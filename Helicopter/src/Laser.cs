





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class Laser
  {
    private bool active;
    private Vector2 position;
    private Vector2 dimensions = new Vector2(Vector2.Distance(Vector2.Zero, new Vector2(1280f, 720f)), 2f);
    private float[] rotations = new float[5];
    private float[] rotationPrimer = new float[5]
    {
      -2f,
      -1f,
      0.0f,
      1f,
      2f
    };
    private float[] rotationSpeeds = new float[5];
    private float RDt;
    private Color color;

    public Laser(Vector2 _position, Color _color)
    {
      this.position = _position;
      this.color = _color;
      this.Reset();
    }

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.RDt += dt;
      if ((double) this.RDt > (double) Global.BPM)
      {
        this.Reset();
      }
      else
      {
        for (int index = 0; index < this.rotations.Length; ++index)
          this.rotations[index] += this.rotationSpeeds[index] * dt;
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      foreach (float rotation in this.rotations)
        this.DrawLine(spriteBatch, rotation);
    }

    private void DrawLine(SpriteBatch spriteBatch, float rotation) => spriteBatch.Draw(Global.pixel, new Rectangle((int) this.position.X, (int) this.position.Y, (int) this.dimensions.X, (int) this.dimensions.Y), new Rectangle?(), this.color, rotation, Vector2.Zero, SpriteEffects.None, 0.0f);

    public void Set(Vector2 _position, Color _color)
    {
      this.position = _position;
      this.color = _color;
    }

    public void TurnOn() => this.active = true;

    public void TurnOff() => this.active = false;

    private void Reset()
    {
      float num1 = Global.RandomBetween(0.1f, 0.9f) * 3.141593f;
      float num2 = Global.RandomBetween(0.1f, 0.3f) * (float) (Global.Random.Next(2) * 2 - 1);
      for (int index = 0; index < this.rotations.Length; ++index)
      {
        this.rotations[index] = num1;
        this.rotationSpeeds[index] = num2 * this.rotationPrimer[index];
      }
      this.RDt = 0.0f;
    }
  }
}
