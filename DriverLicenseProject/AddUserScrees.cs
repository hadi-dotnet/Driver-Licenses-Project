using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DriverLicenseProject
{
    public partial class AddUserScrees : Form
    {
       
        public static Button instancebtnnext = null;
        public AddUserScrees()
        {
            InitializeComponent();
           instancebtnnext = btnnext;
           
            
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void filterAndShow1_Load(object sender, EventArgs e)
        {

        }

        private void AddUserScrees_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if(txtusername.Text==""||txtpassword.Text==""||txtconfirmpass.Text=="")
            {
                MessageBox.Show("Some field is Emty", "ERROR", MessageBoxButtons.OK);
                return;
            }

            if(txtpassword.Text!=txtconfirmpass.Text)
            {
                MessageBox.Show("The passwords do not match.", "ERROR", MessageBoxButtons.OK);
                return;
            }

            if (clsusersbusiness.ispersonidexest(clstrnsfer.personid))
            {
                MessageBox.Show("The person you previously chose as a user.", "ERROR", MessageBoxButtons.OK);
                return;
                
            }

            if(clsusersbusiness.isuserexest(txtusername.Text))
            {
                MessageBox.Show("The username already exists, please change it", "ERROR", MessageBoxButtons.OK);
                return;
            }

            clsusersbusiness user = new clsusersbusiness();
            user.personid = clstrnsfer.personid;
            user.username=txtusername.Text;
            user.password=txtpassword.Text;
            if(chkisactive.Checked )
            {
                user.isactive = true;
            }
            if(user.AddNewUserBU())
            {
                MessageBox.Show("Added seccessfully", "INFO", MessageBoxButtons.OK);
                lblid.Text=user.userid.ToString();
            }
            else
            {
                MessageBox.Show("Added NOT seccessfully", "ERROR", MessageBoxButtons.OK);
            }
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
