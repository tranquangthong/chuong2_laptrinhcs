using System;

enum EmployeeLevel { Junior, Mid, Senior, Manager }
enum ContractType { Permanent, Contract }

class Program
{
    static void Main()
    {
        EmployeeLevel level = NhapEnum<EmployeeLevel>("Nhap cap bac (Junior, Mid, Senior, Manager): ");
        ContractType contract = NhapEnum<ContractType>("Nhap loai hop dong (Permanent, Contract): ");

        double baseSalary = NhapSo("Nhap luong co ban (hoac enter de dung mac dinh): ", -1);
        double allowance = NhapSo("Nhap phu cap (hoac enter de dung mac dinh = 0): ", 0);

        double totalSalary = TinhLuongNhanVien(level, contract, baseSalary, allowance);
        Console.WriteLine($"Tong luong cua nhan vien la: {totalSalary:N0} VND");
    }

    static T NhapEnum<T>(string message) where T : struct
    {
        Console.Write(message);
        string input;
        while (!Enum.TryParse(input = Console.ReadLine(), true, out T result))
        {
            Console.Write("Gia tri khong hop le, vui long nhap lai: ");
        }
        return (T)Enum.Parse(typeof(T), input, true);
    }

    static double NhapSo(string message, double defaultValue)
    {
        Console.Write(message);
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return defaultValue;

        while (!double.TryParse(input, out double value) || value < 0)
        {
            Console.Write("Gia tri khong hop le, vui long nhap lai: ");
            input = Console.ReadLine();
        }
        return double.Parse(input);
    }

    static double TinhLuongNhanVien(EmployeeLevel level, ContractType contract, double baseSalary = -1, double allowance = 0)
    {
        if (baseSalary == -1) baseSalary = level switch
        {
            EmployeeLevel.Junior => 7000000,
            EmployeeLevel.Mid => 12000000,
            EmployeeLevel.Senior => 20000000,
            EmployeeLevel.Manager => 30000000,
            _ => 0
        };

        double contractMultiplier = contract == ContractType.Permanent ? 1.2 : 1.0;
        return (baseSalary * contractMultiplier) + allowance;
    }
}
