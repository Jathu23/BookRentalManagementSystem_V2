using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookRepository
    {
        string connectionstring = "Data Source =BookRentalManagement ";

        public void createDataBase()
        {
            using (var connection = new SqliteConnection(connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                
                command.CommandText = @"
        CREATE TABLE IF NOT EXISTS BOOKS(
            BookId TEXT PRIMARY KEY,
            Title TEXT NOT NULL,
            Author TEXT NOT NULL,
            RentalPrice REAL NOT NULL
        );";

             
               command.ExecuteNonQuery();

                command.CommandText = @"
         INSERT INTO BOOKS (BookId,Title, Author, RentalPrice) 
        VALUES ('BOOK_001 ','Jeans', 'Shankar', 1.0);";


                var rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
        }

    }
}
