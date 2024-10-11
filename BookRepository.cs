using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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


        public void CreateBook()
        {
            Console.WriteLine("Enter Book Id");
            string bookid = Console.ReadLine();
            Console.WriteLine("Enter Book Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Book Author");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Book RentalPrice");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            decimal rentalprice = ValidateBookRentalPrice(price);

            try
            {
                using (var connection = new SqliteConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @" INSERT INTO BOOKS (BookId,Title, Author, RentalPrice) 
                                         VALUES (@id,@title, @author, @price);    ";

                    command.Parameters.AddWithValue("id", bookid);
                    command.Parameters.AddWithValue("title", title);
                    command.Parameters.AddWithValue("author", author);
                    command.Parameters.AddWithValue("price", rentalprice);
                   

                    var rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");
                    Console.WriteLine("Book Add Sucessfully");
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine("Error when adding book");
                Console.WriteLine(ex.Message);
            }

           
           

        }


        public void getbyid(string id)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM BOOKS WHERE BookId == @ID";
                    command.Parameters.AddWithValue("ID",id);
                    var reader = command.ExecuteReader();

                    if (reader.Read()) 
                    {
                        
                        Console.WriteLine($"BookId: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, RentalPrice: {reader["RentalPrice"]}");
                    }
                    else
                    {
                       
                        Console.WriteLine("No book found");
                    }

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                    
            }
           
            
        }

        public bool checkbook(string id)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM BOOKS WHERE BookId == @ID";
                    command.Parameters.AddWithValue("ID", id);
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;

                    }
                    else
                    {
                        return false;

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return false;

        }


        public void showbooks()
        {
            try
            {
                using (var connection = new SqliteConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM BOOKS ";
                    var reader = command.ExecuteReader();



                    if (!reader.Read())
                    {
                        Console.WriteLine("No books ");

                    }
                    while (reader.Read())
                    {
                        Console.WriteLine($"BookId: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, RentalPrice: {reader["RentalPrice"]}");
                    }
                   
                   

                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public void deletebook(string id)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"DELETE  FROM BOOKS WHERE BookId == @ID";
                    command.Parameters.AddWithValue("ID", id);
                 var row =   command.ExecuteNonQuery();

                    if (row != 0)
                    {
                        Console.WriteLine("Book deleted");

                    }
                    else
                    {
                        Console.WriteLine("book not found");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }



        public void UpdateBook()
        {


        }







        public decimal ValidateBookRentalPrice(decimal price)
        {
            while (price <= 0)
            {
                Console.WriteLine("Price must be possitive");
                Console.WriteLine("Enter a valid price");

                price = Convert.ToDecimal(Console.ReadLine());
            }
            return price;
        }


    }
}
