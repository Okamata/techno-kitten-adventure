





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
  public class Helicopter : AnimatedSpriteA
  {
    private ParticleEmitter particleEmitter;
    private RainbowTrail rainbowTrail;
    private Vector2 velocity;
    private Vector2 acceleration = Vector2.Zero;
    private float maxVelocity = 320f;
    private float maxVelocityG = 600f;
    public Vector2 position;
    private Rectangle collisionRect = new Rectangle(-16, -6, 40, 22);
    private float rotation = 0.0f;
    private float rotationVelocity = -1f;
    private float minRotation = 0.25f;
    private float maxRotation = 0.5f;
    private bool dead;
    private float deadTime = 1f;
    private float deadTimer;
    private Fireworks fireworks;

    public Rectangle CollisionRect => new Rectangle((int) this.position.X + this.collisionRect.X, (int) this.position.Y + this.collisionRect.Y, this.collisionRect.Width, this.collisionRect.Height);

    public Helicopter()
      : base(Global.cats)
    {
      this.Reset();
      this.fireworks = new Fireworks(5);
      this.rainbowTrail = new RainbowTrail();
      this.particleEmitter = new ParticleEmitter(this.position, Vector2.Zero, 4);
      this.particleEmitter.particleSystem.worldVelocity = new Vector2(-476f, 0.0f);
      this.ChangeAnimation(0);
    }

    public void HandleInput(InputState input, Tunnel tunnel, ScoreSystem scoreSystem, float dt)
    {
      this.acceleration.Y = 2250f;
      if (input.IsButtonDown(Buttons.A) && !this.IsDead())
      {
        if (!tunnel.IsOn())
        {
          tunnel.TurnOn();
          scoreSystem.Begin();
          this.velocity = Vector2.Zero;
          this.rotation += this.rotationVelocity * dt;
          this.acceleration.Y -= 4500f;
        }
        else
        {
          this.rotation += this.rotationVelocity * dt;
          this.acceleration.Y -= 4500f;
        }
      }
      else
      {
        if (!tunnel.IsOn())
          return;
        this.rotation -= this.rotationVelocity * dt;
      }
    }

    public void Update(float dt, Tunnel tunnel, ScoreSystem scoreSystem)
    {
      this.rainbowTrail.Update(dt, this.position.Y - 8f);
      this.particleEmitter.currPosition = this.position + new Vector2(-12f, 5f);
      this.particleEmitter.Update(dt);
      if (this.dead)
      {
        this.position = new Vector2(400f, 360f);
        this.deadTimer += dt;
        if ((double) this.deadTimer > (double) this.deadTime)
        {
          this.Reset();
          scoreSystem.SetZero();
        }
      }
      if (tunnel.IsOn())
      {
        this.velocity += this.acceleration * dt;
        if ((double) this.velocity.Y > (double) this.maxVelocityG)
          this.velocity.Y = this.maxVelocityG;
        else if ((double) this.velocity.Y < -(double) this.maxVelocity)
          this.velocity.Y = -this.maxVelocity;
        this.position += this.velocity * dt;
        if ((double) this.rotation < (double) this.minRotation)
          this.rotation = this.minRotation;
        if ((double) this.rotation > (double) this.maxRotation)
          this.rotation = this.maxRotation;
      }
      this.fireworks.Update(dt);
      this.Update(dt);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.dead)
      {
        this.particleEmitter.Draw(spriteBatch);
        this.rainbowTrail.Draw(spriteBatch);
        this.Draw(spriteBatch, this.position, this.rotation, 1f, Color.White, SpriteEffects.None);
      }
      else
        this.fireworks.Draw(spriteBatch);
    }

    public void Reset()
    {
      this.dead = false;
      this.deadTimer = 0.0f;
      this.position = new Vector2(400f, 360f);
      this.rotation = this.maxRotation;
    }

    public void Kill()
    {
      Global.PlayCatSound();
      this.dead = true;
      this.fireworks.SetOff(this.position);
      this.fireworks.SetOff(this.position);
      this.fireworks.SetOff(this.position);
    }

    public bool IsDead() => this.dead;

    public void ChangeAnimation(int newAnimation)
    {
      switch (newAnimation)
      {
        case 0:
          this.SetAnimation(new Rectangle(162, 0, 84, 70), 4, 0.1f);
          break;
        case 1:
          this.SetAnimation(new Rectangle(0, 596, 100, 54), 4, 0.05f);
          break;
        case 2:
          this.SetAnimation(new Rectangle(498, 0, 84, 75), 4, 0.1f);
          break;
        case 3:
          this.SetAnimation(new Rectangle(0, 0, 81, 70), 2, 0.3f);
          break;
        case 4:
          this.SetAnimation(new Rectangle(920, 0, 87, 67), 4, 0.05f);
          break;
        case 5:
          this.SetAnimation(new Rectangle(506, 300, 76, 76), 5, 0.1f);
          break;
        case 6:
          this.SetAnimation(new Rectangle(0, 300, 84, 84), 6, 0.1f);
          break;
        case 7:
          this.SetAnimation(new Rectangle(0, 384, 75, 75), 6, 0.1f);
          break;
        case 8:
          this.SetAnimation(new Rectangle(920, 70, 111, 84), 4, 0.07f);
          break;
        case 9:
          this.SetAnimation(new Rectangle(0, 75, 80, 90), 11, 0.025f);
          break;
        case 10:
          this.SetAnimation(new Rectangle(0, 165, 81, 63), 11, 0.025f);
          break;
        case 11:
          this.SetAnimation(new Rectangle(0, 228, 74, 72), 11, 0.025f);
          break;
        case 12:
          this.SetAnimation(new Rectangle(920, 156, 134, 88), 4, 0.07f);
          break;
        case 13:
          this.SetAnimation(new Rectangle(556, 376, 76, 76), 4, 0.05f);
          break;
        case 14:
          this.SetAnimation(new Rectangle(0, 512, 84, 84), 4, 0.05f);
          break;
        case 15:
          this.SetAnimation(new Rectangle(338, 512, 84, 84), 6, 0.05f);
          break;
        case 16:
          this.SetAnimation(new Rectangle(920, 246, 83, 71), 4, 0.05f);
          break;
        case 17:
          this.SetAnimation(new Rectangle(0, 652, 91, 80), 17, 0.05f);
          break;
        case 18:
          this.SetAnimation(new Rectangle(0, 734, 92, 80), 15, 0.05f);
          break;
        case 19:
          this.SetAnimation(new Rectangle(0, 816, 81, 70), 19, 0.05f);
          break;
      }
      if (newAnimation == 3)
        this.particleEmitter.TurnOn();
      else
        this.particleEmitter.TurnOff();
      if (newAnimation == 1)
        this.rainbowTrail.TurnOn();
      else
        this.rainbowTrail.TurnOff();
      if (newAnimation == 0 || newAnimation == 10 || newAnimation == 7)
      {
        this.minRotation = 0.0f;
        this.maxRotation = 0.25f;
        this.rotation = this.maxRotation;
      }
      else if (newAnimation == 1 || newAnimation == 19)
      {
        this.minRotation = -0.3f;
        this.maxRotation = 0.05f;
        this.rotation = this.maxRotation;
      }
      else if (newAnimation == 4 || newAnimation == 8 || newAnimation == 16)
      {
        this.minRotation = -0.09906489f;
        this.maxRotation = 0.1509361f;
        this.rotation = this.maxRotation;
      }
      else if (newAnimation == 12)
      {
        this.minRotation = -0.2037846f;
        this.maxRotation = 0.04621632f;
        this.rotation = this.maxRotation;
      }
      else
      {
        this.minRotation = 0.25f;
        this.maxRotation = 0.5f;
        this.rotation = this.maxRotation;
      }
    }
  }
}
