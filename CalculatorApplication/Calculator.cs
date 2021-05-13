using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    public class Calculator
    {
        private double currentValue;
        private double? memoryValue;
        private double? tempValue;

        public double CurrentValue
        {
            get { return currentValue; }
        }

        public bool HasMemoryValue => !(this.memoryValue is null);

        public double? TemporaryValue // will it be good if this is also nullable?
        {
            get { return tempValue; }
        }

        public Calculator()
        {
            currentValue = 0;
            memoryValue = null;
        }

        public void Add(double value)
        {
            this.currentValue += value;
        }

        public void Subtract(double value)
        {
            this.currentValue -= value;
        }

        public void Multiply(double value)
        {
            this.currentValue *= value;
        }

        public void Divide(double value)
        {
            //TODO: Where should be check for 0?
            this.currentValue /= value;
        }

        public void AddToMemory(double value)
        {
            this.memoryValue += value;
        }

        public void SubtractFromMemory(double value)
        {
            this.memoryValue -= value;
        }

        public double ReadMemoryValue()
        {
            if (this.memoryValue is null)
            {
                throw new InvalidOperationException("Calculator has nothing in memory!");
            }

            return memoryValue.Value;
        }

        public void ClearMemory()
        {
            this.memoryValue = null;
        }

        public void ClearAll()
        {
            this.currentValue = 0;
        }

        internal void InitializeMemory()
        {
            this.memoryValue = 0;
        }
    }
}
