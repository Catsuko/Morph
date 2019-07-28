using UnityEngine;

namespace Morph
{
    internal class WithEasingDecorator : IMorph
    {
        private readonly IMorph _source;
        private readonly AnimationCurve _easingCurve;

        internal WithEasingDecorator(IMorph source, AnimationCurve easingCurve)
        {
            _source = source;
            _easingCurve = easingCurve;
        }

        public void Frame(float time)
        {
            _source.Frame(_easingCurve.Evaluate(time));
        }
    }
}
