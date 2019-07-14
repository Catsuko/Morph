using System;
using System.Collections;

namespace Morphs
{   
    public interface IMorph<T>
    {
        IEnumerator Calling(params Action<T>[] targets);
    }

    public interface IMorph
    {
        IEnumerator Forwards();
        IEnumerator Backwards();
    }
}

