﻿
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
            var Db = new BookRepository();
            Db.createDataBase();


        }

        
    }
}