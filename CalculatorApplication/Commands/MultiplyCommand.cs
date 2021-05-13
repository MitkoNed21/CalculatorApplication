using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class MultiplyCommand : ICommand
    {
        private Calculator calculator;
        private double value;

        public MultiplyCommand(Calculator calculator, double value)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public void Execute()
        {
            calculator.Multiply(value);
        }

        public void Unexecute()
        {
            calculator.Divide(value);
        }
    }
}
