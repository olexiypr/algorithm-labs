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
            this.ResultLabel = new System.Windows.Forms.Label();
            this.AddInput = new System.Windows.Forms.TextBox();
            this.DeleteByKeyButton = new System.Windows.Forms.Button();
            this.InputIdLableLabel = new System.Windows.Forms.Label();
            this.InputValueLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ResultIdLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(214, 146);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.Location = new System.Drawing.Point(156, 341);
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
            this.GetByKeyInput.Location = new System.Drawing.Point(65, 59);
            this.GetByKeyInput.Name = "GetByKeyInput";
            this.GetByKeyInput.Size = new System.Drawing.Size(100, 20);
            this.GetByKeyInput.TabIndex = 2;
            // 
            // ShowByKeyButton
            // 
            this.ShowByKeyButton.Location = new System.Drawing.Point(214, 56);
            this.ShowByKeyButton.Name = "ShowByKeyButton";
            this.ShowByKeyButton.Size = new System.Drawing.Size(75, 23);
            this.ShowByKeyButton.TabIndex = 3;
            this.ShowByKeyButton.Text = "Get by key";
            this.ShowByKeyButton.UseCompatibleTextRendering = true;
            this.ShowByKeyButton.UseVisualStyleBackColor = true;
            this.ShowByKeyButton.Click += new System.EventHandler(this.ShowByKey_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(84, 274);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(43, 13);
            this.ResultLabel.TabIndex = 4;
            this.ResultLabel.Text = "Result: ";
            // 
            // AddInput
            // 
            this.AddInput.Location = new System.Drawing.Point(65, 149);
            this.AddInput.Name = "AddInput";
            this.AddInput.Size = new System.Drawing.Size(100, 20);
            this.AddInput.TabIndex = 6;
            // 
            // DeleteByKeyButton
            // 
            this.DeleteByKeyButton.Location = new System.Drawing.Point(316, 56);
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
            this.InputIdLableLabel.Location = new System.Drawing.Point(26, 61);
            this.InputIdLableLabel.Name = "InputIdLableLabel";
            this.InputIdLableLabel.Size = new System.Drawing.Size(21, 13);
            this.InputIdLableLabel.TabIndex = 8;
            this.InputIdLableLabel.Text = "ID:";
            // 
            // InputValueLabel
            // 
            this.InputValueLabel.AutoSize = true;
            this.InputValueLabel.Location = new System.Drawing.Point(12, 151);
            this.InputValueLabel.Name = "InputValueLabel";
            this.InputValueLabel.Size = new System.Drawing.Size(37, 13);
            this.InputValueLabel.TabIndex = 9;
            this.InputValueLabel.Text = "Value:";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(239, 271);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(124, 20);
            this.ResultTextBox.TabIndex = 10;
            this.ResultTextBox.TextChanged += new System.EventHandler(this.ResultTextBox_TextChanged);
            // 
            // ResultIdLabel
            // 
            this.ResultIdLabel.AutoSize = true;
            this.ResultIdLabel.Location = new System.Drawing.Point(170, 274);
            this.ResultIdLabel.Name = "ResultIdLabel";
            this.ResultIdLabel.Size = new System.Drawing.Size(0, 13);
            this.ResultIdLabel.TabIndex = 11;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(145, 274);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(19, 13);
            this.IdLabel.TabIndex = 12;
            this.IdLabel.Text = "Id:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.ResultIdLabel);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.InputValueLabel);
            this.Controls.Add(this.InputIdLableLabel);
            this.Controls.Add(this.DeleteByKeyButton);
            this.Controls.Add(this.AddInput);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.ShowByKeyButton);
            this.Controls.Add(this.GetByKeyInput);
            this.Controls.Add(this.SaveChangesButton);
            this.Controls.Add(this.AddButton);
            this.Name = "MainForm";
            this.Text = "Laba 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.Button AddButton;
        public  System.Windows.Forms.Button SaveChangesButton;
        public  System.Windows.Forms.TextBox GetByKeyInput;
        public  System.Windows.Forms.Button ShowByKeyButton;
        public  System.Windows.Forms.Label ResultLabel;
        public  System.Windows.Forms.TextBox AddInput;
        public  System.Windows.Forms.Button DeleteByKeyButton;
        public  System.Windows.Forms.Label InputIdLableLabel;
        public  System.Windows.Forms.Label InputValueLabel;
        public  System.Windows.Forms.TextBox ResultTextBox;
        public  System.Windows.Forms.Label ResultIdLabel;
        public  System.Windows.Forms.Label IdLabel;
    }
}

