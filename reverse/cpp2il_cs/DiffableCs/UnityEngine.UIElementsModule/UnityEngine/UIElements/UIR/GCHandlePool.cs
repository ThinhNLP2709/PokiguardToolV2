namespace UnityEngine.UIElements.UIR;

internal class GCHandlePool : IDisposable
{
	private List<GCHandle> m_Handles; //Field offset: 0x10
	private int m_UsedHandlesCount; //Field offset: 0x18
	private readonly int k_AllocBatchSize; //Field offset: 0x1C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x20

	internal bool disposed
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 1011
	}

	public GCHandlePool(int capacity = 256, int allocBatchSize = 64) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	public GCHandle Get(object target) { }

	[CompilerGenerated]
	internal bool get_disposed() { }

	public IntPtr GetIntPtr(object target) { }

	public void ReturnAll() { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

