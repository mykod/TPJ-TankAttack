﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPJ_TankAttack
{
    class AnimatedSprite: Sprite
    {
        private int ncols,nrows;
        private Point currentFrame;
        private float animationInterval = 1f / 20f;
        private float animationTimer = 0f;
        

        public AnimatedSprite(ContentManager content, 
            string filename, int nrows, int ncols):
            base(content,filename)
        {
            this.ncols = ncols;
            this.nrows = nrows;
            this.pixelsize.X = this.pixelsize.X / ncols;
            this.pixelsize.Y = this.pixelsize.Y / nrows;
            this.size = new Vector2(1f, 
                (float)pixelsize.Y / (float)pixelsize.X);
            this.currentFrame = Point.Zero;



        }
        private void nextFrame()
        {
            if(currentFrame.X < ncols - 1)
            {
                currentFrame.X++;
            }
            else if(currentFrame.Y<nrows-1)
            {
                currentFrame.X = 0;
                currentFrame.Y++;
            }
            else
            {
                currentFrame = Point.Zero;
            }
        }

        public override void Update(GameTime gameTime)
        {
            animationTimer += 
                (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(animationTimer> animationInterval)
            {
                animationTimer = 0f;
                nextFrame();

            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
           
            source = new Rectangle((int)(currentFrame.X * pixelsize.X),
                (int)(currentFrame.Y * pixelsize.Y), (int)pixelsize.X,
                (int)pixelsize.Y);

            base.Draw(gameTime);
        }
    }
}
