using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using Pong.Sprites;

namespace Pong;

public class Game1 : Game
{
    public static Random Random;
    private Score _score;
    private List<Sprite> _sprites;
    // Game windows
    public static int _width = 960;
    public static int _height = 480;
    GraphicsDeviceManager _graphics;
    SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _graphics.PreferredBackBufferWidth = _width;
        _graphics.PreferredBackBufferHeight = _height;
        _graphics.ApplyChanges();
        Window.Title = "Pong Game v1";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Random = new Random();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // _ball = Content.Load<Texture2D>("ball");
        var bat = Content.Load<Texture2D>("paddle_player");
        var ball = Content.Load<Texture2D>("ball");
        var background = Content.Load<Texture2D>("baclground");

        _score = new Score(Content.Load<SpriteFont>("font"));

        _sprites = new List<Sprite>()
        {
            new Sprite(background),
        new Bat(bat)
        {
            Position = new Vector2(20, (_height / 2) - (bat.Height) / 2),
            input = new Input()
            {
                Up = Keys.W,
                Down = Keys.S
            }
        },
            new Bat(bat)
            {
                Position = new Vector2(_width - 20 - bat.Width, (_height / 2) - (bat.Height) / 2),
                input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down
                }
            },
            new Ball(ball)
            {
                Position = new Vector2((_width / 2) - (ball.Width / 2), (_height / 2) - (ball.Height / 2)),
                Score = _score
            }
        };

    }




    protected override void Update(GameTime gameTime)
    {
        MouseState _mouseState = Mouse.GetState();
        if (_mouseState.LeftButton == ButtonState.Pressed)
            Exit();

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        foreach (var sprite in _sprites)
        {
            sprite.Update(gameTime, _sprites);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }
        _score.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
