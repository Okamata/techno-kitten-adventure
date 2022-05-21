




using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class BRainbow
  {
    private bool active = false;
    private Vector2 position = new Vector2(0.0f, 403f);
    private float progress;
    private float progressRate = 1.7f;

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.progress += this.progressRate * dt;
      this.position -= new Vector2(Global.mountainVelocity * dt, 0.0f);
      if ((double) this.progress > 1.0)
      {
        this.position += new Vector2(200f, 0.0f);
        this.progress = 0.0f;
        if ((double) this.position.X > 1580.0)
        {
          this.position = new Vector2(0.0f, 403f);
          this.TurnOff();
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      spriteBatch.Draw(Global.rainbow2, this.position - new Vector2((float) ((1.0 - (double) this.progress) * 200.0), 0.0f), new Rectangle?(new Rectangle((int) ((double) this.progress * 200.0), 0, 200, 100)), Color.White);
      spriteBatch.Draw(Global.rainbow2, this.position, new Rectangle?(new Rectangle(0, 0, (int) ((double) this.progress * 200.0), 100)), Color.White);
    }

    public void Reset()
    {
      this.position = new Vector2(0.0f, 403f);
      this.progress = 0.0f;
      this.TurnOn();
    }

    public void TurnOn() => this.active = true;

    public void TurnOff() => this.active = false;
  }
}
