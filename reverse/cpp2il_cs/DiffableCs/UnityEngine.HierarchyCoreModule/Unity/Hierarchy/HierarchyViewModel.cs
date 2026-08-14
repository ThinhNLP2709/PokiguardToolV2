namespace Unity.Hierarchy;

[DefaultMember("Item")]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyViewModel.h")]
[NativeHeader("Modules/HierarchyCore/HierarchyViewModelBindings.h")]
[RequiredByNativeCode(GenerateProxy = True)]
public sealed class HierarchyViewModel : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(HierarchyViewModel viewModel) { }

	}

	internal struct Enumerator
	{
		private readonly HierarchyViewModel m_ViewModel; //Field offset: 0x0
		private readonly HierarchyFlattened m_HierarchyFlattened; //Field offset: 0x8
		private readonly Int32* m_NodesPtr; //Field offset: 0x10
		private readonly int m_NodesCount; //Field offset: 0x18
		private readonly int m_Version; //Field offset: 0x1C
		private int m_Index; //Field offset: 0x20

		[IsReadOnly]
		public HierarchyNode Current
		{
			 get { } //Length: 143
		}

		internal Enumerator(HierarchyViewModel hierarchyViewModel) { }

		public HierarchyNode get_Current() { }

		public bool MoveNext() { }

	}

	private IntPtr m_Ptr; //Field offset: 0x10
	private readonly Hierarchy m_Hierarchy; //Field offset: 0x18
	private readonly HierarchyFlattened m_HierarchyFlattened; //Field offset: 0x20
	private IntPtr m_NodesPtr; //Field offset: 0x28
	private int m_NodesCount; //Field offset: 0x30
	private int m_Version; //Field offset: 0x34
	private readonly bool m_IsOwner; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private IHierarchySearchQueryParser <QueryParser>k__BackingField; //Field offset: 0x40

	public int Count
	{
		 get { } //Length: 4
	}

	public HierarchyFlattened HierarchyFlattened
	{
		 get { } //Length: 5
	}

	public bool IsCreated
	{
		 get { } //Length: 9
	}

	[IsReadOnly]
	public HierarchyNode Item
	{
		 get { } //Length: 145
	}

	internal HierarchySearchQueryDescriptor Query
	{
		[NativeMethod(IsThreadSafe = True)]
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
		internal get { } //Length: 81
	}

	internal IHierarchySearchQueryParser QueryParser
	{
		[CompilerGenerated]
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.HierarchyModule"})]
		internal set { } //Length: 13
	}

	public bool UpdateNeeded
	{
		[NativeMethod("UpdateNeeded", IsThreadSafe = True)]
		 get { } //Length: 81
	}

	internal int Version
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
		internal get { } //Length: 4
	}

	private HierarchyViewModel(IntPtr nativePtr, HierarchyFlattened hierarchyFlattened, IntPtr nodesPtr, int nodesCount, int version) { }

	public HierarchyViewModel(HierarchyFlattened hierarchyFlattened, HierarchyNodeFlags defaultFlags = 0) { }

	public void ClearFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false) { }

	[FreeFunction("HierarchyViewModelBindings::ClearFlagsNode", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	private void ClearFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false) { }

	private static void ClearFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public bool Contains(in HierarchyNode node) { }

	private static bool Contains_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	[FreeFunction("HierarchyViewModelBindings::Create", IsThreadSafe = True)]
	private static IntPtr Create(IntPtr handlePtr, HierarchyFlattened hierarchyFlattened, HierarchyNodeFlags defaultFlags, out IntPtr nodesPtr, out int nodesCount, out int version) { }

	private static IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchyFlattened, HierarchyNodeFlags defaultFlags, out IntPtr nodesPtr, out int nodesCount, out int version) { }

	[RequiredByNativeCode]
	private static IntPtr CreateHierarchyViewModel(IntPtr nativePtr, IntPtr flattenedPtr, IntPtr nodesPtr, int nodesCount, int version) { }

	[FreeFunction("HierarchyViewModelBindings::Destroy", IsThreadSafe = True)]
	private static void Destroy(IntPtr nativePtr) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	public HierarchyViewNodesEnumerable EnumerateNodesWithAllFlags(HierarchyNodeFlags flags) { }

	protected virtual void Finalize() { }

	internal static HierarchyViewModel FromIntPtr(IntPtr handlePtr) { }

	public int get_Count() { }

	public HierarchyFlattened get_HierarchyFlattened() { }

	public bool get_IsCreated() { }

	public HierarchyNode get_Item(int index) { }

	[NativeMethod(IsThreadSafe = True)]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
	internal HierarchySearchQueryDescriptor get_Query() { }

	private static HierarchySearchQueryDescriptor get_Query_Injected(IntPtr _unity_self) { }

	[NativeMethod("UpdateNeeded", IsThreadSafe = True)]
	public bool get_UpdateNeeded() { }

	private static bool get_UpdateNeeded_Injected(IntPtr _unity_self) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
	internal int get_Version() { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public int GetChildrenCount(in HierarchyNode node) { }

	private static int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	public Enumerator GetEnumerator() { }

	public bool HasAllFlags(in HierarchyNode node, HierarchyNodeFlags flags) { }

	[FreeFunction("HierarchyViewModelBindings::HasAllFlagsNode", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	private bool HasAllFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags) { }

	private static bool HasAllFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public int IndexOf(in HierarchyNode node) { }

	private static int IndexOf_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	[RequiredByNativeCode]
	private static void SearchBegin(IntPtr handlePtr) { }

	[CompilerGenerated]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.HierarchyModule"})]
	internal void set_QueryParser(IHierarchySearchQueryParser value) { }

	public void SetFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false) { }

	[FreeFunction("HierarchyViewModelBindings::SetFlagsNode", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	private void SetFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false) { }

	private static void SetFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse) { }

	[NativeMethod(IsThreadSafe = True)]
	public void Update() { }

	private static void Update_Injected(IntPtr _unity_self) { }

	[RequiredByNativeCode]
	private static void UpdateHierarchyViewModel(IntPtr handlePtr, IntPtr nodesPtr, int nodesCount, int version) { }

}

