
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Xml.Linq;

namespace ZLab_Analyzer.Forms
{

    public partial class form_converter : Form
    {

        #region AppLoader

        ZLabConfiguration Conf = new ZLabConfiguration();
        CultureInfo ciSysdefault = CultureInfo.CurrentUICulture;
        formSettings SettingsDialog;
        clsExportEngine Export = new clsExportEngine();
        string[] droppedFiles;
        string sWorkingFolder;
        string language;
        SortedList<int, clsZExportXls> Experiments = new SortedList<int, clsZExportXls>();
        SortedList<string, clsDroppedFile> Files = new SortedList<string, clsDroppedFile>();
        SortedList<int, int> ExperimentOrdering = new SortedList<int, int>();
        SortedList<string, int> FilenameToExperimentId = new SortedList<string, int>();
        bool bFiltersShown = false;
        bool bManualResized = false;

        Size sizeSmall = new Size(609, 402);
        Size sizeLarge = new Size(1280, 680);
        Size sizeXLarge = new Size(1280, 939);

        public form_converter()
        {

            sWorkingFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZLab-Analyzer", "Working");
            try
            {
                Directory.CreateDirectory(sWorkingFolder);
            } catch (Exception ex)
            {
                WriteLogEntry(clsErrorLevel.Exception, SoftwareModules.AppLoader, "new form_converter()", new string[] { sWorkingFolder }, "", "", ex);
            }

            language = Conf.CurrentLanguage;
            if (Conf.CustomLanguage)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            InitializeComponent();
            ApplyLanguageSettings();

            SettingsDialog = new formSettings(Conf);
            SettingsDialog.OnChangeUILanguage += SettingsDialog_OnChangeUILanguage;
            SettingsDialog.FormClosed += SettingsDialog_FormClosed;

            Export.OnExportDone += Export_OnExportDone;
            Export.OnExportPrepareSingleChartFile += Export_OnExportPrepareSingleChartFile;
            Export.OnExportExecSaveChart += Export_OnExportExecSaveChart;

            OnExperimentSelectionChanged += Form_converter_OnExperimentSelectionChanged;

        }

        private void formConverter_Load(object sender, EventArgs e)
        {

            formConverter_ResetView();
            bNoDialog = true;

            if (Conf.LastFilter != null)
            {
                lblInfo.Text = Properties.strings.usage_base + Properties.strings.usage_addition;
                checkAutostart.Visible = true;
                checkAutostart.Checked = Conf.AutostartConverting;
            }

            if (Conf.FavoriteFilter0 == null)
                menu_favorites_load1.Enabled = false;
            else
                menu_favorites_load1.Text = Properties.strings.menu_favorites_load_f1.Replace("{0}", Conf.FavoriteFilter0.Name);


            if (Conf.FavoriteFilter1 == null)
                menu_favorites_load2.Enabled = false;
            else
                menu_favorites_load2.Text = Properties.strings.menu_favorites_load_f2.Replace("{0}", Conf.FavoriteFilter1.Name);

            if (Conf.FavoriteFilter2 == null)
                menu_favorites_load3.Enabled = false;
            else
                menu_favorites_load3.Text = Properties.strings.menu_favorites_load_f3.Replace("{0}", Conf.FavoriteFilter2.Name);

            ApplyConfToGui();

            bNoDialog = false;

            CleanOldFiles();

        }

        #endregion

        #region AppSetter

        bool bSettingsOpen = false;
        private void menu_file_settings_Click(object sender, EventArgs e)
        {
            if (!bSettingsOpen)
            {
                SettingsDialog.Show();
                SettingsDialog.BringToFront();
                bSettingsOpen = true;
            }
        }

        private void SettingsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            bSettingsOpen = false;
            SettingsDialog = new formSettings(Conf);
            SettingsDialog.OnChangeUILanguage += SettingsDialog_OnChangeUILanguage;
            SettingsDialog.FormClosed += SettingsDialog_FormClosed;
        }

        #endregion

        #region AppExit

        private void btnExit_Click(object sender, EventArgs e)
        {
            Conf.CopyCurrentToLast();
            Cleanup_ResetFilters();
            Cleanup_CleanLoadedFiles();
            Application.Exit();
        }

        private void formConverter_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExit_Click(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(null, null);
        }

        #endregion

        #region BoxAndButtonHandler

        private bool bNoDialog = false;
        private void OnChange_Thresholds_Track_Slow()
        {
            TextBox tbMin = text_track_slow_min;
            TextBox tbMax = text_track_slow_max;
            decimal[] dValues = { (decimal)-1.0, (decimal)0.0, (decimal)0.0 };
            dValues = OnChange_Threshold(ref tbMin, ref tbMax);
            if (dValues[0] == (decimal)1.0)
            {
                Conf.CurrentFilter.Track_Slow_Min = dValues[1];
                Conf.CurrentFilter.Track_Slow_Max = dValues[2];
                Conf.SaveCurrentFilter();
                ApplyFilterToCharts();
            }
        }

        private void OnChange_Thresholds_Track_Fast()
        {
            TextBox tbMin = text_track_fast_min;
            TextBox tbMax = text_track_fast_max;
            decimal[] dValues = { (decimal)-1.0, (decimal)0.0, (decimal)0.0 };
            dValues = OnChange_Threshold(ref tbMin, ref tbMax);
            if (dValues[0] == (decimal)1.0)
            {
                Conf.CurrentFilter.Track_Fast_Min = dValues[1];
                Conf.CurrentFilter.Track_Fast_Max = dValues[2];
                Conf.SaveCurrentFilter();
                ApplyFilterToCharts();
            }
        }

        private void OnChange_Thresholds_Track_Inactive()
        {
            TextBox tbMin = text_track_inactive_min;
            TextBox tbMax = text_track_inactive_max;
            decimal[] dValues = { (decimal)-1.0, (decimal)0.0, (decimal)0.0 };
            dValues = OnChange_Threshold(ref tbMin, ref tbMax);
            if (dValues[0] == (decimal)1.0)
            {
                Conf.CurrentFilter.Track_Inactive_Min = dValues[1];
                Conf.CurrentFilter.Track_Inactive_Max = dValues[2];
                Conf.SaveCurrentFilter();
                ApplyFilterToCharts();
            }
        }

        private void OnChange_Thresholds_Track_Empty()
        {
            TextBox tbMin = text_track_empty_min;
            TextBox tbMax = text_track_empty_max;
            decimal[] dValues = { (decimal)-1.0, (decimal)0.0, (decimal)0.0 };
            dValues = OnChange_Threshold(ref tbMin, ref tbMax);
            if (dValues[0] == (decimal)1.0)
            {
                Conf.CurrentFilter.Track_Empty_Max = dValues[2];
                Conf.SaveCurrentFilter();
                ApplyFilterToCharts();
            }
        }

        private void OnChange_Thresholds_Animal_Lines()
        {
            TextBox tbMin = text_animal_threshold_min;
            TextBox tbMax = text_animal_threshold_max;
            decimal[] dValues = { (decimal)-1.0, (decimal)0.0, (decimal)0.0 };
            dValues = OnChange_Threshold(ref tbMin, ref tbMax);
            if (dValues[0] == (decimal)1.0)
            {
                Conf.CurrentFilter.Animal_LinesThreshold = dValues[1];
                Conf.SaveCurrentFilter();
                ApplyFilterToCharts();
            }
        }
        
        Color cColError_Text = SystemColors.ButtonFace;
        Color cColClean_Text = SystemColors.WindowFrame;
        Color cColError_Back = Color.OrangeRed;
        Color cColClean_Back = SystemColors.ButtonFace;

        private decimal[] OnChange_Threshold(ref TextBox tbMin, ref TextBox tbMax)
        {
            decimal dMin = (decimal)0.0;
            decimal dMax = (decimal)0.0;
            decimal[] dOut = { (decimal)-1.0, (decimal)0.0, (decimal)0.0 };
            string sMin = tbMin.Text;
            string sMax = tbMax.Text;
            if (sMin == "") sMin = "0.00";
            if (sMax == "") sMax = "0.00";

            bool bMin = decimal.TryParse(sMin, NumberStyles.Number, ciprovider.en_US, out dMin);
            bool bMax = decimal.TryParse(sMax, NumberStyles.Number, ciprovider.en_US, out dMax);
            
            if (!bMin || !bMax)
            {
                OnChange_Threshold_FillBox(ref tbMin, false);
                OnChange_Threshold_FillBox(ref tbMax, false);
                return dOut;
            }
            if (dMin < (decimal)0.0 || dMax < (decimal)0.0 || dMin > (decimal)100.0 || dMax > (decimal)100.0)
            {
                if (dMin < (decimal)0.0 || dMin > (decimal)100.0)
                    OnChange_Threshold_FillBox(ref tbMin, false);
                if (dMax < (decimal)0.0 || dMax > (decimal)100.0)
                    OnChange_Threshold_FillBox(ref tbMax, false);
                return dOut;
            }
            if (dMin >= dMax)
            {
                OnChange_Threshold_FillBox(ref tbMin, false);
                OnChange_Threshold_FillBox(ref tbMax, false);
                return dOut;
            }

            OnChange_Threshold_FillBox(ref tbMin);
            OnChange_Threshold_FillBox(ref tbMax);

            dOut[0] = (decimal)1.0;
            dOut[1] = dMin;
            dOut[2] = dMax;
            return dOut;
        }

        string[] aIncludeThresholdShortcuts = new string[] { "text_track_slow_min", "text_track_slow_max", "text_track_fast_min", "text_track_fast_max", "text_track_inactive_min", "text_track_inactive_max", "text_track_empty_max", "text_animal_threshold_min" };
        private void OnKeyDown_Threshold(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            TextBox box = (TextBox)sender;
            if (Array.IndexOf(aIncludeThresholdShortcuts, box.Name) == -1)
                return;

            switch (e.KeyCode)
            {

                case Keys.Multiply:
                    int v = 0;
                    if (box.Name == "text_track_empty_max") v = 10;
                    else if (box.Name.EndsWith("_max")) v = 100;
                    box.Text = v.ToString();
                    break;

                case Keys.Add:
                case Keys.Oemplus:
                    OnKeyDown_Add_Threshold(ref box, (e.Shift == true ? Constants.dShortcut_AddShiftAmount : Constants.dShortcut_AddAmount));
                    break;

                case Keys.Subtract:
                case Keys.OemMinus:
                    OnKeyDown_Add_Threshold(ref box, (e.Shift == true ? Constants.dShortcut_SubShiftAmount : Constants.dShortcut_SubAmount));
                    break;

                default:
                    return;
            }

            if (box.Name.Contains("_slow_"))
            {
                OnChange_Thresholds_Track_Slow();
                OnLeave_Threshold_Track_Slow();
            }
            else if (box.Name.Contains("_fast_"))
            {
                OnChange_Thresholds_Track_Fast();
                OnLeave_Threshold_Track_Fast();
            }
            else if (box.Name.Contains("_inactive_"))
            {
                OnChange_Thresholds_Track_Inactive();
                OnLeave_Threshold_Track_Inactive();
            }
            else if (box.Name.Contains("_empty_"))
            {
                OnChange_Thresholds_Track_Empty();
                OnLeave_Threshold_Track_Empty();
            }
            else if (box.Name.Contains("_threshold_"))
            {
                OnChange_Thresholds_Animal_Lines();
                OnLeave_Threshold_Animal_Lines();
            }
            
            e.SuppressKeyPress = true;
            return;

        }

        private void OnScroll_Threshold(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            TextBox box = (TextBox)sender;
            if (Array.IndexOf(aIncludeThresholdShortcuts, box.Name) == -1)
                return;
            
            if (e.Delta > 0) OnKeyDown_Add_Threshold(ref box, (((Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Shift) > 0) ? Constants.dShortcut_AddShiftAmount : Constants.dShortcut_AddAmount));
            else if (e.Delta < 0) OnKeyDown_Add_Threshold(ref box, (((Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Shift) > 0) ? Constants.dShortcut_SubShiftAmount : Constants.dShortcut_SubAmount));

            if (box.Name.Contains("_slow_"))
            {
                OnChange_Thresholds_Track_Slow();
                OnLeave_Threshold_Track_Slow();
            }
            else if (box.Name.Contains("_fast_"))
            {
                OnChange_Thresholds_Track_Fast();
                OnLeave_Threshold_Track_Fast();
            }
            else if (box.Name.Contains("_inactive_"))
            {
                OnChange_Thresholds_Track_Inactive();
                OnLeave_Threshold_Track_Inactive();
            }
            else if (box.Name.Contains("_empty_"))
            {
                OnChange_Thresholds_Track_Empty();
                OnLeave_Threshold_Track_Empty();
            }
            else if (box.Name.Contains("_threshold_"))
            {
                OnChange_Thresholds_Animal_Lines();
                OnLeave_Threshold_Animal_Lines();
            }
            
            return;

        }

        private void OnKeyDown_Add_Threshold(ref TextBox box, decimal value)
        {
            decimal t;
            if (decimal.TryParse(box.Text, NumberStyles.Number, ciprovider.en_US, out t))
            {
                t += value;

                if (box.Name.EndsWith("_max") && t > (decimal)100.0) t = (decimal)100.0;
                else if(box.Name.EndsWith("_min") && t < (decimal)0.0) t = (decimal)0.0;

                box.Text = clsTools.dec2string(t);
            }
        }

        string[] aExcludeFromFilling = new string[] { "text_animal_threshold_max", "text_track_empty_min" };
        private void OnChange_Threshold_FillBox(ref TextBox box, bool result = true)
        {
            if (Array.IndexOf(aExcludeFromFilling, box.Name) != -1)
                return;
            if (result)
            {
                box.ForeColor = cColClean_Text;
                box.BackColor = cColClean_Back;
            } else
            {
                box.ForeColor = cColError_Text;
                box.BackColor = cColError_Back;
            }
        }

        private void OnLeave_Threshold_Track_Slow()
        {
            TextBox tbMin = text_track_slow_min;
            TextBox tbMax = text_track_slow_max;
            if (tbMin.ForeColor == cColClean_Text)
            {
                tbMin.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Slow_Min);
            }
            if (tbMax.ForeColor == cColClean_Text)
            {
                tbMax.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Slow_Max);
            }
        }

        private void OnLeave_Threshold_Track_Fast()
        {
            TextBox tbMin = text_track_fast_min;
            TextBox tbMax = text_track_fast_max;
            if (tbMin.ForeColor == cColClean_Text)
            {
                tbMin.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Fast_Min);
            }
            if (tbMax.ForeColor == cColClean_Text)
            {
                tbMax.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Fast_Max);
            }
        }

        private void OnLeave_Threshold_Track_Inactive()
        {
            TextBox tbMin = text_track_inactive_min;
            TextBox tbMax = text_track_inactive_max;
            if (tbMin.ForeColor == cColClean_Text)
            {
                tbMin.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Inactive_Min);
            }
            if (tbMax.ForeColor == cColClean_Text)
            {
                tbMax.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Inactive_Max);
            }
        }

        private void OnLeave_Threshold_Track_Empty()
        {
            TextBox tbMax = text_track_empty_max;
            if (tbMax.ForeColor == cColClean_Text)
            {
                tbMax.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Empty_Max);
            }
        }

        private void OnLeave_Threshold_Animal_Lines()
        {
            TextBox tbMin = text_animal_threshold_min;
            if (tbMin.ForeColor == cColClean_Text)
            {
                tbMin.Text = clsTools.dec2string(Conf.CurrentFilter.Animal_LinesThreshold);
            }
        }

        private void text_track_slow_min_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Slow();
        }

        private void text_track_slow_max_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Slow();
        }

        private void text_track_fast_min_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Fast();
        }

        private void text_track_fast_max_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Fast();
        }

        private void text_track_inactive_min_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Inactive();
        }

        private void text_track_inactive_max_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Inactive();
        }

        private void text_track_empty_max_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Track_Empty();
        }

        private void text_animal_threshold_min_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnChange_Thresholds_Animal_Lines();
        }

        private void text_track_slow_min_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Slow();
        }

        private void text_track_slow_max_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Slow();
        }

        private void text_track_fast_min_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Fast();
        }

        private void text_track_fast_max_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Fast();
        }

        private void text_track_inactive_min_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Inactive();
        }

        private void text_track_inactive_max_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Inactive();
        }

        private void text_track_empty_max_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Track_Empty();
        }

        private void text_animal_threshold_min_Leave(object sender, EventArgs e)
        {
            OnLeave_Threshold_Animal_Lines();
        }

        private void list_Animals_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (bListbox_Loader) return;

            ListViewGroup lg = list_Animals.Groups[e.Item.Group.Name];
            foreach (int id in Experiments.Keys)
            {
                if (Experiments[id].Filename == lg.Header)
                {
                    if (Experiments[id].Fishes.ContainsKey(e.Item.Text))
                    {
                        Experiments[id].Fishes[e.Item.Text].FilteredManually = !e.Item.Checked;
                    }
                }
            }
            ApplyFilterToCharts();
        }

        private void OnButtonBack_Click(object sender, EventArgs e)
        {
            tabcontrol.SelectTab(tabcontrol.SelectedIndex - 1);
        }

        private void OnButtonNext_Click(object sender, EventArgs e)
        {
            tabcontrol.SelectTab(tabcontrol.SelectedIndex + 1);
        }

        private void OnCheckbox_CheckChanged(object sender, EventArgs e)
        {
            if (bNoDialog) return;
            CheckBox box = (CheckBox)sender;
            switch (box.Name)
            {

                case "check_dataoptions_addsumcolumns":
                    Conf.CurrentFilter.AdditionalDataColumns = box.Checked;
                    break;

                case "check_dataoptions_addgroupcolumns":
                    Conf.CurrentFilter.AdditionalGroupColumns = box.Checked;
                    break;

                case "check_dataoptions_reordercounting":
                    Conf.CurrentFilter.ReorderAnimalCounting = box.Checked;
                    break;

                case "check_imagemerger_enabled":
                    Conf.CurrentFilter.ImageMerger_Enabled = box.Checked;
                    break;

                case "check_chartoptions_savecharts":
                    Conf.CurrentFilter.Charts_CreateFiles = box.Checked;
                    break;

                case "check_chartoptions_ownfolder":
                    Conf.CurrentFilter.Charts_CreateSubfolder = box.Checked;
                    break;

                case "check_chartoptions_xaxis_animalname":
                    Conf.CurrentFilter.Charts_XAxisAnimalname = box.Checked;
                    goto case "-1";

                case "check_2circle_merge":
                    Conf.CurrentFilter.TwoCircle_MergeTracks = box.Checked;
                    break;

                case "check_2circle_chart_inner":
                    Conf.CurrentFilter.TwoCircle_InnerChart = box.Checked;
                    break;

                case "check_2circle_chart_outer":
                    Conf.CurrentFilter.TwoCircle_OuterChart = box.Checked;
                    break;

                case "check_2circle_chart_combined":
                    Conf.CurrentFilter.TwoCircle_CombinedChart = box.Checked;
                    break;

                case "check_destination_overwritefiles":
                    Conf.CurrentFilter.OverwriteExistingFiles = box.Checked;
                    break;

                case "check_destination_subfolders":
                    Conf.CurrentFilter.CreateSubfolders = box.Checked;
                    break;

                case "check_filetype_xlsx_multisheet":
                    Conf.CurrentFilter.Xlsx_MultiWorksheets = box.Checked;
                    break;

                case "check_filetype_xlsx_includefilters":
                    Conf.CurrentFilter.Xlsx_WithFilterValues = box.Checked;
                    break;

                case "check_chart_upscaling":
                    Conf.CurrentFilter.Chart_UpscaleResultchart = box.Checked;
                    goto case "-1";

                case "check_clean_duplicates":
                    Conf.CurrentFilter.RemoveDuplicates = box.Checked;
                    goto case "-1";

                case "check_clean_invalidsum":
                    Conf.CurrentFilter.RemoveLinesWithInvalidSum = box.Checked;
                    goto case "-1";

                case "checkAutostart":
                    Conf.AutostartConverting = box.Checked;
                    break;

                case "-1":
                    ApplyFilterToCharts();
                    break;

                default: return;
            }
            Conf.SaveCurrentFilter();
        }

        private void OnRadioButton_CheckChanged(object sender, EventArgs e)
        {
            if (bNoDialog) return;
            RadioButton box = (RadioButton)sender;
            switch (box.Name)
            {

                case "radio_destination_custom":
                    if (box.Checked == true)
                    {
                        DialogResult r = folderBrowserDialog1.ShowDialog();
                        if (r == DialogResult.Cancel)
                        {
                            radio_destination_custom.Checked = false;
                            radio_destination_importfolder.Checked = true;
                            radio_destination_custom.Text = Properties.strings.destination_checkbox_otherfolder.Replace("{0}", "");
                        }
                        else if (r == DialogResult.OK)
                        {
                            Conf.CurrentFilter.ExportCustomFolder = folderBrowserDialog1.SelectedPath;
                            radio_destination_custom.Text = Properties.strings.destination_checkbox_otherfolder.Replace("{0}", ": " + Conf.CurrentFilter.ExportCustomFolder);
                        }
                    }
                    Conf.CurrentFilter.ExportToCustomFolder = box.Checked;
                    check_filetype_xlsx_multisheet.Enabled = (radio_filetype_xlsx.Checked && !radio_destination_importfolder.Checked);
                    break;

                case "radio_filetype_xlsx":
                    Conf.CurrentFilter.CreateXLSXFile = box.Checked;
                    Conf.SaveCurrentFilter();
                    check_filetype_xlsx_includefilters.Enabled = box.Checked;
                    check_filetype_xlsx_multisheet.Enabled = box.Checked;
                    break;

                case "-1":
                    ApplyFilterToCharts();
                    break;

                default: return;
            }
            Conf.SaveCurrentFilter();
        }

        #endregion

        #region ChartEngine

        private void OnChange_Track_UpdateDiagram(clsZExportXls Experiment = null)
        {
            OnChange_Track_UpdateDiagram_Combined(Experiment);
            return;
        }

        private void OnChange_Track_UpdateDiagram_Combined(clsZExportXls Experiment = null)
        {

            string[] sChart_Name = { "_Track_Exported", "_Filter_Threshold", "_Filter_Inactive", "_Filter_Slow", "_Filter_Fast", "_Filter_Empty", "_Track_Threshold" };
            string[] sChart_Title = { Properties.strings.chart_filter_legend_0, Properties.strings.chart_filter_legend_1, Properties.strings.chart_filter_legend_2, Properties.strings.chart_filter_legend_3, Properties.strings.chart_filter_legend_4, Properties.strings.chart_filter_legend_5, Properties.strings.chart_filter_legend_6 };
            int[] sChart_Pointer = { -2, -3, 2, 0, 1, 3, -1 };

            Color[] cChart_Color = {
                Color.LimeGreen,
                Color.Gainsboro,
                Color.Gray,
                Color.LightSkyBlue,
                Color.SteelBlue,
                Color.FromArgb(64, 64, 64),
                Color.OrangeRed,
            };

            chart_thresholds.Series.Clear();
            chart_thresholds.ChartAreas[0].AxisY.Title = Properties.strings.chart_axis_y_lines;
            Font f = new Font("Segoe UI Historic", (float)6.0, FontStyle.Regular);

            chart_thresholds.PaletteCustomColors = cChart_Color;

            int iCounter = 0;

            //foreach (int id in Experiments.Keys)
            foreach (int iKey in ExperimentOrdering.Keys)
            {

                if (!Experiments.ContainsKey(ExperimentOrdering[iKey]))
                    continue;

                int id = ExperimentOrdering[iKey];

                if (!Experiments[id].Handle_File)
                    continue;

                if (!Experiments[id].DroppedFile.Enabled)
                    continue;

                if (Experiment != null)
                {
                    if (Experiment.Filename != Experiments[id].Filename)
                        continue;
                }

                for (int i = 0; i < 7; i++)
                {
                    chart_thresholds.Series.Add(id.ToString() + sChart_Name[i]);
                    chart_thresholds.Series[id.ToString() + sChart_Name[i]].ChartArea = chart_thresholds.ChartAreas[0].Name;
                    chart_thresholds.Series[id.ToString() + sChart_Name[i]].ChartType = (i == 6 ? SeriesChartType.Line : SeriesChartType.StackedColumn);
                    chart_thresholds.Series[id.ToString() + sChart_Name[i]].Font = f;
                    chart_thresholds.Series[id.ToString() + sChart_Name[i]].IsXValueIndexed = true;
                    if (iCounter == 0)
                    {
                        chart_thresholds.Series[id.ToString() + sChart_Name[i]].Legend = chart_thresholds.Legends[0].Name;
                        chart_thresholds.Series[id.ToString() + sChart_Name[i]].LegendText = sChart_Title[i];
                    }
                    else
                        chart_thresholds.Series[id.ToString() + sChart_Name[i]].IsVisibleInLegend = false;
                    if (i != 6) chart_thresholds.Series[id.ToString() + sChart_Name[i]].SetCustomProperty("StackedGroupName", id.ToString());
                    else
                    {
                        chart_thresholds.Series[id.ToString() + sChart_Name[i]].BorderDashStyle = ChartDashStyle.Dash;
                        chart_thresholds.Series[id.ToString() + sChart_Name[i]].BorderWidth = 3;
                    }
                }

                iCounter++;


                int x = 1;
                int point = 0;
                double[] dValues;
                double dThreshold = (double)Conf.CurrentFilter.Animal_LinesThreshold;
                foreach (string fish in Experiments[id].Fishes.Keys)
                {

                    dValues = Experiments[id].Fishes[fish].GetFilteredTrackCount(Conf.CurrentFilter);

                    for (int i = 0; i < 7; i++)
                    {
                        if (sChart_Pointer[i] >= 0)
                            point = chart_thresholds.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, dValues[sChart_Pointer[i]]);
                        else
                        {
                            switch (sChart_Pointer[i])
                            {

                                case -1:
                                    point = chart_thresholds.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, dThreshold);
                                    break;

                                case -2:
                                    if (dValues[4] >= dThreshold)
                                        point = chart_thresholds.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, dValues[4]);
                                    else
                                        point = chart_thresholds.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, 0.0d);
                                    break;

                                case -3:
                                    if (dValues[4] < dThreshold)
                                        point = chart_thresholds.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, dValues[4]);
                                    else
                                        point = chart_thresholds.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, 0.0d);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    x++;
                }

            }

        }


        bool bAnimalDiagramMode = false; // true = filtered, false = normal
        private void OnChange_Animal_UpdateDiagram(clsZExportXls Experiment = null)
        {

            if (bAnimalDiagramMode)
            {
                OnChange_Animal_UpdateDiagram_Second(Experiment);
            }

            string[] sChart_Name = { "_Inactive", "_Slow", "_Fast", "_Empty" };
            string[] sChart_Title = { Properties.strings.chart_animals_unfiltered_0, Properties.strings.chart_animals_unfiltered_1, Properties.strings.chart_animals_unfiltered_2, Properties.strings.chart_animals_unfiltered_3 };
            int[] sChart_Pointer = { 2, 0, 1, 3 };

            Color[] cChart_Color = {
                Color.Gray,
                Color.LightSkyBlue,
                Color.SteelBlue,
                Color.FromArgb(64, 64, 64),
            };

            chart_importeddata.Series.Clear();
            chart_importeddata.ChartAreas[0].AxisY.Title = Properties.strings.chart_axis_y_time;
            Font f = new Font("Segoe UI Historic", (float)6.0, FontStyle.Regular);
            chart_importeddata.PaletteCustomColors = cChart_Color;

            int iCounter = 0;

            //foreach (int id in Experiments.Keys)
            foreach (int iKey in ExperimentOrdering.Keys)
            {

                if (!Experiments.ContainsKey(ExperimentOrdering[iKey]))
                    continue;

                int id = ExperimentOrdering[iKey];

                if (!Experiments[id].Handle_File)
                    continue;

                if (!Experiments[id].DroppedFile.Enabled)
                    continue;

                if (Experiment != null)
                {
                    if (Experiment.Filename != Experiments[id].Filename)
                        continue;
                }

                for (int i = 0; i < 4; i++)
                {
                    chart_importeddata.Series.Add(id.ToString() + sChart_Name[i]);
                    chart_importeddata.Series[id.ToString() + sChart_Name[i]].ChartArea = chart_importeddata.ChartAreas[0].Name;
                    chart_importeddata.Series[id.ToString() + sChart_Name[i]].ChartType = SeriesChartType.StackedColumn;
                    chart_importeddata.Series[id.ToString() + sChart_Name[i]].Font = f;
                    chart_importeddata.Series[id.ToString() + sChart_Name[i]].IsXValueIndexed = true;
                    if (iCounter == 0)
                    {
                        chart_importeddata.Series[id.ToString() + sChart_Name[i]].Legend = chart_importeddata.Legends[0].Name;
                        chart_importeddata.Series[id.ToString() + sChart_Name[i]].LegendText = sChart_Title[i];
                    }
                    else
                        chart_importeddata.Series[id.ToString() + sChart_Name[i]].IsVisibleInLegend = false;
                    chart_importeddata.Series[id.ToString() + sChart_Name[i]].SetCustomProperty("StackedGroupName", id.ToString());
                }

                iCounter++;

                int x = 1;
                int point = 0;
                double[] dValues;
                foreach (string fish in Experiments[id].Fishes.Keys)
                {

                    dValues = Experiments[id].Fishes[fish].GetTrackTimes(Conf.CurrentFilter);

                    for (int i = 0; i < 4; i++)
                    {
                        point = chart_importeddata.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, dValues[sChart_Pointer[i]]);
                    }

                    x++;
                }

            }

        }
        private void OnChange_Animal_UpdateDiagram_Second(clsZExportXls Experiment = null)
        {

            string[] sChart_Name = { "_Inactive", "_Slow", "_Fast", "_Empty" };
            string[] sChart_Title = { Properties.strings.chart_animals_result_0, Properties.strings.chart_animals_result_1, Properties.strings.chart_animals_result_2, Properties.strings.chart_animals_result_3 };
            int[] sChart_Pointer = { 2, 0, 1, 3 };

            Color[] cChart_Color = {
                Color.Gray,
                Color.LightSkyBlue,
                Color.SteelBlue,
                Color.FromArgb(64, 64, 64),
            };

            chart_result.Series.Clear();
            chart_result.ChartAreas[0].AxisY.Title = Properties.strings.chart_axis_y_time;
            Font f = new Font("Segoe UI Historic", (float)6.0, FontStyle.Regular);
            chart_result.PaletteCustomColors = cChart_Color;

            int iCounter = 0;

            //foreach (int id in Experiments.Keys)
            foreach (int iKey in ExperimentOrdering.Keys)
            {

                if (!Experiments.ContainsKey(ExperimentOrdering[iKey]))
                    continue;

                int id = ExperimentOrdering[iKey];

                if (!Experiments[id].Handle_File)
                    continue;

                if (!Experiments[id].DroppedFile.Enabled)
                    continue;

                if (Experiment != null)
                {
                    if (Experiment.Filename != Experiments[id].Filename)
                        continue;
                }

                for (int i = 0; i < 4; i++)
                {
                    chart_result.Series.Add(id.ToString() + sChart_Name[i]);
                    chart_result.Series[id.ToString() + sChart_Name[i]].ChartArea = chart_result.ChartAreas[0].Name;
                    chart_result.Series[id.ToString() + sChart_Name[i]].ChartType = SeriesChartType.StackedColumn;
                    chart_result.Series[id.ToString() + sChart_Name[i]].Font = f;
                    chart_result.Series[id.ToString() + sChart_Name[i]].IsXValueIndexed = true;
                    if (iCounter == 0)
                    {
                        chart_result.Series[id.ToString() + sChart_Name[i]].Legend = chart_result.Legends[0].Name;
                        chart_result.Series[id.ToString() + sChart_Name[i]].LegendText = sChart_Title[i];
                    }
                    else
                        chart_result.Series[id.ToString() + sChart_Name[i]].IsVisibleInLegend = false;
                    chart_result.Series[id.ToString() + sChart_Name[i]].SetCustomProperty("StackedGroupName", "a" + id.ToString());

                }

                iCounter++;

                int x = 1;
                int point = 0;
                double[] dValues;
                foreach (string fish in Experiments[id].Fishes.Keys)
                {
                    dValues = Experiments[id].Fishes[fish].GetTrackTimes_PostProcessing(Conf.CurrentFilter);

                    for (int i = 0; i < 4; i++)
                    {
                        point = chart_result.Series[id.ToString() + sChart_Name[i]].Points.AddXY(x, dValues[sChart_Pointer[i]]);
                    }

                    x++;
                }

            }

        }

        private void Form_converter_OnExperimentSelectionChanged()
        {
            ApplyFilterToCharts();
        }

        #endregion

        #region ErrorEngine

        string sSupport_LogFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZLab-Analyzer", "app.log.xml");
        string sSupport_LogFile_Old = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZLab-Analyzer", "app.log-1.xml");
        private XDocument ErrorLogDocument;

        private string ErrorLevelName(int iLevel)
        {
            switch (iLevel)
            {
                case 0: return "Undefined";
                case 10: return "Information";
                case 20: return "Exception";
                case 40: return "SoftwareCrash";
                default: return "";
            }
        }

        private void LoadLogfile()
        {
            if (!File.Exists(sSupport_LogFile))
            {
                ErrorLogDocument = new XDocument(new XElement("zlab-report-entries"));
                Directory.CreateDirectory(Path.GetDirectoryName(sSupport_LogFile));
                ErrorLogDocument.Save(sSupport_LogFile);
            } else
            {
                FileInfo fi = new FileInfo(sSupport_LogFile);
                if (fi.Length > 5242880L)
                {
                    if (File.Exists(sSupport_LogFile_Old)) File.Delete(sSupport_LogFile_Old);
                    File.Move(sSupport_LogFile, sSupport_LogFile_Old);
                    ErrorLogDocument = new XDocument(new XElement("zlab-report-entries"));
                    Directory.CreateDirectory(Path.GetDirectoryName(sSupport_LogFile));
                    ErrorLogDocument.Save(sSupport_LogFile);
                }
                else
                    ErrorLogDocument = XDocument.Load(sSupport_LogFile);
            }
        }

        public void WriteLogEntry(int iSeverity, string sModule, string sFunction, string[]sArguments, string sMessage, string sFilename="", Exception eException=null, bool bNoUpload=false)
        {
            if (ErrorLogDocument == null)
                LoadLogfile();
            string sLogEntry = "entry-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            ErrorLogDocument.Element("zlab-report-entries").Add(new XElement(sLogEntry,
                new XElement("a-DateTime", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.FFF K")),
                new XElement("a-Severity", iSeverity.ToString() + "-" + ErrorLevelName(iSeverity)),
                new XElement("b-Module", sModule),
                new XElement("c-Function", sFunction),
                new XElement("d-Message", sMessage),
                new XElement("e-Exception", (eException != null ? eException.Message : "null")),
                new XElement("e-StackTrace", (eException != null ? eException.StackTrace.Replace("\r\n", "") : "null")),
                new XElement("c-Function-Arguments")
                ));
            if (sArguments.Length != 0)
            {
                for (int i=0; i<sArguments.Length; i++)
                {
                    ErrorLogDocument.Element("zlab-report-entries").Element(sLogEntry).Element("c-Function-Arguments").Add(new XElement("arg-" + i.ToString(), sArguments[i]));
                }
            }
            SaveLogFile();
            if (iSeverity >= Conf.ErrorReporting_AutoReport_MinLevel && !bNoUpload)
            {
                SortedList<string, string> items = new SortedList<string, string>();
                items.Add("MAX_FILE_SIZE", "5242880");
                items.Add("bugreport_header", "auto-report");
                items.Add("bugreport_severity", iSeverity.ToString());
                items.Add("bugreport_datetime", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.FFF K"));
                items.Add("bugreport_version", Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf(".")));
                items.Add("bugreport_module", sModule);
                items.Add("bugreport_function", sFunction);
                items.Add("bugreport_message", sMessage);
                items.Add("bugreport_exception", (eException != null ? eException.Message : "null"));
                items.Add("bugreport_stacktrace", (eException != null ? eException.StackTrace.Replace("\r\n", "") : "null"));
                UploadErrorreport(items, sArguments);
            }
        }

        private void UploadErrorreport(SortedList<string, string> values, string[] sArguments)
        {
            try
            {
                var request = WebRequest.Create(Constants.sErrorReportingUrl);
                request.Method = "POST";
                var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.Credentials = new NetworkCredential("ZLab-BugReporter", "YlsA3942GgoZNzht8mLLLXXnxZvVPArou5lVKNsSiZt5ZFBNb5L0GBVBzbJ2u0vH");
                boundary = "--" + boundary;

                using (var requestStream = request.GetRequestStream())
                {
                    // Write the values
                    foreach (string name in values.Keys)
                    {
                        var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                        requestStream.Write(buffer, 0, buffer.Length);
                        buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                        requestStream.Write(buffer, 0, buffer.Length);
                        buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                        requestStream.Write(buffer, 0, buffer.Length);
                    }

                    // Write arguments 
                    for (int i = 0; i < sArguments.Length; i++)
                    {
                        var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                        requestStream.Write(buffer, 0, buffer.Length);
                        buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", "bugreport_function_argument[]", Environment.NewLine));
                        requestStream.Write(buffer, 0, buffer.Length);
                        buffer = Encoding.UTF8.GetBytes("\"" + sArguments[i] + "\"" + Environment.NewLine);
                        requestStream.Write(buffer, 0, buffer.Length);
                    }

                    var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                    requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
                    requestStream.Flush();
                }

                byte[] bData;
                using (var response = request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var stream = new MemoryStream())
                {
                    responseStream.CopyTo(stream);
                    bData = stream.ToArray();
                }
                if (bData != null)
                {
                    string sOut = Encoding.Default.GetString(bData);
                }
            } catch (Exception ex)
            {
                WriteLogEntry(clsErrorLevel.Exception, SoftwareModules.ErrorEngine, "UploadErrorreport", new string[] { "values = " + clsTools.list2string(values), "sArguments = " + clsTools.list2string(sArguments) }, "Error uploading data to software support site or downloading response.", "", ex, true);
            }
            
        }

        private void SaveLogFile()
        {
            ErrorLogDocument.Save(sSupport_LogFile);
        }

        #endregion

        #region EventHandler
        
        public delegate void OnExperimentSelectionChangedHandler();
        public event OnExperimentSelectionChangedHandler OnExperimentSelectionChanged;


        #endregion

        #region ExportEngine

        private void btnCreate_Click(object sender, EventArgs e)
        {
            text_howto_destination.Text = Properties.strings.result_exporting;
            try
            {
                Export.ExportData(ref Conf, ref Experiments);
            }
            catch (Exception ex)
            {
                WriteLogEntry(clsErrorLevel.Exception, SoftwareModules.ExportEngine, "Export.ExportData", new string[] { }, "", "", ex);
            }

            //if (Conf.CurrentFilter.Save_XLSX == true)
            //    i = OnExport_XLSX();
            //else
            //    i = OnExport_XLS();
            //OnExport_Images();
        }

        private void Export_OnExportDone(bool ExportResult, int[] ExportedFiles)
        {
            ApplyFilterToCharts();
            text_howto_destination.Text = Properties.strings.result_export_done.Replace("{0}", (ExportedFiles[1] + ExportedFiles[2]).ToString()).Replace("{1}", ExportedFiles[3].ToString());
        }

        private void Export_OnExportPrepareSingleChartFile(clsZExportXls Experiment)
        {
            OnChange_Animal_UpdateDiagram(Experiment);
            OnChange_Track_UpdateDiagram(Experiment);
        }

        private void Export_OnExportExecSaveChart(ChartTypeEnum ChartType, string Filename, ChartImageFormat Format)
        {
            if (ChartType.HasFlag(ChartTypeEnum.Imported))
            {
                chart_importeddata.SaveImage(Filename, Format);
            }
            else if (ChartType.HasFlag(ChartTypeEnum.Thresholds))
            {
                chart_thresholds.SaveImage(Filename, Format);
            }
            else if (ChartType.HasFlag(ChartTypeEnum.Result))
            {
                chart_result.SaveImage(Filename, Format);
            }
        }

        //private int OnExport_XLS()
        //{
        //    string sTarget;
        //    int iout = 0;
        //    foreach (int id in Experiments.Keys)
        //    {
        //        if (Conf.CurrentFilter.SaveToCustomFolder)
        //        {
        //            sTarget = Path.Combine(Conf.CurrentFilter.CustomSaveFolder, Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Experiments[id].FileInformation.Extension);
        //        }
        //        else
        //        {
        //            sTarget = Path.Combine(Experiments[id].FileInformation.DirectoryName, Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Experiments[id].FileInformation.Extension);
        //        }
        //        iout += OnExport_XLS(Experiments[id], sTarget);
        //    }
        //    if (Conf.CurrentFilter.SaveToCustomFolder)
        //    {
        //        System.Diagnostics.Process.Start(Conf.CurrentFilter.CustomSaveFolder);
        //    }
        //    return iout;
        //}

        //private int OnExport_XLSX()
        //{
        //    string sTarget;
        //    int iout = 0;
        //    if (Conf.CurrentFilter.SaveToCustomFolder && Conf.CurrentFilter.Save_XLSX_MultiWorksheets)
        //    {
        //        sTarget = Path.Combine(Conf.CurrentFilter.CustomSaveFolder, Constants.sTargetPrefix + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + Constants.sTargetSufix + Constants.sExtensionXLSX);
        //        iout = OnExport_XLSX(sTarget);
        //    }
        //    else
        //    {
        //        foreach (int id in Experiments.Keys)
        //        {
        //            if (Conf.CurrentFilter.SaveToCustomFolder)
        //                sTarget = Path.Combine(Conf.CurrentFilter.CustomSaveFolder, Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Constants.sExtensionXLSX);
        //            else
        //                sTarget = Path.Combine(Experiments[id].FileInformation.DirectoryName, Path.GetFileNameWithoutExtension(Experiments[id].FileInformation.FullName) + Constants.sTargetSufix + Constants.sExtensionXLSX);
        //            iout += OnExport_XLSX(Experiments[id], sTarget, id);
        //        }
        //    }
        //    if (Conf.CurrentFilter.SaveToCustomFolder)
        //    {
        //        System.Diagnostics.Process.Start(Conf.CurrentFilter.CustomSaveFolder);
        //    }
        //    return iout;
        //}

        //private int OnExport_XLS(clsZExportXls Experiment, string sTarget)
        //{
        //    if (File.Exists(sTarget) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTarget), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return 0;
        //        }
        //    }

        //    FileStream fs;
        //    try
        //    {
        //        fs = File.Create(sTarget);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(Properties.strings.result_export_error_createfile.Replace("{0}", sTarget).Replace("{1}", ex.Message));
        //        return 0;
        //    }

        //    if (fs != null)
        //    {
        //        string sData = Constants.sOutputFirstline;
        //        if (Conf.CurrentFilter.AddAdditionalColumns) sData += Constants.sOutputFirstlineAddition;
        //        sData += "\r\n";

        //        sData += Experiment.GetCleanedTracks(Conf.CurrentFilter);

        //        using (StreamWriter sw = new StreamWriter(fs))
        //        {
        //            sw.Write(sData);
        //        }

        //        fs.Close();
        //        return 1;
        //    }
        //    return 0;

        //}

        //// multi worksheets
        //private int OnExport_XLSX(string sTarget)
        //{
        //    if (File.Exists(sTarget) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTarget), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return 0;
        //        }
        //    }

        //    SpreadsheetDocument document = SpreadsheetDocument.Create(sTarget, SpreadsheetDocumentType.Workbook);

        //    WorkbookPart workbookPart = document.AddWorkbookPart();
        //    workbookPart.Workbook = new Workbook();
        //    uint sid = 1U;
        //    double[] dTest;
        //    foreach (int id in Experiments.Keys)
        //    {

        //        ListViewGroup lg = list_Animals.Groups[id];

        //        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //        worksheetPart.Worksheet = new Worksheet(new SheetData());
        //        Sheets sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>();
        //        if (sheets == null)
        //            sheets = workbookPart.Workbook.AppendChild(new Sheets());

        //        clsZExportXls Experiment = Experiments[id];
        //        string sSheetName = id.ToString() + " " + Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName);
        //        if (sSheetName.Length > 30) sSheetName = sSheetName.Substring(0, 30);
        //        Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = sid, Name = sSheetName };
        //        sid++;

        //        XLSX_AddHeaders(ref worksheetPart, Experiment);

        //        double dTMin_Slow = (double)Conf.CurrentFilter.Track_Slow_Min, dTMax_Slow = (double)Conf.CurrentFilter.Track_Slow_Max, dTValue_Slow;
        //        double dTMin_Fast = (double)Conf.CurrentFilter.Track_Fast_Min, dTMax_Fast = (double)Conf.CurrentFilter.Track_Fast_Max, dTValue_Fast;
        //        double dTMin_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Min, dTMax_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Max, dTValue_Inactive;
        //        double dTMin_Empty = 0.0, dTMax_Empty = (double)Conf.CurrentFilter.Track_Empty_Max, dTValue_Empty;

        //        bool bRemDupl = Conf.CurrentFilter.RemoveDuplicates;
        //        bool bRemInva = Conf.CurrentFilter.RemoveLinesWithInvalidSum;

        //        uint i = 2U;
        //        if (Conf.CurrentFilter.AddFilterValues)
        //            i = 7U;

        //        foreach (string sFish in Experiment.Fishes.Keys)
        //        {

        //            if (!lg.Items[int.Parse(Experiment.Fishes[sFish].Number) - 1].Checked)
        //                continue;

        //            dTest = Experiment.Fishes[sFish].GetFilteredTrackCount(Conf.CurrentFilter);
        //            if (dTest[4] < (double)Conf.CurrentFilter.Animal_LinesThreshold)
        //                continue;

        //            foreach (int key in Experiment.Fishes[sFish].Tracks.Keys)
        //            {

        //                if (Conf.CurrentFilter.RemoveDuplicates && Experiment.Fishes[sFish].Tracks[key].An == 1) continue;
        //                if (Conf.CurrentFilter.RemoveLinesWithInvalidSum && Experiment.Fishes[sFish].Tracks[key].DurationDifferences > (decimal)0.1) continue;

        //                dTValue_Slow = (double)Experiment.Fishes[sFish].Tracks[key].RelSmallDuration;
        //                dTValue_Fast = (double)Experiment.Fishes[sFish].Tracks[key].RelLargeDuration;
        //                dTValue_Inactive = (double)Experiment.Fishes[sFish].Tracks[key].RelInactiveDuration;
        //                dTValue_Empty = (double)Experiment.Fishes[sFish].Tracks[key].RelEmptyDuration;

        //                if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow) continue;
        //                if (dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast) continue;
        //                if (dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive) continue;
        //                if (dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty) continue;

        //                XLSX_AddTrack(ref worksheetPart, Experiment.Fishes[sFish].Tracks[key], i, Experiment.Fishes[sFish].CustomGroup);
        //                i++;
        //            }

        //        }

        //        sheets.Append(sheet);
        //    }

        //    workbookPart.Workbook.Save();
        //    document.Close();
        //    return 1;

        //}

        //// multi files
        //private int OnExport_XLSX(clsZExportXls Experiment, string sTarget, int id)
        //{
        //    if (File.Exists(sTarget) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTarget), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return 0;
        //        }
        //    }


        //    ListViewGroup lg = list_Animals.Groups[id];

        //    SpreadsheetDocument document = SpreadsheetDocument.Create(sTarget, SpreadsheetDocumentType.Workbook);

        //    WorkbookPart workbookPart = document.AddWorkbookPart();
        //    workbookPart.Workbook = new Workbook();
        //    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //    worksheetPart.Worksheet = new Worksheet(new SheetData());
        //    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
        //    string sSheetName = Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName);
        //    if (sSheetName.Length > 30) sSheetName = sSheetName.Substring(0, 30);
        //    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = sSheetName };
        //    sheets.Append(sheet);

        //    XLSX_AddHeaders(ref worksheetPart, Experiment);

        //    double dTMin_Slow = (double)Conf.CurrentFilter.Track_Slow_Min, dTMax_Slow = (double)Conf.CurrentFilter.Track_Slow_Max, dTValue_Slow;
        //    double dTMin_Fast = (double)Conf.CurrentFilter.Track_Fast_Min, dTMax_Fast = (double)Conf.CurrentFilter.Track_Fast_Max, dTValue_Fast;
        //    double dTMin_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Min, dTMax_Inactive = (double)Conf.CurrentFilter.Track_Inactive_Max, dTValue_Inactive;
        //    double dTMin_Empty = 0.0, dTMax_Empty = (double)Conf.CurrentFilter.Track_Empty_Max, dTValue_Empty;

        //    bool bRemDupl = Conf.CurrentFilter.RemoveDuplicates;
        //    bool bRemInva = Conf.CurrentFilter.RemoveLinesWithInvalidSum;
        //    double[] dTest;

        //    uint i = 2U;
        //    if (Conf.CurrentFilter.AddFilterValues)
        //        i = 7U;

        //    foreach (string sFish in Experiment.Fishes.Keys)
        //    {

        //        if (!lg.Items[int.Parse(Experiment.Fishes[sFish].Number) - 1].Checked)
        //            continue;

        //        dTest = Experiment.Fishes[sFish].GetFilteredTrackCount(Conf.CurrentFilter);
        //        if (dTest[4] < (double)Conf.CurrentFilter.Animal_LinesThreshold)
        //            continue;

        //        foreach (int key in Experiment.Fishes[sFish].Tracks.Keys)
        //        {

        //            if (Conf.CurrentFilter.RemoveDuplicates && Experiment.Fishes[sFish].Tracks[key].An == 1) continue;
        //            if (Conf.CurrentFilter.RemoveLinesWithInvalidSum && Experiment.Fishes[sFish].Tracks[key].DurationDifferences > (decimal)0.1) continue;

        //            dTValue_Slow = (double)Experiment.Fishes[sFish].Tracks[key].RelSmallDuration;
        //            dTValue_Fast = (double)Experiment.Fishes[sFish].Tracks[key].RelLargeDuration;
        //            dTValue_Inactive = (double)Experiment.Fishes[sFish].Tracks[key].RelInactiveDuration;
        //            dTValue_Empty = (double)Experiment.Fishes[sFish].Tracks[key].RelEmptyDuration;

        //            if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow) continue;
        //            if (dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast) continue;
        //            if (dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive) continue;
        //            if (dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty) continue;

        //            XLSX_AddTrack(ref worksheetPart, Experiment.Fishes[sFish].Tracks[key], i, Experiment.Fishes[sFish].CustomGroup);
        //            i++;
        //        }

        //    }

        //    workbookPart.Workbook.Save();

        //    document.Close();
        //    return 1;

        //}

        //private void OnExport_Images()
        //{

        //    if (!Conf.CurrentFilter.Save_ChartImage) return;

        //    string sTargetFolder;
        //    string sTargetFilename;

        //    if (Conf.CurrentFilter.Save_XLSX_MultiWorksheets && Conf.CurrentFilter.Save_XLSX_MultiWorksheets)
        //    {
        //        sTargetFolder = Conf.CurrentFilter.CustomSaveFolder;
        //        sTargetFilename = Constants.sTargetPrefix + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        //        OnExport_GroupImages(sTargetFolder, sTargetFilename);
        //        foreach (int id in Experiments.Keys)
        //        {
        //            OnExport_Images(Experiments[id]);
        //        }
        //    }
        //    else
        //    {
        //        foreach (int id in Experiments.Keys)
        //        {
        //            OnExport_Images(Experiments[id]);
        //        }
        //    }

        //    ApplyFilterToCharts();

        //}

        //private void OnExport_GroupImages(string sTargetFolder, string sTargetBasename)
        //{
        //    string sTargetAnimalchart = Path.Combine(sTargetFolder, sTargetBasename + Constants.sTargetChart_AnimalSufix + Constants.sExtensionPNG);
        //    string sTargetTrackschart = Path.Combine(sTargetFolder, sTargetBasename + Constants.sTargetChart_TrackSufix + Constants.sExtensionPNG);
        //    string sTargetResultchart = Path.Combine(sTargetFolder, sTargetBasename + Constants.sTargetChart_ResultSufix + Constants.sExtensionPNG);

        //    if (File.Exists(sTargetAnimalchart) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetAnimalchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return;
        //        }
        //    }
        //    if (File.Exists(sTargetTrackschart) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetTrackschart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return;
        //        }
        //    }
        //    if (File.Exists(sTargetResultchart) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetResultchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return;
        //        }
        //    }

        //    chart_importeddata.SaveImage(sTargetAnimalchart, ChartImageFormat.Png);
        //    chart_result.SaveImage(sTargetResultchart, ChartImageFormat.Png);
        //    chart_thresholds.SaveImage(sTargetTrackschart, ChartImageFormat.Png);

        //}

        //private void OnExport_Images(clsZExportXls Experiment)
        //{
        //    string sTargetFolder = (Conf.CurrentFilter.SaveToCustomFolder ? Conf.CurrentFilter.CustomSaveFolder : Experiment.FileInformation.DirectoryName);
        //    string sTargetAnimalchart = Path.Combine(sTargetFolder, Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName) + Constants.sTargetChart_AnimalSufix + Constants.sExtensionPNG);
        //    string sTargetResultchart = Path.Combine(sTargetFolder, Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName) + Constants.sTargetChart_ResultSufix + Constants.sExtensionPNG);
        //    string sTargetTrackschart = Path.Combine(sTargetFolder, Path.GetFileNameWithoutExtension(Experiment.FileInformation.FullName) + Constants.sTargetChart_TrackSufix + Constants.sExtensionPNG);

        //    if (File.Exists(sTargetAnimalchart) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetAnimalchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return;
        //        }
        //    }
        //    if (File.Exists(sTargetTrackschart) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetTrackschart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return;
        //        }
        //    }
        //    if (File.Exists(sTargetResultchart) && !Conf.CurrentFilter.Save_OverwriteExistingFiles)
        //    {
        //        DialogResult r = MessageBox.Show(Properties.strings.result_export_overwrite_question.Replace("{0}", sTargetResultchart), Properties.strings.result_export_overwrite_header, MessageBoxButtons.YesNo);
        //        if (r == DialogResult.No)
        //        {
        //            MessageBox.Show(Properties.strings.result_export_error_cancelled);
        //            return;
        //        }
        //    }

        //    OnChange_Animal_UpdateDiagram(Experiment);
        //    OnChange_Track_UpdateDiagram(Experiment);

        //    chart_importeddata.SaveImage(sTargetAnimalchart, ChartImageFormat.Png);
        //    chart_result.SaveImage(sTargetResultchart, ChartImageFormat.Png);
        //    chart_thresholds.SaveImage(sTargetTrackschart, ChartImageFormat.Png);

        //}

        //private void XLSX_AddHeaders(ref WorksheetPart worksheetPart, clsZExportXls Experiment)
        //{

        //    if (Conf.CurrentFilter.AddFilterValues)
        //        XLSX_AddFilterdata(ref worksheetPart, Experiment);

        //    SheetData sd = worksheetPart.Worksheet.Elements<SheetData>().Last();
        //    Row r = new Row() { RowIndex = (Conf.CurrentFilter.AddFilterValues ? 6U : 1U) };

        //    XLSX_WriteText(r, "A", "location");
        //    XLSX_WriteText(r, "B", "animal");
        //    XLSX_WriteText(r, "C", "group");
        //    XLSX_WriteText(r, "D", "user");
        //    XLSX_WriteText(r, "E", "sn");
        //    XLSX_WriteText(r, "F", "an");
        //    XLSX_WriteText(r, "G", "datatype");
        //    XLSX_WriteText(r, "H", "start");
        //    XLSX_WriteText(r, "I", "end");
        //    XLSX_WriteText(r, "J", "startreason");
        //    XLSX_WriteText(r, "K", "endreason");
        //    XLSX_WriteText(r, "L", "entct");
        //    XLSX_WriteText(r, "M", "inact");
        //    XLSX_WriteText(r, "N", "inadur");
        //    XLSX_WriteText(r, "O", "inadist");
        //    XLSX_WriteText(r, "P", "smlct");
        //    XLSX_WriteText(r, "Q", "smldur");
        //    XLSX_WriteText(r, "R", "smldist");
        //    XLSX_WriteText(r, "S", "larct");
        //    XLSX_WriteText(r, "T", "lardur");
        //    XLSX_WriteText(r, "U", "lardist");
        //    XLSX_WriteText(r, "V", "emptyct");
        //    XLSX_WriteText(r, "W", "emptydur");
        //    XLSX_WriteText(r, "X", "stdate");
        //    XLSX_WriteText(r, "Y", "sttime");
        //    if (Conf.CurrentFilter.AddAdditionalColumns)
        //    {
        //        XLSX_WriteText(r, "Z", "totaldur");
        //        XLSX_WriteText(r, "AA", "totaldurdiff");
        //        XLSX_WriteText(r, "AB", "inadurrel");
        //        XLSX_WriteText(r, "AC", "smldurrel");
        //        XLSX_WriteText(r, "AD", "lardurrel");
        //        XLSX_WriteText(r, "AE", "emptydurel");
        //        XLSX_WriteText(r, "AF", "totaldist");
        //        XLSX_WriteText(r, "AG", "inadistrel");
        //        XLSX_WriteText(r, "AH", "smldistrel");
        //        XLSX_WriteText(r, "AI", "lardistrel");
        //    }
        //    sd.Append(r);
        //}

        //private void XLSX_AddFilterdata(ref WorksheetPart worksheetPart, clsZExportXls Experiment)
        //{
        //    SheetData sd = worksheetPart.Worksheet.Elements<SheetData>().Last();

        //    Row r = new Row() { RowIndex = 1U };
        //    XLSX_WriteText(r, "A", Properties.strings.xlsx_header_description.Replace("{0}", Experiment.Filename));
        //    sd.Append(r);

        //    r = new Row() { RowIndex = 2U };
        //    XLSX_WriteText(r, "A", "");
        //    sd.Append(r);

        //    r = new Row() { RowIndex = 3U };
        //    XLSX_WriteText(r, "A", Properties.strings.xlsx_header_filtermin);
        //    XLSX_WriteText(r, "AB", Conf.CurrentFilter.Track_Inactive_Min);
        //    XLSX_WriteText(r, "AC", Conf.CurrentFilter.Track_Slow_Min);
        //    XLSX_WriteText(r, "AD", Conf.CurrentFilter.Track_Fast_Min);
        //    sd.Append(r);

        //    r = new Row() { RowIndex = 4U };
        //    XLSX_WriteText(r, "A", Properties.strings.xlsx_header_filtermax);
        //    if (Conf.CurrentFilter.RemoveDuplicates)
        //        XLSX_WriteText(r, "F", 0);
        //    if (Conf.CurrentFilter.RemoveLinesWithInvalidSum)
        //        XLSX_WriteText(r, "AA", (decimal)0.1);
        //    XLSX_WriteText(r, "AB", Conf.CurrentFilter.Track_Inactive_Max);
        //    XLSX_WriteText(r, "AC", Conf.CurrentFilter.Track_Slow_Max);
        //    XLSX_WriteText(r, "AD", Conf.CurrentFilter.Track_Fast_Max);
        //    XLSX_WriteText(r, "AE", Conf.CurrentFilter.Track_Empty_Max);
        //    sd.Append(r);

        //    r = new Row() { RowIndex = 5U };
        //    XLSX_WriteText(r, "A", "");
        //    sd.Append(r);

        //}

        //private void XLSX_AddTrack(ref WorksheetPart worksheetPart, XLS.clsTrack fData, uint iLine, int iFishGroup)
        //{
        //    SheetData sd = worksheetPart.Worksheet.Elements<SheetData>().First();
        //    Row r = new Row() { RowIndex = iLine };

        //    XLSX_WriteText(r, "A", fData.Location);
        //    XLSX_WriteText(r, "B", fData.Fish);
        //    XLSX_WriteText(r, "C", iFishGroup);
        //    XLSX_WriteText(r, "D", fData.User);
        //    XLSX_WriteText(r, "E", fData.Sn);
        //    XLSX_WriteText(r, "F", fData.An);
        //    XLSX_WriteText(r, "G", fData.Datatype);
        //    XLSX_WriteText(r, "H", fData.Start, 0);
        //    XLSX_WriteText(r, "I", fData.End, 0);
        //    XLSX_WriteText(r, "J", fData.StartReason);
        //    XLSX_WriteText(r, "K", fData.EndReason);
        //    XLSX_WriteText(r, "L", fData.Entct);
        //    XLSX_WriteText(r, "M", fData.InactiveCount);
        //    XLSX_WriteText(r, "N", fData.InactiveDuration);
        //    XLSX_WriteText(r, "O", fData.InactiveDistance);
        //    XLSX_WriteText(r, "P", fData.SmallCount);
        //    XLSX_WriteText(r, "Q", fData.SmallDuration);
        //    XLSX_WriteText(r, "R", fData.SmallDistance);
        //    XLSX_WriteText(r, "S", fData.LargeCount);
        //    XLSX_WriteText(r, "T", fData.LargeDuration);
        //    XLSX_WriteText(r, "U", fData.LargeDistance);
        //    XLSX_WriteText(r, "V", fData.EmptyCount);
        //    XLSX_WriteText(r, "W", fData.EmptyDuration);
        //    XLSX_WriteText(r, "X", fData.TrackDate.ToString("d", ciprovider.Default));
        //    XLSX_WriteText(r, "Y", fData.TrackDate.ToString("T", ciprovider.Default));

        //    if (Conf.CurrentFilter.AddAdditionalColumns)
        //    {

        //        XLSX_WriteText(r, "Z", fData.DurationSum);
        //        XLSX_WriteText(r, "AA", fData.DurationDifferences);
        //        XLSX_WriteText(r, "AB", fData.RelInactiveDuration);
        //        XLSX_WriteText(r, "AC", fData.RelSmallDuration);
        //        XLSX_WriteText(r, "AD", fData.RelLargeDuration);
        //        XLSX_WriteText(r, "AE", fData.RelEmptyDuration);
        //        XLSX_WriteText(r, "AF", fData.DistanceSum);
        //        XLSX_WriteText(r, "AG", fData.RelInactiveDistance);
        //        XLSX_WriteText(r, "AH", fData.RelSmallDistance);
        //        XLSX_WriteText(r, "AI", fData.RelLargeDistance);

        //    }
        //    sd.Append(r);
        //}

        //private string XLSX_int2string(int iIn)
        //{
        //    return iIn.ToString("N0", ciprovider.Default).Replace(",", "");
        //}

        //private string XLSX_dec2string(decimal dIn, int iDecimals = 1)
        //{
        //    return dIn.ToString("N" + iDecimals.ToString(), ciprovider.Default).Replace(",", "");
        //}

        //private void XLSX_WriteText(Row r, string Column, string text)
        //{
        //    Cell c = new Cell()
        //    {
        //        CellReference = Column + r.RowIndex.ToString(),
        //        DataType = CellValues.String,
        //        CellValue = new CellValue(text),
        //    };
        //    r.Append(c);
        //}

        //private void XLSX_WriteText(Row r, string Column, decimal dNumber, int iDecimals = 1)
        //{
        //    Cell c = new Cell()
        //    {
        //        CellReference = Column + r.RowIndex.ToString(),
        //        DataType = CellValues.Number,
        //        CellValue = new CellValue(XLSX_dec2string(dNumber, iDecimals)),
        //    };
        //    r.Append(c);
        //}

        //private void XLSX_WriteText(Row r, string Column, int iNumber)
        //{
        //    Cell c = new Cell()
        //    {
        //        CellReference = Column + r.RowIndex.ToString(),
        //        DataType = CellValues.Number,
        //        CellValue = new CellValue(XLSX_int2string(iNumber)),
        //    };
        //    r.Append(c);
        //}

        #endregion

        #region FavoritesEngine

        private void load10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Conf.FavoriteFilter0 != null)
            {
                Conf.SelectFilter(0);
                ApplyConfToGui();
            }
        }

        private void load20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Conf.FavoriteFilter1 != null)
            {
                Conf.SelectFilter(1);
               ApplyConfToGui();
            }
        }

        private void load30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Conf.FavoriteFilter2 != null)
            {
                Conf.SelectFilter(2);
             ApplyConfToGui();
            }
        }

        private void saveAs1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Microsoft.VisualBasic.Interaction.InputBox(Properties.strings.favorite_save_question, Properties.strings.favorite_save_header);
            if (s != "")
            {
                Conf.CurrentFilter.Name = s;
                Conf.CopyCurrentToFavorite(0);
                menu_favorites_load1.Text = Properties.strings.menu_favorites_load_f1.Replace("{0}", s);
                if (menu_favorites_load1.Enabled == false)
                    menu_favorites_load1.Enabled = true;
            }
        }

        private void saveAs2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Microsoft.VisualBasic.Interaction.InputBox(Properties.strings.favorite_save_question, Properties.strings.favorite_save_header);
            if (s != "")
            {
                Conf.CurrentFilter.Name = s;
            Conf.CopyCurrentToFavorite(1);
            menu_favorites_load2.Text = Properties.strings.menu_favorites_load_f2.Replace("{0}", s);
            if (menu_favorites_load2.Enabled == false)
                menu_favorites_load2.Enabled = true;
            }
        }

        private void saveAs3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Microsoft.VisualBasic.Interaction.InputBox(Properties.strings.favorite_save_question, Properties.strings.favorite_save_header);
            if (s != "")
            {
                Conf.CurrentFilter.Name = s;
            Conf.CopyCurrentToFavorite(2);
            menu_favorites_load3.Text = Properties.strings.menu_favorites_load_f3.Replace("{0}", s);
            if (menu_favorites_load3.Enabled == false)
                menu_favorites_load3.Enabled = true;
            }
        }

        #endregion

        #region FileloaderEngine

        bool b2circleloaded = false;
        private void CleanOldFiles()
        {
            try
            {
                string[] sFiles = Directory.GetFiles(sWorkingFolder);
                    foreach (string sFile in sFiles)
                {
                    File.Delete(sFile);
                }
            } catch (Exception ex)
            {
                WriteLogEntry(clsErrorLevel.Exception, SoftwareModules.FileloaderEngine, "CleanOldFiles", new string[] { sWorkingFolder }, "", "", ex);
            }
        }

        private void formConverter_DragDrop(object sender, DragEventArgs e)
        {
            Cleanup_ResetFilters();
            Cleanup_CleanLoadedFiles();

            string[] aFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            Array.Sort(aFiles);
            if (aFiles.Length != 0)
            {
                
                for (int i = 0; i < aFiles.Length; i++)
                {
                    Files.Add(aFiles[i], new clsDroppedFile(aFiles[i], ref Experiments, sWorkingFolder));
                }

                droppedFiles = aFiles;
                btnExit.Visible = false;
                tcImportError = false;
                button_destination_createfiles.Visible = true;
                button_cancel_files.Visible = true;
                this.AcceptButton = button_destination_createfiles;
                this.CancelButton = button_cancel_files;
                lblInfo.Text = (droppedFiles.Length == 1 ? Properties.strings.usage_checkingfile : Properties.strings.usage_checkingfiles);
                Drop_CheckFiles();

                foreach (int iKey in Experiments.Keys)
                {
                    ExperimentOrdering.Add(iKey, iKey);
                    FilenameToExperimentId.Add(Experiments[iKey].Filename, iKey);
                    Experiments[iKey].DroppedFile.ReportToGrid(ref list_ImportStatus, ref Experiments);
                }

            }
            else
                WriteLogEntry(clsErrorLevel.Information, SoftwareModules.FileloaderEngine, "formConverter_DragDrop", new string[] { }, "Dropped nothing?");
        }

        private void formConverter_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tcImportError = false;
            Cleanup_ResetFilters();
            Cleanup_CleanLoadedFiles();
            formConverter_ResetView();
        }

        private void Drop_CheckFiles()
        {
            b2circleloaded = false;

            if (Experiments.Count == 0)
            {
                if (Files.Keys.Count == 0)
                {
                    btnCancel_Click(null, null);
                    lblInfo.Text = Properties.strings.result_import_error_nofiles;
                } else
                {
                    foreach(string sKey in Files.Keys)
                    {
                        Files[sKey].ReportToGrid(ref list_ImportStatus, ref Experiments);
                    }
                    tcImportError = true;
                    formConverter_ResetView();
                }
            }
            else
            {
                if (checkAutostart.Checked)
                {
                    btnCreate_Click(null, null);
                }
                else
                {
                    
                    int iTracksTotal = 0;
                    int iTracksInvSum = 0;
                    int iTracksDuplicate = 0;
                    int iNoOfFishes = 0;
                    
                    foreach (int i in Experiments.Keys)
                    {

                        if (iNoOfFishes == 0) iNoOfFishes = Experiments[i].NumberOfFishes;
                        else if (iNoOfFishes != Experiments[i].NumberOfFishes)
                        {
                            Experiments[i].Handle_File = false;
                            continue;
                        }
                        
                        foreach (string f in Experiments[i].Fishes.Keys)
                        {
                            iTracksDuplicate += Experiments[i].Fishes[f].GetTrackCount_Duplicates();
                            iTracksInvSum += Experiments[i].Fishes[f].GetTrackCount_InvalidDuration(Conf.CurrentFilter);
                            iTracksTotal += Experiments[i].Fishes[f].Tracks.Keys.Count();
                        }
                        txtGrouping_MultifileSelector.Items.Add(Experiments[i].Filename);
                        if (txtGrouping_MultifileSelector.Text == "") txtGrouping_MultifileSelector.Text = Experiments[i].Filename;
                        if (Experiments[i].Is2CircleExperiment && b2circleloaded == false)
                        {
                            b2circleloaded = true;
                            panel_destination_2circle.Visible = true;
                        }
                        else
                            panel_destination_2circle.Visible = false;


                    }

                    if (iTracksTotal != 0)
                    {
                        double dInvRel = (double)iTracksInvSum / (double)iTracksTotal * 100.0d;
                        double dDupRel = (double)iTracksDuplicate / (double)iTracksTotal * 100.0d;

                        check_clean_invalidsum.Text = Properties.strings.filter_checkbox_invalidsum.Replace("{0}", iTracksInvSum.ToString("N0", ciprovider.en_US)).Replace("{1}", dInvRel.ToString("N0", ciprovider.en_US));
                        check_clean_duplicates.Text = Properties.strings.filter_checkbox_duplicates.Replace("{0}", iTracksDuplicate.ToString("N0", ciprovider.en_US)).Replace("{1}", dDupRel.ToString("N0", ciprovider.en_US));
                    }

                    formConverter_ResetView();
                    AddFilesToListbox();
                    ApplyFilterToCharts();
                    if (tabcontrol.SelectedIndex != 0)
                        tabcontrol.SelectTab(0);
                    else
                        tabControl1_SelectedIndexChanged(null, null);

                }
            }
        }

        private void Cleanup_CleanLoadedFiles()
        {
            if (Experiments.Count != 0)
            {
                foreach (int i in Experiments.Keys)
                {
                    try
                    {
                        Experiments[i].Cleanup();
                    } catch (Exception ex)
                    {
                        WriteLogEntry(clsErrorLevel.Information, SoftwareModules.FileloaderEngine, "Cleanup_CleanLoadedFiles", new string[] { }, "", Experiments[i].Filename, ex);
                    }
                }
                txtGrouping_MultifileSelector.Items.Clear();
            }
            Experiments.Clear();
            Files.Clear();
            ExperimentOrdering.Clear();
            FilenameToExperimentId.Clear();
            txtGrouping_MultifileSelector.Text = "";
            list_ImportStatus.Items.Clear();
        }

        private void Cleanup_ResetFilters()
        {
            if (bFiltersShown)
            {
                bFiltersShown = false;
            }
        }

        private void list_ImportStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = list_ImportStatus;
            if (lv.SelectedItems.Count == 0)
            {
                menu_filehandling.Visible = false;
            }
            else
            {
                menu_filehandling.Visible = true;
                ListViewItem li = lv.SelectedItems[0];
                menu_filehandling_entryup.Enabled = (li.Index != 0);
                menu_filehandling_entrydown.Enabled = (li.Index != (lv.Items.Count - 1));
                menu_filehandling_removeentry.Enabled = (li.Text == "yes");
                menu_filehandling_removeentry.Checked = li.Checked;
            }
        }

        private void menu_filehandling_removeentry_Click(object sender, EventArgs e)
        {
            ListView lv = list_ImportStatus;
            if (lv.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem li = lv.SelectedItems[0];
                string fn = li.SubItems[1].Text;
                if (FilenameToExperimentId.ContainsKey(fn))
                {
                    int id = FilenameToExperimentId[fn];
                    if (Experiments.ContainsKey(id))
                    {
                        if (Experiments[id].DroppedFile.AutoDisabled)
                        {
                            li.Checked = false;
                            menu_filehandling_removeentry.Checked = false;
                            menu_filehandling_removeentry.Enabled = false;
                        } else
                        {
                            if (Experiments[id].DroppedFile.Enabled)
                            {
                                Experiments[id].DroppedFile.Enabled = false;
                                li.Checked = false;
                                menu_filehandling_removeentry.Checked = false;

                            } else
                            {
                                Experiments[id].DroppedFile.Enabled = true;
                                li.Checked = true;
                                menu_filehandling_removeentry.Checked = true;
                            }
                            if (OnExperimentSelectionChanged != null)
                                OnExperimentSelectionChanged();
                        }
                    }
                }
            }
        }

        #endregion

        #region FilterEngine

        private void ApplyConfToGui()
        {

            // export location
            radio_destination_importfolder.Checked = !Conf.CurrentFilter.ExportToCustomFolder;
            radio_destination_custom.Checked = Conf.CurrentFilter.ExportToCustomFolder;
            if (Conf.CurrentFilter.ExportToCustomFolder)
                radio_destination_custom.Text = Properties.strings.destination_checkbox_otherfolder.Replace("{0}", ": " + Conf.CurrentFilter.ExportCustomFolder);
            else
                radio_destination_custom.Text = Properties.strings.destination_checkbox_otherfolder.Replace("{0}", "");
            check_destination_overwritefiles.Checked = Conf.CurrentFilter.OverwriteExistingFiles;
            check_destination_subfolders.Checked = Conf.CurrentFilter.CreateSubfolders;

            // filetype
            radio_filetype_xls.Checked = !Conf.CurrentFilter.CreateXLSXFile;
            radio_filetype_xlsx.Checked = Conf.CurrentFilter.CreateXLSXFile;
            check_filetype_xlsx_multisheet.Checked = Conf.CurrentFilter.Xlsx_MultiWorksheets;
            check_filetype_xlsx_includefilters.Checked = Conf.CurrentFilter.Xlsx_WithFilterValues;

            // data options
            check_dataoptions_addsumcolumns.Checked = Conf.CurrentFilter.AdditionalDataColumns;
            check_dataoptions_addgroupcolumns.Checked = Conf.CurrentFilter.AdditionalGroupColumns;
            check_dataoptions_reordercounting.Checked = Conf.CurrentFilter.ReorderAnimalCounting;

            // image merger
            check_imagemerger_enabled.Checked = Conf.CurrentFilter.ImageMerger_Enabled;

            // chart options
            check_chartoptions_savecharts.Checked = Conf.CurrentFilter.Charts_CreateFiles;
            check_chartoptions_ownfolder.Checked = Conf.CurrentFilter.Charts_CreateSubfolder;
            check_chartoptions_xaxis_animalname.Checked = Conf.CurrentFilter.Charts_XAxisAnimalname;

            // 2-circle
            check_2circle_merge.Checked = Conf.CurrentFilter.TwoCircle_MergeTracks;
            check_2circle_chart_inner.Checked = Conf.CurrentFilter.TwoCircle_InnerChart;
            check_2circle_chart_outer.Checked = Conf.CurrentFilter.TwoCircle_OuterChart;
            check_2circle_chart_combined.Checked = Conf.CurrentFilter.TwoCircle_CombinedChart;

            // basic options
            check_clean_duplicates.Checked = Conf.CurrentFilter.RemoveDuplicates;
            check_clean_invalidsum.Checked = Conf.CurrentFilter.RemoveLinesWithInvalidSum;
            check_chart_upscaling.Checked = Conf.CurrentFilter.Chart_UpscaleResultchart;
            
            // thresholds
            text_track_slow_min.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Slow_Min);
            text_track_slow_max.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Slow_Max);
            text_track_fast_min.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Fast_Min);
            text_track_fast_max.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Fast_Max);
            text_track_inactive_min.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Inactive_Min);
            text_track_inactive_max.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Inactive_Max);
            text_track_empty_max.Text = clsTools.dec2string(Conf.CurrentFilter.Track_Empty_Max);
            text_animal_threshold_min.Text = clsTools.dec2string(Conf.CurrentFilter.Animal_LinesThreshold);

            // group names
            text_groupnaming_group0.Text = Conf.CurrentFilter.GroupName(0);
            text_groupnaming_group1.Text = Conf.CurrentFilter.GroupName(1);
            text_groupnaming_group2.Text = Conf.CurrentFilter.GroupName(2);
            text_groupnaming_group3.Text = Conf.CurrentFilter.GroupName(3);
            text_groupnaming_group4.Text = Conf.CurrentFilter.GroupName(4);
            text_groupnaming_group5.Text = Conf.CurrentFilter.GroupName(5);
            text_groupnaming_group6.Text = Conf.CurrentFilter.GroupName(6);
            text_groupnaming_group7.Text = Conf.CurrentFilter.GroupName(7);
            text_groupnaming_group8.Text = Conf.CurrentFilter.GroupName(8);
            text_groupnaming_group9.Text = Conf.CurrentFilter.GroupName(9);
            OnChangeGroupname(0, Conf.CurrentFilter.GroupName(0));
            OnChangeGroupname(1, Conf.CurrentFilter.GroupName(1));
            OnChangeGroupname(2, Conf.CurrentFilter.GroupName(2));
            OnChangeGroupname(3, Conf.CurrentFilter.GroupName(3));
            OnChangeGroupname(4, Conf.CurrentFilter.GroupName(4));
            OnChangeGroupname(5, Conf.CurrentFilter.GroupName(5));
            OnChangeGroupname(6, Conf.CurrentFilter.GroupName(6));
            OnChangeGroupname(7, Conf.CurrentFilter.GroupName(7));
            OnChangeGroupname(8, Conf.CurrentFilter.GroupName(8));
            OnChangeGroupname(9, Conf.CurrentFilter.GroupName(9));

            ApplyFilterToCharts();
        }

        bool bGroupLoader = false;
        private void ApplyFilterToCharts()
        {
            if (bGroupLoader) return;
            OnChange_Animal_UpdateDiagram();
            OnChange_Track_UpdateDiagram();
            ApplyFilterToListbox();
        }

        bool bListbox_Loader = false;
        private void AddFilesToListbox()
        {
            bListbox_Loader = true;
            list_Animals.Items.Clear();
            list_Animals.Groups.Clear();
            foreach (int id in Experiments.Keys)
            {
                if (!Experiments[id].Handle_File) continue;
                ListViewGroup lg = new ListViewGroup(id.ToString(), Experiments[id].Filename);
                list_Animals.Groups.Add(lg);
                foreach (string f in Experiments[id].Fishes.Keys)
                {
                    int a = Experiments[id].Fishes[f].GetTrackCount_Duplicates();
                    int b = Experiments[id].Fishes[f].Tracks.Count;
                    ListViewItem lvi = list_Animals.Items.Add(new ListViewItem(new string[] { f, Experiments[id].Fishes[f].Number, Experiments[id].Fishes[f].Name, (b - a).ToString("N0", ciprovider.en_US), "", "" }, lg));
                    lvi.Checked = true;
                }
            }
        }

        private void ApplyFilterToListbox()
        {
            if (bGroupLoader) return;

            bListbox_Loader = true;
            int itr = 0;
            foreach (int id in Experiments.Keys)
            {
                if (!Experiments[id].Handle_File) continue;
                ListViewGroup lg = list_Animals.Groups[itr];
                for (int i = 0; i < lg.Items.Count; i++)
                {
                    if (Experiments[id].Fishes.ContainsKey(lg.Items[i].Text))
                    {
                        int a = Experiments[id].Fishes[lg.Items[i].Text].LinesLeft(Conf.CurrentFilter);
                        int b = Experiments[id].Fishes[lg.Items[i].Text].Tracks.Count - Experiments[id].Fishes[lg.Items[i].Text].GetTrackCount_Duplicates();
                        double c = (double)a / (double)b * 100.0d;
                        lg.Items[i].SubItems[4].Text = (b - a).ToString("N0", ciprovider.en_US);
                        lg.Items[i].SubItems[5].Text = a.ToString("N0", ciprovider.en_US) + " (" + c.ToString("N0", ciprovider.en_US) + "%)";
                    }
                }
                itr++;
            }
            bListbox_Loader = false;
        }


        #endregion

        #region GroupingEngine

        clsZExportXls CurrentGroupFile;
        Color[] cBack =
        {
            SystemColors.WindowFrame,
            Color.Brown,
            Color.IndianRed,
            Color.DarkSalmon,
            Color.Chocolate,
            Color.DarkOrange,
            Color.Goldenrod,
            Color.LemonChiffon,
            Color.LightGreen,
            Color.ForestGreen,
        };

        Color[] cFore =
        {
            SystemColors.ButtonFace,
            SystemColors.ButtonFace,
            SystemColors.ButtonFace,
            SystemColors.ButtonFace,
            SystemColors.ButtonFace,
            SystemColors.ButtonFace,
            SystemColors.ButtonFace,
            SystemColors.WindowFrame,
            SystemColors.WindowFrame,
            SystemColors.ButtonFace,
        };

        private void Grouping_OnChangeFile(int iFileId)
        {
            if (!Experiments.ContainsKey(iFileId))
                return;

            CurrentGroupFile = Experiments[iFileId];

            if (grid_grouping.Columns.Count == 0 || grid_grouping.Columns.Count != CurrentGroupFile.Columns)
            {
                grid_grouping.Columns.Clear();
                grid_grouping.SelectionMode = DataGridViewSelectionMode.CellSelect;
                for (int i = 0; i < CurrentGroupFile.Columns; i++)
                {
                    int c = grid_grouping.Columns.Add("col_" + i.ToString(), (i + 1).ToString());
                    grid_grouping.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                    grid_grouping.Columns[c].Width = 64;
                    grid_grouping.Columns[c].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grid_grouping.Columns[c].Resizable = DataGridViewTriState.False;
                }
                grid_grouping.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            }

            grid_grouping.Rows.Clear();
            grid_grouping.Rows.Add(CurrentGroupFile.Rows);
            for (int i = 0; i < CurrentGroupFile.Rows; i++)
            {
                grid_grouping.Rows[i].HeaderCell.Value = ((char)(i + 65)).ToString();

            }

            foreach (string f in CurrentGroupFile.Fishes.Keys)
            {
                XLS.clsFish Fish = CurrentGroupFile.Fishes[f];
                int x = Fish.Column - 1;
                int y = Fish.Row - 1;
                DataGridViewCell ce = grid_grouping.Rows[y].Cells[x];
                ce.Value = Fish.GridViewText(Conf);
                ce.Style.BackColor = cBack[Fish.CustomGroup];
                ce.Style.ForeColor = cFore[Fish.CustomGroup];
            }

        }

        // prevent user input in group box
        private void txtGrouping_MultifileSelector_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void txtGrouping_MultifileSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            int iItem = txtGrouping_MultifileSelector.SelectedIndex;
            if (Experiments.ContainsKey(iItem))
            {
                Grouping_OnChangeFile(iItem);
            }
        }

        Size[] sGroupGridSize =
        {
            new Size(832, 481),
            new Size(529, 481)
        };
        private void gridGrouping_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift) return;
            if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105))
            {
                int iGroup = 0;
                if (e.KeyValue <= 57) iGroup = e.KeyValue - 48;
                else iGroup = e.KeyValue - 96;
                foreach (DataGridViewCell cell in grid_grouping.SelectedCells)
                {
                    string sFish = cell.Value.ToString().Substring(0, 3);
                    if (CurrentGroupFile.Fishes.ContainsKey(sFish))
                    {
                        XLS.clsFish Fish = CurrentGroupFile.Fishes[sFish];
                        Fish.CustomGroup = iGroup;
                        cell.Value = Fish.GridViewText(Conf);
                        cell.Style.BackColor = cBack[Fish.CustomGroup];
                        cell.Style.ForeColor = cFore[Fish.CustomGroup];
                    }
                }
            } 
        }

        private void menugroupingrenameutilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel_grouping_groupnaming.Visible)
            {
                grid_grouping.Size = sGroupGridSize[0];
                panel_grouping_groupnaming.Visible = false;
            }
            else
            {
                grid_grouping.Size = sGroupGridSize[1];
                panel_grouping_groupnaming.Visible = true;
            }
        }

        private void OnChangeGroupname(int Group, string name)
        {
            Conf.CurrentFilter.GroupName(Group, name);
            Conf.SaveCurrentFilter();
            foreach (DataGridViewRow row in grid_grouping.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string sFish = cell.Value.ToString().Substring(0, 3);
                    if (CurrentGroupFile.Fishes.ContainsKey(sFish))
                    {
                        XLS.clsFish Fish = CurrentGroupFile.Fishes[sFish];
                        cell.Value = Fish.GridViewText(Conf);
                    }
                }
            }
        }

        private void menu_grouping_shortcut(int cols)
        {
            if (CurrentGroupFile != null)
            {
                int iGroup = 0;
                foreach (DataGridViewRow row in grid_grouping.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        iGroup = cell.ColumnIndex / cols;
                        string sFish = cell.Value.ToString().Substring(0, 3);
                        if (CurrentGroupFile.Fishes.ContainsKey(sFish))
                        {
                            XLS.clsFish Fish = CurrentGroupFile.Fishes[sFish];
                            Fish.CustomGroup = iGroup;
                            cell.Value = Fish.GridViewText(Conf);
                            cell.Style.BackColor = cBack[Fish.CustomGroup];
                            cell.Style.ForeColor = cFore[Fish.CustomGroup];
                        }
                    }
                }
            }
        }

        private void menu_grouping2_Click(object sender, EventArgs e)
        {
            menu_grouping_shortcut(2);
        }

        private void menu_grouping3_Click(object sender, EventArgs e)
        {
            menu_grouping_shortcut(3);
        }

        private void menu_grouping4_Click(object sender, EventArgs e)
        {
            menu_grouping_shortcut(4);
        }

        private void OnChange_GroupName(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int iGroup = int.Parse(((TextBox)sender).Name.Substring(((TextBox)sender).Name.Length - 1, 1));
            OnChangeGroupname(iGroup, ((TextBox)sender).Text.Replace(",", ""));
        }


        #endregion

        #region HelpEngine

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 fDialog = new AboutBox1();
            fDialog.ShowDialog();
        }

        private void helpSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.sSupportURL);
        }

        #endregion

        #region LanguageEngine

        void ApplyLanguageSettings()
        {

            label_softwarename.Text = Constants.sApplicationHeader;
            this.Text = Constants.sApplicationTitle;

            // menu items
            menu_file.Text = Properties.strings.menu_file;
            menu_file_settings.Text = Properties.strings.menu_file_settings;
            menu_file_exit.Text = Properties.strings.menu_file_exit;

            menu_filehandling.Text = Properties.strings.menu_filehandling;
            menu_filehandling_entryup.Text = Properties.strings.menu_filehandling_entryup;
            menu_filehandling_entrydown.Text = Properties.strings.menu_filehandling_entrydown;
            menu_filehandling_removeentry.Text = Properties.strings.menu_filehandling_removeentry;

            menu_favorites.Text = Properties.strings.menu_favorites;
            menu_favorites_save1.Text = Properties.strings.menu_favorites_save_f1;
            menu_favorites_save2.Text = Properties.strings.menu_favorites_save_f2;
            menu_favorites_save3.Text = Properties.strings.menu_favorites_save_f3;
            menu_favorites_load1.Text = Properties.strings.menu_favorites_load_f1;
            menu_favorites_load2.Text = Properties.strings.menu_favorites_load_f2;
            menu_favorites_load3.Text = Properties.strings.menu_favorites_load_f3;

            menu_grouping.Text = Properties.strings.menu_grouping;
            menu_grouping_by2.Text = Properties.strings.menu_grouping_2col;
            menu_grouping_by3.Text = Properties.strings.menu_grouping_3col;
            menu_grouping_by4.Text = Properties.strings.menu_grouping_4col;
            menu_grouping_renameutility.Text = Properties.strings.menu_grouping_renameutility;

            menu_help.Text = Properties.strings.menu_help;
            menu_help_helpandsupport.Text = Properties.strings.menu_help_support;
            menu_help_about.Text = Properties.strings.menu_help_about;
            
            tab_import.Text = Properties.strings.tabcontrol_import;
            tab_basic.Text = Properties.strings.tabcontrol_basic;
            tab_thresholds.Text = Properties.strings.tabcontrol_threshold;
            tab_grouping.Text = Properties.strings.tabcontrol_grouping;
            tab_results.Text = Properties.strings.tabcontrol_result;
            tab_2circletracks.Text = Properties.strings.tabcontrol_2circle;
            tab_destination.Text = Properties.strings.tabcontrol_destination;

            list_ImportStatus.Columns[0].Text = Properties.strings.column_import_check;
            list_ImportStatus.Columns[1].Text = Properties.strings.column_import_filename;
            list_ImportStatus.Columns[2].Text = Properties.strings.column_import_problems;
            list_ImportStatus.Columns[3].Text = Properties.strings.column_import_imagesfound;
            list_ImportStatus.Columns[4].Text = Properties.strings.column_import_animals;
            list_ImportStatus.Columns[5].Text = Properties.strings.column_import_lines;
            list_ImportStatus.Columns[6].Text = Properties.strings.column_import_duplicates;
            list_ImportStatus.Columns[7].Text = Properties.strings.column_import_secpertrack;
            list_ImportStatus.Columns[8].Text = Properties.strings.column_import_duration;

            checkAutostart.Text = Properties.strings.usage_autostart;
            button_import_next.Text = Properties.strings.button_next;
            button_basics_back.Text = Properties.strings.button_back;
            button_destination_back.Text = Properties.strings.button_back;
            button_thresholds_back.Text = Properties.strings.button_back;
            button_results_back.Text = Properties.strings.button_back;
            button_grouping_back.Text = Properties.strings.button_back;
            button_cancel_files.Text = Properties.strings.button_cancel;
            button_destination_createfiles.Text = Properties.strings.button_create;
            btnExit.Text = Properties.strings.button_exit;
            button_import_next.Text = Properties.strings.button_next;
            button_results_next.Text = Properties.strings.button_next;
            button_basic_next.Text = Properties.strings.button_next;
            button_thresholds_next.Text = Properties.strings.button_next;
            button_grouping_next.Text = Properties.strings.button_next;

            check_clean_duplicates.Text = Properties.strings.filter_checkbox_duplicates;
            check_clean_invalidsum.Text = Properties.strings.filter_checkbox_invalidsum;
            text_howto_basics.Text = Properties.strings.usage_tab1_basics;

            label_grouping_multifiles_info.Text = Properties.strings.grouping_multifiles_info;
            text_howto_grouping.Text = Properties.strings.usage_tab5_grouping;
            label_groupnaming_header.Text = Properties.strings.groups_renaming_header;
            label_groupnaming_group0.Text = Properties.strings.groups_renaming_group0;
            label_groupnaming_group1.Text = Properties.strings.groups_renaming_group1;
            label_groupnaming_group2.Text = Properties.strings.groups_renaming_group2;
            label_groupnaming_group3.Text = Properties.strings.groups_renaming_group3;
            label_groupnaming_group4.Text = Properties.strings.groups_renaming_group4;
            label_groupnaming_group5.Text = Properties.strings.groups_renaming_group5;
            label_groupnaming_group6.Text = Properties.strings.groups_renaming_group6;
            label_groupnaming_group7.Text = Properties.strings.groups_renaming_group7;
            label_groupnaming_group8.Text = Properties.strings.groups_renaming_group8;
            label_groupnaming_group9.Text = Properties.strings.groups_renaming_group9;
            button_groupnaming_done.Text = Properties.strings.button_done;

            label_thresholds_header_min.Text = Properties.strings.filter_min;
            label_thresholds_header_max.Text = Properties.strings.filter_max;
            label_thresholds_fish_empty.Text = Properties.strings.filter_fish;
            label_thresholds_fish_inactive.Text = Properties.strings.filter_fish;
            label_thresholds_fish_fast.Text = Properties.strings.filter_fish;
            label_thresholds_fish_slow.Text = Properties.strings.filter_fish;
            label_thresholds_fish_lines.Text = Properties.strings.filter_fish;
            label_thresholds_header_slow.Text = Properties.strings.filter_slow;
            label_thresholds_header_fast.Text = Properties.strings.filter_fast;
            label_thresholds_header_inactive.Text = Properties.strings.filter_inactive;
            label_thresholds_header_empty.Text = Properties.strings.filter_empty;
            label_thresholds_header_lines.Text = Properties.strings.filter_animallines;
            text_howto_thresholds.Text = Properties.strings.usage_tab2_thresholds;

            list_Animals.Columns[1].Text = Properties.strings.result_table_col_well;
            list_Animals.Columns[2].Text = Properties.strings.result_table_col_animal;
            list_Animals.Columns[3].Text = Properties.strings.result_table_col_linestotal;
            list_Animals.Columns[4].Text = Properties.strings.result_table_col_linesremoved;
            list_Animals.Columns[5].Text = Properties.strings.result_table_col_linesleft;
            text_howto_results.Text = Properties.strings.usage_tab3_result;
            check_chart_upscaling.Text = Properties.strings.result_upscalechart;

            label_destination_header.Text = Properties.strings.destination_wheretosave;
            label_filetype_header.Text = Properties.strings.destination_filetype;
            label_dataoptions_header.Text = Properties.strings.destination_options;
            radio_destination_importfolder.Text = Properties.strings.destination_checkbox_importfolder;
            radio_filetype_xlsx.Text = Properties.strings.destination_xlsx;
            radio_filetype_xls.Text = Properties.strings.destination_xls;
            check_filetype_xlsx_multisheet.Text = Properties.strings.destination_multiworksheet;
            check_filetype_xlsx_includefilters.Text = Properties.strings.destination_checkbox_filterheader;
            check_destination_overwritefiles.Text = Properties.strings.destination_checkbox_overwrite;
            check_chartoptions_savecharts.Text = Properties.strings.destination_charts;
            check_dataoptions_addsumcolumns.Text = Properties.strings.destination_checkbox_addcolumns;
            text_howto_destination.Text = Properties.strings.usage_tab4_destination;
            label_2circle_header.Text = Properties.strings.destination_2circle_header;
            check_2circle_merge.Text = Properties.strings.destination_2circle_mergetracks;
            check_2circle_chart_inner.Text = Properties.strings.destination_2circle_savecharts_inner;
            check_2circle_chart_outer.Text = Properties.strings.destination_2circle_savecharts_outer;
            check_2circle_chart_combined.Text = Properties.strings.destination_2circle_savecharts_combined;
            check_destination_subfolders.Text = Properties.strings.destination_checkbox_file_subfolders;
            check_dataoptions_addgroupcolumns.Text = Properties.strings.destination_checkbox_addgroupcolumns;
            check_dataoptions_reordercounting.Text = Properties.strings.destination_checkbox_reorderanimals;
            label_imagemerger_header.Text = Properties.strings.destination_imagemerger_header;
            check_imagemerger_enabled.Text = Properties.strings.destination_checkbox_enableimagemerger;
            label_chartoptions_header.Text = Properties.strings.destination_charts_header;
            check_chartoptions_ownfolder.Text = Properties.strings.destination_checkbox_chart_subfolders;
            check_chartoptions_xaxis_animalname.Text = Properties.strings.destination_checkbox_chart_xaxisrenaming;

            text_track_slow_min.MouseWheel += OnScroll_Threshold;
            text_track_slow_max.MouseWheel += OnScroll_Threshold;
            text_track_fast_min.MouseWheel += OnScroll_Threshold;
            text_track_fast_max.MouseWheel += OnScroll_Threshold;
            text_track_inactive_min.MouseWheel += OnScroll_Threshold;
            text_track_inactive_max.MouseWheel += OnScroll_Threshold;
            text_track_empty_max.MouseWheel += OnScroll_Threshold;
            text_animal_threshold_min.MouseWheel += OnScroll_Threshold;

            chart_importeddata.Titles[0].Text = Properties.strings.chart_title_animal_beforefilter;
            chart_result.Titles[0].Text = Properties.strings.chart_title_animal_afterfilter;
            chart_thresholds.Titles[0].Text = Properties.strings.chart_title_filters;
        }

        private void SettingsDialog_OnChangeUILanguage(string SelectedLanguage)
        {
            if (SelectedLanguage != language)
            {
                Conf.CurrentLanguage = SelectedLanguage;
                language = SelectedLanguage;
                if (Conf.CustomLanguage)
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                else
                    Thread.CurrentThread.CurrentUICulture = ciSysdefault;
                ApplyLanguageSettings();
                SettingsDialog.ApplyLanguageSettings();
            }
        }

        #endregion

        #region ResizingEngine

        Size sLastTarget;
        private void formConverter_Resize(Size sTarget)
        {
            bool bLarger = true;
            if (sLastTarget != null)
            {
                if ((sTarget.Width * sTarget.Height) < (sLastTarget.Width * sLastTarget.Height))
                    bLarger = false;
            }

            if (!bManualResized)
                this.Size = sTarget;
            else
            {
                if (bLarger)
                {
                    this.Size = new Size(Math.Max(sTarget.Width, this.Size.Width), Math.Max(sTarget.Height, this.Size.Height));
                }
            }

            sLastTarget = sTarget;
        }

        TabPage tp2Circle = null;
        bool tcImportError = false;
        private void formConverter_ResetView()
        {
            if (tp2Circle == null) tp2Circle = tabcontrol.TabPages["tab_2circletracks"];
            if (Experiments.Count != 0 || tcImportError)
            {
                formConverter_Resize(sizeLarge);
                if (b2circleloaded)
                {
                    if (!tabcontrol.TabPages.Contains(tp2Circle))
                    {
                        TabPage tpdest = tabcontrol.TabPages["tab_destination"];
                        tabcontrol.TabPages.Remove(tpdest);
                        tabcontrol.TabPages.Add(tp2Circle);
                        tabcontrol.TabPages.Add(tpdest);
                    }
                }
                else
                {
                    if (tabcontrol.TabPages.Contains(tp2Circle))
                        tabcontrol.TabPages.Remove(tp2Circle);
                }
                tabcontrol.Visible = true;
                lblInfo.Visible = false;
                button_cancel_files.Visible = true;
                btnExit.Visible = false;
                checkAutostart.Visible = false;
            }
            else
            {
                formConverter_Resize(sizeSmall);
                tabcontrol.Visible = false;
                lblInfo.Visible = true;
                button_cancel_files.Visible = false;
                btnExit.Visible = true;
                checkAutostart.Visible = true;
                chart_importeddata.Visible = false;
                chart_result.Visible = false;
                chart_thresholds.Visible = false;
                this.AcceptButton = null;
                this.CancelButton = btnExit;
                lblInfo.Text = Properties.strings.usage_base + Properties.strings.usage_addition;
            }
        }

        Size sBeforeResize;
        Size sAfterResize;
        private void formConverter_ResizeBegin(object sender, EventArgs e)
        {
            if (!bManualResized)
                sBeforeResize = this.Size;
        }

        private void formConverter_ResizeEnd(object sender, EventArgs e)
        {
            if (!bManualResized)
            {
                sAfterResize = this.Size;
                if (sBeforeResize.Width != sAfterResize.Width || sBeforeResize.Height != sAfterResize.Height)
                    bManualResized = true;
            }
        }


        #endregion

        #region TabcontrolEngine

        Size[] sTCSize =
        {
            new Size(1238, 280),
            new Size(1238, 545),
        };
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (tabcontrol.SelectedTab.Name)
            {
                case "tab_import":
                case "tab_basic":
                    menu_grouping.Visible = false;
                    tabcontrol.Size = sTCSize[0];
                    chart_thresholds.Visible = false;
                    chart_importeddata.Visible = true;
                    bAnimalDiagramMode = false;
                    chart_result.Visible = false;
                    formConverter_Resize(sizeLarge);
                    break;

                case "tab_thresholds":
                    menu_grouping.Visible = false;
                    tabcontrol.Size = sTCSize[0];
                    chart_thresholds.Visible = true;
                    chart_importeddata.Visible = false;
                    bAnimalDiagramMode = false;
                    chart_result.Visible = false;
                    formConverter_Resize(sizeLarge);
                    break;

                case "tab_grouping":
                    tabcontrol.Size = sTCSize[1];
                    chart_thresholds.Visible = false;
                    chart_importeddata.Visible = false;
                    bAnimalDiagramMode = false;
                    chart_result.Visible = false;
                    formConverter_Resize(sizeLarge);
                    if (Experiments.Keys.Count > 1)
                    {
                        panel_grouping_multifiles.Visible = true;
                        panel_Grouping_Tutorial.Location = new Point(835, 89);
                        panel_Grouping_Tutorial.Size = new Size(392, 423);
                    } else
                    {
                        panel_grouping_multifiles.Visible = false;
                        panel_Grouping_Tutorial.Location = new Point(835, 6);
                        panel_Grouping_Tutorial.Size = new Size(392, 506);
                    }
                    menu_grouping.Visible = true;
                    break;

                case "tab_results":
                case "tab_2circletracks":
                    menu_grouping.Visible = false;
                    tabcontrol.Size = sTCSize[0];
                    chart_thresholds.Visible = false;
                    chart_importeddata.Visible = true;
                    bAnimalDiagramMode = true;
                    chart_result.Visible = true;
                    formConverter_Resize(sizeXLarge);
                    break;

                case "tab_destination":
                    tabcontrol.Size = sTCSize[1];
                    chart_thresholds.Visible = false;
                    chart_importeddata.Visible = false;
                    bAnimalDiagramMode = false;
                    chart_result.Visible = false;
                    formConverter_Resize(sizeLarge);
                    break;

                default:
                    break;

            }

            ApplyFilterToCharts();

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bGroupLoader = true;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            bGroupLoader = false;
        }


        #endregion

    }
}
