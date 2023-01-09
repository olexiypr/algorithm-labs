namespace Laba3_UI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddButton = new System.Windows.Forms.Button();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.GetByKeyInput = new System.Windows.Forms.TextBox();
            this.ShowByKeyButton = new System.Windows.Forms.Button();
            this.AddInput = new System.Windows.Forms.TextBox();
            this.DeleteByKeyButton = new System.Windows.Forms.Button();
            this.InputIdLableLabel = new System.Windows.Forms.Label();
            this.InputValueLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ResultIdLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.GroupBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResultBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(191, 88);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.Location = new System.Drawing.Point(62, 86);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(102, 23);
            this.SaveChangesButton.TabIndex = 1;
            this.SaveChangesButton.Text = "Save changes";
            this.SaveChangesButton.UseVisualStyleBackColor = true;
            this.SaveChangesButton.Visible = false;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // GetByKeyInput
            // 
            this.GetByKeyInput.Location = new System.Drawing.Point(65, 26);
            this.GetByKeyInput.Name = "GetByKeyInput";
            this.GetByKeyInput.Size = new System.Drawing.Size(100, 20);
            this.GetByKeyInput.TabIndex = 2;
            // 
            // ShowByKeyButton
            // 
            this.ShowByKeyButton.Location = new System.Drawing.Point(191, 23);
            this.ShowByKeyButton.Name = "ShowByKeyButton";
            this.ShowByKeyButton.Size = new System.Drawing.Size(75, 23);
            this.ShowByKeyButton.TabIndex = 3;
            this.ShowByKeyButton.Text = "Get by key";
            this.ShowByKeyButton.UseCompatibleTextRendering = true;
            this.ShowByKeyButton.UseVisualStyleBackColor = true;
            this.ShowByKeyButton.Click += new System.EventHandler(this.ShowByKey_Click);
            // 
            // AddInput
            // 
            this.AddInput.Location = new System.Drawing.Point(65, 91);
            this.AddInput.Name = "AddInput";
            this.AddInput.Size = new System.Drawing.Size(100, 20);
            this.AddInput.TabIndex = 6;
            // 
            // DeleteByKeyButton
            // 
            this.DeleteByKeyButton.Location = new System.Drawing.Point(293, 23);
            this.DeleteByKeyButton.Name = "DeleteByKeyButton";
            this.DeleteByKeyButton.Size = new System.Drawing.Size(92, 23);
            this.DeleteByKeyButton.TabIndex = 7;
            this.DeleteByKeyButton.Text = "Delete by key";
            this.DeleteByKeyButton.UseVisualStyleBackColor = true;
            this.DeleteByKeyButton.Click += new System.EventHandler(this.DeleteByKeyButton_Click);
            // 
            // InputIdLableLabel
            // 
            this.InputIdLableLabel.AutoSize = true;
            this.InputIdLableLabel.Location = new System.Drawing.Point(26, 28);
            this.InputIdLableLabel.Name = "InputIdLableLabel";
            this.InputIdLableLabel.Size = new System.Drawing.Size(21, 13);
            this.InputIdLableLabel.TabIndex = 8;
            this.InputIdLableLabel.Text = "ID:";
            // 
            // InputValueLabel
            // 
            this.InputValueLabel.AutoSize = true;
            this.InputValueLabel.Location = new System.Drawing.Point(12, 93);
            this.InputValueLabel.Name = "InputValueLabel";
            this.InputValueLabel.Size = new System.Drawing.Size(37, 13);
            this.InputValueLabel.TabIndex = 9;
            this.InputValueLabel.Text = "Value:";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(62, 48);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(124, 20);
            this.ResultTextBox.TabIndex = 10;
            this.ResultTextBox.TextChanged += new System.EventHandler(this.ResultTextBox_TextChanged);
            // 
            // ResultIdLabel
            // 
            this.ResultIdLabel.AutoSize = true;
            this.ResultIdLabel.Location = new System.Drawing.Point(66, 22);
            this.ResultIdLabel.Name = "ResultIdLabel";
            this.ResultIdLabel.Size = new System.Drawing.Size(0, 13);
            this.ResultIdLabel.TabIndex = 11;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(37, 22);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(19, 13);
            this.IdLabel.TabIndex = 12;
            this.IdLabel.Text = "Id:";
            // 
            // ResultBox
            // 
            this.ResultBox.Controls.Add(this.ResultTextBox);
            this.ResultBox.Controls.Add(this.IdLabel);
            this.ResultBox.Controls.Add(this.ResultLabel);
            this.ResultBox.Controls.Add(this.ResultIdLabel);
            this.ResultBox.Controls.Add(this.SaveChangesButton);
            this.ResultBox.Location = new System.Drawing.Point(108, 155);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(246, 128);
            this.ResultBox.TabIndex = 13;
            this.ResultBox.TabStop = false;
            this.ResultBox.Text = "Result";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(19, 51);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(37, 13);
            this.ResultLabel.TabIndex = 4;
            this.ResultLabel.Text = "Value:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Controls.Add(this.GetByKeyInput);
            this.groupBox1.Controls.Add(this.InputValueLabel);
            this.groupBox1.Controls.Add(this.ShowByKeyButton);
            this.groupBox1.Controls.Add(this.InputIdLableLabel);
            this.groupBox1.Controls.Add(this.AddInput);
            this.groupBox1.Controls.Add(this.DeleteByKeyButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 126);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResultBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laba 3";
            this.ResultBox.ResumeLayout(false);
            this.ResultBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.Button AddButton;
        public  System.Windows.Forms.Button SaveChangesButton;
        public  System.Windows.Forms.TextBox GetByKeyInput;
        public  System.Windows.Forms.Button ShowByKeyButton;
        public  System.Windows.Forms.TextBox AddInput;
        public  System.Windows.Forms.Button DeleteByKeyButton;
        public  System.Windows.Forms.Label InputIdLableLabel;
        public  System.Windows.Forms.Label InputValueLabel;
        public  System.Windows.Forms.TextBox ResultTextBox;
        public  System.Windows.Forms.Label ResultIdLabel;
        public  System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.GroupBox ResultBox;
        public System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

