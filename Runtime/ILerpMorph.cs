namespace Morphs
{
    public interface ILerpMorph<T> : IMorph<T>
    {
        ILerpMorph<T> From(T start);
        ILerpMorph<T> To(T end);
        ILerpMorph<T> With(LerpStrategy<T> interpolation);
    }
}
