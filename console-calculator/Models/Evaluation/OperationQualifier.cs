using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class OperationQualifier
    {
        public static IOperation GetOperation(char definition)
        {
            switch (definition)
            {
                case '+':
                    return new Sum();
                case '-':
                    return new Subtraction();
                case '*':
                    return new Multiplication();
                case '/':
                    return new Division();
                case '(':
                    return new Bracket(definition);
                case ')':
                    return new Bracket(definition);
                default:
                    throw new Exception();
            }
        }

        public static bool IsOperation(char c)
        {
            char[] operations = { '/', '*', '+', '-', '(', ')' };
            return operations.Contains(c);
        }

        public int Priority { get; set; }
        public string Definition { get; set; }

        public double Apply(double left, double right)
        {
            throw new NotImplementedException();
        }

        public bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}