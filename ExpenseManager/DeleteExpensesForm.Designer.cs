namespace ExpenseManager
{
    partial class DeleteExpensesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteBtn = new System.Windows.Forms.Button();
            this.filterGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.deleteBtn);
            this.filterGroup.Controls.SetChildIndex(this.deleteBtn, 0);
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
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(240, 150);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 15;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // DeleteExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 509);
            this.Name = "DeleteExpensesForm";
            this.Text = "Delete Expenses Form";
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteBtn;
    }
}