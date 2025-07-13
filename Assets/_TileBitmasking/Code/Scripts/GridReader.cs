using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking
{
    public static class GridReader
    {
        public static string[] GetLinesFromFile(this TextAsset tAsset)
        {
            List<string> lines = new List<string>();

            if (tAsset != null)
            {
                string textData = tAsset.text;
                string[] delimiters = { "\r\n", "\n" };

                lines.AddRange(textData.Split(delimiters, StringSplitOptions.None));
                lines.Reverse();
            }
            else
            {
                Debug.LogWarning("Grid Reader: GetTextFromFile Error: invalid TextAsset");
            }

            return lines.ToArray();
        }

        public static Vector2Int GetDimensions(string[] textLines)
        {
            Vector2Int size = new Vector2Int(3, textLines.Length);

            for (int i = 0; i < textLines.Length; i++)
            {
                if (textLines[i].Length > size.x)
                {
                    size.x = textLines[i].Length;
                }
            }

            return size;
        }

        public static Vector2Int GetDimensions(this TextAsset textAsset)
        {
            string[] lines = textAsset.GetLinesFromFile();
            return GetDimensions(lines);
        }

        public static int[,] MakeMap(this TextAsset textAsset)
        {
            string[] lines = textAsset.GetLinesFromFile();
            Vector2Int size = GetDimensions(lines);

            int[,] map = new int[size.x, size.y];

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    if (lines[y].Length > x)
                    {
                        map[x, y] = (int)Char.GetNumericValue(lines[y][x]);
                    }
                }
            }

            return map;
        }

        public static int GetCount(this TextAsset textAsset)
        {
            int[,] map = textAsset.MakeMap();

            int width = map.GetLength(0);
            int height = map.GetLength(1);

            int count = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] != 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}