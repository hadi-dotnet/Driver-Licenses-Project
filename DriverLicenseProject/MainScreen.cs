using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        enum EnMode
        {
            Internationa = 0,ReNew = 1
        }

        private void MianScreen_Load(object sender, EventArgs e)
        {

        }

        private void strippeople_Click(object sender, EventArgs e)
        {
            people pep = new people();
            pep.Show();
        }

        private void stripdrive_Click(object sender, EventArgs e)
        {
            ManageDriverScreen frm = new ManageDriverScreen();
            frm.Show();
        }

        private void stripeuser_Click(object sender, EventArgs e)
        {
            ManageUsersScreen frm = new ManageUsersScreen();
            frm.Show();
        }

        private void currenUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUserInfoScreen frm = new CurrentUserInfoScreen();
            
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordScerrn frm = new ChangePasswordScerrn();
            frm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            changePasswordToolStripMenuItem.Text = "hello";
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicenseScrees frm = new LocalLicenseScrees();
            frm.Show();

        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Application frm = new Local_Driving_License_Application();
            frm.Show();

        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            International_License_Screen frm = new International_License_Screen();
            clstrnsfer.Mode =clstrnsfer.EnMode.Internationa;
            frm.Show();

        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_International_License_Application_Screen frm = new Manage_International_License_Application_Screen();
            frm.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReNew_License_Screen frm = new ReNew_License_Screen();
            clstrnsfer.Mode = clstrnsfer.EnMode.ReNew;
            frm.Show();
        }

        private void replacmentForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replacement_For_Damaged_License_Screen frm = new Replacement_For_Damaged_License_Screen();
            clstrnsfer.Mode = clstrnsfer.EnMode.ReplacementForDamageORLost;
            frm.Show();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicenseScreen frm = new DetainLicenseScreen();
            clstrnsfer.Mode = clstrnsfer.EnMode.Detain;
            frm.Show();

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Release_Detained_License_Screen frm = new Release_Detained_License_Screen();
            clstrnsfer.Mode = clstrnsfer.EnMode.Release;
            frm.Show();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Detained_License_Screen frm = new Manage_Detained_License_Screen();
            frm.Show();
        }

        private void relaseDetanedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Release_Detained_License_Screen frm = new Release_Detained_License_Screen();
            clstrnsfer.Mode = clstrnsfer.EnMode.Release;
            frm.Show();
        }

        private void manageApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Application_Type frm = new Manage_Application_Type();
            frm.Show();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Test_Type_Screen frm = new Manage_Test_Type_Screen();
            frm.Show(); 
        }
    }
}
