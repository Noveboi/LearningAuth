using LearningAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAuth.DataAccess;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
	public DbSet<UserEntity> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Construct an index for the 'Username' column
		modelBuilder.Entity<UserEntity>()
			.HasIndex(b => b.Username)
			.IsUnique();
	}
}
