using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverAccsesLayer;
using DriverLicenseProject;

namespace DriverBusinessLayer
{
    public class clsusersbusiness
    {
        public int userid { get; set; }
        public int personid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isactive { get; set; }

        
        public clsusersbusiness()
        {
            userid = 0;
            personid = 0;
            username = "";
            password = "";
            isactive = false;

        }
        public clsusersbusiness(int id,int prid,string user,string pass,bool act)
        {
            userid = id;
            personid = prid;
            username = user;
            password = pass;
            isactive = act;
            clstrnsfer.Currentpersonid = prid;
            clstrnsfer.CurrentUserid = id;
            clstrnsfer.CurrentUserNAme = user;
            clstrnsfer.CurrentUserISACTIVE = act;
        }

        public static clsusersbusiness checkloginBU(string username,string password)
        {
            int userid = 0,personid=0;
            bool isactive = false;

            if (clsusersaccses.checklogin(ref userid, ref personid, username, password, ref isactive))
            {
                return new clsusersbusiness(userid, personid, username, password, isactive);

            }
            else
                return null;
            

        }

        public static DataTable GetAllUsers()
        {
            return clsusersaccses.GetAllUsers();
        }

        public bool AddNewUserBU()
        {
            int userid=clsusersaccses.AddNewUserAC(personid,username,password,isactive);
            if(userid!=-1)
            {
                this.userid = userid;
                return true;
            }
            return false;


        }

        static public bool ispersonidexest(int id)
        {
            return clsusersaccses.ispersonidexest(id);
        }

        public static bool isuserexest(string username)
        {
            return clsusersaccses.IsUsernameExest(username);
        }
        public static bool DeleteUser(int id)
        {
            return clsusersaccses.DeleteUser(id);
        }

        public static bool ispasstrue(int personid,string password)
        {
            return clsusersaccses.ispasstrue(personid,password);
        }

        public static bool ChangePassword(int userid, string password)
        {
            return clsusersaccses.ChangePassword(userid, password);
        }



    }
}
