namespace Morph.Tests
{
    internal class MorphSpy : IMorph
    {
        public float Time { get; private set; }
        public int FrameCount { get; private set; }
        public bool WasCalled { get { return FrameCount > 0; } }

        public MorphSpy()
        {
            Time = -1;
        }

        public void Frame(float time)
        {
            FrameCount++;
            Time = time;
        }
    }
}

