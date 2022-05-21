using Microsoft.Xna.Framework;

namespace Helicopter
{
    public class Animation
    {
        private Rectangle[] frames;
        private int currentFrame = 0;
        private float timer = 0.0f;
        private float frameLength;

        public Animation(Rectangle[] Frames, float FrameLength)
        {
            this.frames = new Rectangle[Frames.Length];
            for (int index = 0; index < Frames.Length; ++index)
                this.frames[index] = Frames[index];
            this.frameLength = FrameLength;
        }

        public Rectangle CurrentFrame => this.frames[this.currentFrame];

        public int FramesPerSecond => (int)(1.0 / (double)this.frameLength);

        public void Update(float dt)
        {
            this.timer += dt;
            if ((double)this.timer < (double)this.frameLength)
                return;
            this.timer = 0.0f;
            this.currentFrame = (this.currentFrame + 1) % this.frames.Length;
        }

        public void Reset()
        {
            this.currentFrame = 0;
            this.timer = 0.0f;
        }
    }
}
