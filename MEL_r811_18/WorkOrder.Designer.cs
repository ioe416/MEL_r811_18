namespace MEL_r811_18
{
    partial class WorkOrder
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
            this.workRequestID_textBox = new System.Windows.Forms.TextBox();
            this.tech_comboBox = new System.Windows.Forms.ComboBox();
            this.status_comboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToList_button = new System.Windows.Forms.Button();
            this.part_comboBox = new System.Windows.Forms.ComboBox();
            this.qty_textBox = new System.Windows.Forms.TextBox();
            this.stock_radioButton = new System.Windows.Forms.RadioButton();
            this.ordered_radioButton = new System.Windows.Forms.RadioButton();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.partDesc_textbox = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // workRequestID_textBox
            // 
            this.workRequestID_textBox.Enabled = false;
            this.workRequestID_textBox.Location = new System.Drawing.Point(39, 28);
            this.workRequestID_textBox.Name = "workRequestID_textBox";
            this.workRequestID_textBox.Size = new System.Drawing.Size(63, 20);
            this.workRequestID_textBox.TabIndex = 0;
            // 
            // tech_comboBox
            // 
            this.tech_comboBox.FormattingEnabled = true;
            this.tech_comboBox.Location = new System.Drawing.Point(180, 84);
            this.tech_comboBox.Name = "tech_comboBox";
            this.tech_comboBox.Size = new System.Drawing.Size(121, 21);
            this.tech_comboBox.TabIndex = 1;
            // 
            // status_comboBox
            // 
            this.status_comboBox.FormattingEnabled = true;
            this.status_comboBox.Location = new System.Drawing.Point(380, 84);
            this.status_comboBox.Name = "status_comboBox";
            this.status_comboBox.Size = new System.Drawing.Size(121, 21);
            this.status_comboBox.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(272, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Completed";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(380, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(39, 159);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(568, 116);
            this.textBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Work Request ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 52);
            this.label2.TabIndex = 7;
            this.label2.Text = "Primary (Lead) Tech assigned to:\r\n(Additional tech\'s may be\r\nassigned as needed t" +
    "o complete\r\nthe task.)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status of Work Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Describe Work Performed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Completion Date:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.part,
            this.qty,
            this.partDesc,
            this.stockOrdered,
            this.work});
            this.dataGridView1.Location = new System.Drawing.Point(15, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(592, 141);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.Visible = false;
            // 
            // part
            // 
            this.part.HeaderText = "Part Used";
            this.part.Name = "part";
            this.part.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty Used";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // partDesc
            // 
            this.partDesc.HeaderText = "Part Description";
            this.partDesc.Name = "partDesc";
            this.partDesc.ReadOnly = true;
            // 
            // stockOrdered
            // 
            this.stockOrdered.HeaderText = "Stock/Ordered";
            this.stockOrdered.Name = "stockOrdered";
            this.stockOrdered.ReadOnly = true;
            // 
            // work
            // 
            this.work.HeaderText = "Work Performed";
            this.work.Name = "work";
            this.work.ReadOnly = true;
            // 
            // addToList_button
            // 
            this.addToList_button.Location = new System.Drawing.Point(529, 280);
            this.addToList_button.Name = "addToList_button";
            this.addToList_button.Size = new System.Drawing.Size(75, 23);
            this.addToList_button.TabIndex = 12;
            this.addToList_button.Text = "Add";
            this.addToList_button.UseVisualStyleBackColor = true;
            this.addToList_button.Visible = false;
            this.addToList_button.Click += new System.EventHandler(this.AddToOrder_btn_Click);
            // 
            // part_comboBox
            // 
            this.part_comboBox.FormattingEnabled = true;
            this.part_comboBox.Location = new System.Drawing.Point(12, 281);
            this.part_comboBox.Name = "part_comboBox";
            this.part_comboBox.Size = new System.Drawing.Size(90, 21);
            this.part_comboBox.TabIndex = 13;
            this.part_comboBox.Visible = false;
            // 
            // qty_textBox
            // 
            this.qty_textBox.Location = new System.Drawing.Point(279, 281);
            this.qty_textBox.Name = "qty_textBox";
            this.qty_textBox.Size = new System.Drawing.Size(67, 20);
            this.qty_textBox.TabIndex = 14;
            this.qty_textBox.Visible = false;
            // 
            // stock_radioButton
            // 
            this.stock_radioButton.AutoSize = true;
            this.stock_radioButton.Location = new System.Drawing.Point(12, 2);
            this.stock_radioButton.Name = "stock_radioButton";
            this.stock_radioButton.Size = new System.Drawing.Size(76, 17);
            this.stock_radioButton.TabIndex = 15;
            this.stock_radioButton.TabStop = true;
            this.stock_radioButton.Text = "Stock Item";
            this.stock_radioButton.UseVisualStyleBackColor = true;
            this.stock_radioButton.Visible = false;
            // 
            // ordered_radioButton
            // 
            this.ordered_radioButton.AutoSize = true;
            this.ordered_radioButton.Location = new System.Drawing.Point(88, 3);
            this.ordered_radioButton.Name = "ordered_radioButton";
            this.ordered_radioButton.Size = new System.Drawing.Size(86, 17);
            this.ordered_radioButton.TabIndex = 16;
            this.ordered_radioButton.TabStop = true;
            this.ordered_radioButton.Text = "Ordered Item";
            this.ordered_radioButton.UseVisualStyleBackColor = true;
            this.ordered_radioButton.Visible = false;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(529, 26);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 18;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(529, 68);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 19;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // partDesc_textbox
            // 
            this.partDesc_textbox.Location = new System.Drawing.Point(108, 281);
            this.partDesc_textbox.Name = "partDesc_textbox";
            this.partDesc_textbox.Size = new System.Drawing.Size(165, 20);
            this.partDesc_textbox.TabIndex = 21;
            this.partDesc_textbox.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Yes";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(56, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "No";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(368, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 45);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Were Parts Used?";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stock_radioButton);
            this.groupBox2.Controls.Add(this.ordered_radioButton);
            this.groupBox2.Location = new System.Drawing.Point(349, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 24);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // WorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 463);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.partDesc_textbox);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.qty_textBox);
            this.Controls.Add(this.part_comboBox);
            this.Controls.Add(this.addToList_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.status_comboBox);
            this.Controls.Add(this.tech_comboBox);
            this.Controls.Add(this.workRequestID_textBox);
            this.Name = "WorkOrder";
            this.Text = "WorkOrder";
            this.Load += new System.EventHandler(this.WorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox tech_comboBox;
        private System.Windows.Forms.ComboBox status_comboBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addToList_button;
        private System.Windows.Forms.ComboBox part_comboBox;
        private System.Windows.Forms.TextBox qty_textBox;
        private System.Windows.Forms.RadioButton stock_radioButton;
        private System.Windows.Forms.RadioButton ordered_radioButton;
        public System.Windows.Forms.TextBox workRequestID_textBox;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.TextBox partDesc_textbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn part;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn partDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn work;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}