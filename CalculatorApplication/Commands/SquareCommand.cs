using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class SquareCommand : ICommand
    {
        private readonly Calculator calculator;

        public SquareCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            calculator.Multiply(calculator.CurrentValue);
        }

        public void Unexecute()
        {
            calculator.SquareRoot();
        }
    }
}
