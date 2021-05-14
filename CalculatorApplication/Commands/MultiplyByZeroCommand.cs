using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    class MultiplyByZeroCommand : ICommandWithValue
    {
        private Calculator calculator;
        private double previousValue;

        public double Value => 0;

        public MultiplyByZeroCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            previousValue = calculator.CurrentValue;
            calculator.Multiply(0);
        }

        public void Unexecute()
        {
            calculator.SetValue(previousValue);
        }
    }
}
