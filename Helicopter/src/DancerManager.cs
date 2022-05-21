





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  internal class DancerManager
  {
    private bool on_ = false;
    private Dancer[] dancers_ = new Dancer[5];

    public DancerManager()
    {
      for (int index = 0; index < this.dancers_.Length; ++index)
        this.dancers_[index] = new Dancer();
    }

    public void Update(float dt)
    {
      if (!this.on_)
        return;
      foreach (Dancer dancer in this.dancers_)
        dancer.Update(dt);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.on_)
        return;
      foreach (Dancer dancer in this.dancers_)
        dancer.Draw(spriteBatch);
    }

    public void TurnOn(int index)
    {
      this.on_ = true;
      if (index == 0)
      {
        for (int index1 = 0; index1 < this.dancers_.Length; ++index1)
        {
          Color rainbowColor = Global.rainbowColors[index1];
          this.dancers_[index1].TurnOn(new Vector2((float) (1458 / this.dancers_.Length * index1), 360f), 0, Color.White);
        }
      }
      else
      {
        foreach (Dancer dancer in this.dancers_)
          dancer.ReverseDirection();
      }
    }

    public void TurnOff()
    {
      this.on_ = false;
      foreach (Dancer dancer in this.dancers_)
        dancer.TurnOff();
    }
  }
}
