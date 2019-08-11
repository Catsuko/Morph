using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Morph.Tests
{
    [TestFixtureSource("MorpherFixtureArgs")]
    public class SmoothMorpherTests
    {
        private readonly IMorpher _morpher;
        private readonly float _morphDuration;   
        private MorphSpy _spy { get; set; }

        static object[] MorpherFixtureArgs = 
        {
            new object[] { new SmoothMorpher(), 1f },
            new object[] { new SmoothMorpher(0.5f), 0.5f },
            new object[] { new SmoothMorpher(2f), 2f },
        };

        public SmoothMorpherTests(IMorpher morpher, float morphDuration)
        {
            _morpher = morpher;
            _morphDuration = morphDuration;
        }

        [SetUp]
        public void InitSpy ()
        {
            _spy = new MorphSpy();
        }

        [UnityTest]
        public IEnumerator MorphRunsForDuration ()
        {
            var timeStarted = Time.time;
            yield return _morpher.Forwards(_spy);
            Assert.AreEqual(_morphDuration, Time.time - timeStarted, 0.1);
        }
    }
}
