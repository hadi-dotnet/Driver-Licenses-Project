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
    public partial class LogenScreen : Form
    {
        public LogenScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsusersbusiness hadi = clsusersbusiness.checkloginBU(txtusername.Text,txtpassword.Text);
            if (hadi != null)
            {
                MainScreen main = new MainScreen();
                main.Show();
                
              
            }
            else
                MessageBox.Show("uncurect username or password", "ERROR", MessageBoxButtons.OK);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
