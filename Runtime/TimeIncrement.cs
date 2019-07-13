namespace Morphs
{
    /// <summary>
    /// Total steps in a morph will be equal to 1 divided by the increment value given it remains constant.
    /// </summary>
    /// <returns>Value used to increment time during a morph.</returns>
    public delegate float TimeIncrement();
}

