namespace UnityEngine.ResourceManagement.AsyncOperations;

public abstract class AsyncOperationBase : IAsyncOperation
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass60_0
	{
		public Action<AsyncOperationHandle> value; //Field offset: 0x0

		public <>c__DisplayClass60_0() { }

		internal void <add_CompletedTypeless>b__0(AsyncOperationHandle<TObject> s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass61_0
	{
		public Action<AsyncOperationHandle> value; //Field offset: 0x0

		public <>c__DisplayClass61_0() { }

		internal void <remove_CompletedTypeless>b__0(AsyncOperationHandle<TObject> s) { }

	}

	[CompilerGenerated]
	private TObject <Result>k__BackingField; //Field offset: 0x0
	private bool m_InDeferredCallbackQueue; //Field offset: 0x0
	private TaskCompletionSource<Object> m_taskCompletionSourceTypeless; //Field offset: 0x0
	private TaskCompletionSource<TObject> m_taskCompletionSource; //Field offset: 0x0
	[CompilerGenerated]
	private bool <IsRunning>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Action Executed; //Field offset: 0x0
	protected private bool HasExecuted; //Field offset: 0x0
	private Action<AsyncOperationHandle> m_dependencyCompleteAction; //Field offset: 0x0
	private Action<IAsyncOperation> m_OnDestroyAction; //Field offset: 0x0
	private DelegateList<AsyncOperationHandle`1<TObject>> m_CompletedActionT; //Field offset: 0x0
	private DelegateList<AsyncOperationHandle> m_DestroyedAction; //Field offset: 0x0
	internal int m_Version; //Field offset: 0x0
	internal ResourceManager m_RM; //Field offset: 0x0
	internal Exception m_Error; //Field offset: 0x0
	internal AsyncOperationStatus m_Status; //Field offset: 0x0
	private int m_referenceCount; //Field offset: 0x0
	private DelegateList<Single> m_UpdateCallbacks; //Field offset: 0x0
	private Action<Single> m_UpdateCallback; //Field offset: 0x0

	internal event Action<AsyncOperationHandle`1<TObject>> Completed
	{
		internal add { } //Length: 177
		internal remove { } //Length: 33
	}

	internal event Action<AsyncOperationHandle> CompletedTypeless
	{
		internal add { } //Length: 384
		internal remove { } //Length: 287
	}

	internal event Action<AsyncOperationHandle> Destroyed
	{
		internal add { } //Length: 130
		internal remove { } //Length: 79
	}

	internal event Action Executed
	{
		[CompilerGenerated]
		internal add { } //Length: 158
		[CompilerGenerated]
		internal remove { } //Length: 158
	}

	private override event Action<AsyncOperationHandle> UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.CompletedTypeless
	{
		private add { } //Length: 399
		private remove { } //Length: 302
	}

	private override event Action<AsyncOperationHandle> UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.Destroyed
	{
		private add { } //Length: 130
		private remove { } //Length: 79
	}

	internal bool CompletedEventHasListeners
	{
		internal get { } //Length: 52
	}

	internal object Current
	{
		internal get { } //Length: 3
	}

	protected override string DebugName
	{
		 get { } //Length: 38
	}

	internal bool DestroyedEventHasListeners
	{
		internal get { } //Length: 79
	}

	internal AsyncOperationHandle<TObject> Handle
	{
		internal get { } //Length: 53
	}

	internal bool IsDone
	{
		internal get { } //Length: 17
	}

	public internal override bool IsRunning
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal Action<IAsyncOperation> OnDestroy
	{
		internal set { } //Length: 13
	}

	internal Exception OperationException
	{
		internal get { } //Length: 5
		private set { } //Length: 351
	}

	internal float PercentComplete
	{
		internal get { } //Length: 53
	}

	protected override float Progress
	{
		 get { } //Length: 4
	}

	protected private int ReferenceCount
	{
		private get { } //Length: 4
	}

	public TObject Result
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	internal AsyncOperationStatus Status
	{
		internal get { } //Length: 4
	}

	internal Task<TObject> Task
	{
		internal get { } //Length: 254
	}

	private override string UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.DebugName
	{
		private get { } //Length: 20
	}

	private override AsyncOperationHandle UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.Handle
	{
		private get { } //Length: 159
	}

	private override bool UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.IsDone
	{
		private get { } //Length: 17
	}

	private override Action<IAsyncOperation> UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.OnDestroy
	{
		private set { } //Length: 13
	}

	private override Exception UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.OperationException
	{
		private get { } //Length: 5
	}

	private override float UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.PercentComplete
	{
		private get { } //Length: 23
	}

	private override int UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.ReferenceCount
	{
		private get { } //Length: 4
	}

	private override Type UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.ResultType
	{
		private get { } //Length: 60
	}

	private override AsyncOperationStatus UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.Status
	{
		private get { } //Length: 4
	}

	private override Task<Object> UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.Task
	{
		private get { } //Length: 312
	}

	private override int UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.Version
	{
		private get { } //Length: 4
	}

	internal int Version
	{
		internal get { } //Length: 4
	}

	protected AsyncOperationBase`1() { }

	[CompilerGenerated]
	private void <.ctor>b__38_0(AsyncOperationHandle o) { }

	internal void add_Completed(Action<AsyncOperationHandle`1<TObject>> value) { }

	internal void add_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	internal void add_Destroyed(Action<AsyncOperationHandle> value) { }

	[CompilerGenerated]
	internal void add_Executed(Action value) { }

	public void Complete(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true) { }

	public void Complete(TObject result, bool success, string errorMsg, bool releaseDependenciesOnFailure) { }

	public void Complete(TObject result, bool success, string errorMsg) { }

	protected private void DecrementReferenceCount() { }

	protected override void Destroy() { }

	protected abstract void Execute() { }

	internal bool get_CompletedEventHasListeners() { }

	internal object get_Current() { }

	protected override string get_DebugName() { }

	internal bool get_DestroyedEventHasListeners() { }

	internal AsyncOperationHandle<TObject> get_Handle() { }

	internal bool get_IsDone() { }

	[CompilerGenerated]
	public override bool get_IsRunning() { }

	internal Exception get_OperationException() { }

	internal float get_PercentComplete() { }

	protected override float get_Progress() { }

	protected private int get_ReferenceCount() { }

	[CompilerGenerated]
	public TObject get_Result() { }

	internal AsyncOperationStatus get_Status() { }

	internal Task<TObject> get_Task() { }

	internal int get_Version() { }

	public override void GetDependencies(List<AsyncOperationHandle> dependencies) { }

	internal override DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

	protected private void IncrementReferenceCount() { }

	internal void InvokeCompletionEvent() { }

	internal void InvokeExecute() { }

	protected override bool InvokeWaitForCompletion() { }

	internal bool MoveNext() { }

	private void RegisterForDeferredCallbackEvent(bool incrementReferenceCount = true) { }

	internal override void ReleaseDependencies() { }

	internal void remove_Completed(Action<AsyncOperationHandle`1<TObject>> value) { }

	internal void remove_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	internal void remove_Destroyed(Action<AsyncOperationHandle> value) { }

	[CompilerGenerated]
	internal void remove_Executed(Action value) { }

	internal void Reset() { }

	[CompilerGenerated]
	internal void set_IsRunning(bool value) { }

	internal void set_OnDestroy(Action<IAsyncOperation> value) { }

	private void set_OperationException(Exception value) { }

	[CompilerGenerated]
	public void set_Result(TObject value) { }

	internal static string ShortenPath(string p, bool keepExtension) { }

	internal void Start(ResourceManager rm, AsyncOperationHandle dependency, DelegateList<Single> updateCallbacks) { }

	public virtual string ToString() { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.add_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.add_Destroyed(Action<AsyncOperationHandle> value) { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.DecrementReferenceCount() { }

	private override string UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_DebugName() { }

	private override AsyncOperationHandle UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_Handle() { }

	private override bool UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_IsDone() { }

	private override Exception UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_OperationException() { }

	private override float UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_PercentComplete() { }

	private override int UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_ReferenceCount() { }

	private override Type UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_ResultType() { }

	private override AsyncOperationStatus UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_Status() { }

	private override Task<Object> UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_Task() { }

	private override int UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.get_Version() { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.GetDependencies(List<AsyncOperationHandle> deps) { }

	private override DownloadStatus UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.GetDownloadStatus(HashSet<Object> visited) { }

	private override object UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.GetResultAsObject() { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.IncrementReferenceCount() { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.InvokeCompletionEvent() { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.remove_CompletedTypeless(Action<AsyncOperationHandle> value) { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.remove_Destroyed(Action<AsyncOperationHandle> value) { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.set_OnDestroy(Action<IAsyncOperation> value) { }

	private override void UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation.Start(ResourceManager rm, AsyncOperationHandle dependency, DelegateList<Single> updateCallbacks) { }

	private void UpdateCallback(float unscaledDeltaTime) { }

	public override void WaitForCompletion() { }

}

