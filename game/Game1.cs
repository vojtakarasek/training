using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Texture2D _ball;
        Texture2D _player1;
        int _player1X, _player1Y;
        int _speedPlayer;

        Texture2D _player2;
        int _player2X, _player2Y;
        Color _color;
        
        int _ballX;
        int _ballY;
        int _speedX;
        int _speedY;




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
            _color = Color.CornflowerBlue;
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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            BallMove();

            Player1Move();

            Player2Move();

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
                _speedX *= -1;
            if (_ballY > Window.ClientBounds.Height - 40 || _ballY < 0)
                _speedY *= -1;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_color);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_ball, new Rectangle(_ballX, _ballY, 40, 40), Color.White);
            _spriteBatch.Draw(_player1, new Rectangle(_player1X, _player1Y, 40, 65), Color.White);
            _spriteBatch.Draw(_player2, new Rectangle(_player2X, _player2Y, 40, 65), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
