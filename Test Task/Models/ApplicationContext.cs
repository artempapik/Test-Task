using Microsoft.EntityFrameworkCore;

namespace Test_Task.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() : base() => Database.EnsureCreated();

		public DbSet<Client> Clients { get; set; }

		public DbSet<Task> Tasks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=clientsdb;Trusted_Connection=True;");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Client>().HasData
			(
				new[]
				{
					new Client
					{
						Id = 1,
						FirstName = "artem",
						LastName = "yakovlev",
						Address = "kp2b",
						Phone = "2-93-23;2-78-27"
					},
					new Client
					{
						Id = 2,
						FirstName = "kolya",
						LastName = "irzhov",
						Address = "burhava",
						Phone = "50-65-68"
					},
					new Client
					{
						Id = 3,
						FirstName = "oleg",
						LastName = "kaidanny",
						Address = "anoshkina",
						Phone = "2-72-22"
					}
				}
			);
			base.OnModelCreating(modelBuilder);
		}
	}
}