using System;
using UnityEngine;

namespace TileBitmasking.Data8Bit
{
    [CreateAssetMenu(fileName = "PieceSetProfileSO_8Bit", menuName = "Tile Bitmasking/Data 8 Bit/Piece Set Profile", order = 0)]
    public class PieceSetProfileSO : ScriptableObject
    {
        [SerializeField] private BitmaskingTile[] bitmaskingTiles;

        [Serializable]
        public struct BitmaskingTile
        {
            public TileDirection tileDirection;
            public Sprite sprite;
        }

        public Sprite GetTile(int bitmaskingValue)
        {
            for (int i = 0; i < bitmaskingTiles.Length; i++)
            {
                if (bitmaskingValue == bitmaskingTiles[i].tileDirection.ToValue())
                    return bitmaskingTiles[i].sprite;
            }

            return null;
        }
    }
}