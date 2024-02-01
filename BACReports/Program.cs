using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BACReports
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }

    public static class Globals
    {

        //MySQL DB Connection
        public static String con_host = "";
        public static String con_database = "";
        public static String con_username = "";
        public static String con_password = "";
        public static String con_sslmode = "None";

    }

    public static class Reusable
    {
        public static string getUserID;
        public static string getUserName;
        public static string getUserFullName;
        public static string getDepartment;
        public static string getVersionSemantics;
        public static string getMainCode;
        public static string getOfficeCode;
        public static int getVersionStatus;
        public static double getPremium;
        
        public static string getPlanholderId;
        public static string getMainPlanholderId;
        public static string getPlanTypeId;

        public static string getCurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
        public static string getCurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public static string getCurrentMonth = DateTime.Now.ToString("MM");
        public static string getCurrentYear = DateTime.Now.ToString("yyyy");
        
    }

    

    public static class validationMSG
    {
        public static void Error(Form form, string msg)
        {
            MessageBox.Show(msg, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void Success(Form form, string msg)
        {
            MessageBox.Show(msg, "Success",
            MessageBoxButtons.OK);
        }

        public static void Information(Form form, string msg)
        {
            MessageBox.Show(msg, "System Feedback",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static class DateUtils
    {
        public static string Format(string d, string f)
        {
            DateTime dt = Convert.ToDateTime(d);
            String strDT = dt.ToString(f);

            return strDT;
        }
    }

    public static class FormUtils
    {
        public static int GetCheckBoxVal(bool cb)
        {
            int val = 0;

            if (cb == true)
            {
                val = 1;
            }

            return val;
        }

        public static void addDateReferenceOptions(Dictionary<string, string> cs, ComboBox cb)
        {
            cs.Add("applicable-month", "Applicable Month");
            cs.Add("collection-date", "Collection Date");
            cs.Add("posted-date", "Posted Date");
        }

        public static void addAccountStatusOptions(Dictionary<string, string> cs, ComboBox cb)
        {
            cs.Add("", "All");
            cs.Add("Existing", "Existing");
            cs.Add("New", "New");
        }

        public static void addLapsesOptions(Dictionary<string, string> cs, ComboBox cb)
        {
            cs.Add("30", "Over 30 Days");
            cs.Add("60", "Over 60 Days");
            cs.Add("90", "Over 90 Days");
            cs.Add("120", "Over 120 Days");
            cs.Add("121", "Over 121 - Up");
        }

        public static void addMonthsOptions(Dictionary<string, string> cs, ComboBox cb)
        {
            cs.Add("01", "January");
            cs.Add("02", "February");
            cs.Add("03", "March");
            cs.Add("04", "April");
            cs.Add("05", "May");
            cs.Add("06", "June");
            cs.Add("07", "July");
            cs.Add("08", "August");
            cs.Add("09", "September");
            cs.Add("10", "October");
            cs.Add("11", "November");
            cs.Add("12", "December");
        }

        public static DateTime GetMonthEndDate(DateTime date)
        {
            DateTime endDate = date;
            int endDateMonth = endDate.Month;

            while (endDateMonth == endDate.Month)
                endDate = endDate.AddDays(1);

            endDate = endDate.AddDays(-1);

            return endDate;
        }

        public static void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

    }
}
