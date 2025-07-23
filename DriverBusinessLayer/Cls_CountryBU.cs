using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class Cls_CountryBU
    {
        public static string GetCountryNameByCountryID(int CountryID)
        {
            return Cls_CountryAC.GetCountryNameByCountryID(CountryID);
        }

        public static DataTable GetAllCountrys()
        {
            return Cls_CountryAC.GetAllCountrys();
        }


    }
}
