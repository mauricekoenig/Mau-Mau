


using UnityEngine;

namespace MK.MauMau
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private GameObject _cardTemplateFront;
        [SerializeField] private GameObject _cardTemplateBack;

        public int amount;

        [SerializeField] private Transform _local;

        public Transform Local {
            get { return _local; }
            set { _local = value; }
        }

        [SerializeField] private Transform _remote;

        public Transform Remote {
            get { return _remote; }
            set { _remote = value; }
        }

        private void Awake() {

            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start() {

            for (int i = 0; i < amount; i++) {

                var ins = Instantiate(_cardTemplateFront, Local);
            }

            for (int i = 0; i < amount; i++) {

                var ins = Instantiate(_cardTemplateBack, Remote);
            }
        }
    }
}