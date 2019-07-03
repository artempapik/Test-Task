using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Test_Task.Models;
using System.Linq;

namespace Test_Task.Controllers
{
	[Route("api/clients")]
	public class ClientsController : Controller
	{
		public ClientsController() { }

		[HttpGet]
		public IEnumerable<Client> GetClients()
		{
			using (var db = new ApplicationContext())
			{
				return db.Clients.ToList();
			}
		}
	}
}