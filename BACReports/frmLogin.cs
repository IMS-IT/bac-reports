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
    public partial class frmLogin : Form
    {

        MySqlConnection mcon = new MySqlConnection("server=" + Globals.con_host + "; database=" + Globals.con_database + "; username=" + Globals.con_username + "; password=" + Globals.con_password + ";SSLMode=" + Globals.con_sslmode);
        MySqlCommand mcd;
        MySqlDataReader mdr;

        public frmLogin()
        {
            InitializeComponent();
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        public void login()
        {

            if (txtUsername.Text == "")
            {
                validationMSG.Error(this, "Please input username");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                validationMSG.Error(this, "Please input password");
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    mcon.Open();
                    string q = "select * from company_payment_users WHERE username='" + txtUsername.Text + "' AND password=md5('" + txtPassword.Text + "') ";
                    mcd = new MySqlCommand(q, mcon);
                    mdr = mcd.ExecuteReader();
                    if (mdr.Read())
                    {

                        Reusable.getUserID = mdr.GetString("userID");
                        Reusable.getUserName = mdr.GetString("username");
                        Reusable.getUserFullName = mdr.GetString("fullname");
                        Reusable.getDepartment = mdr.GetString("department");
                        Reusable.getVersionStatus = mdr.GetInt32("isVersion");
                        Reusable.getVersionSemantics = lblVersion.Text;
                        
                        string user_fullname = mdr.GetString("fullname");
                        string user_password = mdr.GetString("password");
                        string user_active = mdr.GetString("isActived");
                        string username = mdr.GetString("username");


                        if (user_active == "0")
                        {
                            MessageBox.Show("Account not active, Please contact I.T Department to resolve this issue");
                            txtUsername.Focus();
                        }
                        else
                        {

                            frmMain Main = new frmMain();
                            this.Hide();

                            Main.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("invalid username and password!");
                        txtUsername.Focus();

                    }
                    mdr.Close();
                    mcon.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
