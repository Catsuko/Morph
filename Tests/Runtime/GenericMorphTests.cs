using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Morphs.Tests
{
    public class GenericMorphTests
    {
        [UnityTest]
        public IEnumerator FirstStepIsStartValue ()
        {
            var steps = new List<Vector2>();
            var morph = new GenericLerpMorph<Vector2>().From(Vector2.left).To(Vector2.right).With(Vector2.Lerp);
            yield return morph.Calling(steps.Add);
            Assert.AreEqual(Vector2.left.x, steps[0].x);
        }

        [UnityTest]
        public IEnumerator LastStepIsEndValue ()
        {
            var steps = new List<Vector3>();
            var morph = new GenericLerpMorph<Vector3>().From(Vector3.up).To(Vector3.down).With(Vector3.Lerp);
            yield return morph.Calling(steps.Add);
            Assert.AreEqual(Vector3.down.y, steps[steps.Count - 1].y);
        }

        [UnityTest]
        public IEnumerator NotifyMultipleActions ()
        {
            var position = Vector3.zero;
            var alpha = 0f;
            var morph = new GenericLerpMorph<float>().From(0).To(1).With(Mathf.Lerp);
            yield return morph.Calling((f) => alpha = f, (f) => position = new Vector3(0, f, 0));
            Assert.AreEqual(1, alpha);
            Assert.AreEqual(1, position.y);
        }

        [UnityTest]
        public IEnumerator RaisesMissingStrategyErrorWhenLerpStrategyIsNotProvided ()
        {
            var word = "Cat";
            var morph = new GenericLerpMorph<string>().From(word).To("Dog");
            yield return null;
            Assert.Throws<MissingStrategyException>(() =>
            {
                var enumerator = morph.Calling((str) => word = str);
                while (enumerator.MoveNext()) ;
            });
        }
    }
}

