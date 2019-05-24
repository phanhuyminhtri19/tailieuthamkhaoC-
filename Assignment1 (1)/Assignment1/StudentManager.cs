using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class StudentManager
    {
        List<Student> list = new List<Student>();
        public void addStudent()
        {
            string maSV;
            string hoTen;
            DateTime ngaySinh;
            string diaChi;
            string soDT;
            int currentYear = DateTime.Now.Year;

            
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhap ma so sinh vien");
                    maSV = Console.ReadLine();
                    if (maSV.Length == 0)
                    {
                        throw new Exception();
                    }
                    break;
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Xin vui long nhap lai ma sv");

                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Nhap ho ten sinh vien");
                    hoTen = Console.ReadLine();
                    if (hoTen.Length == 0)
                    {
                       
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Xin vui long nhap lai ten sv");

                }
            }
            while (true)
            {

              
                    
                    Console.WriteLine("Nhap ngay sinh sinh vien");
                     
                    ngaySinh = DateTime.Parse(Console.ReadLine());
                if(ngaySinh.Year > currentYear)
                {
                    Console.WriteLine("Nhập ngu vcl ");
                    throw new Exception();
                }


                break;
               
            }


            while (true)
            {
                try
                {
                    Console.WriteLine("Nhap dia chi cua sinh vien");
                    diaChi = Console.ReadLine();
                    if (diaChi.Length == 0)
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Xin vui long nhap lai dia chi cua sv");

                }
            }

            while (true)
            {

                try
                {
                    
                    Console.WriteLine("Nhap so dien thoai sinh vien");
                    soDT = Console.ReadLine();


                    if (soDT.Length == 0)
                    {
                        throw new Exception();
                    }
                    for (int i = 0; i < soDT.Length; i++)
                    {
                        if (!Char.IsDigit(soDT[i]))
                        {
                            Console.WriteLine("Phone must be nummber");
                            throw new Exception();
                        }
                       
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Xin vui long nhap lai so dien thoai sinh vien");

                }
                
                
            }
            Student stu = new Student(maSV, hoTen, ngaySinh, diaChi, soDT);
            list.Add(stu);


        }

        public void displayStudent()
        {

            foreach (Student stu in list)
            {
                Console.WriteLine("Ma SV : {0} | Ho Ten : {1} | Ngay Sinh : {2} | Dia Chi : {3} | So dien thoai : {4}"
                    ,stu.maSV,stu.hoten,stu.NgaySinh,stu.sodienthoai);
                Console.WriteLine();
            }
        }
        public void searchStudent()
        {
            string id;
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhap ma sinh vien ");
                    id = Console.ReadLine();
                    if (checkID(id))
                    {
                        throw new Exception();
                    }
                    break;


                }
                catch(Exception e)
                {
                    Console.WriteLine("Ma sinh vien khong ton tai hoac sai");
                    return;
                }

            }
            foreach(Student stu in list)
            {
                if (stu.maSV.Equals(id))
                {
                    Console.WriteLine("Ma SV : {0} | Ho Ten : {1} | Ngay Sinh : {2} | Dia Chi : {3} | So dien thoai : {4}"
                   , stu.maSV, stu.hoten, stu.NgaySinh, stu.sodienthoai);
                    Console.WriteLine();
                }
            }


        }
        public Boolean checkID(string id)
        {
            foreach(Student stu in list)
            {
                if (id.Equals(stu.maSV))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
