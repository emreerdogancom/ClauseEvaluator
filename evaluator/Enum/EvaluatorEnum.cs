namespace evaluator.Enum
{

    /// <summary>
    /// Logical Operator Types
    /// </summary>
    public enum LogicalOperatorType
    {
        AND = 0,
        OR = 1
    }


    /// <summary>
    /// Comparison Operator Types
    /// </summary>
    public enum ComparisonOperatorType
    {
        /// <summary>
        /// =
        /// </summary>
        Equal = 0,

        /// <summary>
        /// >
        /// </summary>
        GreaterThan = 1,

        /// <summary>
        /// <
        /// </summary>
        LessThan = 2,

        /// <summary>
        /// >=
        /// </summary>
        GreaterThanOrEqualto = 3,

        /// <summary>
        /// <=
        /// </summary>
        LessThanOrEqualto = 4,

        /// <summary>
        /// !=
        /// </summary>
        NotEqualto = 5,
    }

}
