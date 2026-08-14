namespace UnityEngine.UIElements.Layout;

internal class LayoutManager : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static EventHandler <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Initialize>b__7_0(object _, EventArgs __) { }

	}

	private static bool s_Initialized; //Field offset: 0x0
	private static bool s_AppDomainUnloadRegistered; //Field offset: 0x1
	private static LayoutManager s_SharedInstance; //Field offset: 0x8
	private static readonly List<LayoutManager> s_Managers; //Field offset: 0x10
	private readonly int m_Index; //Field offset: 0x10
	private LayoutDataStore m_Nodes; //Field offset: 0x18
	private LayoutDataStore m_Configs; //Field offset: 0x28
	private readonly object m_SyncRoot; //Field offset: 0x38
	private readonly Stack<LayoutHandle> m_NodesToFree; //Field offset: 0x40
	private readonly LayoutHandle m_DefaultConfig; //Field offset: 0x48
	private readonly ManagedObjectStore<LayoutMeasureFunction> m_ManagedMeasureFunctions; //Field offset: 0x50
	private readonly ManagedObjectStore<LayoutBaselineFunction> m_ManagedBaselineFunctions; //Field offset: 0x58
	private readonly ManagedObjectStore<WeakReference`1<VisualElement>> m_ManagedOwners; //Field offset: 0x60
	private int m_HighMark; //Field offset: 0x68

	public static LayoutManager SharedManager
	{
		 get { } //Length: 79
	}

	private static LayoutManager() { }

	public LayoutManager(Allocator allocator) { }

	public LayoutConfig CreateConfig() { }

	public LayoutNode CreateNode() { }

	private LayoutNode CreateNodeInternal(LayoutHandle configHandle) { }

	public void DestroyConfig(ref LayoutConfig config) { }

	public void DestroyNode(ref LayoutNode node) { }

	public override void Dispose() { }

	private void FreeNode(LayoutHandle handle) { }

	public static LayoutManager get_SharedManager() { }

	private LayoutDataAccess GetAccess() { }

	public LayoutBaselineFunction GetBaselineFunction(LayoutHandle handle) { }

	public LayoutConfig GetDefaultConfig() { }

	internal static LayoutManager GetManager(int index) { }

	public LayoutMeasureFunction GetMeasureFunction(LayoutHandle handle) { }

	public VisualElement GetOwner(LayoutHandle handle) { }

	private static void Initialize() { }

	public void SetMeasureFunction(LayoutHandle handle, LayoutMeasureFunction value) { }

	public void SetOwner(LayoutHandle handle, VisualElement value) { }

	private static void Shutdown() { }

	private void TryFreeNodes() { }

}

