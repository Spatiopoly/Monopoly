﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Monopoly.Models.Cases
{
    class StreetProperty : PropertyCase
    {
        public int BuildingCount { get; set; } = 0;

        public int BuildingPrice { get; set; }

        public PropertyColor Group { get; private set; }

        public Color Color
        {
            get
            {
                switch (Group)
                {
                    case PropertyColor.DarkPurple:
                        return Color.DarkMagenta;
                    case PropertyColor.LightBlue:
                        return Color.FromArgb(135, 205, 222);
                    case PropertyColor.Pink:
                        return Color.Pink;
                    case PropertyColor.Orange:
                        return Color.Orange;
                    case PropertyColor.Red:
                        return Color.Red;
                    case PropertyColor.Yellow:
                        return Color.FromArgb(255, 204, 0);
                    case PropertyColor.Green:
                        return Color.Green;
                    case PropertyColor.DarkBlue:
                        return Color.FromArgb(0, 0, 212);
                }

                return Color.Black;
            }
        }

        public int[] Rents { get; private set; }

        /// <summary>
        /// Create a new street property
        /// </summary>
        /// <param name="color">Property group</param>
        /// <param name="name">Street name</param>
        /// <param name="price">Property buy price (2x mortgage)</param>
        /// <param name="buildingPrice">Building price (per unit)</param>
        /// <param name="rents">Rents (index = buildings count)</param>
        public StreetProperty(PropertyColor group, string name, int price, int buildingPrice, int[] rents) : base(name, price)
        {
            Group = group;

            if (rents.Length != 6)
            {
                throw new ArgumentException("Properties should have 6 rent prices : no house, 1 house, 2 houses, 3 houses, 4 houses, 1 hostel");
            }

            for (int i = 1; i < rents.Length; i++)
            {
                if (rents[i] < rents[i - 1])
                {
                    throw new ArgumentException("Property prices increase incorrect");
                }
            }

            Rents = rents;

            BuildingPrice = buildingPrice;
        }

        public override Image GetBoardCaseImage()
        {
            //@TODO gérer le cache avec les buildings
            if (imageCache.ContainsKey("board-case") && BuildingCount == -1)
                return imageCache["board-case"];

            Image img = base.GetBoardCaseImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;

                // Gradient top
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(0, 40),
                    Color,
                    Color.Darken(30)
                );

                g.FillRectangle(headerBrush, rectangle.X, rectangle.Y, rectangle.Width, 40);

                string name = Name;
                int spaceIndex = name.LastIndexOf(' ');
                if (spaceIndex != -1)
                {
                    char[] n = name.ToCharArray();
                    n[spaceIndex] = '\n';
                    name = new string(n);
                }

                g.DrawString(name, new Font("Arial", 12), Brushes.White, new PointF(rectangle.X + 5, 50));

                g.DrawString("PRIX", new Font("Arial Bold", 12, FontStyle.Bold), Brushes.White, new PointF(rectangle.X + 10, 135));

                g.DrawImage(Properties.Resources.Flouzz, new RectangleF(rectangle.X + 10, 160, 24, 24));
                g.DrawString(this.BuildingPrice.ToString(), new Font("Arial", 24), Brushes.White, new PointF(rectangle.X + 34, 155));

                if (BuildingCount == 1)
                {
                    g.DrawImage(Properties.Resources.property_one_house, new RectangleF(rectangle.X, 0, rectangle.Width, 40));
                }
                else if (BuildingCount == 2)
                {
                    g.DrawImage(Properties.Resources.property_two_house, new RectangleF(rectangle.X, 0, rectangle.Width, 40));
                }
                else if (BuildingCount == 3)
                {
                    g.DrawImage(Properties.Resources.property_three_house, new RectangleF(rectangle.X, 0, rectangle.Width, 40));
                }
                else if (BuildingCount == 4)
                {
                    g.DrawImage(Properties.Resources.property_four_house, new RectangleF(rectangle.X, 0, rectangle.Width, 40));
                }
                else if (BuildingCount == 5)
                {
                    g.DrawImage(Properties.Resources.property_hotel, new RectangleF(rectangle.X, 0, rectangle.Width, 40));
                }
            }

            imageCache["board-case"] = img;

            return img;
        }

        public override Image GetPropertyCardImage(int scale)
        {
            if (imageCache.ContainsKey($"property-case-{scale}x"))
                return imageCache[$"property-case-{scale}x"];

            Image img = base.GetPropertyCardImage(scale);

            using (Graphics g = Graphics.FromImage(img))
            {
                RectangleF rectangle = g.VisibleClipBounds;

                // Gradient top
                int headerHeight = 35 * scale;
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(0, headerHeight),
                    Color.Darken(30),
                    Color.Darken(60)
                );

                g.FillRectangle(headerBrush, rectangle.X, rectangle.Y, rectangle.Width, headerHeight);

                string name = Name;
                int spaceIndex = name.LastIndexOf(' ');
                if (spaceIndex != -1)
                {
                    char[] n = name.ToCharArray();
                    n[spaceIndex] = '\n';
                    name = new string(n);
                }

                g.DrawString(name, new Font("Arial", 10 * scale), Brushes.White, new PointF(2.5F * scale, 2.5F * scale));

                // Rent
                int y = 25 * scale;
                int height = 12 * scale;
                DrawPrice(g, scale, y += height, "Loyer", Rents[0]);
                DrawPrice(g, scale, y += height, "Avec 1 maison", Rents[1]);
                DrawPrice(g, scale, y += height, "Avec 2 maisons", Rents[2]);
                DrawPrice(g, scale, y += height, "Avec 3 maisons", Rents[3]);
                DrawPrice(g, scale, y += height, "Avec 4 maisons", Rents[4]);
                DrawPrice(g, scale, y += height, "Hôtel", Rents[5]);

                DrawPrice(g, scale, y += 17 * scale, "Hypothèque", Price / 2);

                DrawPrice(g, scale, y += 17 * scale, "Bâtiment", BuildingPrice);
            }

            imageCache[$"property-case-{scale}x"] = img;
            return img;
        }

        public override int GetRent(Game game)
        {
            int rent = 0;

            rent = Rents[BuildingCount];

            return rent;
        }
    }
}
