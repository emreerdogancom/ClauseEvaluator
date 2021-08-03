using System;
using System.Collections.Generic;

namespace evaluator.Abstract.Clauses
{
    public interface IClauseOperand
    {
        /// <summary>
        /// Get data from operand classes (ClauseEntityOperand, ClauseValueOperand)
        /// data can be int, string, double
        /// </summary>
        /// <returns></returns>
        IConvertible GetData();

        /// <summary>
        /// Set data from input data (IDictionary<string, int>)
        /// </summary>
        /// <param name="input"></param>
        void SetData(IDictionary<string, int> input);
    }
}
