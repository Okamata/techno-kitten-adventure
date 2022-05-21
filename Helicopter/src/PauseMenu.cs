





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
    internal class PauseMenu : Menu
    {
        private bool canBuyGame;

        public PauseMenu()
          : base(false)
        {
        }

        public void Update(float dt, InputState currInput, ref GameState gameState)
        {
            this.Update(dt, currInput);
            if (currInput.IsButtonPressed(Buttons.Start) || currInput.IsButtonPressed(Buttons.B))
            {
                Global.PlayCatSound();
                gameState = GameState.PLAY;
                this.index_ = 0;
            }
            if (!currInput.IsButtonPressed(Buttons.A))
                return;
            Global.PlayCatSound();
            switch (this.index_)
            {
                case 0:
                    this.index_ = 0;
                    gameState = GameState.PLAY;
                    break;
                case 1:
                    this.index_ = 0;
                    gameState = GameState.OPTIONS;
                    break;
                case 2:
                    this.index_ = 0;
                    gameState = GameState.STAGE_SELECT;
                    break;
                case 3:
                    this.index_ = 0;
                    gameState = GameState.CAT_SELECT;
                    break;
                case 4:
                    this.index_ = 0;
                    gameState = GameState.LEADERBOARDS;
                    break;
                case 5:
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
                case 6:
                    this.index_ = 0;
                    gameState = GameState.MAIN_MENU;
                    break;
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            this.canBuyGame = Global.IsTrialMode && Global.CanBuyGame();
            if (this.canBuyGame && (this.menuItems_.Count == 6 || this.menuItems_.Count == 0))
            {
                this.menuItems_.Clear();
                this.index_ = 0;
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(0, 612, 207, 34), new Vector2(640f, 140f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(211, 558, 168, 25), new Vector2(640f, 197.2f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(381, 558, 290, 25), new Vector2(640f, 249.8f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(0, 585, 312, 25), new Vector2(640f, 302.5f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(314, 585, 245, 25), new Vector2(640f, 355.2f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(561, 585, 78, 25), new Vector2(640f, 407.8f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(0, 558, 209, 25), new Vector2(640f, 460.5f)));
                this.SetItemVertices();
            }
            if (!this.canBuyGame && (this.menuItems_.Count == 7 || this.menuItems_.Count == 0))
            {
                this.menuItems_.Clear();
                this.index_ = 0;
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(0, 612, 207, 34), new Vector2(640f, 160f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(211, 558, 168, 25), new Vector2(640f, 217.2f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(381, 558, 290, 25), new Vector2(640f, 269.8f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(0, 585, 312, 25), new Vector2(640f, 322.5f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(314, 585, 245, 25), new Vector2(640f, 375.2f)));
                this.AddMenuItem(new MenuItem(Global.pauseTex, new Rectangle(0, 558, 209, 25), new Vector2(640f, 427.8f)));
                this.SetItemVertices();
            }
            this.DrawBackground(spriteBatch);
            base.Draw(spriteBatch);
        }

        private void DrawBackground(SpriteBatch spriteBatch) => spriteBatch.Draw(Global.pauseTex, new Vector2(222f, 82f), new Rectangle?(new Rectangle(0, 0, 836, 556)), Color.White);
    }
}
