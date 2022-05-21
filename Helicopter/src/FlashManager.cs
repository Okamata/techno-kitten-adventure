using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
    public class FlashManager
    {
        private float flashAlpha;
        private float flashRate;
        private Color currColor;
        private bool strobeOn;
        private float strobeTimer;
        private float strobeTime;

        public FlashManager()
        {
            this.flashAlpha = 0.0f;
            this.flashRate = 1.5f;
            this.currColor = Color.White;
        }

        public void Update(float dt)
        {
            if (this.strobeOn)
            {
                this.strobeTimer += dt;
                if ((double)this.strobeTimer < 0.0500000007450581)
                    this.flashAlpha = 1f;
                else if ((double)this.strobeTimer > (double)this.strobeTime)
                    this.strobeTimer = 0.0f;
                else
                    this.flashAlpha = 0.0f;
            }
            else
            {
                if ((double)this.flashAlpha <= 0.0)
                    return;
                this.flashAlpha -= this.flashRate * dt;
                if ((double)this.flashAlpha < 0.0)
                    this.flashAlpha = 0.0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if ((double)this.flashAlpha <= 0.0)
                return;
            spriteBatch.Draw(Global.pixel, new Rectangle(0, 0, 1280, 720), new Color(new Vector4(this.currColor.ToVector3(), this.flashAlpha)));
        }

        public void Reset()
        {
            this.flashAlpha = 0.0f;
            this.currColor = Color.White;
            this.strobeOn = false;
        }

        public void DoStrobe(float strobeTime)
        {
            this.flashAlpha = 1f;
            this.strobeTimer = 0.0f;
            this.strobeTime = strobeTime;
            this.strobeOn = true;
        }

        public void DoFlash()
        {
            if (this.strobeOn)
                return;
            this.flashRate = 1.5f;
            this.flashAlpha = 1f;
            this.currColor = Color.White;
        }

        public void DoFade(float fadeTime)
        {
            if (this.strobeOn)
                return;
            this.flashRate = 1f / fadeTime;
            this.flashAlpha = 1f;
            this.currColor = Color.White;
            this.strobeOn = false;
        }
    }
}
