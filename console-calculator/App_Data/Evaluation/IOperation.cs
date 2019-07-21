using System;

namespace Evaluation
{
    interface IOperation
    {
        double Evaluate(double first, double second);

        bool IsLegal(); //Нужен класс-определитель операции
    }
}