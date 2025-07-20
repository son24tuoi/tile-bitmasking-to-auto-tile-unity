using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking
{
    public static class CameraExtensions
    {
        public static void AdjustForGrid(this Camera camera, Vector2Int gridSize)
        {
            Vector3 position = new Vector3(gridSize.x / 2f, gridSize.y / 2f, -10f) + new Vector3(Settings.OffsetCamX, Settings.OffsetCamY, 0f);

            float verticalSize = gridSize.y / 2f + Settings.BorderSizeCamY;
            float horizontalSize = (gridSize.x / 2f + Settings.BorderSizeCamX) / Camera.main.aspect;
            float orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;

            camera.transform.position = position;
            camera.orthographicSize = orthographicSize;
        }
    }
}