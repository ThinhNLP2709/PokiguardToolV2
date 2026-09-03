/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	public class WebSocketException : Exception // TypeDefIndex: 13248
	{
		// Fields
		private CloseStatusCode _code; // 0x90
	
		// Properties
		public CloseStatusCode Code { get; } // 0x0000000182601700-0x0000000182601710 
	
		// Constructors
		internal WebSocketException(); // 0x00000001826015C0-0x0000000182601660
		internal WebSocketException(Exception innerException); // 0x00000001826013F0-0x0000000182601490
		internal WebSocketException(string message); // 0x00000001826012A0-0x0000000182601340
		internal WebSocketException(CloseStatusCode code); // 0x0000000182601490-0x0000000182601520
		internal WebSocketException(string message, Exception innerException); // 0x0000000182601340-0x00000001826013F0
		internal WebSocketException(CloseStatusCode code, Exception innerException); // 0x0000000182601520-0x00000001826015C0
		internal WebSocketException(CloseStatusCode code, string message); // 0x0000000182601660-0x0000000182601700
		internal WebSocketException(CloseStatusCode code, string message, Exception innerException); // 0x00000001826011F0-0x00000001826012A0
	}
}
