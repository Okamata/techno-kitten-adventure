





using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class ExplosionManager
  {
    private bool on_ = false;
    private float explosionTimer_ = 0.0f;
    private int explosionCounter_ = 0;
    private Explosion[] explosions_ = new Explosion[20];

    public ExplosionManager()
    {
      for (int index = 0; index < this.explosions_.Length; ++index)
        this.explosions_[index] = new Explosion();
    }

    public void Update(float dt)
    {
      if (this.on_)
      {
        this.explosionTimer_ += dt;
        if ((double) this.explosionTimer_ > (double) Global.BPM / 4.0)
        {
          ++this.explosionCounter_;
          this.explosionTimer_ -= Global.BPM / 4f;
          if (this.explosionCounter_ < 4)
          {
            int num = 0;
            foreach (Explosion explosion in this.explosions_)
            {
              if (!explosion.Visible)
              {
                explosion.Explode();
                ++num;
                if (num > 6)
                  break;
              }
            }
          }
          else if (this.explosionCounter_ == 8)
          {
            this.explosionCounter_ = 0;
            int num = 0;
            foreach (Explosion explosion in this.explosions_)
            {
              if (!explosion.Visible)
              {
                explosion.Explode();
                ++num;
                if (num > 6)
                  break;
              }
            }
          }
        }
      }
      foreach (Explosion explosion in this.explosions_)
        explosion.Update(dt);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      foreach (Explosion explosion in this.explosions_)
        explosion.Draw(spriteBatch);
    }

    public void TurnOn()
    {
      this.on_ = true;
      this.explosionTimer_ = 0.0f;
      this.explosionCounter_ = 0;
      int num = 0;
      foreach (Explosion explosion in this.explosions_)
      {
        if (!explosion.Visible)
        {
          explosion.Explode();
          ++num;
          if (num > 6)
            break;
        }
      }
    }

    public void TurnOff() => this.on_ = false;
  }
}
