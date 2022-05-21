





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
  internal class TunnelEffects
  {
    private TunnelParticle[] particles_ = new TunnelParticle[246];
    private TunnelParticle[] particles2_ = new TunnelParticle[100];
    private int activeParticles2_;
    private int particleDensity_;
    private float minStartScale_;
    private float maxStartScale_;
    private float minLifetime_;
    private float maxLifetime_;
    private float scaleRate_;
    private float speed_;
    private float acceleration_;

    public TunnelEffects()
    {
      this.particleDensity_ = 3;
      this.minStartScale_ = 0.5f;
      this.maxStartScale_ = 0.8f;
      this.minLifetime_ = 0.3f;
      this.maxLifetime_ = 0.5f;
      this.scaleRate_ = 1.5f;
      this.speed_ = 21f;
      this.acceleration_ = 32f;
      for (int index = 0; index < this.particles_.Length; ++index)
        this.particles_[index] = new TunnelParticle();
      for (int index = 0; index < this.particles2_.Length; ++index)
        this.particles2_[index] = new TunnelParticle();
    }

    public void UpdateTunnel(
      float dt,
      Vector2[] vertices,
      float width,
      float height,
      float tunnelVelocity)
    {
      for (int index = 0; index < this.particles_.Length; ++index)
        this.particles_[index].Update(dt, tunnelVelocity);
      for (int index1 = 0; index1 < 41; ++index1)
      {
        for (int index2 = index1 * 2 * this.particleDensity_; index2 < this.particleDensity_ + index1 * 2 * this.particleDensity_; ++index2)
        {
          if (!this.particles_[index2].visible_)
          {
            float x = vertices[index1].X + Global.RandomBetween(0.0f, width);
            float y = vertices[index1].Y;
            float num1 = Global.RandomBetween(0.0f, 6.283185f);
            float num2 = (float) Math.Cos((double) num1);
            float num3 = (float) Math.Sin((double) num1);
            float lifetime = Global.RandomBetween(this.minLifetime_, this.maxLifetime_);
            float startScale = Global.RandomBetween(this.minStartScale_, this.maxStartScale_);
            this.particles_[index2].Reset(new Vector2(x, y), new Vector2(this.speed_ * num2, this.speed_ * num3), new Vector2(this.acceleration_ * num2, this.acceleration_ * num3), startScale, this.scaleRate_, lifetime);
          }
        }
        for (int index3 = this.particleDensity_ + index1 * 2 * this.particleDensity_; index3 < 2 * this.particleDensity_ + index1 * 2 * this.particleDensity_; ++index3)
        {
          if (!this.particles_[index3].visible_)
          {
            float x = vertices[index1].X + Global.RandomBetween(0.0f, width);
            float y = vertices[index1].Y + height;
            float num4 = Global.RandomBetween(0.0f, 6.283185f);
            float num5 = (float) Math.Cos((double) num4);
            float num6 = (float) Math.Sin((double) num4);
            float lifetime = Global.RandomBetween(this.minLifetime_, this.maxLifetime_);
            float startScale = Global.RandomBetween(this.minStartScale_, this.maxStartScale_);
            this.particles_[index3].Reset(new Vector2(x, y), new Vector2(this.speed_ * num5, this.speed_ * num6), new Vector2(this.acceleration_ * num5, this.acceleration_ * num6), startScale, this.scaleRate_, lifetime);
          }
        }
      }
    }

    public void UpdateSymbols(
      float dt,
      Vector2[] symbolPositions,
      Vector2[] symbolVertices1,
      Vector2[] symbolVertices2,
      Vector2[] symbolVertices3,
      float tunnelVelocity)
    {
      this.activeParticles2_ = 0;
      for (int index = 0; index < this.particles2_.Length; ++index)
        this.particles2_[index].Update(dt, tunnelVelocity);
      this.UpdateSymbolParticles(symbolPositions[0], symbolVertices1);
      this.UpdateSymbolParticles(symbolPositions[1], symbolVertices2);
      this.UpdateSymbolParticles(symbolPositions[2], symbolVertices3);
    }

    private void UpdateSymbolParticles(Vector2 symbolPosition, Vector2[] symbolVertices)
    {
      for (int index1 = 0; index1 < symbolVertices.Length; ++index1)
      {
        int num = (int) ((double) Vector2.Distance(symbolVertices[index1], symbolVertices[(index1 + 1) % symbolVertices.Length]) * (double) this.particleDensity_ / 32.0 * 3.0 / 4.0);
        if (num == 0)
          num = 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          if (!this.particles2_[this.activeParticles2_].visible_)
          {
            Vector2 position = symbolPosition + Vector2.Lerp(symbolVertices[index1], symbolVertices[(index1 + 1) % symbolVertices.Length], (float) index2 / (float) num);
            Vector2 velocity = Vector2.Normalize(symbolVertices[(index1 + 1) % symbolVertices.Length] - symbolVertices[index1]) * this.speed_ * 1.5f;
            float lifetime = Global.RandomBetween(this.minLifetime_, this.maxLifetime_);
            float startScale = this.minStartScale_ + Global.RandomBetween(0.0f, (float) (((double) this.maxStartScale_ - (double) this.minStartScale_) / 2.0));
            this.particles2_[this.activeParticles2_].Reset(position, velocity, Vector2.Zero, startScale, (float) ((double) this.scaleRate_ * 3.0 / 4.0), lifetime);
          }
          ++this.activeParticles2_;
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      foreach (TunnelParticle particle in this.particles_)
        particle.Draw(spriteBatch);
      for (int index = 0; index < this.activeParticles2_; ++index)
        this.particles2_[index].Draw(spriteBatch);
    }
  }
}
