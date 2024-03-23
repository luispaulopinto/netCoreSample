namespace Sample.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity)
            : base($"{entity} not found") { }

        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found") { }
    }
}
