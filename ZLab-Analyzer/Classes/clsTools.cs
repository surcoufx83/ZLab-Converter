using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ZLab_Analyzer
{

    public static class clsTools
    {

        public static string bool2string(bool bIn)
        {
            return (bIn == true ? "True" : "False");
        }

        public static string dec2string(decimal dIn, int iDecimals=2)
        {
            return dIn.ToString("N" + iDecimals.ToString(), ciprovider.Default);
        }

        public static string int2string(int iIn)
        {
            return iIn.ToString(ciprovider.Default);
        }

        public static string list2string(string[] sInput)
        {
            string sOut = "string[" + sInput.Length.ToString() + "] = {";
            string sItems = "";
            for (int i = 0; i < sInput.Length; i++)
            {
                sItems += ", \"" + sInput[i] + "\"";
            }
            if (sItems != "") sOut += sItems.Substring(2);
            sOut += "}";
            return sOut;
        }

        public static string list2string(List<string> sInput)
        {
            string sOut = "List<string>[" + sInput.Count.ToString() + "] = {";
            string sItems = "";
            foreach (string sItem in sInput)
            {
                sItems += ", \"" + sItem + "\"";
            }
            if (sItems != "") sOut += sItems.Substring(2);
            sOut += "}";
            return sOut;
        }

        public static string list2string(SortedList<string, string> sInput)
        {
            string sOut = "SortedList<string, string>[" + sInput.Count.ToString() + "] = {";
            string sItems = "";
            foreach (string sItem in sInput.Keys)
            {
                sItems += ", " + sItem + " = \"" + sInput[sItem] + "\"";
            }
            if (sItems != "") sOut += sItems.Substring(2);
            sOut += "}";
            return sOut;
        }

        public static bool string2bool(string sIn)
        {
            return (sIn == "True");
        }

        public static decimal string2dec(string sIn)
        {
            decimal d = (decimal)0.0;
            decimal.TryParse(sIn, NumberStyles.Number, ciprovider.Default, out d);
            return d;
        }

        public static int string2int(string sIn)
        {
            int i = 0;
            int.TryParse(sIn, NumberStyles.None, ciprovider.Default, out i);
            return i;
        }

    }

    public static class ciprovider
    {
        public static CultureInfo en_US = CultureInfo.CreateSpecificCulture("en-US");
        public static CultureInfo fr_CA = CultureInfo.CreateSpecificCulture("fr-CA");
        public static CultureInfo Default = CultureInfo.CreateSpecificCulture("en-US");
    }

    public static class Constants
    {

        public const string sApplicationTitle = "ZLab-Converter v1.0";
        public const string sApplicationHeader = "ZLab-Fileconverter";

        public const bool bHandle_2CircleExperiments = true;
        public const bool bHandle_RotationExperiments = false;

        public const string sImportExtension_ImageFile = "png";
        public const string sImportExtension_DataFile = "xls";

        public const string sExtensionPNG = ".png";
        public const string sExtensionXLS = ".xls";
        public const string sExtensionXLSX = ".xlsx";

        public const System.Windows.Forms.DataVisualization.Charting.ChartImageFormat sChartFormat = System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png;

        public const string sInputFirstline = "location\tanimal\tuser\tsn\tan\tdatatype\tstart\tend\tstartreason\tendreason\tentct\tinact\tinadur\tinadist\tsmlct\tsmldur\tsmldist\tlarct\tlardur\tlardist\temptyct\temptydur\tstdate\tsttime";
        public const string sInputFirstline_Rotation = "location\tanimal\tuser\tsn\tan\tdatatype\tstart\tend\tstartreason\tendreason\tentct\tinact\tinadur\tinadist\tsmlct\tsmldur\tsmldist\tlarct\tlardur\tlardist\temptyct\temptydur\tstdate\tsttime\tcw\tccw";
        public const string sOutputFirstline = "location\tanimal\tgroup\tuser\tsn\tan\tdatatype\tstart\tend\tstartreason\tendreason\tentct\tinact\tinadur\tinadist\tsmlct\tsmldur\tsmldist\tlarct\tlardur\tlardist\temptyct\temptydur\tstdate\tsttime";
        public const string sOutputFirstlineAddition = "\ttotaldur\tinadurrel\tsmldurrel\tlardurrel\temptydurel\ttotaldist\tinadistrel\tsmldistrel\tlardistrel";

        public const string sTargetPrefix = "ZLab-Converter_";
        public const string sTargetSufix = ".Cleaned";
        public const string sTargetChart_AnimalSufix = ".Chart-Animals";
        public const string sTargetChart_TrackSufix = ".Chart-Tracks";
        public const string sTargetChart_ResultSufix = ".Chart-Result";
        public const string sTargetChart_AllFiles_AnimalSufix = ".Chart-Animals";
        public const string sTargetChart_AllFiles_TrackSufix = ".Chart-Tracks";
        public const string sTargetChart_AllFiles_ResultSufix = ".Chart-Result";
        public const string sTargetChart_Grouped_AnimalSufix = ".Chart-Animals.Group-{0}";
        public const string sTargetChart_Grouped_TrackSufix = ".Chart-Tracks.Group-{0}";
        public const string sTargetChart_Grouped_ResultSufix = ".Chart-Result.Group-{0}";

        public const string sSupportURL = "https://software-support.fuchs.pub/";
        public const string sErrorReportingUrl = "https://software.fuchs.pub/Error-Reporting/index.php";

        public const decimal dShortcut_AddAmount = (decimal)1.0;
        public const decimal dShortcut_AddShiftAmount = (decimal)5.0;
        public const decimal dShortcut_SubAmount = (decimal)-1.0;
        public const decimal dShortcut_SubShiftAmount = (decimal)-5.0;

    }

    public static class SoftwareModules
    {
        public const string Undefined = "";

        public const string AppExit = "AppExit";
        public const string AppLoader = "AppLoader";
        public const string AppSettings = "AppSetter";

        public const string CheckboxHandler = "BoxAndButtonHandler.Checkboxes";
        public const string ButtonHandler = "BoxAndButtonHandler.Buttons";
        public const string RadioboxHandler = "BoxAndButtonHandler.Radioboxes";
        public const string TextboxHandler = "BoxAndButtonHandler.Textboxes";

        public const string ChartEngine = "ChartEngine";
        public const string ErrorEngine = "ErrorEngine";
        public const string ExportEngine = "ExportEngine";
        public const string FavoritesEngine = "FavoritesEngine";
        public const string FileloaderEngine = "FileloaderEngine";
        public const string FilterEngine = "FilterEngine";
        public const string GroupingEngine = "GroupingEngine";
        public const string HelpEngine = "HelpEngine";
        public const string ResizingEngine = "ResizingEngine";
        public const string TabcontrolEngine = "TabcontrolEngine";

    }

    [Flags] public enum ChartTypeEnum
    {
        Undefined = 0x0,
        Imported = 0x1,
        Thresholds = 0x2,
        Result = 0x4,
        _Grouped = 0x8,
        TwoCircle = 0x10,
    }

}

