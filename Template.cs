
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MK.MauMau
{
    public sealed class Template : MonoBehaviour
    {
        [SerializeField] private Card _card;

        public Card Card {

            get { return _card; }
            set { _card = value; }
        }

        private Image _cardImage;

        public Image Image {
            get { return _cardImage; }
            set { _cardImage = value; }
        }

        private void Awake() {

            _cardImage = GetComponent<Image>();
        }

        private void Start() {

            SetSprite();
        }

        private void SetSprite() {

            if (Image != null && Card != null) {

                Image.sprite = Card.Sprite;
            }
        }
    }
}