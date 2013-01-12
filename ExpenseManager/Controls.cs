using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpenseManager
{
    public class Controls
    {
        protected static string[] categoryOptions = { "Travel", "Food", "HomeExpenses", "Gift/Donation", "Electronics", "Miscellaneous" };

        public static string[] getCategoryOptions()
        {
            return categoryOptions;
        }

        public static void validateAmountLively(object sender, EventArgs e)
        {
            TextBox amountBox = (TextBox)sender;
            try
            {
                double amount = double.Parse(amountBox.Text);
                if (amount < 0 || amountBox.Text.Contains(','))
                {
                    throw new FormatException();
                }
            }
            catch (System.Exception)
            {
                try
                {
                    int cursorIndex = amountBox.SelectionStart - 1;
                    amountBox.Text = amountBox.Text.Remove(cursorIndex, 1);
                    amountBox.SelectionStart = cursorIndex;
                    amountBox.SelectionLength = 0;
                }
                catch (System.Exception)
                {

                }
            }
        }
    }
}
