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
	public class MessageEventArgs : EventArgs // TypeDefIndex: 13225
	{
		// Fields
		private string _data; // 0x10
		private bool _dataSet; // 0x18
		private Opcode _opcode; // 0x19
		private byte[] _rawData; // 0x20
	
		// Properties
		internal Opcode Opcode { get; } // 0x00000001825DDB80-0x00000001825DDB90 
		public string Data { get; } // 0x00000001825DDB30-0x00000001825DDB50 
		public bool IsBinary { get; } // 0x00000001825DDB50-0x00000001825DDB60 
		public bool IsPing { get; } // 0x00000001825DDB60-0x00000001825DDB70 
		public bool IsText { get; } // 0x00000001825DDB70-0x00000001825DDB80 
		public byte[] RawData { get; } // 0x00000001825DDB90-0x00000001825DDBB0 
	
		// Constructors
		internal MessageEventArgs(WebSocketFrame frame); // 0x00000001825DDA90-0x00000001825DDB30
		internal MessageEventArgs(Opcode opcode, byte[] rawData); // 0x00000001825DD980-0x00000001825DDA90
	
		// Methods
		private void setData(); // 0x00000001825DDBB0-0x00000001825DDC40
	}
}
