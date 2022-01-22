using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
