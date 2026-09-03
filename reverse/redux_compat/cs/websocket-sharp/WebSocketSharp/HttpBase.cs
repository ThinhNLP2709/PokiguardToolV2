/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	internal abstract class HttpBase // TypeDefIndex: 13262
	{
		// Fields
		private NameValueCollection _headers; // 0x10
		private const int _headersMaxLength = 8192; // Metadata: 0x006A7868
		private Version _version; // 0x18
		internal byte[] EntityBodyData; // 0x20
		protected const string CrLf = "\r\n"; // Metadata: 0x006A786C
	
		// Properties
		public string EntityBody { get; } // 0x00000001825F61B0-0x00000001825F62B0 
		public NameValueCollection Headers { get; } // 0x00000001825D8700-0x00000001825D8710 
		public Version ProtocolVersion { get; } // 0x00000001825D8710-0x00000001825D8720 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 13263
		{
			// Fields
			public List<byte> buff; // 0x10
			public int cnt; // 0x18
	
			// Constructors
			public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _readHeaders_b__0(int i); // 0x0000000182600610-0x0000000182600710
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0<T> // TypeDefIndex: 13264
			where T : HttpBase
		{
			// Fields
			public bool timeout;
			public Stream stream;
	
			// Constructors
			public __c__DisplayClass14_0();
	
			// Methods
			internal void _Read_b__0(object state);
		}
	
		// Constructors
		protected HttpBase(Version version, NameValueCollection headers); // 0x00000001814BCAD0-0x00000001814BCB20
	
		// Methods
		private static byte[] readEntityBody(Stream stream, string length); // 0x00000001825F62B0-0x00000001825F6430
		private static string[] readHeaders(Stream stream, int maxLength); // 0x00000001825F6430-0x00000001825F6800
		protected static T Read<T>(Stream stream, Func<string[], T> parser, int millisecondsTimeout)
			where T : HttpBase;
		public byte[] ToByteArray(); // 0x00000001825F6150-0x00000001825F61B0
	}
}
