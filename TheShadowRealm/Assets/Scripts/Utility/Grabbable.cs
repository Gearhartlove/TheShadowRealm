using System;
using UnityEngine;

namespace DefaultNamespace {
    public class Grabbable : MonoBehaviour {
        private bool isDragging;
        public bool GetIsDragging() => isDragging;
        [SerializeField] public Camera main_camera;

        [SerializeField] private GameObject upper_left;
        [SerializeField] private GameObject lower_right;

        private Vector2 mousePosition;
        public Vector2 GetMousePosition => mousePosition;

        private Vector2 mouse_world_position;
        private Vector3 old_position;
        private Vector2 new_position;

        public void OnMouseDown() {
            isDragging = true;
            old_position = main_camera.ScreenToWorldPoint(Input.mousePosition);
        }

        public void OnMouseUp() {
            isDragging = false;
            if (IsOOB()) {
                old_position.z = 3;
                gameObject.transform.position = old_position;
            } else {
                
            }
        }

        void Update() {
            if (isDragging) {
                mouse_world_position = main_camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition = main_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
                // Debug.Log(mouse_world_position);
            }
        }

        public bool IsOOB() {
            if (mouse_world_position.x < upper_left.transform.position.x ||
                mouse_world_position.x > lower_right.transform.position.x ||
                mouse_world_position.y > upper_left.transform.position.y ||
                mouse_world_position.y < lower_right.transform.position.y) {
                return true;
            }
            return false;
        }
    }
}