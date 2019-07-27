using NUnit.Framework;

namespace Morph.Tests
{
    public class DeltaTimeMorpherTests
    {
        [Test]
        public void ForwardInterpolationStartsAtZero ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new DeltaTimeMorpher();

            smoothMorph.Forwards(spy).MoveNext();

            Assert.AreEqual(0, spy.Time);
        }

        [Test]
        public void ForwardInterpolationEndsAtOne ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new DeltaTimeMorpher();

            var enumerator = smoothMorph.Forwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(1f, spy.Time);
        }

        [Test]
        public void BackwardInterpolationStartsAtOne ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new DeltaTimeMorpher();

            smoothMorph.Backwards(spy).MoveNext();

            Assert.AreEqual(1, spy.Time);
        }

        [Test]
        public void BackwardInterpolationEndsAtZero ()
        {
            var spy = new MorphTargetSpy();
            var smoothMorph = new DeltaTimeMorpher();

            var enumerator = smoothMorph.Backwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(0, spy.Time);
        }

        private class MorphTargetSpy : IMorph
        {
            public float Time { get; private set; }

            public MorphTargetSpy()
            {
                Time = -1;
            }

            public void Frame(float time)
            {
                Time = time;
            }
        }
    }
}
