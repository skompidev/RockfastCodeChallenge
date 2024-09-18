
namespace Rockfast.Dependencies
{
    public class TodoService : ITodoService
    {
        private readonly ApiDbContext _database;
        public TodoService(ApiDbContext db)
        {
            this._database = db;
        }


        public async Task<IEnumerable<TodoVM>> Get()
        {
            var todos = await _database.Todos.AsNoTracking().ToListAsync();

            var response = todos.Adapt<IEnumerable<TodoVM>>();

            return response;
        }

        public async Task<TodoVM> GetById(int id)
        {
            var todo = await _database.Todos.FindAsync(id);

            if (todo == null)
            {
                throw new TodoNotFoundException(id);
            }

            return todo.Adapt<TodoVM>();
        }

        public async Task<TodoVM> Post(TodoVM model)
        {
            var todo = model.Adapt<Todo>();

            _database.Todos.Add(todo);

            await _database.SaveChangesAsync();

            return todo.Adapt<TodoVM>();
        }

        public async Task<TodoVM> Put(TodoVM model)
        {
            var todo = await _database.Todos.FindAsync(model.Id);
            var user = _database.Users.AsNoTracking().Any(u => u.Id == model.UserId);

            if (todo == null)
            {
                throw new TodoNotFoundException(model.Id);
            };
            if (!user)
            {
                throw new UserNotFoundException(model.UserId);
            };

            todo.Name = model.Name;
            todo.UserId = model.UserId;
            todo.DateCompleted = model.DateCompleted;

            _database.Update(todo);

            await _database.SaveChangesAsync();

            return todo.Adapt<TodoVM>();
        }

        public async Task<bool> Delete(int id)
        {
            var todo = await _database.Todos.FindAsync(id);

            if (todo == null)
            {
                throw new TodoNotFoundException(id);
            };

            _database.Remove(todo);

            await _database.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TodoVM>> GetByUserId(Guid userId)
        {
            var todos = await _database.Todos
                            .Where(x => x.UserId == userId)
                            .AsNoTracking()
                            .OrderBy(x => x.Id)
                            .ToListAsync();

            var todosVm = todos.Adapt<IEnumerable<TodoVM>>();

            return todosVm;
        }
    }
}
