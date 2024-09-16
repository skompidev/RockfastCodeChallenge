using Rockfast.ApiDatabase;
using Rockfast.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.Dependencies
{
    public class TodoService : ITodoService
    {
        private readonly ApiDbContext _database;
        public TodoService(ApiDbContext db)
        {
            this._database = db;
        }
    }
}
