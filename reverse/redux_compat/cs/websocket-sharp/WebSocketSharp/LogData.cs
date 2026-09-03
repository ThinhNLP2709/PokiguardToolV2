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
	public class LogData // TypeDefIndex: 13249
	{
		// Fields
		private StackFrame _caller; // 0x10
		private DateTime _date; // 0x18
		private LogLevel _level; // 0x20
		private string _message; // 0x28
	
		// Properties
		public StackFrame Caller { get; } // 0x00000001825D8700-0x00000001825D8710 
		public DateTime Date { get; } // 0x00000001825D8710-0x00000001825D8720 
		public LogLevel Level { get; } // 0x00000001825EE1B0-0x00000001825EE1C0 
		public string Message { get; } // 0x00000001825EE1C0-0x00000001825EE1D0 
	
		// Constructors
		internal LogData(LogLevel level, StackFrame caller, string message); // 0x00000001825FF860-0x00000001825FF920
	
		// Methods
		public override string ToString(); // 0x00000001825FF320-0x00000001825FF860
	}
}
