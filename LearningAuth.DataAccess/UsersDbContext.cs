using LearningAuth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess;

public class UsersDbContext(string connectionString) : DbContext
{
	// SQL Server connection string
	private readonly string _connString = connectionString;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(_connString);
	}

	public DbSet<UserEntity> Users { get; set; }
}
