using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager
{
    public class SysTray : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu contextMenu;
        private static string xmlFile = "Expenses.xml";

        public SysTray()
        {
            //Create Menu Items
            contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("New Expense", onCreateExpense);
            contextMenu.MenuItems.Add("View Expenses", onViewExpense);
            contextMenu.MenuItems.Add("Delete Expense", onDeleteExpense);
            contextMenu.MenuItems.Add("Update Expense", onUpdateExpense);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("Exit", onExit);

            //Create Menu Icon
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Track Your Daily Expenses";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.ContextMenu = contextMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }

        private void onCreateExpense(Object sender, EventArgs e)
        {
            if (!isFormOpen("New Expense Form"))
            {
                NewExpenseForm newExpenseForm = new NewExpenseForm();
                newExpenseForm.Show();
            }
        }

        private void onViewExpense(Object sender, EventArgs e)
        {
            if (!isFormOpen("View Expenses Form"))
            {
                ViewExpensesForm viewExpensesForm = new ViewExpensesForm();
                viewExpensesForm.Show();
            }
        }

        private void onDeleteExpense(Object sender, EventArgs e)
        {

        }

        private void onUpdateExpense(Object sender, EventArgs e)
        {

        }

        private void onExit(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                trayIcon.Dispose();
            }
            base.Dispose(isDisposing);
        }

        //
        //Summary:
        //  Checks whether a form is already open
        //
        //Parameters:
        //  formName:
        //      The name of the form that needs to be checked whether it is open
        //
        //Returns:
        //  'true' when the form is open
        //  'false' when the form is not open
        //
        //Exceptions:
        //  System.ArgumentNullException:
        //     formName is null.
        //
        public bool isFormOpen(string formName)
        {
            try
            {
                foreach (Form form in Application.OpenForms)                //Iterate through each form that is opened
                {
                    if (form.Text.IndexOf(formName) >= 0)                   //Using form name, check if the iterated form is the required form
                    {
                        MessageBox.Show("The window " + formName + " is already open.", "Message");
                        return true;
                    }
                }
            }
            catch (System.ArgumentNullException ex)
            {
                MessageBox.Show("Exception occurred while checking whether the form is already open.\n" + ex.StackTrace, "Exception");
            }
            return false;
        }

        public static string getXmlFile()
        {
            return xmlFile;
        }
    }
}
