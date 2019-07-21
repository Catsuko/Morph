using System.Collections;
using System.Collections.Generic;
using Morphs;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Morphs.Tests
{
    public class SmoothMorphTests
    {
        [Test]
        public void ForwardInterpolationStartsAtZero ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new SmoothMorph();

            smoothMorph.Forwards(spy).MoveNext();

            Assert.AreEqual(0, spy.Time);
        }

        [Test]
        public void ForwardInterpolationEndsAtOne ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new SmoothMorph();

            var enumerator = smoothMorph.Forwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(1f, spy.Time);
        }

        [Test]
        public void BackwardInterpolationStartsAtOne ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new SmoothMorph();

            smoothMorph.Backwards(spy).MoveNext();

            Assert.AreEqual(1, spy.Time);
        }

        [Test]
        public void BackwardInterpolationEndsAtZero ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new SmoothMorph();

            var enumerator = smoothMorph.Backwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(0, spy.Time);
        }

        private class MorphTargetSpy : IMorphTarget
        {
            public float Time { get; private set; }

            public MorphTargetSpy()
            {
                Time = -1;
            }

            public void Interpolate(float time)
            {
                Time = time;
            }
        }
    }
}
