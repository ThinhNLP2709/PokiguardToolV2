namespace WebSocketSharp.Net;

public sealed class HttpListenerRequest
{
	private static readonly Byte[] _100continue; //Field offset: 0x0
	private String[] _acceptTypes; //Field offset: 0x10
	private bool _chunked; //Field offset: 0x18
	private HttpConnection _connection; //Field offset: 0x20
	private Encoding _contentEncoding; //Field offset: 0x28
	private long _contentLength; //Field offset: 0x30
	private HttpListenerContext _context; //Field offset: 0x38
	private CookieCollection _cookies; //Field offset: 0x40
	private WebHeaderCollection _headers; //Field offset: 0x48
	private string _httpMethod; //Field offset: 0x50
	private Stream _inputStream; //Field offset: 0x58
	private Version _protocolVersion; //Field offset: 0x60
	private NameValueCollection _queryString; //Field offset: 0x68
	private string _rawUrl; //Field offset: 0x70
	private Guid _requestTraceIdentifier; //Field offset: 0x78
	private Uri _url; //Field offset: 0x88
	private Uri _urlReferrer; //Field offset: 0x90
	private bool _urlSet; //Field offset: 0x98
	private string _userHostName; //Field offset: 0xA0
	private String[] _userLanguages; //Field offset: 0xA8

	public String[] AcceptTypes
	{
		 get { } //Length: 334
	}

	public int ClientCertificateError
	{
		 get { } //Length: 62
	}

	public Encoding ContentEncoding
	{
		 get { } //Length: 197
	}

	public long ContentLength64
	{
		 get { } //Length: 7
	}

	public string ContentType
	{
		 get { } //Length: 71
	}

	public CookieCollection Cookies
	{
		 get { } //Length: 118
	}

	public bool HasEntityBody
	{
		 get { } //Length: 22
	}

	public NameValueCollection Headers
	{
		 get { } //Length: 7
	}

	public string HttpMethod
	{
		 get { } //Length: 7
	}

	public Stream InputStream
	{
		 get { } //Length: 157
	}

	public bool IsAuthenticated
	{
		 get { } //Length: 31
	}

	public bool IsLocal
	{
		 get { } //Length: 165
	}

	public bool IsSecureConnection
	{
		 get { } //Length: 27
	}

	public bool IsWebSocketRequest
	{
		 get { } //Length: 139
	}

	public bool KeepAlive
	{
		 get { } //Length: 94
	}

	public IPEndPoint LocalEndPoint
	{
		 get { } //Length: 121
	}

	public Version ProtocolVersion
	{
		 get { } //Length: 7
	}

	public NameValueCollection QueryString
	{
		 get { } //Length: 179
	}

	public string RawUrl
	{
		 get { } //Length: 7
	}

	public IPEndPoint RemoteEndPoint
	{
		 get { } //Length: 121
	}

	public Guid RequestTraceIdentifier
	{
		 get { } //Length: 11
	}

	public Uri Url
	{
		 get { } //Length: 475
	}

	public Uri UrlReferrer
	{
		 get { } //Length: 244
	}

	public string UserAgent
	{
		 get { } //Length: 71
	}

	public string UserHostAddress
	{
		 get { } //Length: 132
	}

	public string UserHostName
	{
		 get { } //Length: 10
	}

	public String[] UserLanguages
	{
		 get { } //Length: 331
	}

	private static HttpListenerRequest() { }

	internal HttpListenerRequest(HttpListenerContext context) { }

	internal void AddHeader(string headerField) { }

	public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state) { }

	public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult) { }

	internal void FinishInitialization() { }

	internal bool FlushInput() { }

	public String[] get_AcceptTypes() { }

	public int get_ClientCertificateError() { }

	public Encoding get_ContentEncoding() { }

	public long get_ContentLength64() { }

	public string get_ContentType() { }

	public CookieCollection get_Cookies() { }

	public bool get_HasEntityBody() { }

	public NameValueCollection get_Headers() { }

	public string get_HttpMethod() { }

	public Stream get_InputStream() { }

	public bool get_IsAuthenticated() { }

	public bool get_IsLocal() { }

	public bool get_IsSecureConnection() { }

	public bool get_IsWebSocketRequest() { }

	public bool get_KeepAlive() { }

	public IPEndPoint get_LocalEndPoint() { }

	public Version get_ProtocolVersion() { }

	public NameValueCollection get_QueryString() { }

	public string get_RawUrl() { }

	public IPEndPoint get_RemoteEndPoint() { }

	public Guid get_RequestTraceIdentifier() { }

	public Uri get_Url() { }

	public Uri get_UrlReferrer() { }

	public string get_UserAgent() { }

	public string get_UserHostAddress() { }

	public string get_UserHostName() { }

	public String[] get_UserLanguages() { }

	public X509Certificate2 GetClientCertificate() { }

	private Encoding getContentEncoding() { }

	internal bool IsUpgradeRequest(string protocol) { }

	internal void SetRequestLine(string requestLine) { }

	public virtual string ToString() { }

}

