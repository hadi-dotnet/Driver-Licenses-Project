using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Odbc;

namespace DriverAccsesLayer
{
    public class clsusersaccses
    {

        public static bool checklogin(ref int id,ref int personid, string username, string password ,ref bool act)
        {
            bool te=false;
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = @"select * from users where username=@username and pass=@password";
            SqlCommand comand = new SqlCommand(query, con);
            comand.Parameters.AddWithValue("@username", username);
            comand.Parameters.AddWithValue("@password", password);
            try
            {
                con.Open();
                SqlDataReader red = comand.ExecuteReader();
                if(red.Read())
                {
                    username = (string)red["username"];
                    password = (string)red["pass"];
                    id = (int)red["UserID"];
                    personid = (int)red["PersonID"];
                    act = (bool)red["IsActive"];
                    te=true;
                }
                red.Close();

            }
            catch (Exception)
            {
                te=false;
            
            }
            finally { con.Close(); }


            return te;


        }

        public static DataTable GetAllUsers()
        {

            
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            DataTable dt=new DataTable();
            string query = @"SELECT users.userid, users.personID, people.FirstName, people.SecondName, people.ThirdName, people.LastName, users.username, users.isactive
            FROM     users INNER JOIN
                  people ON users.personID = people.PersonID";

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
            finally
            { con.Close(); }

            return dt;

        }

        public static int AddNewUserAC(int personid,string username,string password,bool isactive)
        {

            int userid = -1 ;
            SqlConnection con = new SqlConnection (clsconnectionstring.constring);

            string query = @"insert into users (personID,username,pass,isactive) values(@personid,@username,@password,@isactive);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@personid", personid);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@isactive", isactive);

            try
            {
                con.Open();
                object x = cmd.ExecuteScalar();
                if (x != null && int.TryParse(x.ToString(), out int h)) 
                {
                    userid= h;


                }

            }
            catch (Exception)
            {

          
            }
            finally { con.Close(); }
            return userid;

        }

        public static bool ispersonidexest(int id)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;
            string query = @"select 1 from users where personid=@id";

            SqlCommand cmd = new SqlCommand (query, con);
            cmd.Parameters.AddWithValue("@id",id);
            try
            {
                con.Open();

                SqlDataReader red =cmd.ExecuteReader();    
                if(red.HasRows)
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

        public static bool IsUsernameExest(string username)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;
            string query = @"select 1 from users where username=@username";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
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

        public static bool DeleteUser(int id)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;
            string query = @"delete from users where userid=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
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

        public static bool ispasstrue(int personid,string password)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;

            string query = @"select 1 from users where personid=@personid and pass=@password";
            SqlCommand cmd = new SqlCommand(query,con);

            cmd.Parameters.AddWithValue("@personid", personid);
           
            cmd.Parameters.AddWithValue("@password", password);

            try
            {

                con.Open();
                SqlDataReader red  = cmd.ExecuteReader();
                if(red.HasRows)
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

        public static bool ChangePassword(int userid, string password)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active = false;
            string query = @"update users set pass=@password where userid=@userid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                con.Open();

                int affected = cmd.ExecuteNonQuery();
                if (affected>0)
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


    }
}
