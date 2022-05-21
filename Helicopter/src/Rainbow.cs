





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class Rainbow
  {
    private bool active;
    private float progress;
    private float progressRate = 1f;

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.progress += this.progressRate * dt;
      if ((double) this.progress > 1.20000004768372)
      {
        this.progress = 0.0f;
        this.TurnOff();
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      spriteBatch.Draw(Global.rainbow, Vector2.Zero, new Rectangle?(new Rectangle(0, 0, (int) ((double) this.progress * 1280.0), 639)), new Color(new Vector4(Color.White.ToVector3(), 1.2f - this.progress)));
    }

    public void TurnOn() => this.active = true;

    public void TurnOff() => this.active = false;

    public void Reset()
    {
      this.active = false;
      this.progress = 0.0f;
    }
  }
}
