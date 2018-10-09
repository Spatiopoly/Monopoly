using Monopoly.Models.Cases;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly.Views
{
    public partial class PropertyManager : UserControl
    {
        public PropertyCase Property { get; set; }
            = new StreetProperty(Models.PropertyColor.DarkBlue, "Rue du Yolo", 42, 12, new int[] { 0, 0, 0, 0, 0, 0 });

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
            g.DrawImage(Property.GetPropertyCardImage(1), new RectangleF(0, 0, 100, 150));
        }
    }
}
