﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
    public class AnimatedSpriteA
    {
        private Texture2D texture;
        protected Rectangle frameInfo;
        protected int currentFrame;
        private int numFrames;
        private float frameTimer;
        private float frameTime;

        public AnimatedSpriteA(Texture2D Texture) => this.texture = Texture;

        public void SetAnimation(Rectangle frameInfo_, int numFrames_, float frameTime_)
        {
            this.frameInfo = frameInfo_;
            this.currentFrame = 0;
            this.numFrames = numFrames_;
            this.frameTimer = 0.0f;
            this.frameTime = frameTime_;
        }

        public bool Update(float dt)
        {
            this.frameTimer += dt;
            if ((double)this.frameTimer > (double)this.frameTime)
            {
                this.frameTimer -= this.frameTime;
                this.currentFrame = (this.currentFrame + 1) % this.numFrames;
                if (this.currentFrame == 0)
                    return true;
            }
            return false;
        }

        public void Draw(
          SpriteBatch spriteBatch,
          Vector2 position,
          float rotation,
          float scale,
          Color color,
          SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(this.texture, position, new Rectangle?(new Rectangle(this.frameInfo.X + this.currentFrame * this.frameInfo.Width, this.frameInfo.Y, this.frameInfo.Width, this.frameInfo.Height)), color, rotation, new Vector2((float)(this.frameInfo.Width / 2), (float)(this.frameInfo.Height / 2)), scale, spriteEffects, 1f);
        }
    }
}
