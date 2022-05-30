using Festival.Shared.Models;
using Festival.Shared.Views;
using Dapper;
using Npgsql;

namespace Festival.Server.Models
{
    public class DBContext
    {
        public string connString { get; set; }
        public NpgsqlConnection connection { get; set; }
       
        public DBContext()
        {
            //connecter til vores database
            connString = "User ID=dbadmin; Password = GreenL1ve; Host = greenlive.postgres.database.azure.com; Port = 5432; Database = greenlive; ";
            connection = new NpgsqlConnection(connString);
        }

        

    }
}
