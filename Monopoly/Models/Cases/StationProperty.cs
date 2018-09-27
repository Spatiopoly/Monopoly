using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class StationProperty : PropertyCase
    {
        const int STATION_PRICE = 200;
        private static readonly int[] STATION_RENTS = new int[] { 25, 50, 100, 200 };

        private Image cacheCaseImage = null;
        private Image cachePropertyImage = null;

        public StationProperty(string name) : base(name, STATION_PRICE) {
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
                g.DrawString("PRIX :    " + STATION_PRICE.ToString(), new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 60));
                g.DrawImage(Properties.Resources.Gare, new RectangleF(rectangle.X + 10, 87, rectangle.Width - 20, rectangle.Width - 20));
            }

            cacheCaseImage = img;
            return img;
        }

        public override Image GetPropertyCardImage()
        {
            if (cachePropertyImage != null)
                return cachePropertyImage;

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

                g.DrawImage(Properties.Resources.Gare, new RectangleF(rectangle.X + 10, 10, rectangle.Width - 20, rectangle.Width - 20));
                g.DrawString(name, new Font("Arial", 10), Brushes.White, new PointF(2.5F, 2.5F + 5));

                // Rent
                int y = 65;
                int height = 12;
                DrawPrice(g, y += height, "Loyer", STATION_RENTS[0]);
                DrawPrice(g, y += height, "Avec 2 gare", STATION_RENTS[1]);
                DrawPrice(g, y += height, "Avec 3 gares", STATION_RENTS[2]);
                DrawPrice(g, y += height, "Avec 4 gares", STATION_RENTS[3]);

                DrawPrice(g, y += 17, "Hypothèque", STATION_PRICE / 2);

            }

            cachePropertyImage = img;
            return img;
        }

        /// <summary>
        /// Get the rent of the card, according to the number of stations owned by this station's owner.
        /// </summary>
        /// <param name="game">The game instance</param>
        /// <returns>The rent to pay</returns>
        public override int GetRent(Game game)
        {
            int rent = 0;
            int stationsOfThisPlayerCount = game.Cases
                .Where(c => c is StationProperty)
                .Where(station => (station as StationProperty).Owner == Owner)
                .ToList()
                .Count;

            rent = STATION_RENTS[stationsOfThisPlayerCount - 1];

            return rent;
        }
    }
}
