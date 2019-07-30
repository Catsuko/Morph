using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Morph.Tests
{
    public class RepeatCoroutineExtensionTests
    {
        [UnityTest]
        public IEnumerator RepeatsASingleTime ()
        {
            var spy = new EnumeratorSpy();

            yield return spy.Run();
            yield return spy.Run();
            //yield return spy.Run().Repeat(1);

            Assert.AreEqual(2, spy.TimesEnumerated);
        }

        [UnityTest]
        public IEnumerator RepeatsTwice ()
        {
            var spy = new EnumeratorSpy();

            yield return spy.Run().Repeat(2);

            Assert.AreEqual(3, spy.TimesEnumerated);
        }

        [UnityTest]
        public IEnumerator RepeatsThreeTimes ()
        {
            var spy = new EnumeratorSpy();

            yield return spy.Run().Repeat(3);

            Assert.AreEqual(4, spy.TimesEnumerated);
        }

        [Test]
        public void RepeatWithNoArgumentLastsForever ()
        {
            var spy = new EnumeratorSpy();
            var enumerator = spy.Run().Repeat();
            var foreverThreshold = 1000;

            for (int i = 0; i < foreverThreshold; i++)
            {
                enumerator.MoveNext();
            }

            Assert.IsTrue(enumerator.MoveNext());
        }

        private class EnumeratorSpy
        {
            public int TimesEnumerated { get; private set; }

            public IEnumerator Run ()
            {
                TimesEnumerated++;
                yield return null;
            }
        }
    }
}
