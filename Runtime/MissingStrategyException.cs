using System;

namespace Morphs
{
    public class MissingStrategyException : Exception
    {
        private readonly Type _morphValueType;

        public MissingStrategyException(Type morphValueType)
        {
            _morphValueType = morphValueType;
        }

        public override string Message => $"Failed to morph {_morphValueType.Name} value because no strategy was given, " +
                                           "you can provide one using the With method.";
    }
}

