using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class ClsDriverLicenseBU
    {
        public static DataTable GetAllClasses()
        {
            return ClsDriverLicenseAC.GetALlCalsses();
        }
        
    }
}
