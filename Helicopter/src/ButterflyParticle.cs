using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
    public class ButterflyParticle
    {
        public bool active_;
        private bool attracted_;
        private Vector2 velocity_;
        private Vector2 position_;
        private float scale_;
        private float rotation_;
        private float rotationRate_;
        private int texIndex_;

        public void Reset(
          Vector2 position,
          Vector2 velocity,
          float scale,
          float rotationRate,
          bool attracted)
        {
            this.active_ = true;
            this.position_ = position;
            this.velocity_ = velocity;
            this.scale_ = scale;
            this.rotationRate_ = rotationRate;
            this.rotation_ = Global.RandomBetween(0.0f, 6.283185f);
            this.texIndex_ = Global.Random.Next(0, 6);
            this.attracted_ = attracted;
        }

        public void Update(float dt, Vector2 catPosition)
        {
            if (!this.active_)
                return;
            if (this.attracted_)
            {
                this.velocity_ = Vector2.Normalize(catPosition - this.position_) * 400f;
                this.position_ += this.velocity_ * dt;
                this.rotation_ += this.rotationRate_ * dt;
                if ((double)Vector2.Distance(this.position_, catPosition) < 5.0)
                    this.active_ = false;
            }
            else
            {
                this.position_ += this.velocity_ * dt;
                this.rotation_ += this.rotationRate_ * dt;
                if ((double)this.position_.X < 0.0 || (double)this.position_.X > 1280.0 || (double)this.position_.Y < 0.0 || (double)this.position_.Y > 720.0)
                    this.active_ = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.active_)
                return;
            spriteBatch.Draw(Global.butterflyParticles, this.position_, new Rectangle?(new Rectangle(15 * this.texIndex_, 0, 15, 17)), Color.White, this.rotation_, new Vector2(7.5f, 8.5f), this.scale_, SpriteEffects.None, 0.0f);
        }

        public void TurnOff() => this.active_ = false;
    }
}
