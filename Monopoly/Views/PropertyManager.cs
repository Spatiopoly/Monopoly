using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly.Models.Cases;

namespace Monopoly.Views
{
    public partial class PropertyManager : UserControl
    {
        PropertyCase property = new StreetProperty(Models.PropertyColor.DarkBlue, "Rue du Yolo", 42, 12, new int[] { 0, 0, 0, 0, 0, 0 });

        public PropertyManager()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            base.OnPaintBackground(e);

            SizeF componentSize = e.Graphics.VisibleClipBounds.Size;
            g.DrawRectangle(Pens.Silver, 0, 0, componentSize.Width - 1, componentSize.Height - 1);
            g.DrawImage(property.GetPropertyCardImage(), new RectangleF(0, 0, 100, 150));
        }
    }
}
