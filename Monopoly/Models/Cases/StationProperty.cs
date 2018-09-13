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
        const int STATION_PRICE = 1000;

        private Image cacheStationImage = null;

        public StationProperty(string name) : base(name, STATION_PRICE) {
        }

        public override Image GetBoardCaseImage()
        {
            if (cacheStationImage != null)
                return cacheStationImage;

            Image img = base.GetBoardCaseImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;
                
                string name = this.Name;
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
                g.DrawImage(Properties.Resources.Gare, new RectangleF(rectangle.X + 10, 73, rectangle.Width - 20, rectangle.Width - 20));
            }

            return img;
        }
    }
}
