using System;
using System.Data.SqlClient;
using DTO; 

namespace DLL_Login
{
   public class DB_Login
   {
       private SqlConnection connection;
       private SqlDataReader reader;
       private SqlCommand command;
       private const String DBlogin = "F20ST2ITS2201907648";
       private DTO_StaffLogin dtoStaffLogin;

       public DTO_StaffLogin LoginStaff(String StaffID, String pw)
       {
           dtoStaffLogin = new DTO_StaffLogin();
           string connectionString = (@"Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";Integrated Security=False;User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
           connection = new SqlConnection(connectionString);
           command = new SqlCommand();
           string queryString = "Select * from Staff_Table where MedarbejderID = '" + StaffID + "'";

           try
           {
               connection.Open();
               using (command = new SqlCommand(queryString, connection))
               {
                   reader = command.ExecuteReader();
                   while (reader.Read())
                   {
                       if (reader["MedarbejderID"].ToString() == StaffID && reader["Password"].ToString() == pw)
                       {
                           dtoStaffLogin.StaffID = (int)reader["MedarbejderID"];
                           dtoStaffLogin.Name = (string)reader["Navn"]; 
                           //dtoStaffLogin.Password = (int)reader["Password];
                           dtoStaffLogin.StaffStatus = (char)reader["Status"];

                           return dtoStaffLogin;
                       }
                   }
               }
           }
           catch
           {
               Console.Write("Database not connected or data not found");
           }
           finally
           {
               connection.Close();
           }
           return dtoStaffLogin;
       }
    }
}
