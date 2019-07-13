using System;
using System.Collections;
using System.Collections.Generic;

namespace Morphs
{
    public class GenericLerpMorph<T> : ILerpMorph<T>
    {
        private readonly T _start, _end;
        private readonly TimeIncrement _timeIncrement;
        private readonly LerpStrategy<T> _lerpStrategy;

        public GenericLerpMorph (TimeIncrement timeIncrement)
        {
            _timeIncrement = timeIncrement;
        }

        public GenericLerpMorph(T start, T end, LerpStrategy<T> lerpStrategy, TimeIncrement timeIncrement)
        {
            _start = start;
            _end = end;
            _lerpStrategy = lerpStrategy;
            _timeIncrement = timeIncrement;
        }

        public ILerpMorph<T> From(T start)
        {
            return new GenericLerpMorph<T>(start, _end, _lerpStrategy, _timeIncrement);
        }

        public ILerpMorph<T> To(T end)
        {
            return new GenericLerpMorph<T>(_start, end, _lerpStrategy, _timeIncrement);
        }

        public ILerpMorph<T> With(LerpStrategy<T> interpolation)
        {
            return new GenericLerpMorph<T>(_start, _end, interpolation, _timeIncrement);
        }

        public IEnumerator Calling (params Action<T>[] targets)
        {
            var lerpStrategy = _lerpStrategy;
            if (_lerpStrategy == null) 
                throw new MissingStrategyException(typeof(T));

            float prevT = 0, t = 0;
            while(t < 1 || (prevT < 1 && t > 1))
            {
                Deliver(targets, Interpolate(t));
                prevT = t;
                t += _timeIncrement.Invoke();
                yield return null;
            }
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

