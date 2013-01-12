using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ExpenseManager
{
    public partial class ViewExpensesForm : Form
    {
        public ViewExpensesForm()
        {
            InitializeComponent();
            categoryCombo.Items.AddRange(ExpenseManager.Controls.getCategoryOptions());
            this.fromAmountTxtBox.TextChanged += new System.EventHandler(ExpenseManager.Controls.validateAmountLively);
            this.toAmountTxtBox.TextChanged += new System.EventHandler(ExpenseManager.Controls.validateAmountLively);
        }

        private void toDateChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (toDateChkBox.Checked)
            {
                fromDateLabel.Text = "From Date";
                toDatePicker.Enabled = true;
            } 
            else
            {
                fromDateLabel.Text = "Date";
                toDatePicker.Enabled = false;
            }
        }

        private void toAmountChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (toAmountChkBox.Checked)
            {
                fromAmountLabel.Text = "From Amount";
                toAmountTxtBox.Enabled = true;
            } 
            else
            {
                fromAmountLabel.Text = "Amount";
                toAmountTxtBox.Enabled = false;
            }
        }

        private bool isFormValid()
        {
            ArrayList errors = new ArrayList();
            errors.AddRange(validateDate().ToArray());
            errors.AddRange(validateCategory().ToArray());
            errors.AddRange(validateAmount());
            if (errors.Count > 0)
            {
                String consolidatedError = "";
                foreach (String error in errors)
                {
                    consolidatedError += (error + "\n");
                }
                MessageBox.Show(consolidatedError, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private ArrayList validateDate()
        {
            ArrayList errors = new ArrayList();
            DateTime today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            DateTime fromDate = new DateTime(fromDatePicker.Value.Year, fromDatePicker.Value.Month, fromDatePicker.Value.Day);
            if (fromDate.CompareTo(today) > 0)
            {
                errors.Add("The From Date cannot be greater than today's date.");
            }
            if(toDateChkBox.Checked)
            {
                DateTime toDate = new DateTime(toDatePicker.Value.Year, toDatePicker.Value.Month, toDatePicker.Value.Day);
                if (toDate.CompareTo(fromDate) > 0)
                {
                    errors.Add("The To Date cannot be greater than from date.");
                }
            }
            return errors;
        }

        private ArrayList validateCategory()
        {
            ArrayList errors = new ArrayList();
            if (categoryCombo.SelectedItem == null && categoryCombo.Text!="")
            {
                errors.Add("Category should be selected from the list");
            }
            return errors;
        }

        private ArrayList validateAmount()
        {
            ArrayList errors = new ArrayList();
            if (!toAmountChkBox.Checked)
            {
                //Do Nothing
            }
            else
            {
                if (fromAmountTxtBox.Text=="")
                {
                    errors.Add("When 'To Amount' is checked, 'From Amount' cannot be empty.");
                }
                else if (toAmountTxtBox.Text == "")
                {
                    errors.Add("When 'To Amount' is checked, 'To Amount' cannot be empty");
                }
                else if ( Double.Parse(toAmountTxtBox.Text) < Double.Parse(fromAmountTxtBox.Text) ) 
                {
                    errors.Add("The 'To Amount' cannot be greater than 'From Amount'.");
                }
            }
            return errors;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!isFormValid())
            {
                return;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Dispose(true);
            Close();
        }
    }
}
