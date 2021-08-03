using evaluator.Abstract.Helpers;

namespace evaluator.Helpers
{
    public abstract class BaseParser<T> : IParser<T> where T : struct
    {
        public abstract string Parse(T op);
    }
}
