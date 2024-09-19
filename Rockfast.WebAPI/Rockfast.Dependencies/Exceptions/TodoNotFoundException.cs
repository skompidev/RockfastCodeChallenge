namespace Rockfast.Dependencies.Exceptions
{
    public class TodoNotFoundException : NotFoundException
    {
        public TodoNotFoundException(int key) : base(nameof(Todo), key) { }
    }
}
