using System;
using System.Collections;

namespace Morphs
{   
    public interface IMorph
    {
        IEnumerator Forwards(params IMorphTarget[] targets);
        IEnumerator Backwards(params IMorphTarget[] targets);
    }
}

