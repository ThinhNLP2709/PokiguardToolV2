namespace WebSocketSharp;

public class CloseEventArgs : EventArgs
{
	private bool _clean; //Field offset: 0x10
	private PayloadData _payloadData; //Field offset: 0x18

	public ushort Code
	{
		 get { } //Length: 29
	}

	public string Reason
	{
		 get { } //Length: 197
	}

	public bool WasClean
	{
		 get { } //Length: 7
	}

	internal CloseEventArgs(PayloadData payloadData, bool clean) { }

	internal CloseEventArgs(ushort code, string reason, bool clean) { }

	public ushort get_Code() { }

	public string get_Reason() { }

	public bool get_WasClean() { }

}

