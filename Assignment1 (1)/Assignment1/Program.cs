using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            StudentManager sm = new StudentManager();

            do
            {
                Console.WriteLine("1.Add a student");
                Console.WriteLine("2.Display all student");
                Console.WriteLine("3.Search a student by ID");
                Console.WriteLine("4.Update a student");
                Console.WriteLine("5.Exit");
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Input your choice");
                        choice = int.Parse(Console.ReadLine());
                        if (choice < 0 || choice > 5)
                        {
                            throw new Exception();
                        }
                        break;


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please input your choice again !");
                    }


                }

                switch (choice)
                {
                    case 1:
                        {
                            sm.addStudent();
                            break;
                        }


                    case 2:
                        {
                            sm.displayStudent();
                            break;
                        }
                    case 3:
                        {
                            sm.searchStudent();
                            break;
                        }
                    case 4:
                        break;

                        
                    case 5:
                        break;



                }


            } while (choice != 5);


            Console.ReadKey();



        }
    }


}

