namespace MEL_r811_18
{
    partial class MachineSetup
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
            this.btNumber_txtbox = new System.Windows.Forms.TextBox();
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.make_txtbox = new System.Windows.Forms.TextBox();
            this.model_txtbox = new System.Windows.Forms.TextBox();
            this.serial_txtbox = new System.Windows.Forms.TextBox();
            this.btNumber_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.make_label = new System.Windows.Forms.Label();
            this.model_label = new System.Windows.Forms.Label();
            this.serial_label = new System.Windows.Forms.Label();
            this.department_label = new System.Windows.Forms.Label();
            this.department_combobox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btNumber_txtbox
            // 
            this.btNumber_txtbox.Location = new System.Drawing.Point(33, 25);
            this.btNumber_txtbox.Name = "btNumber_txtbox";
            this.btNumber_txtbox.Size = new System.Drawing.Size(156, 20);
            this.btNumber_txtbox.TabIndex = 0;
            // 
            // name_txtbox
            // 
            this.name_txtbox.Location = new System.Drawing.Point(239, 25);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(216, 20);
            this.name_txtbox.TabIndex = 1;
            // 
            // make_txtbox
            // 
            this.make_txtbox.Location = new System.Drawing.Point(33, 76);
            this.make_txtbox.Name = "make_txtbox";
            this.make_txtbox.Size = new System.Drawing.Size(156, 20);
            this.make_txtbox.TabIndex = 2;
            // 
            // model_txtbox
            // 
            this.model_txtbox.Location = new System.Drawing.Point(241, 76);
            this.model_txtbox.Name = "model_txtbox";
            this.model_txtbox.Size = new System.Drawing.Size(126, 20);
            this.model_txtbox.TabIndex = 3;
            // 
            // serial_txtbox
            // 
            this.serial_txtbox.Location = new System.Drawing.Point(419, 76);
            this.serial_txtbox.Name = "serial_txtbox";
            this.serial_txtbox.Size = new System.Drawing.Size(142, 20);
            this.serial_txtbox.TabIndex = 4;
            // 
            // btNumber_label
            // 
            this.btNumber_label.AutoSize = true;
            this.btNumber_label.Location = new System.Drawing.Point(12, 9);
            this.btNumber_label.Name = "btNumber_label";
            this.btNumber_label.Size = new System.Drawing.Size(61, 13);
            this.btNumber_label.TabIndex = 6;
            this.btNumber_label.Text = "BT Number";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(219, 9);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(123, 13);
            this.name_label.TabIndex = 7;
            this.name_label.Text = "Machine Common Name";
            // 
            // make_label
            // 
            this.make_label.AutoSize = true;
            this.make_label.Location = new System.Drawing.Point(12, 60);
            this.make_label.Name = "make_label";
            this.make_label.Size = new System.Drawing.Size(34, 13);
            this.make_label.TabIndex = 8;
            this.make_label.Text = "Make";
            // 
            // model_label
            // 
            this.model_label.AutoSize = true;
            this.model_label.Location = new System.Drawing.Point(219, 60);
            this.model_label.Name = "model_label";
            this.model_label.Size = new System.Drawing.Size(36, 13);
            this.model_label.TabIndex = 9;
            this.model_label.Text = "Model";
            // 
            // serial_label
            // 
            this.serial_label.AutoSize = true;
            this.serial_label.Location = new System.Drawing.Point(404, 60);
            this.serial_label.Name = "serial_label";
            this.serial_label.Size = new System.Drawing.Size(33, 13);
            this.serial_label.TabIndex = 10;
            this.serial_label.Text = "Serial";
            // 
            // department_label
            // 
            this.department_label.AutoSize = true;
            this.department_label.Location = new System.Drawing.Point(488, 9);
            this.department_label.Name = "department_label";
            this.department_label.Size = new System.Drawing.Size(62, 13);
            this.department_label.TabIndex = 11;
            this.department_label.Text = "Department";
            // 
            // department_combobox
            // 
            this.department_combobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.department_combobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.department_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department_combobox.FormattingEnabled = true;
            this.department_combobox.Location = new System.Drawing.Point(505, 25);
            this.department_combobox.Name = "department_combobox";
            this.department_combobox.Size = new System.Drawing.Size(121, 21);
            this.department_combobox.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Save_Machine);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(410, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "CANCEL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Cancel);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MachineSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 177);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.department_combobox);
            this.Controls.Add(this.department_label);
            this.Controls.Add(this.serial_label);
            this.Controls.Add(this.model_label);
            this.Controls.Add(this.make_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.btNumber_label);
            this.Controls.Add(this.serial_txtbox);
            this.Controls.Add(this.model_txtbox);
            this.Controls.Add(this.make_txtbox);
            this.Controls.Add(this.name_txtbox);
            this.Controls.Add(this.btNumber_txtbox);
            this.Name = "MachineSetup";
            this.Text = "Machine Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox btNumber_txtbox;
        private System.Windows.Forms.TextBox name_txtbox;
        private System.Windows.Forms.TextBox make_txtbox;
        private System.Windows.Forms.TextBox model_txtbox;
        private System.Windows.Forms.TextBox serial_txtbox;
        private System.Windows.Forms.Label btNumber_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label make_label;
        private System.Windows.Forms.Label model_label;
        private System.Windows.Forms.Label serial_label;
        private System.Windows.Forms.Label department_label;
        private System.Windows.Forms.ComboBox department_combobox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

