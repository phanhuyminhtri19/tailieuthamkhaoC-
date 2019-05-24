using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Student
    {
        public string maSV { set; get; }
        public string Hoten;

        public string hoten
        {
            get { return Hoten; }
            set { Hoten = value; }
        }

        public DateTime Ngaysinh;

        public DateTime NgaySinh
        {
            get { return Ngaysinh; }
            set { Ngaysinh = value; }
        }


        private string DiaChi;

        public string Diachi
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }

        private string Sodienthoai;

        public string sodienthoai
        {
            get { return Sodienthoai; }
            set { Sodienthoai = value; }
        }


        public Student()
        {

        }

        public Student(string maSV, string hoten, DateTime ngaySinh, string diachi, string sodienthoai)
        {
            this.maSV = maSV;
            this.hoten = hoten;
            NgaySinh = ngaySinh;
            Diachi = diachi;
            this.sodienthoai = sodienthoai;
        }
    }
}
