using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace BACReports
{
    public partial class frmC4StarRemmit : Form
    {
        //DB Connection
        MySqlConnection mcon = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode + ";Command Timeout = 28800");
        MySqlCommand mcd;
        MySqlDataReader mdr;

        MySqlConnection mcon2 = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode + ";Command Timeout = 28800");
        MySqlCommand mcd2;
        MySqlDataReader mdr2;

        public string searchPlaceholder = "Search Member...";

        public frmC4StarRemmit()
        {
            InitializeComponent();
        }

        private void frmC4StarRemit_Load(object sender, EventArgs e)
        {
            populateMonths();
            txtYear.Text = Reusable.getCurrentYear;
            generateRemCode();

            populateInsuranceType();
            populateRefno();
            
            dtpFrom.Value = Convert.ToDateTime(Reusable.getCurrentMonth + "-01");
            dtpTo.Value = FormUtils.GetMonthEndDate(dtpTo.Value);

        }

        public void populateMonths()
        {
            cboMonth.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("", "-- Select --");
            FormUtils.addMonthsOptions(comboSource, cboMonth);

            cboMonth.DataSource = new BindingSource(comboSource, null);
            cboMonth.DisplayMember = "Value";
            cboMonth.ValueMember = "Key";

            cboMonth.SelectedValue = Reusable.getCurrentMonth;

        }

        public void populateInsuranceType()
        {
            cboInsuranceType.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("Philam", "Philam");
            comboSource.Add("Alpha", "Alpha");
            
            cboInsuranceType.DataSource = new BindingSource(comboSource, null);
            cboInsuranceType.DisplayMember = "Value";
            cboInsuranceType.ValueMember = "Key";
            
        }

        public void populateRefno()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            mcon.Open();
            string q = "SELECT RCode FROM remittance_code WHERE RCode like '%C4M%' ORDER BY RCode DESC ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                comboSource.Add(mdr.GetString("RCode"), mdr.GetString("RCode"));
            }
            mdr.Close();
            mcon.Close();

            cboRefNo.DataSource = new BindingSource(comboSource, null);
            cboRefNo.DisplayMember = "Value";
            cboRefNo.ValueMember = "Key";

            cboRefNo.SelectedIndex = 0;
        }

        public void populateRemmitDates()
        {
            //cboRemmitFor.DataSource = null;

            string RCode = ((KeyValuePair<string, string>)cboRefNo.SelectedItem).Key;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add("", "-- Select --");
           

            mcon.Open();
            string q = "SELECT Rcode, DATE_FORMAT(coverFrom, '%Y-%m') as cfKey, DATE_FORMAT(coverFrom, ' %Y %b') as cfVal, if(extractedDate is null,'R','') as exd FROM remittance_installments WHERE RCode = '"+ RCode + "' GROUP BY left(coverFrom,7), left(extractedDate,7) ";
            
            if (cboInsuranceType.Text == "Alpha")
            {
                
                //Annual Only
                // q = "SELECT RCode, DATE_FORMAT(Date_From, '%Y-%m') as cfKey, DATE_FORMAT(Date_From, '%Y %b') as cfVal FROM remittance_code WHERE RCode like '%C4M%'  GROUP BY cfKey ";
                q = "SELECT RCODE, DATE_FORMAT(coverFrom, '%Y-%m') as cfKey, DATE_FORMAT(coverFrom, '%Y %b') as cfVal FROM remittance_installments WHERE RCode = '" + RCode + "' AND yrStart=1 GROUP BY cfKey ";
                
            }
            q = q + "ORDER BY cfKey ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                if (cboInsuranceType.Text == "Alpha")
                {
                    comboSource.Add(mdr.GetString("cfKey") + "/" + mdr.GetString("RCODE"), mdr.GetString("cfVal"));
                }
                else
                {
                    comboSource.Add(mdr.GetString("cfKey") + "*" + mdr.GetString("exd") + "/" + mdr.GetString("RCODE"), mdr.GetString("cfVal"));
                }
                    
            }
            mdr.Close();
            mcon.Close();
            
            cboRemmitFor.DataSource = new BindingSource(comboSource, null);
            cboRemmitFor.DisplayMember = "Value";
            cboRemmitFor.ValueMember = "Key";

        }

        public void populateCutOff()
        {
            cboCutOff.DataSource = null;
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("", "-- Select --");
            if (cboRemmitFor.Items.Count > 0)
            {
                string remittanceFor = ((KeyValuePair<string, string>)cboRemmitFor.SelectedItem).Key;
                
                mcon.Open();
                string q = "SELECT DATE_FORMAT(Date_from, '%Y-%m-%d') as collFrom,  DATE_FORMAT(Date_To, '%Y-%m-%d') as collTo, ri.RCode as RCode FROM remittance_installments ri ";
                q = q + "LEFT JOIN remittance_code rc ON ri.RCode = rc.RCode ";

                string coverFrom = "";
                string rcode = "";
                
                if (cboInsuranceType.Text == "Alpha")
                {
                   

                    if (remittanceFor != "")
                    {
                        string[] remit = remittanceFor.Split('/');
                        coverFrom = remit[0];
                        rcode = remit[1];
                    }

                    q = q + "WHERE DATE_FORMAT(coverFrom, '%Y-%m') = '" + coverFrom + "' AND ri.RCODE='"+ rcode + "' AND yrstart=1 ";
                    q = q + "GROUP BY collFrom ";

                }
                else
                {

                    if (remittanceFor != "")
                    {
                        string[] remit = remittanceFor.Split('/');
                        coverFrom = remit[0];
                        rcode = remit[1];
                    }

                    
                    if (coverFrom.Contains("*R"))
                    {
                        coverFrom = coverFrom.Replace("*R", "");
                        coverFrom = coverFrom.Replace("*", "");

                        q = q + "WHERE DATE_FORMAT(coverFrom, '%Y-%m') = '" + coverFrom + "' ";
                        q = q + "AND ri.RCode = '" + rcode + "' ";
                        q = q + "AND extractedDate is null ";
                        q = q + "GROUP BY ri.RCode ";
                    }
                    else
                    {
                        coverFrom = coverFrom.Replace("*", "");
                        q = q + "WHERE DATE_FORMAT(coverFrom, '%Y-%m') = '" + coverFrom + "' ";
                        q = q + "AND ri.RCode = '" + rcode + "' ";
                        q = q + "AND extractedDate is not null ";
                        q = q + "GROUP BY ri.RCode ";
                    }
                }
                
                mcd = new MySqlCommand(q, mcon);
                mdr = mcd.ExecuteReader();
                while (mdr.Read())
                {
                    comboSource.Add(mdr.GetString("RCode"), mdr.GetString("collFrom") + " to " + mdr.GetString("collTo"));
                }
                mdr.Close();
                mcon.Close();
            }

            cboCutOff.DataSource = new BindingSource(comboSource, null);
            cboCutOff.DisplayMember = "Value";
            cboCutOff.ValueMember = "Key";

        }

        public void generateRemCode()
        {
            mcon.Open();
            string q = "SELECT CONCAT(DT,CT,'C4M') AS 'CODE' FROM ( SELECT REPLACE(CURDATE(),'-','') AS 'DT', COUNT(RCode)+1 AS 'CT' FROM remittance_code) AS A ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                txtRemCode.Text = mdr.GetString("CODE");
            }
            mdr.Close();
            mcon.Close();
        }
        
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            totalUnremitted.Text = "0";
        }


        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getUnremmitted();
            totalUnremitted.Text = "0";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getUnremmitted();
        }
        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (Convert.ToUInt32(totalUnremitted.Text) > 0)
            {
                string message = "Are you sure you want to continue ?";
                string caption = "Start Remmittance";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    disabledButtons();
                    remitC4();
                }
            }
            else
            {
                validationMSG.Error(this, "There is no member(s) to remit!");
            }
        }
        public void getUnremmitted()
        {
            string comboMonthKey = ((KeyValuePair<string, string>)cboMonth.SelectedItem).Key;
            string comboMonthValue = ((KeyValuePair<string, string>)cboMonth.SelectedItem).Value;
            
            
            if(comboMonthKey == "")
            {
                validationMSG.Error(this, "Please select month");
                cboMonth.Focus();
            }
            else 
            {

                disabledButtons();
                FormUtils.wait(1000);

                string startDate = dtpFrom.Text;
                string endDate = dtpTo.Text;

                //Check next start date
                /*
                mcon.Open();
                string query = "SELECT DATE_FORMAT(DATE_ADD(Date_To, INTERVAL 1 DAY), '%Y-%m-%d') as nextStartDate FROM remittance_code WHERE RCode like '%C4M%' and Type='C4' ORDER BY RCID DESC LIMIT 1 ";
                mcd = new MySqlCommand(query, mcon);
                mdr = mcd.ExecuteReader();
                while (mdr.Read())
                {
                    startDate = mdr.GetString("nextStartDate");
                }
                mdr.Close();
                mcon.Close();

                int lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(txtYear.Text), Convert.ToInt32(comboMonthValue.TrimStart('0')));
                */
                
                //START - Check Unremmitted
                mcon.Open();

                string query = "SELECT paymentCollectionID, pc.planholderid as planholderId, pt.InsuranceID as insuranceId, ";
                query = query + "ph.MemberName as 'Member', REPLACE(FORMAT(pc.premium, 2), ',', '') as 'Premium', ";
                query = query + "DATE_FORMAT(dtreceived, '%Y-%m-%d') as 'Collection Date', ";
                query = query + "DATE_FORMAT(payment_period, '%Y-%m-%d') as 'Payment Period', ";
                //query = query + "DATE_FORMAT(EffectiveDate, '%Y-%m-%d') as 'Effective Date', ";
                //query = query + "DATE_FORMAT(coveredUntil, '%Y-%m-%d') as 'Covered Until',  ";
                query = query + "if (coveredUntil is null, DATE_FORMAT(DATE_ADD(payment_period, INTERVAL 90 DAY), '%Y-%m-%d'), " +
                    "DATE_FORMAT(coveredUntil, '%Y-%m-%d')) as 'Covered Until', ";
                query = query + "if(" +
                    "(SELECT coverTo FROM remittance_installments WHERE planholderId = pc.planholderid ORDER BY coverTo DESC LIMIT 1) is not null," +
                    "(SELECT coverTo FROM remittance_installments WHERE planholderId = pc.planholderid ORDER BY coverTo DESC LIMIT 1)" +
                    ",'') as lastInstallment, ";
                query = query + "if(dtreceived < '"+ startDate + "','1','0') as latePosted ";
                query = query + "FROM payment_collection pc ";
                query = query + "INNER JOIN planholder ph ON pc.planholderid = ph.PlanholderID ";
                query = query + "INNER JOIN office o ON ph.officecode = o.OfficeCode ";
                query = query + "INNER JOIN plan_type pt ON ph.PlanTypeID = pt.PlanTypeID ";
                // query = query + "WHERE pt.InsuranceID = 16 AND left(dtreceived,10) >= '2022-12-01' AND left(dtreceived,10) <= '" + endDate + "' ";
                query = query + "WHERE pt.InsuranceID = 16 AND left(dtreceived,10) >= '2023-10-01' AND left(dtreceived,10) <= '" + endDate + "' ";
                query = query + "AND remcode_c4 is null ";
                query = query + "AND ph.DtCancelled is null ";
                query = query + "AND o.terminatedaccts = 'N' ";
                query = query + "AND pt.classification = 'I' ";
                query = query + "AND pt.otherbenefitclass = 'I' ";
                query = query + "AND pt.upgrade <> 1 ";
                query = query + "AND pc.remarks = 'VALID' ";
                // query = query + "AND ph.MemberName = 'PUNSALAN, LUZ MANALOTO' ";
                query = query + "GROUP BY pc.premium, payment_period, pc.planholderId "; //To avoid double posting issues
                //query = query + "AND pc.planholderid = '959732' ";
                //query = query + "HAVING DATE_FORMAT(payment_period,'%Y-%m') >= renewalPeriod ";
                //query = query + "HAVING lastInstallment = '' ";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, mcon);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dtMembers.DataSource = ds.Tables[0].DefaultView;
                dtMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtMembers.RowsDefaultCellStyle.BackColor = Color.White;
                dtMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;


                dtMembers.Columns[0].Visible = false;
                dtMembers.Columns[1].Visible = false;
                dtMembers.Columns[2].Visible = false;
                dtMembers.Columns[3].Width = 200;
                dtMembers.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dtMembers.Columns[5].Visible = false;
                dtMembers.Columns[8].Visible = false;
                dtMembers.Columns[9].Visible = false;

                mcon.Close();

                totalUnremitted.Text = dtMembers.Rows.Count.ToString();
                if (dtMembers.Rows.Count > 0)
                {
                    dtMembers.Visible = true;
                    lblMembers.Visible = true;
                }
                else
                {
                    dtMembers.Visible = false;
                    lblMembers.Visible = false;
                }

                enableButtons();

            }
        }

        public void remitC4()
        {
            dtMembers.Visible = false;

            string comboMonthKey = ((KeyValuePair<string, string>)cboMonth.SelectedItem).Key;
            string comboMonthValue = ((KeyValuePair<string, string>)cboMonth.SelectedItem).Value;

            //string dateFrom = txtYear.Text + "-" + comboMonthKey + "-01";
            //string dateTo = txtYear.Text + "-" + comboMonthKey + "-01";
            string dateFrom = dtpFrom.Text;
            string dateTo = dtpTo.Text;
            string query;

            int i = 1;

            showIndicators();
            FormUtils.wait(1000); //1 Second

            foreach (DataGridViewRow row in dtMembers.Rows)
            {

                string paymentCollectionId = row.Cells["paymentCollectionID"].Value.ToString();
                string planholderId = row.Cells["planholderId"].Value.ToString();
                string coveredUntil = row.Cells["Covered Until"].Value.ToString();
                string lastInstallment = row.Cells["lastInstallment"].Value.ToString();
                string paymentDate = row.Cells["Collection Date"].Value.ToString();
                string paymentPeriod = row.Cells["Payment Period"].Value.ToString();
                string insuranceId = row.Cells["insuranceId"].Value.ToString();
                int latePosted = Convert.ToInt32(row.Cells["latePosted"].Value.ToString());
                double premium = Convert.ToDouble(row.Cells["Premium"].Value.ToString());

                string actionCode = "create";
                int yrStart = 1;

                DateTime startCover = Convert.ToDateTime(row.Cells["Payment Period"].Value.ToString());
                if(lastInstallment != "")
                {
                    startCover = Convert.ToDateTime(lastInstallment);
                    actionCode = "maintain";
                    yrStart = 0;
                }

                //Check last cover on installments


                int insCount = 3;
                
                //Insert Installments
                for (int a = 0; a < insCount; a++)
                {

                    //DateTime coverFrom = dtPaymentPeriod.AddMonths(1).ToString("yyyy-MM-dd");
                    DateTime coverFrom = startCover;
                    DateTime coverTo = startCover.AddMonths(1);

                    mcon.Open();
                    query = "INSERT INTO remittance_installments SET " +
                        "RCode='" + txtRemCode.Text + "', " +
                        "paymentCollectionID='" + paymentCollectionId + "', " +
                        "planholderId='" + planholderId + "', " +
                        "coverFrom='" + coverFrom.ToString("yyyy-MM-dd") + "', " +
                        "coverTo='" + coverTo.ToString("yyyy-MM-dd") + "', " +
                        "insuranceId='" + insuranceId + "', " +
                        "actionCode='" + actionCode + "', " +
                        "yrStart='" + yrStart + "', " +
                        "latePosted='" + latePosted + "', " +
                        "paymentDate='" + paymentDate + "', " +
                        "extractedDate=NOW() ";
                    mcd = new MySqlCommand(query, mcon);
                    mcd.ExecuteReader();
                    mcon.Close();


                    startCover = coverTo;
                    if(actionCode == "create")
                    {
                        actionCode = "maintain";
                        yrStart = 0;
                    }
                    
                }

                //Update Payment Collection
                mcon.Open();
                query = "UPDATE payment_collection SET remcode_c4='" + txtRemCode.Text + "', remmitted_c4 = "+ insCount + " WHERE paymentCollectionID='" + paymentCollectionId + "' ";
                //query = "UPDATE payment_collection SET remcode_c4='" + txtRemCode.Text + "', remmitted_c4 = " + insCount + " WHERE planholderid='" + planholderId + "' AND payment_period='"+ paymentPeriod + "' AND premium='"+ premium + "' "; //Tag same record cause by double posting
                mcd = new MySqlCommand(query, mcon);
                mcd.ExecuteReader();
                mcon.Close();


                //Insert loan renewal date
                //mcon.Open();
                //query = "INSERT INTO loan_renewals SET planholderId='" + planholderId + "', paymentCollectionId='" + paymentCollectionId + "', renewalDate='" + coveredUntil + "' ";
                //mcd = new MySqlCommand(query, mcon);
                //mcd.ExecuteReader();
                //mcon.Close();


                //Progress Bar Indicator Start
                int presentage = (i * 100) / dtMembers.RowCount;
                progressBar1.Value = i * 100 / dtMembers.RowCount;  //show process bar counts
                lblActivity.Text = "Processing...";
                lblPercentage.Text = presentage.ToString() + " %";
                i++;
                FormUtils.wait(1); //1 Millisecond
            }

            //Insert remcode
            mcon.Open();
            query = "INSERT INTO remittance_code SET RCode='" + txtRemCode.Text + "', Date_From='" + dateFrom + "', Date_To='" + dateTo + "', RemittedTo='C4', Type='C4', TotCount='" + dtMembers.Rows.Count + "', DtAdded='" + Reusable.getCurrentDateTime + "', AddedBy='" + Reusable.getUserFullName + "'  ";
            mcd = new MySqlCommand(query, mcon);
            mcd.ExecuteReader();
            mcon.Close();

            // populateRemmitDates();
            populateRefno();

            validationMSG.Success(this, "Remmittance complete, Ref#: " + txtRemCode.Text);

            dtMembers.DataSource = null;
            dtMembers.Visible = false;
            lblMembers.Visible = false;
            totalUnremitted.Text = "0";

            generateRemCode();
            enableButtons();
            hideIndicators();

        }

        public void extractExcelC4()
        {
            //Extract Excel
        }

        public void disabledButtons()
        {
            btnExtract.Enabled = false;
            btnRefresh.Enabled = false;
            btnLoadData.Enabled = false;
            btnExport.Enabled = false;
            btnExtractRemmittance.Enabled = false;
        }

        public void enableButtons()
        {
            btnExtract.Enabled = true;
            btnRefresh.Enabled = true;
            btnLoadData.Enabled = true;
            btnExport.Enabled = true;
            btnExtractRemmittance.Enabled = true;
        }

        private void showIndicators()
        {
            progressBar1.Visible = true;
            lblActivity.Visible = true;
            lblPercentage.Visible = true;

        }

        private void hideIndicators()
        {
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            lblActivity.Visible = false;
            lblActivity.Text = "";
            lblPercentage.Text = "0 %";
            lblPercentage.Visible = false;

        }

        private void loadDataMonitoring()
        {
            disabledButtons();
            FormUtils.wait(1000);

            //START - Check Unremmitted
            mcon.Open();
            string query = "SELECT " +
                "ph.Membername as 'Member', " +
                "DATE_FORMAT(ph.EffectiveDate, '%m/%d/%Y') as 'Effectivity Date', " +
                "DATE_FORMAT(paymentDate, '%m/%d/%Y') as 'Payment Date', " +
                "DATE_FORMAT(coverFrom, '%m/%d/%Y') as 'Cover Start', " +
                "DATE_FORMAT(coverTo, '%m/%d/%Y') as 'Cover End', " +
                "RCode " +
                "FROM remittance_installments ri " +
                "INNER JOIN planholder ph ON ri.planholderId = ph.PlanholderID " +
                "INNER JOIN office o ON ph.officecode = o.OfficeCode " +
                "INNER JOIN plan_type pt ON ph.PlanTypeID = pt.PlanTypeID ";
                if (txtSearch.Text != searchPlaceholder && txtSearch.Text != "")
                {
                    query = query + "WHERE ph.Membername like '%" + txtSearch.Text.Replace("'", "''") + "%' ";
                }
            query = query + "ORDER BY memberName, paymentDate, coverFrom ";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, mcon);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtMonitoring.DataSource = ds.Tables[0].DefaultView;
            dtMonitoring.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtMonitoring.RowsDefaultCellStyle.BackColor = Color.White;
            dtMonitoring.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;
            
            //dtMonitoring.Columns[0].Visible = false;
            //dtMonitoring.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mcon.Close();

            lblTotalRecords.Text = Convert.ToInt32(dtMonitoring.Rows.Count).ToString();
            enableButtons();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            loadDataMonitoring();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == searchPlaceholder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;

            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadDataMonitoring();
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = searchPlaceholder;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int numRows = dtMonitoring.Rows.Count;
            if (numRows > 0)
            {

                string fileName = "C4 Star Loan Renewal Monitoring - " + Reusable.getCurrentDate;
                saveFileDialog1.InitialDirectory = @"C:\\";
                saveFileDialog1.Title = "Save As Excel File";
                saveFileDialog1.FileName = fileName;
                saveFileDialog1.Filter = "Excel Files (2007) |*.xlsx|Excel Files (2003)|*.xls";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    showIndicators();
                    disabledButtons();
                    
                    Excel.Application ExcelApp =
                    new Excel.Application();
                    Excel._Workbook ExcelBook;
                    Excel._Worksheet ExcelSheet;

                    int i = 0;
                    int j = 0;
                    int colheadstart = 3;

                    //create object of excel
                    ExcelBook = ExcelApp.Workbooks.Add(1);
                    ExcelSheet = (Excel._Worksheet)ExcelBook.ActiveSheet;
                    ExcelSheet.Name = "Sheet1";

                    //Report Title
                    ExcelSheet.Cells[1, "A"].Value2 = fileName;
                    ExcelSheet.get_Range("A1", "D1").Merge();
                    ExcelSheet.get_Range("A1", "D1").Font.Bold = true;

                    //Col. Header
                    int x = 1; //Visible Col. Counter
                    for (i = 1; i <= this.dtMonitoring.Columns.Count; i++)
                    {
                        if (this.dtMonitoring.Columns[i - 1].Visible == true)
                        {
                            ExcelSheet.Cells[colheadstart, x] = this.dtMonitoring.Columns[i - 1].HeaderText;
                            ExcelSheet.Cells[colheadstart, x].Borders.Color = System.Drawing.Color.Black.ToArgb();
                            ExcelSheet.Cells[colheadstart, x].Font.Bold = true;
                            x = x + 1;
                        }

                    }

                    //Row Content
                    for (i = 1; i <= this.dtMonitoring.RowCount; i++)
                    {
                        int y = 1; //Visible Col. Counter
                        for (j = 1; j <= dtMonitoring.Columns.Count; j++)
                        {

                            if (dtMonitoring.Rows[i - 1].Cells[j - 1].Visible == true)
                            {
                                ExcelSheet.Cells[i + colheadstart, y] = dtMonitoring.Rows[i - 1].Cells[j - 1].Value;
                                ExcelSheet.Cells[i + colheadstart, y].Borders.Color = System.Drawing.Color.Black.ToArgb();
                                y = y + 1;
                            }
                        }
                        
                        //Progress Bar Indicator Start
                        int presentage = (i * 100) / this.dtMonitoring.RowCount;
                        progressBar1.Value = i * 100 / this.dtMonitoring.RowCount;  //show process bar counts
                        lblActivity.Text = "Exporting...";
                        lblPercentage.Text = presentage.ToString() + " %";
                        FormUtils.wait(1);


                    }

                    //ExcelSheet.Cells[i + colheadstart, 7] = lblSubTotalCollection.Text.ToString();
                    //ExcelSheet.Cells[i + colheadstart, 7].Font.Bold = true;

                    Excel.Range usedRange = ExcelSheet.UsedRange;
                    Excel.Range rows = usedRange.Rows;

                    //Excel Format
                    ExcelSheet.Columns.Font.Name = "Calibri";
                    ExcelSheet.Columns.Font.Size = 10;
                    ExcelSheet.Columns.AutoFit();
                    ExcelSheet.Rows.RowHeight = 15;

                    ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                    ExcelApp.Visible = true;
                    ExcelApp.UserControl = false;

                    hideIndicators();
                    enableButtons();
                }
            }
        }

        private void btnExtractRemmittance_Click(object sender, EventArgs e)
        {
            string comboInsTypeKey = ((KeyValuePair<string, string>)cboInsuranceType.SelectedItem).Key;
            string comboInsTypeValue = ((KeyValuePair<string, string>)cboInsuranceType.SelectedItem).Value;

            string comboRemmitDateKey = ((KeyValuePair<string, string>)cboRemmitFor.SelectedItem).Key;
            string comboRemmitDateValue = ((KeyValuePair<string, string>)cboRemmitFor.SelectedItem).Value;

            string comboCutOffKey = ((KeyValuePair<string, string>)cboCutOff.SelectedItem).Key;
            string comboCutOffValue = ((KeyValuePair<string, string>)cboCutOff.SelectedItem).Value;

            if (comboRemmitDateKey == "")
            {
                validationMSG.Error(this, "Please select select month you want to extract");
                cboRemmitFor.Focus();
            }
            else if (comboCutOffKey == "")
            {
                validationMSG.Error(this, "Please select select collectio cut-offf you want to extract");
                cboRemmitFor.Focus();
            }
            else
            {
                extractRemmittance(comboInsTypeKey);
            }
            
        }

        private void extractRemmittance(String insType)
        {
            
            string comboRemmiForKey = ((KeyValuePair<string, string>)cboRemmitFor.SelectedItem).Key;
            string comboRemmitForValue = ((KeyValuePair<string, string>)cboRemmitFor.SelectedItem).Value;
            comboRemmitForValue = comboRemmitForValue.Replace("*R","");
            comboRemmitForValue = comboRemmitForValue.Replace("*", "");
            comboRemmiForKey = comboRemmiForKey.Replace("*R", "");
            comboRemmiForKey = comboRemmiForKey.Replace("*", "");

            string[] remit = comboRemmiForKey.Split('/');
            string coverFrom = remit[0];


            string comboCutOffKey = ((KeyValuePair<string, string>)cboCutOff.SelectedItem).Key;
            string comboCutOffValue = ((KeyValuePair<string, string>)cboCutOff.SelectedItem).Value;

            string fileName = insType + " Remmittance V2 - " + comboRemmitForValue + " Collected From " + comboCutOffValue;
            if (comboCutOffValue == "All")
            {
                fileName = insType + " Remmittance V2 - Collected From " + comboCutOffValue;
            }
            saveFileDialog1.InitialDirectory = @"C:\\";
            saveFileDialog1.Title = "Save As Excel File";
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.Filter = "Excel Files (2007) |*.xlsx|Excel Files (2003)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {

                showIndicators();
                disabledButtons();
                FormUtils.wait(1000);

                //Get Insurance Coverage
                double philamHIBBen = 0.00;
                double philamHIBPrem = 0.00;
                double philamTotalHIBPrem = 0.00;

                double philamLifeBen = 0.00;
                double philamLifePrem = 0.00;
                double philamTotalLifePrem = 0.00;

                double philamADDBen = 0.00;
                double philamADDPrem = 0.00;
                double philamTotalADDPrem = 0.00;


                double philamBurialBen = 0.00;
                double philamBurialPrem = 0.00;
                double philamTotalBurialPrem = 0.00;

                double alphaADDBen = 0.00;
                double alphaADDPrem = 0.00;
                double alphaTotalADDPrem = 0.00;

                double alphaUnprovokedBen = 0.00;
                double alphaUnprovodedPrem = 0.00;
                double alphaTotalUnprovodedPrem = 0.00;

                double alphaMedreimBen = 0.00;
                double alphaMedreimPrem = 0.00;
                double alphaTotalMedreimPrem = 0.00;

                double alphaMotorCyclingBen = 0.00;
                double alphaMotorCyclingPrem = 0.00;
                double alphaTotalMotorCyclingPrem = 0.00;

                double totalTaxAmount = 0.00;
                //double subTotalRemmittance = 0.00;

                double taxPerc = 0.00;
                double taxAmount = 0.00;

                mcon.Open();
                string query = "SELECT ir.InsuranceID, Classification as remmitClass, benefit, insuranceBenefit, insurancePremium FROM multipleinsurance mi ";
                query = query + "LEFT JOIN insurancebenefit ib ON mi.insuranceBenefitId = ib.insuranceBenefitId ";
                query = query + "LEFT JOIN insurance ir ON mi.plan_insuranceId = ir.InsuranceID ";
                query = query + "WHERE mi.insuranceId = 16 ";
                mcd = new MySqlCommand(query, mcon);
                mdr = mcd.ExecuteReader();
                while (mdr.Read())
                {
                    

                    if (insType == "Philam")
                    {

                        if (mdr.GetString("BENEFIT") == "LIFE")
                        {
                            philamLifeBen = Convert.ToDouble(mdr.GetString("insuranceBenefit"));
                            philamLifePrem = Convert.ToDouble(mdr.GetString("insurancePremium")) / 3;
                        }
                        

                        if (mdr.GetString("BENEFIT") == "BURIAL")
                        {
                            philamBurialBen = Convert.ToDouble(mdr.GetString("insuranceBenefit"));
                            philamBurialPrem = Convert.ToDouble(mdr.GetString("insurancePremium")) / 3;
                        }

                    }

                    if(insType == "Alpha")
                    {
                        if (mdr.GetString("BENEFIT") == "ADD")
                        {
                            alphaADDBen = Convert.ToDouble(mdr.GetString("insuranceBenefit"));
                            alphaADDPrem = Convert.ToDouble(mdr.GetString("insurancePremium"));
                        }

                        if (mdr.GetString("BENEFIT") == "UNPROVOKEDMURDER")
                        {
                            alphaUnprovokedBen = Convert.ToDouble(mdr.GetString("insuranceBenefit"));
                            alphaUnprovodedPrem = Convert.ToDouble(mdr.GetString("insurancePremium"));
                        }

                        if (mdr.GetString("BENEFIT") == "MEDREIM")
                        {
                            alphaMedreimBen = Convert.ToDouble(mdr.GetString("insuranceBenefit"));
                            alphaMedreimPrem = Convert.ToDouble(mdr.GetString("insurancePremium"));
                        }

                        if (mdr.GetString("BENEFIT") == "MOTORCYCLING")
                        {
                            alphaMotorCyclingBen = Convert.ToDouble(mdr.GetString("insuranceBenefit"));
                            alphaMotorCyclingPrem = Convert.ToDouble(mdr.GetString("insurancePremium"));
                        }
                            
                    }

                }
                mdr.Close();
                mcon.Close();


                //query = "SELECT o.officecode as corporateCode, o.maincode_desc as companyName,  certnum as certificateNumber, ";
                //query = query + "pt.paymentmethod as payMode, if (pc.newstat = 'y','create','maintain') as actionCode, ";
                //query = query + "'employee' as 'classification', if (ph.civilstatus = 'si','single','') as 'status', pc.Membername as memberName, ";
                //query = query + "DATE_FORMAT(BirthDate, '%m/%d/%Y') as birthDay, if(occupation is null,'',occupation) as occupation,  ";
                //query = query + "DATE_FORMAT(ph.EffectiveDate, '%m/%d/%Y') as effectivityDate, DATE_FORMAT(payment_period, '%m/%d/%Y') as coverStartDate, ";
                //query = query + "DATE_FORMAT(DATE_ADD(payment_period, INTERVAL 1 MONTH), '%m/%d/%Y') as monthlyCoverEndDate, ";
                //query = query + "DATE_FORMAT(DATE_ADD(payment_period, INTERVAL 1 YEAR), '%m/%d/%Y') as annualCoverEndDate, ";
                //query = query + "if (pt.substandard = 1, 'standard','sub-standard') as insType, '17.70' as taxAmount, pt.InsuranceID as insuraceId ";
                //query = query + "FROM payment_collection pc ";
                //query = query + "INNER JOIN planholder ph ON pc.planholderid = ph.PlanholderID ";
                //query = query + "INNER JOIN office o ON ph.officecode = o.OfficeCode ";
                //query = query + "INNER JOIN plan_type pt ON ph.PlanTypeID = pt.PlanTypeID ";
                //query = query + "WHERE remcode_c4 = '" + comboRemmitDateKey + "' ";

                //Get Data Source
                query = "SELECT o.officecode as corporateCode, o.maincode_desc as companyName, ri.InsuranceID as insuraceId, ";
                query = query + "certnum as certificateNumber, actionCode,  'employee' as 'classification', ";
                query = query + "if (ph.civilstatus = 'si','single','') as 'status', ph.Membername as memberName, pt.paymentmethod as payMode, ";
                query = query + "DATE_FORMAT(BirthDate, '%m/%d/%Y') as birthDay, if (occupation is null,'',occupation) as occupation, ";
                query = query + "DATE_FORMAT(ph.EffectiveDate, '%m/%d/%Y') as effectivityDate, ";
                query = query + "DATE_FORMAT(coverFrom, '%m/%d/%Y') as coverStartDate, ";
                query = query + "DATE_FORMAT(coverTo, '%m/%d/%Y') as monthlyCoverEndDate, ";
                query = query + "DATE_FORMAT(paymentDate, '%m/%d/%Y') as paymentDate, ";
                query = query + "DATE_FORMAT(DATE_ADD(coverFrom, INTERVAL 1 YEAR), '%m/%d/%Y') as annualCoverEndDate, ";
                query = query + "if (pt.substandard = 1, 'standard','sub-standard') as insType, '17.70' as taxAmount ";
                query = query + "FROM remittance_installments ri ";
                query = query + "INNER JOIN planholder ph ON ri.planholderId = ph.PlanholderID ";
                query = query + "INNER JOIN office o ON ph.officecode = o.OfficeCode ";
                query = query + "INNER JOIN plan_type pt ON ph.PlanTypeID = pt.PlanTypeID ";
                query = query + "WHERE DATE_FORMAT(coverFrom,'%Y-%m') = '" + coverFrom + "' AND RCode='" + comboCutOffKey + "' ";
                
                if (insType == "Alpha")
                {
                    //Extract Unremmitted/late posted before system 1.0.7 update
                    //query = query + "WHERE DATE_FORMAT(coverFrom,'%Y-%m') = '2022-12' AND RCode='" + comboCutOffKey + "' ";
                    //query = query + "WHERE DATE_FORMAT(coverFrom,'%Y-%m') = '2023-03' AND RCode='" + comboCutOffKey + "' ";
                    query = query + "AND yrStart=1 ";
                }

                MySqlDataAdapter sda = new MySqlDataAdapter(query, mcon);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dtMembers.DataSource = ds.Tables[0].DefaultView;

                //Initialize Excel Class
                Excel.Application ExcelApp =
                new Excel.Application();
                Excel._Workbook ExcelBook;
                Excel._Worksheet ExcelSheet;

                ExcelBook = (Excel._Workbook)ExcelApp.Workbooks.Add(1);
                ExcelSheet = (Excel._Worksheet)ExcelBook.ActiveSheet;
                ExcelSheet.Name = "Sheet1";


                //Add Header
                ExcelSheet.Cells[1, "A"].Value = "COMPANY: " + insType.ToUpper();
                ExcelSheet.Cells[2, "A"].Value = "ACCOUNT TYPE: C4";
                ExcelSheet.Cells[3, "A"].Value = "COLLECTION DATE: " + comboCutOffValue;
                ExcelSheet.Cells[4, "A"].Value = "REMITTANCE FOR: " + comboRemmitForValue;
                ExcelSheet.get_Range("A1", "A4").Font.Bold = true;

                ExcelSheet.get_Range("A5", "Z8").Font.Bold = true;
                ExcelSheet.get_Range("A5", "Z8").Font.Color = Color.White;
                ExcelSheet.get_Range("A5", "Z8").Interior.Color = Color.DarkRed;
                ExcelSheet.get_Range("A5", "Z8").Borders.Color = Color.Black.ToArgb();
                ExcelSheet.get_Range("A5", "Z8").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ExcelSheet.get_Range("A5", "Z8").VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                
                ExcelSheet.get_Range("A5").Value = "NO";
                ExcelSheet.get_Range("A5:A8").Merge();

                ExcelSheet.get_Range("B5").Value = "CORPORATE CODE";
                ExcelSheet.get_Range("B5:B8").Merge();


                ExcelSheet.get_Range("C5").Value = "COMPANY NAME";
                ExcelSheet.get_Range("C5:C8").Merge();

                ExcelSheet.get_Range("D5").Value = "CERTIFICATE NO.";
                ExcelSheet.get_Range("D5:D8").Merge();

                ExcelSheet.get_Range("E5").Value = "MODE OF PAYMENT";
                ExcelSheet.get_Range("E5:E8").Merge();


                ExcelSheet.get_Range("F5").Value = "ACTION CODE";
                ExcelSheet.get_Range("F5:F8").Merge();

                ExcelSheet.get_Range("G5").Value = "CLASSIFICATION";
                ExcelSheet.get_Range("G5:G8").Merge();

                ExcelSheet.get_Range("H5").Value = "STATUS";
                ExcelSheet.get_Range("H5:H8").Merge();

                ExcelSheet.get_Range("I5").Value = "NAME OF EMPLOYEE";
                ExcelSheet.get_Range("I5:K7").Merge();

                ExcelSheet.Cells[8, "I"].Value = "LAST NAME";
                ExcelSheet.Cells[8, "J"].Value = "FIRST NAME";
                ExcelSheet.Cells[8, "K"].Value = "MIDDLE NAME";

                ExcelSheet.get_Range("L5").Value = "DATE OF BIRTH (Mo/Day/Year)";
                ExcelSheet.get_Range("L5:L8").Merge();

                ExcelSheet.get_Range("M5").Value = "OCCUPATION";
                ExcelSheet.get_Range("M5:M8").Merge();

                ExcelSheet.get_Range("N5").Value = "EFFECTIVE DATE";
                ExcelSheet.get_Range("N5:N8").Merge();

                ExcelSheet.get_Range("O5").Value = "PAYMENT COVERAGE";
                ExcelSheet.get_Range("O5:P7").Merge();

                ExcelSheet.Cells[8, "O"].Value = "FROM";
                ExcelSheet.Cells[8, "P"].Value = "TO";

                ExcelSheet.get_Range("Q5").Value = "PREMIUM";
                ExcelSheet.get_Range("Q5:X5").Merge();

                ExcelSheet.get_Range("Q6").Value = "STANDARD / SUB-STANDARD";
                ExcelSheet.get_Range("Q6:X6").Merge();
                
                if (insType == "Alpha")
                {

                    ExcelSheet.get_Range("Q7").Value = "ADD";
                    ExcelSheet.get_Range("Q7:R7").Merge();
                    ExcelSheet.Cells[8, "Q"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "R"].Value = "PREMIUM";

                    ExcelSheet.get_Range("S7").Value = "UNPROVOKEDMURDER";
                    ExcelSheet.get_Range("S7:T7").Merge();
                    ExcelSheet.Cells[8, "S"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "T"].Value = "PREMIUM";

                    ExcelSheet.get_Range("U7").Value = "MEDREIM";
                    ExcelSheet.get_Range("U7:V7").Merge();
                    ExcelSheet.Cells[8, "U"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "V"].Value = "PREMIUM";

                    ExcelSheet.get_Range("W7").Value = "MOTORCYCLING";
                    ExcelSheet.get_Range("W7:X7").Merge();
                    ExcelSheet.Cells[8, "W"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "X"].Value = "PREMIUM";

                }

                if (insType == "Philam")
                {

                    ExcelSheet.get_Range("Q7").Value = "HISP INC";
                    ExcelSheet.get_Range("Q7:R7").Merge();
                    ExcelSheet.Cells[8, "Q"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "R"].Value = "PREMIUM";

                    ExcelSheet.get_Range("S7").Value = "LIFE";
                    ExcelSheet.get_Range("S7:T7").Merge();
                    ExcelSheet.Cells[8, "S"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "T"].Value = "PREMIUM";

                    ExcelSheet.get_Range("U7").Value = "ADD";
                    ExcelSheet.get_Range("U7:V7").Merge();
                    ExcelSheet.Cells[8, "U"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "V"].Value = "PREMIUM";

                    ExcelSheet.get_Range("W7").Value = "BURIAL";
                    ExcelSheet.get_Range("W7:X7").Merge();
                    ExcelSheet.Cells[8, "W"].Value = "COVERAGE";
                    ExcelSheet.Cells[8, "X"].Value = "PREMIUM";
                    
                }

                
                ExcelSheet.get_Range("Y5", "Z6").Borders.Color = Color.DarkRed;
                ExcelSheet.get_Range("Y7:Y8").Merge();
                ExcelSheet.Cells[7, "Y"].Value = "TAX";
                ExcelSheet.get_Range("Z7:Z8").Merge();
                ExcelSheet.get_Range("Z7:Z8").WrapText = true;
                ExcelSheet.Cells[7, "Z"].Value = "TOTAL REMITTANCE";
                
                
                //Add Table Rows
                Excel.Range usedRange = ExcelSheet.UsedRange;
                Excel.Range rows = usedRange.Rows;
                int i = 1;
                int x = 9;

                foreach (DataGridViewRow row in dtMembers.Rows)
                {
                    
                    //string paymentCollectionId = row.Cells["paymentCollectionID"].Value.ToString();
                    //string planholderId = row.Cells["planholderId"].Value.ToString();
                    //string newRenewalDate = row.Cells["Renewal Period"].Value.ToString();

                    string payMode = "monthly";
                    string coverEndDate = row.Cells["monthlyCoverEndDate"].Value.ToString();
                    string insuranceId = row.Cells["insuraceId"].Value.ToString();

                    if (insType == "Alpha")
                    {
                        payMode = "annual";
                        coverEndDate = row.Cells["annualCoverEndDate"].Value.ToString();
                    }

                    string[] fullName = row.Cells["memberName"].Value.ToString().Split(',');
                    string lastName = fullName[0].Trim();
                    string firstName = fullName[1].Trim();
                    string middleName = "";


                    ExcelSheet.Cells[x, "A"].Value = i.ToString();
                    ExcelSheet.Cells[x, "A"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ExcelSheet.Cells[x, "A"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ExcelSheet.Cells[x, "B"].Value = row.Cells["corporateCode"].Value.ToString();
                    ExcelSheet.Cells[x, "B"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    ExcelSheet.Cells[x, "B"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ExcelSheet.Cells[x, "C"].Value = row.Cells["companyName"].Value.ToString();
                    ExcelSheet.Cells[x, "D"].Value = row.Cells["certificateNumber"].Value.ToString();
                    ExcelSheet.Cells[x, "E"].Value = payMode;
                    ExcelSheet.Cells[x, "F"].Value = row.Cells["actionCode"].Value.ToString();
                    ExcelSheet.Cells[x, "G"].Value = row.Cells["classification"].Value.ToString();
                    ExcelSheet.Cells[x, "H"].Value = row.Cells["status"].Value.ToString();
                    ExcelSheet.Cells[x, "I"].Value = lastName;
                    ExcelSheet.Cells[x, "J"].Value = firstName;
                    ExcelSheet.Cells[x, "K"].Value = middleName;

                    ExcelSheet.Cells[x, "L"].Value = row.Cells["birthDay"].Value.ToString();
                    ExcelSheet.Cells[x, "L"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    ExcelSheet.Cells[x, "L"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ExcelSheet.Cells[x, "M"].Value = row.Cells["occupation"].Value.ToString();

                    ExcelSheet.Cells[x, "N"].Value = row.Cells["effectivityDate"].Value.ToString();
                    ExcelSheet.Cells[x, "N"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    ExcelSheet.Cells[x, "N"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ExcelSheet.Cells[x, "O"].Value = row.Cells["coverStartDate"].Value.ToString(); 
                    ExcelSheet.Cells[x, "O"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    ExcelSheet.Cells[x, "O"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ExcelSheet.Cells[x, "P"].Value = coverEndDate;
                    ExcelSheet.Cells[x, "P"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    ExcelSheet.Cells[x, "P"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    if (insType == "Alpha")
                    {
                        //ADD
                        ExcelSheet.Cells[x, "Q"].Value = alphaADDBen.ToString("N");
                        ExcelSheet.Cells[x, "R"].Value = alphaADDPrem.ToString("N");


                        //Unprovoked Murder
                        ExcelSheet.Cells[x, "S"].Value = alphaUnprovokedBen.ToString("N");
                        ExcelSheet.Cells[x, "T"].Value = alphaUnprovodedPrem.ToString("N");


                        //Medreim
                        ExcelSheet.Cells[x, "U"].Value = alphaMedreimBen.ToString("N");
                        ExcelSheet.Cells[x, "V"].Value = alphaMedreimPrem.ToString("N");


                        //Motorcyling
                        ExcelSheet.Cells[x, "W"].Value = alphaMotorCyclingBen.ToString("N");
                        ExcelSheet.Cells[x, "X"].Value = alphaMotorCyclingPrem.ToString("N");
                        
                        alphaTotalADDPrem = alphaTotalADDPrem + alphaADDPrem;
                        alphaTotalUnprovodedPrem = alphaTotalUnprovodedPrem + alphaUnprovodedPrem;
                        alphaTotalMedreimPrem = alphaTotalMedreimPrem + alphaMedreimPrem;
                        alphaTotalMotorCyclingPrem = alphaTotalMotorCyclingPrem + alphaMotorCyclingPrem;

                    }

                    if (insType == "Philam")
                    {
                        //HIB
                        ExcelSheet.Cells[x, "Q"].Value = philamHIBBen.ToString("N");
                        ExcelSheet.Cells[x, "R"].Value = philamHIBPrem.ToString("N");
                        

                        //Life
                        ExcelSheet.Cells[x, "S"].Value = philamLifeBen.ToString("N");
                        ExcelSheet.Cells[x, "T"].Value = philamLifePrem.ToString("N");
                        

                        //ADD
                        ExcelSheet.Cells[x, "U"].Value = philamADDBen.ToString("N");
                        ExcelSheet.Cells[x, "V"].Value = philamADDPrem.ToString("N");
                        
                        
                        //Burial
                        ExcelSheet.Cells[x, "W"].Value = philamBurialBen.ToString("N");
                        ExcelSheet.Cells[x, "X"].Value = philamBurialPrem.ToString("N");

                        philamTotalHIBPrem = philamTotalHIBPrem + philamHIBPrem;
                        philamTotalLifePrem = philamTotalLifePrem + philamLifePrem;
                        philamTotalADDPrem = philamTotalADDPrem + philamADDPrem;
                        philamTotalBurialPrem = philamTotalBurialPrem + philamBurialPrem;

                    }

                    if (insType == "Philam")
                    {
                        ExcelSheet.Cells[x, "Y"].Value = 0.00;
                        totalTaxAmount = totalTaxAmount + 0.00;
                    }
                    else
                    {
                        taxPerc = Convert.ToDouble(row.Cells["taxAmount"].Value) / 100;
                        taxAmount = alphaADDPrem + alphaUnprovodedPrem + alphaMedreimPrem + alphaMotorCyclingPrem;
                        taxAmount = taxAmount * taxPerc;
                        
                        ExcelSheet.Cells[x, "Y"].Value = taxAmount.ToString();
                        totalTaxAmount = totalTaxAmount + taxAmount;
                    }
                    
                    ExcelSheet.Cells[x, "Z"].Value = "=SUM(R"+x+",T"+x+",V"+x+",X"+x+",Y"+x+")";
                    
                    ExcelSheet.Cells[x, "Q"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "R"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "S"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "T"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "U"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "V"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "W"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "X"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "Y"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "Z"].NumberFormat = "#,##0.00";
                    ExcelSheet.get_Range("A"+x, "Z"+x).Borders.Color = Color.Black.ToArgb();

                    int presentage = (i * 100) / dtMembers.RowCount;
                    progressBar1.Value = i * 100 / dtMembers.RowCount;  //show process bar counts
                    lblActivity.Text = "Extracting...";
                    lblPercentage.Text = presentage.ToString() + " %";
                    i++;
                    x++;

                    FormUtils.wait(1);
                    
                }

                if(insType == "Alpha")
                {
                    ExcelSheet.Cells[x, "R"].Value = alphaTotalADDPrem.ToString("N");
                    ExcelSheet.Cells[x, "T"].Value = alphaTotalUnprovodedPrem.ToString("N");
                    ExcelSheet.Cells[x, "V"].Value = alphaTotalMedreimPrem.ToString("N");
                    ExcelSheet.Cells[x, "X"].Value = alphaTotalMotorCyclingPrem.ToString("N");
                }


                if (insType == "Philam")
                {
                    ExcelSheet.Cells[x, "R"].Value = philamTotalHIBPrem.ToString("N");
                    ExcelSheet.Cells[x, "T"].Value = philamTotalLifePrem.ToString("N");
                    ExcelSheet.Cells[x, "V"].Value = philamTotalADDPrem.ToString("N");
                    ExcelSheet.Cells[x, "X"].Value = philamTotalBurialPrem.ToString("N");
                }

                ExcelSheet.Cells[x, "Y"].Value = totalTaxAmount.ToString("N");
                ExcelSheet.Cells[x, "Z"].Value = "=SUM(R" + x + ",T" + x + ",V" + x + ",X" + x + ",Y" + x + ")";
                
                ExcelSheet.get_Range("O" + x + ":P" + x).Merge();
                ExcelSheet.get_Range("O" + x, "Z" + x).Interior.Color = Color.Yellow;
                ExcelSheet.get_Range("A" + x, "Z" + x).Font.Bold = true;
                ExcelSheet.get_Range("A" + x, "Z" + x).Borders.Color = Color.Black.ToArgb();
                ExcelSheet.get_Range("A" + x, "Z" + x).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                ExcelSheet.get_Range("A" + x, "Z" + x).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ExcelSheet.get_Range("A" + x, "Z" + x).NumberFormat = "#,##0.00";

                ExcelSheet.Cells[x, "O"].value = "TOTAL";
                ExcelSheet.Cells[x, "O"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ExcelSheet.Cells[x, "O"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //Excel Format
                ExcelSheet.Columns.Font.Name = "Calibri";
                ExcelSheet.Columns.Font.Size = 10;
                ExcelSheet.Columns.AutoFit();
                ExcelSheet.Rows.RowHeight = 15;

                ExcelSheet.Cells[5, "A"].ColumnWidth = 6; //Total Remittance
                ExcelSheet.Cells[7, "Z"].ColumnWidth = 11; //Total Remittance


                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.Visible = true;
                ExcelApp.UserControl = false;

                //mcon.Open();
                //query = "UPDATE remittance_installments SET extractedDate='" + Reusable.getCurrentDateTime + "', extractedBy = " + Reusable.getUserID + ", extractedFor='"+ insType + "' WHERE DATE_FORMAT(coverFrom,'%Y-%m') = '" + comboRemmiForKey + "' AND extractedDate is null ";
                //mcd = new MySqlCommand(query, mcon);
                //mcd.ExecuteReader();
                //mcon.Close();

                hideIndicators();
                enableButtons();


            }
            
        }

        private void cboRemmitDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (cboRemmitDate.Items.Count > 0)
            {
                string comboRemmitDateKey = ((KeyValuePair<string, string>)cboRemmitDate.SelectedItem).Key;
                string comboRemmitDateValue = ((KeyValuePair<string, string>)cboRemmitDate.SelectedItem).Value;

                mcon.Open();
                string q = "SELECT ";
                q = q + "DATE_FORMAT(Date_From, '%Y-%m-%d') as collectedFrom, ";
                q = q + "DATE_FORMAT(Date_To, '%Y-%m-%d') as collectedTo, ";
                q = q + "DATE_FORMAT(DtAdded, '%Y-%m-%d') as remmitDate ";
                q = q + "FROM remittance_code ";
                q = q + "WHERE RCode = '" + comboRemmitDateKey + "' ";
                mcd = new MySqlCommand(q, mcon);
                mdr = mcd.ExecuteReader();
                while (mdr.Read())
                {
                    lblExtracteDate.Text = mdr.GetString("remmitDate");
                    lblCollectedFrom.Text = mdr.GetString("collectedFrom");
                    lblCollectedTo.Text = mdr.GetString("collectedTo");
                }
                mdr.Close();
                mcon.Close();

                panelExtractInfo.Visible = true;
            }
            else
            {
                lblExtracteDate.Text = "-";
                lblCollectedFrom.Text = "-";
                lblCollectedTo.Text = "-";

                panelExtractInfo.Visible = false;
            }
            
            if (cboRemmitFor.Items.Count > 0) {
                populateCutOff();
            }
            */
            populateCutOff();
        }

        private void cboInsuranceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateRefno();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string RCode = "20231113833C4M";
            string planholderId = "";
            int monthDiff = 0;

            mcon.Open();
            string q = "SELECT *, " +
                "TIMESTAMPDIFF(MONTH, coverFrom, paymentDate) AS monthDiff " +
                "FROM remittance_installments WHERE RCode='"+ RCode + "' " +
                "AND coverFrom >= '2023-06-01' AND coverFrom <= '2023-08-30'  " +
                "ORDER BY planholderId, coverFrom ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                
                string id = mdr.GetString("id").ToString();
                if(planholderId != mdr.GetString("planholderId").ToString())
                {
                    mcon2.Open();
                    q = "SELECT TIMESTAMPDIFF(MONTH, coverFrom, paymentDate) AS monthDiff FROM remittance_installments WHERE " +
                        "planholderId = '" + mdr.GetString("planholderId").ToString() + "' " +
                        "AND RCode = '" + RCode + "' " +
                        "ORDER BY id LIMIT 1 ";
                    mcd2 = new MySqlCommand(q, mcon2);
                    mdr2 = mcd2.ExecuteReader();
                    while (mdr2.Read())
                    {
                        monthDiff = Convert.ToInt32(mdr2.GetString("monthDiff"));
                    }
                    mdr2.Close();
                    mcon2.Close();

                    planholderId = mdr.GetString("planholderId").ToString();
                }
                
                //DateTime coverFrom = dtPaymentPeriod.AddMonths(1).ToString("yyyy-MM-dd");
                DateTime coverFrom = Convert.ToDateTime(mdr.GetString("coverFrom").ToString()).AddMonths(monthDiff);
                DateTime coverTo = coverFrom.AddMonths(1);

                mcon2.Open();
                q = "UPDATE remittance_installments SET coverFrom='" + coverFrom.ToString("yyyy-MM-dd") + "', coverTo='" + coverTo.ToString("yyyy-MM-dd") + "', reapply=1  WHERE id='" + id + "' ";
                mcd2 = new MySqlCommand(q, mcon2);
                mcd2.ExecuteReader();
                mcon2.Close();

            }
            mdr.Close();
            mcon.Close();
        }

        private void cboRefNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateRemmitDates();
        }
    }
}
