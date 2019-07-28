using NUnit.Framework;

namespace Morph.Tests
{
    public class AndExtensionTests
    {
        [Test]
        public void RunTwoMorphsAtTheSameTime ()
        {
            var firstSpy = new MorphSpy();
            var secondSpy = new MorphSpy();

            firstSpy.And(secondSpy).Frame(1);

            Assert.AreEqual(true, firstSpy.WasCalled && secondSpy.WasCalled);
        }

        [Test]
        public void RunThreeMorphsAtTheSameTime()
        {
            var firstSpy = new MorphSpy();
            var secondSpy = new MorphSpy();
            var thirdSpy = new MorphSpy();

            firstSpy.And(secondSpy, thirdSpy).Frame(1);

            Assert.AreEqual(true, firstSpy.WasCalled && secondSpy.WasCalled && thirdSpy.WasCalled);
        }

        [Test]
        public void ChainMultipleAnds ()
        {
            var firstSpy = new MorphSpy();
            var secondSpy = new MorphSpy();
            var thirdSpy = new MorphSpy();

            firstSpy.And(secondSpy).And(thirdSpy).Frame(1);

            Assert.AreEqual(true, firstSpy.WasCalled && secondSpy.WasCalled && thirdSpy.WasCalled);
        }
    }
}

