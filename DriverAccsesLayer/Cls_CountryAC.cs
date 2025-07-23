using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class Cls_CountryAC
    {
        public static string GetCountryNameByCountryID(int CountryID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string CountryName = "";
            string query = @"select countries.name from countries where countries.countryid=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", CountryID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    CountryName = red[0].ToString();
                }

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return CountryName;
        }

        public static DataTable GetAllCountrys()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
           DataTable dt = new DataTable();
            string query = @"select Name from countries;";
            SqlCommand cmd = new SqlCommand(query, con);
          

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    dt.Load(red);
                }
                else
                    dt = null;
                red.Close();

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return dt   ;

        }

    }
}
