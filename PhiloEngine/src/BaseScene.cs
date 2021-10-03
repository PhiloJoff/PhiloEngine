using System;
using System.Collections.Generic;
using System.Text;

namespace PhiloEngine.src
{
    public class BaseScene : Scene
    {
        public BaseScene(MainGame mainGame) : base(mainGame)
        {
            _sceneType = SceneType.Base;
        }
    }
}
