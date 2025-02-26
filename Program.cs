//Bài toán chuyển đổi tiền tệ
using System;
namespace TranQuangThong
{
    class Program
    {
        public static double ChuyenDoiTien(double soTien, double tyGia = 23000)
        {
            return soTien * tyGia;
        }
        public static void Main()
        {
            Console.Write("Nhap so tien can chuyen doi: ");
            double soTien = Convert.ToDouble(Console.ReadLine());
            //Hàm với tý giá mặc định
            Console.WriteLine($"Da chuyen {soTien}$ thanh {ChuyenDoiTien(soTien)} VND");
            //Hàm với tỷ giá tùy chỉnh
            Console.WriteLine($"Da chuyen {soTien}$ thanh {ChuyenDoiTien(soTien,24000)} VND");
        }
    }
}