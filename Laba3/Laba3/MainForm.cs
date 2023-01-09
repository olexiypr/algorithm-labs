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
            this.ResultTextBox.ReadOnly = true;
        }
        
        private void ShowByKey_Click(object sender, EventArgs e)
        {
            var input = this.GetByKeyInput.Text;
            if (!int.TryParse(input, out int key))
            {
                MessageBox.Show("Invalid id!");
                this.GetByKeyInput.Text = "";
                return;
            }
            try
            {
                var record = CRUD.GetCRUD().GetByKey(key);
                DisplayRecord(record);
                this.SaveChangesButton.Visible = false;
                MessageBox.Show("Count equals: " + CRUD.GetCRUD().CountEquals);
                CRUD.GetCRUD().CountEquals = 0;
                this.ResultTextBox.ReadOnly = false;
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("There is no record with this key");
                this.GetByKeyInput.Text = "";
                this.ResultTextBox.ReadOnly = true;
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
                return;
            }
            try
            {
                CRUD.GetCRUD().DeleteRecordByKey(key);
                MessageBox.Show("Success!");
                ClearResult();
                this.SaveChangesButton.Visible = false;
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
            if (ResultIdLabel.Text != "")
            {
                this.SaveChangesButton.Visible = true;
            }
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            var record = CRUD.GetCRUD().GetByKey(int.Parse(this.ResultIdLabel.Text));
            if (record.Value == this.ResultTextBox.Text)
            {
                MessageBox.Show("Cannot update the same values!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.ResultTextBox.Text) || string.IsNullOrWhiteSpace(this.ResultTextBox.Text))
            {
                MessageBox.Show("Cannot update empty value!");
                return;
            }
            record.Value = this.ResultTextBox.Text;
            this.ResultTextBox.Text = record.Value;
            this.ResultIdLabel.Text = record.Key.ToString();
            CRUD.GetCRUD().WriteBlocks();
            MessageBox.Show("Success!");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (this.AddInput.Text is "" || string.IsNullOrWhiteSpace(this.AddInput.Text))
            {
                MessageBox.Show("Cannot add empty value!");
                return;
            }

            this.SaveChangesButton.Visible = false;
            this.ResultTextBox.ReadOnly = false;
            var record = CRUD.GetCRUD().Add(this.AddInput.Text);
            DisplayRecord(record);
        }
    }
}
