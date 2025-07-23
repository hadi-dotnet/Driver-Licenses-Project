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
    public partial class ShowLicenseScreen : Form
    {
       
        public ShowLicenseScreen(int LocalID,string NationalNO)
        {
            InitializeComponent();
           showLicenseControl1.LocalID = LocalID;
            showLicenseControl1.NationalNO = NationalNO;
        }

        public ShowLicenseScreen(int LocalID)
        {
            InitializeComponent();
            showLicenseControl1.LocalID = LocalID;
           
        }






    }
}
