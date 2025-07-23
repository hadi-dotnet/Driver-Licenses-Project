using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class ClsDriversAC
    {

        public static int AddDriver(int personID,int CreatedBY,DateTime CreatedDate)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int DriverID = -1;
            string qy = @"INSERT INTO [dbo].[Drivers]
           ([PersonID]
           ,[CreatedByUserID]
           ,[CreatedDate])
            VALUES
           (@perID
           ,@user
           ,@date);
                 select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(qy,con);
            cmd.Parameters.AddWithValue("@perID", personID);
            cmd.Parameters.AddWithValue("@user", CreatedBY);
            cmd.Parameters.AddWithValue("@date", CreatedDate);

            try
            {
                con.Open();

                object row = cmd.ExecuteScalar();
                if(row!=null&&int.TryParse(row.ToString(),out int value))
                {
                    DriverID= value;
                }
            }
            catch (Exception)
            {

             
            }
            finally { con.Close(); }
            return DriverID;
        }

        public static DataTable GetAllDriversAndLicenseInformation(int LocalID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            DataTable table = new DataTable();  
            string qy = @"SELECT people.PersonID, localdrivingLicenseApplication.applicationID, localdrivingLicenseApplication.classesID, LicenseClasses.DefaultValidityLength, LicenseClasses.ClassFees
                FROM     application INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID INNER JOIN
                  localdrivingLicenseApplication ON application.ApplicationID = localdrivingLicenseApplication.applicationID INNER JOIN
                  LicenseClasses ON localdrivingLicenseApplication.classesID = LicenseClasses.LicenseClassID where localdrivingLicenseApplication.localID=@ID";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("ID", LocalID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();    
                if(red.HasRows)
                {
                    table.Load(red);

                }

            }
            catch (Exception)
            {

             
            }
            finally { con.Close(); }
            return table;
        }

        public static int GetDriverID(int personID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select Drivers.DriverID from Drivers where PersonID=@id";
            int PerID = -1;
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", personID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    PerID = Convert.ToInt32(red[0]);
                }
            }
            catch (Exception)
            {

              
            }
            finally { con.Close(); }
            return PerID;
        }

        public static DataTable GetAllDrivers()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"  WITH Ranked AS (
         SELECT 
        people.FirstName, 
        people.NationalNo, 
        people.SecondName, 
        people.ThirdName, 
        people.LastName, 
        people.PersonID, 
        Licsenses.IssueDate, 
        Licsenses.IsActive, 
        Drivers.DriverID,
        ROW_NUMBER() OVER (PARTITION BY Drivers.DriverID ORDER BY Licsenses.IssueDate DESC) AS rn
    FROM Drivers
    INNER JOIN Licsenses ON Drivers.DriverID = Licsenses.DriverID
    INNER JOIN people ON Drivers.PersonID = people.PersonID
        )
SELECT * 
FROM Ranked 
WHERE rn = 1;
";
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand(qy, con);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.HasRows)
                {
                    table.Load(red);
                }
            }
            catch (Exception)
            {
                table = null;
                
            }
            finally { con.Close(); }
            return table;


        }

        public static int IsDriverExest(int driverID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select InternationalLicenses.InternationalLicenseID from InternationalLicenses where InternationalLicenses.DriverID=@id";
            int InterID = -1;
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", driverID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.Read())
                {
                    InterID =Convert.ToInt32( red[0]);
                }
                red.Close();
            }
            catch (Exception)
            {

          
            }
            finally { con.Close(); }
            return InterID;
        }


    }
}
