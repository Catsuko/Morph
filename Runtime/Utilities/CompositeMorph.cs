using System.Collections.Generic;

namespace Morph
{
    internal class CompositeMorph : IMorph
    {
        private readonly IEnumerable<IMorph> _morphs;

        internal CompositeMorph(params IMorph[] morphs)
        {
            _morphs = morphs;
        }

        public CompositeMorph(IEnumerable<IMorph> morphs)
        {
            _morphs = morphs;
        }

        public void Frame(float time)
        {
            foreach (var morph in _morphs) morph.Frame(time);
        }
    }
}

