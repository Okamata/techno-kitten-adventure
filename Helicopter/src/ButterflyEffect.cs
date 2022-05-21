using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
    public class ButterflyEffect
    {
        private bool active1_;
        private bool active2_;
        private ButterflyParticle[] butterflyParticles_ = new ButterflyParticle[160];
        private float eventTimer_;
        private int currEvent_;
        private float[] eventTimes_ = new float[13];
        private float emmitTimer_;
        private float emmitTime_;
        private float spamTimer_;
        private float spamDuration_ = 1.07657f;
        private float restDuration_ = 0.28f;
        private float emmitterRotation_;
        private float emmitterRotationRate_;

        public ButterflyEffect()
        {
            for (int index = 0; index < this.butterflyParticles_.Length; ++index)
                this.butterflyParticles_[index] = new ButterflyParticle();
            this.eventTimes_[0] = 0.0f;
            this.eventTimes_[1] = 1.356f;
            this.eventTimes_[2] = 2.713f;
            this.eventTimes_[3] = 5.458f;
            this.eventTimes_[4] = 6.822f;
            this.eventTimes_[5] = 8.195f;
            this.eventTimes_[6] = 10.253f;
            this.eventTimes_[7] = 10.948f;
            this.eventTimes_[8] = 12.32f;
            this.eventTimes_[9] = 13.693f;
            this.eventTimes_[10] = 16.43f;
            this.eventTimes_[11] = 17.786f;
            this.eventTimes_[12] = 19.175f;
        }

        public void Update(float dt, Vector2 catPosition)
        {
            if (this.active1_)
            {
                this.eventTimer_ += dt;
                if ((double)this.eventTimer_ > (double)this.eventTimes_[this.currEvent_])
                {
                    this.CreateButterflies();
                    ++this.currEvent_;
                    if (this.currEvent_ >= this.eventTimes_.Length)
                        this.active1_ = false;
                }
            }
            if (this.active2_)
            {
                this.spamTimer_ += dt;
                this.emmitterRotation_ += this.emmitterRotationRate_ * dt;
                if ((double)this.spamTimer_ < (double)this.spamDuration_)
                {
                    this.emmitTimer_ += dt;
                    if ((double)this.emmitTimer_ > (double)this.emmitTime_)
                    {
                        this.EmmitButterflyNotAttracted(catPosition, 400f * new Vector2((float)Math.Cos((double)this.emmitterRotation_), (float)Math.Sin((double)this.emmitterRotation_)));
                        this.emmitTimer_ = 0.0f;
                    }
                }
                else if ((double)this.spamTimer_ > (double)this.spamDuration_ + (double)this.restDuration_)
                    this.spamTimer_ = 0.0f;
            }
            for (int index = 0; index < this.butterflyParticles_.Length; ++index)
                this.butterflyParticles_[index].Update(dt, catPosition);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < this.butterflyParticles_.Length; ++index)
                this.butterflyParticles_[index].Draw(spriteBatch);
        }

        public void TurnOn1()
        {
            this.active1_ = true;
            this.eventTimer_ = 0.0f;
            this.currEvent_ = 0;
        }

        public void TurnOn2()
        {
            this.active2_ = true;
            this.spamTimer_ = 0.0f;
            this.emmitterRotation_ = 0.0f;
            this.emmitterRotationRate_ = 6.283185f;
            this.emmitTimer_ = 0.0f;
            this.emmitTime_ = 0.05f;
        }

        public void TurnOff2() => this.active2_ = false;

        private void CreateButterflies()
        {
            for (int index1 = 0; index1 < 4; ++index1)
            {
                Vector2 vector2_1;
                Vector2 vector2_2;
                int num1;
                if (index1 == 0)
                {
                    vector2_1 = Vector2.Zero;
                    vector2_2 = new Vector2(1280f, 0.0f);
                    num1 = 13;
                }
                else if (index1 == 1)
                {
                    vector2_1 = new Vector2(1280f, 0.0f);
                    vector2_2 = new Vector2(1280f, 720f);
                    num1 = 7;
                }
                else if (index1 == 2)
                {
                    vector2_1 = new Vector2(1280f, 720f);
                    vector2_2 = new Vector2(0.0f, 720f);
                    num1 = 13;
                }
                else
                {
                    vector2_1 = new Vector2(0.0f, 720f);
                    vector2_2 = Vector2.Zero;
                    num1 = 7;
                }
                float num2 = Vector2.Distance(vector2_1, vector2_2) / (float)num1;
                Vector2 vector2_3 = Vector2.Normalize(vector2_2 - vector2_1);
                vector2_1 += vector2_3 * (num2 / 2f);
                for (int index2 = 0; index2 < num1; ++index2)
                    this.EmmitButterflyAttracted(vector2_1 + vector2_3 * num2 * (float)index2);
            }
        }

        private void EmmitButterflyAttracted(Vector2 position)
        {
            for (int index = 0; index < this.butterflyParticles_.Length; ++index)
            {
                if (!this.butterflyParticles_[index].active_)
                {
                    this.butterflyParticles_[index].Reset(position, Vector2.Zero, 1f, 0.0f, true);
                    break;
                }
            }
        }

        private void EmmitButterflyNotAttracted(Vector2 position, Vector2 velocity)
        {
            for (int index = 0; index < this.butterflyParticles_.Length; ++index)
            {
                if (!this.butterflyParticles_[index].active_)
                {
                    this.butterflyParticles_[index].Reset(position, velocity, 1f, 0.0f, false);
                    break;
                }
            }
        }

        public void Reset()
        {
            for (int index = 0; index < this.butterflyParticles_.Length; ++index)
                this.butterflyParticles_[index].TurnOff();
            this.eventTimer_ = 0.0f;
            this.currEvent_ = 0;
            this.spamTimer_ = 0.0f;
            this.active1_ = false;
            this.active2_ = false;
        }
    }
}
