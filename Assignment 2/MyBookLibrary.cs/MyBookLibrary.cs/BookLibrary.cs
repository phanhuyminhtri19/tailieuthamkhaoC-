using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary.cs
{
    public class BookLibrary
    {
        List<Book> listBook = new List<Book>();
        public void AddNewBook()
        {

            // int id = int.Parse(Console.ReadLine());
            int id = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Input Book's Id: ");
                    string BookId = Console.ReadLine();
                    for (int i = 0; i < BookId.Length; i++)
                    {
                        if (!Char.IsDigit(BookId[i]))
                        {
                            Console.WriteLine("Please input right number");
                            throw new Exception();
                        }
                    }
                    id = int.Parse(BookId);
                    if (checkId(id) == true)
                    {
                        Console.WriteLine("Your id has been registed");
                        throw new Exception();
                    }

                    break;
                }
                catch (Exception ex)
                {

                    //Console.WriteLine(ex.Message);
                }
                //break;
            }
            String name = "";
            while (true)
            {
                try
                {
                    Console.WriteLine("Input Book's Name: ");
                    name = Console.ReadLine();
                    if (name.Length == 0 || name == null)
                    {
                        Console.WriteLine("Name is required");
                        throw new Exception();
                    }
                    break;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            String publisher = "";
            while (true)
            {
                try
                {
                    Console.WriteLine("Input Book's Publisher: ");
                    publisher = Console.ReadLine();
                    if (publisher.Length == 0 || publisher == null)
                    {
                        Console.WriteLine("Publisher is required");
                        throw new Exception();
                    }
                    //  date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }

                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }

            double price = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Input Book's Price: ");
                    price = Double.Parse(Console.ReadLine());
                    //  date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Please input right number");
                }
            }


            Book _book = new Book(id, name, publisher, price);
            listBook.Add(_book);
            Console.WriteLine("Added a new book successfully");
        }
        public Boolean UpdateBook(int id)
        {
            foreach (var book in listBook)
            {
                if (book.Id == id)
                {
                    String name = "";
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Input Book's Name: ");
                            name = Console.ReadLine();
                            if (name.Length == 0 || name == null)
                            {
                                Console.WriteLine("Name is required");
                                throw new Exception();
                            }
                            break;
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    String publisher = "";
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Input Book's Publisher: ");
                            publisher = Console.ReadLine();
                            if (publisher.Length == 0 || publisher == null)
                            {
                                Console.WriteLine("Publisher is required");
                                throw new Exception();
                            }
                            //  date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            break;
                        }

                        catch (Exception ex)
                        {
                            // Console.WriteLine(ex.Message);
                        }
                    }

                    double price = 0;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Input Book's Price: ");
                            price = Double.Parse(Console.ReadLine());

                            //  date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            break;
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Please input right number");
                        }
                    }

                    book.Name = name;
                    book.Publisher = publisher;
                    book.Price = price;
                    return true;
                }
            }
            return false;
        }
        public Boolean DeleteBook(int id)
        {
            foreach (var book in listBook)
            {
                if (book.Id == id)
                {
                    listBook.Remove(book);
                    return true;
                }
            }
            return false;
        }
        public void PrintAllBook()
        {
            if (listBook.Count == 0)
            {
                Console.WriteLine("Nothing to print out");
            }
            else
            {
                String s = String.Format("{0,10} | {1,10} | {2,10} | {3,10}", "Id", "Name", "Publisher", "Price");
                Console.WriteLine(s);
                foreach (var book in listBook)
                {
                    String format = String.Format("{0,10} | {1,10} | {2,10} | {3,10}", book.Id, book.Name, book.Publisher, book.Price);
                    Console.WriteLine(format);
                }
            }

        }
        public Boolean checkId(int id)
        {
            bool find = false;
            for (int i = 0; i < listBook.Count; i++)
            {
                Book book = listBook[i];
                if (book.Id == id)
                {
                    find = true;
                }
            }
            return find;

        }

    }
}
