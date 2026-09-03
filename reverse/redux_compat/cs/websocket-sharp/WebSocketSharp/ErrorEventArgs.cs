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
	public class ErrorEventArgs : EventArgs // TypeDefIndex: 13228
	{
		// Fields
		private Exception _exception; // 0x10
		private string _message; // 0x18
	
		// Properties
		public Exception Exception { get; } // 0x00000001825D8700-0x00000001825D8710 
		public string Message { get; } // 0x00000001825D8710-0x00000001825D8720 
	
		// Constructors
		internal ErrorEventArgs(string message); // 0x00000001825D8660-0x00000001825D8670
		internal ErrorEventArgs(string message, Exception exception); // 0x00000001825D8670-0x00000001825D8700
	}
}
