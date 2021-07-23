

using UnityEngine;

namespace MK.MauMau
{
    [CreateAssetMenu]
    public sealed class Card : ScriptableObject
    {
        [SerializeField] private CardValue _cardValue;

        public CardValue Value {

            get { return _cardValue; }
            set { _cardValue = value; }
        }

        [SerializeField] private CardColor _cardColor;

        public CardColor Color {

            get { return _cardColor; }
            set { _cardColor = value; }
        }

        [SerializeField] private Sprite _cardSprite;

        public Sprite Sprite {
            get { return _cardSprite; }
            set { _cardSprite = value; }
        }
    }
}
