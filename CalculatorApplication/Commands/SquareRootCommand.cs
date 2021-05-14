using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class SquareRootCommand : ICommand
    {
        private readonly Calculator calculator;

        public SquareRootCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            calculator.SquareRoot();
        }

        public void Unexecute()
        {
            calculator.Multiply(calculator.CurrentValue);
        }
    }
}
