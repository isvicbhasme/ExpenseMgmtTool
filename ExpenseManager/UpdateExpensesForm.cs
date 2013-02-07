using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpenseManager
{
    class UpdateExpensesForm : ViewExpensesForm
    {
        public UpdateExpensesForm() : base()
        {
            this.Text = "Update Expense Form";
            this.closeBtn.TabIndex++;
            this.filterGroup.Controls.Add(this.createUpdateButton());
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(cellContent_Changed);
        }

        private Button createUpdateButton()
        {
            Button updateBtn = new Button();
            updateBtn.Location = new System.Drawing.Point(250, 151);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new System.Drawing.Size(75, 23);
            updateBtn.TabIndex = this.closeBtn.TabIndex - 1;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += new System.EventHandler(updateBtn_Click);
            return updateBtn;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }

        private void cellContent_Changed(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
