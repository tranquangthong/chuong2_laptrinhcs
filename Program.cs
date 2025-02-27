using System;
namespace TranQuangThong
{
    class Program
    {
        public enum EmployeeLevel
        {
            Intern,
            Junior,
            Mid,
            Senior,
            Master
        }
        public static void Main()
        {
            Console.Write("Nhap cap bac: ");
            string input = Console.ReadLine();
            if(!Enum.TryParse< EmployeeLevel>(input,true,out EmployeeLevel level))
            {
                Console.WriteLine("Cap bac khong hop le!");
                return;
            }
            int salary = 0;
            switch (level)
            {
                case EmployeeLevel.Intern:
                    salary = 5000000;
                    break;
                case EmployeeLevel.Junior:
                    salary = 15000000;
                    break;
                case EmployeeLevel.Mid:
                    salary = 35000000;
                    break;
                case EmployeeLevel.Senior:
                    salary = 50000000;
                    break;
                case EmployeeLevel.Master:
                    salary = 100000000;
                    break;
                default:
                    Console.WriteLine("Cap bac khong xac dinh!");
                    return;
            }
            Console.WriteLine($"Luong cua ban la: {salary:N0} VND");
        }
    }
}
