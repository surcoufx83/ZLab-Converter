using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace ZLab_Analyzer
{
    public class ZLabConfiguration
    {

        private string sFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZLab-Analyzer", "app.config.xml");

        private XDocument xDoc;
        private clsFilter oCurrentFilter = new clsFilter();
        private clsFilter oLastFilter = null;
        private clsFilter oFavFilter0 = null;
        private clsFilter oFavFilter1 = null;
        private clsFilter oFavFilter2 = null;

        public ZLabConfiguration()
        {
            if (!File.Exists(sFilename))
                CreateNewObject();
            else
            {
                xDoc = XDocument.Load(sFilename);

                string sUpdate = xDoc.Element("zlab").Element("main").Element("update").Value;
                ApplyUpdate(sUpdate);

                string sLast = xDoc.Element("zlab").Element("convert-filter").Element("items").Element("last").Value;
                if (sLast != "")
                {
                    oLastFilter = new clsFilter(sLast);
                    CopyLastToCurrent();
                }

                string sFav = xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-0").Value;
                if (sFav != "")
                    oFavFilter0 = new clsFilter(sFav);

                sFav = xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-1").Value;
                if (sFav != "")
                    oFavFilter1 = new clsFilter(sFav);

                sFav = xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-2").Value;
                if (sFav != "")
                    oFavFilter2 = new clsFilter(sFav);
            }
        }

        private void CreateNewObject()
        {
            xDoc = new XDocument(
                new XElement("zlab", 
                    new XElement("main", 
                        new XElement("update", "4"), 
                        new XElement("autostart", "False"),
                        new XElement("license-accepted", "True"),
                        new XElement("language-default", "True"),
                        new XElement("language-custom", ""),
                        new XElement("open-explorer-after-export", "True")
                    ),
                    new XElement("support",
                        new XElement("display-error-level", "40"),
                        new XElement("auto-report-error-level", "20"),
                        new XElement("auto-report-error-contact", ""),
                        new XElement("auto-report-error-configured", "False"),
                        new XElement("auto-report-error-enabled", "False")
                    ),
                    new XElement("mode",
                        new XElement("last", ""),
                        new XElement("auto", "")
                    ),
                    new XElement("convert-filter", 
                        new XElement("autoconvert", "False"), 
                        new XElement("current-changed", "False"),
                        new XElement("items",
                            new XElement("current", oCurrentFilter.ToString()),
                            new XElement("last", ""),
                            new XElement("favorite-0", ""),
                            new XElement("favorite-1", ""),
                            new XElement("favorite-2", "")
                        )
                    )
                )
            );
            Directory.CreateDirectory(Path.GetDirectoryName(sFilename));
            xDoc.Save(sFilename);
        }

        private void ApplyUpdate(string sUpdate)
        {

            switch(sUpdate)
            {

                case "0":
                    string s = xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite").Value;
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite").Remove();
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Add(new XElement("favorite-0", s));
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Add(new XElement("favorite-1", ""));
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Add(new XElement("favorite-2", ""));
                    System.Collections.Generic.IEnumerable<XElement> elements = xDoc.Element("zlab").Element("convert-filter").Element("items").Elements();
                    System.Collections.Generic.List<string> sDelete = new System.Collections.Generic.List<string>();
                    foreach (XElement e in elements)
                    {
                        if (e.Name.LocalName.StartsWith("filter-"))
                        {
                            sDelete.Add(e.Name.LocalName);
                        }
                    }
                    foreach (string e in sDelete)
                    {
                        xDoc.Element("zlab").Element("convert-filter").Element("items").Element(e).Remove();
                    }

                    xDoc.Element("zlab").Element("main").Element("update").Value = "1";
                    xDoc.Save(sFilename);
                    goto case "1";

                case "1":
                    xDoc.Element("zlab").Element("main").Add(new XElement("license-accepted", "True"));
                    xDoc.Element("zlab").Element("main").Element("update").Value = "2";
                    xDoc.Save(sFilename);
                    goto case "2";

                case "2":
                    xDoc.Element("zlab").Add(new XElement("support",
                        new XElement("display-error-level", "40"),
                        new XElement("auto-report-error-level", "20"),
                        new XElement("auto-report-error-contact", ""),
                        new XElement("auto-report-error-configured", "False"),
                        new XElement("auto-report-error-enabled", "False")
                    ));
                    xDoc.Element("zlab").Element("main").Element("update").Value = "3";
                    xDoc.Save(sFilename);
                    goto case "3";

                case "3":
                    xDoc.Element("zlab").Element("main").Add(
                        new XElement("language-default", "True"),
                        new XElement("language-custom", ""),
                        new XElement("open-explorer-after-export", "True")
                    );
                    xDoc.Element("zlab").Element("main").Element("update").Value = "4";
                    xDoc.Save(sFilename);
                    goto case "4";

                case "4":
                    break;

                default:
                    break;

            }

        }

        public bool AutostartConverting
        {
            get { return clsTools.string2bool(xDoc.Element("zlab").Element("convert-filter").Element("autoconvert").Value); }
            set { xDoc.Element("zlab").Element("convert-filter").Element("autoconvert").Value = clsTools.bool2string(value); xDoc.Save(sFilename); }
        }

        public bool AutostartEnabled
        {
            get { return clsTools.string2bool(xDoc.Element("zlab").Element("main").Element("autostart").Value); }
            set { xDoc.Element("zlab").Element("main").Element("autostart").Value = value.ToString(); xDoc.Save(sFilename); }
        }

        public string AutostartMode
        {
            get { return xDoc.Element("zlab").Element("mode").Element("auto").Value; }
            set { xDoc.Element("zlab").Element("mode").Element("auto").Value = value; xDoc.Save(sFilename); }
        }

        public void CopyCurrentToFavorite(int iId)
        {
            switch(iId)
            {
                case 0:
                    oFavFilter0 = new clsFilter(oCurrentFilter.ToString());
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-0").Value = oFavFilter0.ToString();
                    xDoc.Save(sFilename);
                    break;
                case 1:
                    oFavFilter1 = new clsFilter(oCurrentFilter.ToString());
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-1").Value = oFavFilter1.ToString();
                    xDoc.Save(sFilename);
                    break;
                case 2:
                    oFavFilter2 = new clsFilter(oCurrentFilter.ToString());
                    xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-2").Value = oFavFilter2.ToString();
                    xDoc.Save(sFilename);
                    break;
                default:
                    break;
            }
        }

        public void CopyCurrentToLast()
        {
            LastFilter = new clsFilter(oCurrentFilter.ToString());
            xDoc.Element("zlab").Element("convert-filter").Element("items").Element("last").Value = oCurrentFilter.ToString();
            xDoc.Save(sFilename);
        }

        public void CopyLastToCurrent()
        {
            oCurrentFilter = new clsFilter(oLastFilter.ToString());
            xDoc.Element("zlab").Element("convert-filter").Element("items").Element("current").Value = oCurrentFilter.ToString();
            xDoc.Save(sFilename);
        }

        public clsFilter CurrentFilter
        {
            get { return oCurrentFilter; }
        }

        public string CurrentLanguage
        {
            get
            {
                if (clsTools.string2bool(xDoc.Element("zlab").Element("main").Element("language-default").Value)) return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                else return xDoc.Element("zlab").Element("main").Element("language-custom").Value;
            }
            set
            {
                if (value == "")
                {
                    xDoc.Element("zlab").Element("main").Element("language-default").Value = clsTools.bool2string(true);
                    xDoc.Element("zlab").Element("main").Element("language-custom").Value = "";
                } else
                {
                    xDoc.Element("zlab").Element("main").Element("language-default").Value = clsTools.bool2string(false);
                    xDoc.Element("zlab").Element("main").Element("language-custom").Value = value;
                }
                xDoc.Save(sFilename);
            }
        }

        public bool CustomLanguage
        {
            get { return !clsTools.string2bool(xDoc.Element("zlab").Element("main").Element("language-default").Value); }
        }

        public bool ErrorReporting_AutoReportConfigured
        {
            get { return clsTools.string2bool(xDoc.Element("zlab").Element("support").Element("auto-report-error-configured").Value); }
            set { xDoc.Element("zlab").Element("support").Element("auto-report-error-configured").Value = clsTools.bool2string(value); xDoc.Save(sFilename); }
        }

        public string ErrorReporting_AutoReportContact
        {
            get { return xDoc.Element("zlab").Element("support").Element("auto-report-error-contact").Value; }
            set { xDoc.Element("zlab").Element("support").Element("auto-report-error-contact").Value = value; xDoc.Save(sFilename); }
        }

        public bool ErrorReporting_AutoReportEnabled
        {
            get { return clsTools.string2bool(xDoc.Element("zlab").Element("support").Element("auto-report-error-enabled").Value); }
            set { xDoc.Element("zlab").Element("support").Element("auto-report-error-enabled").Value = clsTools.bool2string(value); xDoc.Save(sFilename); }
        }

        public int ErrorReporting_AutoReport_MinLevel
        {
            get { return clsTools.string2int(xDoc.Element("zlab").Element("support").Element("auto-report-error-level").Value); }
            set { xDoc.Element("zlab").Element("support").Element("auto-report-error-level").Value = clsTools.int2string(value); xDoc.Save(sFilename); }
        }

        public int ErrorReporting_DisplayToUser_MinLevel
        {
            get { return clsTools.string2int(xDoc.Element("zlab").Element("support").Element("display-error-level").Value); }
            set { xDoc.Element("zlab").Element("support").Element("display-error-level").Value = clsTools.int2string(value); xDoc.Save(sFilename); }
        }

        public clsFilter FavoriteFilter0
        {
            get { return oFavFilter0; }
            set
            {
                oFavFilter0 = value;
                xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-0").Value = oFavFilter0.ToString();
                xDoc.Save(sFilename);
            }
        }

        public clsFilter FavoriteFilter1
        {
            get { return oFavFilter1; }
            set
            {
                oFavFilter1 = value;
                xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-1").Value = oFavFilter1.ToString();
                xDoc.Save(sFilename);
            }
        }

        public clsFilter FavoriteFilter2
        {
            get { return oFavFilter2; }
            set
            {
                oFavFilter2 = value;
                xDoc.Element("zlab").Element("convert-filter").Element("items").Element("favorite-0").Value = oFavFilter2.ToString();
                xDoc.Save(sFilename);
            }
        }

        public bool FilterChanged
        {
            get { return clsTools.string2bool(xDoc.Element("zlab").Element("convert-filter").Element("current-changed").Value); }
            set { xDoc.Element("zlab").Element("convert-filter").Element("current-changed").Value = clsTools.bool2string(value); xDoc.Save(sFilename); }
        }

        public clsFilter LastFilter
        {
            get { return oLastFilter; }
            set
            {
                oLastFilter = value;
                xDoc.Element("zlab").Element("convert-filter").Element("items").Element("last").Value = oLastFilter.ToString();
                xDoc.Save(sFilename);
            }
        }

        public string LastMode
        {
            get { return xDoc.Element("zlab").Element("mode").Element("last").Value; }
            set { xDoc.Element("zlab").Element("mode").Element("last").Value = value; xDoc.Save(sFilename); }
        }

        public void SaveCurrentFilter()
        {
            xDoc.Save(sFilename);
        }
        
        public void SelectFilter(int iId)
        {
            switch(iId)
            {

                case 0:
                    if (oFavFilter0 != null)
                    {
                        oCurrentFilter = new clsFilter(oFavFilter0.ToString());
                        oLastFilter = new clsFilter(oFavFilter0.ToString());
                    }
                    break;

                case 1:
                    if (oFavFilter1 != null)
                    {
                        oCurrentFilter = new clsFilter(oFavFilter1.ToString());
                        oLastFilter = new clsFilter(oFavFilter1.ToString());
                    }
                    break;

                case 2:
                    if (oFavFilter2 != null)
                    {
                        oCurrentFilter = new clsFilter(oFavFilter2.ToString());
                        oLastFilter = new clsFilter(oFavFilter2.ToString());
                    }
                    break;

                default:
                    break;

            }
            xDoc.Save(sFilename);
        }

        public bool ShowExplorer
        {
            get { return clsTools.string2bool(xDoc.Element("zlab").Element("main").Element("open-explorer-after-export").Value); }
            set { xDoc.Element("zlab").Element("main").Element("open-explorer-after-export").Value = clsTools.bool2string(value); xDoc.Save(sFilename); }
        }

    }
}
