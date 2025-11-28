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

        private SerializedDictionary<int, Sprite> bitValueTileDict;

        private void Awake()
        {
            bitValueTileDict = new SerializedDictionary<int, Sprite>();

            foreach (var kvp in bitMaskingTilesDict)
            {
                bitValueTileDict.Add(kvp.Key.ToValue(), kvp.Value);
            }
        }

        public Sprite GetTile(int bitmaskingValue)
        {
            if (bitValueTileDict.ContainsKey(bitmaskingValue))
            {
                return bitValueTileDict[bitmaskingValue];
            }

            return null;
        }
    }
}