using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    public class PropertyCase : AbstractCase
    {
        public Player Owner { get; set; } = null;

        public override void Land(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
