using evaluator.Abstract.Clauses;
using evaluator.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace evaluator.Concrete.Clauses
{
    public class ClauseEvaluator : IEvaluator
    {
        private readonly IClause _clauseConfiguration;
        private readonly IDictionary<string, int> _inputData;

        public ClauseEvaluator(IClause clauseConfiguration, IDictionary<string, int> inputData)
        {
            _clauseConfiguration = clauseConfiguration;
            _inputData = inputData;
        }


        public (string expression, bool result) Evaluate()
        {
            if (_clauseConfiguration is null)
                throw new NullReferenceException();


            /* 
             * Set input data then
             * Call "invoke" method
             */
            _clauseConfiguration.ImportInputData(_inputData);
            string parsedString = _clauseConfiguration.Invoke();


            /* I didn't like this solution but it looks fastest way otherwise custom parser can be taken too much time */
            DataTable dt = new DataTable();
            var result = dt.Compute(parsedString, string.Empty);


            /* There is no return */
            if (result is not bool)
                throw new ArgumentException();


            /* Return Values */
            return (parsedString, Convert.ToBoolean(result));
        }
    }
}
