namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeTypeHandlerBase.h")]
[NativeHeader("Modules/HierarchyCore/HierarchyNodeTypeHandlerBaseBindings.h")]
[RequiredByNativeCode(GenerateProxy = True)]
public abstract class HierarchyNodeTypeHandlerBase
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(HierarchyNodeTypeHandlerBase handler) { }

	}

	private struct ConstructorScope : IDisposable
	{
		[ThreadStatic]
		private static IntPtr m_Ptr; //Field offset: 0x80000000
		[ThreadStatic]
		private static Hierarchy m_Hierarchy; //Field offset: 0x80000008
		[ThreadStatic]
		private static HierarchyCommandList m_CommandList; //Field offset: 0x80000010

		private static HierarchyCommandList CommandList
		{
			private set { } //Length: 82
		}

		private static Hierarchy Hierarchy
		{
			private set { } //Length: 82
		}

		private static IntPtr Ptr
		{
			private set { } //Length: 58
		}

		public ConstructorScope(IntPtr nativePtr, Hierarchy hierarchy, HierarchyCommandList cmdList) { }

		public override void Dispose() { }

		private static void set_CommandList(HierarchyCommandList value) { }

		private static void set_Hierarchy(Hierarchy value) { }

		private static void set_Ptr(IntPtr value) { }

	}

	private static readonly Dictionary<Type, Int32> s_NodeTypes; //Field offset: 0x0
	internal readonly IntPtr m_Ptr; //Field offset: 0x10
	private readonly Hierarchy m_Hierarchy; //Field offset: 0x18
	private readonly HierarchyCommandList m_CommandList; //Field offset: 0x20

	private static HierarchyNodeTypeHandlerBase() { }

	[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::ChangesPending", HasExplicitThis = True, IsThreadSafe = True)]
	[Obsolete("ChangesPending is obsolete, it is replaced by adding commands into the hierarchy node type handler's CommandList.", False)]
	protected override bool ChangesPending() { }

	private static bool ChangesPending_Injected(IntPtr _unity_self) { }

	[RequiredByNativeCode]
	private static IntPtr CreateNodeTypeHandlerFromType(IntPtr nativePtr, Type handlerType, IntPtr hierarchyPtr, IntPtr cmdListPtr) { }

	protected override void Dispose(bool disposing) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.HierarchyModule"})]
	internal static HierarchyNodeTypeHandlerBase FromIntPtr(IntPtr handlePtr) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	public override HierarchyNodeFlags GetDefaultNodeFlags(in HierarchyNode node, HierarchyNodeFlags defaultFlags = 0) { }

	private static HierarchyNodeFlags GetDefaultNodeFlags_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags defaultFlags) { }

	[NativeMethod(IsThreadSafe = True)]
	public override string GetNodeTypeName() { }

	private static void GetNodeTypeName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	protected override void Initialize() { }

	[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::IntegrateChanges", HasExplicitThis = True, IsThreadSafe = True)]
	[Obsolete("IntegrateChanges is obsolete, it is replaced by adding commands into the hierarchy node type handler's CommandList.", False)]
	protected override bool IntegrateChanges(HierarchyCommandList cmdList) { }

	private static bool IntegrateChanges_Injected(IntPtr _unity_self, IntPtr cmdList) { }

	internal void Internal_SearchBegin(HierarchySearchQueryDescriptor query) { }

	[RequiredByNativeCode]
	private static bool InvokeChangesPending(IntPtr handlePtr) { }

	[RequiredByNativeCode]
	private static void InvokeDispose(IntPtr handlePtr) { }

	[RequiredByNativeCode]
	private static HierarchyNodeFlags InvokeGetDefaultNodeFlags(IntPtr handlePtr, in HierarchyNode node, HierarchyNodeFlags defaultFlags) { }

	[RequiredByNativeCode]
	private static string InvokeGetNodeTypeName(IntPtr handlePtr) { }

	[RequiredByNativeCode]
	private static void InvokeInitialize(IntPtr handlePtr) { }

	[RequiredByNativeCode]
	private static bool InvokeIntegrateChanges(IntPtr handlePtr, IntPtr cmdListPtr) { }

	[RequiredByNativeCode]
	private static void InvokeSearchEnd(IntPtr handlePtr) { }

	[RequiredByNativeCode]
	private static bool InvokeSearchMatch(IntPtr handlePtr, in HierarchyNode node) { }

	[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::SearchBegin", HasExplicitThis = True, IsThreadSafe = True)]
	protected override void SearchBegin(HierarchySearchQueryDescriptor query) { }

	private static void SearchBegin_Injected(IntPtr _unity_self, HierarchySearchQueryDescriptor query) { }

	[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::SearchEnd", HasExplicitThis = True, IsThreadSafe = True)]
	protected override void SearchEnd() { }

	private static void SearchEnd_Injected(IntPtr _unity_self) { }

	[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::SearchMatch", HasExplicitThis = True, IsThreadSafe = True)]
	protected override bool SearchMatch(in HierarchyNode node) { }

	private static bool SearchMatch_Injected(IntPtr _unity_self, in HierarchyNode node) { }

	[RequiredByNativeCode]
	private static bool TryGetStaticNodeType(Type handlerType, out int nodeType) { }

}

