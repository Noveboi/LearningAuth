namespace LearningAuth.DataAccess.Repositories;

/// <summary>
/// General-purpose repository pattern for CRUD operations from a data source
/// </summary>
/// <typeparam name="T">The type of object stored in the repository</typeparam>
public interface IRepository<T>
{
	Task Insert(IEnumerable<T> objects);
	Task<IEnumerable<T>> Read();
	Task<T?> ReadOne(int objectId);
	Task Delete(int objectId);
}
