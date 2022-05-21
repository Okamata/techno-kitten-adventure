




using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
  internal class CatSelectMenu : Menu
  {
    private GameState lastGameState;
    private int currentCat;
    private int[] numCats_ = new int[5]{ 5, 4, 4, 4, 3 };
    private int[] startCatIndex_ = new int[5]
    {
      0,
      5,
      9,
      13,
      17
    };
    private string[] catNames_ = new string[20]
    {
      "JetPack Kitteh",
      "Byarf Kitteh",
      "Butterfly Kitteh",
      "Dream Kitteh",
      "Mermaid Kitteh",
      "Baby Kitteh",
      "Love Kitteh",
      "Angel Kitteh",
      "Death Kitteh",
      "Bat Kitteh",
      "Fire Kitteh",
      "Rock Kitteh",
      "Dragon Kitteh",
      "Steak Kitteh",
      "Bacon Kitteh",
      "HotDog Kitteh",
      "Burger Kitteh",
      "Alien Kitteh",
      "Grin Kitteh",
      "MC Kitteh"
    };
    private string[] lockedNames_ = new string[4]
    {
      "Unlocked in\n Full Mode",
      "Unlocked at\n  40,000 P",
      "Unlocked at\n  60,000 P",
      "Unlocked at\n  80,000 P"
    };

    public GameState LastGameState => this.lastGameState;

    public CatSelectMenu()
      : base(true)
    {
      this.SetCats(0);
    }

    public void Update(
      float dt,
      InputState currInput,
      ref GameState gameState,
      int currentLevel,
      ScoreSystem scoreSystem)
    {
      this.SetCats(currentLevel);
      this.Update(dt, currInput);
      if (currInput.IsButtonPressed(Buttons.A))
      {
        switch (this.index_)
        {
          case 1:
            switch (currentLevel)
            {
              case 0:
                if (Global.IsTrialMode)
                  return;
                break;
              case 1:
                if (!scoreSystem.cloudFortyUnlocked)
                  return;
                break;
              case 2:
                if (!scoreSystem.lavaFortyUnlocked)
                  return;
                break;
              case 3:
                if (!scoreSystem.meatFortyUnlocked)
                  return;
                break;
              case 4:
                if (!scoreSystem.ronFortyUnlocked)
                  return;
                break;
            }
            break;
          case 2:
            switch (currentLevel)
            {
              case 0:
                if (!scoreSystem.seaFortyUnlocked)
                  return;
                break;
              case 1:
                if (!scoreSystem.cloudSixtyUnlocked)
                  return;
                break;
              case 2:
                if (!scoreSystem.lavaSixtyUnlocked)
                  return;
                break;
              case 3:
                if (!scoreSystem.meatSixtyUnlocked)
                  return;
                break;
              case 4:
                if (!scoreSystem.ronSixtyUnlocked)
                  return;
                break;
            }
            break;
          case 3:
            switch (currentLevel)
            {
              case 0:
                if (!scoreSystem.seaSixtyUnlocked)
                  return;
                break;
              case 1:
                if (!scoreSystem.cloudEightyUnlocked)
                  return;
                break;
              case 2:
                if (!scoreSystem.lavaEightyUnlocked)
                  return;
                break;
              case 3:
                if (!scoreSystem.meatEightyUnlocked)
                  return;
                break;
              case 4:
                if (!scoreSystem.ronEightyUnlocked)
                  return;
                break;
            }
            break;
          case 4:
            if (!scoreSystem.seaEightyUnlocked)
              return;
            break;
        }
        Global.PlayCatSound();
        this.currentCat = this.startCatIndex_[currentLevel] + this.index_;
        this.index_ = 0;
        gameState = GameState.PLAY;
      }
      if (!currInput.IsButtonPressed(Buttons.B))
        return;
      Global.PlayCatSound();
      this.index_ = 0;
      gameState = this.lastGameState;
    }

    private void SetCats(int currentLevel)
    {
      if (this.menuItems_.Count != this.numCats_[currentLevel])
      {
        this.menuItems_.Clear();
        for (int index = 0; index < this.numCats_[currentLevel]; ++index)
          this.menuItems_.Add(new MenuItem(Global.selectCatTex, new Rectangle(0, 0, 0, 0), new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 240f)));
      }
      for (int index = 0; index < this.numCats_[currentLevel]; ++index)
        this.menuItems_[index].SetTexRect(new Rectangle((this.startCatIndex_[currentLevel] + index) % 5 * 242, 722 + (this.startCatIndex_[currentLevel] + index) / 5 * 240, 240, 238));
    }

    public void Draw(SpriteBatch spriteBatch, int currentLevel, ScoreSystem scoreSystem)
    {
      this.DrawBackground(spriteBatch, currentLevel);
      this.Draw(spriteBatch);
      this.DrawForeground(spriteBatch, currentLevel, scoreSystem);
    }

    private void DrawBackground(SpriteBatch spriteBatch, int currentLevel)
    {
      spriteBatch.Draw(Global.selectCatTex, Vector2.Zero, new Rectangle?(new Rectangle(0, 0, 1280, 118)), Color.White);
      spriteBatch.Draw(Global.selectCatTex, new Vector2(0.0f, 428f), new Rectangle?(new Rectangle(0, 428, 1280, 292)), Color.White);
    }

    private void DrawForeground(SpriteBatch spriteBatch, int currentLevel, ScoreSystem scoreSystem)
    {
      float scale = 1f;
      if (currentLevel == 0)
        scale = 0.85f;
      for (int index = 0; index < this.numCats_[currentLevel]; ++index)
      {
        spriteBatch.DrawString(Global.menuFont, this.catNames_[this.startCatIndex_[currentLevel] + index], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel]) - 1.5), 389.5f), Color.White, 0.0f, Global.menuFont.MeasureString(this.catNames_[this.startCatIndex_[currentLevel] + index]) / 2f, scale, SpriteEffects.None, 0.0f);
        spriteBatch.DrawString(Global.menuFont, this.catNames_[this.startCatIndex_[currentLevel] + index], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 388f), Color.Black, 0.0f, Global.menuFont.MeasureString(this.catNames_[this.startCatIndex_[currentLevel] + index]) / 2f, scale, SpriteEffects.None, 0.0f);
        bool flag = false;
        if (index == 1 && this.numCats_[currentLevel] == 5)
          flag = Global.IsTrialMode;
        if (index == 2 && this.numCats_[currentLevel] == 5 || index == 1 && this.numCats_[currentLevel] == 4 || index == 1 && this.numCats_[currentLevel] == 3)
        {
          switch (currentLevel)
          {
            case 0:
              flag = !scoreSystem.seaFortyUnlocked;
              break;
            case 1:
              flag = !scoreSystem.cloudFortyUnlocked;
              break;
            case 2:
              flag = !scoreSystem.lavaFortyUnlocked;
              break;
            case 3:
              flag = !scoreSystem.meatFortyUnlocked;
              break;
            case 4:
              flag = !scoreSystem.ronFortyUnlocked;
              break;
          }
        }
        if (index == 3 && this.numCats_[currentLevel] == 5 || index == 2 && this.numCats_[currentLevel] == 4 || index == 2 && this.numCats_[currentLevel] == 3)
        {
          switch (currentLevel)
          {
            case 0:
              flag = !scoreSystem.seaSixtyUnlocked;
              break;
            case 1:
              flag = !scoreSystem.cloudSixtyUnlocked;
              break;
            case 2:
              flag = !scoreSystem.lavaSixtyUnlocked;
              break;
            case 3:
              flag = !scoreSystem.meatSixtyUnlocked;
              break;
            case 4:
              flag = !scoreSystem.ronSixtyUnlocked;
              break;
          }
        }
        if (index == 4 && this.numCats_[currentLevel] == 5 || index == 3 && this.numCats_[currentLevel] == 4 || index == 3 && this.numCats_[currentLevel] == 3)
        {
          switch (currentLevel)
          {
            case 0:
              flag = !scoreSystem.seaEightyUnlocked;
              break;
            case 1:
              flag = !scoreSystem.cloudEightyUnlocked;
              break;
            case 2:
              flag = !scoreSystem.lavaEightyUnlocked;
              break;
            case 3:
              flag = !scoreSystem.meatEightyUnlocked;
              break;
            case 4:
              flag = !scoreSystem.ronEightyUnlocked;
              break;
          }
        }
        if (flag)
        {
          spriteBatch.Draw(Global.selectCatTex, new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 240f), new Rectangle?(new Rectangle(0, 1682, 240, 240)), Color.White, 0.0f, new Vector2(120f, 120f), 1f, SpriteEffects.None, 0.0f);
          if (index == 1 && this.numCats_[currentLevel] == 5)
          {
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[0], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel]) - 1.5), 433.5f), Color.White, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[0]) / 2f, scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[0], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 432f), Color.Black, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[0]) / 2f, scale, SpriteEffects.None, 0.0f);
          }
          if (index == 2 && this.numCats_[currentLevel] == 5 || index == 1 && this.numCats_[currentLevel] == 4 || index == 1 && this.numCats_[currentLevel] == 3)
          {
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[1], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel]) - 1.5), 433.5f), Color.White, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[1]) / 2f, scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[1], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 432f), Color.Black, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[1]) / 2f, scale, SpriteEffects.None, 0.0f);
          }
          if (index == 3 && this.numCats_[currentLevel] == 5 || index == 2 && this.numCats_[currentLevel] == 4 || index == 2 && this.numCats_[currentLevel] == 3)
          {
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[2], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel]) - 1.5), 433.5f), Color.White, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[2]) / 2f, scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[2], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 432f), Color.Black, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[2]) / 2f, scale, SpriteEffects.None, 0.0f);
          }
          if (index == 4 && this.numCats_[currentLevel] == 5 || index == 3 && this.numCats_[currentLevel] == 4 || index == 3 && this.numCats_[currentLevel] == 3)
          {
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[3], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel]) - 1.5), 433.5f), Color.White, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[3]) / 2f, scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(Global.menuFont, this.lockedNames_[3], new Vector2((float) (((double) index + 0.5) * (1280.0 / (double) this.numCats_[currentLevel])), 432f), Color.Black, 0.0f, Global.menuFont.MeasureString(this.lockedNames_[3]) / 2f, scale, SpriteEffects.None, 0.0f);
          }
        }
      }
    }

    public int getCurrentCat() => this.currentCat;

    public void SetLastGameState(GameState gameState) => this.lastGameState = gameState;
  }
}
