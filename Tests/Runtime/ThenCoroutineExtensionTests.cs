using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

namespace Morph.Tests
{
    public class ThenCoroutineExtensionTests
    {
        [UnityTest]
        public IEnumerator ChainsTwoCoroutinesTogether ()
        {
            var spy = new MorphSpy();
            var morpher = new SmoothMorpher(0.05f);

            var chainedRoutine = morpher.Forwards(spy).Then(morpher.Backwards(spy));
            yield return chainedRoutine;

            Assert.AreEqual(0, spy.Time);
        }
    }
}
