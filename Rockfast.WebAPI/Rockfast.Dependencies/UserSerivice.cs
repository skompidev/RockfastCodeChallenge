using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.Dependencies
{
    public class UserSerivice : IUserService
    {
        private readonly ApiDbContext _database;

        public UserSerivice(ApiDbContext db)
        {
            this._database = db;
        }

        public async Task<IEnumerable<UserVM>> Get()
        {
            var users = await _database.Users.AsNoTracking().ToListAsync();

            var response = users.Adapt<IEnumerable<UserVM>>();

            return response;
        }

        public async Task<UserVM> GetById(Guid id)
        {
            var user = await _database.Users.FindAsync(id);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            return user.Adapt<UserVM>();
        }

        public async Task<UserVM> Post(UserVM model)
        {
            var user = model.Adapt<User>();

            _database.Users.Add(user);

            await _database.SaveChangesAsync();

            return user.Adapt<UserVM>();
        }

        public async Task<UserVM> Put(UserVM model)
        {
            var user = await _database.Users.FindAsync(model.Id);

            if (user == null)
            {
                throw new UserNotFoundException(model.Id);
            };

            user.Name = model.Name;
            user.Email = model.Email;

            _database.Update(user);

            await _database.SaveChangesAsync();

            return user.Adapt<UserVM>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _database.Users.FindAsync(id);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            };

            _database.Remove(user);

            await _database.SaveChangesAsync();

            return true;
        }
    }
}
