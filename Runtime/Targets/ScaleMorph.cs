using UnityEngine;

namespace Morphs
{
    public class ScaleMorph : MorphTarget
    {
        [SerializeField]
        private AnimationCurve _scaleCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        [SerializeField]
        private float _scaleStrength = 1f;

        public override void Interpolate(float time)
        {
            transform.localScale = Vector3.one * _scaleCurve.Evaluate(time) * _scaleStrength;
        }
    }
}

