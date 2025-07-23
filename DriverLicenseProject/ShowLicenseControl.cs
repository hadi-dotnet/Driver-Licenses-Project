using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class ShowLicenseControl : UserControl
    {
        
        
        public ShowLicenseControl()
        {
            InitializeComponent();
        }
        public  int  LocalID=0;
        public  string NationalNO = "";

        private void _FillData()
        {
           
                DataTable table = ClsLicenseBU.GetLicenseInformation(LocalID);
                if (table != null)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        string FullName = "", Gendor = "";

                        if (dr["ThirdName"] == DBNull.Value)
                            FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                        else
                            FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                        if (Convert.ToInt32(dr["Gendor"]) == 0)
                            Gendor = "Male";
                        else
                            Gendor = "Female";
                        DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                        DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                        DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);



                        lblFullname.Text = FullName;
                        lblClass.Text = dr["ClassName"].ToString();
                        lbllicenseid.Text = dr["LicenseID"].ToString();
                        lblnationatno.Text = dr["NationalNo"].ToString();
                        lblgendor.Text = Gendor;
                        lblIssueDate.Text = IssueDate.ToString("yyyy-MM-dd");
                    if (Convert.ToInt32(dr["IssueReason"]) == 1)
                        lblIssueReason.Text = "Firts Time";
                    else if (Convert.ToInt32(dr["IssueReason"]) == 2)
                        lblIssueReason.Text = "Renew";
                    else if (Convert.ToInt32(dr["IssueReason"]) == 3)
                        lblIssueReason.Text = "Re.For Damage";
                    else if (Convert.ToInt32(dr["IssueReason"]) == 4)
                        lblIssueReason.Text = "Re.For Lost";
                    if (dr["Notes"] != DBNull.Value)
                            lblNotes.Text = dr["Notes"].ToString();
                        else
                            lblNotes.Text = "There Is No Notes";
                        if (Convert.ToBoolean(dr["IsActive"]))
                            lblIsActive.Text = "Yes";
                        else 
                            lblIsActive.Text = "No";
                        lblDateOfBirth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                    
                        lblDiverID.Text = dr["DriverID"].ToString();
                        lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                        if (dr["ImagePath"] != DBNull.Value)
                            pictureBox1.Load(dr["ImagePath"].ToString());
                        else
                            pictureBox1.Image = Properties.Resources.images;



                    }
                bool IsDetained = ClsDetainBU.IsDetainedBYNationalNOAndLocalID(LocalID,NationalNO);
                if (IsDetained)
                    lblIsDetained.Text = "Yes";
                else
                    lblIsDetained.Text = "No";

                

               

            }
          
        }

        private void ShowLicenseControl_Load(object sender, EventArgs e)
        {
             _FillData();
          
        }
    }
}
