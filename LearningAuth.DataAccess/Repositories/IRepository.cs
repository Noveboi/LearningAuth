namespace LearningAuth.DataAccess.Repositories;

public interface IRepository<T>
{
	Task Insert(IEnumerable<T> objects);
	Task<IEnumerable<T>> Read();
	Task<T?> ReadOne(int objectId);
	Task Delete(int objectId);
}
