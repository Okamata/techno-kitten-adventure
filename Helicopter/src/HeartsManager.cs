





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class HeartsManager
  {
    private bool active_;
    private Vector2[] heartPositions_ = new Vector2[20];
    private float[] heartRotations_ = new float[20];
    private Vector2[] heartVelocities_ = new Vector2[20];
    private float[] heartRotationRates_ = new float[20]
    {
      2f,
      3f,
      4f,
      5f,
      6f,
      7f,
      2f,
      3f,
      4f,
      5f,
      6f,
      7f,
      2f,
      3f,
      4f,
      5f,
      6f,
      7f,
      4f,
      6f
    };
    private int[] heartIndexes_ = new int[20]
    {
      0,
      1,
      2,
      3,
      4,
      5,
      0,
      1,
      2,
      3,
      4,
      5,
      0,
      1,
      2,
      3,
      4,
      5,
      0,
      1
    };
    private Rectangle[] heartRects_ = new Rectangle[6]
    {
      new Rectangle(0, 0, 48, 48),
      new Rectangle(48, 0, 48, 48),
      new Rectangle(96, 0, 48, 48),
      new Rectangle(144, 0, 48, 48),
      new Rectangle(192, 0, 48, 48),
      new Rectangle(240, 0, 48, 48)
    };

    public void Update(float dt)
    {
      if (!this.active_)
        return;
      for (int index = 0; index < this.heartPositions_.Length; ++index)
      {
        this.heartPositions_[index] += this.heartVelocities_[index] * dt;
        this.heartRotations_[index] += this.heartRotationRates_[index] * dt;
        if ((double) this.heartPositions_[index].X > 1280.0)
          this.ResetHeart(index);
      }
    }

    private void ResetHeart(int index)
    {
      float x = Global.RandomBetween(500f, 1000f);
      float y = Global.RandomBetween(-9f / 32f * x, 9f / 32f * x);
      this.heartVelocities_[index] = new Vector2(x, y);
      this.heartPositions_[index].X = 0.0f;
      this.heartPositions_[index].Y = 360f;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active_)
        return;
      for (int index = 0; index < this.heartPositions_.Length; ++index)
        spriteBatch.Draw(Global.heartsTex, this.heartPositions_[index], new Rectangle?(this.heartRects_[this.heartIndexes_[index]]), Color.White, this.heartRotations_[index], new Vector2((float) (this.heartRects_[this.heartIndexes_[index]].Width / 2), (float) (this.heartRects_[this.heartIndexes_[index]].Height / 2)), 1f, SpriteEffects.None, 0.0f);
    }

    public void TurnOn()
    {
      this.active_ = true;
      for (int index = 0; index < this.heartPositions_.Length; ++index)
        this.ResetHeart(index);
    }

    public void TurnOff() => this.active_ = false;
  }
}
