using System;
using System.Collections.Generic;
using System.IO;
using ZLab_Analyzer.XLS;

namespace ZLab_Analyzer
{
    class clsZExportXls
    {
        
        string sFilename = "";
        string sPathSource = "";
        string sPathTemp = "";
        FileInfo fiSourceInfo;
        public clsDroppedFile DroppedFile { get; }
        public bool Is2CircleExperiment = false;

        /// <summary>
        /// If set to false, this file won't be used within the converter. It is set to false in the case
        /// that the file contains more or less animals than the first imported data file
        /// </summary>
        public bool Handle_File { get; set; }

        //int iNoOfTracks = 0;
        public int NumberOfFishes { get; set; }
        public int NumberOfTracks { get; set; }
        public int NumberOfDuplicateTracks { get; set; }
        int iColumns = 0;
        int iRows = 0;
        public decimal OverallDuration { get; private set; }
        public decimal SecondsPerTrack { get; private set; }

        SortedList<string, clsFish> lFishes = new SortedList<string, clsFish>();

        public clsZExportXls(clsDroppedFile oFile, string sWorkingDirectory)
        {
            fiSourceInfo = oFile.Information;
            DroppedFile = oFile;
            sFilename = fiSourceInfo.Name;
            sPathSource = fiSourceInfo.DirectoryName;
            sPathTemp = sWorkingDirectory;
            Directory.CreateDirectory(sPathTemp);
            string star = Path.Combine(sPathTemp, "-" + sFilename);
            File.Copy(fiSourceInfo.FullName, star);
            if (File.Exists(star))
            {
                FileAttributes fa = File.GetAttributes(star);
                if ((fa & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    File.SetAttributes(star, fa & ~FileAttributes.ReadOnly);
                }
            }
            NumberOfFishes = 0;
            NumberOfTracks = 0;
            NumberOfDuplicateTracks = 0;
            Handle_File = true;
            Import();
        }

        public void Cleanup()
        {
            string s = Path.Combine(sPathTemp, "-" + sFilename);
            if (File.Exists(s))
                File.Delete(s);
        }

        public void Import()
        {
            string sLine = "";
            string[] sTrack = { };
            string sFirstFish = "";
            bool b2Circle = false;
            using(StreamReader sr = new StreamReader(Path.Combine(sPathTemp, "-" + sFilename)))
            {
                while ((sLine = sr.ReadLine()) != null)
                {
                    if (NumberOfTracks != 0)
                    {
                        sTrack = sLine.Split('\t');
                        if (!lFishes.ContainsKey(sTrack[1]))
                        {
                            if (sFirstFish == "")
                                sFirstFish = sTrack[1];
                            lFishes.Add(sTrack[1], new clsFish(sTrack));
                            if (lFishes[sTrack[1]].Column > iColumns) iColumns = lFishes[sTrack[1]].Column;
                            if (lFishes[sTrack[1]].Row > iRows) iRows = lFishes[sTrack[1]].Row;
                            NumberOfFishes++;
                        }
                        else
                            lFishes[sTrack[1]].AddTrack(sTrack);
                        if (b2Circle == false && sTrack[4] == "2")
                        {
                            b2Circle = true;
                            Is2CircleExperiment = true;
                        }
                        if ((lFishes[sTrack[1]].Tracks[lFishes[sTrack[1]].Tracks.Keys.Count - 1].An == 1 && !b2Circle) || (lFishes[sTrack[1]].Tracks[lFishes[sTrack[1]].Tracks.Keys.Count - 1].An == 2 && b2Circle))
                        {
                            NumberOfDuplicateTracks++;
                        } else
                        {
                            if (sFirstFish == sTrack[1])
                            {
                                if (lFishes[sTrack[1]].Tracks[lFishes[sTrack[1]].Tracks.Keys.Count - 1].DurationDifferences <= (decimal)0.1)
                                    OverallDuration += lFishes[sTrack[1]].Tracks[lFishes[sTrack[1]].Tracks.Keys.Count - 1].StartEndDiff;
                            }
                        }
                    }
                    NumberOfTracks++;
                }
                NumberOfTracks--;
            }
            
            if (sFirstFish != "")
            {
                if (lFishes[sFirstFish].Tracks.Keys.Count != 0)
                {
                    SecondsPerTrack = lFishes[sFirstFish].Tracks[0].StartEndDiff;
                }
            }

        }

        public string GetCleanedTracks(clsFilter oFilter)
        {
            string sOut = "";
            double[] d;
            foreach (string sKey in lFishes.Keys)
            {
                d = lFishes[sKey].GetFilteredTrackCount(oFilter);
                if (d[4] >= (double)oFilter.Animal_LinesThreshold)
                    sOut += lFishes[sKey].GetCleanedTracks(oFilter);
            }
            return sOut;
        }

        public string Filename
        {
            get { return sFilename; }
        }

        public FileInfo FileInformation
        {
            get { return fiSourceInfo; }
        }

        public SortedList<string, clsFish> Fishes
        {
            get { return lFishes; }
        }

        public string Folder
        {
            get { return sPathSource; }
        }

        public int Columns { get { return iColumns; } }
        public int Rows { get { return iRows; } }

        public string SecondsPerTracking
        {
            get
            {
                decimal m = (decimal)0.0;
                decimal o = SecondsPerTrack;
                if (o >= 60)
                {
                    m = Math.Floor(o / 60);
                    o -= (m * 60);
                    return m.ToString("0") + ":" + o.ToString("00") + " m";
                }
                return o.ToString("0") + " s";
            }
        }

        public string OverallDurationStr
        {
            get
            {
                decimal h = (decimal)0.0;
                decimal m = (decimal)0.0;
                decimal s = (decimal)0.0;
                decimal o = OverallDuration;
                if (o >= 3600)
                {
                    h = Math.Floor(o / 3600);
                    o -= (h * 3600);
                }
                if (o >= 60)
                {
                    m = Math.Floor(o / 60);
                    o -= (m * 60);
                }
                s = o;
                return h.ToString("0") + ":" + m.ToString("00") + ":" + s.ToString("00") + " h";
            }
        }

    }
}
