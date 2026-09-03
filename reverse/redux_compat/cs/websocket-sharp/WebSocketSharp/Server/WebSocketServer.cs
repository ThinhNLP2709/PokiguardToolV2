/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	public class WebSocketServer // TypeDefIndex: 13318
	{
		// Fields
		private IPAddress _address; // 0x10
		private bool _allowForwardedRequest; // 0x18
		private AuthenticationSchemes _authSchemes; // 0x1C
		private static readonly string _defaultRealm; // 0x00
		private bool _dnsStyle; // 0x20
		private string _hostname; // 0x28
		private TcpListener _listener; // 0x30
		private Logger _log; // 0x38
		private int _port; // 0x40
		private string _realm; // 0x48
		private string _realmInUse; // 0x50
		private Thread _receiveThread; // 0x58
		private bool _reuseAddress; // 0x60
		private bool _secure; // 0x61
		private WebSocketServiceManager _services; // 0x68
		private ServerSslConfiguration _sslConfig; // 0x70
		private ServerSslConfiguration _sslConfigInUse; // 0x78
		private ServerState _state; // 0x80
		private object _sync; // 0x88
		private Func<IIdentity, WebSocketSharp.Net.NetworkCredential> _userCredFinder; // 0x90
	
		// Properties
		public IPAddress Address { get; } // 0x00000001825D8700-0x00000001825D8710 
		public bool AllowForwardedRequest { get; set; } // 0x00000001825EF930-0x00000001825EF940 0x0000000182622DA0-0x0000000182622E70
		public AuthenticationSchemes AuthenticationSchemes { get; set; } // 0x00000001826225B0-0x00000001826225C0 0x0000000182622E70-0x0000000182622F40
		public bool IsListening { get; } // 0x00000001826225C0-0x00000001826225E0 
		public bool IsSecure { get; } // 0x00000001826225E0-0x00000001826225F0 
		public bool KeepClean { get; set; } // 0x00000001826225F0-0x0000000182622620 0x0000000182622F40-0x0000000182622F60
		public Logger Log { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
		public int Port { get; } // 0x00000001825EE1E0-0x00000001825EE1F0 
		public string Realm { get; set; } // 0x00000001825E8B00-0x00000001825E8B10 0x0000000182622F60-0x0000000182623040
		public bool ReuseAddress { get; set; } // 0x0000000182622620-0x0000000182622630 0x0000000182623040-0x0000000182623110
		public ServerSslConfiguration SslConfiguration { get; } // 0x0000000182622630-0x00000001826226B0 
		public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> UserCredentialsFinder { get; set; } // 0x00000001826226B0-0x00000001826226C0 0x0000000182623110-0x00000001826231F0
		public TimeSpan WaitTime { get; set; } // 0x00000001826226C0-0x00000001826226E0 0x00000001826231F0-0x0000000182623210
		public WebSocketServiceManager WebSocketServices { get; } // 0x00000001826226E0-0x00000001826226F0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass70_0 // TypeDefIndex: 13319
		{
			// Fields
			public TcpClient cl; // 0x10
			public WebSocketServer __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass70_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _receiveRequest_b__0(object state); // 0x000000018261F3A0-0x000000018261F510
		}
	
		// Constructors
		static WebSocketServer(); // 0x00000001826214D0-0x0000000182621540
		public WebSocketServer(); // 0x0000000182621E10-0x0000000182621EC0
		public WebSocketServer(int port); // 0x00000001826218F0-0x0000000182621A40
		public WebSocketServer(string url); // 0x0000000182621A40-0x0000000182621E10
		public WebSocketServer(int port, bool secure); // 0x0000000182621EC0-0x0000000182622010
		public WebSocketServer(IPAddress address, int port); // 0x0000000182621540-0x0000000182621710
		public WebSocketServer(IPAddress address, int port, bool secure); // 0x0000000182621710-0x00000001826218F0
	
		// Methods
		private void abort(); // 0x0000000182622010-0x0000000182622230
		private bool authenticateClient(TcpListenerWebSocketContext context); // 0x0000000182622230-0x0000000182622400
		private bool canSet(); // 0x0000000182622400-0x0000000182622450
		private bool checkHostNameForRequest(string name); // 0x0000000182622450-0x00000001826224D0
		private string getRealm(); // 0x00000001826224D0-0x0000000182622540
		private ServerSslConfiguration getSslConfiguration(); // 0x0000000182622540-0x00000001826225B0
		private void init(string hostname, IPAddress address, int port, bool secure); // 0x00000001826226F0-0x0000000182622880
		private void processRequest(TcpListenerWebSocketContext context); // 0x0000000182622880-0x0000000182622AF0
		private void receiveRequest(); // 0x0000000182622AF0-0x0000000182622DA0
		private void start(); // 0x0000000182623390-0x00000001826236A0
		private void startReceiving(); // 0x0000000182623210-0x0000000182623390
		private void stop(ushort code, string reason); // 0x00000001826236F0-0x0000000182623920
		private void stopReceiving(int millisecondsTimeout); // 0x00000001826236A0-0x00000001826236F0
		private static bool tryCreateUri(string uriString, out Uri result, out string message); // 0x0000000182623920-0x0000000182623A10
		public void AddWebSocketService<TBehavior>(string path)
			where TBehavior : WebSocketBehavior, new();
		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer)
			where TBehavior : WebSocketBehavior, new();
		public bool RemoveWebSocketService(string path); // 0x0000000182621410-0x0000000182621430
		public void Start(); // 0x0000000182621430-0x0000000182621480
		public void Stop(); // 0x0000000182621480-0x00000001826214D0
	}
}
