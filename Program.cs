using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("#########################################");
            Console.WriteLine("Hello From the Console AddressBook app!");
            Console.WriteLine("#########################################\n");
            Console.WriteLine("Select operation*");
            Console.WriteLine("1. View all Address");
            Console.WriteLine("2. Add Address");
            Console.WriteLine("x. Press to exit");
            Console.Write("Choice: ");
            var userInput = Console.ReadLine();
            var addressBook = new Controller();
            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine();
                        addressBook.View();
                        break;
                    case "2":
                        Console.Write("First Name: ");
                        var firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        var lastName = Console.ReadLine();
                        Console.Write("Address: ");
                        var address = Console.ReadLine();
                        Console.Write("City: ");
                        var city = Console.ReadLine();
                        Console.Write("State: ");
                        var state = Console.ReadLine();
                        Console.Write("Zip: ");
                        var zip = Console.ReadLine();
                        Console.Write("Phone: ");
                        var phone = Console.ReadLine();
                        var newAddress = new Model(firstName, lastName, address, city, state, zip, phone);
                        Console.WriteLine("\n");
                        addressBook.Create(newAddress);
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Select a valid option");
                        break;
                }
                Console.Write("Select operation: ");
                userInput = Console.ReadLine();
                Console.WriteLine();
            }
        }
	}
}
