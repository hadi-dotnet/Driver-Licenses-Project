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
    public partial class InfoApplicationScreen : Form
    {
        public InfoApplicationScreen(int applicationID)
        {
            InitializeComponent();
            Applcation_Details_Control.ApplicatonID = applicationID;
        }

        private void InfoApplicationScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
