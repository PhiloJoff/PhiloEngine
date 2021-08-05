using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhiloEngine.src
{
    abstract public class Scene
    {
        protected MainGame _mainGame;
        protected EntityManager _entityManager;
        protected SpriteBatch _spriteBatch;

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
