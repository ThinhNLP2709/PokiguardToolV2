/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	public class WebSocket : IDisposable // TypeDefIndex: 13229
	{
		// Fields
		private AuthenticationChallenge _authChallenge; // 0x10
		private string _base64Key; // 0x18
		private bool _client; // 0x20
		private Action _closeContext; // 0x28
		private CompressionMethod _compression; // 0x30
		private WebSocketContext _context; // 0x38
		private CookieCollection _cookies; // 0x40
		private NetworkCredential _credentials; // 0x48
		private bool _emitOnPing; // 0x50
		private bool _enableRedirection; // 0x51
		private string _extensions; // 0x58
		private bool _extensionsRequested; // 0x60
		private object _forMessageEventQueue; // 0x68
		private object _forPing; // 0x70
		private object _forSend; // 0x78
		private object _forState; // 0x80
		private MemoryStream _fragmentsBuffer; // 0x88
		private bool _fragmentsCompressed; // 0x90
		private Opcode _fragmentsOpcode; // 0x91
		private const string _guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"; // Metadata: 0x006A780A
		private Func<WebSocketContext, string> _handshakeRequestChecker; // 0x98
		private bool _ignoreExtensions; // 0xA0
		private bool _inContinuation; // 0xA1
		private bool _inMessage; // 0xA2
		private Logger _logger; // 0xA8
		private static readonly int _maxRetryCountForConnect; // 0x00
		private Action<MessageEventArgs> _message; // 0xB0
		private Queue<MessageEventArgs> _messageEventQueue; // 0xB8
		private uint _nonceCount; // 0xC0
		private string _origin; // 0xC8
		private ManualResetEvent _pongReceived; // 0xD0
		private bool _preAuth; // 0xD8
		private string _protocol; // 0xE0
		private string[] _protocols; // 0xE8
		private bool _protocolsRequested; // 0xF0
		private NetworkCredential _proxyCredentials; // 0xF8
		private Uri _proxyUri; // 0x100
		private WebSocketState _readyState; // 0x108
		private ManualResetEvent _receivingExited; // 0x110
		private int _retryCountForConnect; // 0x118
		private bool _secure; // 0x11C
		private ClientSslConfiguration _sslConfig; // 0x120
		private Stream _stream; // 0x128
		private TcpClient _tcpClient; // 0x130
		private Uri _uri; // 0x138
		private const string _version = "13"; // Metadata: 0x006A782F
		private TimeSpan _waitTime; // 0x140
		internal static readonly byte[] EmptyBytes; // 0x08
		internal static readonly int FragmentLength; // 0x10
		internal static readonly RandomNumberGenerator RandomNumber; // 0x18
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<CloseEventArgs> OnClose; // 0x148
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<ErrorEventArgs> OnError; // 0x150
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<MessageEventArgs> OnMessage; // 0x158
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler OnOpen; // 0x160
	
		// Properties
		internal CookieCollection CookieCollection { get; } // 0x00000001825E8A60-0x00000001825E8A70 
		internal Func<WebSocketContext, string> CustomHandshakeRequestChecker { get; set; } // 0x00000001825E8B10-0x00000001825E8B20 0x00000001806CCE20-0x00000001806CCE40
		internal bool HasMessage { get; } // 0x00000001825E8B60-0x00000001825E8C00 
		internal bool IgnoreExtensions { get; set; } // 0x00000001825E8C00-0x00000001825E8C10 0x0000000181727470-0x0000000181727480
		internal bool IsConnected { get; } // 0x00000001825E8C70-0x00000001825E8CC0 
		public CompressionMethod Compression { get; set; } // 0x00000001825E8A50-0x00000001825E8A60 0x00000001825ECE60-0x00000001825ECFF0
		public IEnumerable<Cookie> Cookies { get; } // 0x00000001825E8A70-0x00000001825E8B00 
		public NetworkCredential Credentials { get; } // 0x00000001825E8B00-0x00000001825E8B10 
		public bool EmitOnPing { get; set; } // 0x00000001825E8B20-0x00000001825E8B30 0x00000001803780E0-0x00000001803780F0
		public bool EnableRedirection { get; set; } // 0x00000001825E8B30-0x00000001825E8B40 0x00000001825ECFF0-0x00000001825ED180
		public string Extensions { get; } // 0x00000001825E8B40-0x00000001825E8B60 
		public bool IsAlive { get; } // 0x00000001825E8C10-0x00000001825E8C70 
		public bool IsSecure { get; } // 0x00000001825E8CC0-0x00000001825E8CD0 
		public Logger Log { get; internal set; } // 0x00000001825E8CD0-0x00000001825E8CF0 0x00000001825ED180-0x00000001825ED1C0
		public string Origin { get; set; } // 0x00000001825E8CF0-0x00000001825E8D00 0x00000001825ED1C0-0x00000001825ED550
		public string Protocol { get; internal set; } // 0x00000001825E8D00-0x00000001825E8D20 0x00000001806CCDC0-0x00000001806CCDE0
		public WebSocketState ReadyState { get; } // 0x00000001825E8D20-0x00000001825E8D40 
		public ClientSslConfiguration SslConfiguration { get; } // 0x00000001825E8D40-0x00000001825E8E10 
		public Uri Url { get; } // 0x00000001825E8E10-0x00000001825E8E50 
		public TimeSpan WaitTime { get; set; } // 0x00000001825E8E50-0x00000001825E8E60 0x00000001825ED550-0x00000001825ED740
	
		// Events
		public event EventHandler<CloseEventArgs> OnClose {
			add; // 0x00000001825E5B20-0x00000001825E5BF0
			remove; // 0x00000001825EB2A0-0x00000001825EB370
		}
		public event EventHandler<ErrorEventArgs> OnError {
			add; // 0x00000001825E5BF0-0x00000001825E5CC0
			remove; // 0x00000001825EB370-0x00000001825EB440
		}
		public event EventHandler<MessageEventArgs> OnMessage {
			add; // 0x00000001825E5CC0-0x00000001825E5D90
			remove; // 0x00000001825EB440-0x00000001825EB510
		}
		public event EventHandler OnOpen {
			add; // 0x00000001825E5D90-0x00000001825E5E40
			remove; // 0x00000001825EB510-0x00000001825EB5C0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class _get_Cookies_d__70 : IEnumerable<Cookie>, IEnumerator<Cookie> // TypeDefIndex: 13230
		{
			// Fields
			private int __1__state; // 0x10
			private Cookie __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public WebSocket __4__this; // 0x28
			private object __s__1; // 0x30
			private IEnumerator<Cookie> __s__2; // 0x38
			private Cookie _cookie_5__3; // 0x40
	
			// Properties
			Cookie IEnumerator<WebSocketSharp.Net.Cookie>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_Cookies_d__70(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001825E0030-0x00000001825E0150
			private bool MoveNext(); // 0x00000001825DFC20-0x00000001825DFF30
			private void __m__Finally1(); // 0x00000001825E0150-0x00000001825E0170
			private void __m__Finally2(); // 0x00000001825E0170-0x00000001825E01C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001825DFFF0-0x00000001825E0030
			[DebuggerHidden]
			IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator(); // 0x00000001825DFF30-0x00000001825DFFF0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001825DFF30-0x00000001825DFFF0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13231
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<string, bool> __9__120_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001825DFBB0-0x00000001825DFC20
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _checkProtocols_b__120_0(string protocol); // 0x00000001825DECD0-0x00000001825DEDA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass125_0 // TypeDefIndex: 13232
		{
			// Fields
			public Action<PayloadData, bool, bool, bool> closer; // 0x10
	
			// Constructors
			public __c__DisplayClass125_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _closeAsync_b__0(IAsyncResult ar); // 0x00000001825DEDA0-0x00000001825DEDC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass145_0 // TypeDefIndex: 13233
		{
			// Fields
			public WebSocket __4__this; // 0x10
			public MessageEventArgs e; // 0x18
	
			// Constructors
			public __c__DisplayClass145_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _messages_b__0(object state); // 0x00000001825DEDC0-0x00000001825DEDF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass167_0 // TypeDefIndex: 13234
		{
			// Fields
			public Func<Opcode, Stream, bool> sender; // 0x10
			public Action<bool> completed; // 0x18
			public WebSocket __4__this; // 0x20
	
			// Constructors
			public __c__DisplayClass167_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _sendAsync_b__0(IAsyncResult ar); // 0x00000001825DEDF0-0x00000001825DEED0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass174_0 // TypeDefIndex: 13235
		{
			// Fields
			public WebSocket __4__this; // 0x10
			public Action receive; // 0x18
			public Action<WebSocketFrame> __9__1; // 0x20
			public Action<Exception> __9__2; // 0x28
	
			// Constructors
			public __c__DisplayClass174_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _startReceiving_b__0(); // 0x00000001825DEED0-0x00000001825DEFF0
			internal void _startReceiving_b__1(WebSocketFrame frame); // 0x00000001825DEFF0-0x00000001825DF0F0
			internal void _startReceiving_b__2(Exception ex); // 0x00000001825DF0F0-0x00000001825DF1A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass176_0 // TypeDefIndex: 13236
		{
			// Fields
			public string method; // 0x10
	
			// Constructors
			public __c__DisplayClass176_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _validateSecWebSocketExtensionsServerHeader_b__0(string t); // 0x00000001825DF1A0-0x00000001825DF250
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass177_0 // TypeDefIndex: 13237
		{
			// Fields
			public string value; // 0x10
	
			// Constructors
			public __c__DisplayClass177_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _validateSecWebSocketProtocolServerHeader_b__0(string p); // 0x0000000181FF42F0-0x0000000181FF4310
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass189_0 // TypeDefIndex: 13238
		{
			// Fields
			public Func<bool> acceptor; // 0x10
			public WebSocket __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass189_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _AcceptAsync_b__0(IAsyncResult ar); // 0x00000001825DF250-0x00000001825DF290
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass201_0 // TypeDefIndex: 13239
		{
			// Fields
			public Func<bool> connector; // 0x10
			public WebSocket __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass201_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ConnectAsync_b__0(IAsyncResult ar); // 0x00000001825DF250-0x00000001825DF290
		}
	
		// Constructors
		static WebSocket(); // 0x00000001825E4AA0-0x00000001825E4B90
		internal WebSocket(HttpListenerWebSocketContext context, string protocol); // 0x00000001825E4D50-0x00000001825E4F10
		internal WebSocket(TcpListenerWebSocketContext context, string protocol); // 0x00000001825E4B90-0x00000001825E4D50
		public WebSocket(string url, params string[] protocols); // 0x00000001825E4F10-0x00000001825E5340
	
		// Methods
		private bool accept(); // 0x00000001825E5780-0x00000001825E5B20
		private bool acceptHandshake(); // 0x00000001825E5340-0x00000001825E5780
		private bool canSet(out string message); // 0x00000001825E5E40-0x00000001825E5F10
		private bool checkHandshakeRequest(WebSocketContext context, out string message); // 0x00000001825E5F10-0x00000001825E62A0
		private bool checkHandshakeResponse(HttpResponse response, out string message); // 0x00000001825E62A0-0x00000001825E66B0
		private static bool checkProtocols(string[] protocols, out string message); // 0x00000001825E66B0-0x00000001825E6920
		private bool checkReceivedFrame(WebSocketFrame frame, out string message); // 0x00000001825E6920-0x00000001825E6B30
		private void close(ushort code, string reason); // 0x00000001825E7600-0x00000001825E77D0
		private void close(PayloadData payloadData, bool send, bool receive, bool received); // 0x00000001825E7130-0x00000001825E7600
		private void closeAsync(ushort code, string reason); // 0x00000001825E6B30-0x00000001825E6D00
		private void closeAsync(PayloadData payloadData, bool send, bool receive, bool received); // 0x00000001825E6D00-0x00000001825E6E50
		private bool closeHandshake(byte[] frameAsBytes, bool receive, bool received); // 0x00000001825E6FE0-0x00000001825E7130
		private bool closeHandshake(PayloadData payloadData, bool send, bool receive, bool received); // 0x00000001825E6E50-0x00000001825E6FE0
		private bool connect(); // 0x00000001825E77D0-0x00000001825E7B90
		private string createExtensions(); // 0x00000001825E7B90-0x00000001825E7D20
		private HttpResponse createHandshakeFailureResponse(HttpStatusCode code); // 0x00000001825E7D20-0x00000001825E7DA0
		private HttpRequest createHandshakeRequest(); // 0x00000001825E7DA0-0x00000001825E81E0
		private HttpResponse createHandshakeResponse(); // 0x00000001825E81E0-0x00000001825E8320
		private bool customCheckHandshakeRequest(WebSocketContext context, out string message); // 0x00000001825E8320-0x00000001825E83B0
		private MessageEventArgs dequeueFromMessageEventQueue(); // 0x00000001825E83B0-0x00000001825E8480
		private void doHandshake(); // 0x00000001825E8480-0x00000001825E8620
		private void enqueueToMessageEventQueue(MessageEventArgs e); // 0x00000001825E8620-0x00000001825E86E0
		private void error(string message, Exception exception); // 0x00000001825E86E0-0x00000001825E8810
		private void fatal(string message, Exception exception); // 0x00000001825E88F0-0x00000001825E89B0
		private void fatal(string message, ushort code); // 0x00000001825E8820-0x00000001825E88F0
		private void fatal(string message, CloseStatusCode code); // 0x00000001825E8810-0x00000001825E8820
		private ClientSslConfiguration getSslConfiguration(); // 0x00000001825E89B0-0x00000001825E8A50
		private void init(); // 0x00000001825E8E60-0x00000001825E8FE0
		private void message(); // 0x00000001825E8FE0-0x00000001825E9140
		private void messagec(MessageEventArgs e); // 0x00000001825E9140-0x00000001825E9370
		private void messages(MessageEventArgs e); // 0x00000001825E9370-0x00000001825E9620
		private void open(); // 0x00000001825E9620-0x00000001825E9A10
		private bool ping(byte[] data); // 0x00000001825E9A10-0x00000001825E9B70
		private bool processCloseFrame(WebSocketFrame frame); // 0x00000001825E9B70-0x00000001825E9C50
		private void processCookies(CookieCollection cookies); // 0x00000001825E9C50-0x00000001825E9CA0
		private bool processDataFrame(WebSocketFrame frame); // 0x00000001825E9CA0-0x00000001825E9E70
		private bool processFragmentFrame(WebSocketFrame frame); // 0x00000001825E9E70-0x00000001825EA150
		private bool processPingFrame(WebSocketFrame frame); // 0x00000001825EA150-0x00000001825EA3B0
		private bool processPongFrame(WebSocketFrame frame); // 0x00000001825EA3B0-0x00000001825EA500
		private bool processReceivedFrame(WebSocketFrame frame); // 0x00000001825EA500-0x00000001825EA8B0
		private void processSecWebSocketExtensionsClientHeader(string value); // 0x00000001825EA8B0-0x00000001825EACE0
		private void processSecWebSocketExtensionsServerHeader(string value); // 0x00000001825EACE0-0x00000001825EAD00
		private void processSecWebSocketProtocolClientHeader(IEnumerable<string> values); // 0x00000001825EAD00-0x00000001825EADD0
		private bool processUnsupportedFrame(WebSocketFrame frame); // 0x00000001825EADD0-0x00000001825EAE80
		private void refuseHandshake(CloseStatusCode code, string reason); // 0x00000001825EAE80-0x00000001825EB0A0
		private void releaseClientResources(); // 0x00000001825EB0A0-0x00000001825EB120
		private void releaseCommonResources(); // 0x00000001825EB120-0x00000001825EB1F0
		private void releaseResources(); // 0x00000001825EB1F0-0x00000001825EB230
		private void releaseServerResources(); // 0x00000001825EB230-0x00000001825EB2A0
		private bool send(Opcode opcode, Stream stream); // 0x00000001825EC2E0-0x00000001825EC5A0
		private bool send(Opcode opcode, Stream stream, bool compressed); // 0x00000001825EC5A0-0x00000001825EC900
		private bool send(Fin fin, Opcode opcode, byte[] data, bool compressed); // 0x00000001825EC900-0x00000001825ECAB0
		private void sendAsync(Opcode opcode, Stream stream, Action<bool> completed); // 0x00000001825EB5C0-0x00000001825EB720
		private bool sendBytes(byte[] bytes); // 0x00000001825EB720-0x00000001825EB820
		private HttpResponse sendHandshakeRequest(); // 0x00000001825EB820-0x00000001825EBCD0
		private HttpResponse sendHttpRequest(HttpRequest request, int millisecondsTimeout); // 0x00000001825EBCD0-0x00000001825EBDF0
		private bool sendHttpResponse(HttpResponse response); // 0x00000001825EBDF0-0x00000001825EBEB0
		private void sendProxyConnectRequest(); // 0x00000001825EBEB0-0x00000001825EC2E0
		private void setClientStream(); // 0x00000001825ECAB0-0x00000001825ECE60
		private void startReceiving(); // 0x00000001825ED740-0x00000001825ED8B0
		private bool validateSecWebSocketAcceptHeader(string value); // 0x00000001825ED8B0-0x00000001825ED930
		private bool validateSecWebSocketExtensionsServerHeader(string value); // 0x00000001825ED930-0x00000001825EDDF0
		private bool validateSecWebSocketProtocolServerHeader(string value); // 0x00000001825EDDF0-0x00000001825EDF40
		private bool validateSecWebSocketVersionServerHeader(string value); // 0x00000001825EDF40-0x00000001825EDF90
		internal void Close(HttpResponse response); // 0x00000001825E0E50-0x00000001825E0EF0
		internal void Close(HttpStatusCode code); // 0x00000001825E0EF0-0x00000001825E0F90
		internal void Close(PayloadData payloadData, byte[] frameAsBytes); // 0x00000001825E16B0-0x00000001825E1AD0
		internal static string CreateBase64Key(); // 0x00000001825E2090-0x00000001825E2150
		internal static string CreateResponseKey(string base64Key); // 0x00000001825E2150-0x00000001825E2290
		internal void InternalAccept(); // 0x00000001825E2290-0x00000001825E2390
		internal bool Ping(byte[] frameAsBytes, TimeSpan timeout); // 0x00000001825E2390-0x00000001825E25B0
		internal void Send(Opcode opcode, byte[] data, Dictionary<CompressionMethod, byte[]> cache); // 0x00000001825E3330-0x00000001825E3620
		internal void Send(Opcode opcode, Stream stream, Dictionary<CompressionMethod, Stream> cache); // 0x00000001825E3620-0x00000001825E37C0
		public void Accept(); // 0x00000001825E0400-0x00000001825E0550
		public void AcceptAsync(); // 0x00000001825E01C0-0x00000001825E0400
		public void Close(); // 0x00000001825E1AD0-0x00000001825E1AF0
		public void Close(ushort code); // 0x00000001825E1AF0-0x00000001825E1CB0
		public void Close(CloseStatusCode code); // 0x00000001825E0F90-0x00000001825E10A0
		public void Close(ushort code, string reason); // 0x00000001825E1370-0x00000001825E16B0
		public void Close(CloseStatusCode code, string reason); // 0x00000001825E10A0-0x00000001825E1370
		public void CloseAsync(); // 0x00000001825E0E30-0x00000001825E0E50
		public void CloseAsync(ushort code); // 0x00000001825E0890-0x00000001825E0A50
		public void CloseAsync(CloseStatusCode code); // 0x00000001825E0A50-0x00000001825E0B60
		public void CloseAsync(ushort code, string reason); // 0x00000001825E0550-0x00000001825E0890
		public void CloseAsync(CloseStatusCode code, string reason); // 0x00000001825E0B60-0x00000001825E0E30
		public void Connect(); // 0x00000001825E1F10-0x00000001825E2090
		public void ConnectAsync(); // 0x00000001825E1CB0-0x00000001825E1F10
		public bool Ping(); // 0x00000001825E2740-0x00000001825E27A0
		public bool Ping(string message); // 0x00000001825E25B0-0x00000001825E2740
		public void Send(byte[] data); // 0x00000001825E37C0-0x00000001825E38E0
		public void Send(FileInfo fileInfo); // 0x00000001825E38E0-0x00000001825E3AF0
		public void Send(string data); // 0x00000001825E3AF0-0x00000001825E3CB0
		public void Send(Stream stream, int length); // 0x00000001825E3010-0x00000001825E3330
		public void SendAsync(byte[] data, Action<bool> completed); // 0x00000001825E27A0-0x00000001825E28E0
		public void SendAsync(FileInfo fileInfo, Action<bool> completed); // 0x00000001825E28E0-0x00000001825E2B10
		public void SendAsync(string data, Action<bool> completed); // 0x00000001825E2E30-0x00000001825E3010
		public void SendAsync(Stream stream, int length, Action<bool> completed); // 0x00000001825E2B10-0x00000001825E2E30
		public void SetCookie(Cookie cookie); // 0x00000001825E3CB0-0x00000001825E3F50
		public void SetCredentials(string username, string password, bool preAuth); // 0x00000001825E3F50-0x00000001825E4390
		public void SetProxy(string url, string username, string password); // 0x00000001825E4390-0x00000001825E4A30
		void IDisposable.Dispose(); // 0x00000001825E4A30-0x00000001825E4A50
		[CompilerGenerated]
		private void _open_b__146_0(IAsyncResult ar); // 0x00000001825E4A50-0x00000001825E4A80
		[CompilerGenerated]
		private bool _processSecWebSocketProtocolClientHeader_b__157_0(string val); // 0x00000001825E4A80-0x00000001825E4AA0
	}
}
