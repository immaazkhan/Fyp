
namespace LoginPage
{
    partial class frmProductCategoryMgt
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
            _DefaultInstance = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductCategoryMgt));
            this.lblCaption1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption1
            // 
            this.lblCaption1.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCaption1.Location = new System.Drawing.Point(0, 0);
            this.lblCaption1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption1.Name = "lblCaption1";
            this.lblCaption1.Size = new System.Drawing.Size(869, 44);
            this.lblCaption1.TabIndex = 0;
            this.lblCaption1.Text = "Product Category";
            this.lblCaption1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 93);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(869, 465);
            this.dgv.TabIndex = 10;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 62);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(869, 31);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.Image")));
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(43, 28);
            this.BtnNew.Text = "New";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpen.Image")));
            this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(49, 28);
            this.BtnOpen.Text = "Open";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblCaption1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 62);
            this.panel2.TabIndex = 8;
            // 
            // frmProductCategoryMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 558);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductCategoryMgt";
            this.Text = "frmProductCategoryMgt";
            this.Load += new System.EventHandler(this.frmProductCategoryMgt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.ToolStripButton BtnOpen;
        private System.Windows.Forms.Panel panel2;
    }
}