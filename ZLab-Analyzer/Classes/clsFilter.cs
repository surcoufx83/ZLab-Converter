using System.Linq;

namespace ZLab_Analyzer
{
    public class clsFilter
    {

        private decimal dDefault0 = (decimal)0.0;
        private decimal dDefault100 = (decimal)100.0;

        // destination
        public bool ExportToCustomFolder { get; set; }
        public string ExportCustomFolder { get; set; }
        public bool OverwriteExistingFiles { get; set; }
        public bool CreateSubfolders { get; set; }

        // filetypes
        public bool CreateXLSXFile { get; set; }
        public bool Xlsx_MultiWorksheets { get; set; }
        public bool Xlsx_WithFilterValues { get; set; }

        // dataoptions
        public bool AdditionalDataColumns { get; set; }
        public bool AdditionalGroupColumns { get; set; }
        public bool ReorderAnimalCounting { get; set; }

        // image merger
        public bool ImageMerger_Enabled { get; set; }

        // chartoptions
        public bool Charts_CreateFiles { get; set; }
        public bool Charts_CreateSubfolder { get; set; }
        public bool Charts_XAxisAnimalname { get; set; }

        // 2circleoptions
        public bool TwoCircle_MergeTracks { get; set; }
        public bool TwoCircle_InnerChart { get; set; }
        public bool TwoCircle_OuterChart { get; set; }
        public bool TwoCircle_CombinedChart { get; set; }

        // other options
        public bool Chart_UpscaleResultchart { get; set; }
        public bool RemoveLinesWithInvalidSum { get; set; }
        public bool RemoveDuplicates { get; set; }

        // thresholds
        public decimal Track_Slow_Min { get; set; }
        public decimal Track_Slow_Max { get; set; }
        public decimal Track_Fast_Min { get; set; }
        public decimal Track_Fast_Max { get; set; }
        public decimal Track_Inactive_Min { get; set; }
        public decimal Track_Inactive_Max { get; set; }
        public decimal Track_Empty_Max { get; set; }
        public decimal Animal_LinesThreshold { get; set; }

        string sName = "";
        string[] sGroupNames = { "", "", "", "", "", "", "", "", "", "" };
        
        public clsFilter()
        {

            ExportToCustomFolder = false;
            ExportCustomFolder = "";
            OverwriteExistingFiles = false;
            CreateSubfolders = false;

            CreateXLSXFile = false;
            Xlsx_MultiWorksheets = false;
            Xlsx_WithFilterValues = false;

            AdditionalDataColumns = true;
            AdditionalGroupColumns = true;
            ReorderAnimalCounting = false;

            ImageMerger_Enabled = false;

            Charts_CreateFiles = false;
            Charts_CreateSubfolder = false;
            Charts_XAxisAnimalname = false;

            TwoCircle_MergeTracks = true;
            TwoCircle_InnerChart = false;
            TwoCircle_OuterChart = false;
            TwoCircle_CombinedChart = false;

            Chart_UpscaleResultchart = true;
            RemoveLinesWithInvalidSum = false;
            RemoveDuplicates = true;

            Track_Slow_Min = dDefault0;
            Track_Fast_Min = dDefault0;
            Track_Inactive_Min = dDefault0;
            Animal_LinesThreshold = dDefault0;

            Track_Slow_Max = dDefault100;
            Track_Fast_Max = dDefault100;
            Track_Inactive_Max = dDefault100;
            Track_Empty_Max = dDefault100;

        }

        public clsFilter(string sImport) : base()
        {
            
            if (sImport.StartsWith("{ ") && sImport.EndsWith(" }"))
            {
                sImport = sImport.Substring(2, sImport.Length - 4);
                string[] sItems = sImport.Split(',');
                for (int i = 0; i < sItems.Count(); i++)
                {
                    sItems[i] = sItems[i].Replace("\"", "").Trim();
                    switch (i)
                    {

                        case 0:
                            ExportToCustomFolder = clsTools.string2bool(sItems[i]);
                            break;

                        case 1:
                            AdditionalDataColumns = clsTools.string2bool(sItems[i]);
                            break;

                        case 2:
                            ExportCustomFolder = sItems[i];
                            break;

                        case 3:
                            RemoveLinesWithInvalidSum = clsTools.string2bool(sItems[i]);
                            break;

                        case 4:
                            RemoveDuplicates = clsTools.string2bool(sItems[i]);
                            break;

                        case 5:
                            CreateSubfolders = clsTools.string2bool(sItems[i]);
                            break;

                        case 6:
                            AdditionalGroupColumns = clsTools.string2bool(sItems[i]);
                            break;

                        case 7:
                            ReorderAnimalCounting = clsTools.string2bool(sItems[i]);
                            break;

                        case 8:
                            ImageMerger_Enabled = clsTools.string2bool(sItems[i]);
                            break;

                        case 9:
                            Charts_CreateSubfolder = clsTools.string2bool(sItems[i]);
                            break;

                        case 10:
                            Charts_XAxisAnimalname = clsTools.string2bool(sItems[i]);
                            break;

                        case 11:
                            TwoCircle_MergeTracks = clsTools.string2bool(sItems[i]);
                            break;

                        case 12:
                            Track_Slow_Min = clsTools.string2dec(sItems[i]);
                            break;

                        case 13:
                            Track_Slow_Max = clsTools.string2dec(sItems[i]);
                            break;

                        case 14:
                            Track_Fast_Min = clsTools.string2dec(sItems[i]);
                            break;

                        case 15:
                            Track_Fast_Max = clsTools.string2dec(sItems[i]);
                            break;

                        case 16:
                            Track_Inactive_Min = clsTools.string2dec(sItems[i]);
                            break;

                        case 17:
                            Track_Inactive_Max = clsTools.string2dec(sItems[i]);
                            break;

                        case 18:
                            Track_Empty_Max = clsTools.string2dec(sItems[i]);
                            break;

                        case 19:
                            CreateXLSXFile = clsTools.string2bool(sItems[i]);
                            break;

                        case 20:
                            Charts_CreateFiles = clsTools.string2bool(sItems[i]);
                            break;

                        case 21:
                            Xlsx_MultiWorksheets = clsTools.string2bool(sItems[i]);
                            break;

                        case 22:
                            OverwriteExistingFiles = clsTools.string2bool(sItems[i]);
                            break;

                        case 23:
                            Xlsx_WithFilterValues = clsTools.string2bool(sItems[i]);
                            break;

                        case 24:
                            TwoCircle_InnerChart = clsTools.string2bool(sItems[i]);
                            break;

                        case 25:
                            TwoCircle_OuterChart = clsTools.string2bool(sItems[i]);
                            break;

                        case 26:
                            Animal_LinesThreshold = clsTools.string2dec(sItems[i]);
                            break;

                        case 27:
                            Chart_UpscaleResultchart = clsTools.string2bool(sItems[i]);
                            break;

                        case 28:
                            sName = sItems[i];
                            break;

                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                            sGroupNames[(i - 29)] = sItems[i];
                            break;

                        case 39:
                            TwoCircle_CombinedChart = clsTools.string2bool(sItems[i]);
                            break;

                        default:
                            continue;
                    }
                }
            }
        }

        public override string ToString()
        {
            return "{ " + clsTools.bool2string(ExportToCustomFolder) + 
                ", " + clsTools.bool2string(AdditionalDataColumns) + 
                ", \"" + ExportCustomFolder + "\"" +
                ", " + clsTools.bool2string(RemoveLinesWithInvalidSum) + 
                ", " + clsTools.bool2string(RemoveDuplicates) + 
                ", " + clsTools.bool2string(CreateSubfolders) + 
                ", " + clsTools.bool2string(AdditionalGroupColumns) + 
                ", " + clsTools.bool2string(ReorderAnimalCounting) + 
                ", " + clsTools.bool2string(ImageMerger_Enabled) + 
                ", " + clsTools.bool2string(Charts_CreateSubfolder) +
                ", " + clsTools.bool2string(Charts_XAxisAnimalname) +
                ", " + clsTools.bool2string(TwoCircle_MergeTracks) +
                ", " + clsTools.dec2string(Track_Slow_Min) + 
                ", " + clsTools.dec2string(Track_Slow_Max) + 
                ", " + clsTools.dec2string(Track_Fast_Min) + 
                ", " + clsTools.dec2string(Track_Fast_Max) + 
                ", " + clsTools.dec2string(Track_Inactive_Min) + 
                ", " + clsTools.dec2string(Track_Inactive_Max) + 
                ", " + clsTools.dec2string(Track_Empty_Max) + 
                ", " + clsTools.bool2string(CreateXLSXFile) + 
                ", " + clsTools.bool2string(Charts_CreateFiles) + 
                ", " + clsTools.bool2string(Xlsx_MultiWorksheets) +
                ", " + clsTools.bool2string(OverwriteExistingFiles) + 
                ", " + clsTools.bool2string(Xlsx_WithFilterValues) + 
                ", " + clsTools.bool2string(TwoCircle_InnerChart) + 
                ", " + clsTools.bool2string(TwoCircle_OuterChart) + 
                ", " + clsTools.dec2string(Animal_LinesThreshold) + 
                ", " + clsTools.bool2string(Chart_UpscaleResultchart) + 
                ", " + sName + 
                ", " + sGroupNames[0] + 
                ", " + sGroupNames[1] + 
                ", " + sGroupNames[2] + 
                ", " + sGroupNames[3] + 
                ", " + sGroupNames[4] + 
                ", " + sGroupNames[5] + 
                ", " + sGroupNames[6] + 
                ", " + sGroupNames[7] + 
                ", " + sGroupNames[8] + 
                ", " + sGroupNames[9] +
                ", " + clsTools.bool2string(TwoCircle_CombinedChart) +
                " }";
        }

        public string Name
        {
            get { return sName; }
            set { sName = value.Replace(",", ".").Replace("{", "_").Replace("}", "_").Replace("[", "_").Replace("]", "_").Replace("(", "_").Replace(")", "_"); }
        }

        public string GroupName(int Index)
        {
            return sGroupNames[Index];
        }

        public void GroupName(int Index, string Value)
        {
            sGroupNames[Index] = Value;
        }

        public string[] GroupNames()
        {
            return sGroupNames;
        }

    }
}
