

using UnityEngine;

namespace MK.MauMau
{
    [CreateAssetMenu]
    public sealed class Card : ScriptableObject
    {
        public Value value;
        public ColorProperty color;
        public Sprite sprite;
    }
}
