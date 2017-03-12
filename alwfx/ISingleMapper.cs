namespace alwfx
{
    /// <summary>
    /// Basic generic mapper
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface ISingleMapper<in TIn, out TOut>
    {
        TOut Transform(TIn entity);
    }
}