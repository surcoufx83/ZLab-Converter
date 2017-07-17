using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZLab_Analyzer
{
    class CustomDatagridviewColumn : DataGridViewColumn
    {
        public CustomDatagridviewColumn() : base(new CustomDatagridviewCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType()
                    .IsAssignableFrom(typeof(CustomDatagridviewCell)))
                    throw new InvalidCastException("It should be a custom Cell");
                base.CellTemplate = value;
            }
        }
    }

}