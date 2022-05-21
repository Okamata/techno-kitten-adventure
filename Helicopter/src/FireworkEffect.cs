





namespace Helicopter
{
  public class FireworkEffect : ParticleSystem
  {
    public FireworkEffect(int effects)
      : base(effects)
    {
    }

    protected override void InitializeConstants()
    {
      this.minInitialSpeed = 0.0f;
      this.maxInitialSpeed = 120f;
      this.minAcceleration = 0.0f;
      this.maxAcceleration = 50f;
      this.minLifetime = 0.68182f;
      this.maxLifetime = 0.68182f;
      this.minScale = 1f;
      this.maxScale = 1.3f;
      this.minNumParticles = 8;
      this.maxNumParticles = 10;
      this.minRotationSpeed = 0.0f;
      this.maxRotationSpeed = 3.141593f;
    }
  }
}
