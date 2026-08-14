namespace WebSocketSharp.Net;

internal class HttpHeaderInfo
{
	private string _headerName; //Field offset: 0x10
	private HttpHeaderType _headerType; //Field offset: 0x18

	public string HeaderName
	{
		 get { } //Length: 7
	}

	public HttpHeaderType HeaderType
	{
		 get { } //Length: 6
	}

	internal bool IsMultiValueInRequest
	{
		internal get { } //Length: 11
	}

	internal bool IsMultiValueInResponse
	{
		internal get { } //Length: 11
	}

	public bool IsRequest
	{
		 get { } //Length: 9
	}

	public bool IsResponse
	{
		 get { } //Length: 10
	}

	internal HttpHeaderInfo(string headerName, HttpHeaderType headerType) { }

	public string get_HeaderName() { }

	public HttpHeaderType get_HeaderType() { }

	internal bool get_IsMultiValueInRequest() { }

	internal bool get_IsMultiValueInResponse() { }

	public bool get_IsRequest() { }

	public bool get_IsResponse() { }

	public bool IsMultiValue(bool response) { }

	public bool IsRestricted(bool response) { }

}

