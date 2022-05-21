





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class Eyes
  {
    private bool active;
    private Vector2 position;
    private float alpha;
    private float alphaRate;
    private int currFrame;
    private int numFrames;
    private float frameTimer;
    private float frameTime;

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.alpha += this.alphaRate * dt;
      if ((double) this.alpha > 1.0)
      {
        this.alpha = 1f;
        this.alphaRate = -this.alphaRate;
      }
      if ((double) this.alpha < 0.0)
        this.active = false;
      this.frameTimer += dt;
      if ((double) this.frameTimer > (double) this.frameTime)
      {
        this.currFrame = (this.currFrame + 1) % this.numFrames;
        this.frameTimer = 0.0f;
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      spriteBatch.Draw(Global.searchingEyes, this.position, new Rectangle?(new Rectangle(281 * this.currFrame, 0, 281, 79)), new Color(new Vector4(Color.White.ToVector3(), this.alpha)));
    }

    public void TurnOn()
    {
      this.active = true;
      this.position = new Vector2(499.5f, 320.5f);
      this.alpha = 0.0f;
      this.alphaRate = 0.6f;
      this.frameTime = 0.075f;
      this.frameTimer = 0.0f;
      this.currFrame = 0;
      this.numFrames = 8;
    }

    public void TurnOff() => this.active = false;
  }
}
