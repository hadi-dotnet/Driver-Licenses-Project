using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class Add_Appointment_Vision_Test_Screen : Form
    {
        public enum enMode
        {
            vision = 1, writen = 2, street = 3

        }
        private int localID = 0;
        enMode mode;
        bool activeretaketest = false;
        int RetakeTestID = -1;
        public Add_Appointment_Vision_Test_Screen(int Localid,int mode)
        {
            InitializeComponent();
             localID = Localid;
            this.mode = (enMode)mode;
        }

        public Add_Appointment_Vision_Test_Screen(int Localid, int mode,bool activeretaketest)
        {
            InitializeComponent();
            localID = Localid;
            this.mode = (enMode)mode;
            this.activeretaketest = activeretaketest;
        }
        private void _filldata()
        {
            DataTable dt = ClsApplicationBU.getallinformaion(localID);

            foreach (DataRow dr in dt.Rows)
            {
                string fullname = "";
                if (dr["ThirdName"] == DBNull.Value)
                    fullname = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                else
                    fullname = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["LastName"].ToString();

                lblDLAPPID.Text = dr["localID"].ToString();
                lblclasslicense.Text = dr["ClassName"].ToString();
                lblname.Text = fullname;
                if (mode == enMode.vision)
                    lblFees.Text = clsAppointmentTestBU.GetFeesOfVisionTest().ToString();
                else if (mode == enMode.writen)
                    lblFees.Text = clsAppointmentTestBU.GetFeesOfwritenTest().ToString();
                else if (mode == enMode.street)
                    lblFees.Text = clsAppointmentTestBU.GetFeesOfStreetTest().ToString();

                if(activeretaketest)
                {

                    

                    panel1.Enabled = true;
                    int AppointFees = Convert.ToInt32(lblFees.Text);
                    double FeesOfRetakeTest=ClsApplicationBU.GetFeesOFApplcaton(7);
                    lblREAPPfees.Text=FeesOfRetakeTest.ToString();
                    lbltotalfees.Text = (AppointFees + FeesOfRetakeTest).ToString();
                    
                }


            }
        }

        private void Add_Appointment_Vision_Test_Screen_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            _filldata();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(mode == enMode.vision)
            {
                    if(activeretaketest)
                    {
                        ClsApplicationBU RetakeTest = new ClsApplicationBU();
                        RetakeTest.ApplicantPersonID = ClsApplicationBU.GetPesrsonIDReatakeTest(localID);
                        RetakeTest.ApplicationDate = DateTime.Now;
                        RetakeTest.ApplicationStatus = 3;
                        RetakeTest.ApplicationTypeID = 7;
                        RetakeTest.CreatedByUserID = clstrnsfer.CurrentUserid;
                        RetakeTest.LastStatusDate = DateTime.Now;
                        RetakeTest.PaidFees = ClsApplicationBU.GetFeesOFApplcaton(7);
                        RetakeTestID = RetakeTest.SaveWithoutLocal();
                    }
                clsAppointmentTestBU appointment = new clsAppointmentTestBU(1, localID, dateTimePicker1.Value, Convert.ToInt32(lblFees.Text), clstrnsfer.CurrentUserid, false,RetakeTestID);
                if (appointment.Save())
                {
                    MessageBox.Show("added seccessfulyy");
                    this.Close();
                }
                else
                    MessageBox.Show("added NOT seccessfulyy");

            }
            else if(mode ==enMode.writen)
            {
                    if (activeretaketest)
                    {
                        ClsApplicationBU RetakeTest = new ClsApplicationBU();
                        RetakeTest.ApplicantPersonID = ClsApplicationBU.GetPesrsonIDReatakeTest(localID);
                        RetakeTest.ApplicationDate = DateTime.Now;
                        RetakeTest.ApplicationStatus = 3;
                        RetakeTest.ApplicationTypeID = 7;
                        RetakeTest.CreatedByUserID = clstrnsfer.CurrentUserid;
                        RetakeTest.LastStatusDate = DateTime.Now;
                        RetakeTest.PaidFees = ClsApplicationBU.GetFeesOFApplcaton(7);
                        RetakeTestID = RetakeTest.SaveWithoutLocal();
                    }
                clsAppointmentTestBU appointment = new clsAppointmentTestBU(2, localID, dateTimePicker1.Value, Convert.ToInt32(lblFees.Text), clstrnsfer.CurrentUserid, false, RetakeTestID);
                if (appointment.Save())
                {

                    MessageBox.Show("added seccessfulyy");
                    this.Close();
                }
                else
                    MessageBox.Show("added NOT seccessfulyy");

            }
            else if (mode == enMode.street)
            {
                if (activeretaketest)
                {
                    ClsApplicationBU RetakeTest = new ClsApplicationBU();
                    RetakeTest.ApplicantPersonID = ClsApplicationBU.GetPesrsonIDReatakeTest(localID);
                    RetakeTest.ApplicationDate = DateTime.Now;
                    RetakeTest.ApplicationStatus = 3;
                    RetakeTest.ApplicationTypeID = 7;
                    RetakeTest.CreatedByUserID = clstrnsfer.CurrentUserid;
                    RetakeTest.LastStatusDate = DateTime.Now;
                    RetakeTest.PaidFees = ClsApplicationBU.GetFeesOFApplcaton(7);
                    RetakeTestID = RetakeTest.SaveWithoutLocal();
                    lblREAPPfees.Text = RetakeTestID.ToString();
                }
                clsAppointmentTestBU appointment = new clsAppointmentTestBU(3, localID, dateTimePicker1.Value, Convert.ToInt32(lblFees.Text), clstrnsfer.CurrentUserid, false, RetakeTestID);
                if (appointment.Save())
                {

                    MessageBox.Show("added seccessfulyy");
                    this.Close();
                }
                else
                    MessageBox.Show("added NOT seccessfulyy");

            }


        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
