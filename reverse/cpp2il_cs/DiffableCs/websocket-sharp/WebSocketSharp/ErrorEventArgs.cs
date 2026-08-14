namespace WebSocketSharp;

public class ErrorEventArgs : EventArgs
{
	private Exception _exception; //Field offset: 0x10
	private string _message; //Field offset: 0x18

	public Exception Exception
	{
		 get { } //Length: 7
	}

	public string Message
	{
		 get { } //Length: 7
	}

	internal ErrorEventArgs(string message) { }

	internal ErrorEventArgs(string message, Exception exception) { }

	public Exception get_Exception() { }

	public string get_Message() { }

}

