using evaluator.Abstract.Clauses;
using System.Collections.Generic;

namespace evaluator.Concrete.Clauses
{
    public abstract class BaseClause : IClause
    {
        public BaseClause()
        {

        }

        public abstract string Invoke();

        public abstract void ImportInputData(IDictionary<string, int> input);
    }
}
