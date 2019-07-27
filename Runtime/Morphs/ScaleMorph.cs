using UnityEngine;

namespace Morph
{
    public class ScaleMorph : MonoBehaviour, IMorph
    {
        [SerializeField]
        private Transform _targetTransform;
        [SerializeField]
        private AnimationCurve _growthCurve;
        [SerializeField]
        private float _strength;

        public void Frame(float time)
        {
            _targetTransform.localScale = Vector3.one * _growthCurve.Evaluate(time) * _strength;
        }

        public void Reset()
        {
            _targetTransform = transform;
            _growthCurve = AnimationCurve.Constant(0, 1, 1);
            _strength = 1f;
        }
    }
}

