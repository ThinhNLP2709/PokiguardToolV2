/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public sealed class HttpListenerRequest // TypeDefIndex: 13279
	{
		// Fields
		private static readonly byte[] _100continue; // 0x00
		private string[] _acceptTypes; // 0x10
		private bool _chunked; // 0x18
		private HttpConnection _connection; // 0x20
		private Encoding _contentEncoding; // 0x28
		private long _contentLength; // 0x30
		private HttpListenerContext _context; // 0x38
		private CookieCollection _cookies; // 0x40
		private WebHeaderCollection _headers; // 0x48
		private string _httpMethod; // 0x50
		private Stream _inputStream; // 0x58
		private Version _protocolVersion; // 0x60
		private NameValueCollection _queryString; // 0x68
		private string _rawUrl; // 0x70
		private Guid _requestTraceIdentifier; // 0x78
		private Uri _url; // 0x88
		private Uri _urlReferrer; // 0x90
		private bool _urlSet; // 0x98
		private string _userHostName; // 0xA0
		private string[] _userLanguages; // 0xA8
	
		// Properties
		public string[] AcceptTypes { get; } // 0x00000001825FA4E0-0x00000001825FA630 
		public int ClientCertificateError { get; } // 0x00000001825FA630-0x00000001825FA670 
		public Encoding ContentEncoding { get; } // 0x00000001825FA670-0x00000001825FA740 
		public long ContentLength64 { get; } // 0x00000001825F1D40-0x00000001825F1D50 
		public string ContentType { get; } // 0x00000001825FA740-0x00000001825FA790 
		public CookieCollection Cookies { get; } // 0x00000001825FA790-0x00000001825FA810 
		public bool HasEntityBody { get; } // 0x00000001825FA810-0x00000001825FA830 
		public NameValueCollection Headers { get; } // 0x00000001825E8B00-0x00000001825E8B10 
		public string HttpMethod { get; } // 0x00000001825F1E80-0x00000001825F1E90 
		public Stream InputStream { get; } // 0x00000001825FA830-0x00000001825FA8C0 
		public bool IsAuthenticated { get; } // 0x00000001825FA8C0-0x00000001825FA8E0 
		public bool IsLocal { get; } // 0x00000001825FA8E0-0x00000001825FA990 
		public bool IsSecureConnection { get; } // 0x00000001825FA990-0x00000001825FA9B0 
		public bool IsWebSocketRequest { get; } // 0x00000001825FA9B0-0x00000001825FAA40 
		public bool KeepAlive { get; } // 0x00000001825FAA40-0x00000001825FAAA0 
		public IPEndPoint LocalEndPoint { get; } // 0x00000001825FAAA0-0x00000001825FAB20 
		public Version ProtocolVersion { get; } // 0x00000001825F1EF0-0x00000001825F1F00 
		public NameValueCollection QueryString { get; } // 0x00000001825FAB20-0x00000001825FABE0 
		public string RawUrl { get; } // 0x00000001825F1F10-0x00000001825F1F20 
		public IPEndPoint RemoteEndPoint { get; } // 0x00000001825FABE0-0x00000001825FAC60 
		public Guid RequestTraceIdentifier { get; } // 0x00000001825FAC60-0x00000001825FAC70 
		public Uri Url { get; } // 0x00000001825FAD70-0x00000001825FAF50 
		public Uri UrlReferrer { get; } // 0x00000001825FAC70-0x00000001825FAD70 
		public string UserAgent { get; } // 0x00000001825FAF50-0x00000001825FAFA0 
		public string UserHostAddress { get; } // 0x00000001825FAFA0-0x00000001825FB030 
		public string UserHostName { get; } // 0x00000001825FB030-0x00000001825FB040 
		public string[] UserLanguages { get; } // 0x00000001825FB040-0x00000001825FB190 
	
		// Constructors
		static HttpListenerRequest(); // 0x00000001825FA2E0-0x00000001825FA370
		internal HttpListenerRequest(HttpListenerContext context); // 0x00000001825FA370-0x00000001825FA430
	
		// Methods
		private Encoding getContentEncoding(); // 0x00000001825FA430-0x00000001825FA4E0
		internal void AddHeader(string headerField); // 0x00000001825F9650-0x00000001825F9900
		internal void FinishInitialization(); // 0x00000001825F9980-0x00000001825F9C30
		internal bool FlushInput(); // 0x00000001825F9C30-0x00000001825F9E40
		internal bool IsUpgradeRequest(string protocol); // 0x00000001825F9E80-0x00000001825F9EE0
		internal void SetRequestLine(string requestLine); // 0x00000001825F9EE0-0x00000001825FA200
		public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state); // 0x00000001825F9900-0x00000001825F9940
		public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult); // 0x00000001825F9940-0x00000001825F9980
		public X509Certificate2 GetClientCertificate(); // 0x00000001825F9E40-0x00000001825F9E80
		public override string ToString(); // 0x00000001825FA200-0x00000001825FA2E0
	}
}
