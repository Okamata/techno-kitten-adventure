





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class ShineEffect
  {
    public bool visible_;
    private int textureIndex_;
    private Color color_;
    private Vector2 position_;
    private Vector2 origin_;
    private float scale_;
    private float scaleRate_;
    private float lifetime_;
    private float timeSinceStart_;
    private float alpha_;

    public ShineEffect() => this.origin_ = new Vector2(130f, 130f);

    public void Update(float dt)
    {
      this.scale_ += this.scaleRate_ * dt;
      this.timeSinceStart_ += dt;
      this.alpha_ = (float) (1.0 - (double) this.timeSinceStart_ / (double) this.lifetime_);
      if ((double) this.timeSinceStart_ <= (double) this.lifetime_)
        return;
      this.visible_ = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.visible_)
        return;
      spriteBatch.Draw(Global.shineShapes[this.textureIndex_], this.position_, new Rectangle?(), new Color(new Vector4(this.color_.ToVector3(), this.alpha_)), 0.0f, this.origin_, this.scale_, SpriteEffects.None, 0.0f);
    }

    public void TurnOn(
      Vector2 position,
      float startScale,
      float scaleRate,
      float lifetime,
      Color color,
      int textureIndex)
    {
      this.color_ = color;
      this.textureIndex_ = textureIndex;
      this.position_ = position;
      this.scale_ = startScale;
      this.scaleRate_ = scaleRate;
      this.lifetime_ = lifetime;
      this.timeSinceStart_ = 0.0f;
      this.visible_ = true;
    }

    public void Reset() => this.visible_ = false;
  }
}
