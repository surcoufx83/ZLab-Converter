using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ZLab_Analyzer
{
    class clsExportEngine
    {

        public delegate void OnExportDoneHandler(bool ExportResult, int[] ExportedFiles);
        public event OnExportDoneHandler OnExportDone;

        /// <remarks>Not yet implemented</remarks>
        public delegate void OnExportCreatedFolderHandler(string FolderPath);
        public event OnExportCreatedFolderHandler OnExportCreatedFolder;

        /// <remarks>Not yet implemented</remarks>
        public delegate void OnExportCreatedFileHandler(string FilePath);
        public event OnExportCreatedFileHandler OnExportCreatedFile;

        /// <remarks>Not yet implemented</remarks>
        public delegate void OnExportCreatedDataFileHandler(string FilePath);
        public event OnExportCreatedDataFileHandler OnExportCreatedDataFile;

        public delegate void OnExportPrepareSingleChartFileHandler(clsZExportXls Experiment);
        public event OnExportPrepareSingleChartFileHandler OnExportPrepareSingleChartFile;

        public delegate void OnExportExecSaveChartHandler(ChartTypeEnum ChartType, string Filename, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat Format);
        public event OnExportExecSaveChartHandler OnExportExecSaveChart;

        /// <remarks>Not yet implemented</remarks>
        public delegate void OnExportCreatedChartFileHandler(string FilePath);
        public event OnExportCreatedChartFileHandler OnExportCreatedChartFile;
        
        /// <remarks>Not yet implemented</remarks>
        public delegate void OnExportCreatedImageFileHandler(string FilePath);
        public event OnExportCreatedImageFileHandler OnExportCreatedImageFile;

        public int[] ExportData(ref ZLabConfiguration Conf, ref SortedList<int, clsZExportXls> Experiments)
        {

            // 0 = result (0=failed, 1=ok)
            // 1 = number of exported data files xlsx
            // 2 = number of exported data files xlsx
            // 3 = number of exported charts
            // 4 = number of exported images
            int[] iOut = { 0, 0, 0, 0, 0 };

            if (Conf.CurrentFilter.CreateXLSXFile)
                iOut[1] = Export_XLSX(ref Conf, ref Experiments);
            else
                iOut[2] = Export_XLS(ref Conf, ref Experiments);

            if (Conf.CurrentFilter.Charts_CreateFiles)
                iOut[3] = Export_Images(ref Conf, ref Experiments);

            if (OnExportDone != null) OnExportDone(true, iOut);

            return iOut;
        }
        
        private int Export_XLS(ref ZLabConfiguration Conf, ref SortedList<int, clsZExportXls> Experiments)
        {
            string sTarget;
            int iOut = 0;

            foreach (int id in Experiments.Keys)
            {
                if (Conf.CurrentFilter.ExportToCustomFolder)
                {
                    sTarget = Path.Combine(Conf.CurrentFilter.ExportCustomFolder, Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Experiments[id].FileInformation.Extension);
                }
                else
                {
                    sTarget = Path.Combine(Experiments[id].FileInformation.DirectoryName, Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Experiments[id].FileInformation.Extension);
                }
                iOut += Export_XLS(Experiments[id], sTarget, ref Conf);
            }
            if (Conf.CurrentFilter.ExportToCustomFolder && Conf.ShowExplorer)
            {
                System.Diagnostics.Process.Start(Conf.CurrentFilter.ExportCustomFolder);
            }
            return iOut;
        }

        private int Export_XLSX(ref ZLabConfiguration Conf, ref SortedList<int, clsZExportXls> Experiments)
        {
            string sTarget;
            int iOut = 0;

            if (Conf.CurrentFilter.ExportToCustomFolder && Conf.CurrentFilter.Xlsx_MultiWorksheets)
            {
                sTarget = Path.Combine(Conf.CurrentFilter.ExportCustomFolder, (Experiments.Keys.Count > 1 ? Constants.sTargetPrefix + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") : Path.GetFileNameWithoutExtension(Experiments[0].FileInformation.FullName)) + Constants.sTargetSufix + Constants.sExtensionXLSX);
                iOut = Export_XLSX(sTarget, ref Conf, ref Experiments);
            }
            else
            {
                foreach (int id in Experiments.Keys)
                {
                    sTarget = Path.Combine((Conf.CurrentFilter.ExportToCustomFolder ? Conf.CurrentFilter.ExportCustomFolder : Experiments[id].FileInformation.DirectoryName), Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Constants.sExtensionXLSX);
                    iOut += Export_XLSX(Experiments[id], sTarget, id, ref Conf);
                }
            }
            if (Conf.CurrentFilter.ExportToCustomFolder && Conf.ShowExplorer)
            {
                System.Diagnostics.Process.Start(Conf.CurrentFilter.ExportCustomFolder);
            }
            return iOut;
        }

        private int Export_XLS(clsZExportXls Experiment, string sTarget, ref ZLabConfiguration Conf)
        {
            if (File.Exists(sTarget) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTarget), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }

            FileStream fs;
            try
            {
                fs = File.Create(sTarget);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.strings.result_export_error_createfile.Replace("{0}", sTarget).Replace("{1}", ex.Message));
                return 0;
            }

            if (fs != null)
            {
                string sData = Constants.sOutputFirstline;
                if (Conf.CurrentFilter.AdditionalDataColumns) sData += Constants.sOutputFirstlineAddition;
                sData += "\r\n";

                sData += Experiment.GetCleanedTracks(Conf.CurrentFilter);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(sData);
                }

                fs.Close();
                return 1;
            }
            return 0;

        }

        // multi worksheets
        private int Export_XLSX(string sTarget, ref ZLabConfiguration Conf, ref SortedList<int, clsZExportXls> Experiments)
        {
            if (File.Exists(sTarget) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTarget), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }

            SpreadsheetDocument document = SpreadsheetDocument.Create(sTarget, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            uint sid = 1U;
            double[] dTest;
            foreach (int id in Experiments.Keys)
            {

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());
                Sheets sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                if (sheets == null)
                    sheets = workbookPart.Workbook.AppendChild(new Sheets());

                clsZExportXls Experiment = Experiments[id];
                string sSheetName = id.ToString() + " " + Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName);
                if (sSheetName.Length > 30) sSheetName = sSheetName.Substring(0, 30);
                Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = sid, Name = sSheetName };
                sid++;

                XLSX_AddHeaders(ref worksheetPart, Experiment, ref Conf);

                double dTMin_Slow = (double)Conf.CurrentFilter.Track_Slow_Min, dTMax_Slow = (double)Conf.CurrentFilter.Track_Slow_Max, dTValue_Slow;
                double dTMin_Fast = (double)Conf.CurrentFilter.Track_Fast_Min, dTMax_Fast = (double)Conf.CurrentFilter.Track_Fast_Max, dTValue_Fast;
                double dTMin_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Min, dTMax_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Max, dTValue_Inactive;
                double dTMin_Empty = 0.0, dTMax_Empty = (double)Conf.CurrentFilter.Track_Empty_Max, dTValue_Empty;

                bool bRemDupl = Conf.CurrentFilter.RemoveDuplicates;
                bool bRemInva = Conf.CurrentFilter.RemoveLinesWithInvalidSum;

                uint i = 2U;
                if (Conf.CurrentFilter.Xlsx_WithFilterValues)
                    i = 7U;

                foreach (string sFish in Experiment.Fishes.Keys)
                {

                    if (Experiment.Fishes[sFish].FilteredManually)
                        continue;

                    dTest = Experiment.Fishes[sFish].GetFilteredTrackCount(Conf.CurrentFilter);
                    if (dTest[4] < (double)Conf.CurrentFilter.Animal_LinesThreshold)
                        continue;

                    foreach (int key in Experiment.Fishes[sFish].Tracks.Keys)
                    {

                        if (Conf.CurrentFilter.RemoveDuplicates && Experiment.Fishes[sFish].Tracks[key].An == 1) continue;
                        if (Conf.CurrentFilter.RemoveLinesWithInvalidSum && Experiment.Fishes[sFish].Tracks[key].DurationDifferences > (decimal)0.1) continue;

                        dTValue_Slow = (double)Experiment.Fishes[sFish].Tracks[key].RelSmallDuration;
                        dTValue_Fast = (double)Experiment.Fishes[sFish].Tracks[key].RelLargeDuration;
                        dTValue_Inactive = (double)Experiment.Fishes[sFish].Tracks[key].RelInactiveDuration;
                        dTValue_Empty = (double)Experiment.Fishes[sFish].Tracks[key].RelEmptyDuration;

                        if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow) continue;
                        if (dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast) continue;
                        if (dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive) continue;
                        if (dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty) continue;

                        XLSX_AddTrack(ref worksheetPart, Experiment.Fishes[sFish].Tracks[key], i, Experiment.Fishes[sFish].CustomGroup, ref Conf);
                        i++;
                    }

                }

                sheets.Append(sheet);
            }

            workbookPart.Workbook.Save();
            document.Close();
            return 1;

        }

        // multi files
        private int Export_XLSX(clsZExportXls Experiment, string sTarget, int id, ref ZLabConfiguration Conf)
        {
            if (File.Exists(sTarget) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTarget), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }
            
            SpreadsheetDocument document = SpreadsheetDocument.Create(sTarget, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            string sSheetName = Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName);
            if (sSheetName.Length > 30) sSheetName = sSheetName.Substring(0, 30);
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = sSheetName };
            sheets.Append(sheet);

            XLSX_AddHeaders(ref worksheetPart, Experiment, ref Conf);

            double dTMin_Slow = (double)Conf.CurrentFilter.Track_Slow_Min, dTMax_Slow = (double)Conf.CurrentFilter.Track_Slow_Max, dTValue_Slow;
            double dTMin_Fast = (double)Conf.CurrentFilter.Track_Fast_Min, dTMax_Fast = (double)Conf.CurrentFilter.Track_Fast_Max, dTValue_Fast;
            double dTMin_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Min, dTMax_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Max, dTValue_Inactive;
            double dTMin_Empty = 0.0, dTMax_Empty = (double)Conf.CurrentFilter.Track_Empty_Max, dTValue_Empty;

            bool bRemDupl = Conf.CurrentFilter.RemoveDuplicates;
            bool bRemInva = Conf.CurrentFilter.RemoveLinesWithInvalidSum;
            double[] dTest;

            uint i = 2U;
            if (Conf.CurrentFilter.Xlsx_WithFilterValues)
                i = 7U;

            foreach (string sFish in Experiment.Fishes.Keys)
            {

                if (Experiment.Fishes[sFish].FilteredManually)
                    continue;

                dTest = Experiment.Fishes[sFish].GetFilteredTrackCount(Conf.CurrentFilter);
                if (dTest[4] < (double)Conf.CurrentFilter.Animal_LinesThreshold)
                    continue;

                foreach (int key in Experiment.Fishes[sFish].Tracks.Keys)
                {

                    if (Conf.CurrentFilter.RemoveDuplicates && Experiment.Fishes[sFish].Tracks[key].An == 1) continue;
                    if (Conf.CurrentFilter.RemoveLinesWithInvalidSum && Experiment.Fishes[sFish].Tracks[key].DurationDifferences > (decimal)0.1) continue;

                    dTValue_Slow = (double)Experiment.Fishes[sFish].Tracks[key].RelSmallDuration;
                    dTValue_Fast = (double)Experiment.Fishes[sFish].Tracks[key].RelLargeDuration;
                    dTValue_Inactive = (double)Experiment.Fishes[sFish].Tracks[key].RelInactiveDuration;
                    dTValue_Empty = (double)Experiment.Fishes[sFish].Tracks[key].RelEmptyDuration;

                    if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow) continue;
                    if (dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast) continue;
                    if (dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive) continue;
                    if (dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty) continue;

                    XLSX_AddTrack(ref worksheetPart, Experiment.Fishes[sFish].Tracks[key], i, Experiment.Fishes[sFish].CustomGroup, ref Conf);
                    i++;
                }

            }

            workbookPart.Workbook.Save();

            document.Close();
            return 1;

        }

        private int Export_Images(ref ZLabConfiguration Conf, ref SortedList<int, clsZExportXls> Experiments)
        {

            if (!Conf.CurrentFilter.Charts_CreateFiles) return 0;

            string sTargetFolder;
            string sTargetFilename;
            int iOut = 0;

            if (Conf.CurrentFilter.Xlsx_MultiWorksheets && Conf.CurrentFilter.Xlsx_MultiWorksheets)
            {
                sTargetFolder = Conf.CurrentFilter.ExportCustomFolder;
                sTargetFilename = Constants.sTargetPrefix + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                if (Experiments.Keys.Count > 1) iOut += Export_GroupImages(sTargetFolder, sTargetFilename, ref Conf, ref Experiments);
                foreach (int id in Experiments.Keys)
                {
                    iOut += Export_Images(Experiments[id], ref Conf);
                }
            }
            else
            {
                foreach (int id in Experiments.Keys)
                {
                    iOut += Export_Images(Experiments[id], ref Conf);
                }
            }

            return iOut;
            
        }

        private int Export_GroupImages(string sTargetFolder, string sTargetBasename, ref ZLabConfiguration Conf, ref SortedList<int, clsZExportXls> Experiments)
        {
            string sTargetAnimalchart = Path.Combine(sTargetFolder, sTargetBasename + Constants.sTargetChart_AllFiles_AnimalSufix + Constants.sExtensionPNG);
            string sTargetTrackschart = Path.Combine(sTargetFolder, sTargetBasename + Constants.sTargetChart_AllFiles_TrackSufix + Constants.sExtensionPNG);
            string sTargetResultchart = Path.Combine(sTargetFolder, sTargetBasename + Constants.sTargetChart_AllFiles_ResultSufix + Constants.sExtensionPNG);

            if (File.Exists(sTargetAnimalchart) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetAnimalchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }
            if (File.Exists(sTargetTrackschart) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetTrackschart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }
            if (File.Exists(sTargetResultchart) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetResultchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }

            if (OnExportExecSaveChart != null)
            {
                OnExportExecSaveChart(ChartTypeEnum.Imported, sTargetAnimalchart, Constants.sChartFormat);
                OnExportExecSaveChart(ChartTypeEnum.Thresholds, sTargetTrackschart, Constants.sChartFormat);
                OnExportExecSaveChart(ChartTypeEnum.Result, sTargetResultchart, Constants.sChartFormat);
                return 3;
            }
            return 0;

        }

        private int Export_Images(clsZExportXls Experiment, ref ZLabConfiguration Conf)
        {
            string sTargetFolder = (Conf.CurrentFilter.ExportToCustomFolder ? Conf.CurrentFilter.ExportCustomFolder : Experiment.FileInformation.DirectoryName);
            string sTargetAnimalchart = Path.Combine(sTargetFolder, Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName) + Constants.sTargetChart_AnimalSufix + Constants.sExtensionPNG);
            string sTargetResultchart = Path.Combine(sTargetFolder, Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName) + Constants.sTargetChart_ResultSufix + Constants.sExtensionPNG);
            string sTargetTrackschart = Path.Combine(sTargetFolder, Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName) + Constants.sTargetChart_TrackSufix + Constants.sExtensionPNG);

            if (File.Exists(sTargetAnimalchart) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetAnimalchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }
            if (File.Exists(sTargetTrackschart) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetTrackschart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }
            if (File.Exists(sTargetResultchart) && !Conf.CurrentFilter.OverwriteExistingFiles)
            {
                DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetResultchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    MessageBox.Show(Properties.strings.result_export_error_cancelled);
                    return 0;
                }
            }

            if (OnExportPrepareSingleChartFile != null && OnExportExecSaveChart != null)
            {
                OnExportPrepareSingleChartFile(Experiment);
                OnExportExecSaveChart(ChartTypeEnum.Imported, sTargetAnimalchart, Constants.sChartFormat);
                OnExportExecSaveChart(ChartTypeEnum.Thresholds, sTargetTrackschart, Constants.sChartFormat);
                OnExportExecSaveChart(ChartTypeEnum.Result, sTargetResultchart, Constants.sChartFormat);
                return 3;
            }
            return 0;

        }

        private void XLSX_AddHeaders(ref WorksheetPart worksheetPart, clsZExportXls Experiment, ref ZLabConfiguration Conf)
        {

            if (Conf.CurrentFilter.Xlsx_WithFilterValues)
                XLSX_AddFilterdata(ref worksheetPart, Experiment, ref Conf);

            SheetData sd = worksheetPart.Worksheet.Elements<SheetData>().Last();
            Row r = new Row() { RowIndex = (Conf.CurrentFilter.Xlsx_WithFilterValues ? 6U : 1U) };

            XLSX_WriteText(r, "A", "location");
            XLSX_WriteText(r, "B", "animal");
            XLSX_WriteText(r, "C", "group");
            XLSX_WriteText(r, "D", "user");
            XLSX_WriteText(r, "E", "sn");
            XLSX_WriteText(r, "F", "an");
            XLSX_WriteText(r, "G", "datatype");
            XLSX_WriteText(r, "H", "start");
            XLSX_WriteText(r, "I", "end");
            XLSX_WriteText(r, "J", "startreason");
            XLSX_WriteText(r, "K", "endreason");
            XLSX_WriteText(r, "L", "entct");
            XLSX_WriteText(r, "M", "inact");
            XLSX_WriteText(r, "N", "inadur");
            XLSX_WriteText(r, "O", "inadist");
            XLSX_WriteText(r, "P", "smlct");
            XLSX_WriteText(r, "Q", "smldur");
            XLSX_WriteText(r, "R", "smldist");
            XLSX_WriteText(r, "S", "larct");
            XLSX_WriteText(r, "T", "lardur");
            XLSX_WriteText(r, "U", "lardist");
            XLSX_WriteText(r, "V", "emptyct");
            XLSX_WriteText(r, "W", "emptydur");
            XLSX_WriteText(r, "X", "stdate");
            XLSX_WriteText(r, "Y", "sttime");
            if (Conf.CurrentFilter.AdditionalDataColumns)
            {
                XLSX_WriteText(r, "Z", "totaldur");
                XLSX_WriteText(r, "AA", "totaldurdiff");
                XLSX_WriteText(r, "AB", "inadurrel");
                XLSX_WriteText(r, "AC", "smldurrel");
                XLSX_WriteText(r, "AD", "lardurrel");
                XLSX_WriteText(r, "AE", "emptydurel");
                XLSX_WriteText(r, "AF", "totaldist");
                XLSX_WriteText(r, "AG", "inadistrel");
                XLSX_WriteText(r, "AH", "smldistrel");
                XLSX_WriteText(r, "AI", "lardistrel");
            }
            sd.Append(r);
        }

        private void XLSX_AddFilterdata(ref WorksheetPart worksheetPart, clsZExportXls Experiment, ref ZLabConfiguration Conf)
        {
            SheetData sd = worksheetPart.Worksheet.Elements<SheetData>().Last();

            Row r = new Row() { RowIndex = 1U };
            XLSX_WriteText(r, "A", Properties.strings.xlsx_header_description.Replace("{0}", Experiment.Filename));
            sd.Append(r);

            r = new Row() { RowIndex = 2U };
            XLSX_WriteText(r, "A", "");
            sd.Append(r);

            r = new Row() { RowIndex = 3U };
            XLSX_WriteText(r, "A", Properties.strings.xlsx_header_filtermin);
            XLSX_WriteText(r, "AB", Conf.CurrentFilter.Track_Inactive_Min);
            XLSX_WriteText(r, "AC", Conf.CurrentFilter.Track_Slow_Min);
            XLSX_WriteText(r, "AD", Conf.CurrentFilter.Track_Fast_Min);
            sd.Append(r);

            r = new Row() { RowIndex = 4U };
            XLSX_WriteText(r, "A", Properties.strings.xlsx_header_filtermax);
            if (Conf.CurrentFilter.RemoveDuplicates)
                XLSX_WriteText(r, "F", 0);
            if (Conf.CurrentFilter.RemoveLinesWithInvalidSum)
                XLSX_WriteText(r, "AA", (decimal)0.1);
            XLSX_WriteText(r, "AB", Conf.CurrentFilter.Track_Inactive_Max);
            XLSX_WriteText(r, "AC", Conf.CurrentFilter.Track_Slow_Max);
            XLSX_WriteText(r, "AD", Conf.CurrentFilter.Track_Fast_Max);
            XLSX_WriteText(r, "AE", Conf.CurrentFilter.Track_Empty_Max);
            sd.Append(r);

            r = new Row() { RowIndex = 5U };
            XLSX_WriteText(r, "A", "");
            sd.Append(r);

        }

        private void XLSX_AddTrack(ref WorksheetPart worksheetPart, XLS.clsTrack fData, uint iLine, int iFishGroup, ref ZLabConfiguration Conf)
        {
            SheetData sd = worksheetPart.Worksheet.Elements<SheetData>().First();
            Row r = new Row() { RowIndex = iLine };

            XLSX_WriteText(r, "A", fData.Location);
            XLSX_WriteText(r, "B", fData.Fish);
            XLSX_WriteText(r, "C", iFishGroup);
            XLSX_WriteText(r, "D", fData.User);
            XLSX_WriteText(r, "E", fData.Sn);
            XLSX_WriteText(r, "F", fData.An);
            XLSX_WriteText(r, "G", fData.Datatype);
            XLSX_WriteText(r, "H", fData.Start, 0);
            XLSX_WriteText(r, "I", fData.End, 0);
            XLSX_WriteText(r, "J", fData.StartReason);
            XLSX_WriteText(r, "K", fData.EndReason);
            XLSX_WriteText(r, "L", fData.Entct);
            XLSX_WriteText(r, "M", fData.InactiveCount);
            XLSX_WriteText(r, "N", fData.InactiveDuration);
            XLSX_WriteText(r, "O", fData.InactiveDistance);
            XLSX_WriteText(r, "P", fData.SmallCount);
            XLSX_WriteText(r, "Q", fData.SmallDuration);
            XLSX_WriteText(r, "R", fData.SmallDistance);
            XLSX_WriteText(r, "S", fData.LargeCount);
            XLSX_WriteText(r, "T", fData.LargeDuration);
            XLSX_WriteText(r, "U", fData.LargeDistance);
            XLSX_WriteText(r, "V", fData.EmptyCount);
            XLSX_WriteText(r, "W", fData.EmptyDuration);
            XLSX_WriteText(r, "X", fData.TrackDate.ToString("d", ciprovider.Default));
            XLSX_WriteText(r, "Y", fData.TrackDate.ToString("T", ciprovider.Default));

            if (Conf.CurrentFilter.AdditionalDataColumns)
            {

                XLSX_WriteText(r, "Z", fData.DurationSum);
                XLSX_WriteText(r, "AA", fData.DurationDifferences);
                XLSX_WriteText(r, "AB", fData.RelInactiveDuration);
                XLSX_WriteText(r, "AC", fData.RelSmallDuration);
                XLSX_WriteText(r, "AD", fData.RelLargeDuration);
                XLSX_WriteText(r, "AE", fData.RelEmptyDuration);
                XLSX_WriteText(r, "AF", fData.DistanceSum);
                XLSX_WriteText(r, "AG", fData.RelInactiveDistance);
                XLSX_WriteText(r, "AH", fData.RelSmallDistance);
                XLSX_WriteText(r, "AI", fData.RelLargeDistance);

            }
            sd.Append(r);
        }

        private string XLSX_int2string(int iIn)
        {
            return iIn.ToString("N0", ciprovider.Default).Replace(",", "");
        }

        private string XLSX_dec2string(decimal dIn, int iDecimals = 1)
        {
            return dIn.ToString("N" + iDecimals.ToString(), ciprovider.Default).Replace(",", "");
        }

        private void XLSX_WriteText(Row r, string Column, string text)
        {
            Cell c = new Cell()
            {
                CellReference = Column + r.RowIndex.ToString(),
                DataType = CellValues.String,
                CellValue = new CellValue(text),
            };
            r.Append(c);
        }

        private void XLSX_WriteText(Row r, string Column, decimal dNumber, int iDecimals = 1)
        {
            Cell c = new Cell()
            {
                CellReference = Column + r.RowIndex.ToString(),
                DataType = CellValues.Number,
                CellValue = new CellValue(XLSX_dec2string(dNumber, iDecimals)),
            };
            r.Append(c);
        }

        private void XLSX_WriteText(Row r, string Column, int iNumber)
        {
            Cell c = new Cell()
            {
                CellReference = Column + r.RowIndex.ToString(),
                DataType = CellValues.Number,
                CellValue = new CellValue(XLSX_int2string(iNumber)),
            };
            r.Append(c);
        }

    }
}
