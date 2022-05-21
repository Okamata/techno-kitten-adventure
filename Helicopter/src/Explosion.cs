





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class Explosion : AnimatedSpriteA
  {
    private bool visible_ = false;
    private Vector2 position_ = Vector2.Zero;
    private float scale_ = 1f;
    private float rotation_ = 0.0f;

    public bool Visible => this.visible_;

    public Explosion()
      : base(Global.explosionTex)
    {
      this.SetAnimation(new Rectangle(0, 0, 300, 300), 11, 0.05f);
    }

    public void Update(float dt)
    {
      if (!this.visible_ || !base.Update(dt))
        return;
      this.visible_ = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.visible_)
        return;
      this.Draw(spriteBatch, this.position_, this.rotation_, this.scale_, Color.White, SpriteEffects.None);
    }

    public void Explode()
    {
      if (this.visible_)
        return;
      this.visible_ = true;
      this.position_ = new Vector2(Global.RandomBetween(128f, 1152f), Global.RandomBetween(72f, 648f));
      this.rotation_ = Global.RandomBetween(0.0f, 6.283185f);
      this.scale_ = Global.RandomBetween(0.5f, 1f);
      this.currentFrame = 0;
    }
  }
}
