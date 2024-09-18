using Rockfast.ViewModels;
using System.Security.Cryptography;

namespace Rockfast.ServiceInterfaces
{
    public interface ITodoService : IAppService<TodoVM, int>
    {
        Task<IEnumerable<TodoVM>> GetByUserId(Guid userId);
    }
}
