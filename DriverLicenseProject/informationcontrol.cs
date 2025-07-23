using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class informationcontrol : UserControl
    {
        public static informationcontrol hadiinformation = null;
        public informationcontrol()
        {
            hadiinformation = this;
            InitializeComponent();
        }
        
        static int personid = -1;
        public static void setid(int x)
        {
            personid = x;
            
        }

        private void lblsetimage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addnewscreen frm = new addnewscreen(personid);
            frm.ShowDialog();
            loaddata();
            
        }
      

        public void loaddata()
        {
            
            clsPeopleBU person = clsPeopleBU.Find(personid);
            if(person != null)
            {
                lblpersonid.Text = person.personID.ToString();
                if (person.ThirdName == "")
                    lblname.Text = (person.FirstName + " " + person.SecondName + " " + person.LastName);
                else
                    lblname.Text = (person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName);
                lblnationatno.Text = person.NationalNo;
                lblemail.Text = person.email;
                lblphone.Text = person.Phone;
                lbladdress.Text = person.Address;
                lbldate.Text = person.DateOfBirth.ToString();
                if (person.Gendor == 0)
                    lblgendor.Text = "male";
                else
                    lblgendor.Text = "famale";
                lblcountry.Text = Cls_CountryBU.GetCountryNameByCountryID(person.NationalityCountryID);
                if (person.ImagePath != "")
                    pictureBox1.Load(person.ImagePath);

            }
            
        }



        private void informationcontrol_Load(object sender, EventArgs e)
        {
            
            loaddata();
           

        }
       
        public static informationcontrol returnthis()
        {
            return hadiinformation;
        }

       
    }
}
