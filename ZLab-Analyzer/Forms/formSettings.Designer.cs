namespace ZLab_Analyzer.Forms
{
    partial class formSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSettings));
            this.group_settings_languages = new System.Windows.Forms.GroupBox();
            this.lbl_settings_language_subinfo = new System.Windows.Forms.Label();
            this.radio_settings_language_sysdefault = new System.Windows.Forms.RadioButton();
            this.radio_settings_language_es = new System.Windows.Forms.RadioButton();
            this.radio_settings_language_en = new System.Windows.Forms.RadioButton();
            this.radio_settings_language_de = new System.Windows.Forms.RadioButton();
            this.group_settings_languages.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_settings_languages
            // 
            this.group_settings_languages.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.group_settings_languages.Controls.Add(this.lbl_settings_language_subinfo);
            this.group_settings_languages.Controls.Add(this.radio_settings_language_sysdefault);
            this.group_settings_languages.Controls.Add(this.radio_settings_language_es);
            this.group_settings_languages.Controls.Add(this.radio_settings_language_en);
            this.group_settings_languages.Controls.Add(this.radio_settings_language_de);
            this.group_settings_languages.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.group_settings_languages.Location = new System.Drawing.Point(12, 12);
            this.group_settings_languages.Name = "group_settings_languages";
            this.group_settings_languages.Size = new System.Drawing.Size(328, 211);
            this.group_settings_languages.TabIndex = 0;
            this.group_settings_languages.TabStop = false;
            this.group_settings_languages.Text = "group_settings_languages";
            // 
            // lbl_settings_language_subinfo
            // 
            this.lbl_settings_language_subinfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_settings_language_subinfo.Location = new System.Drawing.Point(6, 140);
            this.lbl_settings_language_subinfo.Name = "lbl_settings_language_subinfo";
            this.lbl_settings_language_subinfo.Size = new System.Drawing.Size(316, 68);
            this.lbl_settings_language_subinfo.TabIndex = 5;
            this.lbl_settings_language_subinfo.Text = "lbl_settings_language_subinfo";
            // 
            // radio_settings_language_sysdefault
            // 
            this.radio_settings_language_sysdefault.AutoSize = true;
            this.radio_settings_language_sysdefault.Location = new System.Drawing.Point(6, 24);
            this.radio_settings_language_sysdefault.Name = "radio_settings_language_sysdefault";
            this.radio_settings_language_sysdefault.Size = new System.Drawing.Size(229, 21);
            this.radio_settings_language_sysdefault.TabIndex = 4;
            this.radio_settings_language_sysdefault.TabStop = true;
            this.radio_settings_language_sysdefault.Text = "radio_settings_language_sysdefault";
            this.radio_settings_language_sysdefault.UseVisualStyleBackColor = true;
            this.radio_settings_language_sysdefault.CheckedChanged += new System.EventHandler(this.radio_settings_language_sysdefault_CheckedChanged);
            // 
            // radio_settings_language_es
            // 
            this.radio_settings_language_es.AutoSize = true;
            this.radio_settings_language_es.Location = new System.Drawing.Point(6, 78);
            this.radio_settings_language_es.Name = "radio_settings_language_es";
            this.radio_settings_language_es.Size = new System.Drawing.Size(184, 21);
            this.radio_settings_language_es.TabIndex = 2;
            this.radio_settings_language_es.TabStop = true;
            this.radio_settings_language_es.Text = "radio_settings_language_es";
            this.radio_settings_language_es.UseVisualStyleBackColor = true;
            this.radio_settings_language_es.CheckedChanged += new System.EventHandler(this.radio_settings_language_es_CheckedChanged);
            // 
            // radio_settings_language_en
            // 
            this.radio_settings_language_en.AutoSize = true;
            this.radio_settings_language_en.Location = new System.Drawing.Point(6, 51);
            this.radio_settings_language_en.Name = "radio_settings_language_en";
            this.radio_settings_language_en.Size = new System.Drawing.Size(185, 21);
            this.radio_settings_language_en.TabIndex = 1;
            this.radio_settings_language_en.TabStop = true;
            this.radio_settings_language_en.Text = "radio_settings_language_en";
            this.radio_settings_language_en.UseVisualStyleBackColor = true;
            this.radio_settings_language_en.CheckedChanged += new System.EventHandler(this.radio_settings_language_en_CheckedChanged);
            // 
            // radio_settings_language_de
            // 
            this.radio_settings_language_de.AutoSize = true;
            this.radio_settings_language_de.Location = new System.Drawing.Point(6, 105);
            this.radio_settings_language_de.Name = "radio_settings_language_de";
            this.radio_settings_language_de.Size = new System.Drawing.Size(186, 21);
            this.radio_settings_language_de.TabIndex = 3;
            this.radio_settings_language_de.TabStop = true;
            this.radio_settings_language_de.Text = "radio_settings_language_de";
            this.radio_settings_language_de.UseVisualStyleBackColor = true;
            this.radio_settings_language_de.CheckedChanged += new System.EventHandler(this.radio_settings_language_de_CheckedChanged);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.group_settings_languages);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formSettings";
            this.Text = "formSettings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formSettings_Load);
            this.group_settings_languages.ResumeLayout(false);
            this.group_settings_languages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_settings_languages;
        private System.Windows.Forms.RadioButton radio_settings_language_sysdefault;
        private System.Windows.Forms.RadioButton radio_settings_language_es;
        private System.Windows.Forms.RadioButton radio_settings_language_en;
        private System.Windows.Forms.RadioButton radio_settings_language_de;
        private System.Windows.Forms.Label lbl_settings_language_subinfo;
    }
}