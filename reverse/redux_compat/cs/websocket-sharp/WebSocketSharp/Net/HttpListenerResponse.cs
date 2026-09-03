/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public sealed class HttpListenerResponse : IDisposable // TypeDefIndex: 13280
	{
		// Fields
		private bool _closeConnection; // 0x10
		private Encoding _contentEncoding; // 0x18
		private long _contentLength; // 0x20
		private string _contentType; // 0x28
		private HttpListenerContext _context; // 0x30
		private CookieCollection _cookies; // 0x38
		private bool _disposed; // 0x40
		private WebHeaderCollection _headers; // 0x48
		private bool _headersSent; // 0x50
		private bool _keepAlive; // 0x51
		private ResponseStream _outputStream; // 0x58
		private Uri _redirectLocation; // 0x60
		private bool _sendChunked; // 0x68
		private int _statusCode; // 0x6C
		private string _statusDescription; // 0x70
		private Version _version; // 0x78
	
		// Properties
		internal bool CloseConnection { get; set; } // 0x00000001825D8650-0x00000001825D8660 0x00000001804C2E20-0x00000001804C2E30
		internal WebHeaderCollection FullHeaders { get; } // 0x0000000182609200-0x00000001826098F0 
		internal bool HeadersSent { get; set; } // 0x00000001825E8B20-0x00000001825E8B30 0x00000001803780E0-0x00000001803780F0
		internal string StatusLine { get; } // 0x0000000182609AE0-0x0000000182609B50 
		public Encoding ContentEncoding { get; set; } // 0x00000001825D8710-0x00000001825D8720 0x0000000182609C50-0x0000000182609D30
		public long ContentLength64 { get; set; } // 0x00000001825DE400-0x00000001825DE410 0x0000000182609D30-0x0000000182609E70
		public string ContentType { get; set; } // 0x00000001825EE1C0-0x00000001825EE1D0 0x0000000182609E70-0x000000018260A0B0
		public CookieCollection Cookies { get; set; } // 0x0000000182609190-0x0000000182609200 0x000000018033E850-0x000000018033E860
		public WebHeaderCollection Headers { get; set; } // 0x00000001826098F0-0x0000000182609970 0x000000018260A0B0-0x000000018260A150
		public bool KeepAlive { get; set; } // 0x00000001825E8B30-0x00000001825E8B40 0x000000018260A150-0x000000018260A220
		public Stream OutputStream { get; } // 0x0000000182609970-0x0000000182609A40 
		public Version ProtocolVersion { get; } // 0x00000001825F1F20-0x00000001825F1F30 
		public string RedirectLocation { get; set; } // 0x0000000182609A40-0x0000000182609AD0 0x000000018260A220-0x000000018260A440
		public bool SendChunked { get; set; } // 0x00000001825F1F00-0x00000001825F1F10 0x000000018260A440-0x000000018260A510
		public int StatusCode { get; set; } // 0x0000000182609AD0-0x0000000182609AE0 0x000000018260A510-0x000000018260A6A0
		public string StatusDescription { get; set; } // 0x00000001825F1F10-0x00000001825F1F20 0x000000018260A6A0-0x000000018260A8C0
	
		// Nested types
		[CompilerGenerated]
		private sealed class _findCookie_d__65 : IEnumerable<Cookie>, IEnumerator<Cookie> // TypeDefIndex: 13281
		{
			// Fields
			private int __1__state; // 0x10
			private Cookie __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private Cookie cookie; // 0x28
			public Cookie __3__cookie; // 0x30
			public HttpListenerResponse __4__this; // 0x38
			private IEnumerator<Cookie> __s__1; // 0x40
			private Cookie _c_5__2; // 0x48
	
			// Properties
			Cookie IEnumerator<WebSocketSharp.Net.Cookie>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _findCookie_d__65(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000182615270-0x0000000182615310
			private bool MoveNext(); // 0x0000000182614EC0-0x0000000182615150
			private void __m__Finally1(); // 0x0000000182615310-0x0000000182615360
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182615230-0x0000000182615270
			[DebuggerHidden]
			IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator(); // 0x0000000182615150-0x0000000182615230
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182615150-0x0000000182615230
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 13282
		{
			// Fields
			public Stream stream; // 0x10
			public HttpListenerResponse __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Close_b__0(IAsyncResult ar); // 0x0000000182614DF0-0x0000000182614E50
		}
	
		// Constructors
		internal HttpListenerResponse(HttpListenerContext context); // 0x0000000182608BF0-0x0000000182608CB0
	
		// Methods
		private bool canSetCookie(Cookie cookie); // 0x0000000182608CB0-0x0000000182608EB0
		private void close(bool force); // 0x0000000182608FF0-0x0000000182609030
		private void close(byte[] responseEntity, int bufferLength, bool willBlock); // 0x0000000182608EB0-0x0000000182608FF0
		private static string createContentTypeHeaderText(string value, Encoding encoding); // 0x0000000182609030-0x00000001826090E0
		private IEnumerable<Cookie> findCookie(Cookie cookie); // 0x00000001826090E0-0x0000000182609190
		private static bool isValidForContentType(string value); // 0x0000000182609B50-0x0000000182609BF0
		private static bool isValidForStatusDescription(string value); // 0x0000000182609BF0-0x0000000182609C50
		public void Abort(); // 0x0000000182608220-0x0000000182608260
		public void AppendCookie(Cookie cookie); // 0x0000000182608260-0x00000001826082F0
		public void AppendHeader(string name, string value); // 0x00000001826082F0-0x0000000182608340
		public void Close(); // 0x0000000182608680-0x00000001826086C0
		public void Close(byte[] responseEntity, bool willBlock); // 0x0000000182608340-0x0000000182608680
		public void CopyFrom(HttpListenerResponse templateResponse); // 0x00000001826086C0-0x00000001826087D0
		public void Redirect(string url); // 0x00000001826087D0-0x0000000182608A60
		public void SetCookie(Cookie cookie); // 0x0000000182608A60-0x0000000182608B60
		public void SetHeader(string name, string value); // 0x0000000182608B60-0x0000000182608BB0
		void IDisposable.Dispose(); // 0x0000000182608220-0x0000000182608260
		[CompilerGenerated]
		private void _close_b__63_0(); // 0x0000000182608BB0-0x0000000182608BF0
	}
}
