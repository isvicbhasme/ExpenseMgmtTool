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
using System.Xml.XPath;
using System.IO;


namespace ExpenseManager
{
    public partial class NewExpenseForm : Form
    {
        XmlOperations.XmlSearch xmlNavigator = new XmlOperations.XmlSearch();
        public NewExpenseForm()
        {
            InitializeComponent();
            category.Items.AddRange(ExpenseManager.Controls.getCategoryOptions());
            cost.TextChanged += new System.EventHandler(ExpenseManager.Controls.validateAmountLively);
        }

        private bool isFormValid()
        {
            ArrayList errors = new ArrayList();
            DateTime userDate = new DateTime(expenseDate.Value.Year, expenseDate.Value.Month, expenseDate.Value.Day);
            DateTime today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            if (userDate.CompareTo(today) > 0)
            {
                errors.Add("Date cannot be greater than today's date.");
            }
            if (itemName.Text.Equals(""))
            {
                errors.Add("Item Name cannot be left empty");
            }
            if (cost.Text.Equals(""))
            {
                errors.Add("Amount cannot be left empty");
            }
            if (category.SelectedItem == null)
            {
                errors.Add("Category should be selected from the list");
            }
            if (errors.Count > 0)
            {
                String consolidatedError = "";
                foreach (String error in errors)
                {
                    consolidatedError += (error+"\n");
                }
                MessageBox.Show(consolidatedError, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose(true);
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isFormValid())
                    return;
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
                XmlNode newExpenseElement = getDataAsXML(xmlDoc);
                XmlNode appendPosition = xmlNavigator.findFirstNode(ref docParent,"calender",new String[] {"day","month","year"},new String[] {expenseDate.Value.Day.ToString(), expenseDate.Value.Month.ToString(), expenseDate.Value.Year.ToString()});
                if(appendPosition == null)
                {
                    XmlElement newCalender = xmlDoc.CreateElement("calender");
                    newCalender.SetAttribute("day",expenseDate.Value.Day.ToString());
                    newCalender.SetAttribute("month",expenseDate.Value.Month.ToString());
                    newCalender.SetAttribute("year",expenseDate.Value.Year.ToString());
                    newCalender.AppendChild(newExpenseElement);
                    docParent.AppendChild(newCalender);
                }
                else
                {
                    appendPosition.AppendChild(newExpenseElement);
                }
                xmlDoc.Save(SysTray.getXmlFile());
                Dispose(true);
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Exception Occurred");
            }
        }

        private XmlNode getDataAsXML(XmlDocument xmlDoc)
        {
            XmlElement itemNode = xmlDoc.CreateElement("item");
            itemNode.AppendChild(xmlDoc.CreateTextNode(itemName.Text));
            XmlElement categoryNode = xmlDoc.CreateElement("category");
            categoryNode.AppendChild(xmlDoc.CreateTextNode(category.SelectedItem.ToString()));
            XmlElement amountNode = xmlDoc.CreateElement("cost");
            amountNode.AppendChild(xmlDoc.CreateTextNode(cost.Text));
            XmlElement commentNode = xmlDoc.CreateElement("comment");
            commentNode.AppendChild(xmlDoc.CreateTextNode(comment.Text));

            XmlNode expenseNode = xmlDoc.CreateElement("expense");
            expenseNode.AppendChild(itemNode);
            expenseNode.AppendChild(categoryNode);
            expenseNode.AppendChild(amountNode);
            expenseNode.AppendChild(commentNode);
            return expenseNode;
        }
    }
}
