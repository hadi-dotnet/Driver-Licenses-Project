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
    public partial class CurrentUserInfoScreen : Form
    {
        public CurrentUserInfoScreen()
        {
            InitializeComponent();
            informationcontrol.setid(clstrnsfer.Currentpersonid);
        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }

        private void CurrentUserInfoScreen_Load(object sender, EventArgs e)
        {
            lbluserid.Text = clstrnsfer.CurrentUserid.ToString();
            lblusername.Text=clstrnsfer.CurrentUserNAme.ToString();
            if (clstrnsfer.CurrentUserISACTIVE)
                lblisactive.Text = "yes";
            else
                lblisactive.Text = "NO";

            
        }
    }
}
