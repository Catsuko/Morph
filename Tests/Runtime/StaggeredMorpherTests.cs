using NUnit.Framework;

namespace Morph.Tests
{
    public class StaggeredMorpherTests
    {
        [Test]
        public void ForwardStartsAtZero ()
        {
            var spy = new MorphSpy();
            var staggeredMorph = new StaggeredMorpher(0);

            staggeredMorph.Forwards(spy).MoveNext();

            Assert.AreEqual(0, spy.Time);
        }

        [Test]
        public void ForwardEndsAtOne ()
        {
            var spy = new MorphSpy();
            var staggeredMorph = new StaggeredMorpher(0);

            var enumerator = staggeredMorph.Forwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(1f, spy.Time);
        }

        [Test]
        public void BackwardsStartsAtOne()
        {
            var spy = new MorphSpy();
            var staggeredMorpher = new StaggeredMorpher(0);

            staggeredMorpher.Backwards(spy).MoveNext();

            Assert.AreEqual(1, spy.Time);
        }

        [Test]
        public void BackwardsEndsAtZero()
        {
            var spy = new MorphSpy();
            var staggeredMorpher = new StaggeredMorpher(0);

            var enumerator = staggeredMorpher.Backwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(0, spy.Time);
        }

        [Test]
        public void FramesThreeTimesWithOneIntermediateStep ()
        {
            var spy = new MorphSpy();
            var staggeredMorpher = new StaggeredMorpher(1);

            var enumerator = staggeredMorpher.Forwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(3, spy.FrameCount);
        }

        [Test]
        public void FirstIntermediateFrameIsHalfWithOneIntermediateFrame ()
        {
            var spy = new MorphSpy();
            var staggeredMorpher = new StaggeredMorpher(1);

            var enumerator = staggeredMorpher.Backwards(spy);
            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.AreEqual(0.5f, spy.Time);
        }

        [Test]
        public void FramesFourTimesWithTwoIntermediateSteps ()
        {
            var spy = new MorphSpy();
            var staggeredMorpher = new StaggeredMorpher(2);

            var enumerator = staggeredMorpher.Forwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(4, spy.FrameCount);
        }

        [Test]
        public void FirstIntermediateFrameIsAThirdWithTwoIntermediateFrames ()
        {
            var spy = new MorphSpy();
            var staggeredMorpher = new StaggeredMorpher(2);

            var enumerator = staggeredMorpher.Forwards(spy);
            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.AreEqual(0.333f, spy.Time, 0.01);
        }
    }
}
