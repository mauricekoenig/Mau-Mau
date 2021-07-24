




using System.Collections.Generic;
using UnityEngine;

namespace MK.MauMau
{
    [CreateAssetMenu]
    public sealed class Deck : ScriptableObject
    {
        public List<Card> Cards = new List<Card>();
        public static readonly int Length = 32;
    }
}