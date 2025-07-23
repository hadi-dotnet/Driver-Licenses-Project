using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DriverAccsesLayer
{
    public class clsPeopleAC
    {
        public static DataTable getallpeopleAC()
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            DataTable dt = new DataTable(); 
            string query = "select * from people";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
                {
                    dt.Load(red);

                }
                red.Close();
            }
            catch (Exception)
            {
                return null;

            }
            finally { con.Close(); }
            return dt;

        }

        public static DataTable FindByIDAC(string id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = @"select * from people where PersonID=@id";

            SqlCommand cmd = new SqlCommand(query,con);

            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
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

        public static DataTable FindByNameAC(string name)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = $"select * from people where FirstName like'{name}%'";

            SqlCommand cmd = new SqlCommand(query, con);

           
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
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

        public static DataTable FindByNationalAC(string nat)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = $"select * from people where NationalNo like'{nat}%'";

            SqlCommand cmd = new SqlCommand(query, con);

           
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if (red.HasRows)
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

        public static int addnewperson(string first,string secound,string third,string last,string nationalna,string email,string phone,int countryid,string imagepath,DateTime dateofberth,int gender,string address)
        {

            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int personid = -1;

            string query = @"insert into people (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)values
                             (@nationalna,@first,@secound,@third,@last,@dateofberth,@gender,@address,@phone,@email,@countryid,@imagepath);
                             SELECT SCOPE_IDENTITY();
          ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nationalna", nationalna);
            cmd.Parameters.AddWithValue("@first", first);
            cmd.Parameters.AddWithValue("@secound", secound);
            if (third != "")
                cmd.Parameters.AddWithValue("@third", third);
            else
                cmd.Parameters.AddWithValue("@third", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@last", last);
            cmd.Parameters.AddWithValue("@dateofberth", dateofberth);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@countryid", countryid);
            if (imagepath != null)
                cmd.Parameters.AddWithValue("@imagepath", imagepath);
            else
                cmd.Parameters.AddWithValue("@imagepath", System.DBNull.Value);

            try
            {
                con.Open();
                object id=cmd.ExecuteScalar();
                if(id!=null&&int.TryParse(id.ToString(),out int x))
                {
                    personid = x;
                }

            }
            catch (Exception)
            {

               
            }
            finally
            { con.Close(); }

            return personid;




        }

        public static bool FindAC(int id, ref string first,ref string secound,ref string third,ref string last,ref string nationalna,ref string email,ref string phone,ref int countryid,ref string imagepath,ref DateTime dateofberth,ref int gender,ref string address)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active=false;
            string query = @"select * from people where personid=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("id", id);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();

                if (red.Read())
                {
                    first = (string)red["FirstName"];
                    secound = (string)red["SecondName"];
                    if (red["ThirdName"] != DBNull.Value)
                        third = (string)red["ThirdName"];
                    else
                        third = "";
                    last = (string)red["LastName"];

                    nationalna = (string)red["NationalNo"];

                    if (red["Email"] != DBNull.Value)
                        email = (string)red["Email"];
                    else
                        email = "";                   

                        phone = (string)red["Phone"];              
                        countryid = (int)red["NationalityCountryID"];
                   
                    if (red["ImagePath"] != DBNull.Value)
                        imagepath = (string)red["ImagePath"];
                    else
                        imagepath = "";
                    gender = (int)red["Gendor"];
                    dateofberth = (DateTime)red["DateOfBirth"];
                    address = (string)red["Address"];

                    active = true;





                }
                red.Close();



            }
            catch (Exception)
            {
                active=false;
               
            }
            finally { con.Close(); }
            return active;

        }

        
        public static int GetPersonIDBYNationalNO(string NationalNO)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            int PersonID = -1;
            string query = @"select * from people where people.PersonID = (select people.PersonID from people where people.NationalNo=@NA)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NA", NationalNO);

            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.Read())
                {
                    PersonID = Convert.ToInt32(red[0]);
                }

            }
            catch (Exception)
            {


            }
            finally { con.Close(); }

            return PersonID;

        }


        public static bool checknationalnaAC(int id, string national)
        {

            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            string query = $"select COUNT(NationalNo) 'COUNT' from people where NationalNo = @national And PersonID <> {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            bool result = false;
            cmd.Parameters.AddWithValue("@national", national);
            try
            {
                con.Open();
                SqlDataReader red = cmd.ExecuteReader();
                if(red.Read())
                {
                    if ((int)red["COUNT"] == 0)
                    {
                        result = true;
                    }
                }
                red.Close();
            }
            catch (Exception)
            {
                
              
            }
            finally { con.Close(); }
            return result;

        }

        public static bool updatepersonAC(int id,string first, string secound, string third, string last, string nationalna, string email, string phone, int countryid, string imagepath, DateTime dateofberth, int gender, string address)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);

            bool active = false;    

            string query = @"UPDATE [dbo].[people]
                               SET [NationalNo] = @nationalna
                                  ,[FirstName] = @first
                                  ,[SecondName] = @secound
                                  ,[ThirdName] =@third
                                  ,[LastName] = @last
                                  ,[DateOfBirth] = @dateofberth
                                  ,[Gendor] =@gender
                                  ,[Address] = @address
                                  ,[Phone] =@phone
                                  ,[Email] = @email
                                  ,[NationalityCountryID] = @countryid
                                  ,[ImagePath] = @imagepath
                             WHERE PersonID=@id ";

            SqlCommand cmd = new SqlCommand(query,con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nationalna", nationalna);
            cmd.Parameters.AddWithValue("@first", first);
            cmd.Parameters.AddWithValue("@secound", secound);
            if (third != "")
                cmd.Parameters.AddWithValue("@third", third);
            else
                cmd.Parameters.AddWithValue("@third", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@last", last);
            cmd.Parameters.AddWithValue("@dateofberth", dateofberth);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@countryid", countryid);
            if (imagepath != null)
                cmd.Parameters.AddWithValue("@imagepath", imagepath);
            else
                cmd.Parameters.AddWithValue("@imagepath", System.DBNull.Value);

            try
            {
                con.Open();
                int x = cmd.ExecuteNonQuery();
                if(x>0)
                {
                    active=true;
                }

            }
            catch (Exception)
            {
                active = false;
              
            }
            finally
            {
                con.Close();
            }
            return active;


        }

        public static bool deletepersonAC(int id)
        {
            SqlConnection con = new SqlConnection(clsconnectionstring.constring);
            bool active=false;
            string query = @"delete from people where personid=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int x = cmd.ExecuteNonQuery();
                if(x>0)
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
