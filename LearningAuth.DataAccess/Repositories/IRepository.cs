namespace LearningAuth.DataAccess.Repositories;

public interface IRepository<T>
{
	void Insert(IEnumerable<T> objects);
	void Read();
	void ReadOne();
	void Update(T oldObject, T newObject);
	void Delete(T obj);
}
