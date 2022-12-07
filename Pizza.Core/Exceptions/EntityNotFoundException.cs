namespace Pizza.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base("Entity was not found")
    {
    }
}
