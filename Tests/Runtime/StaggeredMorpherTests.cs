using NUnit.Framework;

namespace Morph.Tests
{
    [TestFixtureSource("MorpherFixtureArgs")]
    public class StaggeredMorpherTests
    {
        private readonly IMorpher _morpher;
        private readonly int _intermediateSteps;
        private MorphSpy _spy { get; set; }

        static object[] MorpherFixtureArgs =
        {
            new object[] { new StaggeredMorpher(1), 1 },
            new object[] { new StaggeredMorpher(3), 3 },
            new object[] { new StaggeredMorpher(5), 5 },
        };

        public StaggeredMorpherTests (IMorpher morpher, int intermediateSteps)
        {
            _morpher = morpher;
            _intermediateSteps = intermediateSteps;
        }

        [SetUp]
        public void InitSpy()
        {
            _spy = new MorphSpy();
        }

        [Test]
        public void FramesMatchIntermediateStepCountPlusTwo ()
        {
            var enumerator = _morpher.Forwards(_spy);
            while (enumerator.MoveNext()) ;
            Assert.AreEqual(_intermediateSteps + 2, _spy.FrameCount);
        }

        [Test]
        public void FirstIntermediateFrameHasExpectedTime ()
        {
            var enumerator = _morpher.Forwards(_spy);
            enumerator.MoveNext();
            enumerator.MoveNext();
            var expectedTime = 1f / (_intermediateSteps + 1);
            Assert.AreEqual(expectedTime, _spy.Time);
        }
    }
}
