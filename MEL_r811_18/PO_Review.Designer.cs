namespace MEL_r811_18
{
    partial class PR_Review
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PR_Review));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.issueDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.poNumber_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deliverTo_textBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cancel_btn = new System.Windows.Forms.ToolStripButton();
            this.delete_btn = new System.Windows.Forms.ToolStripButton();
            this.update_btn = new System.Windows.Forms.ToolStripButton();
            this.print_btn = new System.Windows.Forms.ToolStripButton();
            this.vendor_textBox = new System.Windows.Forms.ComboBox();
            this.vendorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mELDataSet = new MEL_r811_18.MELDataSet();
            this.vendorsTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.VendorsTableAdapter();
            this.tech_textBox = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.EmployeeTableAdapter();
            this.department_textBox = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.machine_textBox = new System.Windows.Forms.ComboBox();
            this.machinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.DepartmentTableAdapter();
            this.machinesTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.MachinesTableAdapter();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pR_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pR_DetailsTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.PR_DetailsTableAdapter();
            this.tableAdapterManager = new MEL_r811_18.MELDataSetTableAdapters.TableAdapterManager();
            this.poDetails_datagridview = new System.Windows.Forms.DataGridView();
            this.orderID_txb = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pR_DetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poDetails_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Ordered:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Machine:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "PO Number:";
            // 
            // issueDate_dateTimePicker
            // 
            this.issueDate_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.issueDate_dateTimePicker.Location = new System.Drawing.Point(88, 27);
            this.issueDate_dateTimePicker.Name = "issueDate_dateTimePicker";
            this.issueDate_dateTimePicker.Size = new System.Drawing.Size(87, 20);
            this.issueDate_dateTimePicker.TabIndex = 5;
            // 
            // poNumber_textBox
            // 
            this.poNumber_textBox.Location = new System.Drawing.Point(591, 27);
            this.poNumber_textBox.Name = "poNumber_textBox";
            this.poNumber_textBox.Size = new System.Drawing.Size(100, 20);
            this.poNumber_textBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ordered BY:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Order From:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Deliver To:";
            // 
            // deliverTo_textBox
            // 
            this.deliverTo_textBox.Location = new System.Drawing.Point(501, 72);
            this.deliverTo_textBox.Name = "deliverTo_textBox";
            this.deliverTo_textBox.Size = new System.Drawing.Size(100, 20);
            this.deliverTo_textBox.TabIndex = 13;
            this.deliverTo_textBox.Text = "Maint";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancel_btn,
            this.delete_btn,
            this.update_btn,
            this.print_btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(811, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cancel_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cancel_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(47, 22);
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.delete_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.delete_btn.Image = ((System.Drawing.Image)(resources.GetObject("delete_btn.Image")));
            this.delete_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(44, 22);
            this.delete_btn.Text = "Delete";
            this.delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.update_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.update_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.update_btn.Name = "update_btn";
            this.update_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.update_btn.Size = new System.Drawing.Size(49, 22);
            this.update_btn.Text = "Update";
            this.update_btn.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // print_btn
            // 
            this.print_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.print_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.print_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.Image")));
            this.print_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(36, 22);
            this.print_btn.Text = "Print";
            this.print_btn.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // vendor_textBox
            // 
            this.vendor_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.vendorsBindingSource, "VendorName", true));
            this.vendor_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.vendorsBindingSource, "VendorID", true));
            this.vendor_textBox.DataSource = this.vendorsBindingSource;
            this.vendor_textBox.DisplayMember = "VendorName";
            this.vendor_textBox.FormattingEnabled = true;
            this.vendor_textBox.Location = new System.Drawing.Point(268, 73);
            this.vendor_textBox.Name = "vendor_textBox";
            this.vendor_textBox.Size = new System.Drawing.Size(149, 21);
            this.vendor_textBox.TabIndex = 20;
            this.vendor_textBox.ValueMember = "VendorID";
            // 
            // vendorsBindingSource
            // 
            this.vendorsBindingSource.DataMember = "Vendors";
            this.vendorsBindingSource.DataSource = this.mELDataSet;
            // 
            // mELDataSet
            // 
            this.mELDataSet.DataSetName = "MELDataSet";
            this.mELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendorsTableAdapter
            // 
            this.vendorsTableAdapter.ClearBeforeFill = true;
            // 
            // tech_textBox
            // 
            this.tech_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.employeeBindingSource, "EmployeeID", true));
            this.tech_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.employeeBindingSource, "Tech", true));
            this.tech_textBox.DataSource = this.employeeBindingSource;
            this.tech_textBox.DisplayMember = "Tech";
            this.tech_textBox.FormattingEnabled = true;
            this.tech_textBox.Location = new System.Drawing.Point(74, 73);
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
            // department_textBox
            // 
            this.department_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.departmentBindingSource, "DepartmentName", true));
            this.department_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.departmentBindingSource, "DepartmentID", true));
            this.department_textBox.DataSource = this.departmentBindingSource;
            this.department_textBox.DisplayMember = "DepartmentName";
            this.department_textBox.FormattingEnabled = true;
            this.department_textBox.Location = new System.Drawing.Point(252, 28);
            this.department_textBox.Name = "department_textBox";
            this.department_textBox.Size = new System.Drawing.Size(100, 21);
            this.department_textBox.TabIndex = 22;
            this.department_textBox.ValueMember = "DepartmentID";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.mELDataSet;
            // 
            // machine_textBox
            // 
            this.machine_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.machinesBindingSource, "BTNumber", true));
            this.machine_textBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.machinesBindingSource, "MachineID", true));
            this.machine_textBox.DataSource = this.machinesBindingSource;
            this.machine_textBox.DisplayMember = "BTNumber";
            this.machine_textBox.FormattingEnabled = true;
            this.machine_textBox.Location = new System.Drawing.Point(417, 27);
            this.machine_textBox.Name = "machine_textBox";
            this.machine_textBox.Size = new System.Drawing.Size(100, 21);
            this.machine_textBox.TabIndex = 23;
            this.machine_textBox.ValueMember = "MachineID";
            // 
            // machinesBindingSource
            // 
            this.machinesBindingSource.DataMember = "Machines";
            this.machinesBindingSource.DataSource = this.mELDataSet;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // machinesTableAdapter
            // 
            this.machinesTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/mm/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(668, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(613, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Date Due:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(766, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(615, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Tick Checkbox to update Due Date";
            // 
            // pR_DetailsBindingSource
            // 
            this.pR_DetailsBindingSource.DataMember = "PR_Details";
            this.pR_DetailsBindingSource.DataSource = this.mELDataSet;
            // 
            // pR_DetailsTableAdapter
            // 
            this.pR_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DepartmentTableAdapter = this.departmentTableAdapter;
            this.tableAdapterManager.EmployeeTableAdapter = this.employeeTableAdapter;
            this.tableAdapterManager.MachinesTableAdapter = this.machinesTableAdapter;
            this.tableAdapterManager.PartsTableAdapter = null;
            this.tableAdapterManager.PR_DetailsTableAdapter = this.pR_DetailsTableAdapter;
            this.tableAdapterManager.PriorityTableAdapter = null;
            this.tableAdapterManager.PRTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.TypeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = MEL_r811_18.MELDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VendorsTableAdapter = this.vendorsTableAdapter;
            this.tableAdapterManager.WorkOrderTableAdapter = null;
            this.tableAdapterManager.WorkRequestTableAdapter = null;
            // 
            // poDetails_datagridview
            // 
            this.poDetails_datagridview.AllowUserToAddRows = false;
            this.poDetails_datagridview.AllowUserToDeleteRows = false;
            this.poDetails_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.poDetails_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.poDetails_datagridview.Location = new System.Drawing.Point(33, 116);
            this.poDetails_datagridview.Name = "poDetails_datagridview";
            this.poDetails_datagridview.RowHeadersVisible = false;
            this.poDetails_datagridview.Size = new System.Drawing.Size(748, 222);
            this.poDetails_datagridview.TabIndex = 28;
            this.poDetails_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // orderID_txb
            // 
            this.orderID_txb.Enabled = false;
            this.orderID_txb.Location = new System.Drawing.Point(730, 27);
            this.orderID_txb.Name = "orderID_txb";
            this.orderID_txb.Size = new System.Drawing.Size(69, 20);
            this.orderID_txb.TabIndex = 29;
            // 
            // PR_Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(811, 351);
            this.ControlBox = false;
            this.Controls.Add(this.orderID_txb);
            this.Controls.Add(this.poDetails_datagridview);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.machine_textBox);
            this.Controls.Add(this.department_textBox);
            this.Controls.Add(this.tech_textBox);
            this.Controls.Add(this.vendor_textBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.deliverTo_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.poNumber_textBox);
            this.Controls.Add(this.issueDate_dateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PR_Review";
            this.Text = "PO";
            this.Load += new System.EventHandler(this.PO_Review_load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pR_DetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poDetails_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker issueDate_dateTimePicker;
        private System.Windows.Forms.TextBox poNumber_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox deliverTo_textBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cancel_btn;
        private System.Windows.Forms.ToolStripButton update_btn;
        private System.Windows.Forms.ComboBox vendor_textBox;
        private MELDataSet mELDataSet;
        private System.Windows.Forms.BindingSource vendorsBindingSource;
        private MELDataSetTableAdapters.VendorsTableAdapter vendorsTableAdapter;
        private System.Windows.Forms.ComboBox tech_textBox;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private MELDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.ComboBox department_textBox;
        private System.Windows.Forms.ComboBox machine_textBox;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private MELDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.BindingSource machinesBindingSource;
        private MELDataSetTableAdapters.MachinesTableAdapter machinesTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource pR_DetailsBindingSource;
        private MELDataSetTableAdapters.PR_DetailsTableAdapter pR_DetailsTableAdapter;
        private MELDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView poDetails_datagridview;
        private System.Windows.Forms.ToolStripButton print_btn;
        private System.Windows.Forms.ToolStripButton delete_btn;
        private System.Windows.Forms.TextBox orderID_txb;
    }
}