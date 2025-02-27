using System;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        Employee[] employees = NhapDanhSachNhanVien();

        InDanhSachNhanVien(employees);
        Console.WriteLine($"\nTong luong: {TinhTongLuong(employees):N0} VND");
        Employee highestPaid = TimNhanVienLuongCaoNhat(employees);
        Console.WriteLine($"Nhan vien co luong cao nhat: {highestPaid.Name}, Luong: {highestPaid.Salary:N0} VND");
    }

    static Employee[] NhapDanhSachNhanVien()
    {
        Console.Write("Nhap so luong nhan vien: ");
        int n = int.Parse(Console.ReadLine());
        Employee[] employees = new Employee[n];

        for (int i = 0; i < n; i++)
        {
            employees[i] = new Employee();
            Console.Write($"Nhap ten nhan vien {i + 1}: ");
            employees[i].Name = Console.ReadLine();

            Console.Write($"Nhap tuoi nhan vien {i + 1}: ");
            employees[i].Age = int.Parse(Console.ReadLine());

            Console.Write($"Nhap luong nhan vien {i + 1}: ");
            employees[i].Salary = double.Parse(Console.ReadLine());
        }

        return employees;
    }

    static void InDanhSachNhanVien(Employee[] employees)
    {
        Console.WriteLine("\nDanh sach nhan vien:");
        foreach (var emp in employees)
        {
            Console.WriteLine($"Ten: {emp.Name}, Tuoi: {emp.Age}, Luong: {emp.Salary:N0} VND");
        }
    }

    static double TinhTongLuong(Employee[] employees)
    {
        double totalSalary = 0;
        foreach (var emp in employees)
        {
            totalSalary += emp.Salary;
        }
        return totalSalary;
    }

    static Employee TimNhanVienLuongCaoNhat(Employee[] employees)
    {
        Employee highestPaid = employees[0];
        foreach (var emp in employees)
        {
            if (emp.Salary > highestPaid.Salary)
            {
                highestPaid = emp;
            }
        }
        return highestPaid;
    }
}
