using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ZLab_Analyzer
{
    public partial class AnimalgroupWellControl : UserControl
    {

        private string sTitle = "";
        private Color cBack = SystemColors.WindowFrame;
        private Color cFore = SystemColors.ButtonFace;
        private int iGroup = 0;
        private int iValue = -1;

        private GraphicsPath path = new GraphicsPath();
        

        public AnimalgroupWellControl()
        {
            InitializeComponent();
            path.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            this.Region = new Region(path);
            this.BackColor = cBack;
            this.ForeColor = cFore;
        }

        public void Redraw()
        {
            lblTitle.Text = sTitle;
            lblGroup.Text = (iGroup != 0 ? "(Gruppe " + iGroup.ToString() + ")" : "");
            lblValue.Text = (iValue != -1 ? iValue.ToString() + "%" : "");
            this.BackColor = cBack;
            this.ForeColor = cFore;
        }

        public string Title
        {
            get { return sTitle; }
            set
            {
                sTitle = value;
                Redraw();
            }
        }

        public int Groupnumber
        {
            get { return iGroup; }
            set
            {
                iGroup = value;
                Redraw();
            }
        }

        public int Value
        {
            get { return iValue; }
            set
            {
                iValue = value;
                Redraw();
            }
        }

        public Color Background
        {
            get { return cBack; }
            set
            {
                cBack = value;
                Redraw();
            }
        }

        public Color Foreground
        {
            get { return cFore; }
            set
            {
                cFore = value;
                Redraw();
            }
        }

    }
}
