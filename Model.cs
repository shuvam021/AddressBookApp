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
		public Model(Dictionary<string, string> kwargs)
		{
			this.FirstName = kwargs["firstName"];
			this.LastName = kwargs["lastName"];
			this.Address = kwargs["address"];
			this.City = kwargs["city"];
			this.State = kwargs["state"];
			this.Zip = kwargs["zip"];
			this.Number = kwargs["number"];
		}
        public override string ToString()
        {
            return $"AddressBook: " +
				$"First Name = {this.FirstName}, " +
				$"Last Name = {this.LastName}, " +
				$"Address = {this.Address}, " +
				$"City = {this.City}, " +
				$"State = {this.State}, " +
				$"Zip = {this.Zip}, " +
				$"Phone = {this.Number}";
		}
    }
}
