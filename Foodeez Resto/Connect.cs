using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;

namespace Foodeez_Resto
{
    public class Connect
    {
        // Connection String for MYSQL database
        private static string myConnectionString = "server=localhost; uid=root; pwd=; database=restaurantdb";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(myConnectionString);
        }

        public static void HandleException(MySqlException ex)
        {
            Console.WriteLine("MySQL Error:" + ex.Message);
            Console.WriteLine("MySQL Error:" + ex.ErrorCode);
            Console.WriteLine("MySQL Error:" + ex.SqlState);
        }

    }
}
