namespace LoginPage
{
    partial class DSMC_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSMC_Dashboard));
            this.Admin = new System.Windows.Forms.PictureBox();
            this.Lab = new System.Windows.Forms.PictureBox();
            this.Pharmacy = new System.Windows.Forms.PictureBox();
            this.Receptionist = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Admin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pharmacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Receptionist)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Admin
            // 
            this.Admin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin.Image = ((System.Drawing.Image)(resources.GetObject("Admin.Image")));
            this.Admin.Location = new System.Drawing.Point(105, 116);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(148, 133);
            this.Admin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Admin.TabIndex = 0;
            this.Admin.TabStop = false;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // Lab
            // 
            this.Lab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lab.Image = ((System.Drawing.Image)(resources.GetObject("Lab.Image")));
            this.Lab.Location = new System.Drawing.Point(370, 116);
            this.Lab.Name = "Lab";
            this.Lab.Size = new System.Drawing.Size(148, 133);
            this.Lab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Lab.TabIndex = 5;
            this.Lab.TabStop = false;
            this.Lab.Click += new System.EventHandler(this.Lab_Click);
            // 
            // Pharmacy
            // 
            this.Pharmacy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pharmacy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pharmacy.Image = ((System.Drawing.Image)(resources.GetObject("Pharmacy.Image")));
            this.Pharmacy.Location = new System.Drawing.Point(639, 116);
            this.Pharmacy.Name = "Pharmacy";
            this.Pharmacy.Size = new System.Drawing.Size(148, 133);
            this.Pharmacy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pharmacy.TabIndex = 6;
            this.Pharmacy.TabStop = false;
            this.Pharmacy.Click += new System.EventHandler(this.Pharmacy_Click);
            // 
            // Receptionist
            // 
            this.Receptionist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Receptionist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Receptionist.Image = ((System.Drawing.Image)(resources.GetObject("Receptionist.Image")));
            this.Receptionist.Location = new System.Drawing.Point(370, 320);
            this.Receptionist.Name = "Receptionist";
            this.Receptionist.Size = new System.Drawing.Size(148, 133);
            this.Receptionist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Receptionist.TabIndex = 7;
            this.Receptionist.TabStop = false;
            this.Receptionist.Click += new System.EventHandler(this.Receptionist_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(861, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 69);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "DSMC Dashboard";
            // 
            // DSMC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(907, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Receptionist);
            this.Controls.Add(this.Pharmacy);
            this.Controls.Add(this.Lab);
            this.Controls.Add(this.Admin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DSMC_Dashboard";
            this.Text = "DSMC_Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.Admin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pharmacy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Receptionist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Admin;
        private System.Windows.Forms.PictureBox Lab;
        private System.Windows.Forms.PictureBox Pharmacy;
        private System.Windows.Forms.PictureBox Receptionist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}