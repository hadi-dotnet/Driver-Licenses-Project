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
    public partial class Show_International_License_Screen : Form
    {
        public Show_International_License_Screen(int InternationalLicenseID)
        {
            InitializeComponent();
            Show_International_License_Control.InternationalLicenseID = InternationalLicenseID;
           
        }
    }
}
