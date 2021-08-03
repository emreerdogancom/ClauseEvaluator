using System.Collections.Generic;

namespace evaluator.Abstract.Clauses
{
    public interface IClause
    {
        /// <summary>
        /// Execute the code for own class (ClauseGroup, ClauseLine)
        /// </summary>
        /// <returns></returns>
        string Invoke();

        /// <summary>
        /// Import fata from IDictionary<string, int>
        /// </summary>
        /// <param name="input"></param>
        void ImportInputData(IDictionary<string, int> input);
    }
}
