using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Morph.Tests
{
    public class SmoothMorpherTests
    {
        [Test]
        public void ForwardStartsAtZero ()
        {
            var spy = new MorphSpy();
            var smoothMorph = new SmoothMorpher();

            smoothMorph.Forwards(spy).MoveNext();

            Assert.AreEqual(0, spy.Time);
        }

        [Test]
        public void ForwardEndsAtOne ()
        {
            var spy = new MorphSpy();
            var smoothMorph = new SmoothMorpher();

            var enumerator = smoothMorph.Forwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(1f, spy.Time);
        }

        [Test]
        public void BackwardsStartsAtOne ()
        {
            var spy = new MorphSpy();
            var smoothMorph = new SmoothMorpher();

            smoothMorph.Backwards(spy).MoveNext();

            Assert.AreEqual(1, spy.Time);
        }

        [Test]
        public void BackwardsEndsAtZero ()
        {
            var spy = new MorphSpy();
            var smoothMorph = new SmoothMorpher();

            var enumerator = smoothMorph.Backwards(spy);
            while (enumerator.MoveNext()) ;

            Assert.AreEqual(0, spy.Time);
        }

        [UnityTest]
        public IEnumerator MorphWithALongDuration ()
        {
            var duration = 2f;
            var morpher = new SmoothMorpher(duration);
            var timeStarted = Time.time;

            yield return morpher.Forwards(new MorphSpy());

            Assert.AreEqual(duration, Time.time - timeStarted, 0.1);
        }

        [UnityTest]
        public IEnumerator MorphWithAShortDuration()
        {
            var duration = 0.5f;
            var morpher = new SmoothMorpher(duration);
            var timeStarted = Time.time;

            yield return morpher.Forwards(new MorphSpy());

            Assert.AreEqual(duration, Time.time - timeStarted, 0.1);
        }
    }
}
