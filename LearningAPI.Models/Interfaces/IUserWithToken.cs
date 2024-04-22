namespace LearningAuth.Models;

public interface IUserWithToken : IUserEntity
{
    string Token { get; set; }
}