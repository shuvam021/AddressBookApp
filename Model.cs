using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp
{
    /// <summary>Model of Address book app. Used for manipulate data</summary>
    internal class Model
    {
		// Attributes
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Number { get; set; }
		public Model(string firstName, string lastName, string address, string city, string state, string zip, string number)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Address = address;
			this.City = city;
			this.State = state;
			this.Zip = zip;
			this.Number = number;
		}
        public override string ToString()
        {
            return $"AddressBook: {this.FirstName}, {this.LastName}, {this.Number}, {this.Address}, {this.City}, {this.State}, {this.Zip}, {this.Number}";
		}
    }
}
