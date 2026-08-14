namespace UnityEngine.UIElements.UIR;

internal class MeshGenerationDeferrer : IDisposable
{
	private struct CallbackInfo
	{
		public MeshGenerationCallback callback; //Field offset: 0x0
		public object userData; //Field offset: 0x8

	}

	private Queue<CallbackInfo> m_Fork; //Field offset: 0x10
	private Queue<CallbackInfo> m_WorkThenFork; //Field offset: 0x18
	private Queue<CallbackInfo> m_Work; //Field offset: 0x20
	private Queue<CallbackInfo> m_JobDependentFork; //Field offset: 0x28
	private Queue<CallbackInfo> m_JobDependentWorkThenFork; //Field offset: 0x30
	private Queue<CallbackInfo> m_JobDependentWork; //Field offset: 0x38
	private Queue<JobHandle> m_Dependencies; //Field offset: 0x40
	private JobMerger m_DependencyMerger; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x50

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public MeshGenerationDeferrer() { }

	public void AddMeshGenerationCallback(MeshGenerationCallback callback, object userData, MeshGenerationCallbackType callbackType, bool isJobDependent) { }

	public void AddMeshGenerationJob(JobHandle jobHandle) { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	private static void Invoke(CallbackInfo ci, MeshGenerationContext mgc) { }

	public void ProcessDeferredWork(MeshGenerationContext meshGenerationContext) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

