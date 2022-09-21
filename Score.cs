
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Score
    {
        public int Score1;
        public int Score2;

        private SpriteFont _font;
        public Score(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Score1.ToString(), new Vector2(390, 70), Color.White);
            spriteBatch.DrawString(_font, ":", new Vector2(450, 70), Color.White);
            spriteBatch.DrawString(_font, Score2.ToString(), new Vector2(490, 70), Color.White);
        }

    }
}