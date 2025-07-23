using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace DriverAccsesLayer
{
    public class ClsApplicationAC
    {

        
        public static int AddNewApplication(int peris, DateTime appdate, int apptype, byte appstatus, DateTime laststatusdate, double fees, int byuserid)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int appid = -1;
            string qy = @"INSERT INTO [dbo].[application]
           ([ApplicantPersonID]
           ,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
           ,[LastStatusDate]
           ,[PaidFees]
           ,[CreatedByUserID])
     VALUES
           (@peris
           ,@appdate
           ,@apptype
           ,@appstatus
           ,@laststatusdate
           ,@fees
           ,@byuserid);
                select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@peris", peris);
            cmd.Parameters.AddWithValue("@appdate", appdate);
            cmd.Parameters.AddWithValue("@apptype", apptype);
            cmd.Parameters.AddWithValue("@appstatus", appstatus);
            cmd.Parameters.AddWithValue("@laststatusdate", laststatusdate);
            cmd.Parameters.AddWithValue("@fees", fees);
            cmd.Parameters.AddWithValue("@byuserid", byuserid);

            try
            {
                con.Open();
                object x = cmd.ExecuteScalar();
                if (x != null && int.TryParse(x.ToString(), out int H))
                {
                    appid = H;
                }

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return appid;


        }

        public static DataTable getallapplication()
        {
            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = @"SELECT localdrivingLicenseApplication.localID, LicenseClasses.ClassName, people.FirstName, people.SecondName, people.ThirdName, people.LastName, people.NationalNo, application.ApplicationDate, 
                  localdrivingLicenseApplication.passedTest, application.ApplicationStatus
                    FROM     localdrivingLicenseApplication INNER JOIN
                  LicenseClasses ON localdrivingLicenseApplication.classesID = LicenseClasses.LicenseClassID INNER JOIN
                  application ON localdrivingLicenseApplication.applicationID = application.ApplicationID INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID where application.ApplicationTypeID=1";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    data.Load(red);
                }

            }
            catch (Exception)
            {

                return null;
            }
            finally { con.Close(); }
            return data;


        }

        public static DataTable getfullinformaion(int appid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = @"SELECT LicenseClasses.ClassName, users.username, localdrivingLicenseApplication.localID, localdrivingLicenseApplication.passedTest, application.ApplicationID, application.ApplicationStatus, applicationTypes.applicationfees, 
                      applicationTypes.applicationtypetitle, people.FirstName, people.SecondName, people.ThirdName, people.LastName, application.LastStatusDate, application.ApplicationDate
                        FROM     localdrivingLicenseApplication INNER JOIN
                      application ON localdrivingLicenseApplication.applicationID = application.ApplicationID INNER JOIN
                      LicenseClasses ON localdrivingLicenseApplication.classesID = LicenseClasses.LicenseClassID INNER JOIN
                      applicationTypes ON application.ApplicationTypeID = applicationTypes.applicationtypeid INNER JOIN
                      people ON application.ApplicantPersonID = people.PersonID INNER JOIN
                      users ON application.CreatedByUserID = users.userid where localdrivingLicenseApplication.localID=@id
                                         ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", appid);
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

        public static bool CheckClassLicense(int personid, int classid)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;
            string query = @"SELECT people.FirstName
                    FROM     localdrivingLicenseApplication  INNER JOIN
                  application ON localdrivingLicenseApplication.applicationID = application.ApplicationID INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID where people.PersonID=@personid and localdrivingLicenseApplication.classesID =@classid and application.ApplicationStatus <> 2";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@personid", personid);
            cmd.Parameters.AddWithValue("@classid", classid);
           

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {

                    active = true;
                }
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return active;

        }

        public static DataTable GetApplicationStatus(int personid)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            DataTable dt = new DataTable();
            string query = @"		SELECT application.ApplicationStatus 
                    FROM     application INNER JOIN
                  people ON application.ApplicantPersonID = people.PersonID where PersonID=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", personid);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    dt.Load(red);
                }
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return dt;

        }


        public static int GetPesrsonIDReatakeTest(int localID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int personid = -1;
            string query = @"SELECT application.ApplicantPersonID
                FROM     localdrivingLicenseApplication INNER JOIN
                  application ON localdrivingLicenseApplication.applicationID = application.ApplicationID where localdrivingLicenseApplication.localID=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", localID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    personid = Convert.ToInt32(red[0]);
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return personid;

        }

        public static sbyte GetPassedTest(int localID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            sbyte personid = -1;
            string query = @"select localdrivingLicenseApplication.passedTest from localdrivingLicenseApplication where localdrivingLicenseApplication.localID=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", localID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    personid = Convert.ToSByte(red[0]);
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return personid;

        }

        public static bool SetApplicationStatusComplete(int localID)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int applicationID = -1;
            bool active = false;
            string query = @"select localdrivingLicenseApplication.applicationID from localdrivingLicenseApplication where localdrivingLicenseApplication.localID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", localID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    applicationID = Convert.ToInt32(red[0]);
                }
                red.Close();
            }
            catch (Exception)
            {


            }

            string qry = @"update application set ApplicationStatus =3 where application.ApplicationID=@id";
            SqlCommand cmd1 = new SqlCommand(qry, con);
            cmd1.Parameters.AddWithValue("@id", applicationID);
            try
            {
                int rowaffected = cmd1.ExecuteNonQuery();
                if (rowaffected > 0)
                {
                    active = true;
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return active;
        }

        public static bool IsApplicationComplete(int LocalID)
        {
            bool active = false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"SELECT 1
                    FROM     application INNER JOIN
                  localdrivingLicenseApplication ON application.ApplicationID = localdrivingLicenseApplication.applicationID where localdrivingLicenseApplication.localID=@id and application.ApplicationStatus=3";

            SqlCommand cmd = new SqlCommand(qy, con);
            cmd.Parameters.AddWithValue("@id", LocalID);
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
            finally { con.Close(); }
            return active;
        }

        public static bool DeleteApplication(int LocalID)
        {
            bool active = false;
            List<int> RetakeTestNumbersList = new List<int>();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qy = @"delete from application where application.ApplicationID=(select localdrivingLicenseApplication.applicationID
                            from localdrivingLicenseApplication where localdrivingLicenseApplication.localID=@id)";
            SqlCommand cmdDeleteApplication = new SqlCommand(qy, con);
            cmdDeleteApplication.Parameters.AddWithValue("@id", LocalID);

            DataTable Table = new DataTable();
            string DeleteRetakeTest = @"delete from application where application.ApplicationID=@applicationID";
            SqlCommand cmdDeleteRetake = new SqlCommand(DeleteRetakeTest, con);


            string GetRetakeTest = @"select TestAppointments.RetakeTestApplicationID from TestAppointments where TestAppointments.LocalDrivingLicenseApplicationID=@localID";
            SqlCommand cmdGetRetakeTest = new SqlCommand(GetRetakeTest, con);
            cmdGetRetakeTest.Parameters.AddWithValue("@localID", LocalID);
            try
            {
                con.Open();

                SqlDataReader red = cmdGetRetakeTest.ExecuteReader();
                if (red.HasRows)
                {
                    Table.Load(red);
                }
                red.Close();

                foreach (DataRow row in Table.Rows)
                {
                    if (row[0] != DBNull.Value)
                    {
                        int currentRow = Convert.ToInt32(row[0]);
                        RetakeTestNumbersList.Add(currentRow);

                    }
                }


                int RowAffected = cmdDeleteApplication.ExecuteNonQuery();

                cmdDeleteRetake.Parameters.AddWithValue("@applicationID", -1);
                foreach (int nums in RetakeTestNumbersList)
                {
                    cmdDeleteRetake.Parameters["@applicationID"].Value = nums;
                    cmdDeleteRetake.ExecuteNonQuery();
                }


                if (RowAffected > 0)
                {
                    active = true;

                }


            }
            catch (Exception)
            {


            }
            finally { con.Close(); }


            return active;
        }

        public static bool SetApplicationCancel(int LocalID)
        {
            bool active = false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"update application set ApplicationStatus=2 where application.ApplicationID = (select localdrivingLicenseApplication.applicationID from localdrivingLicenseApplication where localdrivingLicenseApplication.localID=@id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", LocalID);
            try
            {
                con.Open();
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    active = true;
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return active;

        }

        public static bool IsApplicationCanceled(int LocalID)
        {

            bool active = false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"SELECT 1
                             FROM     application INNER JOIN
                            localdrivingLicenseApplication ON application.ApplicationID = localdrivingLicenseApplication.applicationID where localdrivingLicenseApplication.localID=@id and application.ApplicationStatus=2";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", LocalID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    active = true;
                }
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return active;
        }

       
        public static double GetFeesOFApplcaton(int ApplcationTypeID)
        {
            double ApplicationFees = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select applicationTypes.applicationfees from applicationTypes where applicationTypes.applicationtypeid=@id;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ApplcationTypeID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    ApplicationFees = Convert.ToDouble(red[0]);
                }
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return ApplicationFees;
        }

        public static int GetLocalIDByLicenselID(int LicenseID)
        {
            int LocalID = -1;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"SELECT localdrivingLicenseApplication.localID
                    FROM     localdrivingLicenseApplication INNER JOIN
                  application ON localdrivingLicenseApplication.applicationID = application.ApplicationID INNER JOIN
                  Licsenses ON application.ApplicationID = Licsenses.ApplicationID where Licsenses.LicenseID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", LicenseID);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                   LocalID  = Convert.ToInt32(red[0]);
                }
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return LocalID;
        }

        public static DataTable GetALlApplicationType()
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"select * from applicationTypes";
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
                    dt=null;
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return dt;
        }

        public static bool UpdateFeesOfApplicationType(int Fees,int ID)
        {
           bool status=false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string query = @"UPDATE [dbo].[applicationTypes]
                             SET 
                             [applicationfees] = @Fees
                                WHERE applicationTypes.applicationtypeid = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                con.Open();
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return status;
        }









    }


}

