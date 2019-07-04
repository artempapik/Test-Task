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
						FirstName = "Vanya",
						LastName = "Popov",
						Address = "Alyaska",
						Phone = "096-044-38-42;068-448-02-56"
					},
					new Client
					{
						Id = 2,
						FirstName = "Artem",
						LastName = "Yakovlev",
						Address = "Ogaio",
						Phone = "098-278-16-76;065-545-22-21"
					},
					new Client
					{
						Id = 3,
						FirstName = "Tolik",
						LastName = "Sidorov",
						Address = "Tokio",
						Phone = "098-996-86-32"
					},
					new Client
					{
						Id = 4,
						FirstName = "Masha",
						LastName = "Gap",
						Address = "Moskow",
						Phone = "067-666-44-54"
					},
					new Client
					{
						Id = 5,
						FirstName = "Valik",
						LastName = "Surname",
						Address = "Kyiv",
						Phone = "050-050-99-55;063-224-33-34"
					}
				}
			);
			base.OnModelCreating(modelBuilder);
		}
	}
}