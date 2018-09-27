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
            this.addContraint_button = new System.Windows.Forms.Button();
            this.removeConstraint_button = new System.Windows.Forms.Button();
            this.import_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(122, 190);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // addContraint_button
            // 
            this.addContraint_button.Location = new System.Drawing.Point(168, 47);
            this.addContraint_button.Name = "addContraint_button";
            this.addContraint_button.Size = new System.Drawing.Size(75, 23);
            this.addContraint_button.TabIndex = 3;
            this.addContraint_button.Text = "Reset";
            this.addContraint_button.UseVisualStyleBackColor = true;
            this.addContraint_button.Click += new System.EventHandler(this.Reset);
            // 
            // removeConstraint_button
            // 
            this.removeConstraint_button.Location = new System.Drawing.Point(168, 18);
            this.removeConstraint_button.Name = "removeConstraint_button";
            this.removeConstraint_button.Size = new System.Drawing.Size(75, 23);
            this.removeConstraint_button.TabIndex = 14;
            this.removeConstraint_button.Text = "Remove";
            this.removeConstraint_button.UseVisualStyleBackColor = true;
            this.removeConstraint_button.Click += new System.EventHandler(this.RemoveContraints);
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(168, 88);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(75, 23);
            this.import_button.TabIndex = 15;
            this.import_button.Text = "Import";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 216);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.removeConstraint_button);
            this.Controls.Add(this.addContraint_button);
            this.Controls.Add(this.listView1);
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.ImportScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button addContraint_button;
        private System.Windows.Forms.Button removeConstraint_button;
        private System.Windows.Forms.Button import_button;
    }
}