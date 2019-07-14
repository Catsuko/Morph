using UnityEngine;

namespace Morphs
{
    public class PositionMorph : MorphTarget
    {
        [SerializeField]
        private Vector3 _start, _end;

        public override void Interpolate(float time)
        {
            transform.position = Vector3.Lerp(_start, _end, time);
        }

        public void Reset()
        {
            _start = _end = transform.position;
        }
    }
}
