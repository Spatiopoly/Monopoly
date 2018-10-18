using Monopoly.Models;
using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Monopoly.Views
{
    class GameView : Panel
    {
        const int BORDER_MARGIN = 55;
        const int PLAYERS_POSITION = 100;
        const int SMALL_CASE_PERCENTAGE = 13; // Of the total board

        private Game _game;
        private Messages _messages = new Messages();
        private List<Pawn> _pawns = new List<Pawn>();

        public static readonly PointF[] playersPathPoints = {
            // Start
            new PointF(985, 880),
            new PointF(985, 980),
            new PointF(875, 980),

            // Bottom line
            new PointF(875, 942),
            new PointF(130, 942),

            // Prison
            new PointF(130, 985),
            new PointF(15, 985),
            new PointF(15, 870),

            // Left line
            new PointF(58, 870),

            // Top line
            new PointF(58, 70),

            // Right line
            new PointF(945, 70),
            new PointF(945, 880),
        };

        public Game Game
        {
            get => _game; set
            {
                _game = value;

                if (value == null)
                {
                    return;
                }

                // Listen to messages
                _game.Message += (Game game, string message) =>
                {
                    _messages.Add(message);
                };

                // Create pawns to display the players
                _pawns.Clear();
                foreach (Player player in Game.Players)
                {
                    _pawns.Add(new Pawn(player, _game));
                }
            }
        }

        public ColorProperty PrimaryColor { get; set; } = new ColorProperty(Color.Silver);

        /// <summary>
        /// Constructor
        /// </summary>
        public GameView()
        {
            DoubleBuffered = true;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);
        }

        /// <summary>
        /// Paint game view
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.Clear(Colors.GAMEVIEW_BG_COLOR);

            if (Game == null) // Avoid crash in Windows Forms Designer
            {
                return;
            }

            RectangleF viewSize = e.Graphics.VisibleClipBounds;
            float dimension = Math.Min(viewSize.Width, viewSize.Height) - 2 * BORDER_MARGIN;
            RectangleF boardPosition = new RectangleF((viewSize.Width - dimension) / 2, (viewSize.Height - dimension) / 2, dimension, dimension);
            e.Graphics.DrawImage(DrawBoard(), boardPosition);

            // Draw players
            RectangleF[] playersZones = {
                new RectangleF(0, viewSize.Bottom - BORDER_MARGIN, boardPosition.Right, BORDER_MARGIN),
                new RectangleF(viewSize.Right - BORDER_MARGIN, boardPosition.Top, BORDER_MARGIN, boardPosition.Bottom),
                new RectangleF(boardPosition.Left, 0, boardPosition.Right, BORDER_MARGIN),
                new RectangleF(0, 0, BORDER_MARGIN, boardPosition.Bottom),
            };

            RotateFlipType[] playersZonesRotations = new RotateFlipType[] {
                RotateFlipType.RotateNoneFlipNone,
                RotateFlipType.Rotate270FlipNone,
                RotateFlipType.Rotate180FlipNone,
                RotateFlipType.Rotate90FlipNone,
            };

            for (int playerZoneIndex = 0; playerZoneIndex < playersZones.Length; playerZoneIndex++)
            {
                if (playerZoneIndex >= Game.Players.Count)
                {
                    continue;
                }

                RectangleF playerZone = playersZones[playerZoneIndex];

                bool isHorizontalZone = playerZone == playersZones[0] || playerZone == playersZones[2];
                int width = (int)Math.Floor(isHorizontalZone ? playerZone.Width : playerZone.Height);

                Bitmap bitmap = new Bitmap(Math.Abs(width), BORDER_MARGIN);
                DrawPlayerZone(bitmap, Game.Players[playerZoneIndex]);
                bitmap.RotateFlip(playersZonesRotations[playerZoneIndex]);

                e.Graphics.DrawImage(bitmap, playerZone);
            }

            // Draw money indicator
            DrawMoney(e.Graphics);

            _messages.Draw(e.Graphics);
        }

        /// <summary>
        /// Draw the board and its contents
        /// </summary>
        /// <param name="g"></param>
        /// <param name="boardPosition"></param>
        private Image DrawBoard()
        {
            Image img = new Bitmap(1000, 1000);

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF boardPosition = g.VisibleClipBounds;
                g.SmoothingMode = SmoothingMode.HighQuality;

                float smallCaseRatio = SMALL_CASE_PERCENTAGE / 100.0F;
                float boardSize = boardPosition.Width; // width = height
                float bigCaseSize = boardPosition.Width * smallCaseRatio; // width = height

                Pen borderPen = new Pen(Colors.CASE_BORDER_COLOR, boardSize / 500);

                g.FillRectangle(Brushes.White, boardPosition);
                g.DrawRectangle(borderPen, boardPosition);

                // Draw the center
                var centerRectangle = new RectangleF(boardPosition.X + bigCaseSize, boardPosition.Y + bigCaseSize, boardSize - 2 * bigCaseSize, boardSize - 2 * bigCaseSize);
                g.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.White)), centerRectangle);
                g.DrawImage(Properties.Resources.Center, centerRectangle);

                // Draw the 4 sides of the board
                RectangleF[] bigCasesPositions = {
                    new RectangleF(boardPosition.X + boardSize - bigCaseSize, boardPosition.Y + boardSize - bigCaseSize, bigCaseSize, bigCaseSize),
                    new RectangleF(boardPosition.X, boardPosition.Y + boardSize - bigCaseSize, bigCaseSize, bigCaseSize),
                    new RectangleF(boardPosition.X, boardPosition.Y, bigCaseSize, bigCaseSize),
                    new RectangleF(boardPosition.X + boardSize - bigCaseSize, boardPosition.Y, bigCaseSize, bigCaseSize),
                };

                RectangleF[] smallCasesRectangles = {
                    new RectangleF(boardPosition.X + bigCaseSize, boardPosition.Y + boardSize - bigCaseSize , boardSize - 2 * (boardSize * smallCaseRatio), boardSize * smallCaseRatio),
                    new RectangleF(boardPosition.X, boardPosition.Y + bigCaseSize, boardSize * smallCaseRatio, boardSize - 2 * (boardSize * smallCaseRatio)),
                    new RectangleF(boardPosition.X + bigCaseSize, boardPosition.Y, boardSize - 2 * (boardSize * smallCaseRatio), boardSize * smallCaseRatio),
                    new RectangleF(boardPosition.X + boardSize - bigCaseSize, boardPosition.Y + bigCaseSize, boardSize * smallCaseRatio, boardSize - 2 * (boardSize * smallCaseRatio)),
                };

                Tuple<PointF, PointF>[] smallCasesLines = { // Where to draw the property rings
                    new Tuple<PointF, PointF>(smallCasesRectangles[0].TopRight(), smallCasesRectangles[0].TopLeft()),
                    new Tuple<PointF, PointF>(smallCasesRectangles[1].BottomRight(), smallCasesRectangles[1].TopRight()),
                    new Tuple<PointF, PointF>(smallCasesRectangles[2].BottomLeft(), smallCasesRectangles[2].BottomRight()),
                    new Tuple<PointF, PointF>(smallCasesRectangles[3].TopLeft(), smallCasesRectangles[3].BottomLeft()),
                };

                for (int sideIndex = 0; sideIndex < 4; sideIndex++)
                {
                    // Draw the big case
                    RectangleF bigCasePosition = bigCasesPositions[sideIndex];
                    Image bigCaseImage = Game.Cases[sideIndex * 10].GetBoardCaseImage(Game);
                    g.DrawImage(bigCaseImage, bigCasePosition);
                    g.DrawRectangle(borderPen, bigCasePosition);

                    /*
                     * Draw the small cases
                     */
                    List<AbstractCase> smallCases = Game.Cases.Skip(sideIndex * 10 + 1).Take(9).ToList();

                    // Property rings
                    Tuple<PointF, PointF> line = smallCasesLines[sideIndex];
                    SizeF caseSideSize = new SizeF(
                        (line.Item2.X - line.Item1.X) / smallCases.Count,
                        (line.Item2.Y - line.Item1.Y) / smallCases.Count
                    );

                    for (int i = 0; i < smallCases.Count; i++)
                    {
                        // Draw only owned properties
                        AbstractCase smallCase = smallCases[i];
                        if (!(smallCase is PropertyCase) || (smallCase as PropertyCase).Owner == null)
                            continue;

                        PointF caseSideCenter = new PointF(
                            line.Item1.X + (i + 0.5F) * caseSideSize.Width,
                            line.Item1.Y + (i + 0.5F) * caseSideSize.Height
                        );

                        const int PROPERTY_RING_RADIUS = 32;

                        Pen ringPen = new Pen((smallCase as PropertyCase).Owner.Color.GetColor(), 5);
                        g.DrawEllipse(ringPen, new RectangleF(caseSideCenter.X - PROPERTY_RING_RADIUS / 2, caseSideCenter.Y - PROPERTY_RING_RADIUS / 2, PROPERTY_RING_RADIUS, PROPERTY_RING_RADIUS));

                    }

                    // Card images
                    if (sideIndex != 2)
                    {
                        smallCases.Reverse();
                    }

                    Image sideContent = DrawSideCases(smallCases);

                    RotateFlipType rotation = (new RotateFlipType[] {
                        RotateFlipType.RotateNoneFlipNone,
                        RotateFlipType.Rotate90FlipNone,
                        RotateFlipType.RotateNoneFlipNone,
                        RotateFlipType.Rotate270FlipNone,
                    })[sideIndex];
                    sideContent.RotateFlip(rotation);

                    RectangleF casesContainer = smallCasesRectangles[sideIndex];
                    g.DrawImage(sideContent, casesContainer);

                    // Draw the small cases border
                    SizeF caseSize = casesContainer.Size;

                    if (sideIndex % 2 == 0) // Horizontal
                    {
                        caseSize.Width /= smallCases.Count;
                    }
                    else // Vertical
                    {
                        caseSize.Height /= smallCases.Count;
                    }

                    for (int caseIndex = 0; caseIndex < smallCases.Count; caseIndex++)
                    {
                        PointF caseLocation = casesContainer.TopLeft();

                        if (sideIndex % 2 == 0) // Horizontal
                        {
                            caseLocation += new SizeF(caseSize.Width * caseIndex, 0);
                        }
                        else // Vertical
                        {
                            caseLocation += new SizeF(0, caseSize.Height * caseIndex);
                        }

                        g.DrawRectangle(borderPen, new RectangleF(caseLocation, caseSize));
                    }
                }

                // Draw the pawns
                DrawPawns(g);
            }

            return img;
        }

        /// <summary>
        /// Draw the cases on a side
        /// </summary>
        /// <param name="cases"></param>
        /// <returns>Image of the side</returns>
        private Image DrawSideCases(List<AbstractCase> cases)
        {
            Bitmap image = new Bitmap(1110, 195);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Colors.CARD_BG_COLOR);

                SizeF caseSize = g.VisibleClipBounds.Size;
                caseSize.Width /= cases.Count;
                int caseIndex = 0;
                foreach (AbstractCase c in cases)
                {
                    PointF casePosition = new PointF(caseSize.Width * caseIndex, 0);
                    g.DrawImage(c.GetBoardCaseImage(Game), new RectangleF(casePosition, caseSize));
                    caseIndex++;
                }
            }

            return image;
        }

        /// <summary>
        /// Draw a player's zone in an image
        /// </summary>
        /// <param name="img"></param>
        private void DrawPlayerZone(Bitmap img, Player player)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF zoneSize = g.VisibleClipBounds;

                g.Clear(Colors.GAMEVIEW_BG_COLOR);

                // Draw the avatar
                var avatarRectangle = new RectangleF(zoneSize.Width - zoneSize.Height, zoneSize.Bottom - zoneSize.Height + 15, zoneSize.Height - 15, zoneSize.Height - 15);
                avatarRectangle.Inflate(10, 10);
                g.DrawImage(player.Color.GetImage(), avatarRectangle);

                // Draw the properties
                List<PropertyCase> properties = player.GetProperties(Game);
                if (properties.Count > 0)
                {
                    SizeF cardSize = new SizeF(PropertyCase.PROPERTY_CARD_WIDTH / 3F, PropertyCase.PROPERTY_CARD_HEIGHT / 3F);

                    int cardMargin = 5;
                    if ((cardSize.Width + cardMargin) * properties.Count - cardMargin > zoneSize.Width - avatarRectangle.Width)
                    {
                        // The zone is too small to make all the cards fit.
                        // Setting a new margin (probably negative) to make the cards overlap.
                        cardMargin = (int)(zoneSize.Width - properties.Count * cardSize.Width) / properties.Count;
                    }

                    for (var i = 0; i < properties.Count; i++)
                    {
                        var cardLocation = new PointF(avatarRectangle.Left - cardSize.Width - (cardSize.Width + cardMargin) * i, zoneSize.Bottom - cardSize.Height);

                        Image image = properties[i].GetPropertyCardImage(1);
                        var cardRectangle = new RectangleF(cardLocation, cardSize);
                        g.DrawImage(image, cardRectangle);
                        g.DrawRectangle(Pens.Black, cardRectangle);
                    }
                }
            }
        }

        /// <summary>
        /// Draw the pawns on the board
        /// </summary>
        /// <param name="g">Graphics object</param>
        private void DrawPawns(Graphics g)
        {
            RectangleF boardPosition = g.VisibleClipBounds;

            foreach (Pawn p in _pawns)
            {
                p.Draw(g);
            }
        }

        /// <summary>
        /// Get the position of a case on the players path
        /// </summary>
        /// <param name="caseIndex">Index of the case</param>
        /// <returns>Length to travel on the players path to arrive at the case</returns>
        public static int GetCaseOnPlayersPath(int caseIndex)
        {
            int[] casePositions = {
                190, 334, 416, 498, 580, 662, 744, 826, 908, 990, 1260,
                1391, 1473, 1555, 1637, 1719, 1801, 1883, 1965, 2047, 2178,
                2263, 2345, 2427, 2509, 2591, 2673, 2755, 2837, 2919, 2993,
                3139, 3221, 3303, 3385, 3467, 3549, 3631, 3713, 3795, 3877,
            };

            return casePositions[caseIndex % casePositions.Length];
        }

        /// <summary>
        /// Travel some distance on the player's path (from the
        /// start point) and return the arrival point.
        /// </summary>
        /// <param name="distance">The distance to travel</param>
        /// <returns>The arrival point</returns>
        public static PointF GetPointOnPlayersPath(float distance)
        {
            int cornerIndex = 0;

            while (distance > 0)
            {
                PointF currentPoint = playersPathPoints[cornerIndex];
                PointF nextPoint = playersPathPoints[cornerIndex == playersPathPoints.Length - 1 ? 0 : cornerIndex + 1];
                int pointsDistance = (int)Math.Sqrt(
                    Math.Pow(nextPoint.X - currentPoint.X, 2) +
                    Math.Pow(nextPoint.Y - currentPoint.Y, 2)
                );

                distance -= pointsDistance;

                cornerIndex += 1;
                if (cornerIndex >= playersPathPoints.Length)
                {
                    cornerIndex = 0;
                }
            }

            PointF corner = playersPathPoints[cornerIndex];
            PointF previousCorner = playersPathPoints[cornerIndex == 0 ? playersPathPoints.Length - 1 : cornerIndex - 1];
            int lastDistance = (int)Math.Sqrt(
                Math.Pow(corner.X - previousCorner.X, 2) +
                Math.Pow(corner.Y - previousCorner.Y, 2)
            );

            double progressOnLine = 1 - (distance + lastDistance) * 1.0 / lastDistance;

            return new PointF()
            {
                X = (float)(corner.X * (1 - progressOnLine) + previousCorner.X * progressOnLine),
                Y = (float)(corner.Y * (1 - progressOnLine) + previousCorner.Y * progressOnLine),
            };
        }

        /// <summary>
        /// Draw the money indicator in the provided bitmap
        /// </summary>
        /// <param name="g"></param>
        private void DrawMoney(Graphics g)
        {
            RectangleF viewSize = g.VisibleClipBounds;
            Player player = Game.CurrentPlayer;

            const int MONEY_BORDER_RADIUS = 10;
            const int MONEY_WIDTH = 150;
            const int MONEY_HEIGHT = 40;

            Brush moneyBrush = new SolidBrush(PrimaryColor.DisplayedValue);

            // Draw the background with a border radius on the bottom left corner
            RectangleF innerRectangle = new RectangleF(viewSize.Right - MONEY_WIDTH + MONEY_BORDER_RADIUS, -1, MONEY_WIDTH - MONEY_BORDER_RADIUS, MONEY_HEIGHT - MONEY_BORDER_RADIUS);
            g.FillRectangle(moneyBrush, innerRectangle);
            g.FillRectangle(moneyBrush, new RectangleF(innerRectangle.Left - MONEY_BORDER_RADIUS + 1, innerRectangle.Top, MONEY_BORDER_RADIUS, MONEY_HEIGHT - MONEY_BORDER_RADIUS));
            g.FillRectangle(moneyBrush, new RectangleF(innerRectangle.Left, innerRectangle.Bottom - 1, innerRectangle.Width, MONEY_BORDER_RADIUS));
            g.FillPie(moneyBrush, viewSize.Right - MONEY_WIDTH + 1, innerRectangle.Bottom - MONEY_BORDER_RADIUS - 1, MONEY_BORDER_RADIUS * 2, MONEY_BORDER_RADIUS * 2, 90, 90);

            g.DrawImage(Properties.Resources.FlouzzBag, innerRectangle.Left, 7, 19, 26);
            g.DrawString(player.Wealth.ToString("N0"), new Font("Arial Bold", 14), Brushes.White, innerRectangle.Left + 25, 8);
        }
    }
}
