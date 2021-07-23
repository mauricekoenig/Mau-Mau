


using UnityEngine;
using UnityEngine.EventSystems;

namespace MK.MauMau
{
    public sealed class Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        [SerializeField] private bool _isDragging = false;

        private Canvas _canvas;
        private Camera _mainCam;

        public bool IsDragging {
            get { return _isDragging; }
            private set {  }
        }

        [SerializeField] private Transform _returnParent;

        public Transform ReturnParent {
            get { return _returnParent; }
            private set {  }
        }

        [SerializeField] private int _index;

        public int Index {
            get { return _index; }
            set {  }
        }


        private void Awake() {

            _returnParent = transform.parent;
            _canvas = FindObjectOfType<Canvas>();
            _mainCam = FindObjectOfType<Camera>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            
            if (!IsDragging) {

                _isDragging = true;
                _returnParent = transform.parent;
                _index = transform.GetSiblingIndex();
            }

        }

        public void OnDrag(PointerEventData eventData) {
            
            if (IsDragging) {

                Vector3 position = Vector3.zero;
                RectTransformUtility.ScreenPointToWorldPointInRectangle
                (_canvas.transform as RectTransform, Input.mousePosition, _mainCam, out position);
                transform.position = position;
            }

        }

        public void OnEndDrag(PointerEventData eventData) {
            
            if (IsDragging) {

                transform.SetParent(ReturnParent);
                _isDragging = false;
            }
        }

    }
}