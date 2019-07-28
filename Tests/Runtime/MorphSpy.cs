namespace Morph.Tests
{
    internal class MorphSpy : IMorph
    {
        public float Time { get; private set; }
        public bool WasCalled { get { return Time >= 0; } }

        public MorphSpy()
        {
            Time = -1;
        }

        public void Frame(float time)
        {
            Time = time;
        }
    }
}

