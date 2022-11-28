using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace movablecontrolshape
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private GraphicsPath path = null;
        private void RefreshPath()
        {
            // Create the GraphicsPath for the shape (in this case
            // an ellipse that fits inside the full control area)
            // and apply it to the control by setting
            // the Region property.
            path = new GraphicsPath();
            path.AddEllipse(this.ClientRectangle);
            this.Region = new Region(path);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            if (path != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
                e.Graphics.DrawPath(new Pen(this.ForeColor, 4), path);
            }
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            //base.OnResize(e);
            RefreshPath();
            this.Invalidate();
        }
    }
}
