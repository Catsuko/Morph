using System.Collections;

namespace Morphs
{   
    public interface IMorph
    {
        IEnumerator Forwards();
        IEnumerator Backwards();
    }
}

