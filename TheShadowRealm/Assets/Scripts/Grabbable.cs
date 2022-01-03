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
        private Vector3 new_position;


        public void OnMouseDown() {
            isDragging = true;
            old_position = transform.position;
        }

        public void OnMouseUp() {
            new_position = main_camera.ScreenToWorldPoint(Input.mousePosition);
            new_position.z = 3;
            isDragging = false;

            var x_mouse_world_diff = Mathf.Abs(new_position.x - old_position.x);
            var y_mouse_world_diff = Mathf.Abs(new_position.y - old_position.y);
            if (x_mouse_world_diff >= 0.5 || y_mouse_world_diff >= 0.5) {
                //place the object in the correct exact spot, 
                Vector3 rounded_new_pos = new Vector3((float) (Mathf.Floor(mouse_world_position.x) + 0.47),
                    (float) (Mathf.Round(mouse_world_position.y) - 0.21), 3);
                if (!IsOOB()) {
                    gameObject.transform.position = rounded_new_pos;
                }
                else {
                    ResetPosition();
                }
            }
        }

        private void ResetPosition() {
            old_position.z = 3;
            gameObject.transform.position = old_position;
        }

        void Update() {
            if (isDragging) {
                mouse_world_position = main_camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition = main_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        }

        public bool IsOOB() {
            Debug.Log("OOB test");
            if (mouse_world_position.x < upper_left.transform.position.x ||
                mouse_world_position.x > lower_right.transform.position.x ||
                mouse_world_position.y > upper_left.transform.position.y ||
                mouse_world_position.y < lower_right.transform.position.y) {
                Debug.Log("100p OOB");
                return true;
            }

            return false;
        }
    }
}