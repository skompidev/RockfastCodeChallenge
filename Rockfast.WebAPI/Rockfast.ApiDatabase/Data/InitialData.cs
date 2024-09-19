using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.ApiDatabase.Data
{
    internal class InitialData
    {
        public static IEnumerable<User> Users =>
        new List<User>
        {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Madison Baker",
                    Email = "crokiffutuyoi-7562@yopmail.com",
                    Todos = new List<Todo>
                    {
                        new Todo {Name = "Take a Short Walk"},
                        new Todo {Name = "Attend Scheduled Meetings"}
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Herman Fields",
                    Email = "wiquoubibuwa-4481@yopmail.com",
                    Todos = new List<Todo>
                    {
                        new Todo {Name = "Organise Emails"},
                        new Todo {Name = "Dentist"}
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Trix Grant",
                    Email = "houdatapasei-1403@yopmail.com",
                    Todos = new List<Todo>
                    {
                        new Todo {Name = "Travel shopping"},
                        new Todo {Name = "Book flight tickets"}
                    }
                }
        };
    }    
}
