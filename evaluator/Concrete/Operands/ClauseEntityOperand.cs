using evaluator.Abstract.Clauses;
using System;
using System.Collections.Generic;

namespace evaluator.Concrete.Operands
{
    public class ClauseEntityOperand : IClauseOperand
    {
        public string Entity { get; set; }

        public IConvertible GetData()
        {
            return Entity;
        }

        public void SetData(IDictionary<string, int> input)
        {
            if (input == null)
                throw new NullReferenceException();


            int outValue;
            if (!input.TryGetValue(Entity, out outValue))
            {
                throw new ArgumentNullException();
            }

            Entity = outValue.ToString();
        }
    }
}
