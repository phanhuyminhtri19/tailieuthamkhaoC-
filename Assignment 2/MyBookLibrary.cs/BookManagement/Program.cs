using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookLibrary.cs;


namespace BookManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose = 0;
            BookLibrary lib = new BookLibrary();
            do
            {
                Console.WriteLine("1. Add New A Book");
                Console.WriteLine("2. Update A Book");
                Console.WriteLine("3. Delete A Book");
                Console.WriteLine("4. Print Out All Book");
                Console.WriteLine("5. Quit");
                while(true)
                {
                    try
                    {
                        Console.WriteLine("YOUR CHOCE: ");
                        choose = int.Parse(Console.ReadLine());
                        if(choose<=0 || choose >5)
                        {
                            Console.WriteLine("Range between 1 and 5");
                            throw new Exception();
                        }
                        break;
                    }
                    catch (Exception ex)
                    {

                        
                    }
                }
               
                switch (choose)
                {
                    case 1:
                        lib.AddNewBook();
                        break;
                    case 2:
                        int IdToUpdate = 0;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Input Book's Id: ");
                                String BookId = Console.ReadLine();
                                for (int i = 0; i < BookId.Length; i++)
                                {
                                    if (!Char.IsDigit(BookId[i]))
                                    {
                                        Console.WriteLine("Please input right number");
                                        throw new Exception();
                                    }
                                }
                                IdToUpdate = int.Parse(BookId);
                                //if (checkId(id) == true)
                                //{
                                //    Console.WriteLine("Your id has been registed");
                                //    throw new Exception();
                                //}

                                break;
                            }
                            catch (Exception ex)
                            {

                                //Console.WriteLine(ex.Message);
                            }
                        }
                        lib.UpdateBook(IdToUpdate);
                        break;
                    case 3:

                        int IdToDelete = 0;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Input Book's Id: ");
                                String BookId = Console.ReadLine();
                                for (int i = 0; i < BookId.Length; i++)
                                {
                                    if (!Char.IsDigit(BookId[i]))
                                    {
                                        Console.WriteLine("Please input right number");
                                        throw new Exception();
                                    }
                                }
                                IdToDelete = int.Parse(BookId);
                                //if (checkId(id) == true)
                                //{
                                //    Console.WriteLine("Your id has been registed");
                                //    throw new Exception();
                                //}

                                break;
                            }
                            catch (Exception ex)
                            {

                                //Console.WriteLine(ex.Message);
                            }
                        }
                        if (lib.checkId(IdToDelete))
                        {
                            Console.WriteLine(" Do you want to delete that book ( YES to delete) ");
                            String option = Console.ReadLine();
                            if (option.Equals("YES", StringComparison.OrdinalIgnoreCase))
                            {
                                lib.DeleteBook(IdToDelete);
                            }
                        }

                        break;
                    case 4:
                        lib.PrintAllBook();
                        break;
                    case 5: default: Console.WriteLine("Google bye "); break;
                }

            }
            while (choose >= 1 && choose < 5);
        }
    }
}
