/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using WebSocketSharp;
using WebSocketSharp.Net;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net.WebSockets
{
	public abstract class WebSocketContext // TypeDefIndex: 13317
	{
		// Properties
		public abstract WebSocketSharp.Net.CookieCollection CookieCollection { get; }
		public abstract NameValueCollection Headers { get; }
		public abstract string Host { get; }
		public abstract bool IsAuthenticated { get; }
		public abstract bool IsLocal { get; }
		public abstract bool IsSecureConnection { get; }
		public abstract bool IsWebSocketRequest { get; }
		public abstract string Origin { get; }
		public abstract NameValueCollection QueryString { get; }
		public abstract Uri RequestUri { get; }
		public abstract string SecWebSocketKey { get; }
		public abstract IEnumerable<string> SecWebSocketProtocols { get; }
		public abstract string SecWebSocketVersion { get; }
		public abstract IPEndPoint ServerEndPoint { get; }
		public abstract IPrincipal User { get; }
		public abstract IPEndPoint UserEndPoint { get; }
		public abstract WebSocket WebSocket { get; }
	
		// Constructors
		protected WebSocketContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
