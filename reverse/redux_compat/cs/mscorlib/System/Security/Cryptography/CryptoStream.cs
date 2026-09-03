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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	public class CryptoStream : Stream, IDisposable // TypeDefIndex: 2769
	{
		// Fields
		private readonly Stream _stream; // 0x28
		private readonly ICryptoTransform _transform; // 0x30
		private readonly CryptoStreamMode _transformMode; // 0x38
		private byte[] _inputBuffer; // 0x40
		private int _inputBufferIndex; // 0x48
		private int _inputBlockSize; // 0x4C
		private byte[] _outputBuffer; // 0x50
		private int _outputBufferIndex; // 0x58
		private int _outputBlockSize; // 0x5C
		private bool _canRead; // 0x60
		private bool _canWrite; // 0x61
		private bool _finalBlockTransformed; // 0x62
		private SemaphoreSlim _lazyAsyncActiveSemaphore; // 0x68
		private readonly bool _leaveOpen; // 0x70
	
		// Properties
		public override bool CanRead { get; } // 0x000000018033D4F0-0x000000018033D500 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanWrite { get; } // 0x00000001804EFDB0-0x00000001804EFDC0 
		public override long Length { get; } // 0x0000000181476640-0x0000000181476690 
		public override long Position { get; set; } // 0x0000000181476690-0x00000001814766E0 0x00000001814766E0-0x0000000181476730
		public bool HasFlushedFinalBlock { get; } // 0x0000000181476630-0x0000000181476640 
		private SemaphoreSlim AsyncActiveSemaphore { get; } // 0x0000000181476530-0x0000000181476630 
	
		// Nested types
		[CompilerGenerated]
		private struct _ReadAsyncInternal_d__37 : IAsyncStateMachine // TypeDefIndex: 2770
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public CryptoStream __4__this; // 0x20
			public byte[] buffer; // 0x28
			public int offset; // 0x30
			public int count; // 0x34
			public CancellationToken cancellationToken; // 0x38
			private SemaphoreSlim _semaphore_5__2; // 0x40
			private ForceAsyncAwaiter __u__1; // 0x48
			private TaskAwaiter<int> __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181486B40-0x00000001814870F0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001814870F0-0x0000000181487150
		}
	
		[CompilerGenerated]
		private struct _ReadAsyncCore_d__42 : IAsyncStateMachine // TypeDefIndex: 2771
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public int count; // 0x20
			public int offset; // 0x24
			public CryptoStream __4__this; // 0x28
			public byte[] buffer; // 0x30
			public bool useAsync; // 0x38
			public CancellationToken cancellationToken; // 0x40
			private int _bytesToDeliver_5__2; // 0x48
			private int _currentOutputIndex_5__3; // 0x4C
			private int _numWholeBlocksInBytes_5__4; // 0x50
			private byte[] _tempInputBuffer_5__5; // 0x58
			private byte[] _tempOutputBuffer_5__6; // 0x60
			private ValueTaskAwaiter<int> __u__1; // 0x68
	
			// Methods
			private void MoveNext(); // 0x0000000181485A50-0x0000000181486AE0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181486AE0-0x0000000181486B40
		}
	
		[CompilerGenerated]
		private struct _WriteAsyncInternal_d__46 : IAsyncStateMachine // TypeDefIndex: 2772
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CryptoStream __4__this; // 0x20
			public byte[] buffer; // 0x28
			public int offset; // 0x30
			public int count; // 0x34
			public CancellationToken cancellationToken; // 0x38
			private SemaphoreSlim _semaphore_5__2; // 0x40
			private ForceAsyncAwaiter __u__1; // 0x48
			private TaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x000000018149C070-0x000000018149C530
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x000000018149C530-0x000000018149C590
		}
	
		[CompilerGenerated]
		private struct _WriteAsyncCore_d__49 : IAsyncStateMachine // TypeDefIndex: 2773
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public int count; // 0x20
			public int offset; // 0x24
			public CryptoStream __4__this; // 0x28
			public byte[] buffer; // 0x30
			public bool useAsync; // 0x38
			public CancellationToken cancellationToken; // 0x40
			private int _bytesToWrite_5__2; // 0x48
			private int _currentInputIndex_5__3; // 0x4C
			private int _numOutputBytes_5__4; // 0x50
			private ValueTaskAwaiter __u__1; // 0x58
			private int _numWholeBlocksInBytes_5__5; // 0x68
			private byte[] _tempOutputBuffer_5__6; // 0x70
	
			// Methods
			private void MoveNext(); // 0x000000018149B030-0x000000018149C010
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x000000018149C010-0x000000018149C070
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2774
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<SemaphoreSlim> __9__54_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018149AFC0-0x000000018149B030
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal SemaphoreSlim _get_AsyncActiveSemaphore_b__54_0(); // 0x000000018149AF70-0x000000018149AFC0
		}
	
		// Constructors
		public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode); // 0x0000000181476510-0x0000000181476530
		public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode, bool leaveOpen); // 0x0000000181476260-0x0000000181476510
	
		// Methods
		public void FlushFinalBlock(); // 0x00000001814754F0-0x00000001814756E0
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x0000000181475370-0x00000001814754F0
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181475C60-0x0000000181475CB0
		public override void SetLength(long value); // 0x0000000181475CB0-0x0000000181475D00
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181475A10-0x0000000181475B50
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181474D90-0x0000000181474E40
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181475320-0x0000000181475360
		private async Task<int> ReadAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001814758E0-0x0000000181475A10
		public override int ReadByte(); // 0x0000000181475B50-0x0000000181475BD0
		public override void WriteByte(byte value); // 0x00000001814760B0-0x0000000181476100
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000181475BD0-0x0000000181475C60
		private void CheckReadArguments(byte[] buffer, int offset, int count); // 0x0000000181474EF0-0x00000001814750A0
		private async Task<int> ReadAsyncCore(byte[] buffer, int offset, int count, CancellationToken cancellationToken, bool useAsync); // 0x00000001814757A0-0x00000001814758E0
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181475F60-0x00000001814760B0
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181474E40-0x0000000181474EF0
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181475360-0x0000000181475370
		private async Task WriteAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181475E30-0x0000000181475F60
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000181476100-0x0000000181476260
		private void CheckWriteArguments(byte[] buffer, int offset, int count); // 0x00000001814750A0-0x0000000181475250
		private async Task WriteAsyncCore(byte[] buffer, int offset, int count, CancellationToken cancellationToken, bool useAsync); // 0x0000000181475D00-0x0000000181475E30
		public void Clear(); // 0x0000000181475250-0x0000000181475270
		protected override void Dispose(bool disposing); // 0x0000000181475270-0x0000000181475320
		private void InitializeBuffer(); // 0x00000001814756E0-0x00000001814757A0
	}
}
