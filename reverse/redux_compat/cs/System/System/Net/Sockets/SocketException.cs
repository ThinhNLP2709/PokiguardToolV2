/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	[Serializable]
	public class SocketException : Win32Exception // TypeDefIndex: 9222
	{
		// Fields
		[NonSerialized]
		private EndPoint m_EndPoint; // 0x98
	
		// Properties
		public override int ErrorCode { get; } // 0x000000018169CBC0-0x000000018169CBD0 
		public override string Message { get; } // 0x0000000181B2B400-0x0000000181B2B490 
		public SocketError SocketErrorCode { get; } // 0x000000018169CBC0-0x000000018169CBD0 
	
		// Constructors
		public SocketException(); // 0x0000000181B2B3E0-0x0000000181B2B400
		internal SocketException(int error, string message); // 0x0000000181B2B3A0-0x0000000181B2B3B0
		public SocketException(int errorCode); // 0x0000000181B2B3B0-0x0000000181B2B3C0
		internal SocketException(SocketError socketError); // 0x0000000181B2B3B0-0x0000000181B2B3C0
		protected SocketException(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B2B3C0-0x0000000181B2B3E0
	
		// Methods
		private static int WSAGetLastError_icall(); // 0x0000000181B2B390-0x0000000181B2B3A0
	}
}
