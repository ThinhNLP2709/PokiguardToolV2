namespace Unity.Hierarchy;

[DefaultMember("Item")]
[NativeHeader("Modules/HierarchyCore/HierarchyFlattenedBindings.h")]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattened.h")]
[RequiredByNativeCode(GenerateProxy = True)]
public sealed class HierarchyFlattened : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(HierarchyFlattened hierarchyFlattened) { }

	}

	internal struct Enumerator
	{
		private readonly HierarchyFlattened m_HierarchyFlattened; //Field offset: 0x0
		private readonly HierarchyFlattenedNode* m_NodesPtr; //Field offset: 0x8
		private readonly int m_NodesCount; //Field offset: 0x10
		private readonly int m_Version; //Field offset: 0x14
		private int m_Index; //Field offset: 0x18

		[IsReadOnly]
		public HierarchyFlattenedNode Current
		{
			 get { } //Length: 125
		}

		internal Enumerator(HierarchyFlattened hierarchyFlattened) { }

		public HierarchyFlattenedNode get_Current() { }

		public bool MoveNext() { }

	}

	private IntPtr m_Ptr; //Field offset: 0x10
	private readonly Hierarchy m_Hierarchy; //Field offset: 0x18
	private IntPtr m_NodesPtr; //Field offset: 0x20
	private int m_NodesCount; //Field offset: 0x28
	private int m_Version; //Field offset: 0x2C
	private readonly bool m_IsOwner; //Field offset: 0x30

	public int Count
	{
		 get { } //Length: 4
	}

	public Hierarchy Hierarchy
	{
		 get { } //Length: 5
	}

	public bool IsCreated
	{
		 get { } //Length: 9
	}

	[IsReadOnly]
	public HierarchyFlattenedNode Item
	{
		 get { } //Length: 114
	}

	internal HierarchyFlattenedNode* NodesPtr
	{
		internal get { } //Length: 11
	}

	public bool UpdateNeeded
	{
		[NativeMethod("UpdateNeeded", IsThreadSafe = True)]
		 get { } //Length: 81
	}

	internal int Version
	{
		internal get { } //Length: 4
	}

	public HierarchyFlattened(Hierarchy hierarchy) { }

	private HierarchyFlattened(IntPtr nativePtr, Hierarchy hierarchy, IntPtr nodesPtr, int nodesCount, int version) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public bool Contains(in HierarchyNode node) { }

	private static bool Contains_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	[FreeFunction("HierarchyFlattenedBindings::Create", IsThreadSafe = True)]
	private static IntPtr Create(IntPtr handlePtr, Hierarchy hierarchy, out IntPtr nodesPtr, out int nodesCount, out int version) { }

	private static IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchy, out IntPtr nodesPtr, out int nodesCount, out int version) { }

	[RequiredByNativeCode]
	private static IntPtr CreateHierarchyFlattened(IntPtr nativePtr, IntPtr hierarchyPtr, IntPtr nodesPtr, int nodesCount, int version) { }

	[FreeFunction("HierarchyFlattenedBindings::Destroy", IsThreadSafe = True)]
	private static void Destroy(IntPtr nativePtr) { }

	private void Dispose(bool disposing) { }

	public override void Dispose() { }

	public HierarchyFlattenedNodeChildren EnumerateChildren(in HierarchyNode node) { }

	protected virtual void Finalize() { }

	internal static HierarchyFlattened FromIntPtr(IntPtr handlePtr) { }

	public int get_Count() { }

	public Hierarchy get_Hierarchy() { }

	public bool get_IsCreated() { }

	public HierarchyFlattenedNode get_Item(int index) { }

	internal HierarchyFlattenedNode* get_NodesPtr() { }

	[NativeMethod("UpdateNeeded", IsThreadSafe = True)]
	public bool get_UpdateNeeded() { }

	private static bool get_UpdateNeeded_Injected(IntPtr _unity_self) { }

	internal int get_Version() { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public int GetChildrenCount(in HierarchyNode node) { }

	private static int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	public Enumerator GetEnumerator() { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public int IndexOf(in HierarchyNode node) { }

	private static int IndexOf_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	[NativeMethod(IsThreadSafe = True)]
	public void Update() { }

	private static void Update_Injected(IntPtr _unity_self) { }

	[RequiredByNativeCode]
	private static void UpdateHierarchyFlattened(IntPtr handlePtr, IntPtr nodesPtr, int nodesCount, int version) { }

}

