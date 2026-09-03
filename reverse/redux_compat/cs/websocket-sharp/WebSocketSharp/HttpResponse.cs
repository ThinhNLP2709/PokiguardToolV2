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
	internal class HttpResponse : HttpBase // TypeDefIndex: 13266
	{
		// Fields
		private string _code; // 0x28
		private string _reason; // 0x30
	
		// Properties
		public CookieCollection Cookies { get; } // 0x00000001825FF060-0x00000001825FF0B0 
		public bool HasConnectionClose { get; } // 0x00000001825FF0B0-0x00000001825FF140 
		public bool IsProxyAuthenticationRequired { get; } // 0x00000001825FF140-0x00000001825FF180 
		public bool IsRedirect { get; } // 0x00000001825FF180-0x00000001825FF1F0 
		public bool IsUnauthorized { get; } // 0x00000001825FF1F0-0x00000001825FF230 
		public bool IsWebSocketResponse { get; } // 0x00000001825FF230-0x00000001825FF320 
		public string Reason { get; } // 0x00000001825F1D40-0x00000001825F1D50 
		public string StatusCode { get; } // 0x00000001825EE1C0-0x00000001825EE1D0 
	
		// Constructors
		private HttpResponse(string code, string reason, Version version, NameValueCollection headers); // 0x00000001825FEE70-0x00000001825FEEF0
		internal HttpResponse(HttpStatusCode code); // 0x00000001825FEEF0-0x00000001825FF060
		internal HttpResponse(HttpStatusCode code, string reason); // 0x00000001825FED40-0x00000001825FEE70
	
		// Methods
		internal static HttpResponse CreateCloseResponse(HttpStatusCode code); // 0x00000001825FE2C0-0x00000001825FE360
		internal static HttpResponse CreateUnauthorizedResponse(string challenge); // 0x00000001825FE360-0x00000001825FE3F0
		internal static HttpResponse CreateWebSocketResponse(); // 0x00000001825FE3F0-0x00000001825FE4B0
		internal static HttpResponse Parse(string[] headerParts); // 0x00000001825FE4B0-0x00000001825FE720
		internal static HttpResponse Read(Stream stream, int millisecondsTimeout); // 0x00000001825FE720-0x00000001825FE7B0
		public void SetCookies(CookieCollection cookies); // 0x00000001825FE7B0-0x00000001825FEA40
		public override string ToString(); // 0x00000001825FEA40-0x00000001825FED40
	}
}
