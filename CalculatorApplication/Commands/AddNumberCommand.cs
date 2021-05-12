using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    public class AddNumberCommand : ICommand
    {
        private Calculator calculator;
        private double value;

        public AddNumberCommand(Calculator calculator, double value)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public void Execute()
        {
            this.calculator.Multiply(10);
            this.calculator.Add(value);
        }

        public void Unexecute()
        {
            this.calculator.Subtract(value);
            this.calculator.Divide(10);
        }
    }
}
