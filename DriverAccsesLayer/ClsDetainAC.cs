using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class ClsDetainAC
    {
        public static int AddDetain(int LicenseID, DateTime DetainDate, double FineFees, int CreatedByUserID, bool IsReleased)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string Query = @"
            INSERT INTO [dbo].[DetainedLicenses]
           ([LicenseID]
           ,[DetainDate]
           ,[FineFees]
           ,[CreatedByUserID]
           ,[IsReleased]
           ,[ReleaseDate]
           ,[ReleasedByUserID]
           ,[ReleaseApplicationID])
            VALUES
           (@LicenseID
           ,@DetainDate
           ,@FineFees
           ,@CreateBYUserID
           ,@IsReleased
           ,@ReleaseDate
           ,@ReleasedByUserID
           ,@ReleaseApplicationID);select SCOPE_IDENTITY();";
            int detainid = -1;

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreateBYUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            try
            {
                con.Open();
                object x = cmd.ExecuteScalar();
                if (x != null && int.TryParse(x.ToString(), out int det))
                {
                    detainid = det;
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); };
            return detainid;
        }


        public static bool Isdetain(int LicenseID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select 1 from DetainedLicenses where DetainedLicenses.LicenseID=@id and DetainedLicenses.IsReleased=0";
            bool Status = false;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", LicenseID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                    Status = true;
                red.Close();

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return Status;
        }

        public static bool IsDetainedBYNationalNOAndLocalID(int LocalID, string NationalNO)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string Query = @" select DetainedLicenses.IsReleased from DetainedLicenses where DetainedLicenses.IsReleased=0 and DetainedLicenses.LicenseID = (  SELECT Licsenses.LicenseID
                FROM     people INNER JOIN
                  Drivers ON people.PersonID = Drivers.PersonID INNER JOIN
                  Licsenses ON Drivers.DriverID = Licsenses.DriverID INNER JOIN
                  application ON people.PersonID = application.ApplicantPersonID AND Licsenses.ApplicationID = application.ApplicationID INNER JOIN
                  localdrivingLicenseApplication ON application.ApplicationID = localdrivingLicenseApplication.applicationID where people.NationalNo =@NatioanlNO and localdrivingLicenseApplication.localID=@localid)
				 
				 ";
            bool Status = false;
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@NatioanlNO", NationalNO);
            cmd.Parameters.AddWithValue("@localid", LocalID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                    Status = true;
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return Status;
        }

        public static DataTable GetDetainDateAndFeesAndIDBYLicenseID(int LicenseID)
        {
            DataTable Dt = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select DetainedLicenses.DetainDate,DetainedLicenses.DetainID,DetainedLicenses.FineFees from DetainedLicenses where DetainedLicenses.LicenseID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", LicenseID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    Dt.Load(red);
                }
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return Dt;
        }

        public static bool UpdateDetain(int DetainID, DateTime ReleaseDate, int ReleaseBYuserID, int ReleaseApplicationID,bool Isrelese)
        {
           
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"UPDATE [dbo].[DetainedLicenses]
        SET [ReleaseDate] = @Date
      ,[ReleasedByUserID] = @UserID
      ,[ReleaseApplicationID] =@ApplcationID
       ,[IsReleased] = @Isrelese
      
                WHERE DetainedLicenses.DetainID=@DetainID";
            bool Status = false;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            cmd.Parameters.AddWithValue("@Date", ReleaseDate);
            cmd.Parameters.AddWithValue("@UserID", ReleaseBYuserID);
            cmd.Parameters.AddWithValue("@ApplcationID", ReleaseApplicationID);
            cmd.Parameters.AddWithValue("@Isrelese", Isrelese);
            try
            {
                con.Open();
               int RowAF = cmd.ExecuteNonQuery();
                if(RowAF>0)
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

        public static DataTable GetAllDetainLicense()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = @"SELECT DetainedLicenses.DetainID, DetainedLicenses.IsReleased, DetainedLicenses.DetainDate, DetainedLicenses.FineFees, DetainedLicenses.ReleaseDate, DetainedLicenses.ReleaseApplicationID, people.NationalNo, people.FirstName, 
                  people.SecondName, people.ThirdName, people.LastName, DetainedLicenses.LicenseID
                    FROM     DetainedLicenses INNER JOIN
                  Licsenses ON DetainedLicenses.LicenseID = Licsenses.LicenseID INNER JOIN
                  Drivers ON Licsenses.DriverID = Drivers.DriverID INNER JOIN
                  people ON Drivers.PersonID = people.PersonID order by DetainedLicenses.DetainID desc";
            DataTable DT = new DataTable(); 
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();

                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    DT.Load(red);
                }
                else
                    DT = null;
            }
            catch (Exception)
            {
                
             
            }
            finally { con.Close(); }
                return DT;
        }

    }


}
