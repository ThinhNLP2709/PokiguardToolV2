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
	internal class WebResponseStream : WebConnectionStream // TypeDefIndex: 9182
	{
		// Fields
		private WebReadStream innerStream; // 0x58
		private bool nextReadCalled; // 0x60
		private bool bufferedEntireContent; // 0x61
		private WebCompletionSource pendingRead; // 0x68
		private object locker; // 0x70
		private int nestedRead; // 0x78
		private bool read_eof; // 0x7C
		[CompilerGenerated]
		private readonly WebRequestStream _RequestStream_k__BackingField; // 0x80
		[CompilerGenerated]
		private WebHeaderCollection _Headers_k__BackingField; // 0x88
		[CompilerGenerated]
		private HttpStatusCode _StatusCode_k__BackingField; // 0x90
		[CompilerGenerated]
		private string _StatusDescription_k__BackingField; // 0x98
		[CompilerGenerated]
		private Version _Version_k__BackingField; // 0xA0
		[CompilerGenerated]
		private bool _KeepAlive_k__BackingField; // 0xA8
		[CompilerGenerated]
		private bool _ChunkedRead_k__BackingField; // 0xA9
	
		// Properties
		public WebRequestStream RequestStream { [CompilerGenerated] get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public WebHeaderCollection Headers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
		public HttpStatusCode StatusCode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018169CBC0-0x000000018169CBD0 0x000000018170C9F0-0x000000018170CA00
		public string StatusDescription { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		public Version Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public bool KeepAlive { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181773D00-0x0000000181773D10 0x0000000181773D30-0x0000000181773D40
		public override bool CanRead { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool CanWrite { get; } // 0x00000001802E7840-0x00000001802E7850 
		private bool ChunkedRead { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181773CF0-0x0000000181773D00 0x0000000181773D20-0x0000000181773D30
		private bool ExpectContent { get; } // 0x0000000181B40AD0-0x0000000181B40B60 
	
		// Nested types
		[CompilerGenerated]
		private struct _ReadAsync_d__40 : IAsyncStateMachine // TypeDefIndex: 9183
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public byte[] buffer; // 0x28
			public int offset; // 0x30
			public int count; // 0x34
			public WebResponseStream __4__this; // 0x38
			private WebCompletionSource _completion_5__2; // 0x40
			private int _nbytes_5__3; // 0x48
			private Exception _throwMe_5__4; // 0x50
			private ConfiguredTaskAwaitable<object> __u__1; // 0x58
			private ConfiguredTaskAwaitable<int> __u__2; // 0x68
	
			// Methods
			private void MoveNext(); // 0x0000000181B3B160-0x0000000181B3BA70
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B3BA70-0x0000000181B3BAD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass41_0 // TypeDefIndex: 9184
		{
			// Fields
			public WebResponseStream __4__this; // 0x10
			public byte[] buffer; // 0x18
			public int offset; // 0x20
			public int size; // 0x24
	
			// Constructors
			public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Task<int> _ProcessRead_b__0(CancellationToken ct); // 0x0000000181B3EE50-0x0000000181B3EEA0
			internal void _ProcessRead_b__1(); // 0x0000000181B3EEA0-0x0000000181B3EEF0
			internal bool _ProcessRead_b__2(); // 0x0000000181B3EEF0-0x0000000181B3EF20
		}
	
		[CompilerGenerated]
		private struct _ReadAllAsyncInner_d__47 : IAsyncStateMachine // TypeDefIndex: 9185
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<byte[]> __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public WebResponseStream __4__this; // 0x28
			private long _maximumSize_5__2; // 0x30
			private MemoryStream _ms_5__3; // 0x38
			private byte[] _buffer_5__4; // 0x40
			private ConfiguredTaskAwaitable<int> __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181B39DE0-0x0000000181B3A3B0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B3A3B0-0x0000000181B3A410
		}
	
		[CompilerGenerated]
		private struct _ReadAllAsync_d__48 : IAsyncStateMachine // TypeDefIndex: 9186
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebResponseStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public bool resending; // 0x30
			private WebCompletionSource _completion_5__2; // 0x38
			private CancellationTokenSource _timeoutCts_5__3; // 0x40
			private Task _timeoutTask_5__4; // 0x48
			private ConfiguredTaskAwaitable<Task> __u__1; // 0x50
			private ConfiguredTaskAwaitable<byte[]> __u__2; // 0x60
	
			// Methods
			private void MoveNext(); // 0x0000000181B3A410-0x0000000181B3B100
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B3B100-0x0000000181B3B160
		}
	
		[CompilerGenerated]
		private struct _InitReadAsync_d__52 : IAsyncStateMachine // TypeDefIndex: 9187
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebResponseStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private BufferOffsetSize _buffer_5__2; // 0x30
			private ReadState _state_5__3; // 0x38
			private int _position_5__4; // 0x3C
			private ConfiguredTaskAwaitable<int> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181B39750-0x0000000181B39D80
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B39D80-0x0000000181B39DE0
		}
	
		// Constructors
		public WebResponseStream(WebRequestStream request); // 0x0000000181B40A40-0x0000000181B40AD0
	
		// Methods
		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181B407C0-0x0000000181B40900
		private Task<int> ProcessRead(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B40310-0x0000000181B405A0
		protected override bool TryReadFromBufferedContent(byte[] buffer, int offset, int count, out int result); // 0x0000000181B40900-0x0000000181B409C0
		private void Initialize(BufferOffsetSize buffer); // 0x0000000181B3FD60-0x0000000181B40310
		private async Task<byte[]> ReadAllAsyncInner(CancellationToken cancellationToken); // 0x0000000181B405A0-0x0000000181B406B0
		internal async Task ReadAllAsync(bool resending, CancellationToken cancellationToken); // 0x0000000181B406B0-0x0000000181B407C0
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181B409C0-0x0000000181B40A40
		protected override void Close_internal(ref bool disposed); // 0x0000000181B3F160-0x0000000181B3F200
		private WebException GetReadException(WebExceptionStatus status, Exception error, string where); // 0x0000000181B3F200-0x0000000181B3F490
		internal async Task InitReadAsync(CancellationToken cancellationToken); // 0x0000000181B3FC60-0x0000000181B3FD60
		private bool GetResponse(BufferOffsetSize buffer, ref int pos, ref ReadState state); // 0x0000000181B3F490-0x0000000181B3FC60
	}
}
