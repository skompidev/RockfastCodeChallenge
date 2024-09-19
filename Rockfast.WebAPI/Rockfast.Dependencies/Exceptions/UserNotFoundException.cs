namespace Rockfast.Dependencies.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid key) : base(nameof(User), key) { }
}
}
