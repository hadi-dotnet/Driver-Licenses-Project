using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class ClsTakeTestAC
    {
        public static bool AddTest(int appointmentID,bool testresult,string notes,int userid)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qry = @"INSERT INTO [dbo].[Tests]
           ([TestAppointmentID]
           ,[TestResult]
           ,[Notes]
           ,[CreatedByUserID])
     VALUES
           (@id
           ,@testresult
           ,@notes
           ,@userid)";
            bool act = false;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", appointmentID);
            cmd.Parameters.AddWithValue("@testresult", testresult);
            if(notes!="")
                cmd.Parameters.AddWithValue("@notes", notes);
            else
                cmd.Parameters.AddWithValue("@notes", DBNull.Value);

            cmd.Parameters.AddWithValue("@userid", userid);

            try
            {
                con.Open();
                int rowaffected = cmd.ExecuteNonQuery();
                if(rowaffected > 0)
                {
                    act=true;
                }
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return act;

        }

        public static DataTable GetAllTestsType()
        {
            DataTable dt = new DataTable(); 
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qry = @"select * from TestTypes;";
            SqlCommand cmd = new SqlCommand(qry, con);


            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                    dt.Load(red);
                else
                    dt = null;
                red.Close();
            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return dt;

        }

        public static bool updateFeesOFTestType(int ID, int Fees)
        {
            bool Status = false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            string qry = @"UPDATE [dbo].[TestTypes]
                             SET 
                            [TestTypeFees] = @Fees
                            WHERE TestTypes.TestTypeID = @id";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                con.Open();
               int RowAffected=cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                    Status = true;

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }
            return Status;
        }
    }
}
