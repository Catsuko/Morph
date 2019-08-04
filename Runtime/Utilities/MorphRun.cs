using System;
using System.Collections;

namespace Morph
{
    internal class MorphRun : IEnumerator
    {
        private readonly Func<IEnumerator> _source;
        private IEnumerator _target;

        public MorphRun(Func<IEnumerator> source)
        {
            _source = source;
        }

        public object Current => Target().Current;

        public bool MoveNext()
        {
            return Target().MoveNext();
        }

        public void Reset()
        {
            _target = null;
        }

        private IEnumerator Target ()
        {
            if (_target == null) _target = _source.Invoke();
            return _target;
        }
    }

}
