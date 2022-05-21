





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class LyricEffect
  {
    private bool[] actives_ = new bool[3];
    private Vector2[] positions_ = new Vector2[3];
    private float[] lyricTimes_ = new float[3];
    private float[] lyricTimers_ = new float[3];
    private float[] rotations_ = new float[3];
    private float rotationRate_;
    private Rectangle[] lyricRectangles_ = new Rectangle[3]
    {
      new Rectangle(0, 0, 179, 153),
      new Rectangle(179, 0, 164, 153),
      new Rectangle(343, 0, 179, 153)
    };

    public void Update(float dt)
    {
      for (int index = 0; index < 3; ++index)
      {
        this.rotations_[index] += this.rotationRate_ * dt;
        this.lyricTimers_[index] += dt;
        if ((double) this.lyricTimers_[index] > (double) this.lyricTimes_[index])
          this.actives_[index] = false;
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.actives_[index])
          spriteBatch.Draw(Global.feelWantTouch, this.positions_[index], new Rectangle?(this.lyricRectangles_[index]), Color.White, this.rotations_[index], new Vector2((float) (this.lyricRectangles_[index].Width / 2), (float) (this.lyricRectangles_[index].Height / 2)), (this.lyricTimes_[index] - this.lyricTimers_[index]) / this.lyricTimes_[index], SpriteEffects.None, 0.0f);
      }
    }

    public void TurnOn(int lyricIndex)
    {
      this.actives_[lyricIndex] = true;
      this.lyricTimers_[lyricIndex] = 0.0f;
      this.lyricTimes_[lyricIndex] = 2f;
      this.positions_[lyricIndex] = new Vector2((float) (213 + lyricIndex * 426), 360f);
      this.rotations_[lyricIndex] = 0.0f;
      this.rotationRate_ = 12.56637f / this.lyricTimes_[lyricIndex];
    }

    public void TurnOff()
    {
      for (int index = 0; index < 3; ++index)
        this.actives_[index] = false;
    }
  }
}
