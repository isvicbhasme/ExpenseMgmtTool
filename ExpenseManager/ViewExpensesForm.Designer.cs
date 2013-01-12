﻿namespace ExpenseManager
{
    partial class ViewExpensesForm
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
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.toAmountChkBox = new System.Windows.Forms.CheckBox();
            this.toDateChkBox = new System.Windows.Forms.CheckBox();
            this.toAmountTxtBox = new System.Windows.Forms.TextBox();
            this.fromAmountTxtBox = new System.Windows.Forms.TextBox();
            this.fromAmountLabel = new System.Windows.Forms.Label();
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.itemTxtBox = new System.Windows.Forms.TextBox();
            this.itemLabel = new System.Windows.Forms.Label();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filterGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.closeBtn);
            this.filterGroup.Controls.Add(this.searchBtn);
            this.filterGroup.Controls.Add(this.toAmountChkBox);
            this.filterGroup.Controls.Add(this.toDateChkBox);
            this.filterGroup.Controls.Add(this.toAmountTxtBox);
            this.filterGroup.Controls.Add(this.fromAmountTxtBox);
            this.filterGroup.Controls.Add(this.fromAmountLabel);
            this.filterGroup.Controls.Add(this.categoryCombo);
            this.filterGroup.Controls.Add(this.categoryLabel);
            this.filterGroup.Controls.Add(this.itemTxtBox);
            this.filterGroup.Controls.Add(this.itemLabel);
            this.filterGroup.Controls.Add(this.toDatePicker);
            this.filterGroup.Controls.Add(this.fromDatePicker);
            this.filterGroup.Controls.Add(this.fromDateLabel);
            this.filterGroup.Location = new System.Drawing.Point(12, 12);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(531, 142);
            this.filterGroup.TabIndex = 0;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Filter";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(428, 104);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(428, 66);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 12;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // toAmountChkBox
            // 
            this.toAmountChkBox.AutoSize = true;
            this.toAmountChkBox.Location = new System.Drawing.Point(204, 104);
            this.toAmountChkBox.Name = "toAmountChkBox";
            this.toAmountChkBox.Size = new System.Drawing.Size(78, 17);
            this.toAmountChkBox.TabIndex = 10;
            this.toAmountChkBox.Text = "To Amount";
            this.toAmountChkBox.UseVisualStyleBackColor = true;
            this.toAmountChkBox.CheckedChanged += new System.EventHandler(this.toAmountChkBox_CheckedChanged);
            // 
            // toDateChkBox
            // 
            this.toDateChkBox.AutoSize = true;
            this.toDateChkBox.Location = new System.Drawing.Point(8, 67);
            this.toDateChkBox.Name = "toDateChkBox";
            this.toDateChkBox.Size = new System.Drawing.Size(65, 17);
            this.toDateChkBox.TabIndex = 2;
            this.toDateChkBox.Text = "To Date";
            this.toDateChkBox.UseVisualStyleBackColor = true;
            this.toDateChkBox.CheckedChanged += new System.EventHandler(this.toDateChkBox_CheckedChanged);
            // 
            // toAmountTxtBox
            // 
            this.toAmountTxtBox.Enabled = false;
            this.toAmountTxtBox.Location = new System.Drawing.Point(297, 102);
            this.toAmountTxtBox.Name = "toAmountTxtBox";
            this.toAmountTxtBox.Size = new System.Drawing.Size(100, 20);
            this.toAmountTxtBox.TabIndex = 11;
            // 
            // fromAmountTxtBox
            // 
            this.fromAmountTxtBox.Location = new System.Drawing.Point(297, 68);
            this.fromAmountTxtBox.Name = "fromAmountTxtBox";
            this.fromAmountTxtBox.Size = new System.Drawing.Size(100, 20);
            this.fromAmountTxtBox.TabIndex = 9;
            // 
            // fromAmountLabel
            // 
            this.fromAmountLabel.AutoSize = true;
            this.fromAmountLabel.Location = new System.Drawing.Point(222, 71);
            this.fromAmountLabel.Name = "fromAmountLabel";
            this.fromAmountLabel.Size = new System.Drawing.Size(43, 13);
            this.fromAmountLabel.TabIndex = 8;
            this.fromAmountLabel.Text = "Amount";
            // 
            // categoryCombo
            // 
            this.categoryCombo.AllowDrop = true;
            this.categoryCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.categoryCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoryCombo.Location = new System.Drawing.Point(297, 29);
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(121, 21);
            this.categoryCombo.Sorted = true;
            this.categoryCombo.TabIndex = 7;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(224, 32);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "Category";
            // 
            // itemTxtBox
            // 
            this.itemTxtBox.Location = new System.Drawing.Point(80, 102);
            this.itemTxtBox.Name = "itemTxtBox";
            this.itemTxtBox.Size = new System.Drawing.Size(100, 20);
            this.itemTxtBox.TabIndex = 5;
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(29, 105);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(27, 13);
            this.itemLabel.TabIndex = 4;
            this.itemLabel.Text = "Item";
            // 
            // toDatePicker
            // 
            this.toDatePicker.Enabled = false;
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(81, 64);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(99, 20);
            this.toDatePicker.TabIndex = 3;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(81, 26);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(99, 20);
            this.fromDatePicker.TabIndex = 1;
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Location = new System.Drawing.Point(29, 28);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(30, 13);
            this.fromDateLabel.TabIndex = 0;
            this.fromDateLabel.Text = "Date";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(531, 254);
            this.dataGridView1.TabIndex = 1;
            // 
            // ViewExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 426);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.filterGroup);
            this.Name = "ViewExpensesForm";
            this.Text = "ViewExpensesForm";
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.Label fromDateLabel;
        private System.Windows.Forms.TextBox itemTxtBox;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.TextBox toAmountTxtBox;
        private System.Windows.Forms.TextBox fromAmountTxtBox;
        private System.Windows.Forms.Label fromAmountLabel;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.CheckBox toAmountChkBox;
        private System.Windows.Forms.CheckBox toDateChkBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button searchBtn;
    }
}