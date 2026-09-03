/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	[Serializable]
	public class HttpListenerException : Win32Exception // TypeDefIndex: 13277
	{
		// Properties
		public override int ErrorCode { get; } // 0x00000001825F8F40-0x00000001825F8F50 
	
		// Constructors
		protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B2B3C0-0x0000000181B2B3E0
		public HttpListenerException(); // 0x00000001825F8F30-0x00000001825F8F40
		public HttpListenerException(int errorCode); // 0x0000000181B2B3B0-0x0000000181B2B3C0
		public HttpListenerException(int errorCode, string message); // 0x0000000181B2B3A0-0x0000000181B2B3B0
	}
}
