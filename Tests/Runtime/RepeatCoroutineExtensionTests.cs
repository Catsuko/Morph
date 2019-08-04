using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Morph.Tests
{
    public class RepeatCoroutineExtensionTests
    {
        [UnityTest]
        public IEnumerator RepeatsASingleTime ()
        {
            var morpher = new SmoothMorpher(0.1f);
            var spy = new MorphSpy();

            yield return morpher.Forwards(spy).Repeat(1);

            Assert.AreEqual(1, spy.TimesRepeated);
        }

        [UnityTest]
        public IEnumerator RepeatsTwice ()
        {
            var morpher = new SmoothMorpher(0.1f);
            var spy = new MorphSpy();

            yield return morpher.Forwards(spy).Repeat(2);

            Assert.AreEqual(2, spy.TimesRepeated);
        }

        [UnityTest]
        public IEnumerator RepeatsThreeTimes ()
        {
            var morpher = new SmoothMorpher(0.1f);
            var spy = new MorphSpy();

            yield return morpher.Forwards(spy).Repeat(3);

            Assert.AreEqual(3, spy.TimesRepeated);
        }

        [Test]
        public void RepeatWithNoArgumentLastsForever ()
        {
            var morpher = new SmoothMorpher(0.1f);
            var spy = new MorphSpy();
            var enumerator = morpher.Forwards(spy).Repeat();

            var foreverThreshold = 1000;
            for (int i = 0; i < foreverThreshold; i++)
            {
                enumerator.MoveNext();
            }

            Assert.IsTrue(enumerator.MoveNext());
        }

        private class MorphSpy : IMorph
        {
            public int TimesRepeated { get; private set; }
            private float _previous = -1f;

            public void Frame(float time)
            {
                if (time < _previous) TimesRepeated++;
                _previous = time;
            }
        }
    }
}
