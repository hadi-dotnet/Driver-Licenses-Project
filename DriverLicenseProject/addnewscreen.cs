using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class addnewscreen : Form
    {
        public addnewscreen()
        {
            InitializeComponent();
           
            addnewcontrol.setmode(-1);
        }
        public addnewscreen(int id)
        {
            InitializeComponent();
           
            addnewcontrol.setmode(id);
            
        }


        private void addnewscreen_Load(object sender, EventArgs e)
        {
          
            
        }

        private void addnewcontrol1_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
