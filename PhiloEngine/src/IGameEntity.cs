using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhiloEngine.src
{
    public interface IGameEntity
    {
        Vector2 Pos { get; set; }
        int DrawOrder { get; set; }
        int UpdateOrder { get; set; }
        void Load();
        void Unload();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
