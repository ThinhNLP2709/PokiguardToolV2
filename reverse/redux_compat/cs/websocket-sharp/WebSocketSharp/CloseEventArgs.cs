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
	public class CloseEventArgs : EventArgs // TypeDefIndex: 13226
	{
		// Fields
		private bool _clean; // 0x10
		private PayloadData _payloadData; // 0x18
	
		// Properties
		public ushort Code { get; } // 0x00000001825D8560-0x00000001825D8580 
		public string Reason { get; } // 0x00000001825D8580-0x00000001825D8650 
		public bool WasClean { get; } // 0x00000001825D8650-0x00000001825D8660 
	
		// Constructors
		internal CloseEventArgs(PayloadData payloadData, bool clean); // 0x00000001825D84E0-0x00000001825D8560
		internal CloseEventArgs(ushort code, string reason, bool clean); // 0x00000001825D8420-0x00000001825D84E0
	}
}
