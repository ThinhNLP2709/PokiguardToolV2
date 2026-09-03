/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal abstract class MobileAuthenticatedStream : AuthenticatedStream, IDisposable // TypeDefIndex: 8557
	{
		// Fields
		private MobileTlsContext xobileTlsContext; // 0x38
		private ExceptionDispatchInfo lastException; // 0x40
		private AsyncProtocolRequest asyncHandshakeRequest; // 0x48
		private AsyncProtocolRequest asyncReadRequest; // 0x50
		private AsyncProtocolRequest asyncWriteRequest; // 0x58
		private BufferOffsetSize2 readBuffer; // 0x60
		private BufferOffsetSize2 writeBuffer; // 0x68
		private object ioLock; // 0x70
		private int closeRequested; // 0x78
		private bool shutdown; // 0x7C
		private Operation operation; // 0x80
		private static int uniqueNameInteger; // 0x00
		[CompilerGenerated]
		private readonly SslStream _SslStream_k__BackingField; // 0x88
		[CompilerGenerated]
		private readonly MonoTlsSettings _Settings_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly MobileTlsProvider _Provider_k__BackingField; // 0x98
		[CompilerGenerated]
		private string _TargetHost_k__BackingField; // 0xA0
		private static int nextId; // 0x04
		internal readonly int ID; // 0xA8
	
		// Properties
		public SslStream SslStream { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public MonoTlsSettings Settings { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public MobileTlsProvider Provider { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		internal string TargetHost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public override bool IsAuthenticated { get; } // 0x0000000181813DB0-0x0000000181813E90 
		public X509Certificate LocalCertificate { get; } // 0x0000000181813EC0-0x0000000181813FE0 
		public X509Certificate InternalLocalCertificate { get; } // 0x0000000181813CB0-0x0000000181813DB0 
		public override bool CanRead { get; } // 0x0000000181813BC0-0x0000000181813C10 
		public override bool CanTimeout { get; } // 0x0000000181813C10-0x0000000181813C40 
		public override bool CanWrite { get; } // 0x0000000181813C40-0x0000000181813CB0 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override long Length { get; } // 0x0000000181813E90-0x0000000181813EC0 
		public override long Position { get; set; } // 0x0000000181813FE0-0x0000000181814010 0x0000000181814070-0x00000001818140B0
		public override int ReadTimeout { get; set; } // 0x0000000181814010-0x0000000181814040 0x00000001818140B0-0x00000001818140E0
		public override int WriteTimeout { get; set; } // 0x0000000181814040-0x0000000181814070 0x00000001818140E0-0x0000000181814110
	
		// Nested types
		private enum Operation // TypeDefIndex: 8558
		{
			None = 0,
			Handshake = 1,
			Authenticated = 2,
			Renegotiate = 3,
			Read = 4,
			Write = 5,
			Close = 6
		}
	
		private enum OperationType // TypeDefIndex: 8559
		{
			Read = 0,
			Write = 1,
			Renegotiate = 2,
			Shutdown = 3
		}
	
		[CompilerGenerated]
		private struct _ProcessAuthentication_d__48 : IAsyncStateMachine // TypeDefIndex: 8560
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public MonoSslAuthenticationOptions options; // 0x20
			public MobileAuthenticatedStream __4__this; // 0x28
			public bool runSynchronously; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable<AsyncProtocolResult> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181821950-0x00000001818222A0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001818222A0-0x0000000181822300
		}
	
		[CompilerGenerated]
		private struct _StartOperation_d__57 : IAsyncStateMachine // TypeDefIndex: 8561
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public MobileAuthenticatedStream __4__this; // 0x20
			public OperationType type; // 0x28
			public AsyncProtocolRequest asyncRequest; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable<AsyncProtocolResult> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181822DE0-0x00000001818235B0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001818235B0-0x0000000181823610
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 8562
		{
			// Fields
			public MobileAuthenticatedStream __4__this; // 0x10
			public int len; // 0x18
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _InnerRead_b__0(); // 0x00000001818237E0-0x0000000181823840
		}
	
		[CompilerGenerated]
		private struct _InnerRead_d__66 : IAsyncStateMachine // TypeDefIndex: 8563
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public MobileAuthenticatedStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public int requestedSize; // 0x30
			public bool sync; // 0x34
			private ConfiguredTaskAwaitable<int> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181821180-0x00000001818215D0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001818215D0-0x0000000181821630
		}
	
		[CompilerGenerated]
		private struct _InnerWrite_d__67 : IAsyncStateMachine // TypeDefIndex: 8564
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public MobileAuthenticatedStream __4__this; // 0x28
			public bool sync; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181821630-0x00000001818218F0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001818218F0-0x0000000181821950
		}
	
		// Constructors
		public MobileAuthenticatedStream(Stream innerStream, bool leaveInnerStreamOpen, SslStream owner, MonoTlsSettings settings, MobileTlsProvider provider); // 0x0000000181813A30-0x0000000181813BC0
		static MobileAuthenticatedStream(); // 0x00000001818139F0-0x0000000181813A30
	
		// Methods
		internal void CheckThrow(bool authSuccessCheck, bool shutdownCheck = false /* Metadata: 0x0069DCDF */); // 0x0000000181811D20-0x0000000181811E20
		internal static Exception GetSSPIException(Exception e); // 0x00000001818122B0-0x0000000181812430
		internal static Exception GetIOException(Exception e, string message); // 0x0000000181812090-0x0000000181812210
		internal static Exception GetInternalError(); // 0x0000000181812210-0x0000000181812260
		internal static Exception GetInvalidNestedCallException(); // 0x0000000181812260-0x00000001818122B0
		internal ExceptionDispatchInfo SetException(Exception e); // 0x0000000181813640-0x00000001818136A0
		public void AuthenticateAsClient(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation); // 0x0000000181811900-0x0000000181811B10
		public void AuthenticateAsServer(X509Certificate serverCertificate, bool clientCertificateRequired, SslProtocols enabledSslProtocols, bool checkCertificateRevocation); // 0x0000000181811B10-0x0000000181811D20
		public Task AuthenticateAsClientAsync(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation); // 0x0000000181811770-0x0000000181811900
		private async Task ProcessAuthentication(bool runSynchronously, MonoSslAuthenticationOptions options, CancellationToken cancellationToken); // 0x0000000181812D00-0x0000000181812E30
		protected abstract MobileTlsContext CreateContext(MonoSslAuthenticationOptions options);
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000181813510-0x0000000181813600
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000181813900-0x00000001818139F0
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181813460-0x0000000181813510
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181813850-0x0000000181813900
		private async Task<int> StartOperation(OperationType type, AsyncProtocolRequest asyncRequest, CancellationToken cancellationToken); // 0x00000001818136D0-0x0000000181813800
		internal int InternalRead(byte[] buffer, int offset, int size, out bool outWantMore); // 0x00000001818127D0-0x00000001818129A0
		private ValueTuple<int, bool> InternalRead(AsyncProtocolRequest asyncRequest, BufferOffsetSize internalBuffer, byte[] buffer, int offset, int size); // 0x0000000181812670-0x00000001818127D0
		internal bool InternalWrite(byte[] buffer, int offset, int size); // 0x0000000181812B60-0x0000000181812D00
		private bool InternalWrite(AsyncProtocolRequest asyncRequest, BufferOffsetSize2 internalBuffer, byte[] buffer, int offset, int size); // 0x00000001818129A0-0x0000000181812B60
		internal async Task<int> InnerRead(bool sync, int requestedSize, CancellationToken cancellationToken); // 0x0000000181812430-0x0000000181812560
		internal async Task InnerWrite(bool sync, CancellationToken cancellationToken); // 0x0000000181812560-0x0000000181812670
		internal AsyncOperationStatus ProcessHandshake(AsyncOperationStatus status, bool renegotiate); // 0x0000000181812E30-0x00000001818131A0
		internal ValueTuple<int, bool> ProcessRead(BufferOffsetSize userBuffer); // 0x00000001818131A0-0x0000000181813300
		internal ValueTuple<int, bool> ProcessWrite(BufferOffsetSize userBuffer); // 0x0000000181813300-0x0000000181813460
		protected override void Dispose(bool disposing); // 0x0000000181811E20-0x0000000181812060
		public override void Flush(); // 0x0000000181812060-0x0000000181812090
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181813600-0x0000000181813640
		public override void SetLength(long value); // 0x00000001818136A0-0x00000001818136D0
		[CompilerGenerated]
		private void _InnerWrite_b__67_0(); // 0x0000000181813800-0x0000000181813850
	}
}
