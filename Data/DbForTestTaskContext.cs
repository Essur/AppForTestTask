using AppForTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppForTestTask.Data
{
	public class DbForTestTaskContext : DbContext
	{
		public DbForTestTaskContext(DbContextOptions<DbForTestTaskContext> options) : base(options) { }
		public DbSet<Folder> Folders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Folder>().ToTable("Folder");
		}
	}
}
