





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
    internal class MainMenu : Menu
    {
        private bool canBuyGame;
        private float shineRotation;
        private int titleAnimFrame;
        private float titleAnimTime;
        private float titleAnimTimer;
        private int titleAnimNumFrames;
        private int catAnimFrame;
        private float catAnimTime;
        private float catAnimTimer;
        private int catAnimNumFrames;
        private Vector2[] starPositions = new Vector2[13];
        private float[] starRotations = new float[13];
        private float[] starScales = new float[13];
        private Vector2[] starScaleInfos = new Vector2[13];
        private float[] starScaleRates = new float[13];

        public MainMenu()
          : base(true)
        {
            this.shineRotation = 2.317797f;
            this.titleAnimFrame = 0;
            this.titleAnimTime = 0.03333334f;
            this.titleAnimTimer = 0.0f;
            this.titleAnimNumFrames = 20;
            this.catAnimFrame = 0;
            this.catAnimTime = 0.03333334f;
            this.catAnimTimer = 0.0f;
            this.catAnimNumFrames = 9;
            this.starPositions[0] = new Vector2(90f, 148f);
            this.starPositions[1] = new Vector2(224f, 58f);
            this.starPositions[2] = new Vector2(420f, -6f);
            this.starPositions[3] = new Vector2(370f, 74f);
            this.starPositions[4] = new Vector2(506f, 40f);
            this.starPositions[5] = new Vector2(666f, 80f);
            this.starPositions[6] = new Vector2(766f, 28f);
            this.starPositions[7] = new Vector2(1002f, -4f);
            this.starPositions[8] = new Vector2(1144f, 50f);
            this.starPositions[9] = new Vector2(1020f, 94f);
            this.starPositions[10] = new Vector2(1156f, 202f);
            this.starPositions[11] = new Vector2(1068f, 216f);
            this.starPositions[12] = new Vector2(1202f, 286f);
            this.starRotations[0] = 0.523599f;
            this.starRotations[1] = 0.349066f;
            this.starRotations[2] = 0.087266f;
            this.starRotations[3] = 0.0f;
            this.starRotations[4] = 0.314159f;
            this.starRotations[5] = 0.575959f;
            this.starRotations[6] = 0.523599f;
            this.starRotations[7] = 0.5236f;
            this.starRotations[8] = -0.2618f;
            this.starRotations[9] = 0.36652f;
            this.starRotations[10] = 0.31416f;
            this.starRotations[11] = 0.5236f;
            this.starRotations[12] = 0.13963f;
            this.starScales[0] = 0.6f;
            this.starScales[1] = 0.766f;
            this.starScales[2] = 0.68f;
            this.starScales[3] = 1f;
            this.starScales[4] = 0.933f;
            this.starScales[5] = 0.77f;
            this.starScales[6] = 0.47f;
            this.starScales[7] = 0.572f;
            this.starScales[8] = 0.755f;
            this.starScales[9] = 0.852f;
            this.starScales[10] = 0.441f;
            this.starScales[11] = 0.608f;
            this.starScales[12] = 0.458f;
            this.starScaleInfos[0] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[1] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[2] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[3] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[4] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[5] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[6] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[7] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[8] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[9] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[10] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[11] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleInfos[12] = new Vector2(Global.RandomBetween(0.0f, 0.4f), Global.RandomBetween(0.6f, 1f));
            this.starScaleRates[0] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[1] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[2] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[3] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[4] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[5] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[6] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[7] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[8] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[9] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[10] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[11] = Global.RandomBetween(1.25f, 2.5f);
            this.starScaleRates[12] = Global.RandomBetween(1.25f, 2.5f);
        }

        public void Update(float dt, InputState currInput, ref GameState gameState)
        {
            this.UpdateBackground(dt);
            this.Update(dt, currInput);
            if (!currInput.IsButtonPressed(Buttons.A))
                return;
            Global.PlayCatSound();
            switch (this.index_)
            {
                case 0:
                    this.index_ = 0;
                    gameState = GameState.STAGE_SELECT;
                    break;
                case 1:
                    this.index_ = 0;
                    gameState = GameState.OPTIONS;
                    break;
                case 2:
                    this.index_ = 0;
                    gameState = GameState.LEADERBOARDS;
                    break;
                case 3:
                    if (this.canBuyGame)
                    {
                        if (Global.IsTrialMode && Global.CanBuyGame())
                        {
                            Guide.ShowMarketplace(Global.playerIndex.Value);
                            break;
                        }
                        break;
                    }
                    gameState = GameState.EXIT;
                    break;
                case 4:
                    gameState = GameState.EXIT;
                    break;
            }
        }

        public void UpdateBackground(float dt)
        {
            this.shineRotation += 0.464f * dt;
            this.titleAnimTimer += dt;
            if ((double)this.titleAnimTimer > (double)this.titleAnimTime)
            {
                this.titleAnimFrame = (this.titleAnimFrame + 1) % this.titleAnimNumFrames;
                this.titleAnimTimer = 0.0f;
            }
            this.catAnimTimer += dt;
            if ((double)this.catAnimTimer > (double)this.catAnimTime)
            {
                this.catAnimFrame = (this.catAnimFrame + 1) % this.catAnimNumFrames;
                this.catAnimTimer = 0.0f;
            }
            for (int index = 0; index < this.starPositions.Length; ++index)
            {
                this.starScales[index] += this.starScaleRates[index] * dt;
                if ((double)this.starScales[index] < (double)this.starScaleInfos[index].X)
                {
                    this.starScales[index] = this.starScaleInfos[index].X;
                    this.starScaleRates[index] = -this.starScaleRates[index];
                }
                else if ((double)this.starScales[index] > (double)this.starScaleInfos[index].Y)
                {
                    this.starScales[index] = this.starScaleInfos[index].Y;
                    this.starScaleRates[index] = -this.starScaleRates[index];
                }
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            this.canBuyGame = Global.IsTrialMode && Global.CanBuyGame();
            if (this.canBuyGame && (this.menuItems_.Count == 4 || this.menuItems_.Count == 0))
            {
                this.menuItems_.Clear();
                this.index_ = 0;
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1134, 722, 169, 42), new Vector2(204f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1134, 766, 284, 42), new Vector2(450f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1132, 810, 211, 42), new Vector2(718f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1132, 854, 126, 43), new Vector2(907f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1132, 899, 156, 42), new Vector2(1068f, 600f)));
                this.SetItemVertices();
            }
            if (!this.canBuyGame && (this.menuItems_.Count == 5 || this.menuItems_.Count == 0))
            {
                this.menuItems_.Clear();
                this.index_ = 0;
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1134, 722, 169, 42), new Vector2(207f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1134, 766, 284, 42), new Vector2(505f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1132, 810, 211, 42), new Vector2(824f, 600f)));
                this.AddMenuItem(new MenuItem(Global.mainTex, new Rectangle(1132, 899, 156, 42), new Vector2(1080f, 600f)));
                this.SetItemVertices();
            }
            this.DrawBackground(spriteBatch);
            base.Draw(spriteBatch);
        }

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Global.mainTex, Vector2.Zero, new Rectangle?(new Rectangle(0, 0, 1280, 720)), Color.White);
            spriteBatch.Draw(Global.mainCircleTex, new Vector2(820f, 288f), new Rectangle?(), Color.White, this.shineRotation, new Vector2(927f, 927f), 1f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(Global.mainTex, new Vector2(74f, 0.0f), new Rectangle?(new Rectangle(0, 720, 1132, 489)), Color.White);
            spriteBatch.Draw(Global.mainCatTex, new Vector2(820f, 288f), new Rectangle?(new Rectangle(this.catAnimFrame % 3 * 445, this.catAnimFrame / 3 * 319 + 1, 445, 318)), Color.White, 0.0f, new Vector2(222.5f, 159.5f), 1f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(Global.mainTitleTex, new Vector2(200f, 222f), new Rectangle?(new Rectangle(this.titleAnimFrame % 4 * 816, this.titleAnimFrame / 4 * 320, 816, 320)), Color.White);
            for (int index = 0; index < this.starPositions.Length; ++index)
                spriteBatch.Draw(Global.mainStarTex, this.starPositions[index], new Rectangle?(), Color.White, this.starRotations[index], new Vector2(20.5f, 20f), this.starScales[index], SpriteEffects.None, 0.0f);
        }
    }
}
