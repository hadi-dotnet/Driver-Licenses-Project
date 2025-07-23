using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DriverAccsesLayer
{
    public class clsInternationalLicenseAC
    {
        public static int AddInternationalLicense(int appID, int DriverID, int IssuedUseingLocalLicenseID, DateTime IssueDate, DateTime EXpirationDate, bool IsActive, int CreatedBYUserID)
        {
            int InternationalID = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"INSERT INTO [dbo].[InternationalLicenses]
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
     VALUES
           (@id
           ,@driverid
           ,@issueusing
           ,@issuedate
           ,@exDate
           ,@isactive
           ,@userid);  select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", appID);
            cmd.Parameters.AddWithValue("@driverid", DriverID);
            cmd.Parameters.AddWithValue("@issueusing", IssuedUseingLocalLicenseID);
            cmd.Parameters.AddWithValue("@issuedate", IssueDate);
            cmd.Parameters.AddWithValue("@exDate", EXpirationDate);
            cmd.Parameters.AddWithValue("@isactive", IsActive);
            cmd.Parameters.AddWithValue("@userid", CreatedBYUserID);

            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int x))
                {
                    InternationalID = x;
                }

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return InternationalID;
        }

        public static DataTable GetInternationalInfoBYInterNationalLicenseID(int InterID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID, InternationalLicenses.DriverID, InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, 
                  InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive, people.NationalNo, people.FirstName, people.SecondName, people.ThirdName, people.LastName, people.DateOfBirth, people.Gendor, people.ImagePath
                    FROM     application INNER JOIN
                  InternationalLicenses ON application.ApplicationID = InternationalLicenses.ApplicationID INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID where InternationalLicenses.InternationalLicenseID=@id";

            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id", InterID);
            DataTable dt = new DataTable();
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

                    dt = null;
                
            }
            finally { con.Close(); }
            return dt;
        }

        public static DataTable GetAllInternationalLicense()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.DriverID,InternationalLicenses.IssuedUsingLocalLicenseID,InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate,InternationalLicenses.IsActive from InternationalLicenses";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(qy,con);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.HasRows)
                {
                    dt.Load(red);
                }
                else
                    dt = null;
                red.Close();
            }
            catch (Exception)
            {
                dt=null;
            
            }
            finally { con.Close(); }
            return dt;
        }

        public static DataTable GetInternationalLicenseOfPersonID(int PersonID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID, InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, 
                  InternationalLicenses.IsActive
                FROM     application INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID INNER JOIN
                  InternationalLicenses ON application.ApplicationID = InternationalLicenses.ApplicationID where people.PersonID=@id  order by InternationalLicenses.InternationalLicenseID DESC";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", PersonID);

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
                dt = null;

            }
            finally { con.Close(); }
            return dt;
        }
    }
}
