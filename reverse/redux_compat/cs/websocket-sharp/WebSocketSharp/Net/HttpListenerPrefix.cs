/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal sealed class HttpListenerPrefix // TypeDefIndex: 13306
	{
		// Fields
		private string _host; // 0x10
		private HttpListener _listener; // 0x18
		private string _original; // 0x20
		private string _path; // 0x28
		private string _port; // 0x30
		private string _prefix; // 0x38
		private bool _secure; // 0x40
	
		// Properties
		public string Host { get; } // 0x00000001825D8700-0x00000001825D8710 
		public bool IsSecure { get; } // 0x0000000182619CC0-0x0000000182619CD0 
		public HttpListener Listener { get; } // 0x00000001825D8710-0x00000001825D8720 
		public string Original { get; } // 0x00000001825DE400-0x00000001825DE410 
		public string Path { get; } // 0x00000001825EE1C0-0x00000001825EE1D0 
		public string Port { get; } // 0x00000001825F1D40-0x00000001825F1D50 
	
		// Constructors
		internal HttpListenerPrefix(string uriPrefix, HttpListener listener); // 0x0000000182619C60-0x0000000182619CC0
	
		// Methods
		private void parse(string uriPrefix); // 0x0000000182619CD0-0x000000018261A030
		public static void CheckPrefix(string uriPrefix); // 0x0000000182619760-0x0000000182619BB0
		public override bool Equals(object obj); // 0x0000000182619BB0-0x0000000182619C30
		public override int GetHashCode(); // 0x0000000182619C30-0x0000000182619C60
		public override string ToString(); // 0x00000001825EE1D0-0x00000001825EE1E0
	}
}
