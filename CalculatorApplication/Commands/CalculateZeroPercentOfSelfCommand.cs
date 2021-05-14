using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Commands
{
    public class CalculateZeroPercentOfSelfCommand : ICommand
    {
        private readonly Calculator calculator;
        private double previousValue;

        public CalculateZeroPercentOfSelfCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            previousValue = calculator.CurrentValue;
            calculator.Clear();
        }

        public void Unexecute()
        {
            calculator.SetValue(previousValue);
        }
        
    }
}
