using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class UtilityProperty : PropertyCase
    {
        const int UTILITY_PRICE = 150;
        private static readonly int[] UTILITY_RENTS = new int[] { 4, 10 };

        private Image cacheCaseImage = null;
        private Image cacheCardImage = null;

        public UtilityProperty(string name) : base(name, UTILITY_PRICE)
        {
		}

        public override Image GetBoardCaseImage()
        {
            if (cacheCaseImage != null)
                return cacheCaseImage;

            Image img = base.GetBoardCaseImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;

                string name = Name;

                int spaceIndex = name.LastIndexOf(' ');
                if (spaceIndex != -1)
                {
                    char[] n = name.ToCharArray();
                    n[spaceIndex] = '\n';
                    name = new string(n);
                }

                g.DrawString(name, new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 15));
                g.DrawImage(Properties.Resources.Flouzz, new RectangleF(rectangle.X + 60, 63, 12, 12));
                g.DrawString("PRIX :    " + UTILITY_PRICE.ToString(), new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 60));

                var image = (Name == "Water Delivery") ? Properties.Resources.UtilityWater : Properties.Resources.UtilityEnergy;
                g.DrawImage(image, new RectangleF(rectangle.X + 10, 87, rectangle.Width - 20, rectangle.Width - 20));
            }

            cacheCaseImage = img;
            return img;
        }

        public override Image GetPropertyCardImage()
        {

            if (cacheCardImage != null)
                return cacheCardImage;

            Image img = base.GetPropertyCardImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;

                string name = Name;

                int spaceIndex = name.LastIndexOf(' ');
                if (spaceIndex != -1)
                {
                    char[] n = name.ToCharArray();
                    n[spaceIndex] = '\n';
                    name = new string(n);
                }

                g.DrawString(name, new Font("Arial", 7), Brushes.White, new PointF(rectangle.X + 2, 50));

                var image = (Name == "Water Delivery") ? Properties.Resources.UtilityWater : Properties.Resources.UtilityEnergy;
                g.DrawImage(image, new RectangleF(rectangle.X + 2, 2, rectangle.Width - 50, rectangle.Width - 50));

                // Rent
                int y = 62;
                int height = 12;
                g.DrawString("Loyer si le bailleur possède", new Font("Arial", 6), Brushes.White, new PointF(rectangle.X + 2, y += height));
                g.DrawString("1 utility :", new Font("Arial", 6), Brushes.White, new PointF(rectangle.X + 2, y += height + 2));
                DrawPrice(g, y += height -1,"Nombre du dé  x ", UTILITY_RENTS[0]);
                g.DrawString("2 utilities :", new Font("Arial", 6), Brushes.White, new PointF(rectangle.X + 2, y += height + 2));
                DrawPrice(g, y += height -1,"Nombre du dé  x", UTILITY_RENTS[1]);

                DrawPrice(g, y += height, "Hypothèque", UTILITY_PRICE / 2);
            }

            cacheCardImage = img;
            return img;
        }

        public override int GetRent(Game game)
        {
            int rent = 0;
            int utilitiesOfThisPlayerCount = game.Cases
                .Where(c => c is UtilityProperty)
                .Where(station => (station as UtilityProperty).Owner == Owner)
                .ToList()
                .Count;

            switch (utilitiesOfThisPlayerCount)
            {
                case 1:
                    rent = UTILITY_RENTS[0] * game.LastDiceSum;
                    break;
                case 2:
                    rent = UTILITY_RENTS[1] * game.LastDiceSum;
                    break;
                default:
                    rent = -1;
                    break;
            }

            return rent;
        }
    }
}
