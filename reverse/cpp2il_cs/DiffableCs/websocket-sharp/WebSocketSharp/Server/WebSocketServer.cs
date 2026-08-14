namespace WebSocketSharp.Server;

public class WebSocketServer
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass70_0
	{
		public TcpClient cl; //Field offset: 0x10
		public WebSocketServer <>4__this; //Field offset: 0x18

		public <>c__DisplayClass70_0() { }

		internal void <receiveRequest>b__0(object state) { }

	}

	private static readonly string _defaultRealm; //Field offset: 0x0
	private IPAddress _address; //Field offset: 0x10
	private bool _allowForwardedRequest; //Field offset: 0x18
	private AuthenticationSchemes _authSchemes; //Field offset: 0x1C
	private bool _dnsStyle; //Field offset: 0x20
	private string _hostname; //Field offset: 0x28
	private TcpListener _listener; //Field offset: 0x30
	private Logger _log; //Field offset: 0x38
	private int _port; //Field offset: 0x40
	private string _realm; //Field offset: 0x48
	private string _realmInUse; //Field offset: 0x50
	private Thread _receiveThread; //Field offset: 0x58
	private bool _reuseAddress; //Field offset: 0x60
	private bool _secure; //Field offset: 0x61
	private WebSocketServiceManager _services; //Field offset: 0x68
	private ServerSslConfiguration _sslConfig; //Field offset: 0x70
	private ServerSslConfiguration _sslConfigInUse; //Field offset: 0x78
	private ServerState _state; //Field offset: 0x80
	private object _sync; //Field offset: 0x88
	private Func<IIdentity, NetworkCredential> _userCredFinder; //Field offset: 0x90

	public IPAddress Address
	{
		 get { } //Length: 7
	}

	public bool AllowForwardedRequest
	{
		 get { } //Length: 7
		 set { } //Length: 181
	}

	public AuthenticationSchemes AuthenticationSchemes
	{
		 get { } //Length: 6
		 set { } //Length: 180
	}

	public bool IsListening
	{
		 get { } //Length: 29
	}

	public bool IsSecure
	{
		 get { } //Length: 7
	}

	public bool KeepClean
	{
		 get { } //Length: 38
		 set { } //Length: 30
	}

	public Logger Log
	{
		 get { } //Length: 7
	}

	public int Port
	{
		 get { } //Length: 6
	}

	public string Realm
	{
		 get { } //Length: 7
		 set { } //Length: 199
	}

	public bool ReuseAddress
	{
		 get { } //Length: 7
		 set { } //Length: 181
	}

	public ServerSslConfiguration SslConfiguration
	{
		 get { } //Length: 116
	}

	public Func<IIdentity, NetworkCredential> UserCredentialsFinder
	{
		 get { } //Length: 10
		 set { } //Length: 205
	}

	public TimeSpan WaitTime
	{
		 get { } //Length: 27
		 set { } //Length: 30
	}

	public WebSocketServiceManager WebSocketServices
	{
		 get { } //Length: 7
	}

	private static WebSocketServer() { }

	public WebSocketServer() { }

	public WebSocketServer(int port) { }

	public WebSocketServer(string url) { }

	public WebSocketServer(int port, bool secure) { }

	public WebSocketServer(IPAddress address, int port) { }

	public WebSocketServer(IPAddress address, int port, bool secure) { }

	private void abort() { }

	public void AddWebSocketService(string path, Action<TBehavior> initializer) { }

	public void AddWebSocketService(string path) { }

	private bool authenticateClient(TcpListenerWebSocketContext context) { }

	private bool canSet() { }

	private bool checkHostNameForRequest(string name) { }

	public IPAddress get_Address() { }

	public bool get_AllowForwardedRequest() { }

	public AuthenticationSchemes get_AuthenticationSchemes() { }

	public bool get_IsListening() { }

	public bool get_IsSecure() { }

	public bool get_KeepClean() { }

	public Logger get_Log() { }

	public int get_Port() { }

	public string get_Realm() { }

	public bool get_ReuseAddress() { }

	public ServerSslConfiguration get_SslConfiguration() { }

	public Func<IIdentity, NetworkCredential> get_UserCredentialsFinder() { }

	public TimeSpan get_WaitTime() { }

	public WebSocketServiceManager get_WebSocketServices() { }

	private string getRealm() { }

	private ServerSslConfiguration getSslConfiguration() { }

	private void init(string hostname, IPAddress address, int port, bool secure) { }

	private void processRequest(TcpListenerWebSocketContext context) { }

	private void receiveRequest() { }

	public bool RemoveWebSocketService(string path) { }

	public void set_AllowForwardedRequest(bool value) { }

	public void set_AuthenticationSchemes(AuthenticationSchemes value) { }

	public void set_KeepClean(bool value) { }

	public void set_Realm(string value) { }

	public void set_ReuseAddress(bool value) { }

	public void set_UserCredentialsFinder(Func<IIdentity, NetworkCredential> value) { }

	public void set_WaitTime(TimeSpan value) { }

	private void start() { }

	public void Start() { }

	private void startReceiving() { }

	private void stop(ushort code, string reason) { }

	public void Stop() { }

	private void stopReceiving(int millisecondsTimeout) { }

	private static bool tryCreateUri(string uriString, out Uri result, out string message) { }

}

