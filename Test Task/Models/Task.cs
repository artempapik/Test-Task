using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Test_Task.Models
{
	public class Task
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ClientAddress { get; set; }

		[NotMapped]
		public string StartTime { get; set; }

		[NotMapped]
		public string EndTime { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int ClientId { get; set; }

		public Client Client { get; set; }
	}
}