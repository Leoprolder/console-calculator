﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Expression
    {
        private string TextExpression { get; set; }
        public Dictionary<String, String> Log { get; set; }

        public Expression(string input)
        {
            Log = new Dictionary<string, string>();
            TextExpression = input;
        }

        public Expression()
        {
            Log = new Dictionary<string, string>();
            TextExpression = "";
        }

        public bool IsLegal()
        {
            char[] allowedSymbols = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '*', '/', '(', ')', '.', ',' };
            foreach (var symbol in TextExpression)
            {
                if (!allowedSymbols.Contains(symbol))
                    return false;
            }
            return true;
        }

        public double Evaluate()
        {
            if (!IsLegal()) //Проверяем, выражение ли это
                throw new Exception();



            TextExpression = TextExpression.Replace(" ", ""); //Убираем лишние пробелы

            return 0;
        }
    }
}