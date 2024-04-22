using LearningAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAuth.DataAccess;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
	public DbSet<UserEntity> Users { get; set; }
}
