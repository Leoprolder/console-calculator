using System;

namespace console_calculator.Models.Evaluation
{
    interface IOperation
    {
        int Priority { get; set; }

        double Apply(double left, double right);

        bool IsLegal(); //Нужен класс-определитель операции
    }
}