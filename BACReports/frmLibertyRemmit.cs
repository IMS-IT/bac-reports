using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace BACReports
{
    public partial class frmLibertyRemmit : Form
    {
        //DB Connection
        MySqlConnection mcon = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode + ";Command Timeout = 28800");
        MySqlCommand mcd;
        MySqlDataReader mdr;

        public frmLibertyRemmit()
        {
            InitializeComponent();
        }

        private void frmLibertyRemmit_Load(object sender, EventArgs e)
        {
            populateMonths();
            txtYear.Text = Reusable.getCurrentYear;
            generateRemCode();

            populateInsuranceType();
            populateReferenceNo();

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

        public void populateReferenceNo()
        {
            //cboRemmitFor.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add("", "-- Select --");

            mcon.Open();
            string q = "SELECT RCode FROM remittance_code WHERE Comp='LIBERTY' ORDER BY DtAdded DESC ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                comboSource.Add(mdr.GetString("RCode"), mdr.GetString("RCode"));
            }
            mdr.Close();
            mcon.Close();

            cboReferenceNo.DataSource = new BindingSource(comboSource, null);
            cboReferenceNo.DisplayMember = "Value";
            cboReferenceNo.ValueMember = "Key";

        }


        public void populateInsuranceType()
        {
            cboInsuranceType.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("Liberty", "Liberty");
            
            cboInsuranceType.DataSource = new BindingSource(comboSource, null);
            cboInsuranceType.DisplayMember = "Value";
            cboInsuranceType.ValueMember = "Key";

        }

        public void generateRemCode()
        {
            mcon.Open();
            string q = "SELECT CONCAT(DT,CT,'LBT') AS 'CODE' FROM ( SELECT REPLACE(CURDATE(),'-','') AS 'DT', COUNT(RCode)+1 AS 'CT' FROM remittance_code) AS A ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                txtRemCode.Text = mdr.GetString("CODE");
            }
            mdr.Close();
            mcon.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getUnremmitted();
        }

        public void getUnremmitted()
        {
            string comboMonthKey = ((KeyValuePair<string, string>)cboMonth.SelectedItem).Key;
            string comboMonthValue = ((KeyValuePair<string, string>)cboMonth.SelectedItem).Value;


            if (comboMonthKey == "")
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
                query = query + "if (coveredUntil is null, DATE_FORMAT(DATE_ADD(payment_period, INTERVAL 90 DAY), '%Y-%m-%d'), " +
                    "DATE_FORMAT(coveredUntil, '%Y-%m-%d')) as 'Covered Until', ";
                query = query + "if(dtreceived < '" + startDate + "','1','0') as latePosted ";
                query = query + "FROM payment_collection pc ";
                query = query + "INNER JOIN planholder ph ON pc.planholderid = ph.PlanholderID ";
                query = query + "INNER JOIN office o ON ph.officecode = o.OfficeCode ";
                query = query + "INNER JOIN plan_type pt ON ph.PlanTypeID = pt.PlanTypeID ";
                query = query + "WHERE pt.InsuranceID = 18 AND left(dtreceived,10) >= '2022-12-01' AND left(dtreceived,10) <= '" + endDate + "' ";
                query = query + "AND RemCode is null ";
                query = query + "AND ph.DtCancelled is null ";
                query = query + "AND o.terminatedaccts = 'N' ";
                query = query + "AND pt.classification = 'I' ";
                query = query + "AND pt.otherbenefitclass = 'I' ";
                query = query + "AND pt.upgrade <> 1 ";
                query = query + "AND pc.remarks = 'VALID' ";
                query = query + "GROUP BY pc.premium, payment_period, pc.planholderId "; //To avoid double posting issues
                
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
                // dtMembers.Columns[5].Visible = false;
                dtMembers.Columns[8].Visible = false;
                // dtMembers.Columns[9].Visible = false;

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

        public void disabledButtons()
        {
            btnExtract.Enabled = false;
            btnRefresh.Enabled = false;
            btnExtractRemmittance.Enabled = false;
        }

        public void enableButtons()
        {
            btnExtract.Enabled = true;
            btnRefresh.Enabled = true;
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
                    remitLiberty();
                }
            }
            else
            {
                validationMSG.Error(this, "There is no member(s) to remit!");
            }
        }

        public void remitLiberty()
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
                // string lastInstallment = row.Cells["lastInstallment"].Value.ToString();
                string paymentDate = row.Cells["Collection Date"].Value.ToString();
                string paymentPeriod = row.Cells["Payment Period"].Value.ToString();
                string insuranceId = row.Cells["insuranceId"].Value.ToString();
                int latePosted = Convert.ToInt32(row.Cells["latePosted"].Value.ToString());
                double premium = Convert.ToDouble(row.Cells["Premium"].Value.ToString());

                // string actionCode = "create";
                DateTime startCover = Convert.ToDateTime(row.Cells["Payment Period"].Value.ToString());
                

                

                //Update Payment Collection
                mcon.Open();
                query = "UPDATE payment_collection SET RemCode='" + txtRemCode.Text + "', Remmitted ='1' WHERE paymentCollectionID='" + paymentCollectionId + "' ";
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
            query = "INSERT INTO remittance_code SET RCode='" + txtRemCode.Text + "', Date_From='" + dateFrom + "', Date_To='" + dateTo + "', RemittedTo='INSURANCE',  Type='ALL', ItemType='STANDARD AND SUB-STANDARD', Comp='LIBERTY', TotCount='" + dtMembers.Rows.Count + "', DtAdded='" + Reusable.getCurrentDateTime + "', AddedBy='" + Reusable.getUserFullName + "'  ";
            mcd = new MySqlCommand(query, mcon);
            mcd.ExecuteReader();
            mcon.Close();

            // populateRemmitDates();

            validationMSG.Success(this, "Remmittance complete, Ref#: " + txtRemCode.Text);

            dtMembers.DataSource = null;
            dtMembers.Visible = false;
            lblMembers.Visible = false;
            totalUnremitted.Text = "0";

            generateRemCode();
            populateReferenceNo();
            enableButtons();
            hideIndicators();

        }

        private void btnExtractRemmittance_Click(object sender, EventArgs e)
        {
            string comboInsTypeKey = ((KeyValuePair<string, string>)cboInsuranceType.SelectedItem).Key;
            string comboInsTypeValue = ((KeyValuePair<string, string>)cboInsuranceType.SelectedItem).Value;

            string comboReferenceNoKey = ((KeyValuePair<string, string>)cboReferenceNo.SelectedItem).Key;
            string comboReferenceNoValue = ((KeyValuePair<string, string>)cboReferenceNo.SelectedItem).Value;
            
            if (comboReferenceNoKey == "")
            {
                validationMSG.Error(this, "Please select reference mo. to extract");
                cboReferenceNo.Focus();
            }
            else
            {
                extractRemmittance(comboInsTypeKey);
            }
        }

        private void extractRemmittance(String insType)
        {

            string comboReferenceNoKey = ((KeyValuePair<string, string>)cboReferenceNo.SelectedItem).Key;
            string comboReferenceNoValue = ((KeyValuePair<string, string>)cboReferenceNo.SelectedItem).Value;

            string fileName = insType + " Remmittance - " + comboReferenceNoValue;
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
                double HIBBen = 0.00;
                double HIBPrem = 0.00;
                double totalHIBPrem = 0.00;

                double lifeBen = 0.00;
                double lifePrem = 0.00;
                double totalLifePrem = 0.00;

                //Accident Death & Dismemberment
                double ADDBen = 0.00;
                double ADDPrem = 0.00;
                double TotalADDPrem = 0.00;

                //Accident Death & Dismemberment & Disability
                double ADDDBen = 0.00;
                double ADDDPrem = 0.00;
                double totalADDDPrem = 0.00;

                double burialBen = 0.00;
                double burialPrem = 0.00;
                double totalBurialPrem = 0.00;
                
                double unprovokedBen = 0.00;
                double unprovokedPrem = 0.00;
                double totalUnprovokedPrem = 0.00;

                double medreimBen = 0.00;
                double medreimPrem = 0.00;
                double totalMedreimPrem = 0.00;

                double motorCyclingBen = 0.00;
                double motorCyclingPrem = 0.00;
                double totalMotorCyclingPrem = 0.00;

                double fireAssistanceBen = 0.00;
                double fireAssistancePrem = 0.00;
                double totalFireAssistancePrem = 0.00;

                double totalTaxAmount = 0.00;
                //double subTotalRemmittance = 0.00;

                double taxPerc = 0.00;
                double taxAmount = 0.00;
                double totalAmount = 0.00;

                
                //Get Data Source
                string query = "SELECT o.officecode as corporateCode, o.maincode_desc as companyName, ";
                query = query + "certnum as certificateNumber, 'create' as actionCode,  'employee' as 'classification', ";
                query = query + "if (ph.civilstatus = 'si','single','') as 'status', ph.Membername as memberName, pt.paymentmethod as payMode, ";
                query = query + "DATE_FORMAT(BirthDate, '%m/%d/%Y') as birthDay, if (occupation is null,'',occupation) as occupation, ";
                query = query + "DATE_FORMAT(ph.EffectiveDate, '%m/%d/%Y') as effectivityDate, ";
                query = query + "DATE_FORMAT(payment_period, '%m/%d/%Y') as coverStartDate, ";
                query = query + "DATE_FORMAT(dtreceived, '%m/%d/%Y') as paymentDate, ";
                query = query + "DATE_FORMAT(DATE_ADD(payment_period, INTERVAL 1 YEAR), '%m/%d/%Y') as annualCoverEndDate, ";
                query = query + "if (pt.substandard = 1, 'standard','sub-standard') as insType, '17.70' as taxAmount, ";

                query = query + "HibPrem1, HibBen1, ADDDben1, ADDDprem1, unprovokedMurderben1, unprovokedMurderprem1, medReimben1, medReimprem1 ";

                query = query + "FROM payment_collection ri ";
                query = query + "INNER JOIN planholder ph ON ri.planholderId = ph.PlanholderID ";
                query = query + "INNER JOIN office o ON ph.officecode = o.OfficeCode ";
                query = query + "INNER JOIN plan_type pt ON ph.PlanTypeID = pt.PlanTypeID ";
                query = query + "WHERE RemCode='" + comboReferenceNoKey + "' ";

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
                ExcelSheet.Cells[2, "A"].Value = "ACCOUNT TYPE: ";
                ExcelSheet.Cells[3, "A"].Value = "COLLECTION DATE: ";
                ExcelSheet.Cells[4, "A"].Value = "REMITTANCE FOR: ";
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

                
                ExcelSheet.get_Range("Q7").Value = "HIB";
                ExcelSheet.get_Range("Q7:R7").Merge();
                ExcelSheet.Cells[8, "Q"].Value = "COVERAGE";
                ExcelSheet.get_Range("Q8:R8").Merge();


                ExcelSheet.get_Range("S7").Value = "UNPROVOKEDMURDER";
                ExcelSheet.get_Range("S7:T7").Merge();
                ExcelSheet.Cells[8, "S"].Value = "COVERAGE";
                ExcelSheet.get_Range("S8:T8").Merge();

                ExcelSheet.get_Range("U7").Value = "MEDREIM";
                ExcelSheet.get_Range("U7:V7").Merge();
                ExcelSheet.Cells[8, "U"].Value = "COVERAGE";
                ExcelSheet.get_Range("U8:V8").Merge();

                ExcelSheet.get_Range("W7").Value = "ADDD";
                ExcelSheet.get_Range("W7:X7").Merge();
                ExcelSheet.Cells[8, "W"].Value = "COVERAGE";
                ExcelSheet.get_Range("W8:X8").Merge();


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

                    HIBBen = Convert.ToDouble(row.Cells["HibPrem1"].Value.ToString());
                    HIBPrem = Convert.ToDouble(row.Cells["HibBen1"].Value.ToString());

                    unprovokedBen = Convert.ToDouble(row.Cells["unprovokedMurderben1"].Value.ToString());
                    unprovokedPrem = Convert.ToDouble(row.Cells["unprovokedMurderprem1"].Value.ToString());

                    medreimBen = Convert.ToDouble(row.Cells["medReimben1"].Value.ToString());
                    medreimPrem = Convert.ToDouble(row.Cells["medReimprem1"].Value.ToString());

                    ADDDBen = Convert.ToDouble(row.Cells["ADDDben1"].Value.ToString());
                    ADDDPrem = Convert.ToDouble(row.Cells["ADDDprem1"].Value.ToString());

                    string payMode = "annual";
                    string coverEndDate = row.Cells["annualCoverEndDate"].Value.ToString();
                    // string insuranceId = row.Cells["insuraceId"].Value.ToString();
                    

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

                    //HIB
                    ExcelSheet.Cells[x, "Q"].Value = HIBBen.ToString("N");
                    ExcelSheet.Range[ExcelSheet.Cells[x, "Q"], ExcelSheet.Cells[x, "R"]].Merge();


                    //Unprovoked
                    ExcelSheet.Cells[x, "S"].Value = unprovokedBen.ToString("N");
                    ExcelSheet.Range[ExcelSheet.Cells[x, "S"], ExcelSheet.Cells[x, "T"]].Merge();
                    //ExcelSheet.Cells[x, "T"].Value = unprovokedPrem.ToString("N");


                    //Medreim
                    ExcelSheet.Cells[x, "U"].Value = medreimBen.ToString("N");
                    ExcelSheet.Range[ExcelSheet.Cells[x, "U"], ExcelSheet.Cells[x, "V"]].Merge();
                    //ExcelSheet.Cells[x, "V"].Value = medreimPrem.ToString("N");


                    //ADDD
                    ExcelSheet.Cells[x, "W"].Value = ADDDBen.ToString("N");
                    ExcelSheet.Range[ExcelSheet.Cells[x, "W"], ExcelSheet.Cells[x, "X"]].Merge();
                    //ExcelSheet.Cells[x, "X"].Value = ADDDPrem.ToString("N");

                    totalHIBPrem = totalHIBPrem + HIBPrem;
                    totalUnprovokedPrem = totalUnprovokedPrem + unprovokedPrem;
                    totalMedreimPrem = totalMedreimPrem + medreimPrem;
                    totalADDDPrem = totalADDDPrem + ADDDPrem;

                    // ExcelSheet.Cells[x, "Z"].Value = "=SUM(R" + x + ",T" + x + ",V" + x + ",X" + x + ",Y" + x + ")";
                    
                    ExcelSheet.Cells[x, "Z"].Value = "92.80";

                    ExcelSheet.Cells[x, "Q"].NumberFormat = "#,##0.00";
                    //ExcelSheet.Cells[x, "R"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "S"].NumberFormat = "#,##0.00";
                    //ExcelSheet.Cells[x, "T"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "U"].NumberFormat = "#,##0.00";
                    //ExcelSheet.Cells[x, "V"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "W"].NumberFormat = "#,##0.00";
                    //ExcelSheet.Cells[x, "X"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "Y"].NumberFormat = "#,##0.00";
                    ExcelSheet.Cells[x, "Z"].NumberFormat = "#,##0.00";
                    ExcelSheet.get_Range("A" + x, "Z" + x).Borders.Color = Color.Black.ToArgb();

                    totalAmount = totalAmount + 92.80;
                    int presentage = (i * 100) / dtMembers.RowCount;
                    progressBar1.Value = i * 100 / dtMembers.RowCount;  //show process bar counts
                    lblActivity.Text = "Extracting...";
                    lblPercentage.Text = presentage.ToString() + " %";
                    i++;
                    x++;

                    FormUtils.wait(1);

                }
                
                ExcelSheet.Cells[x, "Y"].Value = totalTaxAmount.ToString("N");
                ExcelSheet.Cells[x, "Z"].Value = totalAmount.ToString("N");

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
                

                hideIndicators();
                enableButtons();


            }

        }
    }
}
