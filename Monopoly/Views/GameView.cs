﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Models;
using Monopoly.Models.Cases;
using System.Drawing.Drawing2D;

namespace Monopoly.Views
{
    class GameView : Panel
    {
        const int BORDER_MARGIN = 75;
        const int SMALL_CASE_PERCENTAGE = 13; // Of the total board

        private Color backgroundColor = Color.FromArgb(17, 4, 58);

        Timer timer = new Timer();

        public Game Game { get; set; }

        public GameView()
        {
            DoubleBuffered = true;

            InitializeComponent();

            this.timer.Interval = 12;
            this.timer.Enabled = true;
            this.timer.Tick += Timer_Tick;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.LightGray);

            if (Game == null) // Avoid crash in Windows Forms Designer
                return;

            RectangleF size = e.Graphics.VisibleClipBounds;
            float dimension = Math.Min(size.Width, size.Height) - 2 * BORDER_MARGIN;
            RectangleF boardPosition = new RectangleF((size.Width - dimension) / 2, (size.Height - dimension) / 2, dimension, dimension);

            DrawBoard(e.Graphics, boardPosition);
        }

        private void DrawBoard(Graphics g, RectangleF boardPosition)
        {
            float smallCaseRatio = SMALL_CASE_PERCENTAGE / 100.0F;
            float boardSize = boardPosition.Width; // width = height
            float bigCaseSize = boardPosition.Width * smallCaseRatio; // width = height

            Pen borderPen = new Pen(Color.FromArgb(30, 14, 81), boardSize / 500);

            g.FillRectangle(new SolidBrush(backgroundColor), boardPosition);
            g.DrawRectangle(borderPen, boardPosition);

            // Draw the center
            RectangleF centerPosition = new RectangleF(boardPosition.X + bigCaseSize, boardPosition.Y + bigCaseSize, boardSize - 2 * bigCaseSize, boardSize - 2 * bigCaseSize);
            g.DrawImage(Properties.Resources.Windows_XP_wallpaper_2, centerPosition);

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

            for (int sideIndex = 0; sideIndex < 4; sideIndex++)
            {
                // Draw the big case
                RectangleF bigCasePosition = bigCasesPositions[sideIndex];
                Image bigCaseImage = (new Image[] {
                    Properties.Resources.Go,
                    Properties.Resources.Prison,
                    Properties.Resources.Windows_XP_wallpaper_2,
                    Properties.Resources.Windows_XP_wallpaper_2,
                })[sideIndex];
                g.DrawImage(bigCaseImage, bigCasePosition);
                g.DrawRectangle(borderPen, bigCasePosition);

                // Draw the small cases
                RectangleF casesContainer = smallCasesRectangles[sideIndex];

                List<AbstractCase> smallCases = Game.Cases.Skip(sideIndex * 10 + 1).Take(9).ToList();

                if (sideIndex != 2)
                    smallCases.Reverse();

                Image sideContent = DrawSideCases(smallCases);

                RotateFlipType rotation = (new RotateFlipType[] {
                    RotateFlipType.RotateNoneFlipNone,
                    RotateFlipType.Rotate90FlipNone,
                    RotateFlipType.RotateNoneFlipNone,
                    RotateFlipType.Rotate270FlipNone,
                })[sideIndex];
                sideContent.RotateFlip(rotation);

                g.DrawImage(sideContent, casesContainer);

                // Draw the small cases border
                SizeF caseSize = casesContainer.Size;

                if (sideIndex % 2 == 0) // Horizontal
                    caseSize.Width /= smallCases.Count;
                else // Vertical
                    caseSize.Height /= smallCases.Count;

                for (int caseIndex = 0; caseIndex < smallCases.Count; caseIndex++)
                {
                    PointF caseLocation = casesContainer.TopLeft();

                    if (sideIndex % 2 == 0) // Horizontal
                        caseLocation += new SizeF(caseSize.Width * caseIndex, 0);
                    else // Vertical
                        caseLocation += new SizeF(0, caseSize.Height * caseIndex);

                    g.DrawRectangle(borderPen, new RectangleF(caseLocation, caseSize));
                }

            }
        }

        private Image DrawSideCases(List<AbstractCase> cases)
        {
            Bitmap image = new Bitmap(1110, 195);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(backgroundColor);

                SizeF caseSize = g.VisibleClipBounds.Size;
                caseSize.Width /= cases.Count;
                int caseIndex = 0;
                foreach(AbstractCase c in cases)
                {
                    PointF casePosition = new PointF(caseSize.Width * caseIndex, 0);
                    DrawSmallCase(g, new RectangleF(casePosition, caseSize), c);
                    caseIndex++;
                }
            }

            return image;
        }

        private void DrawSmallCase(Graphics g, RectangleF rectangle, AbstractCase c)
        {

            if (c is StreetProperty)
            {
                StreetProperty street = c as StreetProperty;

                // Gradient top
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(0, 40),
                    street.Color,
                    street.Color.Darken(30)
                );

                g.FillRectangle(headerBrush, rectangle.X, rectangle.Y, rectangle.Width, 40);

                string name = street.Name;
                int spaceIndex = name.LastIndexOf(' ');
                if (spaceIndex != -1)
                {
                    char[] n = name.ToCharArray();
                    n[spaceIndex] = '\n';
                    name = new string(n);
                }

                g.DrawString(name, new Font("Verdana", 12), Brushes.White, new PointF(rectangle.X, 50));

                g.DrawString($"Prix : {street.Price}", new Font("Verdana", 16), Brushes.White, new PointF(rectangle.X + 5, 165));
            }

        }
    }
}