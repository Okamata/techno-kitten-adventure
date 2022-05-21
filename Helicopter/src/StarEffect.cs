





namespace Helicopter
{
  public class StarEffect : ParticleSystem
  {
    public StarEffect(int effects)
      : base(effects)
    {
    }

    protected override void InitializeConstants()
    {
      this.minInitialSpeed = 20f;
      this.maxInitialSpeed = 40f;
      this.minAcceleration = 0.0f;
      this.maxAcceleration = 10f;
      this.minLifetime = 0.25f;
      this.maxLifetime = 0.75f;
      this.minScale = 1f;
      this.maxScale = 1f;
      this.minNumParticles = 3;
      this.maxNumParticles = 5;
      this.minRotationSpeed = 0.0f;
      this.maxRotationSpeed = 0.0f;
    }
  }
}
