using System;
using UnityEngine;

namespace DefaultNamespace {
    public class Grabbable : MonoBehaviour {
        private bool isDragging;
        public bool GetIsDragging() => isDragging;
        [SerializeField]
        public Camera main_camera;

        [SerializeField] private GameObject upper_left;
        [SerializeField] private GameObject lower_right;

        private Vector2 mousePosition;
        public Vector2 GetMousePosition => mousePosition;

        public void OnMouseDown() {
            isDragging = true;
        }

        public void OnMouseUp() {
            isDragging = false;
            // if (mousePosition.x < upper_left.transform.position.x ||
            //     mousePosition.x > lower_right.transform.position.x ||
            //     mousePosition.y > upper_left.transform.position.y ||
            //     mousePosition.y < lower_right.transform.position.y) {
            // }
        }

        void Update() {
            if (isDragging) {
                mousePosition = main_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        }

        public bool IsOOB() {
            return false;
        }
    }
}