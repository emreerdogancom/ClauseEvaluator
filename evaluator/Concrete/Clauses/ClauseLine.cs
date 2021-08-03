using evaluator.Abstract.Clauses;
using evaluator.Enum;
using evaluator.Helpers;
using System.Collections.Generic;

namespace evaluator.Concrete.Clauses
{
    public class ClauseLine : BaseClause, IClause
    {
        public IClauseOperand LOperand { get; set; }
        public ComparisonOperatorType Operator { get; set; }
        public IClauseOperand ROperand { get; set; }

        public override string Invoke()
        {
            string line = LOperand.GetData() + ComparisonOperatorParsing(Operator) + ROperand.GetData();
            return line;
        }

        public override void ImportInputData(IDictionary<string, int> input)
        {
            LOperand.SetData(input);
            ROperand.SetData(input);
        }

        /* Note myself: DI can be used *IParser */
        protected virtual string ComparisonOperatorParsing(ComparisonOperatorType op)
        {
            return new OperatorParser().Parse(op);
        }


    }
}
