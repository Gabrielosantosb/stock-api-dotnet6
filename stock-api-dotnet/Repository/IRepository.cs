using stock_api_dotnet.ORM.Models;

namespace stock_api_dotnet.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T Delete(string id);

        T FindById(string id);
        List<T> FindAll();
        List<T> DeleteAll();

        bool Exists(string id);
    }
}
