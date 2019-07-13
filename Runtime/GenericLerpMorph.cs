using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Morphs
{
    public class GenericLerpMorph<T> : ILerpMorph<T>
    {
        private readonly T _start, _end;
        private readonly LerpStrategy<T> _lerpStrategy;

        public GenericLerpMorph ()
        {
        }

        public GenericLerpMorph(T start, T end, LerpStrategy<T> lerpStrategy)
        {
            _start = start;
            _end = end;
            _lerpStrategy = lerpStrategy;
        }

        public ILerpMorph<T> From(T start)
        {
            return new GenericLerpMorph<T>(start, _end, _lerpStrategy);
        }

        public ILerpMorph<T> To(T end)
        {
            return new GenericLerpMorph<T>(_start, end, _lerpStrategy);
        }

        public ILerpMorph<T> With(LerpStrategy<T> interpolation)
        {
            return new GenericLerpMorph<T>(_start, _end, interpolation);
        }

        public IEnumerator Calling (params Action<T>[] targets)
        {
            if (_lerpStrategy == null) 
                throw new MissingStrategyException(typeof(T));

            float t = 0;
            while(t < 1)
            {
                Deliver(targets, Interpolate(t));
                yield return null;
                t += Time.deltaTime;
            }

            Deliver(targets, Interpolate(t));
        }

        private void Deliver (IEnumerable<Action<T>> targets, T interpolated)
        {
            foreach (var target in targets)
                target.Invoke(interpolated);
        }

        private T Interpolate (float time)
        {
            return _lerpStrategy.Invoke(_start, _end, time);
        }
    }
}
