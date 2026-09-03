/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	public class TcpListener // TypeDefIndex: 9238
	{
		// Fields
		private IPEndPoint m_ServerSocketEP; // 0x10
		private Socket m_ServerSocket; // 0x18
		private bool m_Active; // 0x20
		private bool m_ExclusiveAddressUse; // 0x21
	
		// Properties
		public Socket Server { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public TcpListener(IPAddress localaddr, int port); // 0x0000000181B39530-0x0000000181B39710
	
		// Methods
		public void Start(); // 0x0000000181B39000-0x0000000181B39010
		public void Start(int backlog); // 0x0000000181B39010-0x0000000181B393C0
		public void Stop(); // 0x0000000181B393C0-0x0000000181B39530
		public TcpClient AcceptTcpClient(); // 0x0000000181B38EF0-0x0000000181B39000
	}
}
