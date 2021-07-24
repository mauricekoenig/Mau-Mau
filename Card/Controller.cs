


using UnityEngine;
using UnityEngine.EventSystems;

namespace MK.MauMau
{
    public sealed class Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Info info;
        public GameObject Hit { get; set; }
        public bool Dragging { get; set; }
        public Transform ReturnParent { get; set; }
        public Vector3 Origin { get; set; }

        private void Awake() {

            info = GetComponent<Info>();
        }
        public void OnBeginDrag(PointerEventData eventData) {

            if (Dragging)  return;

            Dragging = true;
            Origin = transform.position;
            ReturnParent = transform.parent;
            transform.SetParent(transform.root);
        }
        public void OnDrag(PointerEventData eventData) {

            var Position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            transform.position = Position;

            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit)) {

                if (hit.collider.gameObject != gameObject) {

                    Hit = hit.collider.gameObject;
                }

                else Hit = null;
            }

            Debug.DrawRay(transform.position, Vector3.forward, Color.yellow, .5f);
        }
        public void OnEndDrag(PointerEventData eventData) {

            transform.SetParent(ReturnParent);
            transform.position = Origin;
            Dragging = false;
        }
    }
}