using System;
using AYellowpaper.SerializedCollections;
using TileBitmasking.Data8Bit.Attribute;
using UnityEngine;

namespace TileBitmasking.Data8Bit
{
    [CreateAssetMenu(fileName = "PieceSetProfileSO_8Bit", menuName = "Tile Bitmasking/Data 8 Bit/Piece Set Profile", order = 0)]
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