namespace evaluator.Abstract.Helpers
{
    public interface IParser<T> where T : struct
    {
        string Parse(T op);
    }
}
