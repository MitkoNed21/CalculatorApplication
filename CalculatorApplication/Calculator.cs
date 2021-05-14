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

        public double CurrentValue
        {
            get { return currentValue; }
        }

        public bool HasMemoryValue => !(this.memoryValue is null);

        public Calculator()
        {
            currentValue = 0;
            memoryValue = null;
        }

        public void Add(double value)
        {
            double newValue = this.currentValue + value;
            ThrowIfOverflow(newValue);

            this.currentValue = newValue;
        }

        public void Subtract(double value)
        {
            double newValue = this.currentValue - value;
            ThrowIfOverflow(newValue);

            this.currentValue = newValue;
        }

        public void Multiply(double value)
        {
            double newValue = this.currentValue * value;
            ThrowIfOverflow(newValue);

            this.currentValue = newValue;
        }

        public void Divide(double value)
        {
            double newValue = this.currentValue / value;
            ThrowIfOverflow(newValue);

            this.currentValue = newValue;
        }
        public void SquareRoot()
        {
            double newValue = Math.Sqrt(this.currentValue);
            ThrowIfOverflow(newValue);

            this.currentValue = newValue;
        }

        public void Invert()
        {
            double newValue = 1 / this.currentValue;
            ThrowIfOverflow(newValue);

            this.currentValue = newValue;
        }

        public void AddToMemory(double value)
        {
            double newValue = this.memoryValue.Value + value;
            ThrowIfMemoryOverflow(newValue);

            this.memoryValue = newValue;
        }

        public void SubtractFromMemory(double value)
        {
            double newValue = this.memoryValue.Value - value;
            ThrowIfMemoryOverflow(newValue);

            this.memoryValue = newValue;
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

        public void Clear()
        {
            this.currentValue = 0;
        }

        public void SetValue(double value)
        {
            ThrowIfOverflow(value);
            this.currentValue = value;
        }

        public void InitializeMemory()
        {
            this.memoryValue = 0;
        }

        private void ThrowIfOverflow(double value)
        {
            if (double.IsInfinity(value))
            {
                throw new OverflowException("The calculator's value has overflown!");
            }
        }

        private void ThrowIfMemoryOverflow(double value)
        {
            if (double.IsInfinity(value))
            {
                throw new OverflowException("The calculator's memory has overflown!");
            }
        }
    }
}
