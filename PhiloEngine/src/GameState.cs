﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhiloEngine.src
{
    public class GameState
    {
        public enum SceneType
        {
            MainMenu,
            GameOver,
            Gameplay,
            Pause,
            Win,
            GameEditor,
            GameplayLoaded
        }

        private Scene _currentScene;
        public Scene CurrentScene { get; protected set; }

        public GameState()
        {
        }
        public GameState(Scene scene)
        {
            _currentScene = scene;
        }

        public void SwitchScene(Scene scene)
        {
            if (scene is null)
            {
                throw new ArgumentNullException(nameof(scene));
            }

            if (_currentScene != null)
            {
                _currentScene.Unload();
                _currentScene = null;
            } 
            _currentScene = scene;
            
        }
    }
}
