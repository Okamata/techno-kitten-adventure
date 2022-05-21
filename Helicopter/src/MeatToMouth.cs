





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class MeatToMouth
  {
    private bool active_;
    private Vector2[] meatPositions_ = new Vector2[20];
    private float[] meatRotations_ = new float[20];
    private Vector2[] meatVelocities_ = new Vector2[20];
    private float[] meatRotationRates_ = new float[20]
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
    private int[] meatIndexes_ = new int[20]
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
      4,
      3
    };
    private Rectangle[] meatRects_ = new Rectangle[6]
    {
      new Rectangle(0, 0, 64, 94),
      new Rectangle(64, 0, 34, 20),
      new Rectangle(64, 20, 25, 33),
      new Rectangle(98, 0, 69, 76),
      new Rectangle(167, 0, 90, 80),
      new Rectangle(257, 0, 108, 95)
    };
    private AnimatedSpriteA mouth_;
    private Vector2 mouthPosition_ = new Vector2(1220f, 360f);

    public MeatToMouth()
    {
      this.mouth_ = new AnimatedSpriteA(Global.mouth);
      this.mouth_.SetAnimation(new Rectangle(0, 0, 216, 293), 10, 0.05f);
    }

    public void Update(float dt)
    {
      if (!this.active_)
        return;
      for (int index = 0; index < this.meatPositions_.Length; ++index)
      {
        this.meatPositions_[index] += this.meatVelocities_[index] * dt;
        this.meatRotations_[index] += this.meatRotationRates_[index] * dt;
        if ((double) this.meatPositions_[index].X > 1250.0)
          this.ResetMeat(index);
      }
      this.mouth_.Update(dt);
    }

    private void ResetMeat(int index)
    {
      this.meatVelocities_[index] = new Vector2(Global.RandomBetween(600f, 1000f), Global.RandomBetween(-400f, 400f));
      this.meatPositions_[index].X = -150f;
      float num = (this.mouthPosition_.X - this.meatPositions_[index].X) / this.meatVelocities_[index].X;
      this.meatPositions_[index].Y = this.mouthPosition_.Y - this.meatVelocities_[index].Y * num;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active_)
        return;
      for (int index = 0; index < this.meatPositions_.Length; ++index)
        spriteBatch.Draw(Global.meatsToMouth, this.meatPositions_[index], new Rectangle?(this.meatRects_[this.meatIndexes_[index]]), Color.White, this.meatRotations_[index], new Vector2((float) (this.meatRects_[this.meatIndexes_[index]].Width / 2), (float) (this.meatRects_[this.meatIndexes_[index]].Height / 2)), 1f, SpriteEffects.None, 0.0f);
      this.mouth_.Draw(spriteBatch, this.mouthPosition_, 0.0f, 1f, Color.White, SpriteEffects.FlipHorizontally);
    }

    public void TurnOn()
    {
      this.active_ = true;
      for (int index = 0; index < this.meatPositions_.Length; ++index)
        this.ResetMeat(index);
    }

    public void TurnOff() => this.active_ = false;
  }
}
