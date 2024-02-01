namespace BACReports
{
    partial class frmC4StarVerification
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInsuranceProvider = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEffectivityDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLoanRenewal = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblMonthsEnrolled = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCoveredUntil = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPayor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPlanholder = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtPayments = new System.Windows.Forms.DataGridView();
            this.dgPlanholder = new System.Windows.Forms.DataGridView();
            this.memname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDependents = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtInsuranceBenefits = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDependents)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInsuranceBenefits)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(18, 18);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(700, 31);
            this.txtSearch.TabIndex = 55;
            this.txtSearch.Text = "Search Member...";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblInsuranceProvider);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblEffectivityDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblLoanRenewal);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblMonthsEnrolled);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblCoveredUntil);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblOccupation);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblSex);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblBirthDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCardNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblPayor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPlanholder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(702, 709);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // lblInsuranceProvider
            // 
            this.lblInsuranceProvider.AutoSize = true;
            this.lblInsuranceProvider.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsuranceProvider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInsuranceProvider.Location = new System.Drawing.Point(231, 517);
            this.lblInsuranceProvider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInsuranceProvider.Name = "lblInsuranceProvider";
            this.lblInsuranceProvider.Size = new System.Drawing.Size(43, 22);
            this.lblInsuranceProvider.TabIndex = 167;
            this.lblInsuranceProvider.Text = "N/A";
            this.lblInsuranceProvider.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(27, 517);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 22);
            this.label14.TabIndex = 166;
            this.label14.Text = "Insurance Provider:";
            this.label14.Visible = false;
            // 
            // lblEffectivityDate
            // 
            this.lblEffectivityDate.AutoSize = true;
            this.lblEffectivityDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEffectivityDate.Location = new System.Drawing.Point(231, 443);
            this.lblEffectivityDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEffectivityDate.Name = "lblEffectivityDate";
            this.lblEffectivityDate.Size = new System.Drawing.Size(43, 22);
            this.lblEffectivityDate.TabIndex = 165;
            this.lblEffectivityDate.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(27, 443);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 22);
            this.label12.TabIndex = 164;
            this.label12.Text = "Effectivity Date:";
            // 
            // lblLoanRenewal
            // 
            this.lblLoanRenewal.AutoSize = true;
            this.lblLoanRenewal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanRenewal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLoanRenewal.Location = new System.Drawing.Point(231, 623);
            this.lblLoanRenewal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoanRenewal.Name = "lblLoanRenewal";
            this.lblLoanRenewal.Size = new System.Drawing.Size(43, 22);
            this.lblLoanRenewal.TabIndex = 163;
            this.lblLoanRenewal.Text = "N/A";
            this.lblLoanRenewal.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(27, 623);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 22);
            this.label15.TabIndex = 162;
            this.label15.Text = "Loan Renewal:";
            this.label15.Visible = false;
            // 
            // lblMonthsEnrolled
            // 
            this.lblMonthsEnrolled.AutoSize = true;
            this.lblMonthsEnrolled.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthsEnrolled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMonthsEnrolled.Location = new System.Drawing.Point(231, 583);
            this.lblMonthsEnrolled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthsEnrolled.Name = "lblMonthsEnrolled";
            this.lblMonthsEnrolled.Size = new System.Drawing.Size(43, 22);
            this.lblMonthsEnrolled.TabIndex = 161;
            this.lblMonthsEnrolled.Text = "N/A";
            this.lblMonthsEnrolled.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(27, 583);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 22);
            this.label13.TabIndex = 160;
            this.label13.Text = "Month(s) Enrolled:";
            this.label13.Visible = false;
            // 
            // lblCoveredUntil
            // 
            this.lblCoveredUntil.AutoSize = true;
            this.lblCoveredUntil.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoveredUntil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCoveredUntil.Location = new System.Drawing.Point(231, 478);
            this.lblCoveredUntil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCoveredUntil.Name = "lblCoveredUntil";
            this.lblCoveredUntil.Size = new System.Drawing.Size(43, 22);
            this.lblCoveredUntil.TabIndex = 159;
            this.lblCoveredUntil.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(27, 478);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 22);
            this.label11.TabIndex = 158;
            this.label11.Text = "Covered Until:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(231, 663);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 22);
            this.lblStatus.TabIndex = 157;
            this.lblStatus.Text = "N/A";
            this.lblStatus.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(27, 663);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 22);
            this.label10.TabIndex = 156;
            this.label10.Text = "Status:";
            this.label10.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOccupation.Location = new System.Drawing.Point(231, 252);
            this.lblOccupation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(43, 22);
            this.lblOccupation.TabIndex = 155;
            this.lblOccupation.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(27, 252);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 22);
            this.label9.TabIndex = 154;
            this.label9.Text = "Occupation:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSex.Location = new System.Drawing.Point(231, 214);
            this.lblSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(43, 22);
            this.lblSex.TabIndex = 153;
            this.lblSex.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(27, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 22);
            this.label6.TabIndex = 152;
            this.label6.Text = "Gender:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCompany.Location = new System.Drawing.Point(231, 355);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(43, 22);
            this.lblCompany.TabIndex = 151;
            this.lblCompany.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(27, 355);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 150;
            this.label2.Text = "Company:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddress.Location = new System.Drawing.Point(231, 134);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 22);
            this.lblAddress.TabIndex = 149;
            this.lblAddress.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(27, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 22);
            this.label4.TabIndex = 148;
            this.label4.Text = "Address:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBirthDate.Location = new System.Drawing.Point(231, 172);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(43, 22);
            this.lblBirthDate.TabIndex = 147;
            this.lblBirthDate.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(27, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 146;
            this.label1.Text = "Birth Date:";
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCardNo.Location = new System.Drawing.Point(231, 314);
            this.lblCardNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(43, 22);
            this.lblCardNo.TabIndex = 145;
            this.lblCardNo.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(27, 314);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 22);
            this.label8.TabIndex = 144;
            this.label8.Text = "Card No.:";
            // 
            // lblPayor
            // 
            this.lblPayor.AutoSize = true;
            this.lblPayor.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPayor.Location = new System.Drawing.Point(231, 95);
            this.lblPayor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayor.Name = "lblPayor";
            this.lblPayor.Size = new System.Drawing.Size(43, 22);
            this.lblPayor.TabIndex = 143;
            this.lblPayor.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(27, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 22);
            this.label7.TabIndex = 142;
            this.label7.Text = "Payor:";
            // 
            // lblPlanholder
            // 
            this.lblPlanholder.AutoSize = true;
            this.lblPlanholder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPlanholder.Location = new System.Drawing.Point(231, 58);
            this.lblPlanholder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlanholder.Name = "lblPlanholder";
            this.lblPlanholder.Size = new System.Drawing.Size(43, 22);
            this.lblPlanholder.TabIndex = 141;
            this.lblPlanholder.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(27, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 22);
            this.label5.TabIndex = 140;
            this.label5.Text = "Full Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtPayments);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(729, 406);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1036, 366);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment History";
            // 
            // dtPayments
            // 
            this.dtPayments.AllowUserToAddRows = false;
            this.dtPayments.AllowUserToDeleteRows = false;
            this.dtPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPayments.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtPayments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dtPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPayments.Location = new System.Drawing.Point(9, 34);
            this.dtPayments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtPayments.MultiSelect = false;
            this.dtPayments.Name = "dtPayments";
            this.dtPayments.ReadOnly = true;
            this.dtPayments.RowHeadersVisible = false;
            this.dtPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPayments.Size = new System.Drawing.Size(1018, 323);
            this.dtPayments.TabIndex = 54;
            // 
            // dgPlanholder
            // 
            this.dgPlanholder.AllowUserToAddRows = false;
            this.dgPlanholder.AllowUserToDeleteRows = false;
            this.dgPlanholder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPlanholder.BackgroundColor = System.Drawing.Color.White;
            this.dgPlanholder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgPlanholder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlanholder.ColumnHeadersVisible = false;
            this.dgPlanholder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.memname});
            this.dgPlanholder.Location = new System.Drawing.Point(18, 52);
            this.dgPlanholder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgPlanholder.MultiSelect = false;
            this.dgPlanholder.Name = "dgPlanholder";
            this.dgPlanholder.ReadOnly = true;
            this.dgPlanholder.RowHeadersVisible = false;
            this.dgPlanholder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgPlanholder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlanholder.Size = new System.Drawing.Size(702, 167);
            this.dgPlanholder.TabIndex = 150;
            this.dgPlanholder.Visible = false;
            this.dgPlanholder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPlanholder_KeyDown);
            // 
            // memname
            // 
            this.memname.HeaderText = "memname";
            this.memname.Name = "memname";
            this.memname.ReadOnly = true;
            this.memname.Visible = false;
            // 
            // dtDependents
            // 
            this.dtDependents.AllowUserToAddRows = false;
            this.dtDependents.AllowUserToDeleteRows = false;
            this.dtDependents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDependents.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtDependents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtDependents.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dtDependents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDependents.Location = new System.Drawing.Point(9, 11);
            this.dtDependents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDependents.MultiSelect = false;
            this.dtDependents.Name = "dtDependents";
            this.dtDependents.ReadOnly = true;
            this.dtDependents.RowHeadersVisible = false;
            this.dtDependents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDependents.Size = new System.Drawing.Size(998, 318);
            this.dtDependents.TabIndex = 54;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(738, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 378);
            this.tabControl1.TabIndex = 152;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtDependents);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1020, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Beneficiary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtInsuranceBenefits);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1020, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Insurance Benefits";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtInsuranceBenefits
            // 
            this.dtInsuranceBenefits.AllowUserToAddRows = false;
            this.dtInsuranceBenefits.AllowUserToDeleteRows = false;
            this.dtInsuranceBenefits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtInsuranceBenefits.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtInsuranceBenefits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtInsuranceBenefits.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dtInsuranceBenefits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtInsuranceBenefits.Location = new System.Drawing.Point(9, 11);
            this.dtInsuranceBenefits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtInsuranceBenefits.MultiSelect = false;
            this.dtInsuranceBenefits.Name = "dtInsuranceBenefits";
            this.dtInsuranceBenefits.ReadOnly = true;
            this.dtInsuranceBenefits.RowHeadersVisible = false;
            this.dtInsuranceBenefits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtInsuranceBenefits.Size = new System.Drawing.Size(998, 323);
            this.dtInsuranceBenefits.TabIndex = 55;
            // 
            // frmC4StarVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1784, 791);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgPlanholder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmC4StarVerification";
            this.Text = "frmC4StarMonitoring";
            this.Load += new System.EventHandler(this.frmC4StarVerification_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDependents)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtInsuranceBenefits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPayor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPlanholder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgPlanholder;
        private System.Windows.Forms.DataGridViewTextBoxColumn memname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DataGridView dtPayments;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMonthsEnrolled;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCoveredUntil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLoanRenewal;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.DataGridView dtDependents;
        private System.Windows.Forms.Label lblEffectivityDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblInsuranceProvider;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.DataGridView dtInsuranceBenefits;
    }
}