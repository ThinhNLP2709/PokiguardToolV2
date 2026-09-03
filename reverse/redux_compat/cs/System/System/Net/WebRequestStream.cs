/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class WebRequestStream : WebConnectionStream // TypeDefIndex: 9173
	{
		// Fields
		private static byte[] crlf; // 0x00
		private MemoryStream writeBuffer; // 0x58
		private bool requestWritten; // 0x60
		private bool allowBuffering; // 0x61
		private bool sendChunked; // 0x62
		private WebCompletionSource pendingWrite; // 0x68
		private long totalWritten; // 0x70
		private byte[] headers; // 0x78
		private bool headersSent; // 0x80
		private int completeRequestWritten; // 0x84
		private int chunkTrailerWritten; // 0x88
		[CompilerGenerated]
		private readonly Stream _InnerStream_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly bool _KeepAlive_k__BackingField; // 0x98
	
		// Properties
		internal Stream InnerStream { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public bool KeepAlive { [CompilerGenerated] get; } // 0x0000000180665210-0x0000000180665220 
		public override bool CanRead { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanWrite { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal bool HasWriteBuffer { get; } // 0x0000000181B24CC0-0x0000000181B24CF0 
		internal int WriteBufferLength { get; } // 0x0000000181B24CF0-0x0000000181B255B0 
	
		// Nested types
		[CompilerGenerated]
		private struct _FinishWriting_d__31 : IAsyncStateMachine // TypeDefIndex: 9174
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181B15F10-0x0000000181B16260
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B16260-0x0000000181B162C0
		}
	
		[CompilerGenerated]
		private struct _WriteAsyncInner_d__33 : IAsyncStateMachine // TypeDefIndex: 9175
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public byte[] buffer; // 0x28
			public int offset; // 0x30
			public int size; // 0x34
			public CancellationToken cancellationToken; // 0x38
			public WebCompletionSource completion; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
			private TaskAwaiter __u__2; // 0x58
	
			// Methods
			private void MoveNext(); // 0x0000000181B1DAC0-0x0000000181B1E0B0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1E0B0-0x0000000181B1E110
		}
	
		[CompilerGenerated]
		private struct _ProcessWrite_d__34 : IAsyncStateMachine // TypeDefIndex: 9176
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public int size; // 0x30
			public byte[] buffer; // 0x38
			public int offset; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181B19A80-0x0000000181B1A060
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1A060-0x0000000181B1A0C0
		}
	
		[CompilerGenerated]
		private struct _Initialize_d__36 : IAsyncStateMachine // TypeDefIndex: 9177
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
			private TaskAwaiter __u__2; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181B172C0-0x0000000181B17620
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B17620-0x0000000181B17680
		}
	
		[CompilerGenerated]
		private struct _SetHeadersAsync_d__37 : IAsyncStateMachine // TypeDefIndex: 9178
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public bool setInternalLength; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181B1C770-0x0000000181B1CE00
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1CE00-0x0000000181B1CE60
		}
	
		[CompilerGenerated]
		private struct _WriteRequestAsync_d__38 : IAsyncStateMachine // TypeDefIndex: 9179
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private BufferOffsetSize _buffer_5__2; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
			private TaskAwaiter __u__2; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181B1EC30-0x0000000181B1F2D0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1F2D0-0x0000000181B1F330
		}
	
		[CompilerGenerated]
		private struct _WriteChunkTrailer_inner_d__39 : IAsyncStateMachine // TypeDefIndex: 9180
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181B1E970-0x0000000181B1EBD0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1EBD0-0x0000000181B1EC30
		}
	
		[CompilerGenerated]
		private struct _WriteChunkTrailer_d__40 : IAsyncStateMachine // TypeDefIndex: 9181
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebRequestStream __4__this; // 0x20
			private CancellationTokenSource _cts_5__2; // 0x28
			private Task _timeoutTask_5__3; // 0x30
			private ConfiguredTaskAwaitable<Task> __u__1; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181B1E110-0x0000000181B1E910
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1E910-0x0000000181B1E970
		}
	
		// Constructors
		public WebRequestStream(WebConnection connection, WebOperation operation, Stream stream, WebConnectionTunnel tunnel); // 0x0000000181B24AA0-0x0000000181B24CC0
		static WebRequestStream(); // 0x0000000181B24A10-0x0000000181B24AA0
	
		// Methods
		internal BufferOffsetSize GetWriteBuffer(); // 0x0000000181B23D20-0x0000000181B23E40
		private async Task FinishWriting(CancellationToken cancellationToken); // 0x0000000181B23C30-0x0000000181B23D20
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181B24380-0x0000000181B24740
		private async Task WriteAsyncInner(byte[] buffer, int offset, int size, WebCompletionSource completion, CancellationToken cancellationToken); // 0x0000000181B24250-0x0000000181B24380
		private async Task ProcessWrite(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B23F40-0x0000000181B24070
		private void CheckWriteOverflow(long contentLength, long totalWritten, long size); // 0x0000000181B238F0-0x0000000181B239A0
		internal async Task Initialize(CancellationToken cancellationToken); // 0x0000000181B23E40-0x0000000181B23F40
		private async Task SetHeadersAsync(bool setInternalLength, CancellationToken cancellationToken); // 0x0000000181B24100-0x0000000181B24210
		internal async Task WriteRequestAsync(CancellationToken cancellationToken); // 0x0000000181B24910-0x0000000181B24A10
		private async Task WriteChunkTrailer_inner(CancellationToken cancellationToken); // 0x0000000181B24740-0x0000000181B24830
		private async Task WriteChunkTrailer(); // 0x0000000181B24830-0x0000000181B24910
		internal void KillBuffer(); // 0x000000018043AE10-0x000000018043AE30
		public override Task<int> ReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B24070-0x0000000181B24100
		protected override bool TryReadFromBufferedContent(byte[] buffer, int offset, int count, out int result); // 0x0000000181B24210-0x0000000181B24250
		protected override void Close_internal(ref bool disposed); // 0x0000000181B239A0-0x0000000181B23C30
	}
}
