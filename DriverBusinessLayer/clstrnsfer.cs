using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DriverLicenseProject
{
   
    public class clstrnsfer
    {
        public static int   personid = 0;
        public static int Currentpersonid = 0;
        public static string CurrentUserNAme = "";
        public static int CurrentUserid = 0;
        public static bool CurrentUserISACTIVE = false;

       public enum EnMode
        {
            Internationa = 0, ReNew = 1,ReplacementForDamageORLost = 2,Detain=3,Release = 4
        }

        public static EnMode Mode;






    }
}
