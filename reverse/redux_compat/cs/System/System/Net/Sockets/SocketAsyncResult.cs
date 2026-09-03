/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	internal sealed class SocketAsyncResult : IOAsyncResult // TypeDefIndex: 9241
	{
		// Fields
		public Socket socket; // 0x30
		public SocketOperation operation; // 0x38
		private Exception DelayedException; // 0x40
		public EndPoint EndPoint; // 0x48
		public Memory<byte> Buffer; // 0x50
		public int Offset; // 0x60
		public int Size; // 0x64
		public SocketFlags SockFlags; // 0x68
		public Socket AcceptSocket; // 0x70
		public IPAddress[] Addresses; // 0x78
		public int Port; // 0x80
		public IList<ArraySegment<byte>> Buffers; // 0x88
		public bool ReuseSocket; // 0x90
		public int CurrentAddress; // 0x94
		public Socket AcceptedSocket; // 0x98
		public int Total; // 0xA0
		internal int error; // 0xA4
		public int EndCalled; // 0xA8
	
		// Properties
		public IntPtr Handle { get; } // 0x0000000181B2B300-0x0000000181B2B330 
		public SocketError ErrorCode { get; } // 0x0000000181B2B270-0x0000000181B2B300 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9242
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static WaitCallback __9__27_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181B3EF90-0x0000000181B3F000
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Complete_b__27_0(object state); // 0x0000000181B3BB50-0x0000000181B3BBE0
		}
	
		// Constructors
		public SocketAsyncResult(); // 0x00000001802F4070-0x00000001802F4080
		public SocketAsyncResult(Socket socket, AsyncCallback callback, object state, SocketOperation operation); // 0x0000000181B2B220-0x0000000181B2B270
	
		// Methods
		public void Init(Socket socket, AsyncCallback callback, object state, SocketOperation operation); // 0x0000000181B2B120-0x0000000181B2B220
		public void CheckIfThrowDelayedException(); // 0x0000000181B2AD50-0x0000000181B2AE00
		internal override void CompleteDisposed(); // 0x0000000181B2AE00-0x0000000181B2AE10
		public void Complete(); // 0x0000000181B2AF10-0x0000000181B2B120
		public void Complete(bool synch); // 0x0000000181B2AE10-0x0000000181B2AE20
		public void Complete(int total); // 0x0000000181B2AED0-0x0000000181B2AEE0
		public void Complete(Exception e, bool synch); // 0x0000000181B2AE50-0x0000000181B2AE90
		public void Complete(Exception e); // 0x0000000181B2AE20-0x0000000181B2AE50
		public void Complete(Socket s); // 0x0000000181B2AEE0-0x0000000181B2AF10
		public void Complete(Socket s, int total); // 0x0000000181B2AE90-0x0000000181B2AED0
	}
}
