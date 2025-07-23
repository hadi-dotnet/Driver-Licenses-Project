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

namespace DriverBusinessLayer
{
    public partial class TakeTestVisionScreen : Form
    {
        public int localID = 0;
        private DataTable dt;
        int appointmentID  =0;

        public enum enMode
        {
            vision = 1, writen = 2, street = 3

        }
        enMode mode;

        public TakeTestVisionScreen(int ID,int appointmentID,int mode)
        {
            InitializeComponent();
            localID = ID;
            this.appointmentID = appointmentID;
         
          this. mode = (enMode)mode;
        }
        private void _filldata()
        {
             dt = ClsApplicationBU.getallinformaion(localID);

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
                if(mode==enMode.vision)
                    lblFees.Text = clsAppointmentTestBU.GetFeesOfVisionTest().ToString();
                else if (mode == enMode.writen)
                    lblFees.Text = clsAppointmentTestBU.GetFeesOfwritenTest().ToString();
                else if (mode == enMode.street)
                    lblFees.Text = clsAppointmentTestBU.GetFeesOfStreetTest().ToString();

                lbldate.Text = clsAppointmentTestBU.GetDateOfAppointment(appointmentID);
                
                rdbPass.Checked=true;

            }
        }
        private void TakeTestVisionScreen_Load(object sender, EventArgs e)
        {
            _filldata();
        }

        private void _Savedata(int passedid)
        {

            bool active;
            string notes = "";
            if (rdbPass.Checked)
            {
                active = true;
            }
            else
                active = false;

            if (txtnotes.Text != "")
                notes = txtnotes.Text;
            ClsTakeTestBU test = new ClsTakeTestBU(appointmentID, active, notes, clstrnsfer.CurrentUserid);

            DialogResult result = MessageBox.Show("You cannot modify the appointment after taking the test.", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK && test.Save() && clsAppointmentTestBU.LockAppointment(appointmentID)) 
            {
                
                if (active)
                {
                    clsAppointmentTestBU.UpdatePassed(localID, passedid);
                   
                            
                }
                MessageBox.Show("Successfully took the test.", "Successfully", MessageBoxButtons.OK);
                this.Close();
                    

                

            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (mode == enMode.vision)
                _Savedata(1);
            else if(mode == enMode.writen)
                _Savedata(2);
            else if (mode == enMode.street)
                _Savedata(3);


        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
