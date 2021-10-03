using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhiloEngine.src
{
    abstract public class Scene
    {
        public enum SceneType
        {
            Base,
            MainMenu,
            GameOver,
            Gameplay,
            Pause,
            Win,
            GameEditor,
            Options,
            GameplayLoaded
        }

        protected MainGame _mainGame;
        protected EntityManager _entityManager;
        protected SpriteBatch _spriteBatch;
        protected SceneType _sceneType;

        public Scene(MainGame mainGame)
        {
            if (mainGame is null)
            {
                throw new ArgumentNullException(nameof(mainGame));
            }
            _mainGame = mainGame;
            Load();
        }

        public virtual void Load()
        {
            _spriteBatch = _mainGame.SpriteBatch;
            _entityManager = new EntityManager(_spriteBatch);
        }

        public virtual void Unload()
        {
            _entityManager.Clear();
        }

        public virtual void Update(GameTime gameTime)
        {
            _entityManager.UpdateEntities(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            _entityManager.DrawEntities(gameTime);
        }

    }
}
