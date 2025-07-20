using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    [Serializable]
    public record Tile
    {
        public int xIndex = -1;
        public int yIndex = -1;
        public TileDirection neighbors = TileDirection.None;

        public Tile(int xIndex, int yIndex)
        {
            this.xIndex = xIndex;
            this.yIndex = yIndex;
            this.neighbors = TileDirection.None;
        }

        public override string ToString()
        {
            return $"Tile({xIndex},{yIndex})";
        }

        public Vector2 GetNeighborPosition(TileDirection direction)
        {
            return new Vector2(xIndex, yIndex) + direction.ToVector2();
        }
    }
}
