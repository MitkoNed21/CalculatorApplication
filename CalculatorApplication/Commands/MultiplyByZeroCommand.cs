using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    class MultiplyByZeroCommand
    {
        private Calculator calculator;
        private double previousValue;

        public MultiplyByZeroCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            previousValue = calculator.TemporaryValue;
            calculator.Multiply(0);
        }

        public void Unexecute()
        {
            calculator.Add(previousValue);
        }
    }
}
