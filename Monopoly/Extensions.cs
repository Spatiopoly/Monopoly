using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Monopoly
{
    public static class Extensions
    {
        /// <summary>
        /// Draw a rectangle from a RectangleF
        /// </summary>
        /// <param name="g">Graphics object</param>
        /// <param name="pen">The pen to draw with</param>
        /// <param name="rectangle">The RectangleF</param>
        public static void DrawRectangle(this Graphics g, Pen pen, RectangleF rectangle)
        {
            g.DrawRectangles(pen, new RectangleF[] { rectangle });
        }

        public static PointF TopLeft(this RectangleF rectangle)
            => new PointF(rectangle.X, rectangle.Y);

        public static PointF BottomLeft(this RectangleF rectangle)
            => new PointF(rectangle.X, rectangle.Y + rectangle.Height);

        public static PointF TopRight(this RectangleF rectangle)
            => new PointF(rectangle.X + rectangle.Width, rectangle.Y);

        public static PointF BottomRight(this RectangleF rectangle)
            => new PointF(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);

        /// <summary>
        /// Darken a color by X%
        /// </summary>
        /// <param name="color">The color to darken</param>
        /// <param name="percent">Strength of the effect</param>
        /// <returns>The darkened color</returns>
        public static Color Darken(this Color color, int percent)
        {
            return Color.FromArgb(
                (int)Math.Round((100 - percent) / 100.0 * color.R),
                (int)Math.Round((100 - percent) / 100.0 * color.G),
                (int)Math.Round((100 - percent) / 100.0 * color.B)
            );
        }
    }
}
