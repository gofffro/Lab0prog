namespace Lab0prog
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            densityTextBox = new TextBox();
            radiusTextBox = new TextBox();
            massTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            resultTextBlock = new TextBox();
            label4 = new Label();
            CalculateButton = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 98);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 1;
            label1.Text = "Плотность (кг/м³):";
            // 
            // densityTextBox
            // 
            densityTextBox.Location = new Point(44, 116);
            densityTextBox.Name = "densityTextBox";
            densityTextBox.Size = new Size(189, 23);
            densityTextBox.TabIndex = 2;
            // 
            // radiusTextBox
            // 
            radiusTextBox.Location = new Point(44, 169);
            radiusTextBox.Name = "radiusTextBox";
            radiusTextBox.Size = new Size(189, 23);
            radiusTextBox.TabIndex = 3;
            // 
            // massTextBox
            // 
            massTextBox.Location = new Point(44, 226);
            massTextBox.Name = "massTextBox";
            massTextBox.Size = new Size(189, 23);
            massTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 151);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 5;
            label2.Text = "Радиус (м):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 208);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Масса (кг):";
            // 
            // resultTextBlock
            // 
            resultTextBlock.Location = new Point(44, 281);
            resultTextBlock.Name = "resultTextBlock";
            resultTextBlock.Size = new Size(189, 23);
            resultTextBlock.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 263);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 8;
            label4.Text = "Толщина диска:";
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(44, 323);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(189, 36);
            CalculateButton.TabIndex = 9;
            CalculateButton.Text = "Посчитать";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 25);
            label5.Name = "label5";
            label5.Size = new Size(204, 60);
            label5.TabIndex = 10;
            label5.Text = "Из материала с плотностью p \r\nизготовлен диск радиусом r.\r\nКаким должна быть толщина диска\r\nчтобы он имел массу m? ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 429);
            Controls.Add(label5);
            Controls.Add(CalculateButton);
            Controls.Add(label4);
            Controls.Add(resultTextBlock);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(massTextBox);
            Controls.Add(radiusTextBox);
            Controls.Add(densityTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox densityTextBox;
        private TextBox radiusTextBox;
        private TextBox massTextBox;
        private Label label2;
        private Label label3;
        private TextBox resultTextBlock;
        private Label label4;
        private Button CalculateButton;
        private Label label5;
    }
}
