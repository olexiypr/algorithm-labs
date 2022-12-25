using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        public void ShowByKey_Click(object sender, EventArgs e)
        {
            var input = this.GetByKeyInput.Text;
            if (!int.TryParse(input, out int key))
            {
                MessageBox.Show("Invalid id!");
                this.GetByKeyInput.Text = "";
            }
            try
            {
                var record = CRUD.GetByKey(key);
                DisplayRecord(record);
                MessageBox.Show("Count equals: " + CRUD.CountEquals);
                CRUD.CountEquals = 0;
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("There is no record with this key");
                this.GetByKeyInput.Text = "";
            }
        }
        private void DisplayRecord (Record record)
        {
            this.ResultTextBox.Text = "";
            this.ResultTextBox.Text = $"{record.Value}";
            this.ResultIdLabel.Text = record.Key.ToString();
        }

        private void DeleteByKeyButton_Click(object sender, EventArgs e)
        {
            var input = this.GetByKeyInput.Text;
            if (!int.TryParse(input, out int key))
            {
                MessageBox.Show("Invalid id!");
                this.GetByKeyInput.Text = "";
            }
            try
            {
                CRUD.DeleteRecordByKey(key);
                MessageBox.Show("Success!");
                ClearResult();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("There is no record with this key");
                this.GetByKeyInput.Text = "";
            }
        }
        private void ClearResult ()
        {
            this.ResultTextBox.Text = "";
            this.ResultIdLabel.Text = "";
        }
        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SaveChangesButton.Visible = true;
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            var record = CRUD.GetByKey(int.Parse(this.ResultIdLabel.Text));
            record.Value = this.ResultTextBox.Text;
            this.ResultTextBox.Text = record.Value;
            this.ResultIdLabel.Text = record.Key.ToString();
            CRUD.WriteBlocks();
            MessageBox.Show("Success!");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var record = CRUD.Add(this.AddInput.Text);
            DisplayRecord(record);
        }
    }
}
