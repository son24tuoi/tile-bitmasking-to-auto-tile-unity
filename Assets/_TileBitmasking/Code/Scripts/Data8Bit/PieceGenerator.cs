using System.Collections;
using System.Collections.Generic;
using TileBitmasking.Sample;
using UnityEngine;

namespace TileBitmasking.Data8Bit
{
    public class PieceGenerator : MonoBehaviour
    {
        [Header("Element")]
        [SerializeField] private Grid grid;
        [SerializeField] private Piece piecePrefab;
        [SerializeField] private InfoCanvas infoCanvas;

        [Header("Data")]
        [SerializeField] private Piece[,] pieces;

        private IEnumerator Start()
        {
            yield return null;

            Init(grid.Width, grid.Height);
        }

        public void Init(int width, int height)
        {
            ClearTileViews();
            pieces = new Piece[width, height];
        }

        public void ClearTileViews()
        {
            if (pieces != null)
            {
                if (pieces.GetLength(0) > 0 || pieces.GetLength(1) > 0)
                {
                    foreach (Piece nv in pieces)
                    {
                        Destroy(nv.gameObject);
                    }
                }
            }

            pieces = new Piece[0, 0];
        }

        public void TrySelectTile(Vector2 worldPos)
        {
            int xIndex = Mathf.FloorToInt(worldPos.x);
            int yIndex = Mathf.FloorToInt(worldPos.y);

            if (!IsWithinBounds(xIndex, yIndex))
                return;

            if (pieces[xIndex, yIndex] != null)
                return;

            Tile tile = grid.GetTile(xIndex, yIndex);

            if (tile != null)
            {
                Piece instance = Instantiate(piecePrefab, Vector3.zero, Quaternion.identity, transform);
                instance.Init(tile, GetNeighbors(tile));

                pieces[tile.xIndex, tile.yIndex] = instance;

                UpdateNeighborPieces(instance);
                
                infoCanvas.Log(instance.ToString());
            }

        }

        public TileDirection GetNeighbors(Tile tile)
        {
            TileDirection neighbors = TileDirection.None;

            TileDirection flag; // cache
            Vector2 pos; // cache

            for (int i = 0; i < TileDirectionExtensions.MaxBit; i++)
            {
                flag = (TileDirection)(1 << i);

                if (!tile.neighbors.HasFlag(flag))
                    continue;

                pos = tile.GetNeighborPosition(flag);

                if (!IsWithinBounds((int)pos.x, (int)pos.y))
                    continue;

                if (pieces[(int)pos.x, (int)pos.y] != null)
                    neighbors |= flag;
            }

            return neighbors;
        }

        private void UpdateNeighborPieces(Piece piece)
        {
            int startX = Mathf.Max(0, piece.Tile.xIndex - 1);
            int endX = Mathf.Min(piece.Tile.xIndex + 1, pieces.GetLength(0) - 1);
            int startY = Mathf.Max(0, piece.Tile.yIndex - 1);
            int endY = Mathf.Min(piece.Tile.yIndex + 1, pieces.GetLength(1) - 1);

            Piece instance;

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    instance = pieces[x, y];

                    if (instance != null)
                    {
                        instance.SetNeighbors(GetNeighbors(instance.Tile));
                        instance.Setup();
                    }
                }
            }
        }

        public bool IsWithinBounds(int x, int y)
        {
            return grid.IsWithinBounds(x, y);
        }



#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if (pieces != null)
            {
                Gizmos.color = Color.green;

                foreach (Piece piece in pieces)
                {
                    if (piece != null)
                        Gizmos.DrawWireCube(piece.transform.position, new Vector3(1f, 1f, 0f));
                }
            }
        }

#endif
    }
}