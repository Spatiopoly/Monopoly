using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class TaxCase : AbstractCase
    {
        private Image cacheTaxImage = null;

        public enum Tax { IncomeTax = 100, LuxuryTax = 1000 }

        public Tax Type { get; private set; }

        public int Amount
            => (int)Type;

        public TaxCase(Tax type)
        {
            Type = type;
        }

        public override void Land(Game game) { }

        public override Image GetBoardCaseImage()
        {
            if (cacheTaxImage != null)
                return cacheTaxImage;

            Image img = base.GetBoardCaseImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;

                string name = "Taxe";              

                g.DrawString(name, new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 15));

                g.DrawImage(Properties.Resources.Flouzz, new RectangleF(rectangle.X + 60, 63, 12, 12));
                g.DrawString("PRIX :    " + Amount.ToString(), new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 60));
                g.DrawImage(Properties.Resources.taxe, new RectangleF(rectangle.X + 10, 73, rectangle.Width - 20, rectangle.Width - 20));
            }

            return img;
        }
    }
}
