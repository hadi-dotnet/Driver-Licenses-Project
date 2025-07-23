using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class InfoPersonScreen : Form
    {
        public InfoPersonScreen(int id)
        {
           informationcontrol.setid(id);
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void informationcontrol1_Load(object sender, EventArgs e)
        {

        }

        private void InfoPersonScreen_Load(object sender, EventArgs e)
        {
           
        }
    }
}
