﻿using System;
using System.Collections;
using UnityEngine;

namespace Morph
{
    [Serializable]
    public class SmoothMorpher : IMorpher
    {
        [SerializeField]
        private float _duration = 1f;

        public SmoothMorpher()
        {
        }

        public SmoothMorpher(float duration)
        {
            _duration = duration;
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
            float time = 0, previousTime = 0;
            while(_duration > 0 && (time < 1 || (previousTime < 1 && time >= 1)))
            {
                target.Frame(Mathf.Abs(directionOffset - Mathf.Clamp01(time)));
                previousTime = time;
                time += Time.deltaTime / _duration;
                yield return null;
            }
        }
    }
}
