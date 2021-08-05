using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PhiloEngine.src;

namespace PhiloEngine
{
    public class MainGame : Game
    {
        protected GraphicsDeviceManager _graphics;
        public GraphicsDeviceManager Graphics { get => _graphics; }

        protected SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch { get => _spriteBatch; }

        protected GameState _gameState;
        public GameState GameState { get => _gameState; }


        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public MainGame(int width, int height)
        {
            _graphics  = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height
            };
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameState = new GameState();

        }

        protected override void Update(GameTime gameTime)
        {
            _gameState.CurrentScene.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _gameState.CurrentScene.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
