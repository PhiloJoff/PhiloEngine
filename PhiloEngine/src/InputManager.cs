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
        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyDown(key) && _prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (_currentKeyState.IsKeyUp(key) && _prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

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
