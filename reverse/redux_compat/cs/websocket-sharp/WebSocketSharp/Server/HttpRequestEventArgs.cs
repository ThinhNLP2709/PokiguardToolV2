/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using WebSocketSharp.Net;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	public class HttpRequestEventArgs : EventArgs // TypeDefIndex: 13323
	{
		// Fields
		private HttpListenerContext _context; // 0x10
		private string _docRootPath; // 0x18
	
		// Properties
		public HttpListenerRequest Request { get; } // 0x000000018261AAF0-0x000000018261AB10 
		public HttpListenerResponse Response { get; } // 0x000000018261AB10-0x000000018261AB30 
		public IPrincipal User { get; } // 0x000000018261A5E0-0x000000018261A600 
	
		// Constructors
		internal HttpRequestEventArgs(HttpListenerContext context, string documentRootPath); // 0x000000018261A920-0x000000018261A9B0
	
		// Methods
		private string createFilePath(string childPath); // 0x000000018261A9B0-0x000000018261AAF0
		private static bool tryReadFile(string path, out byte[] contents); // 0x000000018261AB30-0x000000018261ABA0
		public byte[] ReadFile(string path); // 0x000000018261A600-0x000000018261A790
		public bool TryReadFile(string path, out byte[] contents); // 0x000000018261A790-0x000000018261A920
	}
}
