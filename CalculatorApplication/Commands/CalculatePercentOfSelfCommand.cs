using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class CalculatePercentOfSelfCommand : ICommand
    {
        private readonly Calculator calculator;
        private double percentValue;

        public CalculatePercentOfSelfCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            percentValue = calculator.CurrentValue / 100;
            calculator.Multiply(percentValue);
        }

        public void Unexecute()
        {
            calculator.Divide(percentValue);
        }
    }
}
