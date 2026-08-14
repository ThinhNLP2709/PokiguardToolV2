namespace Unity.VisualScripting;

public sealed class GenericClosingException : Exception
{

	public GenericClosingException(string message) { }

	public GenericClosingException(Type open, Type closed) { }

}

