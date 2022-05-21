





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
    public class Tunnel
    {
        private bool visible_ = true;
        private TunnelEffects tunnelEffects_;
        private Color normalColor;
        private Color BColor;
        private Color WColor;
        public float velocity = 476f;
        private Vector2[] vertices;
        private Vector2[] vertices2;
        private int[] animFrames;
        private int animOffset;
        private float animTimer = 0.0f;
        private float animTime = 0.04166666f;
        private int[] symbolIndexes;
        private Vector2[][] symbolLineInfo;
        private Rectangle[][] symbolCollisionRects;
        private int firstIndex;
        private int lastIndex;
        private int width;
        private int width2;
        private int lineWidth = 3;
        private int height = 500;
        private int minHeight = 350;
        private float a;
        private float b;
        private float c;
        private float d;
        private float x;
        private float maxSlope = 2f;
        private TunnelEffect effect;
        private int colorIndex;
        private float t2 = 0.0f;
        private float t;

        public Tunnel(int _num, int _num2)
        {
            this.tunnelEffects_ = new TunnelEffects();
            this.Reset(_num, _num2);
            this.animFrames = new int[_num + 1];
            for (int index = 0; index <= _num; ++index)
                this.animFrames[index] = Global.Random.Next(18);
            this.symbolIndexes = new int[3];
            for (int index = 0; index < this.symbolIndexes.Length; ++index)
                this.symbolIndexes[index] = Global.Random.Next(10);
            this.symbolLineInfo = new Vector2[10][]
            {
        new Vector2[16]
        {
          new Vector2(50f, 88f),
          new Vector2(32f, 69f),
          new Vector2(13f, 57f),
          new Vector2(6f, 45f),
          new Vector2(6f, 29f),
          new Vector2(14f, 15f),
          new Vector2(28f, 11f),
          new Vector2(42f, 16f),
          new Vector2(50f, 27f),
          new Vector2(58f, 16f),
          new Vector2(72f, 11f),
          new Vector2(86f, 15f),
          new Vector2(94f, 29f),
          new Vector2(94f, 45f),
          new Vector2(87f, 57f),
          new Vector2(68f, 69f)
        },
        new Vector2[4]
        {
          new Vector2(14f, 14f),
          new Vector2(86f, 14f),
          new Vector2(86f, 86f),
          new Vector2(14f, 86f)
        },
        new Vector2[10]
        {
          new Vector2(2f, 37f),
          new Vector2(33f, 32f),
          new Vector2(50f, 4f),
          new Vector2(66f, 32f),
          new Vector2(98f, 37f),
          new Vector2(74f, 61f),
          new Vector2(78f, 92f),
          new Vector2(50f, 79f),
          new Vector2(21f, 92f),
          new Vector2(24f, 61f)
        },
        new Vector2[29]
        {
          new Vector2(9f, 52f),
          new Vector2(10f, 41f),
          new Vector2(13f, 31f),
          new Vector2(21f, 21f),
          new Vector2(30f, 15f),
          new Vector2(40f, 11f),
          new Vector2(48f, 9f),
          new Vector2(54f, 10f),
          new Vector2(62f, 11f),
          new Vector2(72f, 14f),
          new Vector2(80f, 20f),
          new Vector2(88f, 31f),
          new Vector2(91f, 42f),
          new Vector2(92f, 51f),
          new Vector2(83f, 47f),
          new Vector2(73f, 52f),
          new Vector2(64f, 47f),
          new Vector2(54f, 52f),
          new Vector2(54f, 85f),
          new Vector2(48f, 93f),
          new Vector2(40f, 93f),
          new Vector2(32f, 88f),
          new Vector2(35f, 81f),
          new Vector2(41f, 86f),
          new Vector2(46f, 80f),
          new Vector2(46f, 52f),
          new Vector2(36f, 47f),
          new Vector2(27f, 52f),
          new Vector2(19f, 46f)
        },
        new Vector2[5]
        {
          new Vector2(75f, 90f),
          new Vector2(25f, 90f),
          new Vector2(9f, 42f),
          new Vector2(49f, 12f),
          new Vector2(89f, 42f)
        },
        new Vector2[3]
        {
          new Vector2(6f, 82f),
          new Vector2(50f, 8f),
          new Vector2(94f, 82f)
        },
        new Vector2[7]
        {
          new Vector2(5f, 25f),
          new Vector2(5f, 75f),
          new Vector2(50f, 75f),
          new Vector2(50f, 95f),
          new Vector2(95f, 50f),
          new Vector2(50f, 5f),
          new Vector2(50f, 25f)
        },
        new Vector2[12]
        {
          new Vector2(10f, 50f),
          new Vector2(15f, 30f),
          new Vector2(30f, 15f),
          new Vector2(50f, 10f),
          new Vector2(70f, 15f),
          new Vector2(85f, 30f),
          new Vector2(90f, 50f),
          new Vector2(85f, 70f),
          new Vector2(70f, 85f),
          new Vector2(50f, 90f),
          new Vector2(30f, 85f),
          new Vector2(15f, 70f)
        },
        new Vector2[6]
        {
          new Vector2(5f, 50f),
          new Vector2(28f, 10f),
          new Vector2(74f, 10f),
          new Vector2(95f, 50f),
          new Vector2(74f, 90f),
          new Vector2(28f, 90f)
        },
        new Vector2[16]
        {
          new Vector2(9f, 69f),
          new Vector2(22f, 74f),
          new Vector2(39f, 73f),
          new Vector2(57f, 58f),
          new Vector2(62f, 40f),
          new Vector2(57f, 22f),
          new Vector2(40f, 7f),
          new Vector2(57f, 6f),
          new Vector2(77f, 15f),
          new Vector2(91f, 33f),
          new Vector2(93f, 58f),
          new Vector2(87f, 76f),
          new Vector2(69f, 91f),
          new Vector2(49f, 95f),
          new Vector2(28f, 90f),
          new Vector2(15f, 80f)
        }
            };
            this.symbolCollisionRects = new Rectangle[10][]
            {
        new Rectangle[8]
        {
          new Rectangle(17, 12, 22, 7),
          new Rectangle(10, 19, 34, 28),
          new Rectangle(21, 47, 60, 15),
          new Rectangle(31, 62, 41, 12),
          new Rectangle(41, 74, 18, 11),
          new Rectangle(44, 22, 12, 25),
          new Rectangle(56, 18, 34, 29),
          new Rectangle(62, 12, 22, 6)
        },
        new Rectangle[1]{ new Rectangle(14, 14, 72, 72) },
        new Rectangle[9]
        {
          new Rectangle(23, 82, 13, 8),
          new Rectangle(63, 82, 14, 8),
          new Rectangle(25, 54, 50, 28),
          new Rectangle(17, 47, 66, 7),
          new Rectangle(10, 39, 80, 8),
          new Rectangle(30, 35, 43, 4),
          new Rectangle(37, 25, 8, 10),
          new Rectangle(45, 12, 10, 23),
          new Rectangle(55, 25, 8, 10)
        },
        new Rectangle[7]
        {
          new Rectangle(42, 11, 22, 4),
          new Rectangle(37, 15, 38, 5),
          new Rectangle(24, 20, 54, 7),
          new Rectangle(19, 27, 65, 9),
          new Rectangle(14, 36, 75, 13),
          new Rectangle(44, 49, 12, 39),
          new Rectangle(34, 83, 10, 11)
        },
        new Rectangle[5]
        {
          new Rectangle(15, 39, 69, 19),
          new Rectangle(19, 59, 61, 13),
          new Rectangle(26, 73, 48, 16),
          new Rectangle(29, 28, 40, 10),
          new Rectangle(41, 19, 6, 8)
        },
        new Rectangle[8]
        {
          new Rectangle(15, 75, 71, 6),
          new Rectangle(20, 64, 61, 11),
          new Rectangle(26, 54, 49, 10),
          new Rectangle(31, 45, 39, 9),
          new Rectangle(36, 35, 30, 10),
          new Rectangle(39, 26, 24, 9),
          new Rectangle(44, 17, 14, 9),
          new Rectangle(48, 11, 6, 6)
        },
        new Rectangle[7]
        {
          new Rectangle(53, 85, 2, 6),
          new Rectangle(52, 75, 9, 9),
          new Rectangle(79, 42, 8, 16),
          new Rectangle(73, 34, 5, 33),
          new Rectangle(52, 9, 2, 7),
          new Rectangle(6, 26, 66, 48),
          new Rectangle(52, 16, 9, 9)
        },
        new Rectangle[7]
        {
          new Rectangle(11, 45, 78, 12),
          new Rectangle(14, 33, 72, 12),
          new Rectangle(21, 24, 58, 12),
          new Rectangle(38, 12, 24, 12),
          new Rectangle(14, 57, 72, 12),
          new Rectangle(21, 69, 58, 12),
          new Rectangle(38, 81, 24, 10)
        },
        new Rectangle[7]
        {
          new Rectangle(11, 42, 6, 15),
          new Rectangle(17, 30, 6, 40),
          new Rectangle(23, 27, 7, 57),
          new Rectangle(30, 13, 43, 74),
          new Rectangle(73, 22, 7, 56),
          new Rectangle(80, 31, 6, 36),
          new Rectangle(86, 44, 5, 12)
        },
        new Rectangle[9]
        {
          new Rectangle(45, 8, 6, 7),
          new Rectangle(51, 10, 9, 12),
          new Rectangle(60, 12, 12, 60),
          new Rectangle(72, 19, 9, 13),
          new Rectangle(72, 32, 16, 41),
          new Rectangle(48, 61, 12, 11),
          new Rectangle(14, 72, 68, 8),
          new Rectangle(19, 80, 54, 8),
          new Rectangle(32, 88, 29, 5)
        }
            };
        }

        public void Update(
          float dt,
          Helicopter helicopter,
          ScoreSystem scoreSystem,
          int stageIndex,
          int catIndex)
        {
            this.t2 += dt;
            this.animTimer += dt;
            if ((double)this.animTimer > (double)this.animTime)
            {
                this.animTimer = 0.0f;
                this.animOffset = (this.animOffset + 1) % 18;
            }
            if (!this.IsOn() && !helicopter.IsDead())
                this.Reset(40, 3);
            if (this.IsOn())
            {
                this.Collides(helicopter, scoreSystem, stageIndex, catIndex);
                this.t += dt;
                if ((double)this.t > 0.5)
                {
                    if (this.height > this.minHeight)
                        --this.height;
                    this.t = 0.0f;
                }
                this.Shift(dt);
            }
            switch (this.effect)
            {
                case TunnelEffect.Normal:
                    Global.tunnelColor = this.normalColor;
                    break;
                case TunnelEffect.Rainbow:
                    this.colorIndex = (this.colorIndex + 1) % 6;
                    Global.tunnelColor = Global.rainbowColors[this.colorIndex];
                    break;
                case TunnelEffect.RainbowPunctuated:
                    if ((double)this.t2 > (double)Global.BPM)
                    {
                        this.colorIndex = (this.colorIndex + 3) % 8;
                        Global.tunnelColor = Global.rainbowColors8[this.colorIndex];
                        this.t2 = 0.0f;
                        break;
                    }
                    break;
                case TunnelEffect.BW:
                    if ((double)this.t2 > (double)Global.BPM)
                    {
                        Global.tunnelColor = !(Global.tunnelColor == this.WColor) ? this.WColor : this.BColor;
                        this.t2 = 0.0f;
                        break;
                    }
                    break;
                case TunnelEffect.BWDouble:
                    if ((double)this.t2 > (double)Global.BPM / 2.0)
                    {
                        Global.tunnelColor = !(Global.tunnelColor == this.WColor) ? this.WColor : this.BColor;
                        this.t2 = 0.0f;
                        break;
                    }
                    break;
                case TunnelEffect.BWQuad:
                    if ((double)this.t2 > (double)Global.BPM / 4.0)
                    {
                        Global.tunnelColor = !(Global.tunnelColor == this.WColor) ? this.WColor : this.BColor;
                        this.t2 = 0.0f;
                        break;
                    }
                    break;
                case TunnelEffect.Disappear:
                    if ((double)this.t2 > (double)Global.BPM)
                    {
                        this.visible_ = !this.visible_;
                        this.t2 = 0.0f;
                        break;
                    }
                    break;
            }
            this.tunnelEffects_.UpdateTunnel(dt, this.vertices, (float)this.width, (float)this.height, this.velocity);
            this.tunnelEffects_.UpdateSymbols(dt, this.vertices2, this.symbolLineInfo[this.symbolIndexes[0]], this.symbolLineInfo[this.symbolIndexes[1]], this.symbolLineInfo[this.symbolIndexes[2]], this.velocity);
        }

        private void Shift(float dt)
        {
            for (int index = 0; index < this.vertices.Length; ++index)
                this.vertices[index].X -= this.velocity * dt;
            for (int index = 0; index < this.vertices2.Length; ++index)
            {
                this.vertices2[index].X -= this.velocity * dt;
                if ((double)this.vertices2[index].X < (double)-this.width2)
                {
                    this.vertices2[index].X = Math.Max(this.vertices2[(index + 1) % 3].X, this.vertices2[(index + 2) % 3].X) + 500f;
                    this.symbolIndexes[index] = Global.Random.Next(10);
                    this.vertices2[index].Y = this.GenerateBlock(this.vertices[this.lastIndex].Y);
                }
            }
            if ((double)this.vertices[this.firstIndex].X >= (double)-this.width)
                return;
            this.vertices[this.firstIndex].X = this.vertices[this.lastIndex].X + (float)this.width;
            this.vertices[this.firstIndex].Y = this.GenerateHeight(this.vertices[this.lastIndex].Y, (float)(648 - this.height) - this.vertices[this.lastIndex].Y);
            this.lastIndex = this.firstIndex;
            this.firstIndex = (this.firstIndex + 1) % this.vertices.Length;
        }

        private float GenerateHeight(float dH1, float dH2)
        {
            this.x += (float)this.width;
            if ((double)this.x > (double)this.c)
            {
                this.x = 0.0f;
                this.d = dH1;
                this.c = (float)(Global.Random.Next(3, 640 / this.width) * this.width);
                this.b = 3.141593f / this.c;
                float num1 = (float)(-(double)dH1 + 72.0);
                float num2 = dH2;
                this.a = Global.RandomBetween((double)num1 > -(double)this.maxSlope / (double)this.b ? num1 : -this.maxSlope / this.b, (double)num2 < (double)this.maxSlope / (double)this.b ? num2 : this.maxSlope / this.b);
            }
            return this.d + (float)((double)this.a * (Math.Cos((double)this.b * (double)this.x + Math.PI) + 1.0) / 2.0);
        }

        private float GenerateBlock(float dH1) => dH1 + Global.RandomBetween(0.0f, (float)(this.height - 100));

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.visible_)
                return;
            this.tunnelEffects_.Draw(spriteBatch);
        }

        private void DrawRectangle(SpriteBatch spriteBatch, Vector2 position_, Rectangle rect_)
        {
            spriteBatch.Draw(Global.pixel, new Rectangle((int)position_.X + rect_.X, (int)position_.Y + rect_.Y, rect_.Width, this.lineWidth), Global.tunnelColor);
            spriteBatch.Draw(Global.pixel, new Rectangle((int)position_.X + rect_.X, (int)position_.Y + rect_.Y + rect_.Height, rect_.Width, this.lineWidth), Global.tunnelColor);
            spriteBatch.Draw(Global.pixel, new Rectangle((int)position_.X + rect_.X, (int)position_.Y + rect_.Y, this.lineWidth, rect_.Height), Global.tunnelColor);
            spriteBatch.Draw(Global.pixel, new Rectangle((int)position_.X + rect_.X + rect_.Width, (int)position_.Y + rect_.Y, this.lineWidth, rect_.Height), Global.tunnelColor);
        }

        public void Reset(int _num, int _num2)
        {
            this.t = 0.0f;
            this.height = 500;
            this.width = 1280 / _num;
            this.width2 = 100;
            this.vertices = new Vector2[_num + 1];
            for (int index = 0; index <= _num; ++index)
                this.vertices[index] = new Vector2((float)(index * this.width), 72f);
            this.firstIndex = 0;
            this.lastIndex = _num;
            this.vertices2 = new Vector2[_num2];
            for (int index = 0; index < _num2; ++index)
                this.vertices2[index] = new Vector2((float)(1280 + index * 500), this.GenerateBlock(72f));
            this.velocity = 0.0f;
            this.a = 0.0f;
            this.b = 0.0f;
            this.c = 0.0f;
            this.d = 0.0f;
            this.x = 0.0f;
            if (this.effect == TunnelEffect.Disappear)
                return;
            this.visible_ = true;
        }

        public void TurnOn() => this.velocity = 476f;

        public void TurnOff() => this.velocity = 0.0f;

        public bool IsOn() => (double)this.velocity != 0.0;

        public void Set(TunnelEffect tunnelEffect)
        {
            this.effect = tunnelEffect;
            this.t2 = 0.0f;
            this.visible_ = true;
        }

        public void SetColor(Color normalColor, Color bColor, Color wColor)
        {
            this.normalColor = normalColor;
            this.BColor = bColor;
            this.WColor = wColor;
        }

        private void Collides(
          Helicopter helicopter,
          ScoreSystem scoreSystem,
          int stageIndex,
          int catIndex)
        {
            if (helicopter.IsDead())
                return;
            for (int index1 = 0; index1 < this.vertices2.Length; ++index1)
            {
                for (int index2 = 0; index2 < this.symbolCollisionRects[this.symbolIndexes[index1]].Length; ++index2)
                {
                    if (new Rectangle((int)this.vertices2[index1].X + this.symbolCollisionRects[this.symbolIndexes[index1]][index2].X, (int)this.vertices2[index1].Y + this.symbolCollisionRects[this.symbolIndexes[index1]][index2].Y, this.symbolCollisionRects[this.symbolIndexes[index1]][index2].Width, this.symbolCollisionRects[this.symbolIndexes[index1]][index2].Height).Intersects(helicopter.CollisionRect))
                    {
                        helicopter.Kill();
                        Global.SetVibrationTemp(true);
                        this.velocity = 0.0f;
                        scoreSystem.End(stageIndex, catIndex);
                        return;
                    }
                }
            }
            float x = this.vertices[this.firstIndex].X;
            int num1 = (int)(((double)helicopter.CollisionRect.X - (double)x) / (double)this.width);
            int num2 = (int)(((double)(helicopter.CollisionRect.X + helicopter.CollisionRect.Width) - (double)x) / (double)this.width);
            for (int index = num1; index <= num2; ++index)
            {
                if ((double)this.vertices[(this.firstIndex + index) % this.vertices.Length].Y > (double)helicopter.CollisionRect.Y || (double)this.vertices[(this.firstIndex + index) % this.vertices.Length].Y + (double)this.height < (double)(helicopter.CollisionRect.Y + helicopter.CollisionRect.Height))
                {
                    helicopter.Kill();
                    Global.SetVibrationTemp(true);
                    this.velocity = 0.0f;
                    scoreSystem.End(stageIndex, catIndex);
                    break;
                }
            }
        }
    }
}
