using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class clsPeopleBU
    {
        public int personID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        enum enmode
        {
            addnew=0,update=1
        }
        enmode mode;
       
        public clsPeopleBU()
        {
            this.personID = 0;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.email = "";
            this.DateOfBirth=DateTime.Now;
            this.Phone = "";
            this.ImagePath = "";
            this.Address = "";
            this.NationalityCountryID= 0;
            this.Gendor = 0;
            mode = enmode.addnew;
        }

       public clsPeopleBU(int id,string nat,string first,string scound,string third,string last,DateTime date,int gendor,string address,string phone,string email,int countryid,string image)
        {
           personID=id;
           NationalNo=nat;
           

            FirstName = first;
            SecondName=scound;
            ThirdName=third;
            LastName=last;
            DateOfBirth=date;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.email=email;
            this.NationalityCountryID= countryid;
            this.ImagePath = image;
            mode = enmode.update;

        }

        public static DataTable GetAllPeople()
        {

            return clsPeopleAC.getallpeopleAC();
            
        }

        public static DataTable FindByIDBU(string id)
        {
            return clsPeopleAC.FindByIDAC(id);
        }

        public static DataTable FindByNameBU(string name)
        {
            return clsPeopleAC.FindByNameAC(name);
        }
        public static DataTable FindByNationalBU(string nat)
        {
            return clsPeopleAC.FindByNationalAC(nat);
        }

        public static clsPeopleBU Find(int id)
        {
            string nat = "", first = "", secound = "", third = "", last = "", email = "", phone = "", address = "", image = "";
            int gendor = 0, countryid = 0;
            DateTime date = DateTime.Now;

            if(clsPeopleAC.FindAC(id,ref first,ref secound,ref third,ref last,ref nat,ref email,ref phone,ref countryid,ref image,ref date,ref gendor,ref address))
            {
                return new clsPeopleBU(id, nat, first, secound, third, last, date, gendor, address, phone, email, countryid, image);
            }
            else
                return null;


        }

        public bool checknationalna()
        {
            return clsPeopleAC.checknationalnaAC(personID, NationalNo);
        }
        private bool _addnewperson()
        {
            personID = clsPeopleAC.addnewperson(FirstName, SecondName, ThirdName, LastName, NationalNo, email, Phone, NationalityCountryID, ImagePath, DateOfBirth, Gendor, Address);
            if (personID!=-1)
            {
                mode = enmode.update;
                return true;
            }
            else
                return false;



        }
        private bool _updateperson()
        {
            if(clsPeopleAC.updatepersonAC(personID,FirstName,SecondName,ThirdName,LastName,NationalNo,email,Phone,this.NationalityCountryID,ImagePath,DateOfBirth,Gendor,Address))
            {
                return true;
            }
            return false;

        }

        public static bool deletepesonBU(int id)
        {
            return clsPeopleAC.deletepersonAC(id);

        }
        public bool save()
        {
            switch (mode)
            {
                case enmode.addnew:
                    {
                        if(_addnewperson())
                            return true;
                        else
                             return false;

                    }
                case enmode.update:
                    {
                        if (_updateperson())
                            return true;
                        else
                            return false;
                        
                    }

                   
            }

            return false;

        }

        public static int GetPersonIDBYNationalNO(string NationalNO)
        {
            return clsPeopleAC.GetPersonIDBYNationalNO(NationalNO);
        }

   




    }
}
