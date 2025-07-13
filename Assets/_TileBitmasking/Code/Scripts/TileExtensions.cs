using System;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    public static class TileExtensions
    {
        public static int CalculationBitmaskingValue(this Tile[] neighbors)
        {
            int result = 0;
            for (int i = 0; i < neighbors.Length; i++)
            {
                result += (neighbors[i] == null) ? 0 : ((TileDirection)i).ToValue();
            }
            return result;
        }
    }
}