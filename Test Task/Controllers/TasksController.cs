using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Test_Task.Models;
using System.Linq;

namespace Test_Task.Controllers
{
	[Route("api/tasks")]
	public class TasksController : Controller
	{
		public TasksController() { }

		[HttpGet("{clientId}")]
		public IEnumerable<Task> GetClientTasks(int clientId)
		{
			using (var db = new ApplicationContext())
			{
				return db.Tasks
					.Where(task => task.ClientId == clientId)
					.ToList();
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody]Task task)
		{
			using (var db = new ApplicationContext())
			{
				db.Tasks.Add(task);
				db.SaveChanges();
				return Ok(task);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			using (var db = new ApplicationContext())
			{
				foreach (var task in db.Tasks.ToList())
				{
					if (task.Id == id)
					{
						db.Tasks.Remove(task);
						db.SaveChanges();
						return Ok(task);
					}
				}
			}

			return default;
		}

		[HttpPut]
		public IActionResult Put([FromBody]Task task)
		{
			using (var db = new ApplicationContext())
			{
				foreach (var t in db.Tasks.ToList())
				{
					if (t.Id == task.Id)
					{
						t.Name = task.Name;
						t.Description = task.Description;
						t.ClientAddress = task.ClientAddress;
						db.SaveChanges();
						return Ok(task);
					}
				}
			}

			return default;
		}
	}
}