/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using WebSocketSharp;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public sealed class HttpListener : IDisposable // TypeDefIndex: 13275
	{
		// Fields
		private AuthenticationSchemes _authSchemes; // 0x10
		private Func<HttpListenerRequest, AuthenticationSchemes> _authSchemeSelector; // 0x18
		private string _certFolderPath; // 0x20
		private Queue<HttpListenerContext> _contextQueue; // 0x28
		private LinkedList<HttpListenerContext> _contextRegistry; // 0x30
		private object _contextRegistrySync; // 0x38
		private static readonly string _defaultRealm; // 0x00
		private bool _disposed; // 0x40
		private bool _ignoreWriteExceptions; // 0x41
		private bool _listening; // 0x42
		private Logger _log; // 0x48
		private string _objectName; // 0x50
		private HttpListenerPrefixCollection _prefixes; // 0x58
		private string _realm; // 0x60
		private bool _reuseAddress; // 0x68
		private ServerSslConfiguration _sslConfig; // 0x70
		private Func<IIdentity, NetworkCredential> _userCredFinder; // 0x78
		private Queue<HttpListenerAsyncResult> _waitQueue; // 0x80
	
		// Properties
		internal bool ReuseAddress { get; set; } // 0x00000001825F1F00-0x00000001825F1F10 0x0000000180B262C0-0x0000000180B262D0
		public AuthenticationSchemes AuthenticationSchemes { get; set; } // 0x00000001825FC9B0-0x00000001825FCA20 0x00000001825FCFC0-0x00000001825FD030
		public Func<HttpListenerRequest, AuthenticationSchemes> AuthenticationSchemeSelector { get; set; } // 0x00000001825FC940-0x00000001825FC9B0 0x00000001825FCF50-0x00000001825FCFC0
		public string CertificateFolderPath { get; set; } // 0x00000001825FCA20-0x00000001825FCA90 0x00000001825FD030-0x00000001825FD0A0
		public bool IgnoreWriteExceptions { get; set; } // 0x00000001825FCA90-0x00000001825FCB00 0x00000001825FD0A0-0x00000001825FD110
		public bool IsListening { get; } // 0x00000001825FCB00-0x00000001825FCB20 
		public static bool IsSupported { get; } // 0x00000001825FCB20-0x00000001825FCB30 
		public Logger Log { get; } // 0x00000001825E8B00-0x00000001825E8B10 
		public HttpListenerPrefixCollection Prefixes { get; } // 0x00000001825FCB30-0x00000001825FCBA0 
		public string Realm { get; set; } // 0x00000001825FCBA0-0x00000001825FCC10 0x00000001825FD110-0x00000001825FD180
		public ServerSslConfiguration SslConfiguration { get; } // 0x00000001825FCC10-0x00000001825FCCC0 
		public bool UnsafeConnectionNtlmAuthentication { get; set; } // 0x00000001825FCCC0-0x00000001825FCD00 0x00000001825FD180-0x00000001825FD1C0
		public Func<IIdentity, NetworkCredential> UserCredentialsFinder { get; set; } // 0x00000001825FCD00-0x00000001825FCD70 0x00000001825FD1C0-0x00000001825FD230
	
		// Constructors
		static HttpListener(); // 0x00000001825FBD90-0x00000001825FBE00
		public HttpListener(); // 0x00000001825FBE00-0x00000001825FC070
	
		// Methods
		private bool authenticateContext(HttpListenerContext context); // 0x00000001825FC070-0x00000001825FC330
		private HttpListenerAsyncResult beginGetContext(AsyncCallback callback, object state); // 0x00000001825FC330-0x00000001825FC530
		private void cleanupContextQueue(bool force); // 0x00000001825FC530-0x00000001825FC600
		private void cleanupContextRegistry(); // 0x00000001825FC600-0x00000001825FC6F0
		private void cleanupWaitQueue(string message); // 0x00000001825FC6F0-0x00000001825FC810
		private void close(bool force); // 0x00000001825FC810-0x00000001825FC8D0
		private string getRealm(); // 0x00000001825FC8D0-0x00000001825FC940
		private bool registerContext(HttpListenerContext context); // 0x00000001825FCD70-0x00000001825FCF20
		private AuthenticationSchemes selectAuthenticationScheme(HttpListenerRequest request); // 0x00000001825FCF20-0x00000001825FCF50
		internal void CheckDisposed(); // 0x00000001825FB390-0x00000001825FB400
		internal bool RegisterContext(HttpListenerContext context); // 0x00000001825FB940-0x00000001825FB9B0
		internal void UnregisterContext(HttpListenerContext context); // 0x00000001825FBCD0-0x00000001825FBD90
		public void Abort(); // 0x00000001825FB190-0x00000001825FB230
		public IAsyncResult BeginGetContext(AsyncCallback callback, object state); // 0x00000001825FB230-0x00000001825FB390
		public void Close(); // 0x00000001825FB400-0x00000001825FB4A0
		public HttpListenerContext EndGetContext(IAsyncResult asyncResult); // 0x00000001825FB4A0-0x00000001825FB7A0
		public HttpListenerContext GetContext(); // 0x00000001825FB7A0-0x00000001825FB940
		public void Start(); // 0x00000001825FB9B0-0x00000001825FBB20
		public void Stop(); // 0x00000001825FBB20-0x00000001825FBCD0
		void IDisposable.Dispose(); // 0x00000001825FB190-0x00000001825FB230
	}
}
