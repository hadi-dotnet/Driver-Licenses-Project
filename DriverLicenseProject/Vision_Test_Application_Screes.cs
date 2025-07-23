using DriverBusinessLayer;
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
    public partial class Vision_Test_Application_Screes : Form
    {
       private int localID = 0;
       
       public enum enMode
        {
            vision = 1, writen = 2, street = 3

        }
        enMode mode;

        public delegate void DataBackEventHandler();

       
        public event DataBackEventHandler DataBack;

        public Vision_Test_Application_Screes(int appid,int mode)
        {
            InitializeComponent();
            Applcation_Details_Control.ApplicatonID = appid;
            localID = appid;
            
            this.mode = (enMode)mode;
        }
        private void _filldata()
        {
           
            DataTable dt = clsAppointmentTestBU.getappointment(localID, (int)mode);
            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["TestAppointmentID"].ToString(), dr["AppointmentDate"].ToString(), dr["PaidFees"].ToString(), dr["IsLocked"]);
            }
            
           
        }



        private void btnAddappiont_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count==0)
            {
                Add_Appointment_Vision_Test_Screen frm = new Add_Appointment_Vision_Test_Screen(localID,(int)mode);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                _filldata();

            }
            else if(!clsAppointmentTestBU.IsLockedBU(Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value)))
            {
                MessageBox.Show("There Is an Active Appointment", "ERROR", MessageBoxButtons.OK);
            }
            else if (clsAppointmentTestBU.CheckTestResult(Convert.ToInt32( dataGridView1.Rows[0].Cells[0].Value)))
            {
                MessageBox.Show("This Person Passed The Test , You Cant Make Another Appointment", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                Add_Appointment_Vision_Test_Screen frm = new Add_Appointment_Vision_Test_Screen(localID, (int)mode,true);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                _filldata();
            }

        }

        private void Vision_Test_Application_Screes_Load(object sender, EventArgs e)
        {
            _filldata();
            if (mode == enMode.writen)
                labelofscreen.Text = "written Test Application";
            else if (mode == enMode.street)
                labelofscreen.Text = "Street Test Application";

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsAppointmentTestBU.IsLockedBU(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)))
            {

                TakeTestVisionScreen frm = new TakeTestVisionScreen(localID,Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value),(int)mode);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                _filldata();


            }
            else
                MessageBox.Show("The appointment is locked you cannot modify it.", "Warning!",MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void Vision_Test_Application_Screes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke();
        }
    }
}
