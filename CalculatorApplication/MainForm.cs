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
        private bool hasBeenUsedHistory;
        private bool hasPerformedSingleStepOperation;
        private string operationName;
        private string operationSymbol;
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
            this.hasBeenUsedHistory = false;
            this.hasPerformedSingleStepOperation = false;

            this.Activated += (s, e) => resultButton.Focus();

            this.commandsHistory = new CommandHistory();
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
                    deleteButton_Click(sender, e);
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    AddNumberToCalculatorScreen(e.KeyChar.ToString());
                    break;
                case '*':
                    this.twoStepOperationButton_Click(multiplyButton, e);
                    break;
                case '+':
                    this.twoStepOperationButton_Click(addButton, e);
                    break;
                case '.':
                case ',':
                    this.decimalPointButton_Click(decimalPointButton, e);
                    break;
                case '-':
                    this.twoStepOperationButton_Click(subtractButton, e);
                    break;
                case '/':
                    this.twoStepOperationButton_Click(divideButton, e);
                    break;
                default:
                    break;
            }
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            AddNumberToCalculatorScreen(((Button)sender).Text);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (hasPressedResultButton) return;

            string currentValueLabelText = this.currentValueLabel.Text;
            if (currentValueLabelText == "0") return;

            if (currentValueLabelText.Length == 1 ||
                currentValueLabelText.Length == 2 && currentValueLabelText[0] == '-')
            {
                this.currentValueLabel.Text = "0";
                UpdatePreviewValueLabel();
                return;
            }

            this.currentValueLabel.Text =
                currentValueLabelText.Substring(0, currentValueLabelText.Length - 1);

            UpdatePreviewValueLabel();
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            this.calculator.Clear();
            this.commandsHistory.Clear();
            this.historyElementsPanel.Controls.Clear();
            this.historyElementsPanel.Refresh();

            this.executingOperation = false;
            this.numberEnteredAfterOperation = false;
            this.hasInteractedWithMemory = false;
            this.hasPressedResultButton = false;
            this.hasBeenUsedHistory = false;
            this.hasPerformedSingleStepOperation = false;

            this.operationName = "";
            this.operationSymbol = "";
            this.operationLabel.Text = "";
            this.previewValueLabel.Text = "";
            this.temporaryValueLabel.Text = "";
            this.currentValueLabel.Text = "0";
        }

        private void clearValueButton_Click(object sender, EventArgs e)
        {
            if (!executingOperation)
            {
                this.numberEnteredAfterOperation = false;
                this.calculator.Clear();
                this.operationLabel.Text = "";
                this.previewValueLabel.Text = "";
                this.temporaryValueLabel.Text = "";
                this.currentValueLabel.Text = "0";
                return;
            }

            this.currentValueLabel.Text = "0";
            UpdatePreviewValueLabel();
        }

        private void AddNumberToCalculatorScreen(string number)
        {
            if (this.currentValueLabel.Text.Length == 15) return;

            if (hasPerformedSingleStepOperation)
            {
                this.currentValueLabel.Text = "0";
                hasPerformedSingleStepOperation = false;
            }

            if (hasInteractedWithMemory)
            {
                this.currentValueLabel.Text = "0";
                hasInteractedWithMemory = false;
            }

            if (hasPressedResultButton)
            {
                hasPressedResultButton = false;
                this.currentValueLabel.Text = "0";
            }

            if (!numberEnteredAfterOperation)
            {
                numberEnteredAfterOperation = true;
            }

            if (this.currentValueLabel.Text == "0")
                this.currentValueLabel.Text = number;
            else
                this.currentValueLabel.Text += number;

            UpdatePreviewValueLabel();
        }

        private bool DividingByZero()
        {
            return this.operationName == "Divide" &&
                   double.Parse(this.currentValueLabel.Text) == 0;
        }

        private void UpdateCalculatorLabels() //FIX
        {
            string currentValueLabelText = this.currentValueLabel.Text;

            this.calculator.SetValue(double.Parse(currentValueLabelText));

            this.temporaryValueLabel.Text = currentValueLabelText;

            this.currentValueLabel.Text = "0";
            this.previewValueLabel.Text = currentValueLabelText;
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            hasPressedResultButton = true;
            double currentValue = double.Parse(this.currentValueLabel.Text);

            if (!this.executingOperation && this.numberEnteredAfterOperation &&
                this.commandsHistory.Count != 0)
            {
                this.calculator.SetValue(currentValue);
            }

            if (this.commandsHistory.Count == 0 && !this.executingOperation)
            {
                return;
            }
            else
            {
                this.numberEnteredAfterOperation = false;
            }


            if (hasBeenUsedHistory)
            {
                RemoveUndoneCommandsFromHistoryPanel();
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
                if (this.operationName == "Multiply" && currentValue == 0)
                {
                    command = new MultiplyByZeroCommand(calculator);
                }
                else
                {
                    command = (ICommand)Activator.CreateInstance(
                        Type.GetType("CalculatorApplication.Commands." + this.operationName + "Command"),
                                     calculator,
                                     currentValue);
                }

                this.executingOperation = false;
            }

            try
            {
                this.commandsHistory.AddCommand(command);
            }
            catch (OverflowException)
            {
                this.previewValueLabel.Text = "Overflow!";
                return;
            }

            AddElementToScreenHistory();

            this.operationLabel.Text = "";
            this.temporaryValueLabel.Text = "";

            this.currentValueLabel.Text = this.calculator.CurrentValue.ToString();
            UpdatePreviewValueLabel();

            this.currentValueLabel.Parent.Refresh();
        }

        private void RemoveUndoneCommandsFromHistoryPanel()
        {
            int indexOfSelectedHistoryElement = (int)this.historyElementsPanel.Tag;
            this.historyElementsPanel.Controls[indexOfSelectedHistoryElement].BackColor = Color.White;

            for (int i = 0; i < indexOfSelectedHistoryElement; i++)
            {
                this.historyElementsPanel.Controls.RemoveAt(0);
            }

            hasBeenUsedHistory = false;
            this.historyElementsPanel.Tag = null;
        }

        private void UpdatePreviewValueLabel()
        {
            if (DividingByZero())
            {
                this.previewValueLabel.Text = "Can't divide by 0!";
                return;
            }

            ICommand command;
            if (!this.executingOperation)
            {
                if (this.commandsHistory.Count != 0)
                    command = commandsHistory.PeekLastCommand();
                else
                    return;
            }
            else
            {
                double currentValue = double.Parse(this.currentValueLabel.Text);

                if (this.operationName == "Multiply" && currentValue == 0)
                {
                    command = new MultiplyByZeroCommand(calculator);
                }
                else
                {
                    command = (ICommand)Activator.CreateInstance(
                        Type.GetType("CalculatorApplication.Commands." + this.operationName + "Command"),
                                     calculator,
                                     currentValue);
                }
            }

            try
            {
                command.Execute();
            }
            catch (OverflowException)
            {
                this.previewValueLabel.Text = "Overflow!";
                return;
            }

            double previewValue = this.calculator.CurrentValue;
            command.Unexecute();

            this.previewValueLabel.Text = previewValue.ToString();
        }

        private void AddElementToScreenHistory()
        {
            var historyElementPanel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = false
            };

            historyElementPanel.Width = 188;
            historyElementPanel.Height = 68;

            ICommand lastCommand = commandsHistory.PeekLastCommand();
            int labelWidth = historyElementPanel.Width;
            Font labelFont = new Font(this.Font.FontFamily, 13, GraphicsUnit.Pixel);
            Padding labelPadding = new Padding(0, 0, 3, 0); // right = 3

            Label top = new Label()
            {
                TextAlign = ContentAlignment.MiddleRight,
                Width = labelWidth,
                Font = labelFont,
                Padding = labelPadding
            };
            Label middle = new Label()
            {
                TextAlign = ContentAlignment.MiddleRight,
                Width = labelWidth,
                Font = labelFont,
                Padding = labelPadding
            };
            Label bottom = new Label()
            {
                TextAlign = ContentAlignment.MiddleRight,
                Width = labelWidth,
                Font = labelFont,
                Padding = labelPadding
            };

            string topLabelText, middleLabelText;
            if (lastCommand is ICommandWithValue convertedCommand)
            {
                if (this.temporaryValueLabel.Text == "")
                {
                    topLabelText = this.currentValueLabel.Text;
                    middleLabelText = operationSymbol + "  " + convertedCommand.Value;
                }
                else
                {
                    topLabelText = this.temporaryValueLabel.Text;
                    middleLabelText = operationSymbol + "  " + this.currentValueLabel.Text;
                }
            }
            else
            {
                topLabelText = operationSymbol;
                middleLabelText = this.currentValueLabel.Text;
            }

            top.Text = topLabelText;
            middle.Text = middleLabelText;
            bottom.Text = "=  " + this.calculator.CurrentValue;

            historyElementPanel.Controls.Add(top);
            historyElementPanel.Controls.Add(middle);
            historyElementPanel.Controls.Add(bottom);

            historyElementPanel.Margin = new Padding(0, 0, 0, 3); // bottom: 3px
            historyElementPanel.BackColor = Color.White;

            SetUpHistoryElementClickEvents(historyElementPanel);

            if (this.historyElementsPanel.Controls.Count == 20)
            {
                this.historyElementsPanel.Controls.RemoveAt(this.historyElementsPanel.Controls.Count - 1);
            }

            this.historyElementsPanel.Controls.Add(historyElementPanel);
            this.historyElementsPanel.Controls.SetChildIndex(historyElementPanel, 0);
        }

        private void SetUpHistoryElementClickEvents(FlowLayoutPanel historyElementPanel)
        {
            foreach (Label label in historyElementPanel.Controls)
            {
                label.MouseClick += HistoryElementClickEvent;
            }
        }

        void HistoryElementClickEvent(object sender, MouseEventArgs eventArgs)
        {
            Control historyElement = ((Control)sender).Parent;
            Control historyElementParent = historyElement.Parent;

            foreach (Control control in historyElementParent.Controls)
            {
                control.BackColor = Color.White;
            }

            historyElement.BackColor = SystemColors.Highlight;

            int index = historyElementParent.Controls.IndexOf(historyElement);
            historyElementParent.Tag = index;

            if (executingOperation)
            {

                this.currentValueLabel.Text = historyElement.Controls[2].Text.TrimStart('=');
            }
            else
            {
                commandsHistory.MoveToCommandAt(commandsHistory.Count - 1 - index);
                this.currentValueLabel.Text = historyElement.Controls[2].Text.TrimStart('=');

                calculator.SetValue(double.Parse(currentValueLabel.Text));
            }

            UpdatePreviewValueLabel();

            hasBeenUsedHistory = true;
        }

        private void twoStepOperationButton_Click(object sender, EventArgs e)
        {
            string operationSymbolString = ((Button)sender).Text;
            string operationName;
            switch (operationSymbolString)
            {
                case "+":
                    operationName = "Add";
                    break;
                case "−":
                    operationName = "Subtract";
                    break;
                case "×":
                    operationName = "Multiply";
                    break;
                case "÷":
                    operationName = "Divide";
                    break;
                default:
                    return;
            }

            string currentValueLabelText = this.currentValueLabel.Text;

            if (!numberEnteredAfterOperation)
            {
                this.currentValueLabel.Text = "0";
                this.executingOperation = true;
                this.operationName = operationName;
                this.operationSymbol = operationSymbolString;
                this.operationLabel.Text = operationSymbolString;

                if (temporaryValueLabel.Text == "")
                {
                    temporaryValueLabel.Text = calculator.CurrentValue.ToString();
                }

                UpdatePreviewValueLabel();
                return;
            }

            if (this.executingOperation)
            {
                this.resultButton_Click(sender, e);
            }

            this.numberEnteredAfterOperation = false;

            //UpdateCalculatorLabels();
            currentValueLabelText = this.currentValueLabel.Text;
            
            this.calculator.SetValue(double.Parse(currentValueLabelText));

            PrepareVariablesForExecutingOperation(operationSymbolString, operationName);
            UpdateFieldsForExecutingOperation(operationSymbolString);
            UpdatePreviewValueLabel();
        }

        private void UpdateFieldsForExecutingOperation(string operationSymbolString)
        {
            this.currentValueLabel.Text = "0";
            this.operationLabel.Text = operationSymbolString;
            if (temporaryValueLabel.Text == "")
            {
                temporaryValueLabel.Text = calculator.CurrentValue.ToString();
            }
        }

        private void PrepareVariablesForExecutingOperation(string operationSymbolString, string operationName)
        {
            this.executingOperation = true;
            this.operationName = operationName;
            this.operationSymbol = operationSymbolString;
        }

        private void decimalPointButton_Click(object sender, EventArgs e)
        {
            if (hasInteractedWithMemory)
            {
                hasInteractedWithMemory = false;
            }

            if (hasPressedResultButton)
            {
                hasPressedResultButton = false;
            }

            if (!numberEnteredAfterOperation)
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
            double currentValue = double.Parse(this.currentValueLabel.Text);

            if (currentValue == 0) return;

            string currentValueLabelText = this.currentValueLabel.Text;
            string result;

            if (currentValueLabelText[0] == '-')
            {
                result = currentValueLabelText.Substring(1);
            }
            else
            {
                result = '-' + currentValueLabelText;
            }

            if (hasPressedResultButton)
            {
                this.calculator.Multiply(-1);
            }

            this.currentValueLabel.Text = result;
            UpdatePreviewValueLabel();
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            string currentValueLabelText = this.currentValueLabel.Text;
            double currentValue = double.Parse(currentValueLabelText);

            if (currentValue == 0) return;

            if (currentValueLabelText[0] == '-')
            {
                this.previewValueLabel.Text = "Can't take square root!";
                return;
            }

            double newValue = Math.Sqrt(currentValue);

            if (double.IsInfinity(newValue))
            {
                previewValueLabel.Text = "Overflow!";
                return;
            }

            hasPerformedSingleStepOperation = true;

            if (hasPressedResultButton)
            {
                this.commandsHistory.AddCommand(new SquareRootCommand(this.calculator));
                operationSymbol = "Square root of";
                AddElementToScreenHistory();
            }

            this.currentValueLabel.Text = newValue.ToString();

            UpdatePreviewValueLabel();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);

            if (currentValue == 0) return;

            double newValue = currentValue * currentValue;

            if (double.IsInfinity(newValue))
            {
                previewValueLabel.Text = "Overflow!";
                return;
            }

            hasPerformedSingleStepOperation = true;

            if (hasPressedResultButton)
            {
                this.commandsHistory.AddCommand(new SquareCommand(this.calculator));
                operationSymbol = "Square of";
                AddElementToScreenHistory();
            }

            this.currentValueLabel.Text = newValue.ToString();

            UpdatePreviewValueLabel();
        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);
            double newValue = currentValue * 0.01 * this.calculator.CurrentValue;

            if (double.IsInfinity(newValue))
            {
                previewValueLabel.Text = "Overflow!";
                return;
            }

            if (hasPressedResultButton)
            {
                ICommand command;
                if (currentValue == 0)
                {
                    command = new CalculateZeroPercentOfSelfCommand(this.calculator);
                    operationSymbol = "0% of";
                }
                else
                {
                    command = new CalculatePercentOfSelfCommand(this.calculator);
                    operationSymbol = this.currentValueLabel.Text + "% of";
                }

                this.commandsHistory.AddCommand(command);
                AddElementToScreenHistory();
            }

            hasPerformedSingleStepOperation = true;

            this.currentValueLabel.Text = newValue.ToString();

            UpdatePreviewValueLabel();
        }

        private void oneOverXButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);

            if (currentValue == 0)
            {
                this.previewValueLabel.Text = "Can't divide by 0!";
                return;
            }

            double newValue = 1 / currentValue;

            if (double.IsInfinity(newValue))
            {
                previewValueLabel.Text = "Overflow!";
                return;
            }

            hasPerformedSingleStepOperation = true;

            if (hasPressedResultButton)
            {
                if (hasPressedResultButton)
                {
                    this.commandsHistory.AddCommand(new InvertCommand(this.calculator));
                    operationSymbol = "Inverse of ";
                    AddElementToScreenHistory();
                }
            }

            this.currentValueLabel.Text = newValue.ToString();
            UpdatePreviewValueLabel();
        }

        #region MemoryCommands

        private void memoryAddButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);
            hasInteractedWithMemory = true;
            if (!this.calculator.HasMemoryValue)
            {
                SetupMemory();
            }
            
            try
            {
                this.calculator.AddToMemory(currentValue);
            }
            catch (OverflowException)
            {
                this.memoryAddButton.Enabled = false;
                this.memorySubtractButton.Enabled = false;

                MessageBox.Show("The calculator memory has overflown!");
            }
        }

        private void memorySubtractButton_Click(object sender, EventArgs e)
        {
            double currentValue = double.Parse(this.currentValueLabel.Text);
            hasInteractedWithMemory = true;
            if (!this.calculator.HasMemoryValue)
            {
                SetupMemory();
            }

            try
            {
                this.calculator.SubtractFromMemory(currentValue);
            }
            catch (OverflowException)
            {
                this.memoryAddButton.Enabled = false;
                this.memorySubtractButton.Enabled = false;

                MessageBox.Show("The memory has overflown");
            }
        }

        private void memoryClearButton_Click(object sender, EventArgs e)
        {
            this.calculator.ClearMemory();

            if (!this.memoryAddButton.Enabled)
                this.memoryAddButton.Enabled = true;

            if (!this.memorySubtractButton.Enabled)
                this.memorySubtractButton.Enabled = true;

            this.memoryReadButton.Enabled = false;
            this.memoryClearButton.Enabled = false;
        }

        private void memoryReadButton_Click(object sender, EventArgs e)
        {
            this.numberEnteredAfterOperation = true;
            this.currentValueLabel.Text = calculator.ReadMemoryValue().ToString();
            UpdatePreviewValueLabel();
            hasInteractedWithMemory = true;
        }

        private void SetupMemory()
        {
            this.calculator.InitializeMemory();
            this.memoryReadButton.Enabled = true;
            this.memoryClearButton.Enabled = true;
        }
        #endregion
    }
}
