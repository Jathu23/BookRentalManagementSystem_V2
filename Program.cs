
using BookRentalManagementSystem_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Startpogram();


        }

        static void Startpogram()
        {
            var bookmanage = new BookRepository();
            bool exitstatus = false;

            while (!exitstatus)
            {
                Console.WriteLine("Book Rental Management System:");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update a Book");
                Console.WriteLine("4. Delete a Book");
                Console.WriteLine("5. showbooks");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option:");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        bookmanage.CreateBook();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter Book Id");
                        string id =  Console.ReadLine();
                        bookmanage.getbyid(id);
                        break;
                    //case "3":
                    //    Console.Clear();
                    //    bookmanage.UpdateBook();
                    //    break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter Book Id fo delete");
                        string did = Console.ReadLine();
                        bookmanage.deletebook(did);
                        break;
                    case "5":
                        Console.Clear();
                        bookmanage.showbooks();
                        break;
                    case "6":
                        exitstatus = true;
                        break;


                }

            }


        }


    }
}