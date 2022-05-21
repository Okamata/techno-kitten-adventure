





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Helicopter
{
  public abstract class ParticleSystem
  {
    public const int AlphaBlendDrawOrder = 100;
    public const int AdditiveDrawOrder = 200;
    private Vector2 origin;
    private int howManyEffects;
    private Particle[] particles;
    private Queue<Particle> freeParticles;
    public Vector2 worldVelocity;
    protected int minNumParticles;
    protected int maxNumParticles;
    protected float minInitialSpeed;
    protected float maxInitialSpeed;
    protected float minAcceleration;
    protected float maxAcceleration;
    protected float minRotationSpeed;
    protected float maxRotationSpeed;
    protected float minLifetime;
    protected float maxLifetime;
    protected float minScale;
    protected float maxScale;

    public bool Free => this.freeParticles.Count == this.particles.Length;

    protected ParticleSystem(int howManyEffects) => this.howManyEffects = howManyEffects;

    public void Initialize()
    {
      this.InitializeConstants();
      this.origin.X = (float) (Global.stars[0].Width / 2);
      this.origin.Y = (float) (Global.stars[0].Height / 2);
      this.particles = new Particle[this.howManyEffects * this.maxNumParticles];
      this.freeParticles = new Queue<Particle>(this.howManyEffects * this.maxNumParticles);
      for (int index = 0; index < this.particles.Length; ++index)
      {
        this.particles[index] = new Particle();
        this.freeParticles.Enqueue(this.particles[index]);
      }
    }

    protected abstract void InitializeConstants();

    public void AddParticles(Vector2 where)
    {
      int num = Global.Random.Next(this.minNumParticles, this.maxNumParticles);
      for (int index = 0; index < num && this.freeParticles.Count > 0; ++index)
        this.InitializeParticle(this.freeParticles.Dequeue(), where);
    }

    protected virtual void InitializeParticle(Particle p, Vector2 where)
    {
      Vector2 vector2 = Global.PickDirection(0.0f, 6.283185f);
      float num1 = Global.RandomBetween(this.minInitialSpeed, this.maxInitialSpeed);
      float num2 = Global.RandomBetween(this.minAcceleration, this.maxAcceleration);
      float lifetime = Global.RandomBetween(this.minLifetime, this.maxLifetime);
      float scale = Global.RandomBetween(this.minScale, this.maxScale);
      float rotationSpeed = Global.RandomBetween(this.minRotationSpeed, this.maxRotationSpeed);
      p.Initialize(this.worldVelocity, where, num1 * vector2, num2 * vector2, lifetime, scale, rotationSpeed, Global.stars.Length);
    }

    public void Update(float dt)
    {
      foreach (Particle particle in this.particles)
      {
        if (particle.Active)
        {
          particle.Update(dt);
          if (!particle.Active)
            this.freeParticles.Enqueue(particle);
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      foreach (Particle particle in this.particles)
      {
        if (particle.Active)
        {
          float num = particle.TimeSinceStart / particle.Lifetime;
          Color color = new Color(new Vector4(1f, 1f, 1f, (float) (4.0 * (double) num * (1.0 - (double) num))));
          float scale = particle.Scale * (float) (0.75 + 0.25 * (double) num);
          spriteBatch.Draw(Global.stars[particle.texIndex], particle.Position, new Rectangle?(), color, particle.Rotation, this.origin, scale, SpriteEffects.None, 0.0f);
        }
      }
    }

    public void Reset()
    {
      this.freeParticles.Clear();
      foreach (Particle particle in this.particles)
        this.freeParticles.Enqueue(particle);
    }
  }
}
