





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
  public class ItemSelectedEffect
  {
    private ItemSelectedParticle[] particles_ = new ItemSelectedParticle[300];
    private Vector2[] itemVertices_ = new Vector2[4];
    private int activeParticles_;
    private float particleDensity_;
    private float minStartScale_;
    private float maxStartScale_;
    private float minLifetime_;
    private float maxLifetime_;
    private float scaleRate_;
    private float speed_;
    private float acceleration_;

    public ItemSelectedEffect()
    {
      this.minStartScale_ = 0.4f;
      this.maxStartScale_ = 0.8f;
      this.minLifetime_ = 0.2f;
      this.maxLifetime_ = 0.5f;
      this.scaleRate_ = 1.5f;
      this.speed_ = 22f;
      this.acceleration_ = 32f;
      this.particleDensity_ = 0.06535948f;
      for (int index = 0; index < this.particles_.Length; ++index)
      {
        switch (index % 6)
        {
          case 0:
            this.particles_[index] = new ItemSelectedParticle(new Color((int) byte.MaxValue, (int) byte.MaxValue, 128));
            break;
          case 1:
            this.particles_[index] = new ItemSelectedParticle(new Color((int) byte.MaxValue, (int) byte.MaxValue, 0));
            break;
          case 2:
            this.particles_[index] = new ItemSelectedParticle(new Color((int) byte.MaxValue, 128, (int) byte.MaxValue));
            break;
          case 3:
            this.particles_[index] = new ItemSelectedParticle(new Color((int) byte.MaxValue, 0, (int) byte.MaxValue));
            break;
          case 4:
            this.particles_[index] = new ItemSelectedParticle(new Color(128, (int) byte.MaxValue, (int) byte.MaxValue));
            break;
          case 5:
            this.particles_[index] = new ItemSelectedParticle(new Color(0, (int) byte.MaxValue, (int) byte.MaxValue));
            break;
        }
      }
    }

    public void Update(float dt)
    {
      for (int index = 0; index < this.particles_.Length; ++index)
        this.particles_[index].Update(dt);
      this.activeParticles_ = 0;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int num1 = (int) ((double) Vector2.Distance(this.itemVertices_[index1], this.itemVertices_[(index1 + 1) % 4]) * (double) this.particleDensity_);
        for (int index2 = 0; index2 < num1; ++index2)
        {
          if (!this.particles_[this.activeParticles_].visible_)
          {
            Vector2 position = Vector2.Lerp(this.itemVertices_[index1], this.itemVertices_[(index1 + 1) % 4], (float) index2 / (float) num1);
            float num2 = Global.RandomBetween(0.0f, 6.283185f);
            Vector2 vector2 = new Vector2((float) Math.Cos((double) num2), (float) Math.Sin((double) num2));
            float lifetime = Global.RandomBetween(this.minLifetime_, this.maxLifetime_);
            float startScale = Global.RandomBetween(this.minStartScale_, this.maxStartScale_);
            this.particles_[this.activeParticles_].Reset(position, this.speed_ * vector2, this.acceleration_ * vector2, startScale, this.scaleRate_, lifetime);
          }
          ++this.activeParticles_;
          if (this.activeParticles_ >= this.particles_.Length)
            return;
        }
      }
    }

    public void SetItemVertices(Rectangle itemRect)
    {
      this.itemVertices_[0] = new Vector2((float) itemRect.X, (float) itemRect.Y);
      this.itemVertices_[1] = new Vector2((float) (itemRect.X + itemRect.Width), (float) itemRect.Y);
      this.itemVertices_[2] = new Vector2((float) (itemRect.X + itemRect.Width), (float) (itemRect.Y + itemRect.Height));
      this.itemVertices_[3] = new Vector2((float) itemRect.X, (float) (itemRect.Y + itemRect.Height));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < this.activeParticles_; ++index)
        this.particles_[index].Draw(spriteBatch);
    }
  }
}
