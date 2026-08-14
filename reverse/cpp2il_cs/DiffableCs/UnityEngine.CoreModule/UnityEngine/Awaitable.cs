namespace UnityEngine;

[AsyncMethodBuilder(typeof(AwaitableAsyncMethodBuilder))]
[NativeHeader("Runtime/Mono/AsyncOperationAwaitable.h")]
[NativeHeader("Runtime/Mono/Awaitable.h")]
[NativeHeader("Runtime/Mono/DelayedCallAwaitable.h")]
public class Awaitable : IEnumerator
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Awaitable> <>9__64_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal ObjectPool<Awaitable> <.cctor>b__64_0() { }

		internal Awaitable <.cctor>b__64_1() { }

	}

	private struct AwaitableAndFrameIndex
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly Awaitable <Awaitable>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly int <FrameIndex>k__BackingField; //Field offset: 0x8

		public Awaitable Awaitable
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
		}

		public int FrameIndex
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
		}

		[CompilerGenerated]
		[IsReadOnly]
		public Awaitable get_Awaitable() { }

		[CompilerGenerated]
		[IsReadOnly]
		public int get_FrameIndex() { }

	}

	[ExcludeFromDocs]
	internal struct AwaitableAsyncMethodBuilder
	{
		private interface IStateMachineBox : IDisposable
		{

		}

		private IStateMachineBox _stateMachineBox; //Field offset: 0x0
		private Awaitable _resultingCoroutine; //Field offset: 0x8

	}

	[IsReadOnly]
	private struct AwaitableHandle
	{
		public static AwaitableHandle ManagedHandle; //Field offset: 0x0
		public static AwaitableHandle NullHandle; //Field offset: 0x8
		private readonly IntPtr _handle; //Field offset: 0x0

		public bool IsManaged
		{
			 get { } //Length: 90
		}

		public bool IsNull
		{
			 get { } //Length: 8
		}

		private static AwaitableHandle() { }

		public AwaitableHandle(IntPtr handle) { }

		public bool get_IsManaged() { }

		public bool get_IsNull() { }

		public static IntPtr op_Implicit(AwaitableHandle handle) { }

	}

	private class DoubleBufferedAwaitableList
	{
		private List<AwaitableAndFrameIndex> _awaitables; //Field offset: 0x10
		private List<AwaitableAndFrameIndex> _scratch; //Field offset: 0x18

		public DoubleBufferedAwaitableList() { }

		public void Clear() { }

		public void SwapAndComplete() { }

	}

	private static readonly ThreadLocal<ObjectPool`1<Awaitable>> _pool; //Field offset: 0x0
	private static bool _nextFrameAndEndOfFrameWiredUp; //Field offset: 0x8
	private static CancellationTokenRegistration _nextFrameAndEndOfFrameWiredUpCTRegistration; //Field offset: 0x10
	private static readonly DoubleBufferedAwaitableList _nextFrameAwaitables; //Field offset: 0x28
	private static readonly DoubleBufferedAwaitableList _endOfFrameAwaitables; //Field offset: 0x30
	private static SynchronizationContext _synchronizationContext; //Field offset: 0x38
	private SpinLock _spinLock; //Field offset: 0x10
	private AwaitableHandle _handle; //Field offset: 0x18
	private ExceptionDispatchInfo _exceptionToRethrow; //Field offset: 0x20
	private bool _managedAwaitableDone; //Field offset: 0x28
	private Action _continuation; //Field offset: 0x30
	private Nullable<CancellationTokenRegistration> _cancelTokenRegistration; //Field offset: 0x38
	private DoubleBufferedAwaitableList _managedCompletionQueue; //Field offset: 0x58

	public bool IsCompleted
	{
		 get { } //Length: 441
	}

	private bool IsCompletedNoLock
	{
		private get { } //Length: 269
	}

	internal bool IsDettachedOrCompleted
	{
		internal get { } //Length: 502
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 3
	}

	private static Awaitable() { }

	private Awaitable() { }

	private AwaitableHandle CheckPointerValidity() { }

	public bool get_IsCompleted() { }

	private bool get_IsCompletedNoLock() { }

	internal bool get_IsDettachedOrCompleted() { }

	[FreeFunction("Scripting::Awaitables::IsCompleted", IsThreadSafe = True)]
	private static int IsNativeAwaitableCompleted(IntPtr nativeAwaitable) { }

	[RequiredByNativeCode]
	private static void OnDelayedCallManagerCleared() { }

	[RequiredByNativeCode]
	private static void OnEndOfFrame() { }

	[RequiredByNativeCode]
	private static void OnUpdate() { }

	internal void PropagateExceptionAndRelease() { }

	internal void RaiseManagedCompletion() { }

	[FreeFunction("Scripting::Awaitables::Release", IsThreadSafe = True)]
	private static void ReleaseNativeAwaitable(IntPtr nativeAwaitable) { }

	[RequiredByNativeCode(GenerateProxy = True)]
	private void RunContinuation() { }

	[RequiredByNativeCode(GenerateProxy = True)]
	private void SetExceptionFromNative(Exception ex) { }

	internal static void SetSynchronizationContext(SynchronizationContext synchronizationContext) { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

}

