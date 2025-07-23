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
    public partial class Applcation_Details_Control : UserControl
    {
        public Applcation_Details_Control()
        {
            InitializeComponent();
        }
        public static int ApplicatonID = 0;
    

        private void Applcation_Details_Control_Load(object sender, EventArgs e)
        {
            DataTable dt = ClsApplicationBU.getallinformaion(ApplicatonID);
            foreach(DataRow dr in dt.Rows)
            {
                string fullname = "";
                if (dr["ThirdName"] == DBNull.Value)
                    fullname = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                else
                    fullname = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() +" "+ dr["ThirdName"].ToString() + " " + dr["LastName"].ToString();

                string passtest = dr["passedTest"].ToString();
                int status = Convert.ToInt32( dr["ApplicationStatus"]);
                if (status == 1)
                    lblstatus.Text = "New";
                else if (status == 2)
                    lblstatus.Text = "Canceld";
                else
                    lblstatus.Text = "Complete";


                lblPassedtest.Text = passtest+"/3";

                lblname.Text = fullname;
                lblclasslicense.Text = dr["ClassName"].ToString();
                lblDLAPPID.Text = dr["localID"].ToString();
                lblappID.Text = dr["ApplicationID"].ToString();
                lblFees.Text = dr["applicationfees"].ToString();
                lbltype.Text = dr["applicationtypetitle"].ToString();
                lblname.Text=fullname;
                lbldate.Text = dr["ApplicationDate"].ToString();
                lbldatestatus.Text = dr["LastStatusDate"].ToString();
                lblcreatedby.Text = dr["username"].ToString();




            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
