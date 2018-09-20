using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Monopoly.Models;

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

        /// <summary>
        /// Lighten a color by X%
        /// </summary>
        /// <param name="color">The color to lighten</param>
        /// <param name="percent">Strength of the effect</param>
        /// <returns>The lightened color</returns>
        public static Color Lighten(this Color color, int percent)
        {
            return Color.FromArgb(
                (int)Math.Round((100 + percent) / 100.0 * color.R),
                (int)Math.Round((100 + percent) / 100.0 * color.G),
                (int)Math.Round((100 + percent) / 100.0 * color.B)
            );
        }

        /// <summary>
        /// Get the color of a player
        /// </summary>
        /// <param name="playerColor"></param>
        /// <returns></returns>
        public static Color GetColor(this Player.PlayerColor playerColor)
        {
            switch (playerColor)
            {
                case Player.PlayerColor.Purple:
                    return Color.FromArgb(159, 0, 181);
                case Player.PlayerColor.Yellow:
                    return Color.FromArgb(255, 200, 0);
                case Player.PlayerColor.Green:
                    return Color.FromArgb(0, 137, 0);
                case Player.PlayerColor.Red:
                    return Color.FromArgb(244, 27, 0);
                case Player.PlayerColor.Blue:
                    return Color.FromArgb(25, 0, 162);
            }

            return Color.Black;
        }

        /// <summary>
        /// Get the image of a player
        /// </summary>
        /// <param name="playerColor"></param>
        /// <returns></returns>
        public static Image GetImage(this Player.PlayerColor playerColor)
        {
            switch (playerColor)
            {
                case Player.PlayerColor.Purple:
                    return Properties.Resources.PlayerPurple;
                case Player.PlayerColor.Yellow:
                    return Properties.Resources.PlayerYellow;
                case Player.PlayerColor.Green:
                    return Properties.Resources.PlayerGreen;
                case Player.PlayerColor.Red:
                    return Properties.Resources.PlayerRed;
                case Player.PlayerColor.Blue:
                    return Properties.Resources.PlayerBlue;
            }

            return Properties.Resources.Center;
        }

        /// <summary>
        /// Get the default name of a player color
        /// </summary>
        /// <param name="playerColor"></param>
        /// <returns></returns>
        public static string GetDefaultName(this Player.PlayerColor playerColor)
        {
            switch (playerColor)
            {
                case Player.PlayerColor.Purple:
                    return "Beerus";
                case Player.PlayerColor.Yellow:
                    return "SpaceCore";
                case Player.PlayerColor.Green:
                    return "Cayde";
                case Player.PlayerColor.Red:
                    return "Deadpool";
                case Player.PlayerColor.Blue:
                    return "Stitch";
            }

            return "Player";
        }

    }
}
