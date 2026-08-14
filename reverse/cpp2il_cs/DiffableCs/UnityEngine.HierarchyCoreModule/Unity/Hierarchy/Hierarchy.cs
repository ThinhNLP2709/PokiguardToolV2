namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/Public/Hierarchy.h")]
[NativeHeader("Modules/HierarchyCore/HierarchyBindings.h")]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeTypeHandlerBase.h")]
[RequiredByNativeCode(GenerateProxy = True)]
public sealed class Hierarchy : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(Hierarchy hierarchy) { }

	}

	private IntPtr m_Ptr; //Field offset: 0x10
	private readonly IntPtr m_RootPtr; //Field offset: 0x18
	private readonly IntPtr m_VersionPtr; //Field offset: 0x20
	private readonly bool m_IsOwner; //Field offset: 0x28

	public bool IsCreated
	{
		 get { } //Length: 9
	}

	[IsReadOnly]
	public HierarchyNode Root
	{
		 get { } //Length: 13
	}

	public bool UpdateNeeded
	{
		[NativeMethod("UpdateNeeded", IsThreadSafe = True)]
		 get { } //Length: 81
	}

	internal int Version
	{
		internal get { } //Length: 22
	}

	public Hierarchy() { }

	private Hierarchy(IntPtr nativePtr, IntPtr rootPtr, IntPtr versionPtr) { }

	public HierarchyNode Add(in HierarchyNode parent) { }

	[FreeFunction("HierarchyBindings::AddNode", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	private HierarchyNode AddNode(in HierarchyNode parent) { }

	private static void AddNode_Injected(IntPtr _unity_self, in HierarchyNode parent, out HierarchyNode ret) { }

	[FreeFunction("HierarchyBindings::Create", IsThreadSafe = True)]
	private static IntPtr Create(IntPtr handlePtr, out IntPtr rootPtr, out IntPtr versionPtr) { }

	[RequiredByNativeCode]
	private static IntPtr CreateHierarchy(IntPtr nativePtr, IntPtr rootPtr, IntPtr versionPtr) { }

	[FreeFunction("HierarchyBindings::Destroy", IsThreadSafe = True)]
	private static void Destroy(IntPtr nativePtr) { }

	private void Dispose(bool disposing) { }

	public override void Dispose() { }

	public HierarchyNodeChildren EnumerateChildren(in HierarchyNode node) { }

	[FreeFunction("HierarchyBindings::EnumerateChildrenPtr", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	private IntPtr EnumerateChildrenPtr(in HierarchyNode node) { }

	private static IntPtr EnumerateChildrenPtr_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	public HierarchyNodeTypeHandlerBaseEnumerable EnumerateNodeTypeHandlersBase() { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public bool Exists(in HierarchyNode node) { }

	private static bool Exists_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	protected virtual void Finalize() { }

	internal static Hierarchy FromIntPtr(IntPtr handlePtr) { }

	public bool get_IsCreated() { }

	public HierarchyNode get_Root() { }

	[NativeMethod("UpdateNeeded", IsThreadSafe = True)]
	public bool get_UpdateNeeded() { }

	private static bool get_UpdateNeeded_Injected(IntPtr _unity_self) { }

	internal int get_Version() { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public HierarchyNode[] GetChildren(in HierarchyNode node) { }

	private static void GetChildren_Injected(IntPtr _unity_self, in HierarchyNode node, out BlittableArrayWrapper ret) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public int GetChildrenCount(in HierarchyNode node) { }

	private static int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	[FreeFunction("HierarchyBindings::GetNodeTypeHandlersBaseCount", HasExplicitThis = True, IsThreadSafe = True)]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
	internal int GetNodeTypeHandlersBaseCount() { }

	private static int GetNodeTypeHandlersBaseCount_Injected(IntPtr _unity_self) { }

	[FreeFunction("HierarchyBindings::GetNodeTypeHandlersBaseSpan", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
	internal int GetNodeTypeHandlersBaseSpan(Span<IntPtr> outHandlers) { }

	private static int GetNodeTypeHandlersBaseSpan_Injected(IntPtr _unity_self, ref ManagedSpanWrapper outHandlers) { }

	[FreeFunction("HierarchyBindings::GetOrCreateProperty", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	private HierarchyPropertyId GetOrCreateProperty(string name, in HierarchyPropertyDescriptor descriptor) { }

	private static void GetOrCreateProperty_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, in HierarchyPropertyDescriptor descriptor, out HierarchyPropertyId ret) { }

	public HierarchyPropertyUnmanaged<T> GetOrCreatePropertyUnmanaged(string name, HierarchyPropertyStorageType type = 1) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public HierarchyNode GetParent(in HierarchyNode node) { }

	private static void GetParent_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret) { }

	[FreeFunction("HierarchyBindings::GetPropertyRaw", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	internal Void* GetPropertyRaw(in HierarchyPropertyId property, in HierarchyNode node, out int size) { }

	private static Void* GetPropertyRaw_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, out int size) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public bool SetParent(in HierarchyNode node, in HierarchyNode parent) { }

	private static bool SetParent_Injected(IntPtr _unity_self, in HierarchyNode node, in HierarchyNode parent) { }

	[FreeFunction("HierarchyBindings::SetPropertyRaw", HasExplicitThis = True, IsThreadSafe = True, ThrowsException = True)]
	internal void SetPropertyRaw(in HierarchyPropertyId property, in HierarchyNode node, Void* ptr, int size) { }

	private static void SetPropertyRaw_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, Void* ptr, int size) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public void SetSortIndex(in HierarchyNode node, int sortIndex) { }

	private static void SetSortIndex_Injected(IntPtr _unity_self, in HierarchyNode node, int sortIndex) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public void SortChildren(in HierarchyNode node, bool recurse = false) { }

	private static void SortChildren_Injected(IntPtr _unity_self, in HierarchyNode node, bool recurse) { }

	[NativeMethod(IsThreadSafe = True)]
	public void Update() { }

	private static void Update_Injected(IntPtr _unity_self) { }

}

