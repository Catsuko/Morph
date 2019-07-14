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
        private List<MorphTarget> _targets = new List<MorphTarget>();
        [SerializeField]
        private AnimationCurve _easingCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public SmoothMorph()
        {
        }

        public IEnumerator Backwards()
        {
            return Run(1f);
        }

        public IEnumerator Forwards()
        {
            return Run(0f);
        }

        private IEnumerator Run (float directionOffset)
        {
            float time = 0, previousTime = 0;
            while(time < 1 || (previousTime < 1 && time >= 1))
            {
                var easedTime = _easingCurve.Evaluate(directionOffset > 0 ? directionOffset - time : time);
                foreach (var target in _targets) target.Interpolate(easedTime);
                previousTime = time;
                time += Time.smoothDeltaTime;
                yield return null;
            }
        }
    }
}
