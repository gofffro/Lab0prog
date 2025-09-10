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
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            btnGenerate = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnCalculateStats = new Button();
            groupBox2 = new GroupBox();
            lblTallestWoman = new Label();
            lblTallestMan = new Label();
            lblAvgFemale = new Label();
            lblAvgMale = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
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
            resultTextBlock.ReadOnly = true;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(btnGenerate);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnLoad);
            groupBox1.Controls.Add(btnCalculateStats);
            groupBox1.Location = new Point(280, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(584, 334);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Статистика роста людей";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(572, 231);
            dataGridView1.TabIndex = 4;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellValidating += ValidateNameCell;
            dataGridView1.CellValidating += ValidateGenderCell;
            dataGridView1.CellValidating += ValidateHeightCell;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(6, 259);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(130, 30);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Сгенерировать";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(142, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить в JSON";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(278, 259);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(130, 30);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Загрузить из JSON";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnCalculateStats
            // 
            btnCalculateStats.Location = new Point(414, 259);
            btnCalculateStats.Name = "btnCalculateStats";
            btnCalculateStats.Padding = new Padding(0, 3, 0, 0);
            btnCalculateStats.Size = new Size(130, 30);
            btnCalculateStats.TabIndex = 3;
            btnCalculateStats.Text = "Рассчитать статистику";
            btnCalculateStats.UseVisualStyleBackColor = true;
            btnCalculateStats.Click += btnCalculateStats_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTallestWoman);
            groupBox2.Controls.Add(lblTallestMan);
            groupBox2.Controls.Add(lblAvgFemale);
            groupBox2.Controls.Add(lblAvgMale);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(280, 365);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(584, 94);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Результаты статистики";
            // 
            // lblTallestWoman
            // 
            lblTallestWoman.AutoSize = true;
            lblTallestWoman.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTallestWoman.Location = new Point(378, 47);
            lblTallestWoman.Name = "lblTallestWoman";
            lblTallestWoman.Size = new Size(12, 15);
            lblTallestWoman.TabIndex = 7;
            lblTallestWoman.Text = "-";
            // 
            // lblTallestMan
            // 
            lblTallestMan.AutoSize = true;
            lblTallestMan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTallestMan.Location = new Point(378, 22);
            lblTallestMan.Name = "lblTallestMan";
            lblTallestMan.Size = new Size(12, 15);
            lblTallestMan.TabIndex = 6;
            lblTallestMan.Text = "-";
            // 
            // lblAvgFemale
            // 
            lblAvgFemale.AutoSize = true;
            lblAvgFemale.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvgFemale.Location = new Point(148, 47);
            lblAvgFemale.Name = "lblAvgFemale";
            lblAvgFemale.Size = new Size(12, 15);
            lblAvgFemale.TabIndex = 5;
            lblAvgFemale.Text = "-";
            // 
            // lblAvgMale
            // 
            lblAvgMale.AutoSize = true;
            lblAvgMale.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvgMale.Location = new Point(146, 22);
            lblAvgMale.Name = "lblAvgMale";
            lblAvgMale.Size = new Size(12, 15);
            lblAvgMale.TabIndex = 4;
            lblAvgMale.Text = "-";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(278, 47);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 3;
            label9.Text = "Самая высокая:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(278, 22);
            label8.Name = "label8";
            label8.Size = new Size(100, 15);
            label8.TabIndex = 2;
            label8.Text = "Самый высокий:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 47);
            label7.Name = "label7";
            label7.Size = new Size(136, 15);
            label7.TabIndex = 1;
            label7.Text = "Средний рост женщин:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 22);
            label6.Name = "label6";
            label6.Size = new Size(134, 15);
            label6.TabIndex = 0;
            label6.Text = "Средний рост мужчин:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 471);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            Text = "Лабораторная работа";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button btnGenerate;
        private Button btnSave;
        private Button btnLoad;
        private Button btnCalculateStats;
        private GroupBox groupBox2;
        private Label lblTallestWoman;
        private Label lblTallestMan;
        private Label lblAvgFemale;
        private Label lblAvgMale;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
    }
}