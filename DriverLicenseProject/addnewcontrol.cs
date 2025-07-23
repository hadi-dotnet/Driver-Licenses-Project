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
    public partial class addnewcontrol : UserControl
    {

        clsPeopleBU person;
        int gendorrad = 0;

        enum enmode
        {
            addnew=0,update=1,natupdate=2
        }
        enmode mode;
        static int personID;
        public addnewcontrol()
        {
            InitializeComponent();
       
        }
        public static void setmode(int x)
        {
            personID = x;             
        }
       

        public void save()
        {
           

           
            person.NationalNo=txtnationalna.Text;
            person.FirstName=txtfirst.Text;
            person.SecondName=txtsecound.Text;
            person.ThirdName=txtthird.Text;
            person.LastName=txtlast.Text;
            person.DateOfBirth=txtdate.Value;
            person.Gendor=gendorrad;
            person.Phone=txtphone.Text;
            person.email=txtemail.Text;
            person.Address=txtaddress.Text;
            person.NationalityCountryID=comcountry.SelectedIndex+1;
            person.ImagePath = pictureBox1.ImageLocation;

            if(txtnationalna.Text==""||txtfirst.Text==""||txtsecound.Text==""||txtlast.Text==""||txtphone.Text==""||txtaddress.Text=="")
            {
                MessageBox.Show("some feild are empty", "ERROR", MessageBoxButtons.OK);
                return;

            }
        
            if (!person.checknationalna())
            {
                MessageBox.Show("National number is already exist !", "Error");
                return;
            }


            




            if (person.save())
            {
                MessageBox.Show("saved secsusfully");
                lblpersonid.Text = person.personID.ToString();

            }




        }

     

        private void _fillcontrol()
        {
             person = clsPeopleBU.Find(personID);
            lblpersonid.Text= person.personID.ToString();
            txtfirst.Text = person.FirstName;
            txtsecound.Text = person.SecondName;
            txtthird.Text = person.ThirdName;
            txtlast.Text= person.LastName;
            txtnationalna.Text = person.NationalNo;
            txtemail.Text = person.email;
            txtphone.Text = person.Phone;
            txtaddress.Text=person.Address;
            comcountry.SelectedIndex = person.NationalityCountryID-1;
            if (person.Gendor == 0)
                radmale.Checked = true;
            else
                radfemale.Checked = true;
            txtdate.Value = person.DateOfBirth;
            if(person.ImagePath!="")
                pictureBox1.Load(person.ImagePath);
        }


        private void infocontrol_Load(object sender, EventArgs e)
        {
            DataTable Countrys = Cls_CountryBU.GetAllCountrys();

            foreach(DataRow Row in Countrys.Rows)
            {
                comcountry.Items.Add(Row[0]);
            }



            if (personID == -1)
            {
                person = new clsPeopleBU();
                mode = enmode.addnew;
                
            }
            else
            {
                _fillcontrol();
                mode = enmode.update;
                label1.Text = "Update Person";
            }



            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            save();
            
          
        }

        private void radmale_CheckedChanged(object sender, EventArgs e)
        {
            gendorrad = 0;
        }

        private void radfemale_CheckedChanged(object sender, EventArgs e)
        {
            gendorrad = 1;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            
        }

        private void lblsetimage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
