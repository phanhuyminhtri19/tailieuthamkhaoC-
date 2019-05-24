using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
   public class BookManager
    {
        List<Book> list = new List<Book>();


        public void addBook()
        {
            int id = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Id Book: ");
                    string BookId = Console.ReadLine();
                    for (int i = 0; i < BookId.Length; i++)
                    {
                        if (!Char.IsDigit(BookId[i]))
                        {
                            Console.WriteLine("Please enter right number ");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
