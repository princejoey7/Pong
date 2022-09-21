using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Sprites
{
    public class Bat : Sprite
    {
        public Bat(Texture2D texture) : base(texture)
        {
            speed = 5f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (input == null)
            {
                throw new Exception("Enter a valid 'Input Key'");
            }
            if (Keyboard.GetState().IsKeyDown(input.Up))
                Velocity.Y = -speed;
            else if (Keyboard.GetState().IsKeyDown(input.Down))
                Velocity.Y = speed;

            Position += Velocity;

            Position.Y = MathHelper.Clamp(Position.Y, 0, Game1._width - _texture.Height);
            Velocity = Vector2.Zero;
            base.Update(gameTime, sprites);
        }
    }
}