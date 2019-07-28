using System.Collections;

namespace Morph
{   
    public interface IMorpher
    {
        IEnumerator Forwards(IMorph target);
        IEnumerator Backwards(IMorph target);
    }
}

