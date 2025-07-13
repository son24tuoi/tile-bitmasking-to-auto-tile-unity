using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    public enum TileDirection
    {
        North = 0,
        West = 1,
        East = 2,
        South = 3
    }

    public static class TileDirectionExtensions
    {
        public static int ToValue(this TileDirection direction)
        {
            return (int)Mathf.Pow(2f, (int)direction);
        }

        public static int CalculationBitmaskingValue(this TileDirection[] neighbors)
        {
            int result = 0;
            for (int i = 0; i < neighbors.Length; i++)
            {
                result += neighbors[i].ToValue();
            }
            return result;
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