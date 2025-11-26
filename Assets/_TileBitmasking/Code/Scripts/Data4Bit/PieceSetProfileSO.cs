using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    [CreateAssetMenu(fileName = "PieceSetProfileSO_4Bit", menuName = "Tile Bitmasking/Data 4 Bit/Piece Set Profile", order = 0)]
    public class PieceSetProfileSO : ScriptableObject
    {
        [SerializedDictionary("Tile Direction", "Sprite")]
        [SerializeField] private SerializedDictionary<TileDirection, Sprite> bitMaskingTilesDict = new SerializedDictionary<TileDirection, Sprite>();

        public Sprite GetTile(int bitmaskingValue)
        {
            if (bitMaskingTilesDict.ContainsKey((TileDirection)bitmaskingValue))
            {
                return bitMaskingTilesDict[(TileDirection)bitmaskingValue];
            }

            return null;
        }
    }
}