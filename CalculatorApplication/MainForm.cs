using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class MainForm : Form
    {
        private Calculator calculator;
        private bool executingOperation;
        private Stack<AddNumberCommand> addedNumbers;

        public MainForm()
        {
            InitializeComponent();

            this.calculator = new Calculator();
            this.valueLabel.Text = calculator.CurrentValue.ToString();
            this.previewLabel.Text = "";
            this.currentNumberLabel.Text = "";
            this.executingOperation = false;

            this.addedNumbers = new Stack<AddNumberCommand>();
        }

        private void MainForm_KeyDown(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13: // Enter Key
                    break;
                case (char)8: // Backspace
                    deleteButton_Click(sender, e);
                    break;
                case (char)127: // Ctrl+Backspace
                    break;
                case '0':
                    this.zeroButton_Click(sender, e);
                    break;
                case '1':
                    this.oneButton_Click(sender, e);
                    break;
                case '2':
                    this.twoButton_Click(sender, e);
                    break;
                case '3':
                    this.threeButton_Click(sender, e);
                    break;
                case '4':
                    this.fourButton_Click(sender, e);
                    break;
                case '5':
                    this.fiveButton_Click(sender, e);
                    break;
                case '6':
                    this.sixButton_Click(sender, e);
                    break;
                case '7':
                    this.sevenButton_Click(sender, e);
                    break;
                case '8':
                    this.eightButton_Click(sender, e);
                    break;
                case '9':
                    this.nineButton_Click(sender, e);
                    break;
                case '*':
                    break;
                case '+':
                    break;
                case '.':
                case ',':
                    break;
                case '-':
                    break;
                case '/':
                    break;
                default:
                    break;
            }
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(1);
            UpdateCalculatorScreen();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(2);
            UpdateCalculatorScreen();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(3);
            UpdateCalculatorScreen();
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(4);
            UpdateCalculatorScreen();
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(5);
            UpdateCalculatorScreen();
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(6);
            UpdateCalculatorScreen();
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(7);
            UpdateCalculatorScreen();
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(8);
            UpdateCalculatorScreen();
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(9);
            UpdateCalculatorScreen();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            if (this.calculator.CurrentValue == 0) return;

            AddNumberToCalculatorScreen(0);
            UpdateCalculatorScreen();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.addedNumbers.Count == 0) return;

            this.addedNumbers.Pop().Unexecute();
            UpdateCalculatorScreen();
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            // Temporary
            this.addedNumbers.Clear();
            this.calculator.ClearAll();
            UpdateCalculatorScreen();
        }

        private void clearValueButton_Click(object sender, EventArgs e)
        {
            // Temporary
            this.addedNumbers.Clear();
            calculator.Subtract(calculator.CurrentValue);
            UpdateCalculatorScreen();
        }

        private void AddNumberToCalculatorScreen(int number)
        {
            if (this.valueLabel.Text.Length == 15) return;

            AddNumberCommand c = new AddNumberCommand(calculator, number);
            addedNumbers.Push(c);
            c.Execute();
        }

        private void UpdateCalculatorScreen()
        {
            this.valueLabel.Text = calculator.CurrentValue.ToString();

            int numberLength = this.valueLabel.Text.Length;

            if (numberLength == 10)
                this.valueLabel.Font = new Font(this.valueLabel.Font.FontFamily, 36);
            else if (numberLength == 11 || numberLength == 13)
                this.valueLabel.Font = new Font(this.valueLabel.Font.FontFamily, 28);
            else if (numberLength == 14)
                this.valueLabel.Font = new Font(this.valueLabel.Font.FontFamily, 24);
        }
    }
}
