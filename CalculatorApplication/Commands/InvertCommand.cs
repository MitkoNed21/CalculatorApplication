using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class InvertCommand : ICommand
    {
        private readonly Calculator calculator;
        private double previousValue;

        public InvertCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            previousValue = calculator.CurrentValue;
            calculator.Invert();
        }

        public void Unexecute()
        {
            calculator.SetValue(previousValue);
        }
    }
}
