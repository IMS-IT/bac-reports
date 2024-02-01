namespace BACReports
{
    partial class frmUncollectedDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtMembers = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMainCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubTotalUnpaid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtMembers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtMembers
            // 
            this.dtMembers.AllowUserToAddRows = false;
            this.dtMembers.AllowUserToDeleteRows = false;
            this.dtMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtMembers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtMembers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMembers.Location = new System.Drawing.Point(12, 12);
            this.dtMembers.MultiSelect = false;
            this.dtMembers.Name = "dtMembers";
            this.dtMembers.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtMembers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtMembers.RowHeadersVisible = false;
            this.dtMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtMembers.Size = new System.Drawing.Size(895, 307);
            this.dtMembers.TabIndex = 51;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(844, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 33);
            this.button1.TabIndex = 52;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMainCode
            // 
            this.txtMainCode.Location = new System.Drawing.Point(12, 397);
            this.txtMainCode.Name = "txtMainCode";
            this.txtMainCode.Size = new System.Drawing.Size(63, 20);
            this.txtMainCode.TabIndex = 54;
            this.txtMainCode.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSubTotalUnpaid);
            this.panel1.Location = new System.Drawing.Point(574, 325);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel1.Size = new System.Drawing.Size(333, 33);
            this.panel1.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "TOTAL UNCOLLECTED:";
            // 
            // lblSubTotalUnpaid
            // 
            this.lblSubTotalUnpaid.AutoSize = true;
            this.lblSubTotalUnpaid.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSubTotalUnpaid.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalUnpaid.Location = new System.Drawing.Point(293, 9);
            this.lblSubTotalUnpaid.Name = "lblSubTotalUnpaid";
            this.lblSubTotalUnpaid.Size = new System.Drawing.Size(40, 16);
            this.lblSubTotalUnpaid.TabIndex = 1;
            this.lblSubTotalUnpaid.Text = "0.00";
            // 
            // frmUncollectedDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(919, 435);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMainCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtMembers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUncollectedDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Uncollected Details";
            this.Load += new System.EventHandler(this.frmUncollectedDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtMembers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dtMembers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMainCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubTotalUnpaid;
        private System.Windows.Forms.Label label1;
    }
}