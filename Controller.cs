using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    /// <summary>Controller for Address book App. Containd all methods to perform operation</summary>
    internal class Controller
    {
        private Dictionary<string, Model> AddressList { get; set; } = new Dictionary<string, Model>();

        /// <summary>Search Address book for matching first name.</summary>
        /// <param name="searchPhrase"></param>
        /// <returns>Model instance</returns>
        private KeyValuePair<string, Model> Search(string searchPhrase)
        {
            var itemList = AddressList
                .Where(c => c.Value.FirstName.Contains(searchPhrase))
                .DefaultIfEmpty()
                .First();
            return itemList;
        }
        public Dictionary<string, Model> SearchByLocation(string searchPhrase)
        {
            var result = new Dictionary<string, Model>();
            foreach (var (key, value) in AddressList)
            {
                if (value.State.Equals(searchPhrase) || value.City.Equals(searchPhrase))
                    result[key] = value;
            }
            return result;
        }
        /// <summary>Count found Contact details</summary>
        /// <param name="searchPhrase">State or City</param>
        /// <returns>Count searched value</returns>
        public int CountContact(string searchPhrase)
        {
            return SearchByLocation(searchPhrase).Count;
        }

        /// <summary>Creates new Address Instance.</summary>
        /// <param name="arg">arg is instance Model</param>
        public void Create(Model arg)
        {
            string name = $"{arg.FirstName} {arg.LastName}";
            if (Search(arg.FirstName).Key == null)
            {
                AddressList[name] = arg;
            }
            else
                Console.WriteLine("Please Try new name");
        }

        /// <summary>Views all address this instance.</summary>
        public void View()
        {
            foreach (var item in AddressList)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        /// <summary>Overload View method for view custom dictionary date.</summary>
        public void View(Dictionary<string, Model> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }


        /// <summary>Updates the specified search phrase.</summary>
        /// <param name="searchPhrase">The search phrase is for find item to edit.</param>
        /// <param name="arg">The argument is an instance of Model class.</param>
        public void Update(string searchPhrase, Model arg)
        {
            var item = Search(searchPhrase);
            if (searchPhrase != string.Empty && item.Key != null)
            {
                if (arg.FirstName != "") item.Value.FirstName = arg.FirstName;
                if (arg.LastName != "") item.Value.LastName = arg.LastName;
                if (arg.Address != "") item.Value.Address = arg.Address;
                if (arg.City != "") item.Value.City = arg.City;
                if (arg.State != "") item.Value.State = arg.State;
                if (arg.Zip != "") item.Value.Zip = arg.Zip;
                if (arg.Number != "") item.Value.Number = arg.Number;
                Console.WriteLine("\t>>>Address Updated...");
            }
            else Console.WriteLine("\t>>>Not found\n");
        }

        /// <summary>Delete the specified search phrase.</summary>
        /// <param name="searchPhrase">The search phrase is for find item to edit.</param>
        public void Delete(string searchPhrase)
        {
            var item = Search(searchPhrase);
            if (item.Key != null)
            {
                AddressList.Remove(item.Key);
                Console.WriteLine("\t>>>Address Deleted...");
            }
            else Console.WriteLine("\t>>>Not found\n");
        }
        public void SortByName()
        {
            try
            {
                this.View(AddressList.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
