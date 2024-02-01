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

namespace BACReports
{
    public partial class frmUncollectedDetails : Form
    {
        //DB Connection
        MySqlConnection mcon = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode);
        MySqlCommand mcd;
        MySqlDataReader mdr;

        frmUncollected form1;
        public frmUncollectedDetails(frmUncollected form_1)
        {
            InitializeComponent();
            form1 = form_1;
        }
        
        private void frmUncollectedDetails_Load(object sender, EventArgs e)
        {
            getTableRows();
        }

        public void getTableRows()
        {

            string comboLapsesKey = ((KeyValuePair<string, string>)form1.cboLapses.SelectedItem).Key;
            string comboLapsesValue = ((KeyValuePair<string, string>)form1.cboLapses.SelectedItem).Value;

            mcon.Open();
            string query = "SELECT  ";
            if (form1.chkGroupBy.Checked == true)
            {
                query = query + "MAINCODE_DESC as Company, ";
            }
            else
            {
                query = query + "o.Classification as Company, ";
            }

            query = query + "MemberName, t.PaymentMethod as 'Paymode', dtLastPayment as 'Last Payment', FORMAT(premium, 2) as 'Premium', DATEDIFF(NOW(), if(coveredUntil>dtLastPayment,coveredUntil,dtLastPayment)) as 'Days Lapsed', ";
            query = query + "FORMAT((premium * FLOOR((DATEDIFF(NOW(), dtLastPayment) / 30))), 2) as 'For Collection' ";
            query = query + "FROM planholder p ";
            query = query + "LEFT JOIN office o ON p.officecode = o.OfficeCode ";
            query = query + "LEFT JOIN agent_hierarchyid h ON p.hierarchyID = h.hierarchyid ";
            query = query + "LEFT JOIN plan_type t ON p.PlanTypeID = t.PlanTypeID ";

            query = query + "WHERE free!=1 AND t.premium ='" + Reusable.getPremium + "' AND left(dtLastPayment,4) = (" + Reusable.getCurrentYear + "-1) AND DATEDIFF(NOW(), if(coveredUntil>dtLastPayment,coveredUntil,dtLastPayment)) > " + comboLapsesKey + " AND dtCancelled is null ";
            
            if (form1.chkGroupBy.Checked == true)
            {
                query = query + "AND MAINCODE='"+ Reusable.getMainCode +"' GROUP BY MAINCODE, MemberName, t.premium  ";
            }
            else
            {
                query = query + "AND p.OfficeCode='" + Reusable.getOfficeCode + "' GROUP BY p.OfficeCode, MemberName, t.premium  ";
            }

            query = query + "ORDER BY Company, MemberName, t.premium  ";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, mcon);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtMembers.DataSource = ds.Tables[0].DefaultView;
            dtMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtMembers.RowsDefaultCellStyle.BackColor = Color.White;
            dtMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite;

            dtMembers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMembers.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtMembers.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMembers.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            double subTotalUnpaid = 0.00;

            foreach (DataGridViewRow row in dtMembers.Rows)
            {
                subTotalUnpaid = subTotalUnpaid + Convert.ToDouble(row.Cells["For Collection"].Value.ToString());
            }

            lblSubTotalUnpaid.Text = subTotalUnpaid.ToString("N");

            mcon.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
