using Monopoly.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    public abstract class AbstractCase
    {
        // Size of a "standard" board case (this doesn't apply to the corner cases)
        public const int BOARD_CASE_WIDTH = 123;
        public const int BOARD_CASE_HEIGHT = 195;

        /// <summary>
        /// Cache the images relative to this case.
        /// Since all the images have to be generated, caching them improves drastically performance.
        /// </summary>
        protected Dictionary<string, Image> imageCache = new Dictionary<string, Image>();

        /// <summary>
        /// What happens when a player lands on the case?
        /// </summary>
        /// <param name="game">The game status</param>
        public virtual void Land(Game game) { }

        /// <summary>
        /// What happens when a players pass through the case?
        /// </summary>
        /// <param name="game">The game status</param>
        public virtual void FlyOver(Game game) {}

        /// <summary>
        /// Get the board case image
        /// </summary>
        /// <returns>An image for the board case</returns>
        public virtual Image GetBoardCaseImage(Game game)
        {
            Image image = new Bitmap(BOARD_CASE_WIDTH, BOARD_CASE_HEIGHT);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Colors.CARD_BG_COLOR);
            }

            return image;
        }

        /// <summary>
        /// Force the images to be re-drawn
        /// </summary>
        public void Invalidate()
        {
            imageCache.Clear();
        }
    }
}