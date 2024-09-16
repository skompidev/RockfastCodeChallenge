using Rockfast.ApiDatabase.Entity;

namespace Rockfast.ServiceInterfaces
{
    public interface IAppService<T, TId>
        where T : class
        where TId : struct 
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(TId id);
        Task<T> Post(T model);
        Task<T> Put(T model);
        Task<bool> Delete(TId id);
    }
}
