/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using WebSocketSharp.Net.WebSockets;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public sealed class HttpListenerContext // TypeDefIndex: 13276
	{
		// Fields
		private HttpConnection _connection; // 0x10
		private string _errorMessage; // 0x18
		private int _errorStatusCode; // 0x20
		private HttpListener _listener; // 0x28
		private HttpListenerRequest _request; // 0x30
		private HttpListenerResponse _response; // 0x38
		private IPrincipal _user; // 0x40
		private HttpListenerWebSocketContext _websocketContext; // 0x48
	
		// Properties
		internal HttpConnection Connection { get; } // 0x00000001825D8700-0x00000001825D8710 
		internal string ErrorMessage { get; set; } // 0x00000001825D8710-0x00000001825D8720 0x00000001802FAF70-0x00000001802FAF80
		internal int ErrorStatusCode { get; set; } // 0x00000001825EE1B0-0x00000001825EE1C0 0x0000000180E332D0-0x0000000180E332E0
		internal bool HasErrorMessage { get; } // 0x00000001825F8F20-0x00000001825F8F30 
		internal HttpListener Listener { get; set; } // 0x00000001825EE1C0-0x00000001825EE1D0 0x000000018033E840-0x000000018033E850
		public HttpListenerRequest Request { get; } // 0x00000001825F1D40-0x00000001825F1D50 
		public HttpListenerResponse Response { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
		public IPrincipal User { get; internal set; } // 0x00000001825E8A60-0x00000001825E8A70 0x0000000180378120-0x0000000180378130
	
		// Constructors
		internal HttpListenerContext(HttpConnection connection); // 0x00000001825F8D00-0x00000001825F8E50
	
		// Methods
		private static string createErrorContent(int statusCode, string statusDescription, string message); // 0x00000001825F8E50-0x00000001825F8F20
		internal HttpListenerWebSocketContext GetWebSocketContext(string protocol); // 0x00000001825F8930-0x00000001825F89B0
		internal void SendAuthenticationChallenge(AuthenticationSchemes scheme, string realm); // 0x00000001825F89B0-0x00000001825F8AB0
		internal void SendError(); // 0x00000001825F8AF0-0x00000001825F8CE0
		internal void SendError(int statusCode); // 0x00000001825F8AE0-0x00000001825F8AF0
		internal void SendError(int statusCode, string message); // 0x00000001825F8AB0-0x00000001825F8AE0
		internal void Unregister(); // 0x00000001825F8CE0-0x00000001825F8D00
		public HttpListenerWebSocketContext AcceptWebSocket(string protocol); // 0x00000001825F8750-0x00000001825F8930
	}
}
