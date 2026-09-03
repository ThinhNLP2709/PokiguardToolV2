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
	internal abstract class WebReadStream : Stream // TypeDefIndex: 9171
	{
		// Fields
		[CompilerGenerated]
		private readonly WebOperation _Operation_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly Stream _InnerStream_k__BackingField; // 0x30
		private bool disposed; // 0x38
	
		// Properties
		public WebOperation Operation { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		protected Stream InnerStream { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
		public override long Length { get; } // 0x0000000181B23830-0x0000000181B23870 
		public override long Position { get; set; } // 0x0000000181B23870-0x0000000181B238B0 0x0000000181B238B0-0x0000000181B238F0
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanRead { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool CanWrite { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		[CompilerGenerated]
		private struct _ReadAsync_d__28 : IAsyncStateMachine // TypeDefIndex: 9172
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public WebReadStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public byte[] buffer; // 0x30
			public int offset; // 0x38
			public int size; // 0x3C
			private ConfiguredTaskAwaitable<int> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181B1A0C0-0x0000000181B1A5A0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1A5A0-0x0000000181B1A600
		}
	
		// Constructors
		public WebReadStream(WebOperation operation, Stream innerStream); // 0x0000000181B237C0-0x0000000181B23830
	
		// Methods
		public override void SetLength(long value); // 0x0000000181B23740-0x0000000181B23780
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181B23700-0x0000000181B23740
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000181B23780-0x0000000181B237C0
		public override void Flush(); // 0x0000000181B23170-0x0000000181B231B0
		protected Exception GetException(Exception e); // 0x0000000181B231B0-0x0000000181B23320
		public override int Read(byte[] buffer, int offset, int size); // 0x0000000181B23450-0x0000000181B23700
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback cb, object state); // 0x0000000181B22DD0-0x0000000181B23050
		public override int EndRead(IAsyncResult r); // 0x0000000181B230A0-0x0000000181B23170
		public sealed override async Task<int> ReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B23320-0x0000000181B23450
		protected abstract Task<int> ProcessReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken);
		internal virtual Task FinishReading(CancellationToken cancellationToken); // 0x0000000181B11530-0x0000000181B11650
		protected override void Dispose(bool disposing); // 0x0000000181B23050-0x0000000181B230A0
	}
}
