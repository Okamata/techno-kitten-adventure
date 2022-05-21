





using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
  public class KaraokeLyrics
  {
    private bool visible_;
    private SpriteFont font_;
    private float fontScale_ = 1f;
    private Vector2 position_ = new Vector2(640f, 86f);
    private Color highlightedColor_ = Color.White;
    private Color nonHighlightedColor_ = new Color(new Vector4(0.0f, 0.0f, 0.0f, 0.7f));
    private int currentLineIndex_ = -1;
    private float lineProgress_;
    private float[] lineTimes_ = new float[44]
    {
      10500f,
      13284f,
      14959f,
      17838f,
      21142f,
      23902f,
      26710f,
      29330f,
      43818f,
      49150f,
      54436f,
      59651f,
      64040f,
      67296f,
      69891f,
      71354f,
      75177f,
      76357f,
      77749f,
      79023f,
      80418f,
      81713f,
      83011f,
      111916f,
      114630f,
      116329f,
      119019f,
      122440f,
      125272f,
      127962f,
      130675f,
      133271f,
      134686f,
      135913f,
      137730f,
      140397f,
      143818f,
      145305f,
      146626f,
      149316f,
      152006f,
      154696f,
      158000f,
      160524f
    };
    private float[] lineProgressRates_ = new float[44]
    {
      0.597015f,
      0.6349206f,
      0.5042864f,
      0.8333333f,
      0.7692308f,
      0.625f,
      0.7142857f,
      0.7692308f,
      0.349284f,
      0.2383222f,
      0.2871913f,
      0.2472799f,
      0.3418804f,
      0.41511f,
      0.770416f,
      0.4268033f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      0.8333333f,
      0.597015f,
      0.6349206f,
      0.5042864f,
      0.8333333f,
      0.7692308f,
      0.625f,
      0.7142857f,
      0.7692308f,
      1f,
      1f,
      0.7692308f,
      0.6349206f,
      0.5042864f,
      0.8333333f,
      0.8333333f,
      0.7692308f,
      0.7142857f,
      0.7692308f,
      0.3363606f,
      0.4462294f,
      0.3444712f
    };
    private string[] lines_ = new string[44]
    {
      "Hungry for your love",
      "Hungry for your love",
      "Youre a taste of heaven",
      "I kissed a star",
      "Craving for your love",
      "Just cant get enough",
      "Feed me more",
      "Let it pour",
      "Ive never felt this way before",
      "I have this appetite for more of you",
      "I feel the world has carved a special place for me",
      "And since Ive laid my eyes on you its been a dream",
      "Theres something burning deep inside",
      "Its growing stronger I cant hide",
      "Its taking over",
      "I cant fight it",
      "You pick me up",
      "You bring me down",
      "Cant feel my feet",
      "Im off the ground",
      "No gravity",
      "In love Ive found",
      "Dont wanna come down",
      "Hungry for your love",
      "Hungry for your love",
      "Youre a taste of heaven",
      "I kissed a star",
      "Craving for your love",
      "Just cant get enough",
      "Feed me more",
      "Let it pour",
      "Hungry for you",
      "Hungry for you",
      "Hungry for your love",
      "Youre a taste of heaven",
      "I kissed a star",
      "Craving for you",
      "Craving for you",
      "Craving for your love",
      "Feed me more",
      "Let it pour",
      "You make me wanna touch the sky",
      "And Im soaring flying high",
      "When Im with you the sun is shining"
    };

    private string CurrentLine => this.currentLineIndex_ > -1 ? this.lines_[this.currentLineIndex_] : "";

    public KaraokeLyrics() => this.font_ = Global.spriteFont;

    public void Update(float dt, float elapsedMilliseconds)
    {
      if (!this.visible_)
        return;
      if (this.currentLineIndex_ > -1)
        this.lineProgress_ += this.lineProgressRates_[this.currentLineIndex_] * dt;
      if (this.lineTimes_.Length > this.currentLineIndex_ + 1 && (double) this.lineTimes_[this.currentLineIndex_ + 1] < (double) elapsedMilliseconds)
      {
        this.lineProgress_ = 0.0f;
        ++this.currentLineIndex_;
      }
      if (this.currentLineIndex_ == this.lineTimes_.Length - 1 && (double) this.lineProgress_ > 2.0)
        this.TurnOff();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this.visible_)
        return;
      if ((double) this.lineProgress_ <= 1.0)
      {
        int num = (int) ((double) this.lineProgress_ * (double) this.CurrentLine.Length);
        string text1 = this.CurrentLine.Substring(0, num);
        string text2 = this.CurrentLine.Substring(num, this.CurrentLine.Length - num);
        Vector2 vector2_1 = this.font_.MeasureString(this.CurrentLine);
        Vector2 vector2_2 = this.font_.MeasureString(text1);
        spriteBatch.DrawString(this.font_, text1, this.position_ + new Vector2((float) (-(double) vector2_1.X / 2.0), (float) (0.0 * (double) vector2_1.Y / 2.0)), this.highlightedColor_, 0.0f, Vector2.Zero, this.fontScale_, SpriteEffects.None, 0.0f);
        spriteBatch.DrawString(this.font_, text2, this.position_ + new Vector2(vector2_2.X - vector2_1.X / 2f, (float) (0.0 * (double) vector2_1.Y / 2.0)), this.nonHighlightedColor_, 0.0f, Vector2.Zero, this.fontScale_, SpriteEffects.None, 0.0f);
      }
      else if ((double) this.lineProgress_ < 1.60000002384186)
      {
        Vector2 vector2 = this.font_.MeasureString(this.CurrentLine);
        spriteBatch.DrawString(this.font_, this.CurrentLine, this.position_, this.highlightedColor_, 0.0f, new Vector2(vector2.X / 2f, 0.0f), this.fontScale_, SpriteEffects.None, 0.0f);
      }
    }

    public void TurnOn()
    {
      this.visible_ = true;
      this.currentLineIndex_ = -1;
      this.lineProgress_ = 0.0f;
    }

    public void TurnOff() => this.visible_ = false;
  }
}
