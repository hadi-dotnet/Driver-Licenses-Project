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
    public partial class Show_International_License_Control : UserControl
    {
        public Show_International_License_Control()
        {
            InitializeComponent();
        }
        public static int InternationalLicenseID = 0;

        private void Show_International_License_Control_Load(object sender, EventArgs e)
        {
            DataTable Table = clsInternationalLicenseBU.GetInternationalInfoBYInterNationalLicenseID(InternationalLicenseID);   
            if(Table != null)
            {
                foreach (DataRow dr in Table.Rows)
                {
                    string FullName = "", Gendor = "",IsActive="";

                    if (dr["ThirdName"] == DBNull.Value)
                        FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                    else
                        FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                    if (Convert.ToInt32(dr["Gendor"]) == 0)
                        Gendor = "Male";
                    else
                        Gendor = "Female";
                    if (Convert.ToBoolean(dr["IsActive"]))
                        IsActive = "YES";
                    else
                        IsActive = "NO";

                    DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                    DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                    DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);



                    lblFullname.Text = FullName;
                   
                   
                    lblnationatno.Text = dr["NationalNo"].ToString();
                    lblgendor.Text = Gendor;
                    lblIssueDate.Text = IssueDate.ToString("yyyy-MM-dd");
                    lblInternationalID.Text = dr["InternationalLicenseID"].ToString();
                    lblApplicationID.Text = dr["ApplicationID"].ToString();
                    lbllicenseid.Text = dr["IssuedUsingLocalLicenseID"].ToString();
                    lblIsActive.Text = IsActive;
                    lblDateOfBirth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                    lblDiverID.Text = dr["DriverID"].ToString();
                    lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                    if (dr["ImagePath"] != DBNull.Value)
                        pictureBox1.Load(dr["ImagePath"].ToString());
                    else
                        pictureBox1.Image = Properties.Resources.images;



                }
            }
        }
    }
}
