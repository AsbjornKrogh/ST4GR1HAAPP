using System;
using System.Data.SqlClient;
using System.Transactions;
using DLL_Login;

namespace BLL_Login
{
    
   public class DB_BLL_Login
   {
        private DB_Login DBLogin = new DB_Login();

        //TODO kontoller DTO objekt for status char 

        /// <summary>
        /// Returns StaffStatus
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool checkLogin(string staffID, string pw)
       {
           if (DBLogin.LoginStaff(staffID, pw) == true)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
