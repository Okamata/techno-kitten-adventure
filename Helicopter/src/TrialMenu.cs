





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
    internal class TrialMenu : Menu
    {
        private float startTimer;
        private bool canBuyGame;

        public TrialMenu()
          : base(true)
        {
        }

        public void Update(float dt, InputState currInput, ref GameState gameState)
        {
            this.startTimer += dt;
            if ((double)this.startTimer <= 1.0)
                return;
            this.Update(dt, currInput);
            if (currInput.IsButtonPressed(Buttons.A))
            {
                Global.PlayCatSound();
                switch (this.index_)
                {
                    case 0:
                        if (this.canBuyGame)
                        {
                            //if (Global.IsTrialMode && Global.CanBuyGame())
                            //{
                            //    Guide.ShowMarketplace(Global.playerIndex.Value);
                            //    break;
                            //}
                            break;
                        }
                        this.index_ = 0;
                        gameState = GameState.MAIN_MENU;
                        break;
                    case 1:
                        this.index_ = 0;
                        gameState = GameState.MAIN_MENU;
                        break;
                }
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            this.canBuyGame = Global.IsTrialMode && Global.CanBuyGame();
            if (this.canBuyGame && (this.menuItems_.Count == 1 || this.menuItems_.Count == 0))
            {
                this.menuItems_.Clear();
                this.index_ = 0;
                this.AddMenuItem(new MenuItem(Global.trialTex, new Rectangle(0, 558, 379, 106), new Vector2(438.5f, 557f)));
                this.AddMenuItem(new MenuItem(Global.trialTex, new Rectangle(380, 558, 379, 106), new Vector2(841.5f, 557f)));
                this.SetItemVertices();
            }
            if (!this.canBuyGame && (this.menuItems_.Count == 2 || this.menuItems_.Count == 0))
            {
                this.menuItems_.Clear();
                this.index_ = 0;
                this.AddMenuItem(new MenuItem(Global.trialTex, new Rectangle(380, 558, 379, 106), new Vector2(841.5f, 557f)));
                this.SetItemVertices();
            }
            this.DrawBackground(spriteBatch);
            base.Draw(spriteBatch);
        }

        private void DrawBackground(SpriteBatch spriteBatch) => spriteBatch.Draw(Global.trialTex, new Vector2(222f, 82f), new Rectangle?(new Rectangle(0, 0, 836, 556)), Color.White);

        public void ResetStartTimer() => this.startTimer = 0.0f;
    }
}
