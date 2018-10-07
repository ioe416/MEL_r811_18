namespace MEL_r811_18
{
    partial class NewPart
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
            this.partNumber_lbl = new System.Windows.Forms.Label();
            this.partDescription_lbl = new System.Windows.Forms.Label();
            this.unitPrice_lbl = new System.Windows.Forms.Label();
            this.partImage_lbl = new System.Windows.Forms.Label();
            this.partNumber_txb = new System.Windows.Forms.TextBox();
            this.partDescription_txb = new System.Windows.Forms.TextBox();
            this.partImage_picBx = new System.Windows.Forms.PictureBox();
            this.saveExit_btn = new System.Windows.Forms.Button();
            this.saveNew_btn = new System.Windows.Forms.Button();
            this.dollarSign_lbl = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.unitPrice_txb = new System.Windows.Forms.TextBox();
            this.saveReturn_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.partImage_picBx)).BeginInit();
            this.SuspendLayout();
            // 
            // partNumber_lbl
            // 
            this.partNumber_lbl.AutoSize = true;
            this.partNumber_lbl.Location = new System.Drawing.Point(12, 9);
            this.partNumber_lbl.Name = "partNumber_lbl";
            this.partNumber_lbl.Size = new System.Drawing.Size(67, 13);
            this.partNumber_lbl.TabIndex = 0;
            this.partNumber_lbl.Text = "Part/Cat No.";
            // 
            // partDescription_lbl
            // 
            this.partDescription_lbl.AutoSize = true;
            this.partDescription_lbl.Location = new System.Drawing.Point(168, 9);
            this.partDescription_lbl.Name = "partDescription_lbl";
            this.partDescription_lbl.Size = new System.Drawing.Size(60, 13);
            this.partDescription_lbl.TabIndex = 1;
            this.partDescription_lbl.Text = "Description";
            // 
            // unitPrice_lbl
            // 
            this.unitPrice_lbl.AutoSize = true;
            this.unitPrice_lbl.Location = new System.Drawing.Point(471, 9);
            this.unitPrice_lbl.Name = "unitPrice_lbl";
            this.unitPrice_lbl.Size = new System.Drawing.Size(53, 13);
            this.unitPrice_lbl.TabIndex = 2;
            this.unitPrice_lbl.Text = "Unit Price";
            // 
            // partImage_lbl
            // 
            this.partImage_lbl.AutoSize = true;
            this.partImage_lbl.Location = new System.Drawing.Point(12, 91);
            this.partImage_lbl.Name = "partImage_lbl";
            this.partImage_lbl.Size = new System.Drawing.Size(58, 13);
            this.partImage_lbl.TabIndex = 3;
            this.partImage_lbl.Text = "Part Image";
            // 
            // partNumber_txb
            // 
            this.partNumber_txb.BackColor = System.Drawing.Color.DodgerBlue;
            this.partNumber_txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNumber_txb.Location = new System.Drawing.Point(15, 25);
            this.partNumber_txb.Name = "partNumber_txb";
            this.partNumber_txb.Size = new System.Drawing.Size(132, 26);
            this.partNumber_txb.TabIndex = 4;
            // 
            // partDescription_txb
            // 
            this.partDescription_txb.BackColor = System.Drawing.Color.DodgerBlue;
            this.partDescription_txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDescription_txb.Location = new System.Drawing.Point(171, 25);
            this.partDescription_txb.Multiline = true;
            this.partDescription_txb.Name = "partDescription_txb";
            this.partDescription_txb.Size = new System.Drawing.Size(278, 76);
            this.partDescription_txb.TabIndex = 5;
            // 
            // partImage_picBx
            // 
            this.partImage_picBx.Location = new System.Drawing.Point(15, 107);
            this.partImage_picBx.Name = "partImage_picBx";
            this.partImage_picBx.Size = new System.Drawing.Size(184, 134);
            this.partImage_picBx.TabIndex = 7;
            this.partImage_picBx.TabStop = false;
            // 
            // saveExit_btn
            // 
            this.saveExit_btn.Location = new System.Drawing.Point(474, 191);
            this.saveExit_btn.Name = "saveExit_btn";
            this.saveExit_btn.Size = new System.Drawing.Size(85, 23);
            this.saveExit_btn.TabIndex = 8;
            this.saveExit_btn.Text = "Save && Exit";
            this.saveExit_btn.UseVisualStyleBackColor = true;
            this.saveExit_btn.Click += new System.EventHandler(this.SaveExit_btn_Click);
            // 
            // saveNew_btn
            // 
            this.saveNew_btn.Location = new System.Drawing.Point(474, 162);
            this.saveNew_btn.Name = "saveNew_btn";
            this.saveNew_btn.Size = new System.Drawing.Size(85, 23);
            this.saveNew_btn.TabIndex = 9;
            this.saveNew_btn.Text = "Save && New";
            this.saveNew_btn.UseVisualStyleBackColor = true;
            this.saveNew_btn.Click += new System.EventHandler(this.SaveNew_btn_Click);
            // 
            // dollarSign_lbl
            // 
            this.dollarSign_lbl.AutoSize = true;
            this.dollarSign_lbl.Location = new System.Drawing.Point(459, 28);
            this.dollarSign_lbl.Name = "dollarSign_lbl";
            this.dollarSign_lbl.Size = new System.Drawing.Size(13, 13);
            this.dollarSign_lbl.TabIndex = 10;
            this.dollarSign_lbl.Text = "$";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(474, 133);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(85, 23);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // unitPrice_txb
            // 
            this.unitPrice_txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPrice_txb.Location = new System.Drawing.Point(474, 25);
            this.unitPrice_txb.Name = "unitPrice_txb";
            this.unitPrice_txb.Size = new System.Drawing.Size(85, 26);
            this.unitPrice_txb.TabIndex = 13;
            this.unitPrice_txb.TextChanged += new System.EventHandler(this.UnitPrice_txb_TextChanged);
            this.unitPrice_txb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UnitPrice_txb_KeyPress);
            // 
            // saveReturn_btn
            // 
            this.saveReturn_btn.Location = new System.Drawing.Point(474, 218);
            this.saveReturn_btn.Name = "saveReturn_btn";
            this.saveReturn_btn.Size = new System.Drawing.Size(85, 23);
            this.saveReturn_btn.TabIndex = 14;
            this.saveReturn_btn.Text = "Save && Return";
            this.saveReturn_btn.UseVisualStyleBackColor = true;
            this.saveReturn_btn.Click += new System.EventHandler(this.SaveReturn_btn_Click);
            // 
            // NewPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(575, 256);
            this.Controls.Add(this.saveReturn_btn);
            this.Controls.Add(this.unitPrice_txb);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.dollarSign_lbl);
            this.Controls.Add(this.saveNew_btn);
            this.Controls.Add(this.saveExit_btn);
            this.Controls.Add(this.partImage_picBx);
            this.Controls.Add(this.partDescription_txb);
            this.Controls.Add(this.partNumber_txb);
            this.Controls.Add(this.partImage_lbl);
            this.Controls.Add(this.unitPrice_lbl);
            this.Controls.Add(this.partDescription_lbl);
            this.Controls.Add(this.partNumber_lbl);
            this.Name = "NewPart";
            this.Text = "NewPart";
            this.Load += new System.EventHandler(this.NewPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.partImage_picBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label partNumber_lbl;
        private System.Windows.Forms.Label partDescription_lbl;
        private System.Windows.Forms.Label unitPrice_lbl;
        private System.Windows.Forms.Label partImage_lbl;
        private System.Windows.Forms.TextBox partNumber_txb;
        private System.Windows.Forms.TextBox partDescription_txb;
        private System.Windows.Forms.PictureBox partImage_picBx;
        private System.Windows.Forms.Button saveExit_btn;
        private System.Windows.Forms.Button saveNew_btn;
        private System.Windows.Forms.Label dollarSign_lbl;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox unitPrice_txb;
        private System.Windows.Forms.Button saveReturn_btn;
    }
}