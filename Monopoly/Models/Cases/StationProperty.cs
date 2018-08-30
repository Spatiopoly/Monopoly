using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class StationProperty : PropertyCase
    {
        const int STATION_PRICE = 1000;

        public StationProperty(string name) : base(name, STATION_PRICE) {
        }
    }
}
