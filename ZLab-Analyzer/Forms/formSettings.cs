using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZLab_Analyzer.Forms
{
    public partial class formSettings : Form
    {

        private bool bInitialized = false;

        public formSettings(ZLabConfiguration Conf)
        {
            InitializeComponent();

            if (Conf.CustomLanguage)
            {
                switch(Conf.CurrentLanguage)
                {
                    case "de":
                        radio_settings_language_de.Checked = true;
                        break;

                    case "en":
                        radio_settings_language_en.Checked = true;
                        break;

                    case "es":
                        radio_settings_language_es.Checked = true;
                        break;

                    default:
                        break;
                }
            } else
            {
                radio_settings_language_sysdefault.Checked = true;
            }
            
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            ApplyLanguageSettings();
            bInitialized = true;
        }

        public void ApplyLanguageSettings()
        {

            this.Text = Properties.strings.settings_header;

            group_settings_languages.Text = Properties.strings.settings_langgroup_header;
            radio_settings_language_de.Text = Properties.strings.settings_langgroup_de;
            radio_settings_language_en.Text = Properties.strings.settings_langgroup_en;
            radio_settings_language_es.Text = Properties.strings.settings_langgroup_es;
            radio_settings_language_sysdefault.Text = Properties.strings.settings_langgroup_default.Replace("{0}", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            lbl_settings_language_subinfo.Text = Properties.strings.settings_langgroup_subinfo;

        }

        public delegate void OnChangeUILanguageHandler(string SelectedLanguage);
        public event OnChangeUILanguageHandler OnChangeUILanguage;

        private void radio_settings_language_sysdefault_CheckedChanged(object sender, EventArgs e)
        {
            if (!bInitialized) return;
            if (OnChangeUILanguage == null) return;
            if (radio_settings_language_sysdefault.Checked) OnChangeUILanguage("");
        }

        private void radio_settings_language_en_CheckedChanged(object sender, EventArgs e)
        {
            if (!bInitialized) return;
            if (OnChangeUILanguage == null) return;
            if (radio_settings_language_en.Checked) OnChangeUILanguage("en");
        }

        private void radio_settings_language_es_CheckedChanged(object sender, EventArgs e)
        {
            if (!bInitialized) return;
            if (OnChangeUILanguage == null) return;
            if (radio_settings_language_es.Checked) OnChangeUILanguage("es");
        }

        private void radio_settings_language_de_CheckedChanged(object sender, EventArgs e)
        {
            if (!bInitialized) return;
            if (OnChangeUILanguage == null) return;
            if (radio_settings_language_de.Checked) OnChangeUILanguage("de");
        }
    }
}
