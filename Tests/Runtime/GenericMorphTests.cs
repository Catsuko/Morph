using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Morphs.Tests
{
    public class GenericLerpMorphTests
    {
        [UnityTest]
        public IEnumerator FirstStepIsStartValue ()
        {
            var steps = new List<Vector2>();
            var morph = new GenericLerpMorph<Vector2>(() => 0.1f).From(Vector2.left).To(Vector2.right).With(Vector2.Lerp);
            yield return morph.Calling(steps.Add);
            Assert.AreEqual(Vector2.left.x, steps[0].x);
        }

        [UnityTest]
        public IEnumerator LastStepIsEndValue ()
        {
            var steps = new List<Vector3>();
            var morph = new GenericLerpMorph<Vector3>(() => 0.1f).From(Vector3.up).To(Vector3.down).With(Vector3.Lerp);
            yield return morph.Calling(steps.Add);
            Assert.AreEqual(Vector3.down.y, steps[steps.Count - 1].y);
        }

        [UnityTest]
        public IEnumerator NotifyMultipleActions ()
        {
            var position = Vector3.zero;
            var alpha = 0f;
            var morph = new GenericLerpMorph<float>(() => 0.1f).From(0).To(1).With(Mathf.Lerp);
            yield return morph.Calling((f) => alpha = f, (f) => position = new Vector3(0, f, 0));
            Assert.AreEqual(1, alpha);
            Assert.AreEqual(1, position.y);
        }

        [UnityTest]
        public IEnumerator RaisesMissingStrategyErrorWhenLerpStrategyIsNotProvided ()
        {
            var word = "Cat";
            var morph = new GenericLerpMorph<string>(() => 0.1f).From(word).To("Dog");
            yield return null;
            Assert.Throws<MissingStrategyException>(() =>
            {
                var enumerator = morph.Calling((str) => word = str);
                while (enumerator.MoveNext()) ;
            });
        }

        [UnityTest]
        public IEnumerator MorphStepsMatchOneDividedByTheTimeIncrement ()
        {
            var stepSize = 0.25f;
            var steps = new List<int>();
            var morph = new GenericLerpMorph<int>(() => stepSize).From(0).To(10).With((a, b, t) => a);
            yield return morph.Calling(steps.Add);
            Assert.AreEqual(Mathf.Floor(1 / stepSize), steps.Count);
        }
    }
}

