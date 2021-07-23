


using UnityEngine;
using UnityEngine.UI;

namespace MK.MauMau
{
    public sealed class Zone : MonoBehaviour
    {
        private Image _area;

        public Image Area {

            get { return _area; }
            private set { }
        }

        private void Awake() {

            _area = GetComponent<Image>();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            
            if (collision.transform.GetComponent<Controller>()) {

                var controller = collision.transform.GetComponent<Controller>();
                controller.EditContainer(ContainerStates.InZone, true);
                _area.color = Constants.ZoneBlinkColor;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            
            if (collision.transform.GetComponent<Controller>()) {

                var controller = collision.transform.GetComponent<Controller>();
                controller.EditContainer(ContainerStates.InZone, false);
                _area.color = Constants.ZoneNormalColor;
            }
        }

    }
}