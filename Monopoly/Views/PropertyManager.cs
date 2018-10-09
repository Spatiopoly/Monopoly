using Monopoly.Models;
using Monopoly.Models.Cases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly.Views
{
    public partial class PropertyManager : UserControl
    {
        private PropertyCase _property = new StreetProperty(Models.PropertyColor.Yellow, "Rue des étoiles", 42, 12, new int[] { 0, 0, 0, 0, 0, 0 });

        /// <summary>
        /// Property shown
        /// </summary>
        public PropertyCase Property
        {
            get => _property;
            set
            {
                _property = value;
                UpdateBuildings();
            }
        }

        /// <summary>
        /// Game instance
        /// </summary>
        public Game Game { get; set; }

        public PropertyManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Paint the background + the property card of the property manager
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            base.OnPaintBackground(e);

            SizeF componentSize = e.Graphics.VisibleClipBounds.Size;
            g.DrawRectangle(Pens.Silver, 0, 0, componentSize.Width - 1, componentSize.Height - 1);
            g.DrawImage(Property.GetPropertyCardImage(1), new RectangleF(0, 0, 100, 150));
        }

        /// <summary>
        /// Add a new building
        /// </summary>
        private void btnAddBuilding_Click(object sender, EventArgs _)
        {
            try
            {
                (Property as StreetProperty).AddBuilding(Game);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }

            UpdateBuildings();
        }

        /// <summary>
        /// Remove a building
        /// </summary>
        private void btnRemoveBuilding_Click(object sender, EventArgs _)
        {
            (Property as StreetProperty).RemoveBuilding();
            UpdateBuildings();
        }

        /// <summary>
        /// Update the display of the buildings
        /// </summary>
        private void UpdateBuildings()
        {
            bool showBuildings = Property is StreetProperty;

            pbxBuilding.Visible = showBuildings;
            btnAddBuilding.Visible = showBuildings;
            btnRemoveBuilding.Visible = showBuildings;

            if (showBuildings)
            {
                StreetProperty street = Property as StreetProperty;
                btnRemoveBuilding.Enabled = street.BuildingCount > 0;
                btnAddBuilding.Enabled = street.BuildingCount < StreetProperty.MAX_BUILDING_COUNT;
            }
        }
    }
}
