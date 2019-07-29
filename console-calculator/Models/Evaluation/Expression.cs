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

        public double Calculate()
        {
            TextExpression = TextExpression.Replace(" ", ""); //Убираем пробелы

            RPNParser parser = new RPNParser();
            string rpnExpression = parser.ToRPN(TextExpression);

            return parser.CalculateRPN(rpnExpression);
        }
    }
}