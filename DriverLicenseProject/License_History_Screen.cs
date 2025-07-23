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
    public partial class License_History_Screen : Form
    {
        private int PersonID = -1;
        private string NationalNO = "";
        public License_History_Screen(int PersonID)
        {
            InitializeComponent();
            filterAndShow1.PersonID = PersonID;
            this.PersonID = PersonID;
        }
        public License_History_Screen(string nationalNO)
        {
            InitializeComponent();
            filterAndShow1.NationalNO = nationalNO;
            this.PersonID = clsPeopleBU.GetPersonIDBYNationalNO(nationalNO);
        }



        private void _FillData()
        {
            if(PersonID!=-1)
            {
                DataTable TableofLocalLicense = ClsLicenseBU.GetLicenseBYPersonID(PersonID);
                if(TableofLocalLicense!=null)
                {
                    foreach(DataRow row in TableofLocalLicense.Rows)
                    {
                        DateTime IssueDate = Convert.ToDateTime(row["IssueDate"]);
                        DateTime ExDate = Convert.ToDateTime(row["ExpirationDate"]);

                        LocaldataGridView.Rows.Add(row["LicenseID"].ToString(), row["ApplicationID"].ToString(), row["ClassName"].ToString(), IssueDate.ToString("yyyy-MM-dd"), ExDate.ToString("yyyy-MM-dd"), row["IsActive"]);
                    }
                }

                DataTable TableOfInternational = clsInternationalLicenseBU.GetInternationalLicenseOfPersonID(PersonID);
                if(TableOfInternational!=null)
                {
                    foreach (DataRow row in TableOfInternational.Rows)
                    {
                        DateTime IssueDate = Convert.ToDateTime(row["IssueDate"]);
                        DateTime ExDate = Convert.ToDateTime(row["ExpirationDate"]);

                        InternationaldataGridView.Rows.Add(row["InternationalLicenseID"].ToString(), row["ApplicationID"].ToString(), row["IssuedUsingLocalLicenseID"].ToString(), IssueDate.ToString("yyyy-MM-dd"), ExDate.ToString("yyyy-MM-dd"), row["IsActive"]);
                    }
                }


            }
            else
            {
                LocaldataGridView.Rows.Clear();
                InternationaldataGridView.Rows.Clear();
            }


        }

        private void License_History_Screen_Load(object sender, EventArgs e)
        {
            _FillData();
        }

       
    }
}
