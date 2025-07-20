using System;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    [CreateAssetMenu(fileName = "PieceSetProfileSO_4Bit", menuName = "Tile Bitmasking/Data 4 Bit/Piece Set Profile", order = 0)]
    public class PieceSetProfileSO : ScriptableObject
    {
        [SerializeField] private Sprite[] bitMaskingTiles;

        public Sprite GetTile(int bitmaskingValue)
        {
            return bitMaskingTiles[Math.Clamp(bitmaskingValue, 0, bitMaskingTiles.Length - 1)];
        }
    }
}