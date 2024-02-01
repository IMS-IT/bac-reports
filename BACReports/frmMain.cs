using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BACReports
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnUsername.Text = Reusable.getUserName;
            setActiveMenu(btnC4StarMonitoring);
            loadFormContent();

            if(Reusable.getDepartment == "ADMIN" || Reusable.getDepartment == "ACCOUNTING")
            {
                btnC4StarRemmit.Visible = true;
                
            }
            else
            {
                btnPostedCollection.Visible = false;
                btnUncollected.Visible = false;
            }
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to log-out ?";
            string caption = "Leave Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                var frm = new frmLogin();
                this.Hide();
                frm.ShowDialog();
                this.Close();

            }
        }

        public void setInactiveMenu()
        {
            foreach (Control c in panelSideMenu.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.BackColor = Color.DodgerBlue;
                    b.ForeColor = Color.White;
                }
            }
        }

        public void setActiveMenu(Control strButton)
        {
            //Set all button menu to In-active state first
            setInactiveMenu();

            //Activate Selected Button
            strButton.BackColor = Color.White;
            strButton.ForeColor = Color.DodgerBlue;

        }

        public void setActiveForm(Form frm)
        {
            panelContent.Controls.Clear();

            //var frm = new strForm();
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Size = panelContent.Size;
            frm.TopLevel = false;

            panelContent.Controls.Add(frm);
            frm.Show();
        }

        public void loadFormContent()
        {
            //Clear current form first
            panelContent.Controls.Clear();

            //Show Form1 to panel
            var frm = new frmC4StarVerification();
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Size = panelContent.Size;
            frm.TopLevel = false;

            panelContent.Controls.Add(frm);
            frm.Show();
        }
        
        private void panelContent_Resize(object sender, EventArgs e)
        {
            foreach (Control c in panelContent.Controls)
            {
                Form frm = c as Form;
                if (frm != null)
                {
                    frm.Size = panelContent.Size;
                }

            }
        }

        private void btnC4StarMonitoring_Click(object sender, EventArgs e)
        {
            setActiveMenu(btnC4StarMonitoring);

            var frm = new frmC4StarVerification();
            setActiveForm(frm);
        }

        private void btnPostedCollection_Click(object sender, EventArgs e)
        {
            setActiveMenu(btnPostedCollection);

            var frm = new frmPostedCollection();
            setActiveForm(frm);
        }

        private void btnUncollected_Click(object sender, EventArgs e)
        {
            setActiveMenu(btnUncollected);

            var frm = new frmUncollected();
            setActiveForm(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setActiveMenu(btnC4StarRemmit);

            var frm = new frmC4StarRemmit();
            setActiveForm(frm);
        }

        private void btnInsuranceRemit_Click(object sender, EventArgs e)
        {
            setActiveMenu(btnLibertyRemmit);

            var frm = new frmLibertyRemmit();
            setActiveForm(frm);
        }
    }
}
