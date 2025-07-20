using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBitmasking.Data4Bit
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PieceGenerator pieceGenerator;

        private Camera mainCamera;
        private Vector3 worldPos;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                // Debug.Log(worldPos);
                pieceGenerator.TrySelectTile(worldPos);
            }
        }
    }
}