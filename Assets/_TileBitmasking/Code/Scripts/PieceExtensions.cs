using System;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    public static class PieceExtensions
    {
        public static int CalculationBitmaskingValue(this Piece[] neighbors)
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