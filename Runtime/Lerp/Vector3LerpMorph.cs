using System;
using System.Collections;
using UnityEngine;

namespace Morphs
{
    [Serializable]
    public class Vector3LerpMorph : ILerpMorph<Vector3>
    {
        [SerializeField]
        private Vector3 _from, _to;
        [SerializeField]
        private AnimationCurve _easingCurve;

        public IEnumerator Calling(params Action<Vector3>[] targets)
        {
            return null;
        }

        public ILerpMorph<Vector3> From(Vector3 start)
        {
            return null;
        }

        public ILerpMorph<Vector3> To(Vector3 end)
        {
            throw new NotImplementedException();
        }

        public ILerpMorph<Vector3> With(LerpStrategy<Vector3> interpolation)
        {
            throw new NotImplementedException();
        }

        private Vector3 LerpWithEase (Vector3 start, Vector3 end, float time)
        {
            return Vector3.Lerp(start, end, _easingCurve.Evaluate(time));
        }

        private float SmoothDeltaTime ()
        {
            return Time.smoothDeltaTime;
        }
    }
}

