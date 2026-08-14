namespace Unity.VisualScripting.FullSerializer;

public struct fsResult
{
	private static readonly String[] EmptyStringArray; //Field offset: 0x0
	public static fsResult Success; //Field offset: 0x8
	private bool _success; //Field offset: 0x0
	private List<String> _messages; //Field offset: 0x8

	public Exception AsException
	{
		 get { } //Length: 357
	}

	public bool Failed
	{
		 get { } //Length: 7
	}

	public string FormattedMessages
	{
		 get { } //Length: 196
	}

	public bool HasWarnings
	{
		 get { } //Length: 73
	}

	public IEnumerable<String> RawMessages
	{
		 get { } //Length: 101
	}

	public bool Succeeded
	{
		 get { } //Length: 4
	}

	private static fsResult() { }

	public void AddMessage(string message) { }

	public void AddMessages(fsResult result) { }

	public fsResult AssertSuccess() { }

	public fsResult AssertSuccessWithoutWarnings() { }

	public static fsResult Fail(string warning) { }

	public Exception get_AsException() { }

	public bool get_Failed() { }

	public string get_FormattedMessages() { }

	public bool get_HasWarnings() { }

	public IEnumerable<String> get_RawMessages() { }

	public bool get_Succeeded() { }

	public fsResult Merge(fsResult other) { }

	public static fsResult op_Addition(fsResult a, fsResult b) { }

	public static fsResult Warn(string warning) { }

}

