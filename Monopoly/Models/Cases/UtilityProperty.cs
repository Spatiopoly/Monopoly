using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class UtilityProperty : PropertyCase
    {
        const int UTILITY_PRICE = 500;

        public UtilityProperty(string name) : base(name, UTILITY_PRICE)
        {
		}
    }
}
