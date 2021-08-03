using evaluator.Abstract.Clauses;
using System;
using System.Collections.Generic;

namespace evaluator.Concrete.Operands
{
    public class ClauseValueOperand : IClauseOperand
    {
        public int Value { get; set; }


        public IConvertible GetData()
        {
            return Value;
        }

        public void SetData(IDictionary<string, int> input)
        {
            // There is no need implementation
        }
    }
}
