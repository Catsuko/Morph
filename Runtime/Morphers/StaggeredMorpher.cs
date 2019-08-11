using System;
using System.Collections;
using UnityEngine;

namespace Morph
{
    [Serializable]
    public class StaggeredMorpher : IMorpher
    {
        [SerializeField, Range(0, 100)]
        private int _intermediateSteps = 1;
        [SerializeField, Range(0, 100)]
        private float _durationInSeconds = 1;

        public StaggeredMorpher(int intermerdiateSteps)
        {
            _intermediateSteps = intermerdiateSteps;
        }

        public IEnumerator Backwards(IMorph target)
        {
            return Run(target, 1f);
        }

        public IEnumerator Forwards(IMorph target)
        {
            return Run(target, 0f);
        }

        private IEnumerator Run (IMorph target, float directionOffset)
        {
            var steps = _intermediateSteps + 2;
            var waitBetweenSteps = new WaitForSeconds(_durationInSeconds / steps);
            var stepSize = 1f / (steps - 1);
            for (int i = 0; i < steps; i++)
            {
                target.Frame(Mathf.Clamp01(Mathf.Abs(directionOffset - i * stepSize)));
                yield return waitBetweenSteps;
            }
        }
    }
}