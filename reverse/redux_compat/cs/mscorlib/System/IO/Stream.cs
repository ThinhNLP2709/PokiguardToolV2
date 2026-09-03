/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	public abstract class Stream : MarshalByRefObject, IDisposable // TypeDefIndex: 3685
	{
		// Fields
		public static readonly Stream Null; // 0x00
		[NonSerialized]
		private ReadWriteTask _activeReadWriteTask; // 0x18
		[NonSerialized]
		private SemaphoreSlim _asyncActiveSemaphore; // 0x20
	
		// Properties
		public abstract bool CanRead { get; }
		public abstract bool CanSeek { get; }
		public virtual bool CanTimeout { get; } // 0x00000001802E7840-0x00000001802E7850 
		public abstract bool CanWrite { get; }
		public abstract long Length { get; }
		public abstract long Position { get; set; }
		public virtual int ReadTimeout { get; set; } // 0x00000001815CFF70-0x00000001815CFFC0 0x00000001815D0010-0x00000001815D0060
		public virtual int WriteTimeout { get; set; } // 0x00000001815CFFC0-0x00000001815D0010 0x00000001815D0060-0x00000001815D00B0
	
		// Nested types
		private struct ReadWriteParameters // TypeDefIndex: 3686
		{
			// Fields
			internal byte[] Buffer; // 0x00
			internal int Offset; // 0x08
			internal int Count; // 0x0C
		}
	
		private sealed class ReadWriteTask : Task<int>, ITaskCompletionAction // TypeDefIndex: 3687
		{
			// Fields
			internal readonly bool _isRead; // 0x58
			internal readonly bool _apm; // 0x59
			internal Stream _stream; // 0x60
			internal byte[] _buffer; // 0x68
			internal readonly int _offset; // 0x70
			internal readonly int _count; // 0x74
			private AsyncCallback _callback; // 0x78
			private ExecutionContext _context; // 0x80
			private static ContextCallback s_invokeAsyncCallback; // 0x00
	
			// Properties
			bool ITaskCompletionAction.InvokeMayRunArbitraryCode { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public ReadWriteTask(bool isRead, bool apm, Func<object, int> function, object state, Stream stream, byte[] buffer, int offset, int count, AsyncCallback callback); // 0x00000001815CD260-0x00000001815CD3A0
	
			// Methods
			internal void ClearBeginState(); // 0x00000001815CD040-0x00000001815CD080
			private static void InvokeAsyncCallback(object completedTask); // 0x00000001815CD080-0x00000001815CD110
			void ITaskCompletionAction.Invoke(Task completingTask); // 0x00000001815CD110-0x00000001815CD260
		}
	
		private sealed class NullStream : Stream // TypeDefIndex: 3688
		{
			// Fields
			private static readonly Task<int> s_zeroTask; // 0x00
	
			// Properties
			public override bool CanRead { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override bool CanWrite { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override bool CanSeek { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override long Length { get; } // 0x00000001802E7860-0x00000001802E7870 
			public override long Position { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
	
			// Constructors
			internal NullStream(); // 0x00000001815C85C0-0x00000001815C85F0
			static NullStream(); // 0x00000001815C8530-0x00000001815C85C0
	
			// Methods
			protected override void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
			public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
			public override Task FlushAsync(CancellationToken cancellationToken); // 0x00000001815C81C0-0x00000001815C82C0
			public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001815C7DC0-0x00000001815C7E50
			public override int EndRead(IAsyncResult asyncResult); // 0x00000001815C7EE0-0x00000001815C8050
			public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001815C7E50-0x00000001815C7EE0
			public override void EndWrite(IAsyncResult asyncResult); // 0x00000001815C8050-0x00000001815C81C0
			public override int Read(byte[] buffer, int offset, int count); // 0x00000001802E7860-0x00000001802E7870
			public override int Read(Span<byte> buffer); // 0x00000001802E7860-0x00000001802E7870
			public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815C82C0-0x00000001815C8310
			public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815C8310-0x00000001815C8350
			public override int ReadByte(); // 0x00000001815418D0-0x00000001815418E0
			public override void Write(byte[] buffer, int offset, int count); // 0x00000001802E76C0-0x00000001802E76D0
			public override void Write(ReadOnlySpan<byte> buffer); // 0x00000001802E76C0-0x00000001802E76D0
			public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815C8440-0x00000001815C8530
			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815C8350-0x00000001815C8440
			public override void WriteByte(byte value); // 0x00000001802E76C0-0x00000001802E76D0
			public override long Seek(long offset, SeekOrigin origin); // 0x00000001802E7860-0x00000001802E7870
			public override void SetLength(long length); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		private sealed class SynchronousAsyncResult : IAsyncResult // TypeDefIndex: 3689
		{
			// Fields
			private readonly object _stateObject; // 0x10
			private readonly bool _isWrite; // 0x18
			private ManualResetEvent _waitHandle; // 0x20
			private ExceptionDispatchInfo _exceptionInfo; // 0x28
			private bool _endXxxCalled; // 0x30
			private int _bytesRead; // 0x34
	
			// Properties
			public bool IsCompleted { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public WaitHandle AsyncWaitHandle { get; } // 0x00000001815D1C30-0x00000001815D1D30 
			public object AsyncState { get; } // 0x0000000180377550-0x0000000180377560 
			public bool CompletedSynchronously { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3690
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<ManualResetEvent> __9__12_0; // 0x08
	
				// Constructors
				static __c(); // 0x00000001815D5290-0x00000001815D5300
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal ManualResetEvent _get_AsyncWaitHandle_b__12_0(); // 0x00000001815D5110-0x00000001815D5140
			}
	
			// Constructors
			internal SynchronousAsyncResult(int bytesRead, object asyncStateObject); // 0x00000001815D1BB0-0x00000001815D1BF0
			internal SynchronousAsyncResult(object asyncStateObject); // 0x00000001815D1BF0-0x00000001815D1C30
			internal SynchronousAsyncResult(Exception ex, object asyncStateObject, bool isWrite); // 0x00000001815D1B40-0x00000001815D1BB0
	
			// Methods
			internal void ThrowIfError(); // 0x00000001815D1B20-0x00000001815D1B40
			internal static int EndRead(IAsyncResult asyncResult); // 0x00000001815CDE80-0x00000001815CDF90
			internal static void EndWrite(IAsyncResult asyncResult); // 0x00000001815CDF90-0x00000001815CE090
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3691
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<SemaphoreSlim> __9__4_0; // 0x08
			public static Action<object> __9__37_0; // 0x10
			public static Func<object, int> __9__40_0; // 0x18
			public static Func<Stream, ReadWriteParameters, AsyncCallback, object, IAsyncResult> __9__45_0; // 0x20
			public static Func<Stream, IAsyncResult, int> __9__45_1; // 0x28
			public static Func<object, int> __9__48_0; // 0x30
			public static Action<Task, object> __9__49_0; // 0x38
			public static Func<Stream, ReadWriteParameters, AsyncCallback, object, IAsyncResult> __9__58_0; // 0x40
			public static Func<Stream, IAsyncResult, VoidTaskResult> __9__58_1; // 0x48
	
			// Constructors
			static __c(); // 0x00000001815D5220-0x00000001815D5290
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal SemaphoreSlim _EnsureAsyncActiveSemaphoreInitialized_b__4_0(); // 0x00000001815D4CE0-0x00000001815D4D30
			internal void _FlushAsync_b__37_0(object state); // 0x00000001815D4D30-0x00000001815D4D90
			internal int _BeginReadInternal_b__40_0(object _p0_); // 0x00000001815D4A30-0x00000001815D4B90
			internal IAsyncResult _BeginEndReadAsync_b__45_0(Stream stream, ReadWriteParameters args, AsyncCallback callback, object state); // 0x00000001815D48F0-0x00000001815D4950
			internal int _BeginEndReadAsync_b__45_1(Stream stream, IAsyncResult asyncResult); // 0x00000001815D4950-0x00000001815D4990
			internal int _BeginWriteInternal_b__48_0(object _p0_); // 0x00000001815D4B90-0x00000001815D4CE0
			internal void _RunReadWriteTaskWhenReady_b__49_0(Task t, object state); // 0x00000001815D4EE0-0x00000001815D4F50
			internal IAsyncResult _BeginEndWriteAsync_b__58_0(Stream stream, ReadWriteParameters args, AsyncCallback callback, object state); // 0x00000001815D4990-0x00000001815D49F0
			internal VoidTaskResult _BeginEndWriteAsync_b__58_1(Stream stream, IAsyncResult asyncResult); // 0x00000001815D49F0-0x00000001815D4A30
		}
	
		[CompilerGenerated]
		private struct _FinishWriteAsync_d__57 : IAsyncStateMachine // TypeDefIndex: 3692
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Task writeTask; // 0x20
			public byte[] localBuffer; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001815D3C10-0x00000001815D3EB0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815D3EB0-0x00000001815D3F10
		}
	
		[CompilerGenerated]
		private struct __ReadAsync_g__FinishReadAsync_44_0_d : IAsyncStateMachine // TypeDefIndex: 3693
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncValueTaskMethodBuilder<int> __t__builder; // 0x08
			public Task<int> readTask; // 0x28
			public byte[] localBuffer; // 0x30
			public Memory<byte> localDestination; // 0x38
			private ConfiguredTaskAwaitable<int> __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001815D45B0-0x00000001815D48A0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815D48A0-0x00000001815D48F0
		}
	
		// Constructors
		protected Stream(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Stream(); // 0x00000001815CFEF0-0x00000001815CFF70
	
		// Methods
		internal SemaphoreSlim EnsureAsyncActiveSemaphoreInitialized(); // 0x00000001815CE4F0-0x00000001815CE5F0
		public virtual void Close(); // 0x00000001815CE090-0x00000001815CE100
		public void Dispose(); // 0x0000000181475250-0x0000000181475270
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract void Flush();
		public virtual Task FlushAsync(CancellationToken cancellationToken); // 0x00000001815CE720-0x00000001815CE930
		public virtual IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001815CD9E0-0x00000001815CDA20
		internal IAsyncResult BeginReadInternal(byte[] buffer, int offset, int count, AsyncCallback callback, object state, bool serializeAsynchronously, bool apm); // 0x00000001815CD7C0-0x00000001815CD9E0
		public virtual int EndRead(IAsyncResult asyncResult); // 0x00000001815CE100-0x00000001815CE300
		public Task<int> ReadAsync(byte[] buffer, int offset, int count); // 0x00000001815CEF00-0x00000001815CEFA0
		public virtual Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815CE930-0x00000001815CEBC0
		public virtual ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815CEBC0-0x00000001815CEF00
		private Task<int> BeginEndReadAsync(byte[] buffer, int offset, int count); // 0x00000001815CD3A0-0x00000001815CD5B0
		public virtual IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001815CDC40-0x00000001815CDC80
		internal IAsyncResult BeginWriteInternal(byte[] buffer, int offset, int count, AsyncCallback callback, object state, bool serializeAsynchronously, bool apm); // 0x00000001815CDA20-0x00000001815CDC40
		private void RunReadWriteTaskWhenReady(Task asyncWaiter, ReadWriteTask readWriteTask); // 0x00000001815CF280-0x00000001815CF440
		private void RunReadWriteTask(ReadWriteTask readWriteTask); // 0x00000001815CF440-0x00000001815CF510
		private void FinishTrackingAsyncOperation(); // 0x00000001815CE5F0-0x00000001815CE630
		public virtual void EndWrite(IAsyncResult asyncResult); // 0x00000001815CE300-0x00000001815CE4F0
		public Task WriteAsync(byte[] buffer, int offset, int count); // 0x00000001815CF9A0-0x00000001815CFA40
		public virtual Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815CFA40-0x00000001815CFCC0
		public virtual ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815CF670-0x00000001815CF9A0
		private async Task FinishWriteAsync(Task writeTask, byte[] localBuffer); // 0x00000001815CE630-0x00000001815CE720
		private Task BeginEndWriteAsync(byte[] buffer, int offset, int count); // 0x00000001815CD5B0-0x00000001815CD7C0
		public abstract long Seek(long offset, SeekOrigin origin);
		public abstract void SetLength(long value);
		public abstract int Read(byte[] buffer, int offset, int count);
		public virtual int Read(Span<byte> buffer); // 0x00000001815CF040-0x00000001815CF280
		public virtual int ReadByte(); // 0x00000001815CEFA0-0x00000001815CF040
		public abstract void Write(byte[] buffer, int offset, int count);
		public virtual void Write(ReadOnlySpan<byte> buffer); // 0x00000001815CFD50-0x00000001815CFEF0
		public virtual void WriteByte(byte value); // 0x00000001815CFCC0-0x00000001815CFD50
		internal IAsyncResult BlockingBeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001815CDC80-0x00000001815CDD80
		internal static int BlockingEndRead(IAsyncResult asyncResult); // 0x00000001815CDE80-0x00000001815CDF90
		internal IAsyncResult BlockingBeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001815CDD80-0x00000001815CDE80
		internal static void BlockingEndWrite(IAsyncResult asyncResult); // 0x00000001815CDF90-0x00000001815CE090
		private bool HasOverriddenBeginEndRead(); // 0x00000001802E7990-0x00000001802E79A0
		private bool HasOverriddenBeginEndWrite(); // 0x00000001802E7990-0x00000001802E79A0
		[CompilerGenerated]
		internal static async ValueTask<int> _ReadAsync_g__FinishReadAsync_44_0(Task<int> readTask, byte[] localBuffer, Memory<byte> localDestination); // 0x00000001815CF510-0x00000001815CF670
	}
}
