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
            try {
                var item = _addressList.Where(c => c.FirstName.Contains(searchPharase)).First();
                if(arg.FirstName != "") item.FirstName = arg.FirstName;
                if (arg.LastName != "") item.LastName = arg.LastName;
                if (arg.Address != "") item.Address = arg.Address;
                if (arg.City != "") item.City = arg.City;
                if (arg.City != "") item.State = arg.State;
                if (arg.Zip != "") item.Zip = arg.Zip;
                if (arg.Number != "") item.Number = arg.Number;
            }
            catch (InvalidOperationException e) { Console.WriteLine(e); }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
