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

            if (todo == null)
            {
                throw new TodoNotFoundException(model.Id);
            };

            todo.Name = model.Name;
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
    }
}
