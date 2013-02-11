using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;
using System.Globalization;


namespace ExpenseManager
{
    struct InvalidatedExpense
    {
        public string expenseID;
        public int rowIndex;

        public InvalidatedExpense(string id, int index)
        {
            expenseID = id;
            rowIndex = index;
        }
    }

    class UpdateExpensesForm : ViewExpensesForm
    {
        public UpdateExpensesForm() : base()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(cellContent_Changed);
            modifiedExpenseList = new ArrayList();
        }

        private bool isUpdateBtnClicked = false;
        private ArrayList modifiedExpenseList;
        private Label alertLabel;
        private Button updateBtn;
        private Hashtable expense;

        private void updateBtn_Click(object sender, EventArgs e)
        {
            isUpdateBtnClicked = true;
            searchBtn_Click(sender, e);
            isUpdateBtnClicked = false;
            updateBtn.Enabled = false;
        }

        private void cellContent_Changed(object sender, DataGridViewCellEventArgs e)
        {
            string modifiedExpenseId = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (InvalidatedExpense preModifiedExpense in modifiedExpenseList)
            {
                if (preModifiedExpense.expenseID.CompareTo(modifiedExpenseId) == 0)
                {
                    return;
                }
            }
            modifiedExpenseList.Add(new InvalidatedExpense(modifiedExpenseId, e.RowIndex));
            updateBtn.Enabled = true;
        }

        protected override void searchBtn_Click(object sender, EventArgs e)
        {
            if (!isUpdateBtnClicked)
            {
                base.searchBtn_Click(sender, e);
                modifiedExpenseList = new ArrayList();
                updateBtn.Enabled = false;
                dataGridView1.Columns["Date"].ReadOnly = true;
                return;
            }
            foreach (InvalidatedExpense invalidExpense in modifiedExpenseList)
            {
                expense = new Hashtable();
                expense["date"] = DateTime.ParseExact(this.dataGridView1.Rows[invalidExpense.rowIndex].Cells[1].Value.ToString(), "dd-MMM-yy", new CultureInfo("en-US"));
                expense["item"] = this.dataGridView1.Rows[invalidExpense.rowIndex].Cells[2].Value.ToString();
                expense["cost"] = double.Parse(this.dataGridView1.Rows[invalidExpense.rowIndex].Cells[3].Value.ToString());
                expense["category"] = this.dataGridView1.Rows[invalidExpense.rowIndex].Cells[4].Value.ToString();
                expense["comment"] = this.dataGridView1.Rows[invalidExpense.rowIndex].Cells[5].Value.ToString();
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
                XmlNode oldExpenseCalenderNode = xmlNavigator.findFirstNode(xmlDoc.DocumentElement, "calender", new String[] { "day", "month", "year" }, new String[] { ((DateTime)expense["date"]).Day.ToString(), ((DateTime)expense["date"]).Month.ToString(), ((DateTime)expense["date"]).Year.ToString() });
                XmlNode oldExpense = xmlNavigator.findFirstNode(oldExpenseCalenderNode, "id", invalidExpense.expenseID);
                xmlNavigator.replaceElement(oldExpense, expense);
                xmlDoc.Save(SysTray.getXmlFile());
            }
        }

        protected override void initGridView()
        {
            if (!isUpdateBtnClicked)
            {
            	base.initGridView();
                return;
            }
        }

        protected override void storeInputValues()
        {
            if (!isUpdateBtnClicked)
            {
            	base.storeInputValues();
                return;
            }
        }

        protected override System.Collections.ArrayList validateDate()
        {
            if (!isUpdateBtnClicked)
            {
            	return base.validateDate();
            }
            return null;
        }

        protected override bool isFormValid()
        {
            if (!isUpdateBtnClicked)
            {
            	return base.isFormValid();
            }
            return false;
        }

        private void InitializeComponent()
        {
            this.alertLabel = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.filterGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.updateBtn);
            this.filterGroup.Controls.SetChildIndex(this.updateBtn, 0);
            this.filterGroup.Controls.SetChildIndex(this.fromDateLabel, 0);
            this.filterGroup.Controls.SetChildIndex(this.fromDatePicker, 0);
            this.filterGroup.Controls.SetChildIndex(this.toDatePicker, 0);
            this.filterGroup.Controls.SetChildIndex(this.itemLabel, 0);
            this.filterGroup.Controls.SetChildIndex(this.itemTxtBox, 0);
            this.filterGroup.Controls.SetChildIndex(this.categoryLabel, 0);
            this.filterGroup.Controls.SetChildIndex(this.fromAmountLabel, 0);
            this.filterGroup.Controls.SetChildIndex(this.fromAmountTxtBox, 0);
            this.filterGroup.Controls.SetChildIndex(this.toAmountTxtBox, 0);
            this.filterGroup.Controls.SetChildIndex(this.toDateChkBox, 0);
            this.filterGroup.Controls.SetChildIndex(this.toAmountChkBox, 0);
            this.filterGroup.Controls.SetChildIndex(this.searchBtn, 0);
            this.filterGroup.Controls.SetChildIndex(this.closeBtn, 0);
            this.filterGroup.Controls.SetChildIndex(this.categoryList, 0);
            // 
            // alertLabel
            // 
            this.alertLabel.AutoSize = true;
            this.alertLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertLabel.ForeColor = System.Drawing.Color.Red;
            this.alertLabel.Location = new System.Drawing.Point(74, 497);
            this.alertLabel.Name = "alertLabel";
            this.alertLabel.Size = new System.Drawing.Size(250, 15);
            this.alertLabel.TabIndex = 6;
            this.alertLabel.Text = "Alert: Validation of edited content is not done.";
            // 
            // updateBtn
            // 
            this.updateBtn.Enabled = false;
            this.updateBtn.Location = new System.Drawing.Point(240, 150);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 15;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // UpdateExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(585, 517);
            this.Controls.Add(this.alertLabel);
            this.Name = "UpdateExpensesForm";
            this.Text = "Update Expense Form";
            this.Controls.SetChildIndex(this.alertLabel, 0);
            this.Controls.SetChildIndex(this.filterGroup, 0);
            this.Controls.SetChildIndex(this.totalCostLabel, 0);
            this.Controls.SetChildIndex(this.totalCostTxtBox, 0);
            this.Controls.SetChildIndex(this.AvgCostLabel, 0);
            this.Controls.SetChildIndex(this.AvgCostTxtBox, 0);
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
