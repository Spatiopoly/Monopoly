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

        public bool IsMortgaged { get; set; } = false;

        public PropertyCase(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override void Land(Game game)
        {
            Player currentPlayer = game.CurrentPlayer;

            if (Owner != null && Owner != currentPlayer && !this.IsMortgaged)
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
        /// <param name="scale">Scale of the image (default = 1)</param>
        /// <returns>A blank image of the size of the property card</returns>
        public virtual Image GetPropertyCardImage(int scale)
        {
            Image image = new Bitmap(PROPERTY_CARD_WIDTH * scale, PROPERTY_CARD_HEIGHT * scale);

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
        /// <param name="g">Graphics object</param>
        /// <param name="y">Y position of the price</param>
        /// <param name="name">Key of the price</param>
        /// <param name="price">Value of the price</param>
        /// <param name="scale">Scale of the text to draw</param>
        protected void DrawPrice(Graphics g, int scale, int y, string name, int price)
        {
            g.DrawString(name, new Font("Arial", 6 * scale), new SolidBrush(Color.FromArgb(200, Color.White)), new PointF(2.5F * scale, y + 0.5F * scale));
            g.DrawImage(Properties.Resources.Flouzz, new RectangleF(65 * scale, y + 2.5F * scale, 6 * scale, 6 * scale));
            g.DrawString(price.ToString(), new Font("Arial", 7 * scale, FontStyle.Bold), Brushes.White, new PointF(71 * scale, y));
        }

        /// <summary>
        /// Get the stay price for the case
        /// </summary>
        /// <param name="game">The game (used for some cases)</param>
        /// <returns>Rent</returns>
        public abstract int GetRent(Game game);

        public override string ToString()
            => Name;
    }
}
