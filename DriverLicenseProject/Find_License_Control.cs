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
    public partial class Find_License_Control : UserControl
    {
        
        public TextBox Instancetxtbox = null;
        public Button InstannceBTN = null;
        public Find_License_Control()
        {
            InitializeComponent();
            Instancetxtbox = this.txtLicenseID;
            InstannceBTN = this.btnfind;
        }
        
        


        public event Action<int> getLicenseID;

        protected virtual void FunLicenseid(int LicenseID)
        {
            Action<int> handler = getLicenseID;
            if (handler != null)
            {
                handler(LicenseID); 
            }
        }


        public event Action<bool> SetIssueDesable;

        protected virtual void FunSetIssueDesable(bool Status)
        {
            Action<bool> handler = SetIssueDesable;
            if (handler != null)
            {
                handler(Status); 
            }
        }


        public event Action<bool> SetLinkLalbe;

        protected virtual void FunSetLinkLalbe(bool Status)
        {
            Action<bool> handler = SetLinkLalbe;
            if (handler != null)
            {
                handler(Status); 
            }
        }


        public event Action<int> GetPersonID;

        protected virtual void FunGetPersonID(int PersonID)
        {
            Action<int> handler = GetPersonID;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        public event Action<int> GetInterLicenseID;

        protected virtual void FunGetInterLicenseID(int InterID)
        {
            Action<int> handler = GetInterLicenseID;
            if (handler != null)
            {
                handler(InterID); 
            }
        }


        public event Action<int> GetRenewLicenseID;

        protected virtual void FunGetRenewLicenseID(int RenewID)
        {
            Action<int> handler = GetRenewLicenseID;
            if (handler != null)
            {
                handler(RenewID); 
            }
        }



        public event Action<int> GetLocalID;

        protected virtual void FunGetLocalID(int LocalID)
        {
            Action<int> handler = GetLocalID;
            if (handler != null)
            {
                handler(LocalID); 
            }
        }


        public event Action<int> GetDriverID;

        protected virtual void FunGetDriverID(int DriverID)
        {
            Action<int> handler = GetDriverID;
            if (handler != null)
            {
                handler(DriverID); 
            }
        }



        public event Action<int> GetLicenseClassID;

        protected virtual void FunGetLicenseClassID(int ClassLicenseID)
        {
            Action<int> handler = GetLicenseClassID;
            if (handler != null)
            {
                handler(ClassLicenseID);
            }
        }

        public event Action<DateTime> GetExDate;

        protected virtual void FunGetExDate(DateTime ExDate)
        {
            Action<DateTime> handler = GetExDate;
            if (handler != null)
            {
                handler(ExDate);
            }
        }

        public event Action<string> GetNots;

        protected virtual void FunGetNots(string notes)
        {
            Action<string> handler = GetNots;
            if (handler != null)
            {
                handler(notes); 
            }
        }

        private void Find_License_Control_Load(object sender, EventArgs e)
        {
            if (txtLicenseID.Text != "")
            {


                DataTable table = ClsLicenseBU.GetLicenseByID(Convert.ToInt32(txtLicenseID.Text));
                if (table != null)
                {

                    foreach (DataRow dr in table.Rows)
                    {

                        string FullName = "", Gendor = "", ISActive = "";

                        if (dr["ThirdName"] == DBNull.Value)
                            FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                        else
                            FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                        if (Convert.ToInt32(dr["Gendor"]) == 0)
                            Gendor = "Male";
                        else
                            Gendor = "Female";
                        if (Convert.ToBoolean(dr["IsActive"]))
                            ISActive = "YES";
                        else
                            ISActive = "NO";
                        DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                        DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                        DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);


                        bool Isdetained = ClsDetainBU.IsDenaited(Convert.ToInt32(txtLicenseID.Text));
                        lblname.Text = FullName;
                        lblClass.Text = dr["ClassName"].ToString();
                        lblLicenseID.Text = dr["LicenseID"].ToString();
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

                        lblIsActive.Text = ISActive;
                        lblDateOfBerth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                        lblDriverID.Text = dr["DriverID"].ToString();
                        lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                        if (dr["ImagePath"] != DBNull.Value)
                            pictureBox1.Load(dr["ImagePath"].ToString());
                        else
                            pictureBox1.Image = Properties.Resources.images;
                        if (Isdetained)
                            lblIsDetained.Text = "Yes";
                        else
                            lblIsDetained.Text = "NO";
                        if (GetLocalID != null)
                            FunGetLocalID(Convert.ToInt32(dr["localID"]));
                        if (GetPersonID != null)
                            FunGetPersonID(Convert.ToInt32(dr["PersonID"]));
                        if (getLicenseID != null)
                            FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                        if (SetLinkLalbe != null)
                            FunSetLinkLalbe(true);                   
                        if (SetLinkLalbe != null)
                            FunSetLinkLalbe(true);

                        
                        if (!Isdetained)
                        {
                            MessageBox.Show("The License Is NOT Detained", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                            if (SetIssueDesable != null)
                                FunSetIssueDesable(false);
                            return;

                        }

                        if (Convert.ToDateTime(dr["ExpirationDate"]) < DateTime.Now)
                        {
                            if (SetIssueDesable != null)
                                FunSetIssueDesable(false);
                            MessageBox.Show("Expired License .. Needs To Be Renewed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           
                            return;


                        }
                        if (SetIssueDesable != null)
                            FunSetIssueDesable(true);

                    }

                }
                else
                    MessageBox.Show("Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }








        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if (clstrnsfer.Mode == clstrnsfer.EnMode.Internationa)
            {




                if (txtLicenseID.Text != "")
                {

                    DataTable table = ClsLicenseBU.GetLicenseByID(Convert.ToInt32(txtLicenseID.Text));
                    if (table != null)
                    {

                        foreach (DataRow dr in table.Rows)
                        {

                            string FullName = "", Gendor = "", ISActive = "";

                            if (dr["ThirdName"] == DBNull.Value)
                                FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            else
                                FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            if (Convert.ToInt32(dr["Gendor"]) == 0)
                                Gendor = "Male";
                            else
                                Gendor = "Female";
                            if (Convert.ToBoolean(dr["IsActive"]))
                                ISActive = "YES";
                            else
                                ISActive = "NO";
                            DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                            DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                            DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);


                            bool Isdetained = ClsDetainBU.IsDenaited(Convert.ToInt32(txtLicenseID.Text));
                            lblname.Text = FullName;
                            lblClass.Text = dr["ClassName"].ToString();
                            lblLicenseID.Text = dr["LicenseID"].ToString();
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

                            lblIsActive.Text = ISActive;
                            lblDateOfBerth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                            lblDriverID.Text = dr["DriverID"].ToString();
                            lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                            if (dr["ImagePath"] != DBNull.Value)
                                pictureBox1.Load(dr["ImagePath"].ToString());
                            else
                                pictureBox1.Image = Properties.Resources.images;
                            if (Isdetained)
                                lblIsDetained.Text = "Yes";
                            else
                                lblIsDetained.Text = "NO";

                            if (GetPersonID != null)
                                FunGetPersonID(Convert.ToInt32(dr["PersonID"]));
                            if (getLicenseID != null)
                                FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                            if (GetLicenseClassID != null)
                                FunGetLicenseClassID(Convert.ToInt32(dr["LicenseClassID"]));

                            int InterID = (ClsDriversBU.IsDriverExest(Convert.ToInt32(dr["DriverID"])));
                            if (InterID != -1)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                if (GetInterLicenseID != null)
                                    FunGetInterLicenseID(InterID);
                                MessageBox.Show($"The Person Already Has An International Driving License With ID = {InterID}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (SetLinkLalbe != null)
                                    FunSetLinkLalbe(false);
                            }


                            if (Convert.ToInt32(dr["LicenseClassID"]) < 3)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                if (getLicenseID != null)
                                    FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                                MessageBox.Show("Driver License Class NOT Allow The Creation Of An International License", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }

                            if (!Convert.ToBoolean(dr["IsActive"]))
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                if (getLicenseID != null)
                                    FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                                MessageBox.Show("The License IS NOT Active", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                return;
                            }

                            if (Convert.ToDateTime(dr["ExpirationDate"]) < DateTime.Now)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                if (getLicenseID != null)
                                    FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                                MessageBox.Show("Expired License .. Needs To Be Renewed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;

                            }


                            if (GetDriverID != null)
                                FunGetDriverID(Convert.ToInt32(dr["DriverID"]));
                        }

                        if (SetIssueDesable != null)
                            FunSetIssueDesable(true);



                    }
                    else
                        MessageBox.Show("Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                    MessageBox.Show("The Text IS Emty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else if (clstrnsfer.Mode == clstrnsfer.EnMode.ReNew)
            {


                if (txtLicenseID.Text != "")
                {

                    DataTable table = ClsLicenseBU.GetLicenseByID(Convert.ToInt32(txtLicenseID.Text));
                    if (table != null)
                    {

                        foreach (DataRow dr in table.Rows)
                        {

                            string FullName = "", Gendor = "", ISActive = "";

                            if (dr["ThirdName"] == DBNull.Value)
                                FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            else
                                FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            if (Convert.ToInt32(dr["Gendor"]) == 0)
                                Gendor = "Male";
                            else
                                Gendor = "Female";
                            if (Convert.ToBoolean(dr["IsActive"]))
                                ISActive = "YES";
                            else
                                ISActive = "NO";
                            DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                            DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                            DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);


                            bool Isdetained = ClsDetainBU.IsDenaited(Convert.ToInt32(txtLicenseID.Text));
                            lblname.Text = FullName;
                            lblClass.Text = dr["ClassName"].ToString();
                            lblLicenseID.Text = dr["LicenseID"].ToString();
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

                            lblIsActive.Text = ISActive;
                            lblDateOfBerth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                            lblDriverID.Text = dr["DriverID"].ToString();
                            lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                            if (dr["ImagePath"] != DBNull.Value)
                                pictureBox1.Load(dr["ImagePath"].ToString());
                            else
                                pictureBox1.Image = Properties.Resources.images;
                            if (Isdetained)
                                lblIsDetained.Text = "Yes";
                            else
                                lblIsDetained.Text = "NO";
                            if (GetLocalID != null)
                                FunGetLocalID(Convert.ToInt32(dr["localID"]));
                            if (GetPersonID != null)
                                FunGetPersonID(Convert.ToInt32(dr["PersonID"]));
                            if (getLicenseID != null)
                                FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                            if (GetDriverID != null)
                                FunGetDriverID(Convert.ToInt32(dr["DriverID"]));


                      

                            if (!Convert.ToBoolean(dr["IsActive"]))
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                               
                                MessageBox.Show("The License IS NOT Active", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                return;
                            }

                            if (Convert.ToDateTime(dr["ExpirationDate"]) < DateTime.Now)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(true);
                               
                            }
                            else
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                DateTime ReExDate = Convert.ToDateTime(dr["ExpirationDate"]);
                                MessageBox.Show($"The driver's license is not expired. It will expire on {ReExDate.ToString("yyyy-MM-dd")}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                    }
                    else
                        MessageBox.Show("Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("The Text IS Emty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(clstrnsfer.Mode == clstrnsfer.EnMode.ReplacementForDamageORLost)
            {

                if (txtLicenseID.Text != "")
                {

                    DataTable table = ClsLicenseBU.GetLicenseByID(Convert.ToInt32(txtLicenseID.Text));
                    if (table != null)
                    {

                        foreach (DataRow dr in table.Rows)
                        {

                            string FullName = "", Gendor = "", ISActive = "";

                            if (dr["ThirdName"] == DBNull.Value)
                                FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            else
                                FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            if (Convert.ToInt32(dr["Gendor"]) == 0)
                                Gendor = "Male";
                            else
                                Gendor = "Female";
                            if (Convert.ToBoolean(dr["IsActive"]))
                                ISActive = "YES";
                            else
                                ISActive = "NO";
                            DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                            DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                            DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);


                            bool Isdetained = ClsDetainBU.IsDenaited(Convert.ToInt32(txtLicenseID.Text));
                            lblname.Text = FullName;
                            lblClass.Text = dr["ClassName"].ToString();
                            lblLicenseID.Text = dr["LicenseID"].ToString();
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

                            lblIsActive.Text = ISActive;
                            lblDateOfBerth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                            lblDriverID.Text = dr["DriverID"].ToString();
                            lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                            if (dr["ImagePath"] != DBNull.Value)
                                pictureBox1.Load(dr["ImagePath"].ToString());
                            else
                                pictureBox1.Image = Properties.Resources.images;
                            if (Isdetained)
                                lblIsDetained.Text = "Yes";
                            else
                                lblIsDetained.Text = "NO";
                            if (GetLocalID != null)
                                FunGetLocalID(Convert.ToInt32(dr["localID"]));
                            if (GetPersonID != null)
                                FunGetPersonID(Convert.ToInt32(dr["PersonID"]));
                            if (getLicenseID != null)
                                FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                            if (GetDriverID != null)
                                FunGetDriverID(Convert.ToInt32(dr["DriverID"]));
                            if (GetLicenseClassID != null)
                                FunGetLicenseClassID(Convert.ToInt32(dr["LicenseClassID"]));
                            if (GetExDate != null)
                                FunGetExDate(Convert.ToDateTime( dr["ExpirationDate"]));
                            if (SetLinkLalbe != null)
                                FunSetLinkLalbe(true);
                            
                            if(GetNots != null)
                            {
                                if (dr["Notes"] != DBNull.Value)
                                    FunGetNots(dr["Notes"].ToString());
                                else
                                    FunGetNots("");
                            }

                     

                            if (!Convert.ToBoolean(dr["IsActive"]))
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                               
                                MessageBox.Show("The License IS NOT Active", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                return;
                            }

                            if (Convert.ToDateTime(dr["ExpirationDate"]) < DateTime.Now)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                MessageBox.Show("Expired License .. Needs To Be Renewed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               
                                return;


                            }
                            if (SetIssueDesable != null)
                                FunSetIssueDesable(true);

                        }

                    }
                    else
                        MessageBox.Show("Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("The Text IS Emty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else if(clstrnsfer.Mode == clstrnsfer.EnMode.Detain)
            {


                if (txtLicenseID.Text != "")
                {

                    DataTable table = ClsLicenseBU.GetLicenseByID(Convert.ToInt32(txtLicenseID.Text));
                    if (table != null)
                    {

                        foreach (DataRow dr in table.Rows)
                        {

                            string FullName = "", Gendor = "", ISActive = "";

                            if (dr["ThirdName"] == DBNull.Value)
                                FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            else
                                FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            if (Convert.ToInt32(dr["Gendor"]) == 0)
                                Gendor = "Male";
                            else
                                Gendor = "Female";
                            if (Convert.ToBoolean(dr["IsActive"]))
                                ISActive = "YES";
                            else
                                ISActive = "NO";
                            DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                            DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                            DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);


                            bool Isdetained = ClsDetainBU.IsDenaited(Convert.ToInt32(txtLicenseID.Text));
                            lblname.Text = FullName;
                            lblClass.Text = dr["ClassName"].ToString();
                            lblLicenseID.Text = dr["LicenseID"].ToString();
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

                            lblIsActive.Text = ISActive;
                            lblDateOfBerth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                            lblDriverID.Text = dr["DriverID"].ToString();
                            lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                            if (dr["ImagePath"] != DBNull.Value)
                                pictureBox1.Load(dr["ImagePath"].ToString());
                            else
                                pictureBox1.Image = Properties.Resources.images;
                            if (Isdetained)
                                lblIsDetained.Text = "Yes";
                            else
                                lblIsDetained.Text = "NO";
                            if (GetLocalID != null)
                                FunGetLocalID(Convert.ToInt32(dr["localID"]));
                            if (GetPersonID != null)
                                FunGetPersonID(Convert.ToInt32(dr["PersonID"]));
                            if (getLicenseID != null)
                                FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                            if (SetLinkLalbe != null)
                                FunSetLinkLalbe(true);
                            

                            if (Isdetained)
                            {
                                MessageBox.Show("The License Is Already Detained","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                return;

                            }


                            if (!Convert.ToBoolean(dr["IsActive"]))
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                               
                                MessageBox.Show("The License IS NOT Active", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                return;
                            }

                            if (Convert.ToDateTime(dr["ExpirationDate"]) < DateTime.Now)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                MessageBox.Show("Expired License .. Needs To Be Renewed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                              
                                return;


                            }
                            if (SetIssueDesable != null)
                                FunSetIssueDesable(true);

                        }

                    }
                    else
                        MessageBox.Show("Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("The Text IS Emty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (clstrnsfer.Mode == clstrnsfer.EnMode.Release)
            {


                if (txtLicenseID.Text != "")
                {

                    DataTable table = ClsLicenseBU.GetLicenseByID(Convert.ToInt32(txtLicenseID.Text));
                    if (table != null)
                    {

                        foreach (DataRow dr in table.Rows)
                        {

                            string FullName = "", Gendor = "", ISActive = "";

                            if (dr["ThirdName"] == DBNull.Value)
                                FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            else
                                FullName = dr["FirstName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                            if (Convert.ToInt32(dr["Gendor"]) == 0)
                                Gendor = "Male";
                            else
                                Gendor = "Female";
                            if (Convert.ToBoolean(dr["IsActive"]))
                                ISActive = "YES";
                            else
                                ISActive = "NO";
                            DateTime DateOFBerth = Convert.ToDateTime(dr["DateOfBirth"]);
                            DateTime IssueDate = Convert.ToDateTime(dr["IssueDate"]);
                            DateTime ExDate = Convert.ToDateTime(dr["ExpirationDate"]);


                            bool Isdetained = ClsDetainBU.IsDenaited(Convert.ToInt32(txtLicenseID.Text));
                            lblname.Text = FullName;
                            lblClass.Text = dr["ClassName"].ToString();
                            lblLicenseID.Text = dr["LicenseID"].ToString();
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

                            lblIsActive.Text = ISActive;
                            lblDateOfBerth.Text = DateOFBerth.ToString("yyyy-MM-dd");
                            lblDriverID.Text = dr["DriverID"].ToString();
                            lblExpirationDate.Text = ExDate.ToString("yyyy-MM-dd");
                            if (dr["ImagePath"] != DBNull.Value)
                                pictureBox1.Load(dr["ImagePath"].ToString());
                            else
                                pictureBox1.Image = Properties.Resources.images;
                            if (Isdetained)
                            {
                                lblIsDetained.Text = "Yes";
                                if (getLicenseID != null)
                                    FunLicenseid(Convert.ToInt32(txtLicenseID.Text));
                            }
                            else
                                lblIsDetained.Text = "NO";
                            if (GetLocalID != null)
                                FunGetLocalID(Convert.ToInt32(dr["localID"]));
                            if (GetPersonID != null)
                                FunGetPersonID(Convert.ToInt32(dr["PersonID"]));
                           
                            if (SetLinkLalbe != null)
                                FunSetLinkLalbe(true);
                           
                            if (SetLinkLalbe != null)
                                FunSetLinkLalbe(true);

                            if (!Isdetained)
                            {
                                MessageBox.Show("The License Is NOT Detained", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                return;

                            }
                         

                            if (Convert.ToDateTime(dr["ExpirationDate"]) < DateTime.Now)
                            {
                                if (SetIssueDesable != null)
                                    FunSetIssueDesable(false);
                                MessageBox.Show("Expired License .. Needs To Be Renewed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                              
                                return;


                            }
                            if (SetIssueDesable != null)
                                FunSetIssueDesable(true);

                        }

                    }
                    else
                        MessageBox.Show("Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("The Text IS Emty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
