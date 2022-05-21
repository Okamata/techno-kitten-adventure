





using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
    public class InputState
    {
        private GamePadState prevInput;
        private GamePadState currInput;
        private KeyboardState prevKeyInput;
        private KeyboardState currKeyInput;

        public void Update()
        {
            if (Global.playerIndex.HasValue)
                this.currInput = GamePad.GetState(Global.playerIndex.Value);
            this.currKeyInput = Keyboard.GetState();
        }

        public void EndUpdate()
        {
            this.prevInput = this.currInput;
            this.prevKeyInput = this.currKeyInput;
        }

        public bool IsButtonPressed(Buttons button)
        {
            bool flag1 = this.currInput.IsButtonDown(button) && this.prevInput.IsButtonUp(button);
            bool flag2 = false;
            switch (button)
            {
                case Buttons.DPadUp:
                    flag1 = flag1 || (double)this.currInput.ThumbSticks.Left.Y > 0.5 && (double)this.prevInput.ThumbSticks.Left.Y <= 0.5;
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Up) && this.prevKeyInput.IsKeyUp(Keys.Up);
                    break;
                case Buttons.DPadDown:
                    flag1 = flag1 || (double)this.currInput.ThumbSticks.Left.Y < -0.5 && (double)this.prevInput.ThumbSticks.Left.Y >= -0.5;
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Down) && this.prevKeyInput.IsKeyUp(Keys.Down);
                    break;
                case Buttons.DPadLeft:
                    flag1 = flag1 || (double)this.currInput.ThumbSticks.Left.X < -0.5 && (double)this.prevInput.ThumbSticks.Left.X >= -0.5;
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Left) && this.prevKeyInput.IsKeyUp(Keys.Left);
                    break;
                case Buttons.DPadRight:
                    flag1 = flag1 || (double)this.currInput.ThumbSticks.Left.X > 0.5 && (double)this.prevInput.ThumbSticks.Left.X <= 0.5;
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Right) && this.prevKeyInput.IsKeyUp(Keys.Right);
                    break;
                case Buttons.Start:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.S) && this.prevKeyInput.IsKeyUp(Keys.S);
                    break;
                case Buttons.A:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Space) && this.prevKeyInput.IsKeyUp(Keys.Space);
                    break;
                case Buttons.B:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.B) && this.prevKeyInput.IsKeyUp(Keys.B);
                    break;
            }
            return flag1 || flag2;
        }

        public bool IsButtonUp(Buttons button)
        {
            bool flag1 = this.currInput.IsButtonUp(button);
            bool flag2 = false;
            switch (button)
            {
                case Buttons.DPadUp:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.Up);
                    break;
                case Buttons.DPadDown:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.Down);
                    break;
                case Buttons.DPadLeft:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.Left);
                    break;
                case Buttons.DPadRight:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.Right);
                    break;
                case Buttons.Start:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.S);
                    break;
                case Buttons.A:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.Space);
                    break;
                case Buttons.B:
                    flag2 = this.currKeyInput.IsKeyUp(Keys.B);
                    break;
            }
            return flag1 || flag2;
        }

        public bool IsButtonDown(Buttons button)
        {
            bool flag1 = this.currInput.IsButtonDown(button);
            bool flag2 = false;
            switch (button)
            {
                case Buttons.DPadUp:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Up);
                    break;
                case Buttons.DPadDown:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Down);
                    break;
                case Buttons.DPadLeft:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Left);
                    break;
                case Buttons.DPadRight:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Right);
                    break;
                case Buttons.Start:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.S);
                    break;
                case Buttons.A:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.Space);
                    break;
                case Buttons.B:
                    flag2 = this.currKeyInput.IsKeyDown(Keys.B);
                    break;
            }
            return flag1 || flag2;
        }
    }
}
