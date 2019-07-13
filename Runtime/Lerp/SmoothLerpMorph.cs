using System;
using UnityEngine;

namespace Morphs
{
    /// <summary>
    /// SmoothLerpMorph uses an AnimationCurve to provide easing while the morph runs. 
    /// Made for use in a Unity scene, it can be serialized and configured in the Inspector.
    /// </summary>

    //TODO: Created typed morphs for common types and then find a way to reuse the easing component. Can the easing decorator be applied via the editor without the user knowing?
    // Then typed morphhs can still used the ILerpedMorph interface and lazily load generic morphs when needed.
    [Serializable]
    public class SmoothLerpMorph
    {
        [SerializeField]
        private AnimationCurve _easingCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField, Min(0.001f)]
        private float _duration = 1f;
        
        public ILerpMorph<T> From<T> (T value)
        {
            return CreateMorphFor<T>().From(value);
        }

        public ILerpMorph<T> To<T> (T value)
        {
            return CreateMorphFor<T>().To(value);
        }

        public ILerpMorph<T> With<T> (LerpStrategy<T> strategy)
        {
            return CreateMorphFor<T>().With(strategy);
        }

        private ILerpMorph<T> CreateMorphFor<T> ()
        {
            return new EasingDecorator<T>(new GenericLerpMorph<T>(DeltaTime), _easingCurve);
        }

        private float DeltaTime ()
        {
            return Time.smoothDeltaTime / _duration;
        }
    }
}
