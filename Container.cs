

using UnityEngine;

namespace MK.MauMau
{
    public struct Container
    {
        public bool InZone;
        public bool IsPlayable;

        public Container (bool inZone, bool isPlayable) {

            InZone = inZone;
            IsPlayable = isPlayable;
        }
    }
}