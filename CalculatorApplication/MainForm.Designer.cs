
namespace CalculatorApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.negateButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.decimalPointButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.percentButton = new System.Windows.Forms.Button();
            this.memoryReadButton = new System.Windows.Forms.Button();
            this.memoryClearButton = new System.Windows.Forms.Button();
            this.memorySubtractButton = new System.Windows.Forms.Button();
            this.memoryAddButton = new System.Windows.Forms.Button();
            this.squareRootButton = new System.Windows.Forms.Button();
            this.squareButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.clearValueButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.operationLabel = new System.Windows.Forms.Label();
            this.previewValueLabel = new System.Windows.Forms.Label();
            this.temporaryValueLabel = new System.Windows.Forms.Label();
            this.currentValueLabel = new System.Windows.Forms.Label();
            this.historyElementsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // negateButton
            // 
            this.negateButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.negateButton.Location = new System.Drawing.Point(2, 419);
            this.negateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.negateButton.Name = "negateButton";
            this.negateButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 6);
            this.negateButton.Size = new System.Drawing.Size(72, 52);
            this.negateButton.TabIndex = 24;
            this.negateButton.Text = "±";
            this.negateButton.UseVisualStyleBackColor = true;
            this.negateButton.Click += new System.EventHandler(this.negateButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.zeroButton.Location = new System.Drawing.Point(75, 419);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.zeroButton.Size = new System.Drawing.Size(72, 52);
            this.zeroButton.TabIndex = 25;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // decimalPointButton
            // 
            this.decimalPointButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.decimalPointButton.Location = new System.Drawing.Point(148, 419);
            this.decimalPointButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.decimalPointButton.Name = "decimalPointButton";
            this.decimalPointButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.decimalPointButton.Size = new System.Drawing.Size(72, 52);
            this.decimalPointButton.TabIndex = 26;
            this.decimalPointButton.Text = ".";
            this.decimalPointButton.UseVisualStyleBackColor = true;
            this.decimalPointButton.Click += new System.EventHandler(this.decimalPointButton_Click);
            // 
            // resultButton
            // 
            this.resultButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.resultButton.Location = new System.Drawing.Point(221, 419);
            this.resultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultButton.Name = "resultButton";
            this.resultButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 6);
            this.resultButton.Size = new System.Drawing.Size(72, 52);
            this.resultButton.TabIndex = 27;
            this.resultButton.Text = "=";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.oneButton.Location = new System.Drawing.Point(2, 366);
            this.oneButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oneButton.Name = "oneButton";
            this.oneButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.oneButton.Size = new System.Drawing.Size(72, 52);
            this.oneButton.TabIndex = 20;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = true;
            this.oneButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // twoButton
            // 
            this.twoButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.twoButton.Location = new System.Drawing.Point(75, 366);
            this.twoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.twoButton.Name = "twoButton";
            this.twoButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.twoButton.Size = new System.Drawing.Size(72, 52);
            this.twoButton.TabIndex = 21;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = true;
            this.twoButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // threeButton
            // 
            this.threeButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.threeButton.Location = new System.Drawing.Point(148, 366);
            this.threeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.threeButton.Name = "threeButton";
            this.threeButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.threeButton.Size = new System.Drawing.Size(72, 52);
            this.threeButton.TabIndex = 22;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = true;
            this.threeButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.addButton.Location = new System.Drawing.Point(221, 366);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addButton.Name = "addButton";
            this.addButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 6);
            this.addButton.Size = new System.Drawing.Size(72, 52);
            this.addButton.TabIndex = 23;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.twoStepOperationButton_Click);
            // 
            // fourButton
            // 
            this.fourButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.fourButton.Location = new System.Drawing.Point(2, 313);
            this.fourButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fourButton.Name = "fourButton";
            this.fourButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.fourButton.Size = new System.Drawing.Size(72, 52);
            this.fourButton.TabIndex = 16;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = true;
            this.fourButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.fiveButton.Location = new System.Drawing.Point(75, 313);
            this.fiveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.fiveButton.Size = new System.Drawing.Size(72, 52);
            this.fiveButton.TabIndex = 17;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = true;
            this.fiveButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // sevenButton
            // 
            this.sevenButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.sevenButton.Location = new System.Drawing.Point(2, 260);
            this.sevenButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.sevenButton.Size = new System.Drawing.Size(72, 52);
            this.sevenButton.TabIndex = 12;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = true;
            this.sevenButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // eightButton
            // 
            this.eightButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.eightButton.Location = new System.Drawing.Point(75, 260);
            this.eightButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eightButton.Name = "eightButton";
            this.eightButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.eightButton.Size = new System.Drawing.Size(72, 52);
            this.eightButton.TabIndex = 13;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = true;
            this.eightButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // nineButton
            // 
            this.nineButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.nineButton.Location = new System.Drawing.Point(148, 260);
            this.nineButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nineButton.Name = "nineButton";
            this.nineButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.nineButton.Size = new System.Drawing.Size(72, 52);
            this.nineButton.TabIndex = 14;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = true;
            this.nineButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.multiplyButton.Location = new System.Drawing.Point(221, 260);
            this.multiplyButton.Margin = new System.Windows.Forms.Padding(0);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 6);
            this.multiplyButton.Size = new System.Drawing.Size(72, 52);
            this.multiplyButton.TabIndex = 15;
            this.multiplyButton.Text = "×";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.twoStepOperationButton_Click);
            // 
            // sixButton
            // 
            this.sixButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.sixButton.Location = new System.Drawing.Point(148, 313);
            this.sixButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sixButton.Name = "sixButton";
            this.sixButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.sixButton.Size = new System.Drawing.Size(72, 52);
            this.sixButton.TabIndex = 18;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = true;
            this.sixButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // subtractButton
            // 
            this.subtractButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.subtractButton.Location = new System.Drawing.Point(221, 313);
            this.subtractButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 6);
            this.subtractButton.Size = new System.Drawing.Size(72, 52);
            this.subtractButton.TabIndex = 19;
            this.subtractButton.Text = "−";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new System.EventHandler(this.twoStepOperationButton_Click);
            // 
            // divideButton
            // 
            this.divideButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.divideButton.Location = new System.Drawing.Point(221, 207);
            this.divideButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.divideButton.Name = "divideButton";
            this.divideButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 6);
            this.divideButton.Size = new System.Drawing.Size(72, 52);
            this.divideButton.TabIndex = 11;
            this.divideButton.Text = "÷";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new System.EventHandler(this.twoStepOperationButton_Click);
            // 
            // percentButton
            // 
            this.percentButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.percentButton.Location = new System.Drawing.Point(148, 207);
            this.percentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.percentButton.Name = "percentButton";
            this.percentButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.percentButton.Size = new System.Drawing.Size(72, 52);
            this.percentButton.TabIndex = 10;
            this.percentButton.Text = "%";
            this.percentButton.UseVisualStyleBackColor = true;
            this.percentButton.Click += new System.EventHandler(this.percentButton_Click);
            // 
            // memoryReadButton
            // 
            this.memoryReadButton.Enabled = false;
            this.memoryReadButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.memoryReadButton.Location = new System.Drawing.Point(221, 116);
            this.memoryReadButton.Margin = new System.Windows.Forms.Padding(0);
            this.memoryReadButton.Name = "memoryReadButton";
            this.memoryReadButton.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.memoryReadButton.Size = new System.Drawing.Size(72, 37);
            this.memoryReadButton.TabIndex = 3;
            this.memoryReadButton.Text = "MR";
            this.memoryReadButton.UseVisualStyleBackColor = true;
            this.memoryReadButton.Click += new System.EventHandler(this.memoryReadButton_Click);
            // 
            // memoryClearButton
            // 
            this.memoryClearButton.Enabled = false;
            this.memoryClearButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.memoryClearButton.Location = new System.Drawing.Point(148, 116);
            this.memoryClearButton.Margin = new System.Windows.Forms.Padding(0);
            this.memoryClearButton.Name = "memoryClearButton";
            this.memoryClearButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.memoryClearButton.Size = new System.Drawing.Size(72, 37);
            this.memoryClearButton.TabIndex = 2;
            this.memoryClearButton.Text = "MC";
            this.memoryClearButton.UseVisualStyleBackColor = true;
            this.memoryClearButton.Click += new System.EventHandler(this.memoryClearButton_Click);
            // 
            // memorySubtractButton
            // 
            this.memorySubtractButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.memorySubtractButton.Location = new System.Drawing.Point(75, 116);
            this.memorySubtractButton.Margin = new System.Windows.Forms.Padding(0);
            this.memorySubtractButton.Name = "memorySubtractButton";
            this.memorySubtractButton.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.memorySubtractButton.Size = new System.Drawing.Size(72, 37);
            this.memorySubtractButton.TabIndex = 1;
            this.memorySubtractButton.Text = "M-";
            this.memorySubtractButton.UseVisualStyleBackColor = true;
            this.memorySubtractButton.Click += new System.EventHandler(this.memorySubtractButton_Click);
            // 
            // memoryAddButton
            // 
            this.memoryAddButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.memoryAddButton.Location = new System.Drawing.Point(2, 116);
            this.memoryAddButton.Margin = new System.Windows.Forms.Padding(0);
            this.memoryAddButton.Name = "memoryAddButton";
            this.memoryAddButton.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.memoryAddButton.Size = new System.Drawing.Size(72, 37);
            this.memoryAddButton.TabIndex = 0;
            this.memoryAddButton.Text = "M+";
            this.memoryAddButton.UseVisualStyleBackColor = true;
            this.memoryAddButton.Click += new System.EventHandler(this.memoryAddButton_Click);
            // 
            // squareRootButton
            // 
            this.squareRootButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.squareRootButton.Location = new System.Drawing.Point(75, 207);
            this.squareRootButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.squareRootButton.Name = "squareRootButton";
            this.squareRootButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.squareRootButton.Size = new System.Drawing.Size(72, 52);
            this.squareRootButton.TabIndex = 9;
            this.squareRootButton.Text = "√";
            this.squareRootButton.UseVisualStyleBackColor = true;
            this.squareRootButton.Click += new System.EventHandler(this.squareRootButton_Click);
            // 
            // squareButton
            // 
            this.squareButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.squareButton.Location = new System.Drawing.Point(2, 207);
            this.squareButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.squareButton.Name = "squareButton";
            this.squareButton.Padding = new System.Windows.Forms.Padding(7, 0, 0, 2);
            this.squareButton.Size = new System.Drawing.Size(72, 52);
            this.squareButton.TabIndex = 8;
            this.squareButton.Text = "x²";
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.deleteButton.Location = new System.Drawing.Point(221, 154);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.deleteButton.Size = new System.Drawing.Size(72, 52);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "⌫";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.clearAllButton.Location = new System.Drawing.Point(148, 154);
            this.clearAllButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.clearAllButton.Size = new System.Drawing.Size(72, 52);
            this.clearAllButton.TabIndex = 6;
            this.clearAllButton.Text = "C";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // clearValueButton
            // 
            this.clearValueButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.clearValueButton.Location = new System.Drawing.Point(75, 154);
            this.clearValueButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearValueButton.Name = "clearValueButton";
            this.clearValueButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.clearValueButton.Size = new System.Drawing.Size(72, 52);
            this.clearValueButton.TabIndex = 5;
            this.clearValueButton.Text = "CE";
            this.clearValueButton.UseVisualStyleBackColor = true;
            this.clearValueButton.Click += new System.EventHandler(this.clearValueButton_Click);
            // 
            // modButton
            // 
            this.modButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.modButton.Location = new System.Drawing.Point(2, 154);
            this.modButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modButton.Name = "modButton";
            this.modButton.Padding = new System.Windows.Forms.Padding(1, 0, 0, 2);
            this.modButton.Size = new System.Drawing.Size(72, 52);
            this.modButton.TabIndex = 4;
            this.modButton.Text = "1/x";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.oneOverXButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.operationLabel);
            this.panel1.Controls.Add(this.previewValueLabel);
            this.panel1.Controls.Add(this.temporaryValueLabel);
            this.panel1.Controls.Add(this.currentValueLabel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 111);
            this.panel1.TabIndex = 15;
            // 
            // operationLabel
            // 
            this.operationLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.operationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.operationLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.operationLabel.Location = new System.Drawing.Point(466, 0);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.operationLabel.Size = new System.Drawing.Size(31, 27);
            this.operationLabel.TabIndex = 31;
            // 
            // previewValueLabel
            // 
            this.previewValueLabel.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.previewValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.previewValueLabel.Location = new System.Drawing.Point(3, 74);
            this.previewValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.previewValueLabel.Name = "previewValueLabel";
            this.previewValueLabel.Size = new System.Drawing.Size(488, 37);
            this.previewValueLabel.TabIndex = 30;
            this.previewValueLabel.Text = "1213959008";
            this.previewValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // temporaryValueLabel
            // 
            this.temporaryValueLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.temporaryValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.temporaryValueLabel.Location = new System.Drawing.Point(0, 0);
            this.temporaryValueLabel.Name = "temporaryValueLabel";
            this.temporaryValueLabel.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.temporaryValueLabel.Size = new System.Drawing.Size(460, 27);
            this.temporaryValueLabel.TabIndex = 28;
            this.temporaryValueLabel.Text = "9634880";
            this.temporaryValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // currentValueLabel
            // 
            this.currentValueLabel.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.currentValueLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.currentValueLabel.Location = new System.Drawing.Point(0, 22);
            this.currentValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.currentValueLabel.Name = "currentValueLabel";
            this.currentValueLabel.Size = new System.Drawing.Size(500, 91);
            this.currentValueLabel.TabIndex = 29;
            this.currentValueLabel.Text = "1204324128";
            this.currentValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // historyElementsPanel
            // 
            this.historyElementsPanel.AutoScroll = true;
            this.historyElementsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.historyElementsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.historyElementsPanel.Location = new System.Drawing.Point(295, 117);
            this.historyElementsPanel.Name = "historyElementsPanel";
            this.historyElementsPanel.Size = new System.Drawing.Size(208, 356);
            this.historyElementsPanel.TabIndex = 28;
            this.historyElementsPanel.WrapContents = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 473);
            this.Controls.Add(this.historyElementsPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zeroButton);
            this.Controls.Add(this.oneButton);
            this.Controls.Add(this.twoButton);
            this.Controls.Add(this.threeButton);
            this.Controls.Add(this.fourButton);
            this.Controls.Add(this.fiveButton);
            this.Controls.Add(this.sixButton);
            this.Controls.Add(this.sevenButton);
            this.Controls.Add(this.eightButton);
            this.Controls.Add(this.nineButton);
            this.Controls.Add(this.decimalPointButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.subtractButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.percentButton);
            this.Controls.Add(this.squareButton);
            this.Controls.Add(this.squareRootButton);
            this.Controls.Add(this.modButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.clearValueButton);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.memoryAddButton);
            this.Controls.Add(this.memorySubtractButton);
            this.Controls.Add(this.memoryReadButton);
            this.Controls.Add(this.memoryClearButton);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.negateButton);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Calculator";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button negateButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button decimalPointButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button percentButton;
        private System.Windows.Forms.Button memoryReadButton;
        private System.Windows.Forms.Button memoryClearButton;
        private System.Windows.Forms.Button memorySubtractButton;
        private System.Windows.Forms.Button memoryAddButton;
        private System.Windows.Forms.Button squareRootButton;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button clearValueButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label previewValueLabel;
        private System.Windows.Forms.Label currentValueLabel;
        private System.Windows.Forms.Label temporaryValueLabel;
        private System.Windows.Forms.FlowLayoutPanel historyElementsPanel;
        private System.Windows.Forms.Label operationLabel;
    }
}

