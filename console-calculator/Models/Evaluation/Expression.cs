using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Expression
    {
        private string TextExpression { get; set; }

        public Expression(string input)
        {
            TextExpression = input;
        }

        public Expression()
        {
            TextExpression = "";
        }

        private void CheckIfLegal()
        {
            for (int i = 0; i < TextExpression.Length; i++)
            {
                if (new Operation().IsOperation(TextExpression[i], out Operation.Apply res) ||
                    Int32.TryParse(TextExpression[i].ToString(), out int intres) ||
                    TextExpression[i] == '.' || TextExpression[i] == ',')
                    continue;
                else
                    throw new Exception("invalid symbols in expression");
            }
        }

        public double Calculate()
        {
            TextExpression = TextExpression.Replace(" ", ""); //Убираем пробелы

            CheckIfLegal(); //Проверим, выражение ли

            RPNParser parser = new RPNParser();
            string rpnExpression = parser.ToRPNRecursive(TextExpression);

            return parser.CalculateRPN(rpnExpression);
        }
    }
}