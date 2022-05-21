





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Helicopter
{
    public struct ScoreInfo
    {
        public int highScore_;
        public int seaHigh_;
        public int cloudHigh_;
        public int lavaHigh_;
        public int meatHigh_;
        public int ronHigh_;
        public int[] stageIndexes_;
        public int[] catIndexes_;
        public int[] scores_;

        public int HighScore => this.highScore_;

        public bool seaFortyUnlocked => this.seaHigh_ >= 40000;

        public bool seaSixtyUnlocked => this.seaHigh_ >= 60000;

        public bool seaEightyUnlocked => this.seaHigh_ >= 80000;

        public bool cloudFortyUnlocked => this.cloudHigh_ >= 40000;

        public bool cloudSixtyUnlocked => this.cloudHigh_ >= 60000;

        public bool cloudEightyUnlocked => this.cloudHigh_ >= 80000;

        public bool lavaFortyUnlocked => this.lavaHigh_ >= 40000;

        public bool lavaSixtyUnlocked => this.lavaHigh_ >= 60000;

        public bool lavaEightyUnlocked => this.lavaHigh_ >= 80000;

        public bool meatFortyUnlocked => this.meatHigh_ >= 40000;

        public bool meatSixtyUnlocked => this.meatHigh_ >= 60000;

        public bool meatEightyUnlocked => this.meatHigh_ >= 80000;

        public bool ronFortyUnlocked => this.ronHigh_ >= 40000;

        public bool ronSixtyUnlocked => this.ronHigh_ >= 60000;

        public bool ronEightyUnlocked => this.ronHigh_ >= 80000;

        public ScoreInfo(int someInt)
        {
            this.stageIndexes_ = new int[10];
            this.catIndexes_ = new int[10];
            this.scores_ = new int[10];
            this.highScore_ = 0;
            this.seaHigh_ = 0;
            this.cloudHigh_ = 0;
            this.lavaHigh_ = 0;
            this.meatHigh_ = 0;
            this.ronHigh_ = 0;
            this.stageIndexes_[0] = 0;
            this.stageIndexes_[1] = 0;
            this.stageIndexes_[2] = 1;
            this.stageIndexes_[3] = 1;
            this.stageIndexes_[4] = 2;
            this.stageIndexes_[5] = 2;
            this.stageIndexes_[6] = 3;
            this.stageIndexes_[7] = 3;
            this.stageIndexes_[8] = 4;
            this.stageIndexes_[9] = 4;
            this.catIndexes_[0] = 0;
            this.catIndexes_[1] = 1;
            this.catIndexes_[2] = 3;
            this.catIndexes_[3] = 4;
            this.catIndexes_[4] = 6;
            this.catIndexes_[5] = 7;
            this.catIndexes_[6] = 9;
            this.catIndexes_[7] = 10;
            this.catIndexes_[8] = 12;
            this.catIndexes_[9] = 13;
            this.scores_[0] = 0;
            this.scores_[1] = 0;
            this.scores_[2] = 0;
            this.scores_[3] = 0;
            this.scores_[4] = 0;
            this.scores_[5] = 0;
            this.scores_[6] = 0;
            this.scores_[7] = 0;
            this.scores_[8] = 0;
            this.scores_[9] = 0;
        }

        public void AddScore(int stageIndex, int catIndex, int score)
        {
            switch (stageIndex)
            {
                case 0:
                    if (score > this.seaHigh_)
                    {
                        this.seaHigh_ = score;
                        break;
                    }
                    break;
                case 1:
                    if (score > this.cloudHigh_)
                    {
                        this.cloudHigh_ = score;
                        break;
                    }
                    break;
                case 2:
                    if (score > this.lavaHigh_)
                    {
                        this.lavaHigh_ = score;
                        break;
                    }
                    break;
                case 3:
                    if (score > this.meatHigh_)
                    {
                        this.meatHigh_ = score;
                        break;
                    }
                    break;
                case 4:
                    if (score > this.ronHigh_)
                    {
                        this.ronHigh_ = score;
                        break;
                    }
                    break;
            }
            for (int index1 = 0; index1 < 10; ++index1)
            {
                if (score > this.scores_[index1])
                {
                    if (index1 == 0)
                        this.highScore_ = score;
                    for (int index2 = 8; index2 >= index1; --index2)
                    {
                        this.stageIndexes_[index2 + 1] = this.stageIndexes_[index2];
                        this.catIndexes_[index2 + 1] = this.catIndexes_[index2];
                        this.scores_[index2 + 1] = this.scores_[index2];
                    }
                    this.stageIndexes_[index1] = stageIndex;
                    this.catIndexes_[index1] = catIndex;
                    this.scores_[index1] = score;
                    break;
                }
            }
        }

        public static ScoreInfo LoadInfo()
        {
            ScoreInfo scoreInfo;
            if (Global.DeviceManager.Device != null && Global.DeviceManager.Device.IsConnected)
            {
                IAsyncResult result = Global.DeviceManager.Device.BeginOpenContainer("Techno Kitten Adventure", (AsyncCallback)null, (object)null);
                result.AsyncWaitHandle.WaitOne();
                StorageContainer storageContainer = Global.DeviceManager.Device.EndOpenContainer(result);
                result.AsyncWaitHandle.Close();
                string file = nameof(ScoreInfo);
                if (!storageContainer.FileExists(file))
                {
                    scoreInfo = new ScoreInfo(0);
                    storageContainer.Dispose();
                }
                else
                {
                    Stream stream = storageContainer.OpenFile(file, FileMode.Open);
                    scoreInfo = (ScoreInfo)new XmlSerializer(typeof(ScoreInfo)).Deserialize(stream);
                    stream.Close();
                    storageContainer.Dispose();
                }
            }
            else
                scoreInfo = new ScoreInfo(0);
            return scoreInfo;
        }

        public void SaveInfo()
        {
            if (Global.DeviceManager.Device == null || !Global.DeviceManager.Device.IsConnected)
                return;
            IAsyncResult result = Global.DeviceManager.Device.BeginOpenContainer("Techno Kitten Adventure", (AsyncCallback)null, (object)null);
            result.AsyncWaitHandle.WaitOne();
            StorageContainer storageContainer = Global.DeviceManager.Device.EndOpenContainer(result);
            result.AsyncWaitHandle.Close();
            string file1 = nameof(ScoreInfo);
            if (storageContainer.FileExists(file1))
                storageContainer.DeleteFile(file1);
            Stream file2 = storageContainer.CreateFile(file1);
            new XmlSerializer(typeof(ScoreInfo)).Serialize(file2, (object)this);
            file2.Close();
            storageContainer.Dispose();
        }

        public void DrawAllScores(SpriteBatch spriteBatch)
        {
            string[] strArray1 = new string[5]
            {
        "Dream",
        "Cloud",
        "Lava",
        "Meat",
        "Popaganda"
            };
            string[] strArray2 = new string[20]
            {
        "Jet Pack",
        "Byarf",
        "Butterfly",
        "Dream",
        "Mermaid",
        "Baby",
        "Love",
        "Angel",
        "Death",
        "Bat",
        "Fire",
        "Rock",
        "Dragon",
        "Steak",
        "Bacon",
        "HotDog",
        "Burger",
        "Alien",
        "Grin",
        "MC"
            };
            float num1 = 148f;
            float num2 = 51f;
            float y = num1;
            for (int index = 0; index < 10; ++index)
            {
                if (this.stageIndexes_[index] < strArray1.Length)
                    spriteBatch.DrawString(Global.menuFont, strArray1[this.stageIndexes_[index]], new Vector2((float)byte.MaxValue, y), Color.White, 0.0f, Global.menuFont.MeasureString(strArray1[this.stageIndexes_[index]]) / 2f, 1f, SpriteEffects.None, 0.0f);
                if (this.catIndexes_[index] < strArray2.Length)
                    spriteBatch.DrawString(Global.menuFont, strArray2[this.catIndexes_[index]], new Vector2(660f, y), Color.White, 0.0f, Global.menuFont.MeasureString(strArray2[this.catIndexes_[index]]) / 2f, 1f, SpriteEffects.None, 0.0f);
                this.DrawNumber(spriteBatch, this.scores_[index], new Vector2(1034f, y));
                y += num2;
            }
        }

        private void DrawNumber(SpriteBatch spriteBatch, int number, Vector2 startingPosition)
        {
            string str = number.ToString();
            Vector2 origin = new Vector2((float)((double)str.Length * (323.0 / 16.0) / 2.0), 16f);
            for (int index = 0; index < str.Length; ++index)
            {
                int numericValue = (int)char.GetNumericValue(str[index]);
                spriteBatch.Draw(Global.numbersTexture, startingPosition, new Rectangle?(new Rectangle(numericValue * 36, 0, 36, 32)), Color.White, 0.0f, origin, 17f / 32f, SpriteEffects.None, 0.0f);
                startingPosition.X += 323f / 16f;
            }
        }
    }
}
