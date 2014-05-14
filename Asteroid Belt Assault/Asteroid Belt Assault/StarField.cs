﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class StarField
    {
        private List<Sprite> stars = new List<Sprite>();
        private int screenWidth = 800;
        private int screenHeight = 600;
        private Random rand;
        private Color[] colors = { Color.Wheat, Color.Lime, 
                           Color.Cyan, Color.WhiteSmoke, 
                           Color.SlateGray };

        public StarField(
            int screenWidth,
            int screenHeight,
            int starCount,
            Vector2 starVelocity,
            Texture2D texture,
            Rectangle frameRectangle)
        {
            System.Threading.Thread.Sleep(15);
            this.rand = new Random(System.Environment.TickCount);
            


            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            for (int x = 0; x < starCount; x++)
            {
                stars.Add(new Sprite(
                    new Vector2(rand.Next(0, screenWidth),
                        rand.Next(0, screenHeight)),
                    texture,
                    frameRectangle,
                    starVelocity));
                Color starColor = colors[rand.Next(0, colors.Count())];
                starColor *= (float)(rand.Next(30, 80) / 100f); stars[stars.Count() - 1].TintColor = starColor;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite star in stars)
            {
                star.Update(gameTime);
                if (star.Location.Y > screenHeight)
                {
                    star.Location = new Vector2(
                        rand.Next(0, screenWidth), 0);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite star in stars)
            {
                star.Draw(spriteBatch);
            }
        }

    }
}
