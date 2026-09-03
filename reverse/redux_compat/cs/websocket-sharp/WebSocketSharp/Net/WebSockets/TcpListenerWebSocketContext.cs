/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using WebSocketSharp;
using WebSocketSharp.Net;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net.WebSockets
{
	internal class TcpListenerWebSocketContext : WebSocketContext // TypeDefIndex: 13314
	{
		// Fields
		private Logger _log; // 0x10
		private NameValueCollection _queryString; // 0x18
		private HttpRequest _request; // 0x20
		private Uri _requestUri; // 0x28
		private bool _secure; // 0x30
		private EndPoint _serverEndPoint; // 0x38
		private Stream _stream; // 0x40
		private TcpClient _tcpClient; // 0x48
		private IPrincipal _user; // 0x50
		private EndPoint _userEndPoint; // 0x58
		private WebSocket _websocket; // 0x60
	
		// Properties
		internal Logger Log { get; } // 0x00000001825D8700-0x00000001825D8710 
		internal Stream Stream { get; } // 0x00000001825E8A60-0x00000001825E8A70 
		public override WebSocketSharp.Net.CookieCollection CookieCollection { get; } // 0x000000018261EA70-0x000000018261EA90 
		public override NameValueCollection Headers { get; } // 0x000000018261EA90-0x000000018261EAB0 
		public override string Host { get; } // 0x000000018261EAB0-0x000000018261EB10 
		public override bool IsAuthenticated { get; } // 0x000000018261EB10-0x000000018261EB20 
		public override bool IsLocal { get; } // 0x000000018261EB20-0x000000018261EB90 
		public override bool IsSecureConnection { get; } // 0x00000001825E8A50-0x00000001825E8A60 
		public override bool IsWebSocketRequest { get; } // 0x000000018261EB90-0x000000018261EBB0 
		public override string Origin { get; } // 0x000000018261EBB0-0x000000018261EC10 
		public override NameValueCollection QueryString { get; } // 0x000000018261EC10-0x000000018261ECD0 
		public override Uri RequestUri { get; } // 0x000000018261ECD0-0x000000018261EE20 
		public override string SecWebSocketKey { get; } // 0x000000018261EE20-0x000000018261EE80 
		public override IEnumerable<string> SecWebSocketProtocols { get; } // 0x000000018261EE80-0x000000018261EF10 
		public override string SecWebSocketVersion { get; } // 0x000000018261EF10-0x000000018261EF70 
		public override IPEndPoint ServerEndPoint { get; } // 0x000000018261EF70-0x000000018261EFE0 
		public override IPrincipal User { get; } // 0x00000001825F1E80-0x00000001825F1E90 
		public override IPEndPoint UserEndPoint { get; } // 0x000000018261EFE0-0x000000018261F050 
		public override WebSocket WebSocket { get; } // 0x00000001825F1EF0-0x00000001825F1F00 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _get_SecWebSocketProtocols_d__39 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 13315
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public TcpListenerWebSocketContext __4__this; // 0x28
			private string _val_5__1; // 0x30
			private string[] __s__2; // 0x38
			private int __s__3; // 0x40
			private string _elm_5__4; // 0x48
			private string _protocol_5__5; // 0x50
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_SecWebSocketProtocols_d__39(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000182620090-0x0000000182620280
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182620340-0x0000000182620380
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x0000000182620280-0x0000000182620340
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182620280-0x0000000182620340
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass51_0 // TypeDefIndex: 13316
		{
			// Fields
			public int retry; // 0x10
			public TcpListenerWebSocketContext __4__this; // 0x18
			public AuthenticationSchemes scheme; // 0x20
			public string realm; // 0x28
			public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> credentialsFinder; // 0x30
			public string chal; // 0x38
			public Func<bool> auth; // 0x40
	
			// Constructors
			public __c__DisplayClass51_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _Authenticate_b__0(); // 0x000000018261F150-0x000000018261F3A0
		}
	
		// Constructors
		internal TcpListenerWebSocketContext(TcpClient tcpClient, string protocol, bool secure, ServerSslConfiguration sslConfig, Logger log); // 0x000000018261E830-0x000000018261EA70
	
		// Methods
		private HttpRequest sendAuthenticationChallenge(string challenge); // 0x000000018261F050-0x000000018261F0D0
		internal bool Authenticate(AuthenticationSchemes scheme, string realm, Func<IIdentity, WebSocketSharp.Net.NetworkCredential> credentialsFinder); // 0x000000018261E590-0x000000018261E730
		internal void Close(); // 0x000000018261E7C0-0x000000018261E800
		internal void Close(WebSocketSharp.Net.HttpStatusCode code); // 0x000000018261E730-0x000000018261E7C0
		public override string ToString(); // 0x000000018261E800-0x000000018261E830
	}
}
