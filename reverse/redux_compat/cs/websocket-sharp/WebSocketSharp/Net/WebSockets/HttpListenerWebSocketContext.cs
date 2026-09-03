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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using WebSocketSharp;
using WebSocketSharp.Net;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net.WebSockets
{
	public class HttpListenerWebSocketContext : WebSocketContext // TypeDefIndex: 13312
	{
		// Fields
		private HttpListenerContext _context; // 0x10
		private WebSocket _websocket; // 0x18
	
		// Properties
		internal Logger Log { get; } // 0x000000018261A2E0-0x000000018261A310 
		internal Stream Stream { get; } // 0x000000018261A580-0x000000018261A5B0 
		public override WebSocketSharp.Net.CookieCollection CookieCollection { get; } // 0x000000018261A190-0x000000018261A1C0 
		public override NameValueCollection Headers { get; } // 0x000000018261A1C0-0x000000018261A1F0 
		public override string Host { get; } // 0x000000018261A1F0-0x000000018261A220 
		public override bool IsAuthenticated { get; } // 0x000000018261A220-0x000000018261A250 
		public override bool IsLocal { get; } // 0x000000018261A250-0x000000018261A280 
		public override bool IsSecureConnection { get; } // 0x000000018261A280-0x000000018261A2B0 
		public override bool IsWebSocketRequest { get; } // 0x000000018261A2B0-0x000000018261A2E0 
		public override string Origin { get; } // 0x000000018261A310-0x000000018261A380 
		public override NameValueCollection QueryString { get; } // 0x000000018261A380-0x000000018261A3B0 
		public override Uri RequestUri { get; } // 0x000000018261A3B0-0x000000018261A3E0 
		public override string SecWebSocketKey { get; } // 0x000000018261A3E0-0x000000018261A450 
		public override IEnumerable<string> SecWebSocketProtocols { get; } // 0x000000018261A450-0x000000018261A4E0 
		public override string SecWebSocketVersion { get; } // 0x000000018261A4E0-0x000000018261A550 
		public override IPEndPoint ServerEndPoint { get; } // 0x000000018261A550-0x000000018261A580 
		public override IPrincipal User { get; } // 0x000000018261A5E0-0x000000018261A600 
		public override IPEndPoint UserEndPoint { get; } // 0x000000018261A5B0-0x000000018261A5E0 
		public override WebSocket WebSocket { get; } // 0x00000001825D8710-0x00000001825D8720 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _get_SecWebSocketProtocols_d__30 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 13313
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public HttpListenerWebSocketContext __4__this; // 0x28
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
			public _get_SecWebSocketProtocols_d__30(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x000000018261FD90-0x000000018261FF90
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182620050-0x0000000182620090
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x000000018261FF90-0x0000000182620050
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018261FF90-0x0000000182620050
		}
	
		// Constructors
		internal HttpListenerWebSocketContext(HttpListenerContext context, string protocol); // 0x000000018261A100-0x000000018261A190
	
		// Methods
		internal void Close(); // 0x000000018261A030-0x000000018261A060
		internal void Close(WebSocketSharp.Net.HttpStatusCode code); // 0x000000018261A060-0x000000018261A0C0
		public override string ToString(); // 0x000000018261A0C0-0x000000018261A100
	}
}
