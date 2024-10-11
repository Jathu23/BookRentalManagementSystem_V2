using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Book
    {
        public Book(string bookid, string title, string author, decimal rentalPrice)
        {
            this.bookid = bookid;
            this.title = title;
            this.author = author;
            this.rentalPrice = rentalPrice;
           
        }

        public string bookid {  get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public decimal rentalPrice { get; set; }

      



    }
}
