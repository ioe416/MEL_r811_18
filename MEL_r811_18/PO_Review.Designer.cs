﻿namespace MEL_r811_18
{
    partial class PO_Review
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.department_textBox = new System.Windows.Forms.TextBox();
            this.issueDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.machine_textBox = new System.Windows.Forms.TextBox();
            this.poNumber_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deliverTo_textBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.vendor_textBox = new System.Windows.Forms.ComboBox();
            this.mELDataSet = new MEL_r811_18.MELDataSet();
            this.vendorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendorsTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.VendorsTableAdapter();
            this.tech_textBox = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.EmployeeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Ordered:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Machine:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "PO Number:";
            // 
            // department_textBox
            // 
            this.department_textBox.Location = new System.Drawing.Point(291, 27);
            this.department_textBox.Name = "department_textBox";
            this.department_textBox.Size = new System.Drawing.Size(100, 20);
            this.department_textBox.TabIndex = 4;
            // 
            // issueDate_dateTimePicker
            // 
            this.issueDate_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.issueDate_dateTimePicker.Location = new System.Drawing.Point(115, 27);
            this.issueDate_dateTimePicker.Name = "issueDate_dateTimePicker";
            this.issueDate_dateTimePicker.Size = new System.Drawing.Size(87, 20);
            this.issueDate_dateTimePicker.TabIndex = 5;
            // 
            // machine_textBox
            // 
            this.machine_textBox.Location = new System.Drawing.Point(466, 27);
            this.machine_textBox.Name = "machine_textBox";
            this.machine_textBox.Size = new System.Drawing.Size(100, 20);
            this.machine_textBox.TabIndex = 6;
            // 
            // poNumber_textBox
            // 
            this.poNumber_textBox.Location = new System.Drawing.Point(655, 27);
            this.poNumber_textBox.Name = "poNumber_textBox";
            this.poNumber_textBox.Size = new System.Drawing.Size(100, 20);
            this.poNumber_textBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ordered BY:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Order From:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(455, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Deliver To:";
            // 
            // deliverTo_textBox
            // 
            this.deliverTo_textBox.Location = new System.Drawing.Point(524, 72);
            this.deliverTo_textBox.Name = "deliverTo_textBox";
            this.deliverTo_textBox.Size = new System.Drawing.Size(100, 20);
            this.deliverTo_textBox.TabIndex = 13;
            this.deliverTo_textBox.Text = "Maint";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(752, 177);
            this.dataGridView1.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton1.Text = "Cancel";
            this.toolStripButton1.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton2.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton2.Text = "Update";
            this.toolStripButton2.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // vendor_textBox
            // 
            this.vendor_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.vendorsBindingSource, "VendorName", true));
            this.vendor_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.vendorsBindingSource, "VendorID", true));
            this.vendor_textBox.DataSource = this.vendorsBindingSource;
            this.vendor_textBox.DisplayMember = "VendorName";
            this.vendor_textBox.FormattingEnabled = true;
            this.vendor_textBox.Location = new System.Drawing.Point(291, 73);
            this.vendor_textBox.Name = "vendor_textBox";
            this.vendor_textBox.Size = new System.Drawing.Size(149, 21);
            this.vendor_textBox.TabIndex = 20;
            this.vendor_textBox.ValueMember = "VendorID";
            // 
            // mELDataSet
            // 
            this.mELDataSet.DataSetName = "MELDataSet";
            this.mELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendorsBindingSource
            // 
            this.vendorsBindingSource.DataMember = "Vendors";
            this.vendorsBindingSource.DataSource = this.mELDataSet;
            // 
            // vendorsTableAdapter
            // 
            this.vendorsTableAdapter.ClearBeforeFill = true;
            // 
            // tech_textBox
            // 
            this.tech_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.employeeBindingSource, "Tech", true));
            this.tech_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.employeeBindingSource, "EmployeeID", true));
            this.tech_textBox.DataSource = this.employeeBindingSource;
            this.tech_textBox.DisplayMember = "Tech";
            this.tech_textBox.FormattingEnabled = true;
            this.tech_textBox.Location = new System.Drawing.Point(97, 73);
            this.tech_textBox.Name = "tech_textBox";
            this.tech_textBox.Size = new System.Drawing.Size(113, 21);
            this.tech_textBox.TabIndex = 21;
            this.tech_textBox.ValueMember = "EmployeeID";
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.mELDataSet;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // PO_Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(800, 349);
            this.ControlBox = false;
            this.Controls.Add(this.tech_textBox);
            this.Controls.Add(this.vendor_textBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deliverTo_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.poNumber_textBox);
            this.Controls.Add(this.machine_textBox);
            this.Controls.Add(this.issueDate_dateTimePicker);
            this.Controls.Add(this.department_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PO_Review";
            this.Text = "PO";
            this.Load += new System.EventHandler(this.PO_Review_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox department_textBox;
        private System.Windows.Forms.DateTimePicker issueDate_dateTimePicker;
        private System.Windows.Forms.TextBox machine_textBox;
        private System.Windows.Forms.TextBox poNumber_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox deliverTo_textBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ComboBox vendor_textBox;
        private MELDataSet mELDataSet;
        private System.Windows.Forms.BindingSource vendorsBindingSource;
        private MELDataSetTableAdapters.VendorsTableAdapter vendorsTableAdapter;
        private System.Windows.Forms.ComboBox tech_textBox;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private MELDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
    }
}