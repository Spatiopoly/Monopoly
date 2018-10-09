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

        private void btnAddBuilding_Click(object sender, System.EventArgs e)
        {
            if (Property is StreetProperty)
            {
                if ((Property as StreetProperty).Owner.Wealth >= (Property as StreetProperty).BuildingPrice && (Property as StreetProperty).BuildingCount < 5)
                {
                    (Property as StreetProperty).Owner.Wealth -= (Property as StreetProperty).BuildingPrice;
                    (Property as StreetProperty).BuildingCount++;
                }
            }
            else
            {
                //@TODO faire disparaitre les boutons avant le click pour les stations et utilities
                btnAddBuilding.Visible = false;
                btnRemoveBuilding.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private void btnRemoveBuilding_Click(object sender, System.EventArgs e)
        {
            if (Property is StreetProperty)
            {
                if ((Property as StreetProperty).BuildingCount > 0)
                {
                    (Property as StreetProperty).Owner.Wealth += (Property as StreetProperty).BuildingPrice;
                    (Property as StreetProperty).BuildingCount--;
                }
            }
            else
            {
                //@TODO faire disparaitre les boutons avant le click pour les stations et utilities
                btnAddBuilding.Visible = false;
                btnRemoveBuilding.Visible = false;
                pictureBox1.Visible = false;
            }
        }
    }
}
