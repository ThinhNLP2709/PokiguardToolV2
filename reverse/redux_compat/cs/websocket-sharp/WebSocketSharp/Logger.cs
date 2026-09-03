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
	public class Logger // TypeDefIndex: 13251
	{
		// Fields
		private string _file; // 0x10
		private LogLevel _level; // 0x18
		private Action<LogData, string> _output; // 0x20
		private object _sync; // 0x28
	
		// Properties
		public string File { get; set; } // 0x0000000180DEFF60-0x0000000180DEFF80 0x00000001825FFEF0-0x00000001825FFFF0
		public LogLevel Level { get; set; } // 0x00000001825FFCA0-0x00000001825FFCC0 0x00000001825FFFF0-0x0000000182600100
		public Action<LogData, string> Output { get; set; } // 0x00000001825DE400-0x00000001825DE410 0x0000000182600100-0x0000000182600220
	
		// Constructors
		public Logger(); // 0x00000001825FFBD0-0x00000001825FFC00
		public Logger(LogLevel level); // 0x00000001825FFAC0-0x00000001825FFAE0
		public Logger(LogLevel level, string file, Action<LogData, string> output); // 0x00000001825FFAE0-0x00000001825FFBD0
	
		// Methods
		private static void defaultOutput(LogData data, string path); // 0x00000001825FFC00-0x00000001825FFCA0
		private void output(string message, LogLevel level); // 0x00000001825FFCC0-0x00000001825FFEF0
		private static void writeToFile(string value, string path); // 0x0000000182600220-0x00000001826003F0
		public void Debug(string message); // 0x00000001825FF920-0x00000001825FF970
		public void Error(string message); // 0x00000001825FF970-0x00000001825FF9C0
		public void Fatal(string message); // 0x00000001825FF9C0-0x00000001825FF9D0
		public void Info(string message); // 0x00000001825FF9D0-0x00000001825FFA20
		public void Trace(string message); // 0x00000001825FFA20-0x00000001825FFA70
		public void Warn(string message); // 0x00000001825FFA70-0x00000001825FFAC0
	}
}
