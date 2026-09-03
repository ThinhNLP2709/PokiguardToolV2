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
	public abstract class EndPoint // TypeDefIndex: 9033
	{
		// Properties
		public virtual AddressFamily AddressFamily { get; } // 0x0000000181BE1090-0x0000000181BE10C0 
	
		// Constructors
		protected EndPoint(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual SocketAddress Serialize(); // 0x0000000181BE1060-0x0000000181BE1090
		public virtual EndPoint Create(SocketAddress socketAddress); // 0x0000000181BE1030-0x0000000181BE1060
	}
}
