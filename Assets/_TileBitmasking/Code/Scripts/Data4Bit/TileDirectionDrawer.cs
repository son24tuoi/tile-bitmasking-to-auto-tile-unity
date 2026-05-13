using UnityEditor;
using UnityEngine;

namespace TileBitmasking.Data4Bit.Attribute
{
    [CustomPropertyDrawer(typeof(TileDirection))]
    public class TileDirectionDrawer : PropertyDrawer
    {
        private readonly TileDirection[] directions =
        {
            TileDirection.None, TileDirection.North, TileDirection.None,
            TileDirection.West, TileDirection.None,  TileDirection.East,
            TileDirection.None, TileDirection.South, TileDirection.None
        };

        private const float CellSize = 130f;
        private const float Percent = 0.9f;
        private const float MaxSize = 120f;
        private const float MinSize = 80f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var value = (TileDirection)property.intValue;

            float fullSize = Mathf.Clamp(position.width * Percent, MinSize, MaxSize);
            float size = fullSize / 3f;
            Rect r = new Rect(position.x, position.y, size, size);
            Color old;
            TileDirection dir;

            for (int i = 0; i < directions.Length; i++)
            {
                dir = directions[i];

                old = GUI.backgroundColor;

                if (dir != TileDirection.None && value.HasFlag(dir))
                    GUI.backgroundColor = Color.green;

                if (dir == TileDirection.None && value == TileDirection.None)
                    GUI.backgroundColor = Color.green;

                if (GUI.Button(r, GetDirectionLabel(dir)))
                {
                    if (dir != TileDirection.None)
                    {
                        if (value.HasFlag(dir))
                            value &= ~dir;  // tắt
                        else
                            value |= dir;   // bật
                    }
                    else
                    {
                        value = TileDirection.None;
                    }
                }

                GUI.backgroundColor = old;

                r.x += size;
                if ((i + 1) % 3 == 0)
                {
                    r.x = position.x;
                    r.y += size;
                }
            }

            // Nút Everything
            if (value.IsEverything())
                GUI.backgroundColor = Color.green;

            r.x = position.x + fullSize;
            r.y = position.y + size * 2;
            r.width = size;

            if (GUI.Button(r, "All"))
            {
                value = ~TileDirection.None;
            }
            // End Nút Everything

            property.intValue = (int)value;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return CellSize;
        }

        private string GetDirectionLabel(TileDirection flag)
        {
            return flag switch
            {
                TileDirection.North => "N",
                TileDirection.East => "E",
                TileDirection.South => "S",
                TileDirection.West => "W",
                _ => "None"
            };
        }
    }
}
