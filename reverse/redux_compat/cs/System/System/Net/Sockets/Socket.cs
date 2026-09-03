/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	public class Socket : IDisposable // TypeDefIndex: 9211
	{
		// Fields
		private static readonly EventHandler<SocketAsyncEventArgs> AcceptCompletedHandler; // 0x00
		private static readonly EventHandler<SocketAsyncEventArgs> ReceiveCompletedHandler; // 0x08
		private static readonly EventHandler<SocketAsyncEventArgs> SendCompletedHandler; // 0x10
		private static readonly TaskSocketAsyncEventArgs<Socket> s_rentedSocketSentinel; // 0x18
		private static readonly Int32TaskSocketAsyncEventArgs s_rentedInt32Sentinel; // 0x20
		private static readonly Task<int> s_zeroTask; // 0x28
		private CachedEventArgs _cachedTaskEventArgs; // 0x10
		private static object s_InternalSyncObject; // 0x30
		internal static bool s_SupportsIPv4; // 0x38
		internal static bool s_SupportsIPv6; // 0x39
		internal static bool s_OSSupportsIPv6; // 0x3A
		internal static bool s_Initialized; // 0x3B
		private static bool s_LoggingEnabled; // 0x3C
		private bool is_closed; // 0x18
		private bool is_listening; // 0x19
		private int linger_timeout; // 0x1C
		private AddressFamily addressFamily; // 0x20
		private SocketType socketType; // 0x24
		private ProtocolType protocolType; // 0x28
		internal SafeSocketHandle m_Handle; // 0x30
		internal EndPoint seed_endpoint; // 0x38
		internal SemaphoreSlim ReadSem; // 0x40
		internal SemaphoreSlim WriteSem; // 0x48
		internal bool is_blocking; // 0x50
		internal bool is_bound; // 0x51
		internal bool is_connected; // 0x52
		private int m_IntCleanedUp; // 0x54
		internal bool connect_in_progress; // 0x58
		private static AsyncCallback AcceptAsyncCallback; // 0x40
		private static IOAsyncCallback BeginAcceptCallback; // 0x48
		private static IOAsyncCallback BeginAcceptReceiveCallback; // 0x50
		private static AsyncCallback ConnectAsyncCallback; // 0x58
		private static IOAsyncCallback BeginConnectCallback; // 0x60
		private static AsyncCallback DisconnectAsyncCallback; // 0x68
		private static IOAsyncCallback BeginDisconnectCallback; // 0x70
		private static AsyncCallback ReceiveAsyncCallback; // 0x78
		private static IOAsyncCallback BeginReceiveCallback; // 0x80
		private static IOAsyncCallback BeginReceiveGenericCallback; // 0x88
		private static AsyncCallback ReceiveFromAsyncCallback; // 0x90
		private static IOAsyncCallback BeginReceiveFromCallback; // 0x98
		private static AsyncCallback SendAsyncCallback; // 0xA0
		private static IOAsyncCallback BeginSendGenericCallback; // 0xA8
		private static AsyncCallback SendToAsyncCallback; // 0xB0
	
		// Properties
		public static bool OSSupportsIPv4 { get; } // 0x0000000181B36130-0x0000000181B36190 
		public static bool OSSupportsIPv6 { get; } // 0x0000000181B36190-0x0000000181B361F0 
		public IntPtr Handle { get; } // 0x0000000181A6EA40-0x0000000181A6EA60 
		public AddressFamily AddressFamily { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public SocketType SocketType { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public ProtocolType ProtocolType { get; } // 0x0000000180377930-0x0000000180377940 
		public bool ExclusiveAddressUse { set; } // 0x0000000181B36500-0x0000000181B365A0
		public bool DontFragment { set; } // 0x0000000181B363C0-0x0000000181B36460
		public bool DualMode { get; set; } // 0x0000000181B35D40-0x0000000181B35E10 0x0000000181B36460-0x0000000181B36500
		private bool IsDualMode { get; } // 0x0000000181B35FD0-0x0000000181B36030 
		private static object InternalSyncObject { get; } // 0x0000000181B35F20-0x0000000181B35FD0 
		internal bool CleanedUp { get; } // 0x0000000181B35D30-0x0000000181B35D40 
		public bool IsBound { get; } // 0x00000001802F4040-0x00000001802F4050 
		public EndPoint LocalEndPoint { get; } // 0x0000000181B36030-0x0000000181B36130 
		public bool Blocking { get; set; } // 0x0000000180377920-0x0000000180377930 0x0000000181B362F0-0x0000000181B363C0
		public bool Connected { get; } // 0x00000001818986C0-0x00000001818986D0 
		public bool NoDelay { set; } // 0x0000000181B365A0-0x0000000181B36630
		public EndPoint RemoteEndPoint { get; } // 0x0000000181B361F0-0x0000000181B362F0 
		internal static int FamilyHint { get; } // 0x0000000181B35E10-0x0000000181B35F20 
	
		// Nested types
		private sealed class CachedEventArgs // TypeDefIndex: 9212
		{
			// Fields
			public TaskSocketAsyncEventArgs<Socket> TaskAccept; // 0x10
			public Int32TaskSocketAsyncEventArgs TaskReceive; // 0x18
			public Int32TaskSocketAsyncEventArgs TaskSend; // 0x20
			public AwaitableSocketAsyncEventArgs ValueTaskReceive; // 0x28
			public AwaitableSocketAsyncEventArgs ValueTaskSend; // 0x30
	
			// Constructors
			public CachedEventArgs(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class TaskSocketAsyncEventArgs<TResult> : SocketAsyncEventArgs // TypeDefIndex: 9213
		{
			// Fields
			internal AsyncTaskMethodBuilder<TResult> _builder;
			internal bool _accessed;
	
			// Constructors
			internal TaskSocketAsyncEventArgs();
	
			// Methods
			internal AsyncTaskMethodBuilder<TResult> GetCompletionResponsibility(out bool responsibleForReturningToPool);
		}
	
		private sealed class Int32TaskSocketAsyncEventArgs : TaskSocketAsyncEventArgs<int> // TypeDefIndex: 9214
		{
			// Fields
			internal bool _wrapExceptionsInIOExceptions; // 0xA0
	
			// Constructors
			public Int32TaskSocketAsyncEventArgs(); // 0x0000000181B26D70-0x0000000181B26D80
		}
	
		internal sealed class AwaitableSocketAsyncEventArgs : SocketAsyncEventArgs, IValueTaskSource, IValueTaskSource<int> // TypeDefIndex: 9215
		{
			// Fields
			internal static readonly AwaitableSocketAsyncEventArgs Reserved; // 0x00
			private static readonly Action<object> s_completedSentinel; // 0x08
			private static readonly Action<object> s_availableSentinel; // 0x10
			private Action<object> _continuation; // 0x80
			private ExecutionContext _executionContext; // 0x88
			private object _scheduler; // 0x90
			private short _token; // 0x98
			[CompilerGenerated]
			private bool _WrapExceptionsInIOExceptions_k__BackingField; // 0x9A
	
			// Properties
			public bool WrapExceptionsInIOExceptions { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B26890-0x0000000181B268A0 0x0000000181B268A0-0x0000000181B268B0
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 9216
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static ContextCallback __9__14_0; // 0x08
				public static SendOrPostCallback __9__20_0; // 0x10
	
				// Constructors
				static __c(); // 0x0000000181B3EF20-0x0000000181B3EF90
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _OnCompleted_b__14_0(object runState); // 0x0000000181B3BC70-0x0000000181B3BD00
				internal void _InvokeContinuation_b__20_0(object s); // 0x0000000181B3BBE0-0x0000000181B3BC70
				internal void _.cctor_b__27_0(object state); // 0x0000000181B3C6E0-0x0000000181B3C730
				internal void _.cctor_b__27_1(object state); // 0x0000000181B3C730-0x0000000181B3C780
			}
	
			// Constructors
			public AwaitableSocketAsyncEventArgs(); // 0x0000000181B267B0-0x0000000181B26890
			static AwaitableSocketAsyncEventArgs(); // 0x0000000181B26600-0x0000000181B267B0
	
			// Methods
			public bool Reserve(); // 0x0000000181B26330-0x0000000181B263C0
			private void Release(); // 0x0000000181B262B0-0x0000000181B26330
			protected override void OnCompleted(SocketAsyncEventArgs _); // 0x0000000181B25EF0-0x0000000181B26150
			public ValueTask<int> ReceiveAsync(Socket socket); // 0x0000000181B26150-0x0000000181B262B0
			public ValueTask SendAsyncForNetworkStream(Socket socket); // 0x0000000181B263C0-0x0000000181B264E0
			public ValueTaskSourceStatus GetStatus(short token); // 0x0000000181B25950-0x0000000181B259F0
			public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags); // 0x0000000181B25CE0-0x0000000181B25EF0
			private void InvokeContinuation(Action<object> continuation, object state, bool forceAsync); // 0x0000000181B259F0-0x0000000181B25CE0
			public int GetResult(short token); // 0x0000000181B258F0-0x0000000181B25950
			void IValueTaskSource.GetResult(short token); // 0x0000000181B264E0-0x0000000181B26530
			private void ThrowIncorrectTokenException(); // 0x0000000181B26560-0x0000000181B265B0
			private void ThrowMultipleContinuationsException(); // 0x0000000181B265B0-0x0000000181B26600
			private void ThrowException(SocketError error); // 0x0000000181B26530-0x0000000181B26560
			private Exception CreateException(SocketError error); // 0x0000000181B25800-0x0000000181B258F0
		}
	
		private struct WSABUF // TypeDefIndex: 9217
		{
			// Fields
			public int len; // 0x00
			public IntPtr buf; // 0x08
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9218
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<CachedEventArgs> __9__14_0; // 0x08
			public static Func<AwaitableSocketAsyncEventArgs> __9__14_1; // 0x10
			public static AsyncCallback __9__15_0; // 0x18
			public static AsyncCallback __9__15_1; // 0x20
			public static Func<CachedEventArgs> __9__22_0; // 0x28
			public static Func<AwaitableSocketAsyncEventArgs> __9__22_1; // 0x30
			public static AsyncCallback __9__23_0; // 0x38
			public static AsyncCallback __9__23_1; // 0x40
			public static IOAsyncCallback __9__295_0; // 0x48
			public static IOAsyncCallback __9__297_0; // 0x50
	
			// Constructors
			static __c(); // 0x0000000181B3F000-0x0000000181B3F070
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal CachedEventArgs _ReceiveAsync_b__14_0(); // 0x0000000181B3C1B0-0x0000000181B3C200
			internal AwaitableSocketAsyncEventArgs _ReceiveAsync_b__14_1(); // 0x0000000181B3C200-0x0000000181B3C250
			internal void _ReceiveAsyncApm_b__15_0(IAsyncResult iar); // 0x0000000181B3BD00-0x0000000181B3BE50
			internal void _ReceiveAsyncApm_b__15_1(IAsyncResult iar); // 0x0000000181B3BE50-0x0000000181B3C1B0
			internal CachedEventArgs _SendAsyncForNetworkStream_b__22_0(); // 0x0000000181B3C5C0-0x0000000181B3C610
			internal AwaitableSocketAsyncEventArgs _SendAsyncForNetworkStream_b__22_1(); // 0x0000000181B3C610-0x0000000181B3C660
			internal void _SendAsyncApm_b__23_0(IAsyncResult iar); // 0x0000000181B3C250-0x0000000181B3C3A0
			internal void _SendAsyncApm_b__23_1(IAsyncResult iar); // 0x0000000181B3C3A0-0x0000000181B3C5C0
			internal void _SendAsync_b__295_0(IOAsyncResult s); // 0x0000000181B3C660-0x0000000181B3C6E0
			internal void _BeginSend_b__297_0(IOAsyncResult s); // 0x0000000181B3BAD0-0x0000000181B3BB50
			internal void _.cctor_b__367_0(object s, SocketAsyncEventArgs e); // 0x0000000181B3C780-0x0000000181B3CA40
			internal void _.cctor_b__367_1(object s, SocketAsyncEventArgs e); // 0x0000000181B3DB10-0x0000000181B3DBE0
			internal void _.cctor_b__367_2(object s, SocketAsyncEventArgs e); // 0x0000000181B3DBE0-0x0000000181B3DCB0
			internal void _.cctor_b__367_3(IAsyncResult ares); // 0x0000000181B3DCB0-0x0000000181B3DFD0
			internal void _.cctor_b__367_4(IOAsyncResult ares); // 0x0000000181B3DFD0-0x0000000181B3E0C0
			internal void _.cctor_b__367_5(IOAsyncResult ares); // 0x0000000181B3E0C0-0x0000000181B3E290
			internal void _.cctor_b__367_6(IAsyncResult ares); // 0x0000000181B3E290-0x0000000181B3E4C0
			internal void _.cctor_b__367_7(IOAsyncResult ares); // 0x0000000181B3E4C0-0x0000000181B3E770
			internal void _.cctor_b__367_8(IAsyncResult ares); // 0x0000000181B3E770-0x0000000181B3EA40
			internal void _.cctor_b__367_9(IOAsyncResult ares); // 0x0000000181B3EA40-0x0000000181B3EBF0
			internal void _.cctor_b__367_10(IAsyncResult ares); // 0x0000000181B3CA40-0x0000000181B3CC80
			internal void _.cctor_b__367_11(IOAsyncResult ares); // 0x0000000181B3CC80-0x0000000181B3CF00
			internal void _.cctor_b__367_12(IOAsyncResult ares); // 0x0000000181B3CF00-0x0000000181B3D020
			internal void _.cctor_b__367_13(IAsyncResult ares); // 0x0000000181B3D020-0x0000000181B3D360
			internal void _.cctor_b__367_14(IOAsyncResult ares); // 0x0000000181B3D360-0x0000000181B3D4B0
			internal void _.cctor_b__367_15(IAsyncResult ares); // 0x0000000181B3D4B0-0x0000000181B3D6F0
			internal void _.cctor_b__367_16(IOAsyncResult ares); // 0x0000000181B3D6F0-0x0000000181B3D810
			internal void _.cctor_b__367_17(IAsyncResult ares); // 0x0000000181B3D810-0x0000000181B3DB10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass240_0 // TypeDefIndex: 9219
		{
			// Fields
			public SocketAsyncResult sockares; // 0x10
	
			// Constructors
			public __c__DisplayClass240_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _BeginConnect_b__0(Task<IPAddress[]> t); // 0x0000000181B3EC40-0x0000000181B3ED70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass298_0 // TypeDefIndex: 9220
		{
			// Fields
			public int sent_so_far; // 0x10
	
			// Constructors
			public __c__DisplayClass298_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _BeginSendCallback_b__0(IOAsyncResult s); // 0x0000000181B3ED70-0x0000000181B3EE00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass355_0 // TypeDefIndex: 9221
		{
			// Fields
			public Socket __4__this; // 0x10
			public IOSelectorJob job; // 0x18
			public IntPtr handle; // 0x20
	
			// Constructors
			public __c__DisplayClass355_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _QueueIOSelectorJob_b__0(Task t); // 0x0000000181B3EE00-0x0000000181B3EE50
		}
	
		// Constructors
		public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType); // 0x0000000181B35900-0x0000000181B35C00
		internal Socket(AddressFamily family, SocketType type, ProtocolType proto, SafeSocketHandle safe_handle); // 0x0000000181B35C00-0x0000000181B35D20
		static Socket(); // 0x0000000181B34FA0-0x0000000181B35900
	
		// Methods
		internal ValueTask<int> ReceiveAsync(Memory<byte> buffer, SocketFlags socketFlags, bool fromNetworkStream, CancellationToken cancellationToken); // 0x0000000181B30970-0x0000000181B30DC0
		private Task<int> ReceiveAsyncApm(Memory<byte> buffer, SocketFlags socketFlags); // 0x0000000181B30590-0x0000000181B30970
		internal ValueTask SendAsyncForNetworkStream(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken); // 0x0000000181B32BD0-0x0000000181B32FF0
		private Task<int> SendAsyncApm(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags); // 0x0000000181B327E0-0x0000000181B32BD0
		private static void CompleteAccept(Socket s, TaskSocketAsyncEventArgs<Socket> saea); // 0x0000000181B2D5D0-0x0000000181B2D7D0
		private static void CompleteSendReceive(Socket s, Int32TaskSocketAsyncEventArgs saea, bool isReceive); // 0x0000000181B2D7D0-0x0000000181B2D9A0
		private static Exception GetException(SocketError error, bool wrapExceptionsInIOExceptions = false /* Metadata: 0x0069E356 */); // 0x0000000181B2ED00-0x0000000181B2EDF0
		private void ReturnSocketAsyncEventArgs(Int32TaskSocketAsyncEventArgs saea, bool isReceive); // 0x0000000181B32750-0x0000000181B327E0
		private void ReturnSocketAsyncEventArgs(TaskSocketAsyncEventArgs<Socket> saea); // 0x0000000181B326E0-0x0000000181B32750
		internal bool CanTryAddressFamily(AddressFamily family); // 0x0000000181B2D4C0-0x0000000181B2D4E0
		public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags); // 0x0000000181B337E0-0x0000000181B33850
		public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags); // 0x0000000181B340F0-0x0000000181B34170
		public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags); // 0x0000000181B31A20-0x0000000181B31AA0
		public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags); // 0x0000000181B32410-0x0000000181B32480
		public int IOControl(IOControlCode ioControlCode, byte[] optionInValue, byte[] optionOutValue); // 0x0000000181B2F2C0-0x0000000181B2F460
		public void SetIPProtectionLevel(IPProtectionLevel level); // 0x0000000181B34170-0x0000000181B34290
		public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state); // 0x0000000181B2CFF0-0x0000000181B2D090
		public int EndSend(IAsyncResult asyncResult); // 0x0000000181B2EBE0-0x0000000181B2ED00
		public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state); // 0x0000000181B2C290-0x0000000181B2C490
		public int EndReceive(IAsyncResult asyncResult); // 0x0000000181B2E910-0x0000000181B2EA30
		internal static void InitializeSockets(); // 0x0000000181B2F900-0x0000000181B2FBB0
		public void Dispose(); // 0x0000000181B2E340-0x0000000181B2E3B0
		~Socket(); // 0x0000000181428550-0x00000001814285D0
		internal void InternalShutdown(SocketShutdown how); // 0x0000000181B2FBB0-0x0000000181B2FC30
		internal void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue, bool silent); // 0x0000000181B34550-0x0000000181B346C0
		private void SocketDefaults(); // 0x0000000181B34920-0x0000000181B349F0
		private static IntPtr Socket_icall(AddressFamily family, SocketType type, ProtocolType proto, out int error); // 0x0000000181B34B20-0x0000000181B34B30
		private static SocketAddress LocalEndPoint_internal(SafeSocketHandle safeHandle, int family, out int error); // 0x0000000181B30010-0x0000000181B30150
		private static SocketAddress LocalEndPoint_icall(IntPtr socket, int family, out int error); // 0x0000000181B30000-0x0000000181B30010
		private static void Blocking_internal(SafeSocketHandle safeHandle, bool block, out int error); // 0x0000000181B2D390-0x0000000181B2D4C0
		internal static void Blocking_icall(IntPtr socket, bool block, out int error); // 0x0000000181B2D380-0x0000000181B2D390
		private static SocketAddress RemoteEndPoint_internal(SafeSocketHandle safeHandle, int family, out int error); // 0x0000000181B325A0-0x0000000181B326E0
		private static SocketAddress RemoteEndPoint_icall(IntPtr socket, int family, out int error); // 0x0000000181B32590-0x0000000181B325A0
		public bool Poll(int microSeconds, SelectMode mode); // 0x0000000181B302B0-0x0000000181B30440
		private static bool Poll_internal(SafeSocketHandle safeHandle, SelectMode mode, int timeout, out int error); // 0x0000000181B30160-0x0000000181B302B0
		private static bool Poll_icall(IntPtr socket, SelectMode mode, int timeout, out int error); // 0x0000000181B30150-0x0000000181B30160
		public Socket Accept(); // 0x0000000181B2B5F0-0x0000000181B2B750
		internal void Accept(Socket acceptSocket); // 0x0000000181B2B750-0x0000000181B2B890
		public IAsyncResult BeginAccept(AsyncCallback callback, object state); // 0x0000000181B2B890-0x0000000181B2BA30
		public Socket EndAccept(IAsyncResult asyncResult); // 0x0000000181B2E3B0-0x0000000181B2E4B0
		public Socket EndAccept(out byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult); // 0x0000000181B2E4B0-0x0000000181B2E5C0
		private static SafeSocketHandle Accept_internal(SafeSocketHandle safeHandle, out int error, bool blocking); // 0x0000000181B2B4A0-0x0000000181B2B5F0
		private static IntPtr Accept_icall(IntPtr sock, out int error, bool blocking); // 0x0000000181B2B490-0x0000000181B2B4A0
		public void Bind(EndPoint localEP); // 0x0000000181B2D1D0-0x0000000181B2D380
		private static void Bind_internal(SafeSocketHandle safeHandle, SocketAddress sa, out int error); // 0x0000000181B2D0A0-0x0000000181B2D1D0
		private static void Bind_icall(IntPtr sock, SocketAddress sa, out int error); // 0x0000000181B2D090-0x0000000181B2D0A0
		public void Listen(int backlog); // 0x0000000181B2FEF0-0x0000000181B30000
		private static void Listen_internal(SafeSocketHandle safeHandle, int backlog, out int error); // 0x0000000181B2FDD0-0x0000000181B2FEF0
		private static void Listen_icall(IntPtr sock, int backlog, out int error); // 0x0000000181B2FDC0-0x0000000181B2FDD0
		public void Connect(IPAddress address, int port); // 0x0000000181B2DED0-0x0000000181B2DF50
		public void Connect(EndPoint remoteEP); // 0x0000000181B2DAD0-0x0000000181B2DED0
		public IAsyncResult BeginConnect(string host, int port, AsyncCallback callback, object state); // 0x0000000181B2BBB0-0x0000000181B2BE90
		public IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state); // 0x0000000181B2BA30-0x0000000181B2BBB0
		private static bool BeginMConnect(SocketAsyncResult sockares); // 0x0000000181B2BE90-0x0000000181B2C080
		private static bool BeginSConnect(SocketAsyncResult sockares); // 0x0000000181B2C490-0x0000000181B2CA00
		public void EndConnect(IAsyncResult asyncResult); // 0x0000000181B2E5C0-0x0000000181B2E680
		private static void Connect_internal(SafeSocketHandle safeHandle, SocketAddress sa, out int error, bool blocking); // 0x0000000181B2D9B0-0x0000000181B2DAD0
		private static void Connect_icall(IntPtr sock, SocketAddress sa, out int error, bool blocking); // 0x0000000181B2D9A0-0x0000000181B2D9B0
		public void Disconnect(bool reuseSocket); // 0x0000000181B2E090-0x0000000181B2E1A0
		public void EndDisconnect(IAsyncResult asyncResult); // 0x0000000181B2E680-0x0000000181B2E740
		private static void Disconnect_internal(SafeSocketHandle safeHandle, bool reuse, out int error); // 0x0000000181B2DF60-0x0000000181B2E090
		private static void Disconnect_icall(IntPtr sock, bool reuse, out int error); // 0x0000000181B2DF50-0x0000000181B2DF60
		public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B322A0-0x0000000181B32410
		private int Receive(Memory<byte> buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B31AA0-0x0000000181B31CB0
		[CLSCompliant(false)]
		public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B31CB0-0x0000000181B322A0
		public int Receive(Span<byte> buffer, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B31930-0x0000000181B31A20
		public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B33850-0x0000000181B338E0
		public bool ReceiveAsync(SocketAsyncEventArgs e); // 0x0000000181B30DC0-0x0000000181B31270
		public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state); // 0x0000000181B2C080-0x0000000181B2C290
		public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode); // 0x0000000181B2E820-0x0000000181B2E910
		private static unsafe int Receive_internal(SafeSocketHandle safeHandle, WSABUF* bufarray, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B317F0-0x0000000181B31930
		private static unsafe int Receive_array_icall(IntPtr sock, WSABUF* bufarray, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B31690-0x0000000181B316A0
		private static unsafe int Receive_internal(SafeSocketHandle safeHandle, byte* buffer, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B316B0-0x0000000181B317F0
		private static unsafe int Receive_icall(IntPtr sock, byte* buffer, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B316A0-0x0000000181B316B0
		private int ReceiveFrom(Memory<byte> buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, out SocketError errorCode); // 0x0000000181B313E0-0x0000000181B31690
		private int EndReceiveFrom_internal(SocketAsyncResult sockares, SocketAsyncEventArgs ares); // 0x0000000181B2E740-0x0000000181B2E820
		private static unsafe int ReceiveFrom_internal(SafeSocketHandle safeHandle, byte* buffer, int count, SocketFlags flags, ref SocketAddress sockaddr, out int error, bool blocking); // 0x0000000181B31280-0x0000000181B313E0
		private static unsafe int ReceiveFrom_icall(IntPtr sock, byte* buffer, int count, SocketFlags flags, ref SocketAddress sockaddr, out int error, bool blocking); // 0x0000000181B31270-0x0000000181B31280
		public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B33F20-0x0000000181B340F0
		[CLSCompliant(false)]
		public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode); // 0x0000000181B338E0-0x0000000181B33F20
		public bool SendAsync(SocketAsyncEventArgs e); // 0x0000000181B32FF0-0x0000000181B33540
		public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state); // 0x0000000181B2CD60-0x0000000181B2CFF0
		private static void BeginSendCallback(SocketAsyncResult sockares, int sent_so_far); // 0x0000000181B2CA00-0x0000000181B2CD60
		public int EndSend(IAsyncResult asyncResult, out SocketError errorCode); // 0x0000000181B2EAF0-0x0000000181B2EBE0
		private static unsafe int Send_internal(SafeSocketHandle safeHandle, WSABUF* bufarray, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B336A0-0x0000000181B337E0
		private static unsafe int Send_array_icall(IntPtr sock, WSABUF* bufarray, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B33540-0x0000000181B33550
		private static unsafe int Send_internal(SafeSocketHandle safeHandle, byte* buffer, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B33560-0x0000000181B336A0
		private static unsafe int Send_icall(IntPtr sock, byte* buffer, int count, SocketFlags flags, out int error, bool blocking); // 0x0000000181B33550-0x0000000181B33560
		public int EndSendTo(IAsyncResult asyncResult); // 0x0000000181B2EA30-0x0000000181B2EAF0
		public object GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName); // 0x0000000181B2EDF0-0x0000000181B2F000
		private static void GetSocketOption_obj_internal(SafeSocketHandle safeHandle, SocketOptionLevel level, SocketOptionName name, out object obj_val, out int error); // 0x0000000181B2F010-0x0000000181B2F160
		private static void GetSocketOption_obj_icall(IntPtr socket, SocketOptionLevel level, SocketOptionName name, out object obj_val, out int error); // 0x0000000181B2F000-0x0000000181B2F010
		public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue); // 0x0000000181B346C0-0x0000000181B346E0
		public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue); // 0x0000000181B34410-0x0000000181B34550
		private static void SetSocketOption_internal(SafeSocketHandle safeHandle, SocketOptionLevel level, SocketOptionName name, object obj_val, byte[] byte_val, int int_val, out int error); // 0x0000000181B342A0-0x0000000181B34410
		private static void SetSocketOption_icall(IntPtr socket, SocketOptionLevel level, SocketOptionName name, object obj_val, byte[] byte_val, int int_val, out int error); // 0x0000000181B34290-0x0000000181B342A0
		public int IOControl(int ioControlCode, byte[] optionInValue, byte[] optionOutValue); // 0x0000000181B2F460-0x0000000181B2F5F0
		private static int IOControl_internal(SafeSocketHandle safeHandle, int ioctl_code, byte[] input, byte[] output, out int error); // 0x0000000181B2F170-0x0000000181B2F2C0
		private static int IOControl_icall(IntPtr sock, int ioctl_code, byte[] input, byte[] output, out int error); // 0x0000000181B2F160-0x0000000181B2F170
		public void Close(); // 0x0000000181B2D4F0-0x0000000181B2D560
		public void Close(int timeout); // 0x0000000181B2D560-0x0000000181B2D5D0
		internal static void Close_icall(IntPtr socket, out int error); // 0x0000000181B2D4E0-0x0000000181B2D4F0
		public void Shutdown(SocketShutdown how); // 0x0000000181B34810-0x0000000181B34920
		private static void Shutdown_internal(SafeSocketHandle safeHandle, SocketShutdown how, out int error); // 0x0000000181B346F0-0x0000000181B34810
		internal static void Shutdown_icall(IntPtr socket, SocketShutdown how, out int error); // 0x0000000181B346E0-0x0000000181B346F0
		protected virtual void Dispose(bool disposing); // 0x0000000181B2E1A0-0x0000000181B2E340
		private void Linger(IntPtr handle); // 0x0000000181B2FC80-0x0000000181B2FDC0
		private void ThrowIfDisposedAndClosed(); // 0x0000000181B34D50-0x0000000181B34DE0
		private void ThrowIfBufferNull(byte[] buffer); // 0x0000000181B34B30-0x0000000181B34B90
		private void ThrowIfBufferOutOfRange(byte[] buffer, int offset, int size); // 0x0000000181B34B90-0x0000000181B34D50
		private void ThrowIfUdp(); // 0x0000000181B34DE0-0x0000000181B34E40
		private SocketAsyncResult ValidateEndIAsyncResult(IAsyncResult ares, string methodName, string argName); // 0x0000000181B34E40-0x0000000181B34FA0
		private void QueueIOSelectorJob(SemaphoreSlim sem, IntPtr handle, IOSelectorJob job); // 0x0000000181B30440-0x0000000181B30590
		private void InitSocketAsyncEventArgs(SocketAsyncEventArgs e, AsyncCallback callback, object state, SocketOperation operation); // 0x0000000181B2F5F0-0x0000000181B2F900
		private SocketAsyncOperation SocketOperationToSocketAsyncOperation(SocketOperation op); // 0x0000000181B349F0-0x0000000181B34B20
		private IPEndPoint RemapIPEndPoint(IPEndPoint input); // 0x0000000181B32480-0x0000000181B32590
		internal static void cancel_blocking_socket_operation(Thread thread); // 0x0000000181B35D20-0x0000000181B35D30
		private static bool IsProtocolSupported_internal(NetworkInterfaceComponent networkInterface); // 0x000000018150C960-0x000000018150C970
		private static bool IsProtocolSupported(NetworkInterfaceComponent networkInterface); // 0x0000000181B2FC30-0x0000000181B2FC80
	}
}
