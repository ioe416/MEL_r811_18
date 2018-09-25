namespace MEL_r811_18
{
    partial class Import
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.loadMachines_button = new System.Windows.Forms.Button();
            this.saveMachines_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.loadParts_button = new System.Windows.Forms.Button();
            this.loadVendors_button = new System.Windows.Forms.Button();
            this.saveParts_button = new System.Windows.Forms.Button();
            this.saveVendors_button = new System.Windows.Forms.Button();
            this.loadEmployee_button = new System.Windows.Forms.Button();
            this.saveEmployee_button = new System.Windows.Forms.Button();
            this.loadPR_button = new System.Windows.Forms.Button();
            this.loadPR_Details_button = new System.Windows.Forms.Button();
            this.savePR_button = new System.Windows.Forms.Button();
            this.savePR_Details_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(122, 603);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // loadMachines_button
            // 
            this.loadMachines_button.Location = new System.Drawing.Point(128, 12);
            this.loadMachines_button.Name = "loadMachines_button";
            this.loadMachines_button.Size = new System.Drawing.Size(75, 23);
            this.loadMachines_button.TabIndex = 1;
            this.loadMachines_button.Text = "Machines";
            this.loadMachines_button.UseVisualStyleBackColor = true;
            this.loadMachines_button.Click += new System.EventHandler(this.LoadMachinesFromExcel);
            // 
            // saveMachines_button
            // 
            this.saveMachines_button.Enabled = false;
            this.saveMachines_button.Location = new System.Drawing.Point(209, 12);
            this.saveMachines_button.Name = "saveMachines_button";
            this.saveMachines_button.Size = new System.Drawing.Size(75, 23);
            this.saveMachines_button.TabIndex = 2;
            this.saveMachines_button.Text = "Save to DB";
            this.saveMachines_button.UseVisualStyleBackColor = true;
            this.saveMachines_button.Click += new System.EventHandler(this.SaveMachinesToDB);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(171, 592);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Reset);
            // 
            // loadParts_button
            // 
            this.loadParts_button.Location = new System.Drawing.Point(128, 41);
            this.loadParts_button.Name = "loadParts_button";
            this.loadParts_button.Size = new System.Drawing.Size(75, 23);
            this.loadParts_button.TabIndex = 4;
            this.loadParts_button.Text = "Parts";
            this.loadParts_button.UseVisualStyleBackColor = true;
            this.loadParts_button.Click += new System.EventHandler(this.LoadPartsFromExcel);
            // 
            // loadVendors_button
            // 
            this.loadVendors_button.Location = new System.Drawing.Point(128, 70);
            this.loadVendors_button.Name = "loadVendors_button";
            this.loadVendors_button.Size = new System.Drawing.Size(75, 23);
            this.loadVendors_button.TabIndex = 6;
            this.loadVendors_button.Text = "Vendors";
            this.loadVendors_button.UseVisualStyleBackColor = true;
            this.loadVendors_button.Click += new System.EventHandler(this.LoadVendorsFromExcel);
            // 
            // saveParts_button
            // 
            this.saveParts_button.Enabled = false;
            this.saveParts_button.Location = new System.Drawing.Point(209, 41);
            this.saveParts_button.Name = "saveParts_button";
            this.saveParts_button.Size = new System.Drawing.Size(75, 23);
            this.saveParts_button.TabIndex = 5;
            this.saveParts_button.Text = "Save to DB";
            this.saveParts_button.UseVisualStyleBackColor = true;
            this.saveParts_button.Click += new System.EventHandler(this.SavePartsToDB);
            // 
            // saveVendors_button
            // 
            this.saveVendors_button.Enabled = false;
            this.saveVendors_button.Location = new System.Drawing.Point(209, 70);
            this.saveVendors_button.Name = "saveVendors_button";
            this.saveVendors_button.Size = new System.Drawing.Size(75, 23);
            this.saveVendors_button.TabIndex = 7;
            this.saveVendors_button.Text = "Save to DB";
            this.saveVendors_button.UseVisualStyleBackColor = true;
            this.saveVendors_button.Click += new System.EventHandler(this.SaveVendorsToDB);
            // 
            // loadEmployee_button
            // 
            this.loadEmployee_button.Location = new System.Drawing.Point(128, 99);
            this.loadEmployee_button.Name = "loadEmployee_button";
            this.loadEmployee_button.Size = new System.Drawing.Size(75, 23);
            this.loadEmployee_button.TabIndex = 8;
            this.loadEmployee_button.Text = "Employee";
            this.loadEmployee_button.UseVisualStyleBackColor = true;
            this.loadEmployee_button.Click += new System.EventHandler(this.LoadEmployeeFromExcel);
            // 
            // saveEmployee_button
            // 
            this.saveEmployee_button.Enabled = false;
            this.saveEmployee_button.Location = new System.Drawing.Point(209, 99);
            this.saveEmployee_button.Name = "saveEmployee_button";
            this.saveEmployee_button.Size = new System.Drawing.Size(75, 23);
            this.saveEmployee_button.TabIndex = 9;
            this.saveEmployee_button.Text = "Save to DB";
            this.saveEmployee_button.UseVisualStyleBackColor = true;
            this.saveEmployee_button.Click += new System.EventHandler(this.SaveEmployeeToDB);
            // 
            // loadPR_button
            // 
            this.loadPR_button.Location = new System.Drawing.Point(128, 128);
            this.loadPR_button.Name = "loadPR_button";
            this.loadPR_button.Size = new System.Drawing.Size(75, 23);
            this.loadPR_button.TabIndex = 10;
            this.loadPR_button.Text = "PR";
            this.loadPR_button.UseVisualStyleBackColor = true;
            this.loadPR_button.Click += new System.EventHandler(this.LoadPRFromExcel);
            // 
            // loadPR_Details_button
            // 
            this.loadPR_Details_button.Location = new System.Drawing.Point(128, 157);
            this.loadPR_Details_button.Name = "loadPR_Details_button";
            this.loadPR_Details_button.Size = new System.Drawing.Size(75, 23);
            this.loadPR_Details_button.TabIndex = 11;
            this.loadPR_Details_button.Text = "PR Details";
            this.loadPR_Details_button.UseVisualStyleBackColor = true;
            this.loadPR_Details_button.Click += new System.EventHandler(this.LoadPR_DetaisFromExcel);
            // 
            // savePR_button
            // 
            this.savePR_button.Enabled = false;
            this.savePR_button.Location = new System.Drawing.Point(209, 128);
            this.savePR_button.Name = "savePR_button";
            this.savePR_button.Size = new System.Drawing.Size(75, 23);
            this.savePR_button.TabIndex = 12;
            this.savePR_button.Text = "Save to DB";
            this.savePR_button.UseVisualStyleBackColor = true;
            this.savePR_button.Click += new System.EventHandler(this.SavePRToDB);
            // 
            // savePR_Details_button
            // 
            this.savePR_Details_button.Enabled = false;
            this.savePR_Details_button.Location = new System.Drawing.Point(209, 157);
            this.savePR_Details_button.Name = "savePR_Details_button";
            this.savePR_Details_button.Size = new System.Drawing.Size(75, 23);
            this.savePR_Details_button.TabIndex = 13;
            this.savePR_Details_button.Text = "Save to DB";
            this.savePR_Details_button.UseVisualStyleBackColor = true;
            this.savePR_Details_button.Click += new System.EventHandler(this.SavePR_DetaisToDB);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 627);
            this.Controls.Add(this.savePR_Details_button);
            this.Controls.Add(this.savePR_button);
            this.Controls.Add(this.loadPR_Details_button);
            this.Controls.Add(this.loadPR_button);
            this.Controls.Add(this.saveEmployee_button);
            this.Controls.Add(this.loadEmployee_button);
            this.Controls.Add(this.saveVendors_button);
            this.Controls.Add(this.loadVendors_button);
            this.Controls.Add(this.saveParts_button);
            this.Controls.Add(this.loadParts_button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.saveMachines_button);
            this.Controls.Add(this.loadMachines_button);
            this.Controls.Add(this.listView1);
            this.Name = "Import";
            this.Text = "Import";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button loadMachines_button;
        private System.Windows.Forms.Button saveMachines_button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button loadParts_button;
        private System.Windows.Forms.Button loadVendors_button;
        private System.Windows.Forms.Button saveParts_button;
        private System.Windows.Forms.Button saveVendors_button;
        private System.Windows.Forms.Button loadEmployee_button;
        private System.Windows.Forms.Button saveEmployee_button;
        private System.Windows.Forms.Button loadPR_button;
        private System.Windows.Forms.Button loadPR_Details_button;
        private System.Windows.Forms.Button savePR_button;
        private System.Windows.Forms.Button savePR_Details_button;
    }
}