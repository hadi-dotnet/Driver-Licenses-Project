using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class ClsDriverLicenseAC
    {
        public static DataTable GetALlCalsses()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            DataTable dt = new DataTable();
            string query = @"select ClassName from LicenseClasses";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.HasRows)
                {
                    dt.Load(red);
                }

            }
            catch (Exception)
            {

              
            }
            finally { con.Close(); }
            return dt; 

        }

        public static int AddlocaldrivingLicenseApplication(int appid,int classid,byte passed)
        {
            int id = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"INSERT INTO [dbo].[localdrivingLicenseApplication]
           ([applicationID]
           ,[classesID],passedTest)
     VALUES
           (@app
           ,@class,@passed);
             SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@app", appid);
            cmd.Parameters.AddWithValue("@class", classid);
            cmd.Parameters.AddWithValue("@passed", passed);
         

            try
            {
                con.Open();

               object x=cmd.ExecuteScalar();
                if (x!=null&& int.TryParse(x.ToString(),out int number))
                {
                    id=number;
                }

            }
            catch (Exception)
            {

                
            }
            finally { con.Close(); }
            return id;
            
        }
    }
}
