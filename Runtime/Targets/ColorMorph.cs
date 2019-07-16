using System;
using UnityEngine;
using UnityEngine.Events;

namespace Morphs
{
    public class ColorMorph : MorphTarget
    {
        [Serializable]
        private class ColorChangedEvent : UnityEvent<Color> { }

        [SerializeField]
        private Color _start = Color.green, _finish = Color.red;
        [SerializeField]
        private ColorChangedEvent _onColorChanged;

        public override void Interpolate(float time)
        {
            _onColorChanged.Invoke(Color.Lerp(_start, _finish, time));
        }
    }
}
