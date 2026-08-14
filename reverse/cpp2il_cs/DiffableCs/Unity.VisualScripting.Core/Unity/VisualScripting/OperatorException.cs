namespace Unity.VisualScripting;

public abstract class OperatorException : InvalidCastException
{

	protected OperatorException() { }

	protected OperatorException(string message) { }

	protected OperatorException(string message, Exception innerException) { }

}

