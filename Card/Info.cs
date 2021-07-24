
using UnityEngine;
using UnityEngine.UI;

namespace MK.MauMau
{
    public sealed class Info : MonoBehaviour
    {
        public Card Data { get; set; }
        public Image Sprite { get; set; }

        void Awake() {

            Sprite = GetComponent<Image>();
        }

        public void Construct (Card card) {

            Data = card;
            Sprite.sprite = card.sprite;
        }
    }
}