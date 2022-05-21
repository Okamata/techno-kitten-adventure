





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class SpreadLaser
  {
    private bool active_;
    private Vector2 position_;
    private float scaleX_;
    private float minScaleX_;
    private float maxScaleX_;
    private float scaleXRate_;
    private Color color_;
    private int frameIndex_;
    private int numFrames_;
    private float frameTimer_;
    private float frameTime_;

    public SpreadLaser()
    {
      this.active_ = false;
      this.position_ = new Vector2(640f, 600f);
      this.color_ = Color.Red;
      this.scaleX_ = 0.6f;
      this.minScaleX_ = 0.0f;
      this.maxScaleX_ = 1f;
      this.scaleXRate_ = 2f;
      this.frameIndex_ = 0;
      this.numFrames_ = 2;
      this.frameTimer_ = 0.0f;
      this.frameTime_ = 100f;
    }

    public void Update(float dt)
    {
      if (!this.active_)
        return;
      this.frameTimer_ += dt;
      if ((double) this.frameTimer_ > (double) this.frameTime_)
      {
        this.frameIndex_ = (this.frameIndex_ + 1) % this.numFrames_;
        this.frameTimer_ = 0.0f;
      }
      this.scaleX_ += this.scaleXRate_ * dt;
      if ((double) this.scaleX_ > (double) this.maxScaleX_)
        this.scaleX_ = this.minScaleX_;
      if ((double) this.scaleX_ < (double) this.minScaleX_)
        this.scaleX_ = this.minScaleX_;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    public void TurnOff() => this.active_ = false;
  }
}
