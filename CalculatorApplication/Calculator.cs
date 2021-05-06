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
        private double memoryValue;
        private double tempValue;

        public double CurrentValue
        {
            get { return currentValue; }
        }

        public double MemoryValue
        {
            get { return memoryValue; }
        }

        public double TemporaryValue
        {
            get { return tempValue; }
        }

        public Calculator()
        {
            currentValue = 0;
            memoryValue = 0;
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

        public void MemoryAdd(double value)
        {
            this.memoryValue += value;
        }

        public void MemorySubtract(double value)
        {
            this.memoryValue -= value;
        }

        public void MemoryRead()
        {
            this.currentValue = memoryValue;
        }

        public void MemoryClear()
        {
            this.memoryValue = 0;
        }

        public void ClearAll()
        {
            this.currentValue = 0;
        }
    }
}
