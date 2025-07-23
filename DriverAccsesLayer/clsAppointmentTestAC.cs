using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class clsAppointmentTestAC
    {

        public static bool Save(int TestTypeID,int LocalDrivingLicenseApplicationID,DateTime AppointmentDate,float PaidFees ,int CreatedByUserID,bool IsLocked,int RetakeTestApplicationID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;
            string query = @"INSERT INTO [dbo].[TestAppointments]
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
           ,[CreatedByUserID]
           ,[IsLocked]
           ,[RetakeTestApplicationID])
     VALUES
           (@testtypeID
           ,@localid
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID
           ,@IsLocked
           ,@RetakeTestApplicationID)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@testtypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@localid", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            if(RetakeTestApplicationID==-1)
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID",RetakeTestApplicationID);

            try
            {
                con.Open();
                int rowaffected = cmd.ExecuteNonQuery();
                if (rowaffected > 0)
                {
                    active= true;
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();

            }
            return active;
        }

        public static DataTable getAppointment(int localID,int typeid)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = $"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked  from TestAppointments   where TestAppointments.LocalDrivingLicenseApplicationID={localID} and TestAppointments.TestTypeID={typeid} order by TestAppointmentID desc";

            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
          
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    dt.Load(red);
                }
            }
            catch (Exception)
            {
                dt = null;

            }
            finally { con.Close(); }
            return dt;
        }

        public static string GetDateOfAppointment(int appointmentID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select TestAppointments.AppointmentDate from TestAppointments where TestAppointmentID=@appID";
            string appdate = "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@appID", appointmentID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    appdate = red[0].ToString();
                }
            }
            catch (Exception)
            {

            }
            finally { con.Close(); }
            return appdate;
        }

        public static int GetFeesOfVisionTest()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select TestTypeFees from TestTypes where TestTypeID=1";
            SqlCommand cmd = new SqlCommand(query, con);
            int num = -1;
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    num = Convert.ToInt32(red[0]);
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return num;
        }

          public static int GetFeesOfwritenTest()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select TestTypeFees from TestTypes where TestTypeID=2";
            SqlCommand cmd = new SqlCommand(query, con);
            int num = -1;
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    num = Convert.ToInt32(red[0]);
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return num;
        }

        public static int GetFeesOfStreetTest()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select TestTypeFees from TestTypes where TestTypeID=3";
            SqlCommand cmd = new SqlCommand(query, con);
            int num = -1;
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    num = Convert.ToInt32(red[0]);
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return num;
        }

        public  static bool LockAppointment(int appointID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"update [TestAppointments] set IsLocked=1 where TestAppointmentID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            bool active = false;
            cmd.Parameters.AddWithValue("@id", appointID);
            try
            {
                con.Open();
                int rowaffected = cmd.ExecuteNonQuery();
                if (rowaffected > 0)
                {
                    active=true;
                }

            }
            catch (Exception)
            {

             
            }
            finally { con.Close(); }
            return active;
        }

        public static bool IsLocked(int appointmentID)
        {

            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select 1 from TestAppointments where TestAppointmentID=@id and IsLocked=1";
            SqlCommand cmd = new SqlCommand(query, con);
            bool active = false;
            cmd.Parameters.AddWithValue("@id", appointmentID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    active = true;
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); } return active;
        }

        public static bool UpdatePassed(int localID,int passedid)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"update localdrivingLicenseApplication set passedTest=@passedid where localdrivingLicenseApplication.localID=@localID";
            SqlCommand cmd = new SqlCommand(query, con);
            bool active = false;
            cmd.Parameters.AddWithValue("@localID", localID);
            cmd.Parameters.AddWithValue("@passedid", passedid);
            try
            {
                con.Open();
                int rowaffected = cmd.ExecuteNonQuery();
                if(rowaffected > 0)
                {
                    active=true;
                }
            }
            catch (Exception)
            {

           
            }
            finally { con.Close(); } return active;
        }

        public static bool CheckTestResult(int appointmentID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"SELECT Tests.TestResult
                    FROM     TestAppointments INNER JOIN
                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID where TestAppointments.TestAppointmentID=@id
                        ";
            SqlCommand cmd = new SqlCommand(query, con);
            bool result=false;
            cmd.Parameters.AddWithValue("@id", appointmentID);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    result = (bool)red[0];
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return result;
        }


    }
}
