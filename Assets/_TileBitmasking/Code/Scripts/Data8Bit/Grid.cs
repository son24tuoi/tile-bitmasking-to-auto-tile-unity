using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking.Data8Bit
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private TextAsset gridData;

        [SerializeField] private Tile[,] tiles;

        [SerializeField] private int width;
        [SerializeField] private int height;

        private Camera mainCamera;

        public Tile[,] Tiles => tiles;
        public int Width => width;
        public int Height => height;

        public static readonly Vector2[] AllTileDirections = {
            new Vector2(-1, 1),
            Vector2.up,
            new Vector2(1, 1),
            Vector2.left,
            Vector2.right,
            new Vector2(-1, -1),
            Vector2.down,
            new Vector2(1, -1),
        };

        private void Start()
        {
            mainCamera = Camera.main;

            Test();

            Init(gridData.GetDimensions());
        }

        [ContextMenu(nameof(Test))]
        public void Test()
        {
            Init(gridData.GetDimensions());
        }

        public void Init(Vector2Int size)
        {
            mainCamera.AdjustForGrid(size);

            width = size.x;
            height = size.y;

            tiles = new Tile[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile newTile = new Tile(x, y);
                    tiles[x, y] = newTile;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    tiles[x, y].neighbors = GetNeighbors(x, y);
                }
            }
        }

        public TileDirection GetNeighbors(int x, int y)
        {
            TileDirection neighbors = TileDirection.None;

            Vector2 dir;
            int newX, newY;

            for (int i = 0; i < AllTileDirections.Length; i++)
            {
                dir = AllTileDirections[i];

                newX = x + (int)dir.x;
                newY = y + (int)dir.y;

                if (IsWithinBounds(newX, newY) &&
                    tiles[newX, newY] != null)
                {
                    neighbors |= (TileDirection)(1 << i);
                }
            }

            return neighbors;
        }

        public bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        public Tile GetTile(int x, int y)
        {
            return IsWithinBounds(x, y) ? tiles[x, y] : null;
        }



#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (tiles != null)
            {
                Gizmos.color = Color.white;

                foreach (Tile tile in tiles)
                {
                    Gizmos.DrawWireCube(transform.position + new Vector3(tile.xIndex, tile.yIndex, 0), new Vector3(1f, 1f, 0f));
                }
            }
        }

#endif
    }
}