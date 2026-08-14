namespace System.Runtime.InteropServices;

public class ExternalException : SystemException
{

	public override int ErrorCode
	{
		 get { } //Length: 4
	}

	public ExternalException() { }

	public ExternalException(string message) { }

	public ExternalException(string message, int errorCode) { }

	protected ExternalException(SerializationInfo info, StreamingContext context) { }

	public override int get_ErrorCode() { }

	public virtual string ToString() { }

}

