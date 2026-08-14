namespace System.ComponentModel;

public class InvalidEnumArgumentException : ArgumentException
{

	public InvalidEnumArgumentException() { }

	public InvalidEnumArgumentException(string message) { }

	public InvalidEnumArgumentException(string argumentName, int invalidValue, Type enumClass) { }

	protected InvalidEnumArgumentException(SerializationInfo info, StreamingContext context) { }

}

