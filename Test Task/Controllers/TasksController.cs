using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Test_Task.Models;
using System.Linq;
using System;

namespace Test_Task.Controllers
{
	[Route("api/tasks")]
	public class TasksController : Controller
	{
		[HttpGet("{clientId}")]
		public IEnumerable<Task> GetClientTasks(int clientId)
		{
			using (var db = new ApplicationContext())
			{
				var tasks = db.Tasks
					.Where(task => task.ClientId == clientId)
					.ToList();

				foreach (var task in tasks)
				{
					task.StartTime = task.StartDate.ToString("dd/MM/yyyy");
					task.EndTime = task.EndDate.ToString("dd/MM/yyyy");
				}

				return tasks;
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody]Task task)
		{
			task.StartDate = DateTime.ParseExact(task.StartTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			task.EndDate = DateTime.ParseExact(task.EndTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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

						t.StartTime = task.StartTime;
						t.EndTime = task.EndTime;
						t.StartDate = DateTime.ParseExact(t.StartTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
						t.EndDate = DateTime.ParseExact(t.EndTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);

						db.SaveChanges();
						return Ok(task);
					}
				}
			}

			return default;
		}
	}
}