namespace Morphs
{
    /// <summary>
    /// Strategy used to interpolate a value from start to end given a point between them.
    /// </summary>
    /// <typeparam name="T">Type of value being lerped.</typeparam>
    /// <param name="start">When time = 0 the interpolated value will be equal to the start.</param>
    /// <param name="end">When time = 1 the interpolate value will be equal to the end.</param>
    /// <param name="time">Represents how far between the start and end to interpolate.</param>
    /// <returns>Value that sits between the start and the end.</returns>
    public delegate T LerpStrategy<T>(T start, T end, float time);
}