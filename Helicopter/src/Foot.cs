﻿





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class Foot
  {
    private bool active;
    private Vector2 position = new Vector2(600f, -169f);
    private Vector2 velocity = new Vector2(0.0f, 200f);

    public void Update(float dt)
    {
      if (!this.active)
        return;
      this.position += this.velocity * dt;
      if ((double) this.position.Y > 0.0)
      {
        this.position.Y = 0.0f;
        this.velocity = -this.velocity;
      }
      if ((double) this.position.Y < -302.0)
      {
        this.position.Y = -302f;
        this.velocity = -this.velocity;
        this.TurnOff();
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.active)
        return;
      spriteBatch.Draw(Global.backgroundSpritesTexture, this.position, new Rectangle?(new Rectangle(592, 1000, 442, 302)), Color.White);
    }

    public void Reset()
    {
      this.active = true;
      this.position = new Vector2(419f, -302f);
      this.velocity = new Vector2(0.0f, 200f);
    }

    public void TurnOff() => this.active = false;
  }
}
