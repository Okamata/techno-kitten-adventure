





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class Fireworks
  {
    private bool showActive;
    private FireworkEffect[] fireworkEffects;

    public Fireworks(int _num)
    {
      this.fireworkEffects = new FireworkEffect[_num];
      for (int index = 0; index < _num; ++index)
      {
        this.fireworkEffects[index] = new FireworkEffect(1);
        this.fireworkEffects[index].Initialize();
      }
    }

    public void Update(float dt)
    {
      if (this.showActive)
      {
        for (int index = 0; index < this.fireworkEffects.Length; ++index)
        {
          if (this.fireworkEffects[index].Free)
            this.fireworkEffects[index].AddParticles(new Vector2(Global.RandomBetween(0.0f, 1280f), Global.RandomBetween(0.0f, 300f)));
        }
      }
      foreach (FireworkEffect fireworkEffect in this.fireworkEffects)
      {
        if (!fireworkEffect.Free)
          fireworkEffect.Update(dt);
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      foreach (FireworkEffect fireworkEffect in this.fireworkEffects)
      {
        if (!fireworkEffect.Free)
          fireworkEffect.Draw(spriteBatch);
      }
    }

    public void SetOff(Vector2 _position)
    {
      for (int index = 0; index < this.fireworkEffects.Length; ++index)
      {
        if (this.fireworkEffects[index].Free)
        {
          this.fireworkEffects[index].AddParticles(_position);
          break;
        }
      }
    }

    public void TurnOn() => this.showActive = true;

    public void TurnOff() => this.showActive = false;
  }
}
