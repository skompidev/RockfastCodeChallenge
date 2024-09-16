using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg) { }

        public NotFoundException(string name, object key) : base($"Entity: [{name}] with key [{key}] not found.") { }
    }
}
