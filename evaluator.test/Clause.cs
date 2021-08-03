using evaluator.Abstract.Clauses;
using evaluator.Concrete.Clauses;
using evaluator.Concrete.Operands;
using evaluator.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace evaluator.test
{
    public class Tests
    {
        [Test]
        public void Evaluate_ClauseTest_Sample1()
        {
            ClauseEvaluator ce = new ClauseEvaluator(Sample1().clause, Sample1().input);
            var obj = ce.Evaluate();

            /* write std output */
            Console.WriteLine(obj.expression);

            /* 10>=1000
             * it should be "False" */
            Assert.AreEqual(false, obj.result);
        }

        public (IClause clause, IDictionary<string, int> input) Sample1()
        {
            /* Input Data */
            var data = new Dictionary<string, int>();
            data.Add("Amount1", 10);


            /* Sample Clause */
            var clause = new ClauseLine
            {
                LOperand = new ClauseEntityOperand { Entity = "Amount1" },
                Operator = ComparisonOperatorType.GreaterThanOrEqualto,
                ROperand = new ClauseValueOperand { Value = 1000 }
            };

            return (clause, data);
        }





        [Test]
        public void Evaluate_ClauseTest_Sample2()
        {
            ClauseEvaluator ce = new ClauseEvaluator(Sample2().clause, Sample2().input);
            var obj = ce.Evaluate();

            /* write std output */
            Console.WriteLine(obj.expression);

            /* (10>=100) AND (200=10)
             * it should be "False"
             */
            Assert.AreEqual(false, obj.result);
        }

        public (IClause clause, IDictionary<string, int> input) Sample2()
        {
            /* Input Data*/
            var data = new Dictionary<string, int>();
            data.Add("Amount1", 10);
            data.Add("Amount2", 10);


            /* Sample Clause */
            var clause = new ClauseGroup
                        {
                            Operator = LogicalOperatorType.AND,
                            Clauses = new List<IClause>
                                {
                                new ClauseLine
                                {
                                    LOperand = new ClauseEntityOperand { Entity = "Amount1" },
                                    Operator = ComparisonOperatorType.GreaterThanOrEqualto,
                                    ROperand = new ClauseValueOperand { Value = 100 }
                                },
                                new ClauseLine
                                {
                                    LOperand = new ClauseValueOperand { Value = 200 },
                                    Operator = ComparisonOperatorType.Equal,
                                    ROperand = new ClauseEntityOperand { Entity = "Amount2" }
                                }
                            }
                        };

            return (clause, data);
        }





        [Test]
        public void Evaluate_ClauseTest_Sample3()
        {
            ClauseEvaluator ce = new ClauseEvaluator(Sample3().clause, Sample3().input);
            var obj = ce.Evaluate();

            /* write std output */
            Console.WriteLine(obj.expression);

            /* ((100>=200) AND (300=300)) OR (200<300)
             * It should be "True"
             */
            Assert.AreEqual(true, obj.result);
        }

        public (IClause clause, IDictionary<string, int> input) Sample3()
        {
            /* Input Data for Sample 3 */
            var data = new Dictionary<string, int>();
            data.Add("Amount1", 100);
            data.Add("Amount2", 200);
            data.Add("Amount3", 300);
            data.Add("Amount4", 300);


            /* Sample 3 */
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