using System;
using System.Data.SqlClient;

namespace DLL_Login
{
   public class DB_Login
   {
       private SqlConnection connection;
       private SqlDataReader reader;
       private SqlCommand command;
       private const String DBlogin = "F20ST2ITS2201907648";

       public bool LoginStaff(String MedarbejderID, String pw)
       {
           bool result = false;
           string connectionString = (@"Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";Integrated Security=False;User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
           connection = new SqlConnection(connectionString);
           command = new SqlCommand();
           string queryString = "Select * from Staff_Table where MedarbejderID = '" + MedarbejderID + "'";

           try
           {
               connection.Open();
               using (command = new SqlCommand(queryString, connection))
               {
                   reader = command.ExecuteReader();
                   while (reader.Read())
                   {
                       if (reader["MedarbejderID"].ToString() == MedarbejderID && reader["Password"].ToString() == pw)
                       {
                           result = true;
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
           return result;
       }
    }
}
