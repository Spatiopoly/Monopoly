using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class CardCase : AbstractCase
    {
        private Image cacheCaseImage = null;

        public CardType Type { get; private set; }

        /// <summary>
        /// Get the illustration image of the card type
        /// </summary>
        public Image TypeImage
            => Type == CardType.Chance
            ? Properties.Resources.Luck
            : Properties.Resources.CommunityChest;

        public CardCase(CardType type)
        {
            Type = type;
        }

        public override void Land(Game game)
        {
            //throw new NotImplementedException();
        }

        public override Image GetBoardCaseImage()
        {
            if (cacheCaseImage != null)
                return cacheCaseImage;

            Image img = base.GetBoardCaseImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;

                string name = ToString().Replace(' ', '\n');
                g.DrawString(name, new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 15));

                Image image = TypeImage; 
                g.DrawImage(image, new RectangleF(rectangle.X + 10, 87, rectangle.Width - 20, rectangle.Width - 20));
            }

            return img;
        }

        public override string ToString()
        {
            return Type == CardType.Chance ? "Chance" : "Community chest";
        }
    }
}
