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
    public partial class Edit_Fees_OF_TestType_Screen : Form
    {
        int ID = 0;
        string Title = "";
        
        public Edit_Fees_OF_TestType_Screen(int ID,string Title)
        {
            InitializeComponent();
            this.ID = ID;
            this.Title = Title;
           
        }

        public delegate void Data();
        public event Data DataBack;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtfees.Text!="")
            {
                if (ClsTakeTestBU.updateFeesOFTestType(ID, Convert.ToInt32 ( txtfees.Text)))
                    MessageBox.Show("Fees Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Fees Updated NOT Successfully", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            

            }
            else
                    MessageBox.Show("You Have To Enter Fees", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void Edit_Fees_OF_TestType_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Fees_OF_TestType_Screen_Load(object sender, EventArgs e)
        {

            lblID.Text = ID.ToString();
            lbltitle.Text = Title;  
            
        }
    }
}
