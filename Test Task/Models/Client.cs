using System.Collections.Generic;

namespace Test_Task.Models
{
	public class Client
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		//change to one-to-many relationship
		public string Phone { get; set; }

		public List<Task> Tasks { get; set; }
	}
}