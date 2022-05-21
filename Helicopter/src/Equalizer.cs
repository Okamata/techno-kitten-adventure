





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Helicopter
{
  internal class Equalizer
  {
    private bool visible_;
    private VisualizationData visualizationData_;
    private Vector2 position_ = new Vector2(120f, 600f);
    private float dWidth_;
    private float dHeight_;
    private float equalizerHeight_;
    private float[] freqHeights_ = new float[16];
    private float startingHue_;
    private float startingHueRate_ = 1080f;
    private float bpmTimer_;
    private bool rainbowed_ = false;

    public Equalizer()
    {
      this.dWidth_ = (float) (Global.equalizerBar.Width + 2);
      this.dHeight_ = (float) (Global.equalizerBar.Height + 2);
      this.equalizerHeight_ = (float) (int) (576.0 / (double) this.dHeight_);
      this.visualizationData_ = new VisualizationData();
    }

    public void Update(float dt)
    {
      if (!this.visible_)
        return;
      MediaPlayer.GetVisualizationData(this.visualizationData_);
      for (int index1 = 0; index1 < 16; ++index1)
      {
        this.freqHeights_[index1] = 0.0f;
        for (int index2 = 0; index2 < 16; ++index2)
          this.freqHeights_[index1] += this.visualizationData_.Frequencies[index1 * 16 + index2];
        this.freqHeights_[index1] *= 1f / 16f;
        this.freqHeights_[index1] *= this.equalizerHeight_;
        this.freqHeights_[index1] -= 10f;
        this.freqHeights_[index1] *= 1.15f;
      }
      if (this.rainbowed_)
      {
        this.startingHue_ += this.startingHueRate_ * dt;
        if ((double) this.startingHue_ < 0.0)
        {
          this.startingHue_ = 0.0f;
          this.startingHueRate_ = -this.startingHueRate_;
        }
        if ((double) this.startingHue_ > 360.0)
        {
          this.startingHue_ = 360f;
          this.startingHueRate_ = -this.startingHueRate_;
        }
      }
      else
      {
        this.bpmTimer_ += dt;
        if ((double) this.bpmTimer_ > 0.333333343267441)
        {
          this.bpmTimer_ -= 0.3333333f;
          this.startingHue_ += 90f;
          this.startingHue_ %= 360f;
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.visible_)
        return;
      for (int index1 = 0; index1 < this.freqHeights_.Length; ++index1)
      {
        int freqHeight = (int) this.freqHeights_[index1];
        for (int index2 = 0; index2 < freqHeight; ++index2)
        {
          if (this.rainbowed_)
            spriteBatch.Draw(Global.equalizerBar, this.position_ + new Vector2(this.dWidth_ * (float) index1, -this.dHeight_ * (float) index2), Equalizer.GetColor((float) (((double) this.startingHue_ + 22.5 * (double) index1 + (double) index2 / (double) this.equalizerHeight_ * 360.0) % 360.0)));
          else
            spriteBatch.Draw(Global.equalizerBar, this.position_ + new Vector2(this.dWidth_ * (float) index1, -this.dHeight_ * (float) index2), Equalizer.GetColor((float) (((double) this.startingHue_ + 11.25 * (double) index1 + (double) index2 / (double) this.equalizerHeight_ * 180.0) % 360.0)));
        }
      }
    }

    public void TurnOn(bool rainbowed)
    {
      this.visible_ = true;
      this.rainbowed_ = rainbowed;
      this.startingHue_ = 0.0f;
      this.bpmTimer_ = 0.0f;
    }

    public void TurnOff() => this.visible_ = false;

    private static Color GetColor(float hue)
    {
      Vector3 one = Vector3.One;
      if ((double) hue < 0.0)
        return new Color(new Vector4(Color.White.ToVector3(), 0.0f));
      if ((double) hue <= 60.0)
      {
        one.X = 1f;
        one.Y = hue / 60f;
        one.Z = 0.0f;
      }
      else if ((double) hue <= 120.0)
      {
        one.Y = 1f;
        one.X = (float) (2.0 - (double) hue / 60.0);
        one.Z = 0.0f;
      }
      else if ((double) hue <= 180.0)
      {
        one.Y = 1f;
        one.Z = (float) ((double) hue / 60.0 - 2.0);
        one.X = 0.0f;
      }
      else if ((double) hue <= 240.0)
      {
        one.Z = 1f;
        one.Y = (float) (4.0 - (double) hue / 60.0);
        one.X = 0.0f;
      }
      else if ((double) hue <= 300.0)
      {
        one.Z = 1f;
        one.X = (float) ((double) hue / 60.0 - 4.0);
        one.Y = 0.0f;
      }
      else
      {
        one.X = 1f;
        one.Z = (float) (6.0 - (double) hue / 60.0);
        one.Y = 0.0f;
      }
      return new Color(one);
    }
  }
}
