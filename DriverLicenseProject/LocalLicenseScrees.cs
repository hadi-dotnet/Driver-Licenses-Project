using DriverBusinessLayer;
using DriverLicenseProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class LocalLicenseScrees : Form
    {
        public LocalLicenseScrees()
        {
            InitializeComponent();
        }
        int personID = 0;

        private void LocalLicenseScrees_Load(object sender, EventArgs e)
        {
            lblapplicationdate.Text = DateTime.Now.ToString();
            lblcreaterdby.Text = clstrnsfer.CurrentUserNAme;
            lblfees.Text = ClsApplicationBU.GetFeesOFApplcaton(1).ToString();
            DataTable dt = ClsDriverLicenseBU.GetAllClasses();
            foreach(DataRow h in dt.Rows)
            {
                comLicenseclasses.Items.Add(h[0].ToString());
            }
            comLicenseclasses.SelectedIndex = 2;
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void filterAndShow1_getpersonID(int obj)
        {
            personID= obj;
            btnnext.Enabled = true;
            btnsave.Enabled = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
          

            if (ClsApplicationBU.CheckClassLicnse(personID,comLicenseclasses.SelectedIndex+1))
            {
                MessageBox.Show("The Person Is Already Have Application", "ERROR", MessageBoxButtons.OK);
                return;

            }



            ClsApplicationBU app = new ClsApplicationBU();
            app.ApplicantPersonID = personID;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationStatus = 1;
            app.ApplicationTypeID = 1;
            app.ClassLicense = comLicenseclasses.SelectedIndex + 1;
            app.CreatedByUserID = clstrnsfer.CurrentUserid;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = ClsApplicationBU.GetFeesOFApplcaton(1);
            app.PassedTest = 0;

            if(app.Save())
            {
                lblid.Text = app.localapplicationID.ToString();
                MessageBox.Show("Application Added Successfully","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Faild","ERROR");
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
