using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    public class DivideCommand : ICommand
    {
        private Calculator calculator;
        private double value;

        public DivideCommand(Calculator calculator, double value)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public void Execute()
        {
            // Shouldn't be able to work with 0?
            calculator.Divide(value);
        }

        public void Unexecute()
        {
            calculator.Multiply(value);
        }
    }
}
