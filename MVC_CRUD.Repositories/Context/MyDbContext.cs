using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Entities.Models;
using System.Data;

namespace MVC_CRUD.Repositories.Context
{
	public class MyDbContext : IdentityDbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }

		public DbSet<Supplier> Suppliers { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<StockAlert> StockAlerts { get; set; }

		public DbSet<Inventory> Inventorys { get; set; }

		public DbSet<Users> Users { get; set; }

		public DbSet<Sales> Sales { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{


		//	// Seeding a  'Administrator' role to AspNetRoles table
		//	modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b", Name = "Admin", NormalizedName = "ADMIN" }, new IdentityRole { Id = "540fa4db-060f-4f1b-b60a-dd199bfe4111", Name = "SuperAdmin", NormalizedName = "SuperAdmin" });


		//	//a hasher to hash the password before seeding the user to the db
		//	var hasher = new PasswordHasher<Users>();


		//	//Seeding the User to AspNetUsers table
		//	modelBuilder.Entity<Users>().HasData(
		//	 new Users
		//	 {
		//		 Id = "62fe5285-fd68-4711-ae93-673787f4ac66", // primary key
		//		 FullName = "Admin",
		//		 NormalizedUserName = "ADMIN",
		//		 Email = "admin@admin.com",
		//		 NormalizedEmail = "admin@admin.com".ToUpper(),
		//		 PasswordHash = hasher.HashPassword(null, "123456789"),
		//		 EmailConfirmed = true
		//	 },
		//	 new Users
		//	 { // primary key
		//		 Id = "62fe5285-fd68-4711-ae93-673787f4a111",
		//		 FullName = "SuperAdmin",
		//		 NormalizedUserName = "SuperAdmin",
		//		 Email = "super@super.com",
		//		 NormalizedEmail = "super@super.com".ToUpper(),
		//		 PasswordHash = hasher.HashPassword(null, "123456789"),
		//		 EmailConfirmed = true
		//	 }
		//	);


		//	//Seeding the relation between our user and role to AspNetUserRoles table
		//	modelBuilder.Entity<IdentityUserRole<string>>().HasData(
		//	 new IdentityUserRole<string>
		//	 {
		//		 RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b",
		//		 UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
		//	 }, new IdentityUserRole<string>
		//	 {
		//		 RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
		//		 UserId = "62fe5285-fd68-4711-ae93-673787f4a111"
		//	 }, new IdentityUserRole<string>
		//	 {
		//		 RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
		//		 UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
		//	 }
		//	);

		//}

	}

}
