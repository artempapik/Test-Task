using System;

namespace Test_Task.Models
{
	public class Task
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ClientAddress { get; set; }

		//public DateTime StartTime { get; set; }

		//public DateTime EndTime { get; set; }

		public int ClientId { get; set; }

		public Client Client { get; set; }
	}
}