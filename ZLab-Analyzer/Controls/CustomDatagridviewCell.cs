﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZLab_Analyzer
{
    class CustomDatagridviewCell : DataGridViewCell
    {
        public CustomDatagridviewCell() : base() { }
        
        public override Type FormattedValueType
        {
            get  {  return typeof(AnimalgroupWellControl); }
        }

        public override Type ValueType
        {
            get { return typeof(AnimalgroupWellControl); }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            var ctrl = (AnimalgroupWellControl)new AnimalgroupWellControl();
            var img = new Bitmap(cellBounds.Width, cellBounds.Height);
            ctrl.DrawToBitmap(img, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
            graphics.DrawImage(img, cellBounds.Location);
        }

        //protected override void OnClick(DataGridViewCellEventArgs e)
        //{
        //    List<InfoObject> objs = DataGridView.DataSource as List<InfoObject>;
        //    if (objs == null)
        //        return;
        //    if (e.RowIndex < 0 || e.RowIndex >= objs.Count)
        //        return;

        //    AnimalgroupWellControl ctrl = objs[e.RowIndex].Ctrl;
        //    // Take any action - I will just change the color for now.
        //    ctrl.BackColor = Color.Red;
        //    ctrl.Refresh();
        //    DataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);
        //}

    }
}
