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
	[Serializable]
	public class IPEndPoint : EndPoint // TypeDefIndex: 9006
	{
		// Fields
		private IPAddress _address; // 0x10
		private int _port; // 0x18
		internal static IPEndPoint Any; // 0x00
		internal static IPEndPoint IPv6Any; // 0x08
	
		// Properties
		public override AddressFamily AddressFamily { get; } // 0x0000000181BF2EB0-0x0000000181BF2EE0 
		public IPAddress Address { get; } // 0x0000000180377550-0x0000000180377560 
		public int Port { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public IPEndPoint(IPAddress address, int port); // 0x0000000181BF2DC0-0x0000000181BF2EB0
		static IPEndPoint(); // 0x0000000181BF2BF0-0x0000000181BF2DC0
	
		// Methods
		public override string ToString(); // 0x0000000181BF2B30-0x0000000181BF2BF0
		public override SocketAddress Serialize(); // 0x0000000181BF2A90-0x0000000181BF2B30
		public override EndPoint Create(SocketAddress socketAddress); // 0x0000000181BF2660-0x0000000181BF29A0
		public override bool Equals(object comparand); // 0x0000000181BF29A0-0x0000000181BF2A50
		public override int GetHashCode(); // 0x0000000181BF2A50-0x0000000181BF2A90
	}
}
