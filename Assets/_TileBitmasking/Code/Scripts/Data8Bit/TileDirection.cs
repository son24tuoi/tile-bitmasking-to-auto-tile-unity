using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking.Data8Bit
{
    [System.Flags]
    public enum TileDirection
    {
        None = 0,
        NorthWest = 1 << 0, // = 1
        North = 1 << 1, // = 2
        NorthEast = 1 << 2, // = 4
        West = 1 << 3, // = 8
        East = 1 << 4, // = 16
        SouthWest = 1 << 5, // = 32
        South = 1 << 6, // = 64
        SouthEast = 1 << 7, // = 128 
    }

    public static class TileDirectionExtensions
    {
        public const int MaxBit = 9;

        public static Vector2 ToVector2(this TileDirection tileDirection)
        {
            return tileDirection switch
            {
                TileDirection.NorthWest => new Vector2(-1, 1),
                TileDirection.North => Vector2.up,
                TileDirection.NorthEast => new Vector2(1, 1),
                TileDirection.West => Vector2.left,
                TileDirection.East => Vector2.right,
                TileDirection.SouthWest => new Vector2(-1, -1),
                TileDirection.South => Vector2.down,
                TileDirection.SouthEast => new Vector2(1, -1),
                _ => throw new System.Exception()
            };
        }

        public static int ToValue(this TileDirection direction)
        {
            int result = 0;

            if (direction.HasFlag(TileDirection.NorthWest))
            {
                if (direction.HasFlag(TileDirection.North) && direction.HasFlag(TileDirection.West))
                    result += (int)TileDirection.NorthWest;
            }

            if (direction.HasFlag(TileDirection.North))
                result += (int)TileDirection.North;

            if (direction.HasFlag(TileDirection.NorthEast))
            {
                if (direction.HasFlag(TileDirection.North) && direction.HasFlag(TileDirection.East))
                    result += (int)TileDirection.NorthEast;
            }

            if (direction.HasFlag(TileDirection.West))
                result += (int)TileDirection.West;

            if (direction.HasFlag(TileDirection.East))
                result += (int)TileDirection.East;

            if (direction.HasFlag(TileDirection.SouthWest))
            {
                if (direction.HasFlag(TileDirection.South) && direction.HasFlag(TileDirection.West))
                    result += (int)TileDirection.SouthWest;
            }

            if (direction.HasFlag(TileDirection.South))
                result += (int)TileDirection.South;

            if (direction.HasFlag(TileDirection.SouthEast))
            {
                if (direction.HasFlag(TileDirection.South) && direction.HasFlag(TileDirection.East))
                    result += (int)TileDirection.SouthEast;
            }

            return result;
        }

        public static string Information(this TileDirection tileDirection)
        {
            string s = string.Empty;

            for (int i = 0; i < MaxBit; i++)
            {
                TileDirection flag = (TileDirection)(1 << i);

                if (tileDirection.HasFlag(flag))
                    s += (int)flag + ((i == MaxBit - 1) ? "." : ", ");
            }

            return s;
        }
    }
}