using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Views;

namespace Monopoly.Models.Cases
{
    public abstract class PropertyCase : AbstractCase
    {
        public const int PROPERTY_CARD_WIDTH = 100;
        public const int PROPERTY_CARD_HEIGHT = 150;

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
            // throw new NotImplementedException();
        }

        public virtual Image GetPropertyCardImage()
        {
            Image image = new Bitmap(PROPERTY_CARD_WIDTH, PROPERTY_CARD_HEIGHT);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Colors.CARD_BG_COLOR);
            }

            return image;
        }

        /// <summary>
        /// Get the stay price for the case
        /// </summary>
        /// <returns>Rent</returns>
        public abstract int GetRent();
    }
}
