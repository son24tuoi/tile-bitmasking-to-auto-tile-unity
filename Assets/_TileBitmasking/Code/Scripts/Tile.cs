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
        public TileDirection[] neighbors = new TileDirection[0];

        public Tile(int xIndex, int yIndex)
        {
            this.xIndex = xIndex;
            this.yIndex = yIndex;
            this.neighbors = null;
        }

        public override string ToString()
        {
            return $"Tile({xIndex},{yIndex})";
        }

        public Vector2[] GetNeighborPositions()
        {
            List<Vector2> neighborPositions = new List<Vector2>();

            for (int i = 0; i < neighbors.Length; i++)
            {
                neighborPositions.Add(new Vector2(xIndex, yIndex) + neighbors[i].ToVector2());
            }

            return neighborPositions.ToArray();
        }
    }
}
