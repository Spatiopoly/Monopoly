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
        const int UTILITY_PRICE = 500;

        private Image cacheUtilityImage = null;

        public UtilityProperty(string name) : base(name, UTILITY_PRICE)
        {
		}

        public override Image GetBoardCaseImage()
        {
            if (cacheUtilityImage != null)
                return cacheUtilityImage;

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
                // ATTENTION : image à changer 
                g.DrawImage(Properties.Resources.Gare, new RectangleF(rectangle.X + 10, 73, rectangle.Width - 20, rectangle.Width - 20));
            }

            return img;
        }

        public override int GetRent()
        {
            return 42; // @TODO
        }
    }
}
