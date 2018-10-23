namespace MEL_r811_18
{
    partial class WorkRequestEntry
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
            this.machine_comboBox = new System.Windows.Forms.ComboBox();
            this.requestDate_datePicker = new System.Windows.Forms.DateTimePicker();
            this.requestType_comboBox = new System.Windows.Forms.ComboBox();
            this.requestPriority_comboBox = new System.Windows.Forms.ComboBox();
            this.workRequested_textBox = new System.Windows.Forms.TextBox();
            this.requestConvertedradioButton = new System.Windows.Forms.RadioButton();
            this.saveUpdate_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.department_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mELDataSet = new MEL_r811_18.MELDataSet();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.DepartmentTableAdapter();
            this.machinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.machinesTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.MachinesTableAdapter();
            this.mELDataSet1 = new MEL_r811_18.MELDataSet();
            this.typeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.typeTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.TypeTableAdapter();
            this.priorityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.priorityTableAdapter = new MEL_r811_18.MELDataSetTableAdapters.PriorityTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priorityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // machine_comboBox
            // 
            this.machine_comboBox.DataSource = this.machinesBindingSource;
            this.machine_comboBox.DisplayMember = "BTNumber";
            this.machine_comboBox.FormattingEnabled = true;
            this.machine_comboBox.Location = new System.Drawing.Point(295, 25);
            this.machine_comboBox.Name = "machine_comboBox";
            this.machine_comboBox.Size = new System.Drawing.Size(82, 21);
            this.machine_comboBox.TabIndex = 0;
            this.machine_comboBox.ValueMember = "MachineID";
            // 
            // requestDate_datePicker
            // 
            this.requestDate_datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.requestDate_datePicker.Location = new System.Drawing.Point(45, 26);
            this.requestDate_datePicker.Name = "requestDate_datePicker";
            this.requestDate_datePicker.Size = new System.Drawing.Size(99, 20);
            this.requestDate_datePicker.TabIndex = 1;
            // 
            // requestType_comboBox
            // 
            this.requestType_comboBox.DataSource = this.typeBindingSource;
            this.requestType_comboBox.DisplayMember = "Type";
            this.requestType_comboBox.FormattingEnabled = true;
            this.requestType_comboBox.Location = new System.Drawing.Point(402, 25);
            this.requestType_comboBox.Name = "requestType_comboBox";
            this.requestType_comboBox.Size = new System.Drawing.Size(161, 21);
            this.requestType_comboBox.TabIndex = 2;
            this.requestType_comboBox.ValueMember = "TypeID";
            // 
            // requestPriority_comboBox
            // 
            this.requestPriority_comboBox.DataSource = this.priorityBindingSource;
            this.requestPriority_comboBox.DisplayMember = "Priority";
            this.requestPriority_comboBox.FormattingEnabled = true;
            this.requestPriority_comboBox.Location = new System.Drawing.Point(583, 25);
            this.requestPriority_comboBox.Name = "requestPriority_comboBox";
            this.requestPriority_comboBox.Size = new System.Drawing.Size(215, 21);
            this.requestPriority_comboBox.TabIndex = 3;
            this.requestPriority_comboBox.ValueMember = "PriorityID";
            // 
            // workRequested_textBox
            // 
            this.workRequested_textBox.Location = new System.Drawing.Point(55, 71);
            this.workRequested_textBox.Multiline = true;
            this.workRequested_textBox.Name = "workRequested_textBox";
            this.workRequested_textBox.Size = new System.Drawing.Size(566, 107);
            this.workRequested_textBox.TabIndex = 4;
            // 
            // requestConvertedradioButton
            // 
            this.requestConvertedradioButton.AutoSize = true;
            this.requestConvertedradioButton.Location = new System.Drawing.Point(665, 81);
            this.requestConvertedradioButton.Name = "requestConvertedradioButton";
            this.requestConvertedradioButton.Size = new System.Drawing.Size(94, 17);
            this.requestConvertedradioButton.TabIndex = 5;
            this.requestConvertedradioButton.TabStop = true;
            this.requestConvertedradioButton.Text = "Work Request";
            this.requestConvertedradioButton.UseVisualStyleBackColor = true;
            // 
            // saveUpdate_button
            // 
            this.saveUpdate_button.Location = new System.Drawing.Point(665, 137);
            this.saveUpdate_button.Name = "saveUpdate_button";
            this.saveUpdate_button.Size = new System.Drawing.Size(97, 23);
            this.saveUpdate_button.TabIndex = 6;
            this.saveUpdate_button.Text = "Save Changes";
            this.saveUpdate_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Machine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date Work Requested";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Request Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Priority";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Describe work to be performed.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(632, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tick to convert to work order.";
            // 
            // department_comboBox
            // 
            this.department_comboBox.DataSource = this.departmentBindingSource;
            this.department_comboBox.DisplayMember = "DepartmentName";
            this.department_comboBox.FormattingEnabled = true;
            this.department_comboBox.Location = new System.Drawing.Point(170, 26);
            this.department_comboBox.Name = "department_comboBox";
            this.department_comboBox.Size = new System.Drawing.Size(105, 21);
            this.department_comboBox.TabIndex = 13;
            this.department_comboBox.ValueMember = "DepartmentID";
            this.department_comboBox.SelectedIndexChanged += new System.EventHandler(this.Department_combo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Department";
            // 
            // mELDataSet
            // 
            this.mELDataSet.DataSetName = "MELDataSet";
            this.mELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.mELDataSet;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // machinesBindingSource
            // 
            this.machinesBindingSource.DataMember = "Machines";
            this.machinesBindingSource.DataSource = this.mELDataSet;
            // 
            // machinesTableAdapter
            // 
            this.machinesTableAdapter.ClearBeforeFill = true;
            // 
            // mELDataSet1
            // 
            this.mELDataSet1.DataSetName = "MELDataSet";
            this.mELDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // typeBindingSource
            // 
            this.typeBindingSource.DataMember = "Type";
            this.typeBindingSource.DataSource = this.mELDataSet1;
            // 
            // typeTableAdapter
            // 
            this.typeTableAdapter.ClearBeforeFill = true;
            // 
            // priorityBindingSource
            // 
            this.priorityBindingSource.DataMember = "Priority";
            this.priorityBindingSource.DataSource = this.mELDataSet1;
            // 
            // priorityTableAdapter
            // 
            this.priorityTableAdapter.ClearBeforeFill = true;
            // 
            // WorkRequestEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 197);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.department_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveUpdate_button);
            this.Controls.Add(this.requestConvertedradioButton);
            this.Controls.Add(this.workRequested_textBox);
            this.Controls.Add(this.requestPriority_comboBox);
            this.Controls.Add(this.requestType_comboBox);
            this.Controls.Add(this.requestDate_datePicker);
            this.Controls.Add(this.machine_comboBox);
            this.Name = "WorkRequestEntry";
            this.Text = "WorkRequestEntry";
            this.Load += new System.EventHandler(this.WorkRequestEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priorityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox machine_comboBox;
        private System.Windows.Forms.DateTimePicker requestDate_datePicker;
        private System.Windows.Forms.ComboBox requestType_comboBox;
        private System.Windows.Forms.ComboBox requestPriority_comboBox;
        private System.Windows.Forms.TextBox workRequested_textBox;
        private System.Windows.Forms.RadioButton requestConvertedradioButton;
        private System.Windows.Forms.Button saveUpdate_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox department_comboBox;
        private System.Windows.Forms.Label label7;
        private MELDataSet mELDataSet;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private MELDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.BindingSource machinesBindingSource;
        private MELDataSetTableAdapters.MachinesTableAdapter machinesTableAdapter;
        private MELDataSet mELDataSet1;
        private System.Windows.Forms.BindingSource typeBindingSource;
        private MELDataSetTableAdapters.TypeTableAdapter typeTableAdapter;
        private System.Windows.Forms.BindingSource priorityBindingSource;
        private MELDataSetTableAdapters.PriorityTableAdapter priorityTableAdapter;
    }
}