using evaluator.Abstract.Clauses;
using evaluator.Concrete.Clauses;
using evaluator.Concrete.Operands;
using evaluator.Enum;
using System;
using System.Collections.Generic;

namespace evaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Execute */
            ClauseEvaluator ce = new ClauseEvaluator(Sample1().clause, null);
            Console.WriteLine(ce.Evaluate());
        }


        /// <summary>
        /// Sample 1
        /// </summary>
        /// <returns></returns>
        public static (IClause clause, IDictionary<string, int> input) Sample1()
        {
            /* Input Data for Sample 1 */
            var data = new Dictionary<string, int>();
            data.Add("Amount1", 100);

            /* Sample 1 */
            var clause = new ClauseLine
            {
                LOperand = new ClauseEntityOperand { Entity = "Amount1" },
                //LOperand = new ClauseValueOperand { Value = 1000 },
                Operator = ComparisonOperatorType.GreaterThanOrEqualto,
                ROperand = new ClauseValueOperand { Value = 1000 }
            };

            return (clause, data);
        }

        /// <summary>
        /// Sample 2
        /// </summary>
        /// <returns></returns>
        public static (IClause clause, IDictionary<string, int> input) Sample2()
        {
            /* Input Data for Sample 2 */
            var data = new Dictionary<string, int>();
            data.Add("Amount1", 10);
            data.Add("Amount2", 77);
            data.Add("Amount3", 88);
            data.Add("Amount4", 99);

            /* Sample 2 */
            var clause = new ClauseGroup
            {
                Operator = LogicalOperatorType.OR,
                Clauses = new List<IClause>
                    {
                        new ClauseGroup
                        {
                            Operator = LogicalOperatorType.AND,
                            Clauses = new List<IClause>
                             {
                                new ClauseLine
                                {
                                    LOperand = new ClauseEntityOperand { Entity = "Amount1" },
                                    Operator = ComparisonOperatorType.GreaterThanOrEqualto,
                                    ROperand = new ClauseEntityOperand { Entity = "Amount2" }
                                },
                                new ClauseLine
                                {
                                    LOperand = new ClauseEntityOperand { Entity = "Amount3" },
                                    Operator = ComparisonOperatorType.Equal,
                                    ROperand = new ClauseEntityOperand { Entity = "Amount4" }
                                }
                            }
                        },
                        new ClauseLine
                        {
                            LOperand = new ClauseEntityOperand { Entity = "Amount2" },
                            Operator = ComparisonOperatorType.LessThan,
                            ROperand = new ClauseEntityOperand { Entity = "Amount3" }
                        }
                    }
            };

            return (clause, data);
        }

    }
}
