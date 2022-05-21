





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class ScoreSystem
  {
    private ScoreInfo scoreInfo;
    private int currScore;
    private bool scoring;
    private Vector2 positionNormal = new Vector2(128f, 623f);
    private Vector2 positionHigh = new Vector2(900f, 623f);
    private float scale = 0.75f;
    private bool toTheBass = false;
    private float scaleChange = 4.399988f;
    private bool toMovement = false;
    private Vector2 velocityNormal;
    private Vector2 velocityHigh;

    public bool seaFortyUnlocked => this.scoreInfo.seaFortyUnlocked;

    public bool seaSixtyUnlocked => this.scoreInfo.seaSixtyUnlocked;

    public bool seaEightyUnlocked => this.scoreInfo.seaEightyUnlocked;

    public bool cloudFortyUnlocked => this.scoreInfo.cloudFortyUnlocked;

    public bool cloudSixtyUnlocked => this.scoreInfo.cloudSixtyUnlocked;

    public bool cloudEightyUnlocked => this.scoreInfo.cloudEightyUnlocked;

    public bool lavaFortyUnlocked => this.scoreInfo.lavaFortyUnlocked;

    public bool lavaSixtyUnlocked => this.scoreInfo.lavaSixtyUnlocked;

    public bool lavaEightyUnlocked => this.scoreInfo.lavaEightyUnlocked;

    public bool meatFortyUnlocked => this.scoreInfo.meatFortyUnlocked;

    public bool meatSixtyUnlocked => this.scoreInfo.meatSixtyUnlocked;

    public bool meatEightyUnlocked => this.scoreInfo.meatEightyUnlocked;

    public bool ronFortyUnlocked => this.scoreInfo.ronFortyUnlocked;

    public bool ronSixtyUnlocked => this.scoreInfo.ronSixtyUnlocked;

    public bool ronEightyUnlocked => this.scoreInfo.ronEightyUnlocked;

    public int CurrScore
    {
      get => this.currScore;
      set => this.currScore = value;
    }

    public ScoreSystem() => this.scoreInfo = new ScoreInfo(0);

    public void LoadInfo() => this.scoreInfo = ScoreInfo.LoadInfo();

    public void SaveInfo()
    {
      if (this.scoreInfo.HighScore == 0)
        return;
      this.scoreInfo.SaveInfo();
    }

    public void Update(float dt)
    {
      if (this.scoring)
        this.currScore += (int) ((double) dt * 1000.0);
      if (this.toTheBass)
      {
        this.scale += this.scaleChange * dt;
        if ((double) this.scale > 1.5)
        {
          this.scale = 1.5f;
          this.scaleChange = -this.scaleChange;
        }
        if ((double) this.scale < 0.0)
        {
          this.scale = 0.0f;
          this.scaleChange = -this.scaleChange;
        }
      }
      else
        this.scale = 0.75f;
      if (!this.toMovement)
        return;
      this.positionNormal += this.velocityNormal * dt;
      this.positionHigh += this.velocityHigh * dt;
      if ((double) this.positionNormal.X < 0.0)
      {
        this.positionNormal.X = 0.0f;
        this.velocityNormal.X = -this.velocityNormal.X;
      }
      if ((double) this.positionNormal.X > 900.0)
      {
        this.positionNormal.X = 900f;
        this.velocityNormal.X = -this.velocityNormal.X;
      }
      if ((double) this.positionNormal.Y < 0.0)
      {
        this.positionNormal.Y = 0.0f;
        this.velocityNormal.Y = -this.velocityNormal.Y;
      }
      if ((double) this.positionNormal.Y > 687.0)
      {
        this.positionNormal.Y = 687f;
        this.velocityNormal.Y = -this.velocityNormal.Y;
      }
      if ((double) this.positionHigh.X < 0.0)
      {
        this.positionHigh.X = 0.0f;
        this.velocityHigh.X = -this.velocityHigh.X;
      }
      if ((double) this.positionHigh.X > 900.0)
      {
        this.positionHigh.X = 900f;
        this.velocityHigh.X = -this.velocityHigh.X;
      }
      if ((double) this.positionHigh.Y < 0.0)
      {
        this.positionHigh.Y = 0.0f;
        this.velocityHigh.Y = -this.velocityHigh.Y;
      }
      if ((double) this.positionHigh.Y > 687.0)
      {
        this.positionHigh.Y = 687f;
        this.velocityHigh.Y = -this.velocityHigh.Y;
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(Global.scoreTexture, this.positionNormal, new Rectangle?(), Global.tunnelColor, 0.0f, Vector2.Zero, this.scale, SpriteEffects.None, 0.0f);
      this.DrawNumber(spriteBatch, this.currScore, this.positionNormal + new Vector2(204f * this.scale, 0.0f), Vector2.Zero);
      spriteBatch.Draw(Global.highScoreTexture, this.positionHigh, new Rectangle?(), Global.tunnelColor, 0.0f, Vector2.Zero, this.scale, SpriteEffects.None, 0.0f);
      this.DrawNumber(spriteBatch, this.scoreInfo.HighScore, this.positionHigh + new Vector2(144f * this.scale, 0.0f), Vector2.Zero);
    }

    private void DrawNumber(
      SpriteBatch spriteBatch,
      int number,
      Vector2 startingPosition,
      Vector2 startingOrigin)
    {
      foreach (char c in number.ToString())
      {
        int numericValue = (int) char.GetNumericValue(c);
        spriteBatch.Draw(Global.numbersTexture, startingPosition, new Rectangle?(new Rectangle(numericValue * 36, 0, 36, 32)), Global.tunnelColor, 0.0f, startingOrigin, this.scale, SpriteEffects.None, 0.0f);
        startingPosition.X += 38f * this.scale;
      }
    }

    public void DrawAllScores(SpriteBatch spriteBatch) => this.scoreInfo.DrawAllScores(spriteBatch);

    public void Begin()
    {
      this.SetZero();
      this.scoring = true;
    }

    public void SetZero() => this.currScore = 0;

    public void End(int stageIndex, int catIndex)
    {
      this.scoreInfo.AddScore(stageIndex, catIndex, this.currScore);
      this.scoring = false;
    }

    public void Reset()
    {
      this.scoring = false;
      this.currScore = 0;
    }

    public void TurnOnBass()
    {
      this.toTheBass = true;
      this.scaleChange = 1.5f / Global.BPM;
    }

    public void TurnOffBass() => this.toTheBass = false;

    public void TurnOnMovement()
    {
      this.toMovement = true;
      this.positionNormal = new Vector2(128f, 623f);
      this.positionHigh = new Vector2(900f, 623f);
      this.velocityNormal = new Vector2(600f, -1200f);
      this.velocityHigh = new Vector2(-1200f, -600f);
    }

    public void TurnOffMovement()
    {
      this.toMovement = false;
      this.positionNormal = new Vector2(128f, 623f);
      this.positionHigh = new Vector2(900f, 623f);
    }
  }
}
