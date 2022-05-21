





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
  public class MenuItem
  {
    private Texture2D texture_;
    public Rectangle texRect_;
    private Vector2 position_;
    private Vector2 origin_;
    private float rotation_;
    private float minRotation_ = -1f * (float) Math.PI / 32f;
    private float maxRotation_ = (float) Math.PI / 32f;
    private float rotationRate_ = 3.141593f;

    public Rectangle CollisionRect => new Rectangle((int) ((double) this.position_.X - (double) this.origin_.X), (int) ((double) this.position_.Y - (double) this.origin_.Y), this.texRect_.Width, this.texRect_.Height);

    public MenuItem(Texture2D texture, Rectangle texRect, Vector2 position)
    {
      this.texture_ = texture;
      this.texRect_ = texRect;
      this.position_ = position;
      this.origin_ = new Vector2((float) (texRect.Width / 2), (float) (texRect.Height / 2));
    }

    public void Update(float dt, bool selected)
    {
      if (selected)
      {
        this.rotation_ += this.rotationRate_ * dt;
        if ((double) this.rotation_ > (double) this.maxRotation_)
        {
          this.rotation_ = this.maxRotation_;
          this.rotationRate_ = -this.rotationRate_;
        }
        if ((double) this.rotation_ >= (double) this.minRotation_)
          return;
        this.rotation_ = this.minRotation_;
        this.rotationRate_ = -this.rotationRate_;
      }
      else
        this.rotation_ = 0.0f;
    }

    public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(this.texture_, this.position_, new Rectangle?(this.texRect_), Color.White, this.rotation_, this.origin_, 1f, SpriteEffects.None, 0.0f);

    public void SetTexRect(Rectangle texRect)
    {
      this.texRect_ = texRect;
      this.origin_ = new Vector2((float) (texRect.Width / 2), (float) (texRect.Height / 2));
    }
  }
}
