using NUnit.Framework;

namespace Morph.Tests
{
    [TestFixtureSource("MorpherFixtureArgs")]
    public class MorpherTests
    {
        private readonly IMorpher _morpher;
        private MorphSpy _spy { get; set; }

        static object[] MorpherFixtureArgs =
        {
            new object[] { new SmoothMorpher(1f), "1s Duration" },
            new object[] { new SmoothMorpher(0.5f), "0.5s Duration" },
            new object[] { new SmoothMorpher(2f), "2s Duration" },
            new object[] { new StaggeredMorpher(1), "1 Intermediate Step" },
            new object[] { new StaggeredMorpher(3), "3 Intermediate Steps" },
            new object[] { new StaggeredMorpher(5), "5 Intermediate Steps" }
        };

        public MorpherTests(IMorpher morpher, string name)
        {
            _morpher = morpher;
        }

        [SetUp]
        public void InitSpy()
        {
            _spy = new MorphSpy();
        }

        [Test]
        public void ForwardStartsAtZero()
        {
            _morpher.Forwards(_spy).MoveNext();
            Assert.AreEqual(0, _spy.Time, 0.001);
        }

        [Test]
        public void ForwardEndsAtOne()
        {
            var enumerator = _morpher.Forwards(_spy);
            while (enumerator.MoveNext()) ;
            Assert.AreEqual(1f, _spy.Time, 0.001);
        }

        [Test]
        public void BackwardsStartsAtOne()
        {
            _morpher.Backwards(_spy).MoveNext();
            Assert.AreEqual(1, _spy.Time, 0.001);
        }

        [Test]
        public void BackwardsEndsAtZero()
        {
            var enumerator = _morpher.Backwards(_spy);
            while (enumerator.MoveNext()) ;
            Assert.AreEqual(0, _spy.Time, 0.001);
        }
    }
}
