using System;
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

            //Обратная польская запись поможеть
            //http://www.lib.unn.ru/students/src/struct.pdf

            TextExpression = TextExpression.Replace(" ", ""); //Убираем пробелы

            return 0;
        }

        private string ToRPN(Expression input) //Метод, конвертирующий выражение в обратную польскую запись
        {
            Stack<char> stack = new Stack<char>();
            string output = String.Empty;

            for (int i = 0; i < input.TextExpression.Length; i++)
            {
                char symbol = input.TextExpression[i];

                if (OperationQualifier.IsOperation(symbol)) //Если встретившийся символ является операцией
                {
                    IOperation operation = OperationQualifier.GetOperation(symbol);
                }
                else //Если символ или группа символов - число
                {
                    output += input.TextExpression[i];
                    int j = i + 1;
                    while (j < input.TextExpression.Length) //Пробегаем цикл, пока не достингем конца
                    {
                        //Если символ и последующие за ним - цифры, то добавляем в output
                        if (Int32.TryParse(input.TextExpression[j].ToString(), out int res) || input.TextExpression[j] == '.' || input.TextExpression[j] == ',')
                        {
                            output += input.TextExpression[j];
                        }

                        j++;
                    }

                    if (j + i < input.TextExpression.Length) //Если не достигли конца выражения
                        i += j - i; //то переходим на символ за числом

                    output += " "; //Разделяющий пробел
                }
            }

            output.Replace('.', ',');

            return output;
        }

        private double EvaluateRPN()
        {
            //берём два числа в стек, применяем операцию

            return 0;
        }
    }
}