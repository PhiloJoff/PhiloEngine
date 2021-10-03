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
        protected Scene _baseScene;
        public Scene BaseScene { get => _baseScene; }
        protected InputManager _inputManager;
        public InputManager InputManager { get => _inputManager; }



        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameState = new GameState();
            _baseScene = new BaseScene(this);
            _inputManager = InputManager.Instance;
            Content.RootDirectory = "Content";
        }
        public MainGame(int width, int height)
        {
            _graphics  = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height
            };
            _gameState = new GameState();
            _baseScene = new BaseScene(this);
            _inputManager = InputManager.Instance;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            _gameState.SwitchScene(_baseScene);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _inputManager.Update();
            _gameState.CurrentScene.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _gameState.CurrentScene.Draw(gameTime);
            _spriteBatch.End();

        }
    }
}
