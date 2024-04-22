using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;

namespace LearningAuth.API.Services;

public class UserService(IUserRepository<UserEntity> repository)
{
	private readonly IUserRepository<UserEntity> _repository = repository;

	public async Task<UserEntity?> Find(IUserLoginModel userCredentials) 
		=> await _repository.Find(userCredentials);
}
