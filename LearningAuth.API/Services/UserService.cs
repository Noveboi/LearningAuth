using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;


namespace LearningAuth.API.Services;

public class UserService(IUserRepository repository)
{
	private readonly IUserRepository _repository = repository;

	public async Task<IUser?> Find(LoginUserDto user) 
		=> await _repository.Find(user.Username, user.PasswordHash);

	public async Task<bool> Register(UserDto user)
	{
		return await Task.FromResult(true);
	}
}
