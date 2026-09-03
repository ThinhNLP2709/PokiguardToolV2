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
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	public class TcpClient : IDisposable // TypeDefIndex: 9237
	{
		// Fields
		private Socket m_ClientSocket; // 0x10
		private bool m_Active; // 0x18
		private NetworkStream m_DataStream; // 0x20
		private AddressFamily m_Family; // 0x28
		private bool m_CleanedUp; // 0x2C
	
		// Properties
		public Socket Client { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		public TcpClient(); // 0x0000000181B38BE0-0x0000000181B38CA0
		public TcpClient(AddressFamily family); // 0x0000000181B38CF0-0x0000000181B38E60
		public TcpClient(string hostname, int port); // 0x0000000181B389C0-0x0000000181B38BE0
		internal TcpClient(Socket acceptedSocket); // 0x0000000181B38CA0-0x0000000181B38CF0
	
		// Methods
		public void Connect(string hostname, int port); // 0x0000000181B38050-0x0000000181B386B0
		public void Connect(IPEndPoint remoteEP); // 0x0000000181B37F40-0x0000000181B38050
		public IAsyncResult BeginConnect(string host, int port, AsyncCallback requestCallback, object state); // 0x0000000181B37CF0-0x0000000181B37D70
		public void EndConnect(IAsyncResult asyncResult); // 0x0000000181B38800-0x0000000181B38850
		public Task ConnectAsync(string host, int port); // 0x0000000181B37DC0-0x0000000181B37F40
		public NetworkStream GetStream(); // 0x0000000181B38850-0x0000000181B389C0
		public void Close(); // 0x0000000181B37D70-0x0000000181B37DC0
		protected virtual void Dispose(bool disposing); // 0x0000000181B386D0-0x0000000181B38800
		public void Dispose(); // 0x0000000181B386B0-0x0000000181B386D0
		~TcpClient(); // 0x0000000181428550-0x00000001814285D0
		private void initialize(); // 0x0000000181B38E60-0x0000000181B38EF0
	}
}
