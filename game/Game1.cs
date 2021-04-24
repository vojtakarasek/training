using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Texture2D _ball;
        Texture2D _background;
        Texture2D _player1;
        int _player1X, _player1Y;
        int _speedPlayer;


        Texture2D _player2;
        int _player2X, _player2Y;



        int _ballX;
        int _ballY;
        int _speedX;
        int _speedY;

        SoundEffect _kick;
        SoundEffect _goal;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _graphics.PreferredBackBufferWidth = 1365;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();

            _background = Content.Load<Texture2D>("Sprites/pitch");

            _ball = Content.Load<Texture2D>("Sprites/ball");
            _speedX = 5;
            _speedY = 5;

            _player1 = Content.Load<Texture2D>("Sprites/ronaldo");
            _player1X = 0;
            _player1Y = 230;
            _speedPlayer = 5;



            _player2 = Content.Load<Texture2D>("Sprites/messi");
            _player2X = 760;
            _player2Y = 230;
            _speedPlayer = 5;

            _kick = Content.Load<SoundEffect>("Sounds/hitbox");
            _goal = Content.Load<SoundEffect>("Sounds/applause");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        void PlayGoal()
        {
            _goal.Play();
        }
        
        void PlayKick()
        {
            _kick.Play();
            //MediaPlayer.Play(_kick);
        }


        protected override void Update(GameTime gameTime)
        {
            BallMove();

            Player1Move();

            Player2Move();

            BallCollision();

            BallScore();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        }

        void Player1Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                _player1Y -= _speedPlayer;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                _player1Y += _speedPlayer;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _player1X -= _speedPlayer;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                _player1X += _speedPlayer;
        }
        void Player2Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _player2Y -= _speedPlayer;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _player2Y += _speedPlayer;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _player2X -= _speedPlayer;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _player2X += _speedPlayer;
        }
        void BallMove()
        {
            _ballX += _speedX;
            _ballY += _speedY;

            if (_ballX > Window.ClientBounds.Width - 40 || _ballX < 0)
            {
                _speedX *= -1;
                PlayKick();
            }
            if (_ballY > Window.ClientBounds.Height - 40 || _ballY < 0)
            {
                _speedY *= -1;
                PlayKick();
            }
        }

        void BallCollision()
        {
            if (_player1X == _ballX + 40)
                if (_player1Y <= _ballY + 40 && _player1Y >= _ballY - 66)
                    _speedX *= -1;
            if (_player1X + 40 == _ballX)
                if (_player1Y <= _ballY + 40 && _player1Y >= _ballY - 66)
                    _speedX *= -1;
            if (_player1Y == _ballY + 40)
                if (_player1X <= _ballX + 40 && _player1X >= _ballX - 40)
                    _speedY *= -1;
            if (_player1Y + 65 == _ballY)
                if (_player1X <= _ballX + 40 && _player1X >= _ballX - 40)
                    _speedY *= -1;



            if (_player2X == _ballX + 40)
                if (_player2Y <= _ballY + 40 && _player2Y >= _ballY - 66)
                    _speedX *= -1;
            if (_player2X + 40 == _ballX)
                if (_player2Y <= _ballY + 40 && _player2Y >= _ballY - 66)
                    _speedX *= -1;
            if (_player2Y == _ballY + 40)
                if (_player2X <= _ballX + 40 && _player2X >= _ballX - 40)
                    _speedY *= -1;
            if (_player2Y + 65 == _ballY)
                if (_player2X <= _ballX + 40 && _player2X >= _ballX - 40)
                    _speedY *= -1;


        }
        private void BallScore()
        {
            if (_ballX == 0)
                if (_ballY > 210 && _ballY < 520)
                    PlayGoal();
            if (_ballX == 1325)
                if (_ballY > 210 && _ballY < 520)
                    PlayGoal();
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(_background);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, new Rectangle(0, 0, 1365, 768), Color.White);
            _spriteBatch.Draw(_ball, new Rectangle(_ballX, _ballY, 40, 40), Color.White);
            _spriteBatch.Draw(_player1, new Rectangle(_player1X, _player1Y, 40, 65), Color.White);
            _spriteBatch.Draw(_player2, new Rectangle(_player2X, _player2Y, 40, 65), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
