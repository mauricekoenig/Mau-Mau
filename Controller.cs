


using UnityEngine;
using UnityEngine.EventSystems;

namespace MK.MauMau
{
    public sealed class Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
    {
        
        [SerializeField] private bool _isDragging = false;

        private Canvas _canvas;
        private Camera _mainCam;

        public bool IsDragging {
            get { return _isDragging; }
            private set {  }
        }

        private Container _container;

        public Container Container {
            get { return _container; }
            private set { }
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

        private bool _isPlayable;

        public bool IsPlayable {
            get { return _isPlayable; }
            set { _isPlayable = value; }
        }



        private void Awake() {

            _returnParent = transform.parent;
            _canvas = FindObjectOfType<Canvas>();
            _mainCam = FindObjectOfType<Camera>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            
            if (!IsDragging) {

                _container = new Container(false, false);
                _isDragging = true;
                _returnParent = transform.parent;
                _index = transform.GetSiblingIndex();
                transform.SetParent(transform.root);
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

                if (Container.InZone && Container.IsPlayable) {

                    transform.SetParent(GameManager.Instance.Middle);
                    _returnParent = null;
                    _index = -1;
                } 
            }
        }


        public void OnPointerUp(PointerEventData eventData) {

            if (!Container.InZone && !Container.IsPlayable) {

                transform.SetParent(ReturnParent);
                transform.SetSiblingIndex(Index);
            }

        }

        public void EditContainer (ContainerStates state, bool value) {

            switch (state) {

                case ContainerStates.InZone:
                    _container.InZone = value;
                    break;

                case ContainerStates.IsPlayable:
                    _container.IsPlayable = value;
                    break;
            }

        }

    }
}