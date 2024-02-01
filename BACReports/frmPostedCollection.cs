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
    public partial class frmPostedCollection : Form
    {
        //DB Connection
        MySqlConnection mcon = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode);
        MySqlCommand mcd;
        MySqlDataReader mdr;

        //Filter Variables
        public string searchPlaceholder = "Search Company...";
        
        public frmPostedCollection()
        {
            InitializeComponent();
        }

        private void frmPostedCollection_Load(object sender, EventArgs e)
        {
            populateDateReference();
            populateAccounType();
            populateCenter();
            populateAccountStatus();

            dtpFrom.Value = Convert.ToDateTime(Reusable.getCurrentMonth + "-01");
            dtpTo.Value = FormUtils.GetMonthEndDate(dtpTo.Value);
        }

        public void populateDateReference()
        {
            cboDateReference.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            FormUtils.addDateReferenceOptions(comboSource, cboDateReference);

            cboDateReference.DataSource = new BindingSource(comboSource, null);
            cboDateReference.DisplayMember = "Value";
            cboDateReference.ValueMember = "Key";

        }

        public void populateAccounType()
        {
            cboAccountType.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add("", "All");

            mcon.Open();
            string q = "SELECT AccountType FROM office GROUP BY AccountType ORDER BY AccountType";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                comboSource.Add(mdr.GetString("AccountType"), mdr.GetString("AccountType"));
            }
            mdr.Close();
            mcon.Close();

            cboAccountType.DataSource = new BindingSource(comboSource, null);
            cboAccountType.DisplayMember = "Value";
            cboAccountType.ValueMember = "Key";

        }

        public void populateAccountStatus()
        {
            cboAccountStatus.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            FormUtils.addAccountStatusOptions(comboSource, cboAccountStatus);

            cboAccountStatus.DataSource = new BindingSource(comboSource, null);
            cboAccountStatus.DisplayMember = "Value";
            cboAccountStatus.ValueMember = "Key";

        }

        public void populateCenter()
        {
            cboCenter.DataSource = null;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add("", "All");

            mcon.Open();
            string q = "SELECT * FROM commission_branch WHERE branch_name != '' ";
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                comboSource.Add(mdr.GetString("branchID"), mdr.GetString("branch_name"));
            }
            mdr.Close();
            mcon.Close();

            cboCenter.DataSource = new BindingSource(comboSource, null);
            cboCenter.DisplayMember = "Value";
            cboCenter.ValueMember = "Key";

        }


        public void disabledButtons()
        {
            btnGenerate.Enabled = false;
        }

        public void endbleButtons()
        {
            btnGenerate.Enabled = true;
        }

        public void getTableRows()
        {

            disabledButtons();
            dtMembers.DataSource = null;
            dtMembers.Rows.Clear();

            string comboDateReferenceKey = ((KeyValuePair<string, string>)cboDateReference.SelectedItem).Key;
            string comboDateReferenceValue = ((KeyValuePair<string, string>)cboDateReference.SelectedItem).Value;

            string comboAccountTypeKey = ((KeyValuePair<string, string>)cboAccountType.SelectedItem).Key;
            string comboAccountTypeValue = ((KeyValuePair<string, string>)cboAccountType.SelectedItem).Value;

            string comboCenterKey = ((KeyValuePair<string, string>)cboCenter.SelectedItem).Key;
            string comboCenterValue = ((KeyValuePair<string, string>)cboCenter.SelectedItem).Value;

            string comboAccountStatusKey = ((KeyValuePair<string, string>)cboAccountStatus.SelectedItem).Key;
            string comboAccountStatusValue = ((KeyValuePair<string, string>)cboAccountStatus.SelectedItem).Value;

            mcon.Open();
            string query = "SELECT OfficeID, c.OfficeCode, MAINCODE, AccountType as 'Type', ";
            if (chkGroupBy.Checked == true)
            {
                query = query + "MAINCODE_DESC as Company, ";
                
            } else
            {

                query = query + "o.Classification as Company, ";
            }
                

            query = query + "FORMAT(premium, 2) as 'Premium', ifnull(sum(if (newstat != 'Y', 0, 1)), 0) as 'New', ifnull(sum(if(newstat = 'Y', 0, 1)), 0) as 'Existing', ";
            query = query + "count(*) as 'Total Accts', FORMAT(sum(premium), 2) as 'Total Premium' FROM payment_collection c ";
            query = query + "LEFT JOIN planholder p ON c.planholderid = p.PlanholderId ";
            query = query + "LEFT JOIN office o ON c.officecode = o.OfficeCode ";
            query = query + "LEFT JOIN agent_hierarchyid h ON p.hierarchyID = h.hierarchyid ";

            if (comboDateReferenceKey == "applicable-month")
            {
                query = query + "WHERE payment_period >= '" + DateUtils.Format(dtpFrom.Text, "yyyy-MM-dd") + "' AND payment_period <= '" + DateUtils.Format(dtpTo.Text, "yyyy-MM-dd") + "' ";
            }
            else if (comboDateReferenceKey == "collection-date")
            {
                query = query + "WHERE dtreceived >= '" + DateUtils.Format(dtpFrom.Text, "yyyy-MM-dd") + "' AND dtreceived <= '" + DateUtils.Format(dtpTo.Text, "yyyy-MM-dd") + "' ";
            }
            else 
            {
                query = query + "WHERE left(processdate,10) >= '" + DateUtils.Format(dtpFrom.Text, "yyyy-MM-dd") + "' AND left(processdate,10) <= '" + DateUtils.Format(dtpTo.Text, "yyyy-MM-dd") + "' ";
            }


            if (comboAccountTypeKey != "")
            {
                query = query + "AND AccountType = '" + comboAccountTypeKey + "' ";
            }

            if (comboCenterKey != "")
            {
                query = query + "AND branchID = '" + comboCenterKey + "' ";
            }

            if (txtSearch.Text != searchPlaceholder) 
            {
                query = query + "AND o.Classification like '%" + txtSearch.Text + "%' ";
            }

            if (comboAccountStatusKey == "Existing")
            {
                query = query + "AND newstat != 'Y' ";
            }
            else if (comboAccountStatusKey == "New")
            {
                query = query + "AND newstat = 'Y' ";
            }
            else
            {
                //None
            }
            
            if(chkGroupBy.Checked == true)
            {
                query = query + "GROUP BY MAINCODE, premium  ";
            } else
            {
                query = query + "GROUP BY c.OfficeCode, premium  ";
            }
            
            query = query + "ORDER BY Company, premium  ";
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
            dtMembers.Columns[3].Width = 50;
            dtMembers.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtMembers.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMembers.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMembers.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMembers.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            //Get Sub Total
            int subTotalNew = 0;
            int subTotalExisting = 0;
            int subTotalAccts = 0;
            double subTotalCollection = 0.00;

            foreach (DataGridViewRow row in dtMembers.Rows)
            {
                subTotalNew = subTotalNew + Convert.ToInt32(row.Cells["New"].Value.ToString());
                subTotalExisting = subTotalExisting + Convert.ToInt32(row.Cells["Existing"].Value.ToString());
                subTotalAccts = subTotalAccts + Convert.ToInt32(row.Cells["Total Accts"].Value.ToString());
                subTotalCollection = subTotalCollection + Convert.ToDouble(row.Cells["Total Premium"].Value.ToString());
            }

            lblSubTotalCollection.Text = subTotalCollection.ToString("N");


            mcon.Close();
            endbleButtons();
        }
        
        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == searchPlaceholder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;

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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getTableRows();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            getTableRows();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int numRows = dtMembers.Rows.Count;
            if (numRows > 0)
            {
                
                string fileName = "Collection Reports - " + Reusable.getCurrentDate;
                saveFileDialog1.InitialDirectory = @"C:\\";
                saveFileDialog1.Title = "Save As Excel File";
                saveFileDialog1.FileName = fileName;
                saveFileDialog1.Filter = "Excel Files (2007) |*.xlsx|Excel Files (2003)|*.xls";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    showIndicators();

                    Microsoft.Office.Interop.Excel.Application ExcelApp =
                    new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook ExcelBook;
                    Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;

                    int i = 0;
                    int j = 0;
                    int colheadstart = 3;

                    //create object of excel
                    ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
                    ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;
                    ExcelSheet.Name = "Sheet1";

                    //Report Title
                    ExcelSheet.Cells[1, "A"].Value2 = fileName;
                    ExcelSheet.get_Range("A1", "D1").Merge();
                    ExcelSheet.get_Range("A1", "D1").Font.Bold = true;

                    //Col. Header
                    int x = 1; //Visible Col. Counter
                    for (i = 1; i <= this.dtMembers.Columns.Count; i++)
                    {
                        if (this.dtMembers.Columns[i - 1].Visible == true)
                        {
                            ExcelSheet.Cells[colheadstart, x] = this.dtMembers.Columns[i - 1].HeaderText;
                            ExcelSheet.Cells[colheadstart, x].Borders.Color = System.Drawing.Color.Black.ToArgb();
                            ExcelSheet.Cells[colheadstart, x].Font.Bold = true;
                            x = x + 1;
                        }

                    }

                    //Row Content
                    for (i = 1; i <= this.dtMembers.RowCount; i++)
                    {
                        int y = 1; //Visible Col. Counter
                        for (j = 1; j <= dtMembers.Columns.Count; j++)
                        {

                            if (dtMembers.Rows[i - 1].Cells[j - 1].Visible == true)
                            {
                                ExcelSheet.Cells[i + colheadstart, y] = dtMembers.Rows[i - 1].Cells[j - 1].Value;
                                ExcelSheet.Cells[i + colheadstart, y].Borders.Color = System.Drawing.Color.Black.ToArgb();
                                y = y + 1;
                            }
                        }

                        //Progress Bar Indicator Start
                        int presentage = (i * 100) / this.dtMembers.RowCount;
                        progressBar1.Value = i * 100 / this.dtMembers.RowCount;  //show process bar counts
                        lblActivity.Text = "Exporting...";
                        lblPercentage.Text = presentage.ToString() + " %";

                    }

                    ExcelSheet.Cells[i + colheadstart, 7] = lblSubTotalCollection.Text.ToString();
                    ExcelSheet.Cells[i + colheadstart, 7].Font.Bold = true;

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
                }
            }
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
    }
}
