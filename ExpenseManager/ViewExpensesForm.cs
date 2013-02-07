using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.XPath;

namespace ExpenseManager
{
    public partial class ViewExpensesForm : Form
    {
        private DateTime fromDate;
        private DateTime toDate;
        private String item = String.Empty;
        private ArrayList categories;
        private double fromAmount;
        private double toAmount;
        private Hashtable userInputPair=null;

        public ViewExpensesForm()
        {
            InitializeComponent();
            //categoryCombo.Items.AddRange(ExpenseManager.Controls.getCategoryOptions());
            categoryList.Items.AddRange(ExpenseManager.Controls.getCategoryOptions());
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
            //errors.AddRange(validateCategory().ToArray());
            errors.AddRange(validateAmount().ToArray());
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
                if (toDate.CompareTo(fromDate) < 0)
                {
                    errors.Add("The To Date cannot be lesser than from date.");
                }
                else if (toDate.CompareTo(today) > 0)
                {
                    errors.Add("The 'ToDate' cannot be greater than today's date, " + today.ToShortDateString());
                }
            }
            return errors;
        }

        /*private ArrayList validateCategory()
        {
            ArrayList errors = new ArrayList();
            if (categoryCombo.SelectedItem == null && categoryCombo.Text!="")
            {
                errors.Add("Category should be selected from the list");
            }
            return errors;
        }*/

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
                    errors.Add("The 'To Amount' cannot be lesser than 'From Amount'.");
                }
            }
            return errors;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            XmlOperations.XmlSearch xmlNavigator = new XmlOperations.XmlSearch();
            if (!isFormValid())
            {
                return;
            }
            storeInputValues();
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
            XmlElement docParent = xmlDoc.DocumentElement;
            double totalCost = 0;
            String[] calenderAttributeNames = new String[] { "day", "month", "year" };
            initGridView();
            for (DateTime searchDate = fromDate; searchDate.CompareTo(toDate) <= 0; searchDate=searchDate.AddDays(1))
            {
                userInputPair["date"] = searchDate;
                XmlNode calenderNode = xmlNavigator.findFirstNode(ref docParent, "calender", calenderAttributeNames, new String[] { searchDate.Day.ToString(), searchDate.Month.ToString(), searchDate.Year.ToString() });
                if (calenderNode == null)
                {
                    //MessageBox.Show("Could not find any record with the given filter.", "Expense Mgmt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }
                IEnumerator expenseNode = calenderNode.ChildNodes.GetEnumerator();
                while(expenseNode.MoveNext())
                {
                    if (xmlNavigator.isNodeMatching((XmlNode)expenseNode.Current,userInputPair))
                    {
                        //Code to insert row into datatable
                        XPathNavigator navigateExpenseToDisplay = ((XmlNode)expenseNode.Current).CreateNavigator();
                        navigateExpenseToDisplay.MoveToChild(XPathNodeType.Element);
                        string item = navigateExpenseToDisplay.Value;
                        navigateExpenseToDisplay.MoveToNext();
                        string category = navigateExpenseToDisplay.Value;
                        navigateExpenseToDisplay.MoveToNext();
                        string cost = navigateExpenseToDisplay.Value;
                        totalCost += double.Parse(cost);
                        navigateExpenseToDisplay.MoveToNext();
                        string comment = navigateExpenseToDisplay.Value;
                        navigateExpenseToDisplay.MoveToNext();
                        string id = navigateExpenseToDisplay.Value;
                        string date = searchDate.ToShortDateString().ToString();
                        dataGridView1.Rows.Add(new String[] {id, date, item, cost, category, comment});
                    }
                }
            }
            totalCostTxtBox.Text = totalCost+"";
            AvgCostTxtBox.Text = Math.Round(totalCost / (((toDate - fromDate).TotalDays)+1),2) + "";
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Dispose(true);
            Close();
        }

        private void storeInputValues()
        {
            userInputPair = new Hashtable();
            fromDate = fromDatePicker.Value;
            userInputPair.Add("date", fromDate);
            if (toDateChkBox.Checked)
            {
                toDate = toDatePicker.Value;
            }
            else
            {
                toDate = fromDate;
            }
            if (!itemTxtBox.Text.Equals(String.Empty))
            {
                item = itemTxtBox.Text;
                userInputPair.Add("item", item);
            }
            if (categoryList.SelectedItems.Count>0)
            {
                categories = new ArrayList();
                for (int i = 0; i < categoryList.SelectedItems.Count; i++ )
                    categories.Add(categoryList.SelectedItems[i].ToString());
                userInputPair.Add("category", categories);
            }
            if (!fromAmountTxtBox.Text.Equals(""))
            {
            	fromAmount = Double.Parse(fromAmountTxtBox.Text);
                userInputPair.Add("FromAmount", fromAmount);
                if (toAmountChkBox.Checked)
                {
                    toAmount = Double.Parse(toAmountTxtBox.Text);
                    userInputPair.Add("ToAmount", toAmount);
                }
                else
                {
                    toAmount = fromAmount;
                    userInputPair.Add("ToAmount", fromAmount);
                }
            }
        }

        protected void initGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Date","Date");
            dataGridView1.Columns.Add("Item", "Item");
            dataGridView1.Columns.Add("Cost", "Cost");
            dataGridView1.Columns.Add("Category", "Category");
            dataGridView1.Columns.Add("Comment", "Comment");
            dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
