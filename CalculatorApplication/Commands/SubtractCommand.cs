using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class SubtractCommand : ICommand
    {
        private Calculator calculator;
        private double value;

        public SubtractCommand(Calculator calculator, double value)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public void Execute()
        {
            calculator.Subtract(value);
        }

        public void Unexecute()
        {
            calculator.Add(value);
        }
    }
}
