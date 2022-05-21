




using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
  internal class Dancer : AnimatedSpriteA
  {
    private bool visible_ = false;
    private Vector2 position_ = Vector2.Zero;
    private Vector2 velocity_ = new Vector2(400f, 0.0f);
    private Color color_;
    private SpriteEffects spriteEffects_ = SpriteEffects.None;

    public Dancer()
      : base(Global.pelvicTex)
    {
      this.SetAnimation(new Rectangle(0, 0, 178, 454), 2, 0.1724138f);
    }

    public void Update(float dt)
    {
      if (!this.visible_)
        return;
      this.position_ += this.velocity_ * dt;
      if (Math.Sign(this.velocity_.X) == 1 && (double) this.position_.X > (double) (1280 + this.frameInfo.Width / 2))
        this.position_.X -= (float) (1280 + this.frameInfo.Width);
      if (Math.Sign(this.velocity_.X) == -1 && (double) this.position_.X < (double) (-this.frameInfo.Width / 2))
        this.position_.X += (float) (1280 + this.frameInfo.Width);
      base.Update(dt);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.visible_)
        return;
      this.Draw(spriteBatch, this.position_, 0.0f, 1f, this.color_, this.spriteEffects_);
    }

    public void TurnOn(Vector2 position, int state, Color color)
    {
      this.visible_ = true;
      this.position_ = position;
      this.currentFrame = state;
      this.color_ = color;
      this.velocity_ = new Vector2(400f, 0.0f);
      this.spriteEffects_ = SpriteEffects.None;
    }

    public void ReverseDirection()
    {
      this.velocity_ = new Vector2(-400f, 0.0f);
      this.spriteEffects_ = SpriteEffects.FlipHorizontally;
    }

    public void TurnOff() => this.visible_ = false;
  }
}
