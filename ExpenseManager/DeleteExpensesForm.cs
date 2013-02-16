using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using System.Globalization;

namespace ExpenseManager
{
    public partial class DeleteExpensesForm : ViewExpensesForm
    {
        public DeleteExpensesForm()
        {
            InitializeComponent();
            this.dataGridView1.SelectionChanged += new EventHandler(DataGridView1_SelectionChanged);
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                this.deleteBtn.Enabled = true;
            }
            else
            {
                this.deleteBtn.Enabled = false;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            for (int selectionIndex = 0; selectionIndex < dataGridView1.SelectedRows.Count; selectionIndex++)
            {
                String expenseId = this.dataGridView1.SelectedRows[selectionIndex].Cells[0].Value.ToString();
                DateTime date = DateTime.ParseExact(this.dataGridView1.SelectedRows[selectionIndex].Cells[1].Value.ToString(), "dd-MMM-yy", new CultureInfo("en-US"));
                XmlOperations.XmlSearch xmlNavigator = new XmlOperations.XmlSearch();
                XmlDocument xmlDoc = new XmlDocument();
                if (File.Exists(SysTray.getXmlFile()))
                {
                    xmlDoc.Load(SysTray.getXmlFile());
                }
                else
                {
                    MessageBox.Show("File '" + SysTray.getXmlFile() + "' could not be found here.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                XmlNode calenderNode = xmlNavigator.findFirstNode(xmlDoc.DocumentElement, "calender", new String[] { "day", "month", "year" }, new String[] { date.Day.ToString(), date.Month.ToString(), date.Year.ToString() });
                XmlNode expense = xmlNavigator.findFirstNode(calenderNode, "id", expenseId);
                expense.ParentNode.RemoveChild(expense);
                xmlDoc.Save(SysTray.getXmlFile());
            }
            base.searchBtn_Click(sender, e);
        }

    }
}
