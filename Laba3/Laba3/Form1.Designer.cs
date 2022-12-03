namespace Laba3_UI
{
    partial class Form1
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
            this.SaveChanges = new System.Windows.Forms.Button();
            this.GetByKeyInput = new System.Windows.Forms.TextBox();
            this.GetByKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AddInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            // SaveChanges
            // 
            this.SaveChanges.Location = new System.Drawing.Point(156, 341);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(102, 23);
            this.SaveChanges.TabIndex = 1;
            this.SaveChanges.Text = "Save changes";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Visible = false;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // GetByKeyInput
            // 
            this.GetByKeyInput.Location = new System.Drawing.Point(65, 59);
            this.GetByKeyInput.Name = "GetByKeyInput";
            this.GetByKeyInput.Size = new System.Drawing.Size(100, 20);
            this.GetByKeyInput.TabIndex = 2;
            // 
            // GetByKey
            // 
            this.GetByKey.Location = new System.Drawing.Point(214, 56);
            this.GetByKey.Name = "GetByKey";
            this.GetByKey.Size = new System.Drawing.Size(75, 23);
            this.GetByKey.TabIndex = 3;
            this.GetByKey.Text = "Get by key";
            this.GetByKey.UseCompatibleTextRendering = true;
            this.GetByKey.UseVisualStyleBackColor = true;
            this.GetByKey.Click += new System.EventHandler(this.GetByKey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Result: ";
            // 
            // AddInput
            // 
            this.AddInput.Location = new System.Drawing.Point(65, 149);
            this.AddInput.Name = "AddInput";
            this.AddInput.Size = new System.Drawing.Size(100, 20);
            this.AddInput.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Delete by key";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Value:";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(239, 271);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(124, 20);
            this.ResultTextBox.TabIndex = 10;
            this.ResultTextBox.TextChanged += new System.EventHandler(this.ResultTextBox_TextChanged);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(170, 274);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(0, 13);
            this.IdLabel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Id:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetByKey);
            this.Controls.Add(this.GetByKeyInput);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.AddButton);
            this.Name = "Form1";
            this.Text = "Laba 3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.Button AddButton;
        public  System.Windows.Forms.Button SaveChanges;
        public  System.Windows.Forms.TextBox GetByKeyInput;
        public  System.Windows.Forms.Button GetByKey;
        public  System.Windows.Forms.Label label1;
        public  System.Windows.Forms.TextBox AddInput;
        public  System.Windows.Forms.Button button1;
        public  System.Windows.Forms.Label label2;
        public  System.Windows.Forms.Label label3;
        public  System.Windows.Forms.TextBox ResultTextBox;
        public  System.Windows.Forms.Label IdLabel;
        public  System.Windows.Forms.Label label4;
    }
}

