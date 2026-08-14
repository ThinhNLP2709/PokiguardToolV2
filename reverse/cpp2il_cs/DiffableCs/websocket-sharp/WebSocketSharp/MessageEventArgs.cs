namespace WebSocketSharp;

public class MessageEventArgs : EventArgs
{
	private string _data; //Field offset: 0x10
	private bool _dataSet; //Field offset: 0x18
	private Opcode _opcode; //Field offset: 0x19
	private Byte[] _rawData; //Field offset: 0x20

	public string Data
	{
		 get { } //Length: 26
	}

	public bool IsBinary
	{
		 get { } //Length: 10
	}

	public bool IsPing
	{
		 get { } //Length: 10
	}

	public bool IsText
	{
		 get { } //Length: 10
	}

	internal Opcode Opcode
	{
		internal get { } //Length: 7
	}

	public Byte[] RawData
	{
		 get { } //Length: 26
	}

	internal MessageEventArgs(WebSocketFrame frame) { }

	internal MessageEventArgs(Opcode opcode, Byte[] rawData) { }

	public string get_Data() { }

	public bool get_IsBinary() { }

	public bool get_IsPing() { }

	public bool get_IsText() { }

	internal Opcode get_Opcode() { }

	public Byte[] get_RawData() { }

	private void setData() { }

}

