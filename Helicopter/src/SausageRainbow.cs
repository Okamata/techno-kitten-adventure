





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class SausageRainbow
  {
    private bool largeSausage;
    private bool active = false;
    private Vector2 position;
    private float progress;
    private float progressRate = 0.5f;

    public SausageRainbow(bool isLargeSausage)
    {
      this.largeSausage = isLargeSausage;
      if (this.largeSausage)
        this.position = new Vector2(96.5f, 50f);
      else
        this.position = new Vector2(473.5f, 210f);
    }

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
      {
        if (this.largeSausage)
          spriteBatch.Draw(Global.backgroundSpritesTexture, this.position, new Rectangle?(new Rectangle(0, 330, (int) ((double) this.progress * 1087.0), 500)), Color.White);
        else
          spriteBatch.Draw(Global.backgroundSpritesTexture, this.position, new Rectangle?(new Rectangle(1100, 330, (int) ((double) this.progress * 333.0), 210)), Color.White);
      }
      else if (this.largeSausage)
        spriteBatch.Draw(Global.backgroundSpritesTexture, this.position + new Vector2((float) (((double) this.progress - 1.0) * 1087.0), 0.0f), new Rectangle?(new Rectangle((int) (((double) this.progress - 1.0) * 1087.0), 330, (int) (1087.0 - ((double) this.progress - 1.0) * 1087.0), 500)), Color.White);
      else
        spriteBatch.Draw(Global.backgroundSpritesTexture, this.position + new Vector2((float) (((double) this.progress - 1.0) * 333.0), 0.0f), new Rectangle?(new Rectangle(1100 + (int) (((double) this.progress - 1.0) * 333.0), 330, (int) (333.0 - ((double) this.progress - 1.0) * 333.0), 210)), Color.White);
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
