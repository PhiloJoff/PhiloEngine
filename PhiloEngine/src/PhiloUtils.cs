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
        /// Return a Texture2D
        /// </summary>
        /// <param name="graphics">GraphicsDevice</param>
        /// <param name="width">Width of the Texture2D</param>
        /// <param name="height">Height of the Texture2D</param>
        /// <param name="color">Color of the Texture2D</param>
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
        /// <returns>True if equal</returns>
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

        /// <summary>
        /// Return color by name
        /// </summary>
        /// <param name="name">Name of the color</param>
        /// <returns>Return the color if found else return Transparent</returns>
        public static Color GetColorByName(string name)
        {
            foreach (var prop in typeof(Color).GetProperties())
            {
                if (name == prop.Name)
                {

                    return (Color)prop.GetValue(typeof(Color));
                }
            }

            return Color.Transparent;
        }

        /// <summary>
        /// Return a Texture2D with border
        /// </summary>
        /// <param name="graphics">Graphics Device</param>
        /// <param name="width">Width of the texture</param>
        /// <param name="height">Height of the texture</param>
        /// <param name="textureColor">Main color fo the texture</param>
        /// <param name="colorBorder">Color of the border</param>
        /// <param name="thickness">Thickness of the border</param>
        /// <returns></returns>
        public static Texture2D CreateBorderTexture2D(GraphicsDevice graphics, int width, int height, Color textureColor, Color colorBorder, int thickness)
        {

            Texture2D texture = new Texture2D(graphics, width, height);
            Color[] data = new Color[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bool colored = false;
                    for (int i = 0; i < thickness; i++)
                    {
                        if (x == i || y == i || x == width - 1 - i || y == height - 1 - i)
                        {
                            data[x + y * width] = colorBorder;
                            colored = true;
                            break;
                        
                        }
                    }
                    if (!colored)
                        data[x + y * width] = textureColor;
                }
            }
            texture.SetData(data);
            return texture;

        }
    }
}
