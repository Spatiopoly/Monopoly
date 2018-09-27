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
            Player currentPlayer = game.CurrentPlayer;

            if (Owner != null && Owner != currentPlayer)
            {
                int rent = GetRent(game);
                currentPlayer.Wealth -= rent;
                Owner.Wealth += rent;
                game.SendMessage($"{currentPlayer.Name} paye {rent} de loyer à {Owner.Name}");
            }
        }

        /// <summary>
        /// Create a blank (empty) property card image that can be extended by subclasses
        /// </summary>
        /// <returns>A blank image of the size of the property card</returns>
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
        /// Draw a line of text on the card to indicate the price
        /// </summary>
        /// <param name="g"></param>
        /// <param name="y"></param>
        /// <param name="name">Key of the price</param>
        /// <param name="price">Value of the price</param>
        protected virtual void DrawPrice(Graphics g, int y, string name, int price)
        {
            g.DrawString(name, new Font("Arial", 6), new SolidBrush(Color.FromArgb(200, Color.White)), new PointF(2.5F, y + 0.5F));
            g.DrawImage(Properties.Resources.Flouzz, new RectangleF(65, y + 2.5F, 6, 6));
            g.DrawString(price.ToString(), new Font("Arial", 7, FontStyle.Bold), Brushes.White, new PointF(71, y));
        }

        /// <summary>
        /// Get the stay price for the case
        /// </summary>
        /// <param name="game">The game (used for some cases)</param>
        /// <returns>Rent</returns>
        public abstract int GetRent(Game game);
    }
}
