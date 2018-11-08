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

        public UtilityProperty(string name) : base(name, UTILITY_PRICE)
        {
		}

        public override Image GetBoardCaseImage(Game game)
        {
            if (imageCache.ContainsKey("board-case"))
                return imageCache["board-case"];

            Image img = base.GetBoardCaseImage(game);

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

                if (!this.IsMortgaged)
                {
                    string price = (Owner != null) ? "LOYER :    " + GetRent(game).ToString() : "PRIX :    " + UTILITY_PRICE.ToString();
                    g.DrawString(price, new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 60));
                } else
                {
                    g.DrawString("Hypotéquée", new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 60));
                }
                

                var image = (Name == "Water Delivery") ? Properties.Resources.UtilityWater : Properties.Resources.UtilityEnergy;
                g.DrawImage(image, new RectangleF(rectangle.X + 10, 87, rectangle.Width - 20, rectangle.Width - 20));
            }

            imageCache["board-case"] = img;
            return img;
        }

        public override Image GetPropertyCardImage(int scale)
        {
            if (imageCache.ContainsKey($"property-card-{scale}x"))
                return imageCache[$"property-card-{scale}x"];

            Image img = base.GetPropertyCardImage(scale);

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

                g.DrawString(name, new Font("Arial", 7 * scale), Brushes.White, new PointF(rectangle.X + 2 * scale, 50 * scale));

                var image = (Name == "Water Delivery") ? Properties.Resources.UtilityWater : Properties.Resources.UtilityEnergy;
                g.DrawImage(image, new RectangleF(rectangle.X + 2 * scale, 2 * scale, rectangle.Width - 50 * scale, rectangle.Width - 50 * scale));

                // Rent
                int y = 62 * scale;
                int height = 12 * scale;
                g.DrawString("Loyer si le bailleur possède", new Font("Arial", 6 * scale), Brushes.White, new PointF(rectangle.X + 2 * scale, y += height));
                g.DrawString("1 service :", new Font("Arial", 6 * scale), Brushes.White, new PointF(rectangle.X + 2 * scale, y += height + 2 * scale));
                DrawPrice(g, scale, y += height - 1 * scale, "Nombre du dé  x ", UTILITY_RENTS[0]);
                g.DrawString("2 services :", new Font("Arial", 6 * scale), Brushes.White, new PointF(rectangle.X + 2 * scale, y += height + 2 * scale));
                DrawPrice(g, scale, y += height - 1 * scale, "Nombre du dé  x", UTILITY_RENTS[1]);

                DrawPrice(g, scale, y += height, "Hypothèque", UTILITY_PRICE / 2);
            }

            imageCache[$"property-card-{scale}x"] = img;
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

            rent = UTILITY_RENTS[utilitiesOfThisPlayerCount - 1] * (game.LastFirstDiceResult + game.LastSecDiceResult);

            return rent;
        }
    }
}
