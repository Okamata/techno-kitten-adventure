





using Microsoft.Xna.Framework;

namespace Helicopter
{
  public class Particle
  {
    public Vector2 WorldVelocity;
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public float Lifetime;
    public float TimeSinceStart;
    public float Scale;
    public float Rotation;
    public float RotationSpeed;
    public int texIndex;

    public bool Active => (double) this.TimeSinceStart < (double) this.Lifetime;

    public void Initialize(
      Vector2 worldVelocity,
      Vector2 position,
      Vector2 velocity,
      Vector2 acceleration,
      float lifetime,
      float scale,
      float rotationSpeed,
      int numTexIndex)
    {
      this.WorldVelocity = worldVelocity;
      this.Position = position;
      this.Velocity = velocity;
      this.Acceleration = acceleration;
      this.Lifetime = lifetime;
      this.Scale = scale;
      this.RotationSpeed = rotationSpeed;
      this.TimeSinceStart = 0.0f;
      this.Rotation = Global.RandomBetween(0.0f, 6.283185f);
      this.texIndex = Global.Random.Next(0, numTexIndex);
    }

    public void Update(float dt)
    {
      this.Velocity += this.Acceleration * dt;
      this.Position += (this.Velocity + this.WorldVelocity) * dt;
      this.Rotation += this.RotationSpeed * dt;
      this.TimeSinceStart += dt;
    }
  }
}
