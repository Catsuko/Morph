using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Morphs
{
    [Serializable]
    public class SmoothMorph : IMorph
    {
        [SerializeField]
        private AnimationCurve _easingCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        [SerializeField]
        private float _duration = 1f;
        
        public IEnumerator Backwards(params IMorphTarget[] targets)
        {
            return Run(targets, 1f);
        }

        public IEnumerator Forwards(params IMorphTarget[] targets)
        {
            return Run(targets, 0f);
        }

        private IEnumerator Run (IEnumerable<IMorphTarget> targets, float directionOffset)
        {
            if (_duration <= 0)
                throw new InvalidOperationException("Morphing failed: Morph Duration must be a positive non-zero amount.");

            float time = 0, previousTime = 0;
            while(time < 1 || (previousTime < 1 && time >= 1))
            {
                var easedTime = _easingCurve.Evaluate(directionOffset > 0 ? directionOffset - time : time);
                foreach (var target in targets) target.Interpolate(easedTime);
                previousTime = time;
                time += Time.smoothDeltaTime / _duration;
                yield return null;
            }
        }
    }
}
