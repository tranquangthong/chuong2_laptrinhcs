using System;

enum EmployeeLevel
{
    Junior,
    Mid,
    Senior,
    Manager
}

enum ContractType
{
    Permanent,
    Contract
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap cap bac (Junior, Mid, Senior, Manager): ");
        string inputLevel = Console.ReadLine();
        EmployeeLevel level;
        while (!Enum.TryParse(inputLevel, true, out level))
        {
            Console.Write("Cap bac khong hop le, vui long nhap lai: ");
            inputLevel = Console.ReadLine();
        }

        Console.Write("Nhap loai hop dong (Permanent, Contract): ");
        string inputContract = Console.ReadLine();
        ContractType contract;
        while (!Enum.TryParse(inputContract, true, out contract))
        {
            Console.Write("Loai hop dong khong hop le, vui long nhap lai: ");
            inputContract = Console.ReadLine();
        }

        Console.WriteLine($"Ban da chon: Cap bac {level}, Hop dong {contract}");
    }
}
