




using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class Vine
  {
    private bool active;
    private Vector2 position = new Vector2(0.0f, -90f);
    private float progress;
    private float progressRate = 0.5f;
    private float animTime;
    private float animTimer;
    private int animFrame;

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.progress += this.progressRate * dt;
      if ((double) this.progress > 2.0)
        this.TurnOff();
      this.animTimer += dt;
      if ((double) this.animTimer > (double) this.animTime)
      {
        this.animTimer = 0.0f;
        this.animFrame = (this.animFrame + 1) % 2;
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      if ((double) this.progress < 1.0)
        spriteBatch.Draw(Global.backgroundSpritesTexture, this.position + new Vector2(0.0f, (float) (810.0 - (double) this.progress * 810.0)), new Rectangle?(new Rectangle(this.animFrame * 295, 1761 - (int) ((double) this.progress * 810.0), 295, (int) ((double) this.progress * 810.0))), Color.White);
      else
        spriteBatch.Draw(Global.backgroundSpritesTexture, this.position + new Vector2(0.0f, (float) (810.0 - (2.0 - (double) this.progress) * 810.0)), new Rectangle?(new Rectangle(this.animFrame * 295, 1761 - (int) ((2.0 - (double) this.progress) * 810.0), 295, (int) ((2.0 - (double) this.progress) * 810.0))), Color.White);
    }

    public void Reset()
    {
      this.progress = 0.0f;
      this.animTime = 0.1f;
      this.animTimer = 0.0f;
      this.animFrame = 0;
      this.active = true;
    }

    public void TurnOff() => this.active = false;
  }
}
