using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;


namespace BACReports
{
    public partial class frmC4StarVerification : Form
    {
        //DB Connection
        MySqlConnection mcon = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode);
        MySqlCommand mcd;
        MySqlDataReader mdr;

        MySqlConnection mcon2 = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode);
        MySqlCommand mcd2;
        MySqlDataReader mdr2;

        //Filter Variables
        public string searchPlaceholder = "Search Member...";

        public frmC4StarVerification()
        {
            InitializeComponent();
        }


        private void frmC4StarVerification_Load(object sender, EventArgs e)
        {

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
            if (e.KeyCode == Keys.Down)
            {
                dgPlanholder.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                //getPlanhoderInfo();
                autofillPlanholder();
            }
        }

        public void autofillPlanholder()
        {

            DataTable dt1 = new DataTable();
            MySqlDataAdapter mda = new MySqlDataAdapter();
            MySqlCommand cmd;


            var query = "SELECT Concat(MemberName, ' (', planholder.officecode, ' - PLAN: ', premium,' - ',if(covereduntil>=curdate(), 'ACTIVE','LAPSED'),')') as MemberName FROM planholder ";
            query = query + "INNER JOIN office on planholder.officecode = office.officecode ";
            query = query + "LEFT JOIN plan_type ON planholder.PlanTypeID = plan_type.PlanTypeID ";
            query = query + "WHERE MemberName like '" + txtSearch.Text + "%' AND terminatedaccts = 'N'  ";

            //query = query + "AND EffectiveDate is not null AND office.MAINCODE = 'CSKM.01' AND planholder.PlanTypeID = 2294 ";

            query = query + "GROUP BY planholder.PlanTypeID, MainPlanholderID, planholder.MemberName, planholder.officecode ";
            query = query + "ORDER BY planholder.MemberName, office.Classification LIMIT 30 ";
            cmd = new MySqlCommand(query, mcon);
            mda.SelectCommand = cmd;
            mda.Fill(dt1);

            dgPlanholder.DataSource = dt1;
            dgPlanholder.CellBorderStyle = DataGridViewCellBorderStyle.None;
            int numRows = dgPlanholder.Rows.Count;
            if (numRows == 0)
            {
                dgPlanholder.Visible = false;
            }
            else
            {
                dgPlanholder.Visible = true;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                //autofillPlanholder();
            }
            else
            {
                dgPlanholder.Visible = false;
            }
        }

        private void dgPlanholder_KeyDown(object sender, KeyEventArgs e)
        {
            //Down Tab Key Press
            if (e.KeyCode == Keys.Back)
            {
                txtSearch.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                getPlanhoderInfo();
            }
        }

        public void getPlanhoderInfo()
        {
            //Get Value autofill
            int rowindex;
            rowindex = dgPlanholder.CurrentRow.Index;
            DataGridViewRow selectedRow = dgPlanholder.Rows[rowindex];

            string dbPlanholderInfo = selectedRow.Cells[1].Value.ToString();
            string[] splitDBP = dbPlanholderInfo.Split('(');

            string dbMemberName = splitDBP[0];
            string dbCompany = splitDBP[1];
            string[] splitCompany = dbCompany.Split('-');
            string dbofficecode = splitCompany[0];
            
            mcon.Open();
            string q = "SELECT PlanholderID,MemberName,PayorName,Classification,if (Sex is null, '', Sex) as Gender, " +
                "if(CoveredUntil is null,'',date_format(CoveredUntil,'%Y-%m-%d')) as CoveredUntil, date_format(EffectiveDate,'%Y-%m-%d') as EffectiveDate, " +
                "date_format(birthdate,'%Y-%m-%d') as bday, if(IWCCardNo is null, '', IWCCardNo) as IWCCardNum, " +
                "if(mainplanholderID is null, '0', mainplanholderID) as mainplanholderID, " +
                "if(PECAll=0,'NA','Covered') as PECCompany, " +
                "if(PreExistingCoverage=0,'NA','Covered') as PECIndividual, " +
                "if(Occupation is null, '', Occupation) as myoccupation,planholder.plantypeid as PlantypeID,planholder.mainplanholderid as mainplanholderid, " +
                "date_format(if( date_add(anniv, interval (TIMESTAMPDIFF(DAY, anniv, curdate())/90) QUARTER) > curdate(), date_sub(date_add(anniv, interval (TIMESTAMPDIFF(DAY, anniv, curdate())/90) QUARTER), INTERVAL 1 QUARTER) ,date_add(anniv, interval (TIMESTAMPDIFF(DAY, anniv, curdate())/90) QUARTER)),'%Y-%m-%d') nxtperqtr,date_format(min(if(anniv is null,'1900-01-01',anniv)),'%Y-%m-%d')anniv FROM planholder " +
                "INNER JOIN office ON planholder.officecode = office.officecode ";
            q = q + "WHERE MemberName='" + dbMemberName + "' AND planholder.officecode='" + dbofficecode + "' AND birthdate is not null Group By planholder.Mainplanholderid ORDER BY COVEREDUNTIL >= CURDATE() DESC LIMIT 1 "; //Remove Group By Mainplanholderid
            mcd = new MySqlCommand(q, mcon);
            mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                string gender = mdr.GetString("Gender");
                if(gender == "F")
                {
                    gender = "Female";
                } else
                {
                    gender = "Male";
                }

                lblPlanholder.Text = mdr.GetString("MemberName");
                lblPayor.Text = mdr.GetString("PayorName");
                lblBirthDate.Text = mdr.GetString("bday");

                lblCompany.MaximumSize = new Size(300, 0);
                lblCompany.AutoSize = true;
                lblCompany.Text = mdr.GetString("Classification");
                lblCardNo.Text = mdr.GetString("IWCCardNum");

                lblSex.Text = gender;
                lblOccupation.Text = mdr.GetString("myoccupation");

                lblEffectivityDate.Text = mdr.GetString("EffectiveDate");
                lblCoveredUntil.Text = mdr.GetString("CoveredUntil");
                
                Reusable.getPlanTypeId = mdr.GetString("PlantypeID");
                Reusable.getPlanholderId = mdr.GetString("PlanholderID");
                Reusable.getMainPlanholderId = mdr.GetString("mainplanholderid");
            }
            mdr.Close();
            mcon.Close();

            txtSearch.Text = "";
            dgPlanholder.Visible = false;

            getPaymentHistoty();
            getDependents();
            getInsuranceBenefits();
        }

        public void getPaymentHistoty()
        {
            mcon.Open();
            string q = "SELECT DATE_FORMAT(payment_period,'%Y-%m') as 'Applicable Month', DATE_FORMAT(dtreceived,'%Y-%m-%d') as 'Payment Date', ";
            q = q + "DATE_FORMAT(processdate,'%Y-%m-%d') as 'Date Posted', FORMAT(premium, 2) as 'Amount' ";
            q = q + "FROM payment_collection ";
            q = q + "WHERE planholderid = '"+ Reusable.getPlanholderId + "' ";
            q = q + "ORDER BY payment_period ";
            MySqlDataAdapter sda = new MySqlDataAdapter(q, mcon);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtPayments.DataSource = ds.Tables[0].DefaultView;
            dtPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtPayments.RowsDefaultCellStyle.BackColor = Color.White;
            dtPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;

            dtPayments.Columns[0].Width = 150;
            dtPayments.Columns[1].Width = 130;
            dtPayments.Columns[2].Width = 130;
            dtPayments.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            mcon.Close();

            lblMonthsEnrolled.Text = dtPayments.Rows.Count.ToString();
        }

        public void getDependents()
        {
            mcon.Open();
            string q = "SELECT DependentName as 'Fullname', BirthDate as 'Birth Date', RelationToMember as Relation FROM planholder_dependent ";
            q = q + "WHERE planholderid = '" + Reusable.getPlanholderId + "' ";
            MySqlDataAdapter sda = new MySqlDataAdapter(q, mcon);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtDependents.DataSource = ds.Tables[0].DefaultView;
            dtDependents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtDependents.RowsDefaultCellStyle.BackColor = Color.White;
            dtDependents.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;
            
            mcon.Close();
            
        }

        public void getInsuranceBenefits() {
            
            mcon.Open();


            string q = "SELECT i.Classification as 'Provider', FORMAT(LifeBen1,2) as 'LIFE', FORMAT(AddBen1,2) as 'ADD', FORMAT(HibBen1,2) as 'HIB', FORMAT(BurialBen1,2) as 'BURIAL'  FROM plan_type pt ";
            q = q + "LEFT JOIN insurance i ON pt.insuranceId = i.InsuranceID ";
            q = q + "WHERE planTypeId = '" + Reusable.getPlanTypeId + "' ";

            //Multiple Insurance
            if(Reusable.getPlanTypeId == "2294")
            {
                q = "SELECT Classification as 'Provider', benefit as 'Benefit', FORMAT(insuranceBenefit, 2) as 'Amount'  FROM multipleinsurance mi ";
                q = q + "LEFT JOIN insurance i ON mi.plan_insuranceId = i.InsuranceID ";
                q = q + "LEFT JOIN insurancebenefit b ON mi.insuranceBenefitId = b.insuranceBenefitId ";
                q = q + " WHERE mi.insuranceId = 16 ";
            }

            
            MySqlDataAdapter sda = new MySqlDataAdapter(q, mcon);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtInsuranceBenefits.DataSource = ds.Tables[0].DefaultView;
            dtInsuranceBenefits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtInsuranceBenefits.RowsDefaultCellStyle.BackColor = Color.White;
            dtInsuranceBenefits.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;
            

            mcon.Close();
            
        }

    }
}
