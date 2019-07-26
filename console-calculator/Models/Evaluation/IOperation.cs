using System;

namespace console_calculator.Models.Evaluation
{
    public interface IOperation
    {
        int Priority { get; set; }
        char Definition { get; set; }
        double Apply(double left, double right);
    }
}