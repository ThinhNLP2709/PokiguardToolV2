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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	public class SocketAsyncEventArgs : EventArgs, IDisposable // TypeDefIndex: 9240
	{
		// Fields
		private bool disposed; // 0x10
		internal int in_progress; // 0x14
		private EndPoint remote_ep; // 0x18
		private Socket current_socket; // 0x20
		internal SocketAsyncResult socket_async_result; // 0x28
		[CompilerGenerated]
		private Socket _AcceptSocket_k__BackingField; // 0x30
		[CompilerGenerated]
		private int _BytesTransferred_k__BackingField; // 0x38
		[CompilerGenerated]
		private SocketAsyncOperation _LastOperation_k__BackingField; // 0x3C
		[CompilerGenerated]
		private SocketError _SocketError_k__BackingField; // 0x40
		[CompilerGenerated]
		private SocketFlags _SocketFlags_k__BackingField; // 0x44
		[CompilerGenerated]
		private object _UserToken_k__BackingField; // 0x48
		[CompilerGenerated]
		private EventHandler<SocketAsyncEventArgs> Completed; // 0x50
		private Memory<byte> _buffer; // 0x58
		private int _offset; // 0x68
		private int _count; // 0x6C
		private bool _bufferIsExplicitArray; // 0x70
		private IList<ArraySegment<byte>> _bufferList; // 0x78
	
		// Properties
		public Socket AcceptSocket { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public int BytesTransferred { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		private SocketAsyncOperation LastOperation { [CompilerGenerated] set; } // 0x00000001805D5550-0x00000001805D5560
		public EndPoint RemoteEndPoint { set; } // 0x00000001802FAF70-0x00000001802FAF80
		public SocketError SocketError { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
		public SocketFlags SocketFlags { [CompilerGenerated] set; } // 0x000000018033ED00-0x000000018033ED10
		public object UserToken { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		internal Socket CurrentSocket { get; } // 0x00000001802F8630-0x00000001802F8640 
		public Memory<byte> MemoryBuffer { get; } // 0x0000000181B2AD40-0x0000000181B2AD50 
		public int Offset { get; } // 0x00000001803002C0-0x00000001803002D0 
		public int Count { get; } // 0x0000000180C55C40-0x0000000180C55C50 
		public IList<ArraySegment<byte>> BufferList { get; } // 0x000000018033D4E0-0x000000018033D4F0 
	
		// Constructors
		internal SocketAsyncEventArgs(bool flowExecutionContext); // 0x0000000181B2ACB0-0x0000000181B2AD40
	
		// Methods
		~SocketAsyncEventArgs(); // 0x0000000181B2AA80-0x0000000181B2AAE0
		private void Dispose(bool disposing); // 0x0000000181B2AA70-0x0000000181B2AA80
		public void Dispose(); // 0x0000000181B2AA10-0x0000000181B2AA70
		internal void SetBytesTransferred(int value); // 0x00000001805D5570-0x00000001805D5580
		internal void SetCurrentSocket(Socket socket); // 0x000000018033E830-0x000000018033E840
		internal void SetLastOperation(SocketAsyncOperation op); // 0x0000000181B2ABE0-0x0000000181B2ACB0
		internal void Complete_internal(); // 0x0000000181B2A9D0-0x0000000181B2AA10
		protected virtual void OnCompleted(SocketAsyncEventArgs e); // 0x0000000181B2AAE0-0x0000000181B2AB10
		public void SetBuffer(Memory<byte> buffer); // 0x0000000181B2AB10-0x0000000181B2ABE0
	}
}
