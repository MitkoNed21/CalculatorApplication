using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorApplication.Commands;

namespace CalculatorApplication
{
    public partial class MainForm : Form
    {
        private Calculator calculator;
        private bool executingOperation;
        private bool numberEnteredAfterOperation;
        private bool hasInteractedWithMemory;
        private bool hasPressedResultButton;
        private string operationName;
        //private Stack<AddNumberCommand> addedNumbers;
        private CommandHistory commandsHistory;

        public MainForm()
        {
            InitializeComponent();
            
            this.calculator = new Calculator();
            this.currentValueLabel.Text = calculator.CurrentValue.ToString();
            this.previewValueLabel.Text = "";
            this.temporaryValueLabel.Text = "";
            this.executingOperation = false;
            this.numberEnteredAfterOperation = false;
            this.hasInteractedWithMemory = false;
            this.hasPressedResultButton = false;

            //this.addedNumbers = new Stack<AddNumberCommand>();
            this.commandsHistory = new CommandHistory();
            this.KeyDown += MainForm_KeyPress;
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            MessageBox.Show("TEST");
            //this.previewValueLabel.Font = new Font(this.previewValueLabel.Font.FontFamily, 12);
            //this.previewValueLabel.Text = e.KeyValue + " | " + e.KeyCode + " | " + e.KeyData;
        }

        private void MainForm_KeyPress(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
            this.previewValueLabel.Font = new Font(this.previewValueLabel.Font.FontFamily, 12);
            this.previewValueLabel.Text = calculator.CurrentValue + ", op: " + executingOperation + ", his: " + commandsHistory.Count;
        }

        private void MainForm_KeyDown(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13: // Enter Key
                    resultButton_Click(sender, e);
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
                    this.multiplyButton_Click(multiplyButton, e);
                    break;
                case '+':
                    this.addButton_Click(addButton, e);
                    break;
                case '.':
                case ',':
                    this.decimalPointButton_Click(decimalPointButton, e);
                    break;
                case '-':
                    this.subtractButton_Click(subtractButton, e);
                    break;
                case '/':
                    this.divideButton_Click(divideButton, e);
                    break;
                default:
                    break;
            }
        }

        //private void numberButton_Click(object sender, EventArgs e)

        private void oneButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(1);
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(2);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(3);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(4);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(5);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(6);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(7);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(8);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(9);
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(0);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string currentValueLabelText = this.currentValueLabel.Text;
            if (currentValueLabelText == "0") return;

            if (currentValueLabelText.Length == 1)
            {
                // if there is only 1 digit and we delete, set to 0
                this.currentValueLabel.Text = "0";
                this.previewValueLabel.Text = this.temporaryValueLabel.Text;
                return;
            }

            //int charactersToRemove = 1;
            // If the decimal point is the second to last character, remove it as well
            //if (currentValueLabelText[currentValueLabelText.Length - 2] == '.')
            {
            //    charactersToRemove = 2;
            }


            this.currentValueLabel.Text =
                currentValueLabelText.Substring(0, currentValueLabelText.Length - /*charactersToRemove*/1);

            if (this.executingOperation)
            {
                ICommand command = (ICommand)Activator.CreateInstance(
                   Type.GetType("CalculatorApplication.Commands." + this.operationName + "Command"),
                                calculator,
                                double.Parse(this.currentValueLabel.Text));
                UpdatePreviewValueLabel(command);
            }

            //this.addedNumbers.Pop().Unexecute();
            //UpdateCalculatorScreen();
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            // Temporary
            //this.addedNumbers.Clear();

            this.numberEnteredAfterOperation = false;
            this.calculator.ClearAll();
            this.operationLabel.Text = "";
            this.previewValueLabel.Text = "";
            this.temporaryValueLabel.Text = "";
            this.currentValueLabel.Text = "0";
        }

        private void clearValueButton_Click(object sender, EventArgs e)
        {
            // Temporary
            //this.addedNumbers.Clear();
            //calculator.Subtract(calculator.CurrentValue);
            //UpdateCalculatorScreen();
            this.currentValueLabel.Text = "0";
            this.previewValueLabel.Text = this.temporaryValueLabel.Text;
        }

        private void AddNumberToCalculatorScreen(int number)
        {
            if (this.currentValueLabel.Text.Length == 15) return;

            if (hasInteractedWithMemory)
            {
                this.currentValueLabel.Text = "0";
                hasInteractedWithMemory = false;
            }

            if (!numberEnteredAfterOperation)
            {
                numberEnteredAfterOperation = true;
            }

            if (this.currentValueLabel.Text == "0")
                this.currentValueLabel.Text = number.ToString();
            else
                this.currentValueLabel.Text += number;

            if (DividingByZero())
            {
                this.previewValueLabel.Text = "Can't divide by 0!";
                return;
            }

            if (this.executingOperation)
            {
                ICommand command;
                if (this.operationName == "Multiply" && this.currentValueLabel.Text == "0")
                {
                    command = new MultiplyByZeroCommand(calculator);
                }
                else
                {
                    command = (ICommand)Activator.CreateInstance(
                       Type.GetType("CalculatorApplication.Commands." + this.operationName + "Command"),
                                    calculator,
                                    double.Parse(this.currentValueLabel.Text));
                }

                UpdatePreviewValueLabel(command);
            }
            else if(!executingOperation)
            {
                //this.currentValueLabel.Text = "0";
            }

            

            //this.Update();

            //AddNumberCommand c = new AddNumberCommand(calculator, number);
            //addedNumbers.Push(c);
            //c.Execute();
        }

        private bool DividingByZero()
        {
            return this.operationName == "Divide" && this.currentValueLabel.Text == "0";
        }

        private void UpdateCalculatorScreen()
        {
            this.currentValueLabel.Text = calculator.CurrentValue.ToString();

            int numberLength = this.currentValueLabel.Text.Length;

            if (numberLength == 10)
                this.currentValueLabel.Font = new Font(this.currentValueLabel.Font.FontFamily, 36);
            else if (numberLength == 11 || numberLength == 13)
                this.currentValueLabel.Font = new Font(this.currentValueLabel.Font.FontFamily, 28);
            else if (numberLength == 14)
                this.currentValueLabel.Font = new Font(this.currentValueLabel.Font.FontFamily, 24);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.operationLabel.Text = ((Button)sender).Text;

            if (!numberEnteredAfterOperation)
            {
                this.operationName = "Add";
                return;
            }

            if (this.executingOperation)
            {
                this.resultButton_Click(sender, e);
            }

            UpdateCalculatorLabels(sender);
            this.executingOperation = true;
            this.operationName = "Add";
            this.numberEnteredAfterOperation = false;

            //this.UpdateCalculatorScreen();
        }

        private void UpdateCalculatorLabels(object sender)
        {
            //TODO: Make if possible a single method
            string currentValueLabelText = this.currentValueLabel.Text;
            if (this.calculator.CurrentValue == 0 &&
                currentValueLabelText != "0")
            {
                //TryParse;
                this.calculator.Add(double.Parse(currentValueLabelText));
            }

            this.temporaryValueLabel.Text = currentValueLabelText;
            
            this.currentValueLabel.Text = "0";
            this.previewValueLabel.Text = currentValueLabelText;
        }

        private void resultButton_Click(object sender, EventArgs e)
        {

            //TODO: if operation button was pressed, but no number was pressed
            hasPressedResultButton = true;

            if (this.commandsHistory.Count == 0 && !this.executingOperation)
            {
                return;
            }
            else
            {
                this.numberEnteredAfterOperation = false;
            }

            if (DividingByZero())
            {
                this.previewValueLabel.Text = "Can't divide by 0!";
                return;
            }

            ICommand command;
            if (!this.executingOperation && this.commandsHistory.Count != 0)
            {
                command = commandsHistory.PeekLastCommand();
            }
            else
            {
                if (this.operationName == "Multiply" && this.currentValueLabel.Text == "0")
                {
                    command = new MultiplyByZeroCommand(calculator);
                }
                else
                {
                    command = (ICommand)Activator.CreateInstance(
                        Type.GetType("CalculatorApplication.Commands." + this.operationName + "Command"),
                                     calculator,
                                     double.Parse(this.currentValueLabel.Text));
                }

                this.executingOperation = false;
            }

            this.temporaryValueLabel.Text = this.calculator.CurrentValue.ToString();

            command.Execute();
            this.commandsHistory.AddCommand(command);

            AddElementToScreenHistory(command);

            this.currentValueLabel.Text = this.calculator.CurrentValue.ToString();
            UpdatePreviewValueLabel(command);

            this.currentValueLabel.Parent.Update();


            //UpdateCalculatorScreen();




            //new Label() { Text = $"234986+\n7348234=\n7583220" }
        }

        private void UpdatePreviewValueLabel(ICommand command)
        {
            command.Execute();
            double previewValue = this.calculator.CurrentValue;
            command.Unexecute();
            this.negateButton.Text = calculator.CurrentValue.ToString();
            this.previewValueLabel.Text = previewValue.ToString();
        }

        private void AddElementToScreenHistory(ICommand command)
        {
            var historyElementPanel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = false
            };

            historyElementPanel.Width = 188;
            historyElementPanel.Height = 68;
            //historyElementPanel.Controls.Add(new Label { Text = "C" + calculator.CurrentValue.ToString() });
            //historyElementPanel.Controls.Add(new Label { Text = "T" + calculator.TemporaryValue.ToString() });
            //historyElementPanel.Controls.Add(new Label { Text = "M" + calculator.MemoryValue.ToString() });
            //historyElementPanel.Controls.Add(new Label { Text = "CM " + commandsHistory.PeekLastCommand().GetType().FullName });
            historyElementPanel.Controls.Add(new Label() { Text = this.temporaryValueLabel.Text, TextAlign = ContentAlignment.MiddleRight, Width = historyElementPanel.Width });
            historyElementPanel.Controls.Add(new Label() { Text = "+" + this.currentValueLabel.Text, TextAlign = ContentAlignment.MiddleRight, Width = historyElementPanel.Width });
            historyElementPanel.Controls.Add(new Label() { Text = "=" + this.calculator.CurrentValue, TextAlign = ContentAlignment.MiddleRight, Width = historyElementPanel.Width });

            historyElementPanel.Margin = new Padding(0, 0, 0, 3); // bottom: 3px
            historyElementPanel.BackColor = Color.White;

            historyElementPanel.MouseClick += (s, ea) =>
            {
                ((Control)s).BackColor = SystemColors.Highlight;
                ((Control)s).Update();
                //l.MouseEnter
            };

            historyElementPanel.MouseLeave += (s, ea) =>
            {
                ((Control)s).BackColor = Color.White;
                ((Control)s).Update();
                //l.MouseEnter
            };

            if (this.flowLayoutPanel1.Controls.Count == 20)
            {
                this.flowLayoutPanel1.Controls.RemoveAt(this.flowLayoutPanel1.Controls.Count - 1);
            }

            this.flowLayoutPanel1.Controls.Add(historyElementPanel);
            this.flowLayoutPanel1.Controls.SetChildIndex(historyElementPanel, 0);
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            this.operationLabel.Text = ((Button)sender).Text;
            if (!numberEnteredAfterOperation)
            {
                this.operationName = "Subtract";
                return;
            }

            if (this.executingOperation)
            {
                this.resultButton_Click(sender, e);
            }

            UpdateCalculatorLabels(sender);
            this.executingOperation = true; this.numberEnteredAfterOperation = false;
            this.operationName = "Subtract";

            //this.UpdateCalculatorScreen();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            this.operationLabel.Text = ((Button)sender).Text;

            if (!numberEnteredAfterOperation)
            {
                this.operationName = "Multiply";
                return;
            }
            if (this.executingOperation)
            {
                this.resultButton_Click(sender, e);
            }

            UpdateCalculatorLabels(sender);
            this.executingOperation = true; this.numberEnteredAfterOperation = false;
            this.operationName = "Multiply";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            this.operationLabel.Text = ((Button)sender).Text;

            if (!numberEnteredAfterOperation)
            {
                this.operationName = "Divide";
                return;
            }
            if (executingOperation)
            {
                this.resultButton_Click(sender, e);
            }

            UpdateCalculatorLabels(sender);
            this.executingOperation = true; this.numberEnteredAfterOperation = false;
            this.operationName = "Divide";
        }

        private void decimalPointButton_Click(object sender, EventArgs e)
        {
            if (executingOperation && !numberEnteredAfterOperation)
            {
                numberEnteredAfterOperation = true;
            }

            if (!this.currentValueLabel.Text.Contains('.'))
            {
                this.currentValueLabel.Text += ".";
            }
        }

        private void negateButton_Click(object sender, EventArgs e)
        {
            if (this.currentValueLabel.Text == "0") return;

            string currentValueLabelText = this.currentValueLabel.Text;
            string result;

            if (currentValueLabelText.StartsWith("-"))
            {
                result = currentValueLabelText.Substring(1);
            }
            else
            {
                result = '-' + currentValueLabelText;
            }

            this.currentValueLabel.Text = result;
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            string currentValueLabelText = this.currentValueLabel.Text;
            if (currentValueLabelText[0] == '-')
            {
                this.previewValueLabel.Text = "Can't take square root!";
                return;
            }

            double newValue = Math.Sqrt(double.Parse(currentValueLabelText));
            this.calculator.Divide(newValue);
            this.currentValueLabel.Text = newValue.ToString();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);
            this.currentValueLabel.Text = (currentValue * currentValue).ToString();
        }

        private void memoryAddButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);
            hasInteractedWithMemory = true;
            if (!this.calculator.HasMemoryValue)
            {
                SetupMemory();
            }
            this.calculator.AddToMemory(currentValue);
        }

        private void memorySubtractButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);
            hasInteractedWithMemory = true;
            if (!this.calculator.HasMemoryValue)
            {
                SetupMemory();
            }
            this.calculator.SubtractFromMemory(currentValue);
        }

        private void memoryClearButton_Click(object sender, EventArgs e)
        {
            this.calculator.ClearMemory();
            this.memoryReadButton.Enabled = false;
            this.memoryClearButton.Enabled = false;
        }

        private void memoryReadButton_Click(object sender, EventArgs e)
        {
            this.numberEnteredAfterOperation = true;
            this.currentValueLabel.Text = calculator.ReadMemoryValue().ToString();
            hasInteractedWithMemory = true;
        }

        private void SetupMemory()
        {
            this.calculator.InitializeMemory();
            this.memoryReadButton.Enabled = true;
            this.memoryClearButton.Enabled = true;
        }
    }
}
