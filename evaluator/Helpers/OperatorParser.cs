using evaluator.Enum;

namespace evaluator.Helpers
{

    public class OperatorParser : BaseParser<ComparisonOperatorType>
    {
        public override string Parse(ComparisonOperatorType op) 
        {
            switch (op)
            {
                case ComparisonOperatorType.Equal:
                    return "=";
                case ComparisonOperatorType.GreaterThan:
                    return ">";
                case ComparisonOperatorType.LessThan:
                    return "<";
                case ComparisonOperatorType.GreaterThanOrEqualto:
                    return ">=";
                case ComparisonOperatorType.LessThanOrEqualto:
                    return "<=";
                case ComparisonOperatorType.NotEqualto:
                    return "!=";
                default:
                    return "";
            }
        }


    }
}
