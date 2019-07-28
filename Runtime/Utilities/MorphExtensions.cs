using System.Collections.Generic;
using UnityEngine;

namespace Morph
{
    public static class MorphExtensions
    {
        public static IMorph And(this IMorph morph, params IMorph[] others) => new CompositeMorph(new List<IMorph>(others) { morph });
        public static IMorph WithEasing(this IMorph morph, AnimationCurve curve) => new WithEasingDecorator(morph, curve);
    }
}

