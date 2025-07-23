using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class FilterAndShow : UserControl
    {
        public  int PersonID = -1;
        public string NationalNO = "";
        private int ComSelected = 0; 
        public FilterAndShow()
        {
            InitializeComponent();
          

        }

  
        
            Image img=Image.FromFile(@"C:\Program Files (x86)\images.png");
        public event Action<int> getpersonID;

        protected virtual void tpersonid(int PersonID)
        {
            Action<int> handler = getpersonID;
            if (handler != null)
            {
                handler(PersonID);
            }
        }


        public void loaddata(clsPeopleBU person)
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
                lblcountry.Text = person.NationalityCountryID.ToString();


                if (person.ImagePath != "")
                    pictureBox1.Load(person.ImagePath);
                else
                    pictureBox1.Image= img;

              
            
        }

          
        private void btnfind_Click(object sender, EventArgs e)
        {
            if (txtfilter.Text == "")
                txtfilter.Text = Convert.ToString(0);
            if(comfilter.SelectedIndex==1)
            {
                clsPeopleBU person = clsPeopleBU.Find(Convert.ToInt32(txtfilter.Text));
                if(person != null)
                {
                    loaddata(person);
                    clstrnsfer.personid = person.personID;
                 
                    if(getpersonID!=null)
                        tpersonid(Convert.ToInt32(txtfilter.Text));

                }
                else
                    MessageBox.Show("Not Found", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FilterAndShow_Load(object sender, EventArgs e)
        {
            if(PersonID!=-1)
            {
                comfilter.SelectedIndex = 1;
                txtfilter.Text = PersonID.ToString();
                txtfilter.Enabled = false;
                comfilter.Enabled = false;
                btnfind.Enabled = false;

                clsPeopleBU person = clsPeopleBU.Find(PersonID);
                if (person != null)
                {
                    loaddata(person);
                }
                else
                    MessageBox.Show("Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (NationalNO!="")
            {
                int PerID = clsPeopleBU.GetPersonIDBYNationalNO(NationalNO);

                comfilter.SelectedIndex = 3;
                txtfilter.Text = PerID.ToString();
                txtfilter.Enabled = false;
                comfilter.Enabled = false;
                btnfind.Enabled = false;

                clsPeopleBU person = clsPeopleBU.Find(PerID);
                if (person != null)
                {
                    loaddata(person);
                }
                else
                    MessageBox.Show("Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }


        }
    }
}
