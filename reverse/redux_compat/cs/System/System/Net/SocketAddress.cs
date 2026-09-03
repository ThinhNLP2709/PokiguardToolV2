/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public class SocketAddress // TypeDefIndex: 9050
	{
		// Fields
		internal int m_Size; // 0x10
		internal byte[] m_Buffer; // 0x18
		private bool m_changed; // 0x20
		private int m_hash; // 0x24
	
		// Properties
		public AddressFamily Family { get; } // 0x0000000181BF4C50-0x0000000181BF4C90 
		public int Size { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public byte this[int offset] { get => default; } // 0x0000000181BF4C90-0x0000000181BF4D10 
	
		// Constructors
		public SocketAddress(AddressFamily family, int size); // 0x0000000181BF47A0-0x0000000181BF48C0
		internal SocketAddress(IPAddress ipAddress); // 0x0000000181BF48C0-0x0000000181BF4C50
		internal SocketAddress(IPAddress ipaddress, int port); // 0x0000000181BF4740-0x0000000181BF47A0
	
		// Methods
		internal IPAddress GetIPAddress(); // 0x0000000181BF4120-0x0000000181BF43C0
		internal IPEndPoint GetIPEndPoint(); // 0x0000000181BF43C0-0x0000000181BF44C0
		public override bool Equals(object comparand); // 0x0000000181BF3EA0-0x0000000181BF3FE0
		public override int GetHashCode(); // 0x0000000181BF3FE0-0x0000000181BF4120
		public override string ToString(); // 0x0000000181BF44C0-0x0000000181BF4740
	}
}
