using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class StreetProperty : PropertyCase
    {
        public int BuildingCount { get; set; } = 0;

        public int BuildingPrice { get; set; }

        /// <summary>
        /// Create a new street property
        /// </summary>
        /// <param name="color">Property group</param>
        /// <param name="name">Street name</param>
        /// <param name="price">Property buy price (2x mortgage)</param>
        /// <param name="buildingPrice">Building price (per unit)</param>
        /// <param name="rents">Rents (index = buildings count)</param>
        public StreetProperty(PropertyColor color, string name, int price, int buildingPrice, int[] rents) : base(name, price)
        {
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
