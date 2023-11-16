namespace OptiScaffold.Exceptions;

internal class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string blockName)
        : base($"A directory already exists with the name {blockName}")
    {
    }
}