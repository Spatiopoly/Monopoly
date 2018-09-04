using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Monopoly.Models.Cases
{
    class StreetProperty : PropertyCase
    {
        public int BuildingCount { get; set; } = 0;

        public int BuildingPrice { get; set; }

        public PropertyColor Group { get; private set; }

        public Color Color
        {
            get
            {
                switch (Group)
                {
                    case PropertyColor.DarkPurple:
                        return Color.DarkMagenta;
                    case PropertyColor.LightBlue:
                        return Color.FromArgb(135, 205, 222);
                    case PropertyColor.Pink:
                        return Color.Pink;
                    case PropertyColor.Orange:
                        return Color.Orange;
                    case PropertyColor.Red:
                        return Color.Red;
                    case PropertyColor.Yellow:
                        return Color.FromArgb(255, 204, 0);
                    case PropertyColor.Green:
                        return Color.Green;
                    case PropertyColor.DarkBlue:
                        return Color.FromArgb(0, 0, 212);
                }

                return Color.Black;
            }
        }

        /// <summary>
        /// Create a new street property
        /// </summary>
        /// <param name="color">Property group</param>
        /// <param name="name">Street name</param>
        /// <param name="price">Property buy price (2x mortgage)</param>
        /// <param name="buildingPrice">Building price (per unit)</param>
        /// <param name="rents">Rents (index = buildings count)</param>
        public StreetProperty(PropertyColor group, string name, int price, int buildingPrice, int[] rents) : base(name, price)
        {
            Group = group;

            if (rents.Length != 6)
                throw new ArgumentException("Properties should have 6 rent prices : no house, 1 house, 2 houses, 3 houses, 4 houses, 1 hostel");

            for (int i = 1; i < rents.Length; i++)
            {
                if (rents[i] < rents [i - 1])
                {
                    throw new ArgumentException("Property prices increase incorrect");
                }
            }

            BuildingPrice = buildingPrice;
		}
    }
}
