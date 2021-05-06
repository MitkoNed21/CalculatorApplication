using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
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
            // What if value is 0?
            calculator.Divide(value);
        }
    }
}
