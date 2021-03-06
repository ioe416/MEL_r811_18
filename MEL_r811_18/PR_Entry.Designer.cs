﻿namespace MEL_r811_18
{
    partial class PR_Entry
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
            this.dateIssued_lbl = new System.Windows.Forms.Label();
            this.orderedBy_lbl = new System.Windows.Forms.Label();
            this.dep_lbl = new System.Windows.Forms.Label();
            this.mach_lbl = new System.Windows.Forms.Label();
            this.dateIsued_dtp = new System.Windows.Forms.DateTimePicker();
            this.employee_combo = new System.Windows.Forms.ComboBox();
            this.mELDataSet = new MEL_r811_18.MELDataSet();
            this.dep_combo = new System.Windows.Forms.ComboBox();
            this.mach_combo = new System.Windows.Forms.ComboBox();
            this.vend_combo = new System.Windows.Forms.ComboBox();
            this.deliverTo_txb = new System.Windows.Forms.TextBox();
            this.vend_lbl = new System.Windows.Forms.Label();
            this.deliverTo_lbl = new System.Windows.Forms.Label();
            this.qty_txb = new System.Windows.Forms.TextBox();
            this.unit_combo = new System.Windows.Forms.ComboBox();
            this.part_combo = new System.Windows.Forms.ComboBox();
            this.desc_txb = new System.Windows.Forms.TextBox();
            this.price_txb = new System.Windows.Forms.TextBox();
            this.per_combo = new System.Windows.Forms.ComboBox();
            this.total_txb = new System.Windows.Forms.TextBox();
            this.ordTot_txb = new System.Windows.Forms.TextBox();
            this.addToOrder_btn = new System.Windows.Forms.Button();
            this.qty_lbl = new System.Windows.Forms.Label();
            this.partNo_lbl = new System.Windows.Forms.Label();
            this.unit_lbl = new System.Windows.Forms.Label();
            this.unitPrice_lbl = new System.Windows.Forms.Label();
            this.partDesc_lbl = new System.Windows.Forms.Label();
            this.ordTot_lbl = new System.Windows.Forms.Label();
            this.total_lbl = new System.Windows.Forms.Label();
            this.per_lbl = new System.Windows.Forms.Label();
            this.newOrderDetails_dataGridView = new System.Windows.Forms.DataGridView();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.received = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save_btn = new System.Windows.Forms.Button();
            this.cncl_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newOrderDetails_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateIssued_lbl
            // 
            this.dateIssued_lbl.AutoSize = true;
            this.dateIssued_lbl.Location = new System.Drawing.Point(12, 19);
            this.dateIssued_lbl.Name = "dateIssued_lbl";
            this.dateIssued_lbl.Size = new System.Drawing.Size(67, 13);
            this.dateIssued_lbl.TabIndex = 0;
            this.dateIssued_lbl.Text = "Date Issued:";
            // 
            // orderedBy_lbl
            // 
            this.orderedBy_lbl.AutoSize = true;
            this.orderedBy_lbl.Location = new System.Drawing.Point(12, 65);
            this.orderedBy_lbl.Name = "orderedBy_lbl";
            this.orderedBy_lbl.Size = new System.Drawing.Size(63, 13);
            this.orderedBy_lbl.TabIndex = 1;
            this.orderedBy_lbl.Text = "Ordered By:";
            // 
            // dep_lbl
            // 
            this.dep_lbl.AutoSize = true;
            this.dep_lbl.Location = new System.Drawing.Point(194, 19);
            this.dep_lbl.Name = "dep_lbl";
            this.dep_lbl.Size = new System.Drawing.Size(33, 13);
            this.dep_lbl.TabIndex = 2;
            this.dep_lbl.Text = "Dept:";
            // 
            // mach_lbl
            // 
            this.mach_lbl.AutoSize = true;
            this.mach_lbl.Location = new System.Drawing.Point(376, 19);
            this.mach_lbl.Name = "mach_lbl";
            this.mach_lbl.Size = new System.Drawing.Size(51, 13);
            this.mach_lbl.TabIndex = 3;
            this.mach_lbl.Text = "Machine:";
            // 
            // dateIsued_dtp
            // 
            this.dateIsued_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateIsued_dtp.Location = new System.Drawing.Point(27, 35);
            this.dateIsued_dtp.Name = "dateIsued_dtp";
            this.dateIsued_dtp.Size = new System.Drawing.Size(127, 20);
            this.dateIsued_dtp.TabIndex = 4;
            this.dateIsued_dtp.Value = new System.DateTime(2018, 10, 3, 13, 2, 40, 0);
            // 
            // employee_combo
            // 
            this.employee_combo.DisplayMember = "EmployeeID";
            this.employee_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employee_combo.FormattingEnabled = true;
            this.employee_combo.Location = new System.Drawing.Point(27, 81);
            this.employee_combo.Name = "employee_combo";
            this.employee_combo.Size = new System.Drawing.Size(127, 21);
            this.employee_combo.TabIndex = 5;
            this.employee_combo.ValueMember = "EmployeeID";
            // 
            // mELDataSet
            // 
            this.mELDataSet.DataSetName = "MELDataSet";
            this.mELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dep_combo
            // 
            this.dep_combo.DisplayMember = "DepartmentID";
            this.dep_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dep_combo.FormattingEnabled = true;
            this.dep_combo.Location = new System.Drawing.Point(212, 35);
            this.dep_combo.Name = "dep_combo";
            this.dep_combo.Size = new System.Drawing.Size(121, 21);
            this.dep_combo.TabIndex = 6;
            this.dep_combo.ValueMember = "DepartmentID";
            this.dep_combo.SelectedIndexChanged += new System.EventHandler(this.Dep_combo_SelectedIndexChanged);
            // 
            // mach_combo
            // 
            this.mach_combo.DisplayMember = "MachineID";
            this.mach_combo.FormattingEnabled = true;
            this.mach_combo.Location = new System.Drawing.Point(395, 34);
            this.mach_combo.Name = "mach_combo";
            this.mach_combo.Size = new System.Drawing.Size(121, 21);
            this.mach_combo.TabIndex = 7;
            this.mach_combo.ValueMember = "MachineID";
            // 
            // vend_combo
            // 
            this.vend_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.vend_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vend_combo.DisplayMember = "VendorID";
            this.vend_combo.DropDownWidth = 300;
            this.vend_combo.FormattingEnabled = true;
            this.vend_combo.Location = new System.Drawing.Point(212, 84);
            this.vend_combo.Name = "vend_combo";
            this.vend_combo.Size = new System.Drawing.Size(121, 21);
            this.vend_combo.TabIndex = 8;
            this.vend_combo.ValueMember = "VendorID";
            this.vend_combo.Leave += new System.EventHandler(this.Vend_combo_SelectedIndexChanged);
            // 
            // deliverTo_txb
            // 
            this.deliverTo_txb.Location = new System.Drawing.Point(395, 85);
            this.deliverTo_txb.Name = "deliverTo_txb";
            this.deliverTo_txb.Size = new System.Drawing.Size(78, 20);
            this.deliverTo_txb.TabIndex = 9;
            this.deliverTo_txb.Text = "Maint";
            // 
            // vend_lbl
            // 
            this.vend_lbl.AutoSize = true;
            this.vend_lbl.Location = new System.Drawing.Point(194, 65);
            this.vend_lbl.Name = "vend_lbl";
            this.vend_lbl.Size = new System.Drawing.Size(81, 13);
            this.vend_lbl.TabIndex = 10;
            this.vend_lbl.Text = "Purchase From:";
            // 
            // deliverTo_lbl
            // 
            this.deliverTo_lbl.AutoSize = true;
            this.deliverTo_lbl.Location = new System.Drawing.Point(376, 65);
            this.deliverTo_lbl.Name = "deliverTo_lbl";
            this.deliverTo_lbl.Size = new System.Drawing.Size(59, 13);
            this.deliverTo_lbl.TabIndex = 11;
            this.deliverTo_lbl.Text = "Deliver To:";
            // 
            // qty_txb
            // 
            this.qty_txb.Location = new System.Drawing.Point(15, 153);
            this.qty_txb.Name = "qty_txb";
            this.qty_txb.Size = new System.Drawing.Size(71, 20);
            this.qty_txb.TabIndex = 12;
            // 
            // unit_combo
            // 
            this.unit_combo.FormattingEnabled = true;
            this.unit_combo.Items.AddRange(new object[] {
            "Piece",
            "Box",
            "Roll",
            "Pkg",
            "Foot",
            "Lb",
            "Bucket",
            "Pail"});
            this.unit_combo.Location = new System.Drawing.Point(90, 153);
            this.unit_combo.Name = "unit_combo";
            this.unit_combo.Size = new System.Drawing.Size(60, 21);
            this.unit_combo.TabIndex = 13;
            // 
            // part_combo
            // 
            this.part_combo.DisplayMember = "PartID";
            this.part_combo.FormattingEnabled = true;
            this.part_combo.Location = new System.Drawing.Point(154, 153);
            this.part_combo.Name = "part_combo";
            this.part_combo.Size = new System.Drawing.Size(96, 21);
            this.part_combo.TabIndex = 14;
            this.part_combo.ValueMember = "PartID";
            this.part_combo.SelectedIndexChanged += new System.EventHandler(this.Part_combo_SelectedIndexChanged);
            // 
            // desc_txb
            // 
            this.desc_txb.Location = new System.Drawing.Point(254, 153);
            this.desc_txb.Name = "desc_txb";
            this.desc_txb.Size = new System.Drawing.Size(263, 20);
            this.desc_txb.TabIndex = 15;
            // 
            // price_txb
            // 
            this.price_txb.Location = new System.Drawing.Point(521, 153);
            this.price_txb.Name = "price_txb";
            this.price_txb.Size = new System.Drawing.Size(80, 20);
            this.price_txb.TabIndex = 16;
            // 
            // per_combo
            // 
            this.per_combo.FormattingEnabled = true;
            this.per_combo.Items.AddRange(new object[] {
            "ea",
            "pc",
            "ft",
            "lb",
            "pkg"});
            this.per_combo.Location = new System.Drawing.Point(605, 153);
            this.per_combo.Name = "per_combo";
            this.per_combo.Size = new System.Drawing.Size(69, 21);
            this.per_combo.TabIndex = 17;
            // 
            // total_txb
            // 
            this.total_txb.Location = new System.Drawing.Point(678, 153);
            this.total_txb.Name = "total_txb";
            this.total_txb.Size = new System.Drawing.Size(65, 20);
            this.total_txb.TabIndex = 18;
            // 
            // ordTot_txb
            // 
            this.ordTot_txb.Location = new System.Drawing.Point(705, 418);
            this.ordTot_txb.Name = "ordTot_txb";
            this.ordTot_txb.Size = new System.Drawing.Size(83, 20);
            this.ordTot_txb.TabIndex = 19;
            // 
            // addToOrder_btn
            // 
            this.addToOrder_btn.Location = new System.Drawing.Point(749, 153);
            this.addToOrder_btn.Name = "addToOrder_btn";
            this.addToOrder_btn.Size = new System.Drawing.Size(45, 20);
            this.addToOrder_btn.TabIndex = 20;
            this.addToOrder_btn.Text = "ADD";
            this.addToOrder_btn.UseVisualStyleBackColor = true;
            this.addToOrder_btn.Click += new System.EventHandler(this.AddToOrder_btn_Click);
            // 
            // qty_lbl
            // 
            this.qty_lbl.AutoSize = true;
            this.qty_lbl.Location = new System.Drawing.Point(15, 137);
            this.qty_lbl.Name = "qty_lbl";
            this.qty_lbl.Size = new System.Drawing.Size(46, 13);
            this.qty_lbl.TabIndex = 21;
            this.qty_lbl.Text = "Quantity";
            // 
            // partNo_lbl
            // 
            this.partNo_lbl.AutoSize = true;
            this.partNo_lbl.Location = new System.Drawing.Point(154, 137);
            this.partNo_lbl.Name = "partNo_lbl";
            this.partNo_lbl.Size = new System.Drawing.Size(70, 13);
            this.partNo_lbl.TabIndex = 22;
            this.partNo_lbl.Text = "Part/Cat. No.";
            // 
            // unit_lbl
            // 
            this.unit_lbl.AutoSize = true;
            this.unit_lbl.Location = new System.Drawing.Point(90, 137);
            this.unit_lbl.Name = "unit_lbl";
            this.unit_lbl.Size = new System.Drawing.Size(26, 13);
            this.unit_lbl.TabIndex = 23;
            this.unit_lbl.Text = "Unit";
            // 
            // unitPrice_lbl
            // 
            this.unitPrice_lbl.AutoSize = true;
            this.unitPrice_lbl.Location = new System.Drawing.Point(521, 137);
            this.unitPrice_lbl.Name = "unitPrice_lbl";
            this.unitPrice_lbl.Size = new System.Drawing.Size(31, 13);
            this.unitPrice_lbl.TabIndex = 24;
            this.unitPrice_lbl.Text = "Price";
            // 
            // partDesc_lbl
            // 
            this.partDesc_lbl.AutoSize = true;
            this.partDesc_lbl.Location = new System.Drawing.Point(254, 137);
            this.partDesc_lbl.Name = "partDesc_lbl";
            this.partDesc_lbl.Size = new System.Drawing.Size(60, 13);
            this.partDesc_lbl.TabIndex = 25;
            this.partDesc_lbl.Text = "Description";
            // 
            // ordTot_lbl
            // 
            this.ordTot_lbl.AutoSize = true;
            this.ordTot_lbl.Location = new System.Drawing.Point(615, 421);
            this.ordTot_lbl.Name = "ordTot_lbl";
            this.ordTot_lbl.Size = new System.Drawing.Size(84, 13);
            this.ordTot_lbl.TabIndex = 26;
            this.ordTot_lbl.Text = "ORDER TOTAL";
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.Location = new System.Drawing.Point(678, 138);
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(42, 13);
            this.total_lbl.TabIndex = 27;
            this.total_lbl.Text = "TOTAL";
            // 
            // per_lbl
            // 
            this.per_lbl.AutoSize = true;
            this.per_lbl.Location = new System.Drawing.Point(605, 137);
            this.per_lbl.Name = "per_lbl";
            this.per_lbl.Size = new System.Drawing.Size(23, 13);
            this.per_lbl.TabIndex = 28;
            this.per_lbl.Text = "Per";
            // 
            // newOrderDetails_dataGridView
            // 
            this.newOrderDetails_dataGridView.AllowUserToAddRows = false;
            this.newOrderDetails_dataGridView.AllowUserToDeleteRows = false;
            this.newOrderDetails_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newOrderDetails_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qty,
            this.unit,
            this.partid,
            this.part,
            this.description,
            this.unitPrice,
            this.per,
            this.dueDate,
            this.received,
            this.total});
            this.newOrderDetails_dataGridView.Location = new System.Drawing.Point(15, 195);
            this.newOrderDetails_dataGridView.Name = "newOrderDetails_dataGridView";
            this.newOrderDetails_dataGridView.ReadOnly = true;
            this.newOrderDetails_dataGridView.RowHeadersVisible = false;
            this.newOrderDetails_dataGridView.Size = new System.Drawing.Size(779, 217);
            this.newOrderDetails_dataGridView.TabIndex = 29;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qty.FillWeight = 30F;
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unit.FillWeight = 30F;
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // partid
            // 
            this.partid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.partid.FillWeight = 30F;
            this.partid.HeaderText = "Part ID";
            this.partid.Name = "partid";
            this.partid.ReadOnly = true;
            // 
            // part
            // 
            this.part.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.part.HeaderText = "Part/Cat. No.";
            this.part.Name = "part";
            this.part.ReadOnly = true;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.FillWeight = 200F;
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unitPrice.FillWeight = 75F;
            this.unitPrice.HeaderText = "Unit Price";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // per
            // 
            this.per.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.per.FillWeight = 50F;
            this.per.HeaderText = "Per";
            this.per.Name = "per";
            this.per.ReadOnly = true;
            // 
            // dueDate
            // 
            this.dueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dueDate.FillWeight = 75F;
            this.dueDate.HeaderText = "Due Date";
            this.dueDate.Name = "dueDate";
            this.dueDate.ReadOnly = true;
            // 
            // received
            // 
            this.received.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.received.FillWeight = 40F;
            this.received.HeaderText = "Rec\'v";
            this.received.Name = "received";
            this.received.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.FillWeight = 75F;
            this.total.HeaderText = "Line Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(705, 12);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(83, 23);
            this.save_btn.TabIndex = 30;
            this.save_btn.Text = "Save Order";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // cncl_btn
            // 
            this.cncl_btn.Location = new System.Drawing.Point(705, 41);
            this.cncl_btn.Name = "cncl_btn";
            this.cncl_btn.Size = new System.Drawing.Size(83, 23);
            this.cncl_btn.TabIndex = 31;
            this.cncl_btn.Text = "Cancel Order";
            this.cncl_btn.UseVisualStyleBackColor = true;
            this.cncl_btn.Click += new System.EventHandler(this.Cncl_btn_Click);
            // 
            // PR_Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cncl_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.newOrderDetails_dataGridView);
            this.Controls.Add(this.per_lbl);
            this.Controls.Add(this.total_lbl);
            this.Controls.Add(this.ordTot_lbl);
            this.Controls.Add(this.partDesc_lbl);
            this.Controls.Add(this.unitPrice_lbl);
            this.Controls.Add(this.unit_lbl);
            this.Controls.Add(this.partNo_lbl);
            this.Controls.Add(this.qty_lbl);
            this.Controls.Add(this.addToOrder_btn);
            this.Controls.Add(this.ordTot_txb);
            this.Controls.Add(this.total_txb);
            this.Controls.Add(this.per_combo);
            this.Controls.Add(this.price_txb);
            this.Controls.Add(this.desc_txb);
            this.Controls.Add(this.part_combo);
            this.Controls.Add(this.unit_combo);
            this.Controls.Add(this.qty_txb);
            this.Controls.Add(this.deliverTo_lbl);
            this.Controls.Add(this.vend_lbl);
            this.Controls.Add(this.deliverTo_txb);
            this.Controls.Add(this.vend_combo);
            this.Controls.Add(this.mach_combo);
            this.Controls.Add(this.dep_combo);
            this.Controls.Add(this.employee_combo);
            this.Controls.Add(this.dateIsued_dtp);
            this.Controls.Add(this.mach_lbl);
            this.Controls.Add(this.dep_lbl);
            this.Controls.Add(this.orderedBy_lbl);
            this.Controls.Add(this.dateIssued_lbl);
            this.Name = "PR_Entry";
            this.Text = "Purchase Request";
            this.Load += new System.EventHandler(this.PR_Entry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newOrderDetails_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateIssued_lbl;
        private System.Windows.Forms.Label orderedBy_lbl;
        private System.Windows.Forms.Label dep_lbl;
        private System.Windows.Forms.Label mach_lbl;
        private System.Windows.Forms.DateTimePicker dateIsued_dtp;
        private System.Windows.Forms.ComboBox employee_combo;
        private System.Windows.Forms.ComboBox dep_combo;
        private System.Windows.Forms.ComboBox mach_combo;
        private System.Windows.Forms.ComboBox vend_combo;
        private System.Windows.Forms.TextBox deliverTo_txb;
        private System.Windows.Forms.Label vend_lbl;
        private System.Windows.Forms.Label deliverTo_lbl;
        private System.Windows.Forms.TextBox qty_txb;
        private System.Windows.Forms.ComboBox unit_combo;
        private System.Windows.Forms.ComboBox part_combo;
        private System.Windows.Forms.TextBox desc_txb;
        private System.Windows.Forms.TextBox price_txb;
        private System.Windows.Forms.ComboBox per_combo;
        private System.Windows.Forms.TextBox total_txb;
        private System.Windows.Forms.TextBox ordTot_txb;
        private System.Windows.Forms.Button addToOrder_btn;
        private System.Windows.Forms.Label qty_lbl;
        private System.Windows.Forms.Label partNo_lbl;
        private System.Windows.Forms.Label unit_lbl;
        private System.Windows.Forms.Label unitPrice_lbl;
        private System.Windows.Forms.Label partDesc_lbl;
        private System.Windows.Forms.Label ordTot_lbl;
        private System.Windows.Forms.Label total_lbl;
        private System.Windows.Forms.Label per_lbl;
        private System.Windows.Forms.DataGridView newOrderDetails_dataGridView;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cncl_btn;
        private MELDataSet mELDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn partid;
        private System.Windows.Forms.DataGridViewTextBoxColumn part;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn per;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn received;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}