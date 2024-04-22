using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;


namespace LearningAuth.API.Services;

public class UserService(IUserRepository<IUser> repository)
{
	private readonly IUserRepository<IUser> _repository = repository;

	public async Task<IUserEntity?> Find(UserLoginModel user) 
		=> await _repository.Find(user.Username, user.Password);

	public async Task<bool> Register(IUser user)
	{
		return await Task.FromResult(true);
	}
}
