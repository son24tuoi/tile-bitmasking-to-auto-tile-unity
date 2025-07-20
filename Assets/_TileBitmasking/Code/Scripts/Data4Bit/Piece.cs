using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    public class Piece : MonoBehaviour
    {
        [Header("Element")]
        [SerializeField] private SpriteRenderer spriteRenderer;

        [Header("Data")]
        [SerializeField] PieceSetProfileSO pieceSetProfile;
        [SerializeField] private TileDirection neighbors;
        [SerializeField] Tile tile;

        public Tile Tile => tile;
        public int BitmaskingValue => (int)neighbors;

        public void Init(Tile tile, TileDirection neighbors)
        {
            this.tile = tile;
            transform.localPosition = new Vector3(tile.xIndex, tile.yIndex, 0);

            gameObject.name = $"Piece_({tile.xIndex}, {tile.yIndex})";

            SetNeighbors(neighbors);
            Setup();
        }

        [ContextMenu(nameof(Setup))]
        public void Setup()
        {
            spriteRenderer.sprite = pieceSetProfile.GetTile(BitmaskingValue);
        }

        [ContextMenu(nameof(ToString))]
        public override string ToString()
        {
            Debug.Log($"Piece_({tile.xIndex}, {tile.yIndex})_{BitmaskingValue}");
            return $"Piece_({tile.xIndex}, {tile.yIndex})_{BitmaskingValue}";
        }

        public void SetNeighbors(TileDirection neighbors)
        {
            this.neighbors = neighbors;
        }
    }
}