using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class AddCommand : ICommandWithValue
    {
        private readonly Calculator calculator;
        private readonly double value;
        
        public double Value => value;

        public AddCommand(Calculator calculator, double value)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public void Execute()
        {
            calculator.Add(value);
        }

        public void Unexecute()
        {
            calculator.Subtract(value);
        }
    }
}
