/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal sealed class EndPointListener // TypeDefIndex: 13272
	{
		// Fields
		private List<HttpListenerPrefix> _all; // 0x10
		private Dictionary<HttpConnection, HttpConnection> _connections; // 0x18
		private object _connectionsSync; // 0x20
		private static readonly string _defaultCertFolderPath; // 0x00
		private IPEndPoint _endpoint; // 0x28
		private List<HttpListenerPrefix> _prefixes; // 0x30
		private bool _secure; // 0x38
		private Socket _socket; // 0x40
		private ServerSslConfiguration _sslConfig; // 0x48
		private List<HttpListenerPrefix> _unhandled; // 0x50
	
		// Properties
		public IPAddress Address { get; } // 0x0000000181BF3B80-0x0000000181BF3BA0 
		public bool IsSecure { get; } // 0x00000001825F1D50-0x00000001825F1D60 
		public int Port { get; } // 0x000000018062F200-0x000000018062F220 
		public ServerSslConfiguration SslConfiguration { get; } // 0x00000001825E8B00-0x00000001825E8B10 
	
		// Constructors
		static EndPointListener(); // 0x00000001825F3BD0-0x00000001825F3C30
		internal EndPointListener(IPEndPoint endpoint, bool secure, string certificateFolderPath, ServerSslConfiguration sslConfig, bool reuseAddress); // 0x00000001825F3C30-0x00000001825F3F90
	
		// Methods
		private static void addSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix); // 0x00000001825F3F90-0x00000001825F41B0
		private void clearConnections(); // 0x00000001825F41B0-0x00000001825F4340
		private static RSACryptoServiceProvider createRSAFromFile(string path); // 0x00000001825F4340-0x00000001825F43C0
		private static X509Certificate2 getCertificate(int port, string folderPath, X509Certificate2 defaultCertificate); // 0x00000001825F43C0-0x00000001825F45F0
		private void leaveIfNoPrefix(); // 0x00000001825F45F0-0x00000001825F46A0
		private static void onAccept(IAsyncResult asyncResult); // 0x00000001825F46A0-0x00000001825F4840
		private static void processAccepted(Socket socket, EndPointListener listener); // 0x00000001825F4840-0x00000001825F4980
		private static bool removeSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix); // 0x00000001825F4980-0x00000001825F4A30
		private static HttpListener searchHttpListenerFromSpecial(string path, List<HttpListenerPrefix> prefixes); // 0x00000001825F4A30-0x00000001825F4BA0
		internal static bool CertificateExists(int port, string folderPath); // 0x00000001825F3210-0x00000001825F3360
		internal void RemoveConnection(HttpConnection connection); // 0x00000001825F33D0-0x00000001825F3490
		internal bool TrySearchHttpListener(Uri uri, out HttpListener listener); // 0x00000001825F37F0-0x00000001825F3BD0
		public void AddPrefix(HttpListenerPrefix prefix); // 0x00000001825F2EA0-0x00000001825F3210
		public void Close(); // 0x00000001825F3360-0x00000001825F33D0
		public void RemovePrefix(HttpListenerPrefix prefix); // 0x00000001825F3490-0x00000001825F37F0
	}
}
