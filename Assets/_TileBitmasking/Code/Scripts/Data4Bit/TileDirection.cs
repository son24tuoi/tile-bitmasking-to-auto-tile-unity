using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    [System.Flags]
    public enum TileDirection
    {
        None = 0,
        North = 1,
        West = 2,
        East = 4,
        South = 8
    }

    public static class TileDirectionExtensions
    {
        public const int MaxBit = 5;

        public static int ToValue(this TileDirection direction)
        {
            return (int)Mathf.Pow(2f, (int)direction);
        }

        public static Vector2 ToVector2(this TileDirection tileDirection)
        {
            return tileDirection switch
            {
                TileDirection.North => Vector2.up,
                TileDirection.West => Vector2.left,
                TileDirection.East => Vector2.right,
                TileDirection.South => Vector2.down,
                _ => throw new System.Exception()
            };
        }
    }
}