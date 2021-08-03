using evaluator.Abstract.Clauses;
using evaluator.Enum;
using System.Collections.Generic;
using System.Linq;

namespace evaluator.Concrete.Clauses
{
    public class ClauseGroup : BaseClause, IClause
    {
        public LogicalOperatorType Operator { get; set; }
        public IList<IClause> Clauses { get; set; }

        public override void ImportInputData(IDictionary<string, int> input)
        {
            foreach (IClause item in Clauses)
            {
                item.ImportInputData(input);
            }
        }

        public override string Invoke()
        {
            string s = "";

            var last = Clauses.LastOrDefault();

            foreach (IClause item in Clauses)
            {
                if (item.Equals(last))
                    s += "(" + item.Invoke() + ")";
                else
                    s += "(" + item.Invoke() + ") " + LogicalOperatorParsing(Operator) + " ";
            }

            return s;
        }

        protected virtual string LogicalOperatorParsing(LogicalOperatorType op)
        {
            return op.ToString();
        }
    }
}
