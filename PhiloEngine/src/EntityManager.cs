﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhiloEngine.src
{
    public class EntityManager
    {
        protected List<IGameEntity> _gameEntities;
        public List<IGameEntity> GameEntities { get => _gameEntities; }

        public EntityManager()
        {
            _gameEntities = new List<IGameEntity>();
        }
        
        public bool AddEntity(IGameEntity gameEntity)
        {
            if (gameEntity is null)
            {
                throw new ArgumentNullException(nameof(gameEntity));
            }

            if (HasEntity(gameEntity))
                return false;

            _gameEntities.Add(gameEntity);
            return true;
        }

        public bool RemoveEntity(IGameEntity gameEntity)
        {
            if (gameEntity is null)
            {
                throw new ArgumentNullException(nameof(gameEntity));
            }

            if (HasEntity(gameEntity))
                return false;

            _gameEntities.Remove(gameEntity); 
            return true;
        }

        public bool HasEntity(IGameEntity gameEntity) => _gameEntities.Contains(gameEntity);

        public void Clear()
        {
            foreach (IGameEntity entity in _gameEntities.OrderBy(e => e.UpdateOrder))
            {
                entity.Unload();
            }
            _gameEntities.Clear();
        }

        public void UpdateEntities(GameTime gameTime)
        {
            foreach (IGameEntity entity in _gameEntities.OrderBy(e => e.UpdateOrder))
            {
                entity.Update(gameTime);
            }
        }
        public void DrawEntities(GameTime gameTime)
        {
            foreach (IGameEntity entity in _gameEntities.OrderBy(e => e.DrawOrder))
            {
                entity.Draw(gameTime);
            }
        }

    }
}
