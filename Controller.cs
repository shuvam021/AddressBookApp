using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    /// <summary>Controller for Address book App. Containd all methods to perform operation</summary>
    internal class Controller
    {
        private List<Model> _addressList { get; set; } = new List<Model>();

        /// <summary>Creates new Address Instance.</summary>
        /// <param name="arg">arg is instance Model</param>
        private Model search(string searchPharase)
        {
            var itemList = _addressList.Where(c => c.FirstName.Contains(searchPharase));
            if (itemList.Count() == 0) return null;
            return itemList.First();
        }
        public void Create(Model arg)
        {
            _addressList.Add(arg);
        }
        /// <summary>Views all address this instance.</summary>
        public void View()
        {
            foreach (var item in _addressList)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>Updates the specified search pharase.</summary>
        /// <param name="searchPharase">The search pharase is for find item to edit.</param>
        /// <param name="arg">The argument is an instance of Model class.</param>
        public void Update(string searchPharase, Model arg)
        {
            var item = search(searchPharase);
            if (item != null)
            {
                if(arg.FirstName != "") item.FirstName = arg.FirstName;
                if (arg.LastName != "") item.LastName = arg.LastName;
                if (arg.Address != "") item.Address = arg.Address;
                if (arg.City != "") item.City = arg.City;
                if (arg.City != "") item.State = arg.State;
                if (arg.Zip != "") item.Zip = arg.Zip;
                if (arg.Number != "") item.Number = arg.Number;
                Console.WriteLine("\t>>>Address Updated...");
            }
            else Console.WriteLine("\t>>>Not found\n");
        }
        public void Delete(string searchPharase)
        {
            var item = search(searchPharase);
            if (item != null) {
                _addressList.Remove(item);
                Console.WriteLine("\t>>>Address Deleted...");
            }
            else Console.WriteLine("\t>>>Not found\n");
        }
    }
}
