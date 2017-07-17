using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZLab_Analyzer
{
    class clsDroppedFile
    {
        
        public string Filename { get; }
        public FileAttributes Attributes { get; }
        public FileInfo Information { get; }
        public bool IsFile { get; }
        public bool IsFolder { get; }

        public bool BadDataHeader { get; }
        public bool IsDataFile { get; }
        public bool Contains_2CircleData { get; }
        public bool Contains_RotationData { get; }
        public bool IsImageFile { get; }
        public string AnimalImage { get; }
        public bool Enabled { get; set; }
        public bool AutoDisabled { get; private set; }

        public int Children_Datafiles { get; set; }
        public int Children_Imagefiles { get; set; }

        public List<int> ExperimentIDs { get; set; }
        
        public SortedList<string, clsDroppedFile> Children { get; }
        public clsDroppedFile Parent { get; }
        public Exception ImportException { get; set; }

        public clsDroppedFile(string sFilename, ref SortedList<int, clsZExportXls> oExperiments, string sWorkingFolder, clsDroppedFile oParent = null)
        {
            Filename = sFilename;
            Attributes = File.GetAttributes(Filename);
            Information = new FileInfo(Filename);
            IsFolder = Attributes.HasFlag(FileAttributes.Directory);
            IsFile = !IsFolder;
            Parent = oParent;
            ExperimentIDs = new List<int>();
            Children_Datafiles = 0;
            Children_Imagefiles = 0;

            if (IsFolder)
            {
                Children = new SortedList<string, clsDroppedFile>();
                foreach (string sSubfolder in Directory.GetDirectories(Filename))
                {
                    Children.Add(sSubfolder, new clsDroppedFile(sSubfolder, ref oExperiments, sWorkingFolder, this));
                }
                string[] sFiles = Directory.GetFiles(Filename);
                if (sFiles.Length != 0)
                {
                    foreach (string sSubfilename in sFiles)
                    {
                        Children.Add(sSubfilename, new clsDroppedFile(sSubfilename, ref oExperiments, sWorkingFolder, this));
                    }
                }
            } else
            {
                IsDataFile = false;
                IsImageFile = false;
                Contains_2CircleData = false;
                Contains_RotationData = false;
                AnimalImage = "";

                string sExt = Information.Extension.ToLower();
                if (sExt.StartsWith(".")) sExt = sExt.Substring(1);
                if (sExt == Constants.sImportExtension_DataFile)
                {
                    string[] sLines = { "", "", "", "", "" };
                    int iCounter = 0;
                    using (StreamReader sr = Information.OpenText())
                    {
                        while (iCounter < 5)
                        {
                            sLines[iCounter] = sr.ReadLine();
                            iCounter++;
                        }
                    }
                    if (sLines[0] == Constants.sInputFirstline)
                    {
                        IsDataFile = true;
                        if (oParent != null) oParent.Children_Datafiles++;
                        try
                        {
                            string[] sItems = sLines[3].Split('\t');
                            if (sItems.Length > 4)
                            {
                                if (sItems[4] == "2")
                                    Contains_2CircleData = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            ImportException = ex;
                        }
                    }
                    else if (sLines[0] == Constants.sInputFirstline_Rotation)
                    {
                        IsDataFile = true;
                        if (oParent != null) oParent.Children_Datafiles++;
                        Contains_RotationData = true;
                    } else
                    {
                        BadDataHeader = true;
                    }

                    if (IsDataFile && (!Contains_2CircleData || Constants.bHandle_2CircleExperiments) && (!Contains_RotationData || Constants.bHandle_RotationExperiments))
                    {
                        int iID = oExperiments.Count;
                        try
                        {
                            oExperiments.Add(iID, new clsZExportXls(this, sWorkingFolder));
                            ExperimentIDs.Add(iID);
                            if (Parent != null)
                            {
                                Parent.AddExperimentIDs(iID);
                            }
                        }
                        catch (Exception ex)
                        {
                            ImportException = ex;
                        }
                    }

                } else if (sExt == Constants.sImportExtension_ImageFile)
                {
                    Match m = Regex.Match(Filename, "_(?<animal>[A-Z][0-9]{2})_1.PNG");
                    if (m.Success)
                    {
                        IsImageFile = true;
                        if (oParent != null) oParent.Children_Imagefiles++;
                        AnimalImage = m.Groups["animal"].Value;
                    }
                }
            }

        }

        public void AddExperimentIDs(int ID)
        {
            ExperimentIDs.Add(ID);
            if (Parent != null)
            {
                Parent.AddExperimentIDs(ID);
            }
        }

        public void ReportToGrid(ref ListView list, ref SortedList<int, clsZExportXls> oExperiments)
        {
            if (IsFolder && Children != null)
            {
                foreach (string sName in Children.Keys)
                {
                    Children[sName].ReportToGrid(ref list, ref oExperiments);
                }
            } else if (IsFile)
            {
                ReportFileToGrid(ref list, ref oExperiments);
            }
        }

        private void ReportFileToGrid(ref ListView list, ref SortedList<int, clsZExportXls> oExperiments)
        {
            if (IsDataFile || BadDataHeader)
            {
                if (ExperimentIDs.Count == 0)
                {
                    string sMessage = "";
                    if (BadDataHeader) sMessage = "Error: Bad first line content";
                    else if (Contains_2CircleData && !Constants.bHandle_2CircleExperiments) sMessage = "Not supported: 2-circle experiment";
                    else if (Contains_RotationData && !Constants.bHandle_RotationExperiments) sMessage = "Not supported: rotation data";
                    else if (ImportException != null) sMessage = "Error importing file: " + ImportException.Message;
                    else sMessage = "Problem importing this file.";
                    ReportFileToGrid(ref list, sMessage);
                }
                else
                {
                    ReportFileToGrid(ref list, new string[] { (Parent != null ? (Parent.Children_Imagefiles / Parent.Children_Datafiles).ToString() : "0"), oExperiments[ExperimentIDs[0]].NumberOfFishes.ToString(), oExperiments[ExperimentIDs[0]].NumberOfTracks.ToString(), oExperiments[ExperimentIDs[0]].NumberOfDuplicateTracks.ToString(), oExperiments[ExperimentIDs[0]].SecondsPerTracking, oExperiments[ExperimentIDs[0]].OverallDurationStr }, (!oExperiments[ExperimentIDs[0]].Handle_File ? "Error: Mismatch in animal counting" : ""));
                }
            }
        }

        private void ReportFileToGrid(ref ListView list, string sErrorMessage)
        {
            ListViewItem li = list.Items.Add("no");
            li.SubItems.Add(Information.Name);
            li.SubItems.Add(sErrorMessage);
            li.SubItems.Add("");
            li.SubItems.Add("");
            li.SubItems.Add("");
            li.SubItems.Add("");
            li.SubItems.Add("");
            li.SubItems.Add("");
            AutoDisabled = true;
            Enabled = false;
        }

        private void ReportFileToGrid(ref ListView list, string[] sColumnData, string sErrorMessage = "")
        {
            ListViewItem li = list.Items.Add((sErrorMessage == "" ? "yes" : "no"));
            li.SubItems.Add(Information.Name);
            li.SubItems.Add(sErrorMessage);
            li.SubItems.Add(sColumnData[0]);
            li.SubItems.Add(sColumnData[1]);
            li.SubItems.Add(sColumnData[2]);
            li.SubItems.Add(sColumnData[3]);
            li.SubItems.Add(sColumnData[4]);
            li.SubItems.Add(sColumnData[5]);
            li.Checked = (sErrorMessage == "");
            AutoDisabled = (sErrorMessage != "");
            Enabled = !AutoDisabled;
        }

    }
}
