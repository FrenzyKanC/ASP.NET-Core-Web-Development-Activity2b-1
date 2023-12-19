using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System;
using ASP.NET_Core_Web_Development_Activity2b_1.Models;
using System.Data.SqlClient;

// connectionString kommt aus der DB properties
// siehe SQLCommand.Parameters Property om dem Docs für mehr Info

namespace ASP.NET_Core_Web_Development_Activity2b_1.Services
{
    public class UsersDAO
    {
        // das @ lässt mehrere " in einem string zu
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""ASP.NET_Core_Web_Development_Activity Db"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {

            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.USers Where username = @username AND password = @password";

            // "using" sorgt dafür, dass der code in der {} nmit der SqlConnection genutzt wird und danach sofort
            // geschlossen wird damit andere anwendungen sie wieder nutzen können
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // consturctor der das sqlStatement nimmt und die db connection
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // parameter für das SqlCommand
                // ("@welcherParameterGeändertWerdenSoll", Datentyp, 40);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return success;
            // return true if found in db

        }
    }
}
