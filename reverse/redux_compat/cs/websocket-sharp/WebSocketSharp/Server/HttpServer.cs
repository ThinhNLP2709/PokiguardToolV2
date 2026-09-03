/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
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
	public class HttpServer // TypeDefIndex: 13320
	{
		// Fields
		private IPAddress _address; // 0x10
		private string _docRootPath; // 0x18
		private string _hostname; // 0x20
		private HttpListener _listener; // 0x28
		private Logger _log; // 0x30
		private int _port; // 0x38
		private Thread _receiveThread; // 0x40
		private bool _secure; // 0x48
		private WebSocketServiceManager _services; // 0x50
		private ServerState _state; // 0x58
		private object _sync; // 0x60
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnConnect; // 0x68
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnDelete; // 0x70
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnGet; // 0x78
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnHead; // 0x80
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnOptions; // 0x88
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnPost; // 0x90
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnPut; // 0x98
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HttpRequestEventArgs> OnTrace; // 0xA0
	
		// Properties
		public IPAddress Address { get; } // 0x00000001825D8700-0x00000001825D8710 
		public AuthenticationSchemes AuthenticationSchemes { get; set; } // 0x000000018261C0D0-0x000000018261C0F0 0x000000018261D280-0x000000018261D360
		public string DocumentRootPath { get; set; } // 0x00000001825D8710-0x00000001825D8720 0x000000018261D360-0x000000018261D860
		public bool IsListening { get; } // 0x000000018261C0F0-0x000000018261C110 
		public bool IsSecure { get; } // 0x000000018261C110-0x000000018261C120 
		public bool KeepClean { get; set; } // 0x000000018261C120-0x000000018261C150 0x000000018261D860-0x000000018261D880
		public Logger Log { get; } // 0x00000001825F1D40-0x00000001825F1D50 
		public int Port { get; } // 0x000000018261C150-0x000000018261C160 
		public string Realm { get; set; } // 0x000000018261C160-0x000000018261C180 0x000000018261D880-0x000000018261D960
		public bool ReuseAddress { get; set; } // 0x000000018261C180-0x000000018261C1A0 0x000000018261D960-0x000000018261DA40
		public ServerSslConfiguration SslConfiguration { get; } // 0x000000018261C1A0-0x000000018261C230 
		public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> UserCredentialsFinder { get; set; } // 0x000000018261C230-0x000000018261C250 0x000000018261DA40-0x000000018261DB20
		public TimeSpan WaitTime { get; set; } // 0x000000018261C250-0x000000018261C270 0x000000018261DB20-0x000000018261DB40
		public WebSocketServiceManager WebSocketServices { get; } // 0x00000001825F1E80-0x00000001825F1E90 
	
		// Events
		public event EventHandler<HttpRequestEventArgs> OnConnect {
			add; // 0x000000018261B7F0-0x000000018261B8B0
			remove; // 0x000000018261CC30-0x000000018261CCF0
		}
		public event EventHandler<HttpRequestEventArgs> OnDelete {
			add; // 0x000000018261B8B0-0x000000018261B970
			remove; // 0x000000018261CCF0-0x000000018261CDB0
		}
		public event EventHandler<HttpRequestEventArgs> OnGet {
			add; // 0x000000018261B970-0x000000018261BA30
			remove; // 0x000000018261CDB0-0x000000018261CE70
		}
		public event EventHandler<HttpRequestEventArgs> OnHead {
			add; // 0x000000018261BA30-0x000000018261BB00
			remove; // 0x000000018261CE70-0x000000018261CF40
		}
		public event EventHandler<HttpRequestEventArgs> OnOptions {
			add; // 0x000000018261BB00-0x000000018261BBD0
			remove; // 0x000000018261CF40-0x000000018261D010
		}
		public event EventHandler<HttpRequestEventArgs> OnPost {
			add; // 0x000000018261BBD0-0x000000018261BCA0
			remove; // 0x000000018261D010-0x000000018261D0E0
		}
		public event EventHandler<HttpRequestEventArgs> OnPut {
			add; // 0x000000018261BCA0-0x000000018261BD70
			remove; // 0x000000018261D0E0-0x000000018261D1B0
		}
		public event EventHandler<HttpRequestEventArgs> OnTrace {
			add; // 0x000000018261BD70-0x000000018261BE40
			remove; // 0x000000018261D1B0-0x000000018261D280
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass83_0 // TypeDefIndex: 13321
		{
			// Fields
			public HttpListenerContext ctx; // 0x10
			public HttpServer __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass83_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _receiveRequest_b__0(object state); // 0x000000018261F510-0x000000018261F6B0
		}
	
		// Constructors
		public HttpServer(); // 0x000000018261B420-0x000000018261B4B0
		public HttpServer(int port); // 0x000000018261B2F0-0x000000018261B420
		public HttpServer(string url); // 0x000000018261AE20-0x000000018261B130
		public HttpServer(int port, bool secure); // 0x000000018261B4B0-0x000000018261B5E0
		public HttpServer(IPAddress address, int port); // 0x000000018261B130-0x000000018261B2F0
		public HttpServer(IPAddress address, int port, bool secure); // 0x000000018261AC50-0x000000018261AE20
	
		// Methods
		private void abort(); // 0x000000018261B5E0-0x000000018261B7F0
		private bool canSet(); // 0x000000018261BE40-0x000000018261BE90
		private bool checkCertificate(out string message); // 0x000000018261BE90-0x000000018261BFD0
		private static HttpListener createListener(string hostname, int port, bool secure); // 0x000000018261BFD0-0x000000018261C0D0
		private void init(string hostname, IPAddress address, int port, bool secure); // 0x000000018261C270-0x000000018261C490
		private void processRequest(HttpListenerContext context); // 0x000000018261C6C0-0x000000018261C970
		private void processRequest(HttpListenerWebSocketContext context); // 0x000000018261C490-0x000000018261C6C0
		private void receiveRequest(); // 0x000000018261C970-0x000000018261CC30
		private void start(); // 0x000000018261DC90-0x000000018261DF40
		private void startReceiving(); // 0x000000018261DB40-0x000000018261DC90
		private void stop(ushort code, string reason); // 0x000000018261DF90-0x000000018261E1D0
		private void stopReceiving(int millisecondsTimeout); // 0x000000018261DF40-0x000000018261DF90
		private static bool tryCreateUri(string uriString, out Uri result, out string message); // 0x000000018261E1D0-0x000000018261E430
		public void AddWebSocketService<TBehavior>(string path)
			where TBehavior : WebSocketBehavior, new();
		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer)
			where TBehavior : WebSocketBehavior, new();
		public bool RemoveWebSocketService(string path); // 0x000000018261ABA0-0x000000018261ABC0
		public void Start(); // 0x000000018261ABC0-0x000000018261AC00
		public void Stop(); // 0x000000018261AC00-0x000000018261AC50
	}
}
