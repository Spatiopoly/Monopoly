using Monopoly.Models;
using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
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

        public frmGame FrmGame { get; set; }

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
        public void UpdateBuildings()
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

            //Switch between buttons mortgage and lift mortgage
            if (Property.IsMortgaged)
            {
                btnMortgage.Enabled = false;
                btnMortgage.Visible = false;
                btnLiftMortgage.Enabled = true;
                btnLiftMortgage.Visible = true;

                btnAddBuilding.Enabled = false;
                btnRemoveBuilding.Enabled = false;
            }
            else
            {

                btnMortgage.Enabled = true;
                btnMortgage.Visible = true;
                btnLiftMortgage.Enabled = false;
                btnLiftMortgage.Visible = false;
            }
        }

        private void btnMortgage_Click(object sender, EventArgs e)
        {            

            //Test if mortgaged property is a street property and if the owner owns all the group
            if (Property is StreetProperty && Game.HasMonopoly(Property.Owner, (Property as StreetProperty).Group))
            {
                //Ask player if he wants to sell all houses on the group's properties
                if (MessageBox.Show("Voulez-vous vendre toues les maisons et hotels présentes sur les propriétés de ce groupe ?", "Hypthèque", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Get some of the owner's properties within the same group
                    List<PropertyCase> groupProperties = Game.CurrentPlayer.GetProperties(Game)
                        .FindAll(
                        property => property is StreetProperty 
                        && (property as StreetProperty).Group == (Property as StreetProperty).Group);

                    //Loop for each property
                    foreach (PropertyCase sp in groupProperties)
                    {
                        //Sell all houses on property
                        while ((sp as StreetProperty).BuildingCount > 0)
                        {
                            (sp as StreetProperty).RemoveBuilding();                            
                        }
                    }
                }
            }



            Property.IsMortgaged = true;
            Property.Invalidate();
            //Return half of the property buying price to the owner
            Property.Owner.Wealth += Property.Price / 2;

            FrmGame.UpdateTabs();
            FrmGame.sideTabs.SelectedTab = FrmGame.sideTabs.TabPages[FrmGame.sideTabs.TabPages.Count - 1];
        }

        private void btnLiftMortgage_Click(object sender, EventArgs e)
        {
            Property.IsMortgaged = false;
            Property.Invalidate();
            //Ower must pay mortgage value plus 10% of interest
            int mortgageValue = Property.Price / 2;
            Property.Owner.Wealth -= mortgageValue + (int)(mortgageValue * 0.1);

            UpdateBuildings();
        }
    }
}
