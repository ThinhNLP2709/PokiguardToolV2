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
	internal class HttpHeaderInfo // TypeDefIndex: 13291
	{
		// Fields
		private string _headerName; // 0x10
		private HttpHeaderType _headerType; // 0x18
	
		// Properties
		internal bool IsMultiValueInRequest { get; } // 0x00000001826081E0-0x00000001826081F0 
		internal bool IsMultiValueInResponse { get; } // 0x00000001826081F0-0x0000000182608200 
		public string HeaderName { get; } // 0x00000001825D8700-0x00000001825D8710 
		public HttpHeaderType HeaderType { get; } // 0x00000001826081D0-0x00000001826081E0 
		public bool IsRequest { get; } // 0x0000000182608200-0x0000000182608210 
		public bool IsResponse { get; } // 0x0000000182608210-0x0000000182608220 
	
		// Constructors
		internal HttpHeaderInfo(string headerName, HttpHeaderType headerType); // 0x0000000180E02950-0x0000000180E029A0
	
		// Methods
		public bool IsMultiValue(bool response); // 0x0000000182608170-0x00000001826081B0
		public bool IsRestricted(bool response); // 0x00000001826081B0-0x00000001826081D0
	}
}
