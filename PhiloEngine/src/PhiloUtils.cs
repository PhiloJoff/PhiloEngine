using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhiloEngine.src
{
    /// <summary>
    /// Classe Utils avec divers fonctions
    /// </summary>
    public static class PhiloUtils
    {
        /// <summary>
        /// Create a Texture2D with a Color.White by default
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Texture2D CreateTexture2D(GraphicsDevice graphics, int width, int height, Color? color = null)
        {
            Texture2D texture = new Texture2D(graphics, width, height);
            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
                data[i] = color ?? Color.White;

            texture.SetData(data);
            return texture;
        }

        /// <summary>
        /// Return true if the 2 rectangles colide
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsColide(Rectangle a, Rectangle b)
        {

            return b.Contains(a) || a.Contains(b);
        }
        /// <summary>
        /// Return true if a intersect b
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="aWidth"></param>
        /// <param name="aHeight"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="bWidth"></param>
        /// <param name="bHeight"></param>
        /// <returns></returns>
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
