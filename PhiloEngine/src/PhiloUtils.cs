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
        /// <summary>
        /// Check if 2 unordered Collection are equals. Return true or false
        /// </summary>
        /// <typeparam name="T">Type of value in the list</typeparam>
        /// <param name="a">Collection<T> 1</param>
        /// <param name="b">Collection<T> 2</param>
        /// <returns></returns>
        public static bool UnorderedEqual<T>(ICollection<T> a, ICollection<T> b)
        {
            // Require that the counts are equal
            if (a.Count != b.Count)
            {
                return false;
            }
            // Initialize new Dictionary of the type
            Dictionary<T, int> d = new Dictionary<T, int>();
            // Add each key's frequency from collection A to the Dictionary
            foreach (T item in a)
            {
                int c;
                if (d.TryGetValue(item, out c))
                {
                    d[item] = c + 1;
                }
                else
                {
                    d.Add(item, 1);
                }
            }
            // Add each key's frequency from collection B to the Dictionary
            // Return early if we detect a mismatch
            foreach (T item in b)
            {
                int c;
                if (d.TryGetValue(item, out c))
                {
                    if (c == 0)
                    {
                        return false;
                    }
                    else
                    {
                        d[item] = c - 1;
                    }
                }
                else
                {
                    // Not in dictionary
                    return false;
                }
            }
            // Verify that all frequencies are zero
            foreach (int v in d.Values)
            {
                if (v != 0)
                {
                    return false;
                }
            }
            // We know the collections are equal
            return true;
        }
    }
}
