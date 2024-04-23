using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;
using LearningAuth.Models.Messages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace LearningAuth.API.Services;

public class UserService(IUserRepository repository)
{
	private readonly IUserRepository _repository = repository;

	public async Task<ApiResult<IUser>> Find(LoginUserDto user)
	{
		IUser? foundUser = await _repository.Find(user.Username, user.PasswordHash);
		if (foundUser == null)
		{
			return ApiResult<IUser>.NotOk(Error.DoesntExist("User with given credentials doesn't exist. Please check that you've entered your username and password correctly."));
		}

		return ApiResult<IUser>.Ok(foundUser);
	}

	public async Task<ApiResult> Register(UserDto user) 
	{
		try
		{
			await _repository.Insert(user);
			return ApiResult.Ok();
		}
		
		// Catch unique constraint violations
		catch (DbUpdateException ex) when (ex.InnerException is SqlException iex && iex.ErrorCode == 2627)
		{
			return ApiResult.NotOk(Error.AlreadyExists($"The user with username \"{user.Username}\" already exists."));
		}
	}
}
