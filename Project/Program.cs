using System;
using System.Globalization;
using Project.Entities;
using Project.Entities.Exception;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine("Enter Account data");
                System.Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                System.Console.Write("Holder: ");
                string holder = Console.ReadLine();

                System.Console.Write("Initial Balance: ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                System.Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                System.Console.WriteLine();
                System.Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(number, holder, initialBalance, withdrawLimit);

                acc.Withdraw(amount);

                System.Console.Write($"New balance: {acc.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch(DomainException e)
            {
                System.Console.WriteLine("Withdraw error: " + e.Message);
            }
            catch(FormatException e)
            {
                System.Console.WriteLine("Format error: " + e.Message);
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}