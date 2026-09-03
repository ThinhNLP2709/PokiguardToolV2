/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebSocketSharp.Net;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	internal class HttpRequest : HttpBase // TypeDefIndex: 13265
	{
		// Fields
		private CookieCollection _cookies; // 0x28
		private string _method; // 0x30
		private string _uri; // 0x38
	
		// Properties
		public AuthenticationResponse AuthenticationResponse { get; } // 0x00000001825FE0F0-0x00000001825FE160 
		public CookieCollection Cookies { get; } // 0x00000001825FE160-0x00000001825FE1E0 
		public string HttpMethod { get; } // 0x00000001825F1D40-0x00000001825F1D50 
		public bool IsWebSocketRequest { get; } // 0x00000001825FE1E0-0x00000001825FE2C0 
		public string RequestUri { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
	
		// Constructors
		private HttpRequest(string method, string uri, Version version, NameValueCollection headers); // 0x00000001825FDF40-0x00000001825FDFC0
		internal HttpRequest(string method, string uri); // 0x00000001825FDFC0-0x00000001825FE0F0
	
		// Methods
		internal static HttpRequest CreateConnectRequest(Uri uri); // 0x00000001825FD230-0x00000001825FD350
		internal static HttpRequest CreateWebSocketRequest(Uri uri); // 0x00000001825FD350-0x00000001825FD4F0
		internal HttpResponse GetResponse(Stream stream, int millisecondsTimeout); // 0x00000001825FD4F0-0x00000001825FD610
		internal static HttpRequest Parse(string[] headerParts); // 0x00000001825FD610-0x00000001825FD890
		internal static HttpRequest Read(Stream stream, int millisecondsTimeout); // 0x00000001825FD890-0x00000001825FD920
		public void SetCookies(CookieCollection cookies); // 0x00000001825FD920-0x00000001825FDC40
		public override string ToString(); // 0x00000001825FDC40-0x00000001825FDF40
	}
}
