using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PhiloEngine.src
{
    public class InputManager
    {
        private KeyboardState _currentKeyState, _prevKeyState;
        public KeyboardState CurrentKeyState { get => _currentKeyState; }

        private static InputManager _instance;
        public static InputManager Instance {
            get
            {
                if (_instance is null)
                    _instance = new InputManager();
                return _instance;

            }
        }

        public void Update()
        {
            _prevKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
        }
        //Touche juste tapé
        public bool KeyTyped(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyDown(key) && _prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }
        // Touche relaché
        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyUp(key) && _prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        // Touche enfoncé
        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
    }
}
