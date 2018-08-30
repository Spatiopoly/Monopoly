using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    abstract class PropertyCase : AbstractCase
    {
        public virtual string Name { get; private set; }

        public Player Owner { get; set; } = null;

        public int Price { get; private set; }

        public PropertyCase(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override void Land(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
