using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    internal class Program
	{
        public static void TempData(Controller book)
        {
            var data1 = new Dictionary<string, string>()
                        {
                            { "firstName", "John" },
                            { "lastName", "Doe" },
                            { "address", "Knowhere" },
                            { "city", "Knowhere" },
                            { "state", "Knowhere" },
                            { "zip", "123456" },
                            { "number", "1234567890" }
                        };
            var newAddress1 = new Model(data1);
            book.Create(newAddress1);
            var data2 = new Dictionary<string, string>()
                        {
                            { "firstName", "Jane" },
                            { "lastName", "Doe" },
                            { "address", "Knowhere" },
                            { "city", "Knowhere" },
                            { "state", "Knowhere" },
                            { "zip", "798745" },
                            { "number", "9876543210" }
                        };
            var newAddress2 = new Model(data2);
            book.Create(newAddress2);
        }
        public static Dictionary<string, string> CreateOrUpdateInputs()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            Console.Write("First Name: ");
            data["firstName"] = Console.ReadLine();
            Console.Write("Last Name: ");
            data["lastName"] = Console.ReadLine();
            Console.Write("Address: ");
            data["address"] = Console.ReadLine();
            Console.Write("City: ");
            data["city"] = Console.ReadLine();
            Console.Write("State: ");
            data["state"] = Console.ReadLine();
            Console.Write("Zip: ");
            data["zip"] = Console.ReadLine();
            Console.Write("Phone: ");
            data["number"] = Console.ReadLine();
            return data;
        }

        public static void OptionsCheck()
        {
            Console.WriteLine("1. View all Address");
            Console.WriteLine("2. Add Address");
            Console.WriteLine("3. Edit Address");
            Console.WriteLine("4. Delete Address");
            Console.WriteLine("5. Search by Location");
            Console.WriteLine("6. Count no. of Address(i.e. Search by Location)");
            Console.Write("Choice or E[x]it: ");
        }
        static void Main(string[] args)
		{
            Console.WriteLine("#########################################");
            Console.WriteLine("Hello From the Console AddressBook app!");
            Console.WriteLine("#########################################\n");
            Console.WriteLine("Select operation*");
            OptionsCheck();
            var userInput = Console.ReadLine();
            var addressBook = new Controller();
            var data = new Dictionary<string, string>();
            string searchPhrase;
            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        addressBook.View();
                        break;
                    case "2":
                        //data = CreateOrUpdateInputs();
                        //var newAddress = new Model(data);
                        //addressBook.Create(newAddress);
                        TempData(addressBook);
                        break;
                    case "3":
                        Console.Write("Enter First Name for update address: ");
                        searchPhrase = Console.ReadLine();
                        data = CreateOrUpdateInputs();
                        var updateAddress = new Model(data);
                        addressBook.Update(searchPhrase, updateAddress);
                        break;
                    case "4":
                        Console.Write("Enter First Name for deleting address: ");
                        searchPhrase = Console.ReadLine();
                        Console.WriteLine("are you sure? [Y]es/[A]ny-key: ");
                        if (Console.ReadLine()?.ToLower() == "y") addressBook.Delete(searchPhrase);
                        break;
                    case "5":
                        Console.Write("Enter State/City Name for Searching address: ");
                        searchPhrase = Console.ReadLine();
                        addressBook.View(addressBook.SearchByLocation(searchPhrase));
                        break;
                    case "6":
                        Console.Write("Enter State/City Name for Count address: ");
                        searchPhrase = Console.ReadLine();
                        Console.WriteLine(addressBook.CountContact(searchPhrase));
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Select a valid option");
                        break;
                }
                Console.Write("Select operation or E[x]it: ");
                userInput = Console.ReadLine();
            }
        }
	}
}
