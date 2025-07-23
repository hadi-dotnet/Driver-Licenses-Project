using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class ClsLicenseAC
    {
        public static int AddLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, double PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int LicenseID = -1;
            string qy = @"INSERT INTO [dbo].[Licsenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
     VALUES
           (@appID
           ,@driveID
           ,@LicenseClass
           ,@IssueDate
           ,@ExDate
           ,@Notes
           ,@PaidFees
           ,@isActive
           ,@IssueReson
           ,@UserID);  select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@appID", ApplicationID);
            cmd.Parameters.AddWithValue("@driveID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExDate", ExpirationDate);
            if (Notes != "")
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);

            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@isActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReson", IssueReason);
            cmd.Parameters.AddWithValue("@UserID", CreatedByUserID);

            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int value))
                {
                    LicenseID = value;
                }


            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return LicenseID;
        }

        public static DataTable GetLicenseInformation(int localID)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"SELECT LicenseClasses.ClassName, people.NationalNo, people.FirstName, people.SecondName, people.ThirdName, people.LastName, Licsenses.LicenseID, Licsenses.DriverID, people.Gendor, Licsenses.IssueDate, Licsenses.ExpirationDate, 
                  Licsenses.Notes, Licsenses.IsActive, people.DateOfBirth, people.ImagePath,Licsenses.IssueReason
                  FROM   localdrivingLicenseApplication INNER JOIN
                  application ON localdrivingLicenseApplication.applicationID = application.ApplicationID INNER JOIN
                  Licsenses ON application.ApplicationID = Licsenses.ApplicationID INNER JOIN
                  Drivers ON Licsenses.DriverID = Drivers.DriverID INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID AND Drivers.PersonID = people.PersonID INNER JOIN
                  LicenseClasses ON localdrivingLicenseApplication.classesID = LicenseClasses.LicenseClassID AND Licsenses.LicenseClass = LicenseClasses.LicenseClassID where localdrivingLicenseApplication.localID=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", localID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    table.Load(red);

                }
                red.Close();
            }
            catch (Exception)
            {
                table = null;

            }
            finally { con.Close(); }
            return table;

        }

        public static DataTable GetLicenseByID(int licenseID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"SELECT localdrivingLicenseApplication.localID, LicenseClasses.ClassName, Licsenses.LicenseID, Licsenses.DriverID, Licsenses.IssueDate, Licsenses.ExpirationDate, Licsenses.Notes, Licsenses.IsActive, Licsenses.IssueReason, people.NationalNo, people.FirstName, 
                  people.SecondName, people.LastName,Licsenses.Notes, people.ThirdName, people.DateOfBirth, people.Gendor, people.ImagePath, LicenseClasses.LicenseClassID, people.PersonID
FROM     Licsenses INNER JOIN
                  Drivers ON Licsenses.DriverID = Drivers.DriverID INNER JOIN
                  people ON Drivers.PersonID = people.PersonID INNER JOIN
                  LicenseClasses ON Licsenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN
                  application ON Licsenses.ApplicationID = application.ApplicationID AND people.PersonID = application.ApplicantPersonID INNER JOIN
                  localdrivingLicenseApplication ON LicenseClasses.LicenseClassID = localdrivingLicenseApplication.classesID AND application.ApplicationID = localdrivingLicenseApplication.applicationID
WHERE  (Licsenses.LicenseID = @id)";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", licenseID);
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


        public static DataTable GetLicenseBYPersonID(int personID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"SELECT Licsenses.LicenseID, Licsenses.ApplicationID, Licsenses.DriverID, LicenseClasses.ClassName, Licsenses.IssueDate, Licsenses.ExpirationDate, Licsenses.IsActive
                    FROM     application INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID INNER JOIN
                  Licsenses ON application.ApplicationID = Licsenses.ApplicationID INNER JOIN
                  LicenseClasses ON Licsenses.LicenseClass = LicenseClasses.LicenseClassID where people.PersonID=@id order by Licsenses.LicenseID Desc";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", personID);
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

        public static int GetValidityOfLicenseByLicenseID(int licenseID)
        {
            int Validity = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select LicenseClasses.DefaultValidityLength from LicenseClasses where LicenseClasses.LicenseClassID=(select Licsenses.LicenseClass from Licsenses where Licsenses.LicenseID=@id)";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", licenseID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    Validity = Convert.ToInt32(red[0]);

                }
                red.Close();

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return Validity;
        }

        public static double GetFeesOfLicenseBYLicenseID(int licenseID)
        {
            double LicenseFees = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select LicenseClasses.ClassFees from LicenseClasses where LicenseClasses.LicenseClassID = (select Licsenses.LicenseClass from Licsenses where Licsenses.LicenseID =@id)";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", licenseID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    LicenseFees = Convert.ToDouble(red[0]);

                }
                red.Close();

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return LicenseFees;
        }

        public static int GetLicenseClassBYLicenseID(int LicenseID)
        {

            int LicenseClass = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select Licsenses.LicenseClass from Licsenses where Licsenses.LicenseID = @id";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", LicenseID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    LicenseClass = Convert.ToInt32(red[0]);

                }
                red.Close();

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return LicenseClass;
        }

        public static bool SetLicenseUnActiveORActive(int licenseID ,bool StatusActive)
        {
            bool Status = false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"update Licsenses set Licsenses.IsActive = @Status where Licsenses.LicenseID=@id";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", licenseID);
            cmd.Parameters.AddWithValue("@Status", StatusActive);

            try
            {
                con.Open();
                int RowAffected = cmd.ExecuteNonQuery();
                if(RowAffected > 0)
                {
                    Status = true;
                }

            }
            catch (Exception)
            {

               
            }
            finally { con.Close(); }
            return Status;
        }

        public static int GetLicenseIDBYDetainID(int DetainID)
        {
            int LicenseID = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"select DetainedLicenses.LicenseID from DetainedLicenses where DetainedLicenses.DetainID = @id";
            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", DetainID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.Read())
                {
                    LicenseID = Convert.ToInt32(red[0]);
                }
                red.Close();

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return LicenseID;
        }

    }




    
}
