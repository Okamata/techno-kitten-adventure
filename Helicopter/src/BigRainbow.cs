




using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class BigRainbow
  {
    private bool active = false;
    private Vector2 position = new Vector2(0.0f, 0.0f);
    private float progress;
    private float progressRate = 0.5f;

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.progress += this.progressRate * dt;
      if ((double) this.progress > 2.0)
        this.TurnOff();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      if ((double) this.progress < 1.0)
        spriteBatch.Draw(Global.rainbow3, this.position, new Rectangle?(new Rectangle(0, 0, (int) ((double) this.progress * 1280.0), 489)), Color.White);
      else
        spriteBatch.Draw(Global.rainbow3, this.position + new Vector2((float) (((double) this.progress - 1.0) * 1280.0), 0.0f), new Rectangle?(new Rectangle((int) (((double) this.progress - 1.0) * 1280.0), 0, (int) (1280.0 - ((double) this.progress - 1.0) * 1280.0), 489)), Color.White);
    }

    public void Reset()
    {
      this.progress = 0.0f;
      this.TurnOn();
    }

    public void TurnOn() => this.active = true;

    public void TurnOff() => this.active = false;
  }
}
