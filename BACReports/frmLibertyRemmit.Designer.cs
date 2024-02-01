﻿namespace BACReports
{
    partial class frmLibertyRemmit
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblMembers = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtRemCode = new System.Windows.Forms.TextBox();
            this.dtMembers = new System.Windows.Forms.DataGridView();
            this.totalUnremitted = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkExcludeEx = new System.Windows.Forms.CheckBox();
            this.panelExtractInfo = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCollectedTo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCollectedFrom = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExtracteDate = new System.Windows.Forms.Label();
            this.btnExtractRemmittance = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboReferenceNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboInsuranceType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblActivity = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMembers)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panelExtractInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(24, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1293, 670);
            this.tabControl1.TabIndex = 158;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dtpTo);
            this.tabPage1.Controls.Add(this.dtpFrom);
            this.tabPage1.Controls.Add(this.lblMembers);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.txtRemCode);
            this.tabPage1.Controls.Add(this.dtMembers);
            this.tabPage1.Controls.Add(this.totalUnremitted);
            this.tabPage1.Controls.Add(this.lbl1);
            this.tabPage1.Controls.Add(this.btnExtract);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtYear);
            this.tabPage1.Controls.Add(this.cboMonth);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1285, 632);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Remmit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(273, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 22);
            this.label10.TabIndex = 309;
            this.label10.Text = "Collection To:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(32, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 22);
            this.label9.TabIndex = 308;
            this.label9.Text = "Collection From:";
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.CustomFormat = "yyyy-MM-dd";
            this.dtpTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(278, 55);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(230, 31);
            this.dtpTo.TabIndex = 307;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(36, 55);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(230, 31);
            this.dtpFrom.TabIndex = 306;
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMembers.Location = new System.Drawing.Point(514, 25);
            this.lblMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(80, 22);
            this.lblMembers.TabIndex = 305;
            this.lblMembers.Text = "Details:";
            this.lblMembers.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(36, 182);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(232, 55);
            this.btnRefresh.TabIndex = 304;
            this.btnRefresh.Text = "Check Unremmitted";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtRemCode
            // 
            this.txtRemCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemCode.ForeColor = System.Drawing.Color.Black;
            this.txtRemCode.Location = new System.Drawing.Point(1036, 11);
            this.txtRemCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemCode.Name = "txtRemCode";
            this.txtRemCode.ReadOnly = true;
            this.txtRemCode.Size = new System.Drawing.Size(214, 31);
            this.txtRemCode.TabIndex = 173;
            this.txtRemCode.Visible = false;
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
            this.dtMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMembers.Location = new System.Drawing.Point(519, 55);
            this.dtMembers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtMembers.MultiSelect = false;
            this.dtMembers.Name = "dtMembers";
            this.dtMembers.ReadOnly = true;
            this.dtMembers.RowHeadersVisible = false;
            this.dtMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtMembers.Size = new System.Drawing.Size(734, 537);
            this.dtMembers.TabIndex = 172;
            this.dtMembers.Visible = false;
            // 
            // totalUnremitted
            // 
            this.totalUnremitted.AutoSize = true;
            this.totalUnremitted.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalUnremitted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalUnremitted.Location = new System.Drawing.Point(236, 122);
            this.totalUnremitted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalUnremitted.Name = "totalUnremitted";
            this.totalUnremitted.Size = new System.Drawing.Size(21, 22);
            this.totalUnremitted.TabIndex = 163;
            this.totalUnremitted.Text = "0";
            this.totalUnremitted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl1.Location = new System.Drawing.Point(32, 122);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(188, 22);
            this.lbl1.TabIndex = 162;
            this.lbl1.Text = "Total Unremitted:";
            // 
            // btnExtract
            // 
            this.btnExtract.BackColor = System.Drawing.Color.Transparent;
            this.btnExtract.ForeColor = System.Drawing.Color.Black;
            this.btnExtract.Location = new System.Drawing.Point(278, 182);
            this.btnExtract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(232, 55);
            this.btnExtract.TabIndex = 161;
            this.btnExtract.Text = "Start";
            this.btnExtract.UseVisualStyleBackColor = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(32, 303);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 160;
            this.label1.Text = "Year:";
            this.label1.Visible = false;
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.ForeColor = System.Drawing.Color.Black;
            this.txtYear.Location = new System.Drawing.Point(36, 329);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(79, 31);
            this.txtYear.TabIndex = 159;
            this.txtYear.Visible = false;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(126, 329);
            this.cboMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(324, 33);
            this.cboMonth.TabIndex = 158;
            this.cboMonth.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(122, 303);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 22);
            this.label6.TabIndex = 157;
            this.label6.Text = "Month:";
            this.label6.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkExcludeEx);
            this.tabPage2.Controls.Add(this.panelExtractInfo);
            this.tabPage2.Controls.Add(this.btnExtractRemmittance);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cboReferenceNo);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cboInsuranceType);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1285, 632);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Extract";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkExcludeEx
            // 
            this.chkExcludeEx.AutoSize = true;
            this.chkExcludeEx.Checked = true;
            this.chkExcludeEx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeEx.Location = new System.Drawing.Point(24, 305);
            this.chkExcludeEx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkExcludeEx.Name = "chkExcludeEx";
            this.chkExcludeEx.Size = new System.Drawing.Size(219, 29);
            this.chkExcludeEx.TabIndex = 184;
            this.chkExcludeEx.Text = "Exclude Extracted";
            this.chkExcludeEx.UseVisualStyleBackColor = true;
            this.chkExcludeEx.Visible = false;
            // 
            // panelExtractInfo
            // 
            this.panelExtractInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExtractInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExtractInfo.Controls.Add(this.label13);
            this.panelExtractInfo.Controls.Add(this.label14);
            this.panelExtractInfo.Controls.Add(this.label11);
            this.panelExtractInfo.Controls.Add(this.label12);
            this.panelExtractInfo.Controls.Add(this.lblCollectedTo);
            this.panelExtractInfo.Controls.Add(this.label7);
            this.panelExtractInfo.Controls.Add(this.label5);
            this.panelExtractInfo.Controls.Add(this.lblCollectedFrom);
            this.panelExtractInfo.Controls.Add(this.label8);
            this.panelExtractInfo.Controls.Add(this.lblExtracteDate);
            this.panelExtractInfo.Location = new System.Drawing.Point(465, 55);
            this.panelExtractInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelExtractInfo.Name = "panelExtractInfo";
            this.panelExtractInfo.Size = new System.Drawing.Size(582, 204);
            this.panelExtractInfo.TabIndex = 183;
            this.panelExtractInfo.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(180, 51);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 22);
            this.label13.TabIndex = 189;
            this.label13.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(14, 52);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 22);
            this.label14.TabIndex = 188;
            this.label14.Text = "Not Extracted:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(180, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 22);
            this.label11.TabIndex = 187;
            this.label11.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(14, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 22);
            this.label12.TabIndex = 186;
            this.label12.Text = "Extracted:";
            // 
            // lblCollectedTo
            // 
            this.lblCollectedTo.AutoSize = true;
            this.lblCollectedTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectedTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCollectedTo.Location = new System.Drawing.Point(180, 151);
            this.lblCollectedTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCollectedTo.Name = "lblCollectedTo";
            this.lblCollectedTo.Size = new System.Drawing.Size(18, 22);
            this.lblCollectedTo.TabIndex = 185;
            this.lblCollectedTo.Text = "-";
            this.lblCollectedTo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(14, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 22);
            this.label7.TabIndex = 181;
            this.label7.Text = "Collected From:";
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(14, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 22);
            this.label5.TabIndex = 180;
            this.label5.Text = "Remmit Date:";
            this.label5.Visible = false;
            // 
            // lblCollectedFrom
            // 
            this.lblCollectedFrom.AutoSize = true;
            this.lblCollectedFrom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectedFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCollectedFrom.Location = new System.Drawing.Point(180, 118);
            this.lblCollectedFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCollectedFrom.Name = "lblCollectedFrom";
            this.lblCollectedFrom.Size = new System.Drawing.Size(18, 22);
            this.lblCollectedFrom.TabIndex = 184;
            this.lblCollectedFrom.Text = "-";
            this.lblCollectedFrom.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(14, 151);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 22);
            this.label8.TabIndex = 182;
            this.label8.Text = "Collected To:";
            this.label8.Visible = false;
            // 
            // lblExtracteDate
            // 
            this.lblExtracteDate.AutoSize = true;
            this.lblExtracteDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtracteDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblExtracteDate.Location = new System.Drawing.Point(180, 86);
            this.lblExtracteDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtracteDate.Name = "lblExtracteDate";
            this.lblExtracteDate.Size = new System.Drawing.Size(18, 22);
            this.lblExtracteDate.TabIndex = 183;
            this.lblExtracteDate.Text = "-";
            this.lblExtracteDate.Visible = false;
            // 
            // btnExtractRemmittance
            // 
            this.btnExtractRemmittance.BackColor = System.Drawing.Color.Transparent;
            this.btnExtractRemmittance.ForeColor = System.Drawing.Color.Black;
            this.btnExtractRemmittance.Location = new System.Drawing.Point(278, 294);
            this.btnExtractRemmittance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtractRemmittance.Name = "btnExtractRemmittance";
            this.btnExtractRemmittance.Size = new System.Drawing.Size(147, 49);
            this.btnExtractRemmittance.TabIndex = 182;
            this.btnExtractRemmittance.Text = "Extract";
            this.btnExtractRemmittance.UseVisualStyleBackColor = false;
            this.btnExtractRemmittance.Click += new System.EventHandler(this.btnExtractRemmittance_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(20, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 22);
            this.label4.TabIndex = 181;
            this.label4.Text = "Reference #:";
            // 
            // cboReferenceNo
            // 
            this.cboReferenceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReferenceNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboReferenceNo.FormattingEnabled = true;
            this.cboReferenceNo.Location = new System.Drawing.Point(24, 142);
            this.cboReferenceNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboReferenceNo.Name = "cboReferenceNo";
            this.cboReferenceNo.Size = new System.Drawing.Size(398, 33);
            this.cboReferenceNo.TabIndex = 180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 179;
            this.label2.Text = "Insurance:";
            // 
            // cboInsuranceType
            // 
            this.cboInsuranceType.AutoCompleteCustomSource.AddRange(new string[] {
            "Alpha",
            "Philam"});
            this.cboInsuranceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsuranceType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInsuranceType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboInsuranceType.FormattingEnabled = true;
            this.cboInsuranceType.Location = new System.Drawing.Point(24, 55);
            this.cboInsuranceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInsuranceType.Name = "cboInsuranceType";
            this.cboInsuranceType.Size = new System.Drawing.Size(398, 33);
            this.cboInsuranceType.TabIndex = 178;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblActivity);
            this.panel1.Controls.Add(this.lblPercentage);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 694);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 58);
            this.panel1.TabIndex = 159;
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.Location = new System.Drawing.Point(279, 18);
            this.lblActivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(29, 20);
            this.lblActivity.TabIndex = 309;
            this.lblActivity.Text = ".....";
            this.lblActivity.Visible = false;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(228, 18);
            this.lblPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(32, 20);
            this.lblPercentage.TabIndex = 308;
            this.lblPercentage.Text = "0%";
            this.lblPercentage.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 15);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(195, 31);
            this.progressBar1.TabIndex = 307;
            this.progressBar1.Visible = false;
            // 
            // frmLibertyRemmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 752);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmLibertyRemmit";
            this.Text = "frmLibertyRemmit";
            this.Load += new System.EventHandler(this.frmLibertyRemmit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMembers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelExtractInfo.ResumeLayout(false);
            this.panelExtractInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtRemCode;
        public System.Windows.Forms.DataGridView dtMembers;
        private System.Windows.Forms.Label totalUnremitted;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkExcludeEx;
        private System.Windows.Forms.Panel panelExtractInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCollectedTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCollectedFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblExtracteDate;
        private System.Windows.Forms.Button btnExtractRemmittance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboReferenceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboInsuranceType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}