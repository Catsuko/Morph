using System;
using UnityEngine;

namespace Morphs
{
    [Serializable]
    public abstract class MorphTarget : MonoBehaviour
    {
        public abstract void UpdateTo(float time);
    }
}

