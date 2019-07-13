using System;
using System.Collections;
using UnityEngine;

namespace Morphs
{
    internal class EasingDecorator<T> : ILerpMorph<T>
    {
        private readonly ILerpMorph<T> _source;
        private readonly AnimationCurve _easingCurve;

        internal EasingDecorator(ILerpMorph<T> source, AnimationCurve easingCurve)
        {
            _source = source;
            _easingCurve = easingCurve;
        }

        public IEnumerator Calling(params Action<T>[] targets)
        {
            return _source.Calling(targets);
        }

        public ILerpMorph<T> From(T start)
        {
            return Decorate(_source.From(start));
        }

        public ILerpMorph<T> To(T end)
        {
            return Decorate(_source.To(end));
        }

        public ILerpMorph<T> With(LerpStrategy<T> interpolation)
        {
            LerpStrategy<T> easedStrategy = (start, end, time) => interpolation.Invoke(start, end, _easingCurve.Evaluate(time));
            return new EasingDecorator<T>(_source.With(easedStrategy), _easingCurve);
        }

        private ILerpMorph<T> Decorate (ILerpMorph<T> source)
        {
            return new EasingDecorator<T>(source, _easingCurve);
        }
    }
}
