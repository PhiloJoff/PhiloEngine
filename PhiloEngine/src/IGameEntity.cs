using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhiloEngine.src
{
    public interface IGameEntity
    {
        Texture2D Texture2D { get; set; }
        Vector2 Pos { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Color Color { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; set; }
        float Scale { get; set; }
        SpriteEffects SpriteEffects { get; set; }
        float LayerDepth { get; set; }

        int DrawOrder { get; set; }
        int UpdateOrder { get; set; }
        void Load();
        void Unload();
        void Update(GameTime gameTime);
    }
}
