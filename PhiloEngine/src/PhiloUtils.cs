using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhiloEngine.src
{
    public static class PhiloUtils
    {
        public static Texture2D CreateTexture2D(GraphicsDevice graphics, int width, int height, Color? color = null)
        {
            Texture2D texture = new Texture2D(graphics, width, height);
            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
                data[i] = color ?? Color.White;

            texture.SetData(data);
            return texture;
        }


        public static bool IsColide(Rectangle a, Rectangle b)
        {

            return b.Contains(a) || a.Contains(b);
        }
        public static bool IsColide(int aX, int aY, int aWidth, int aHeight,
            int bX, int bY, int bWidth, int bHeight)
        {

            if (aY + aHeight <= bY ||
                aY >= bY + bHeight ||
                aX + aWidth <= bX ||
                aX >= bX + bWidth)
            {
                return false;
            }
            return true;
        }
    }
}
