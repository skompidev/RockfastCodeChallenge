using Rockfast.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.ServiceInterfaces
{
    public interface IUserService : IAppService<UserVM, Guid>
    {
    }
}
