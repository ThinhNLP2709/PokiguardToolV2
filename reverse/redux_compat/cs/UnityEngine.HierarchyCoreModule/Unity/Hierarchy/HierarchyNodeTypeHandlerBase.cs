/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 56: UnityEngine.HierarchyCoreModule.dll - Assembly: UnityEngine.HierarchyCoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15636-15666

namespace Unity.Hierarchy
{
	[NativeHeader("Modules/HierarchyCore/HierarchyNodeTypeHandlerBaseBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeTypeHandlerBase.h")]
	[RequiredByNativeCode]
	public abstract class HierarchyNodeTypeHandlerBase // TypeDefIndex: 15640
	{
		// Fields
		internal readonly IntPtr m_Ptr; // 0x10
		private readonly Hierarchy m_Hierarchy; // 0x18
		private readonly HierarchyCommandList m_CommandList; // 0x20
		[AutoStaticsCleanupOnCodeReload]
		private static readonly Dictionary<Type, int> s_NodeTypes; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15641
		{
			// Methods
			public static IntPtr ConvertToUnmanaged(HierarchyNodeTypeHandlerBase handler); // 0x00000001808586A0-0x00000001808586C0
		}
	
		private struct ConstructorScope : IDisposable // TypeDefIndex: 15642
		{
			// Fields
			[NoAutoStaticsCleanup]
			[ThreadStatic]
			private static IntPtr m_Ptr; // 0x80000000
			[NoAutoStaticsCleanup]
			[ThreadStatic]
			private static Hierarchy m_Hierarchy; // 0x80000008
			[NoAutoStaticsCleanup]
			[ThreadStatic]
			private static HierarchyCommandList m_CommandList; // 0x80000010
	
			// Properties
			private static IntPtr Ptr { set; } // 0x00000001822718C0-0x0000000182271900
			private static Hierarchy Hierarchy { set; } // 0x0000000182271860-0x00000001822718C0
			private static HierarchyCommandList CommandList { set; } // 0x0000000182271800-0x0000000182271860
	
			// Constructors
			public ConstructorScope(IntPtr nativePtr, Hierarchy hierarchy, HierarchyCommandList cmdList); // 0x0000000182271720-0x0000000182271800
	
			// Methods
			public void Dispose(); // 0x0000000182271650-0x0000000182271720
		}
	
		// Constructors
		static HierarchyNodeTypeHandlerBase(); // 0x0000000182274230-0x00000001822743B0
	
		// Methods
		protected virtual void Initialize(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		[NativeMethod(IsThreadSafe = true)]
		public virtual string GetNodeTypeName(); // 0x00000001822731C0-0x00000001822732F0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public virtual HierarchyNodeFlags GetDefaultNodeFlags([IsReadOnly] in HierarchyNode node, HierarchyNodeFlags defaultFlags = HierarchyNodeFlags.None /* Metadata: 0x006AA134 */); // 0x0000000182272D10-0x0000000182272DC0
		[NativeMethod(IsThreadSafe = true)]
		public virtual HierarchyNode GetNodeFromEntityId(EntityId entityId); // 0x00000001822730C0-0x0000000182273170
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public virtual int GetNodesFromEntityIds(ReadOnlySpan<EntityId> entityIds, Span<HierarchyNode> outNodes); // 0x0000000182273350-0x0000000182273480
		[NativeMethod(IsThreadSafe = true)]
		public virtual EntityId GetEntityIdFromNode([IsReadOnly] in HierarchyNode node); // 0x0000000182272E20-0x0000000182272ED0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public virtual int GetEntityIdsFromNodes(ReadOnlySpan<HierarchyNode> nodes, Span<EntityId> outEntityIds); // 0x0000000182272F30-0x0000000182273060
		protected virtual void SearchBegin(HierarchySearchQueryDescriptor query); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual bool SearchMatch([IsReadOnly] in HierarchyNode node); // 0x00000001802E7840-0x00000001802E7850
		protected virtual void SearchEnd(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void UpdateBegin(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void UpdateEnd(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void ViewModelPostUpdate(HierarchyViewModel viewModel); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void ViewModelPostSetState(HierarchyViewModel viewModel); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void GetUIDInfo(out HierarchyUIDInfo info); // 0x0000000182273480-0x0000000182273490
		protected virtual void WriteUIDs(ReadOnlySpan<HierarchyNode> nodes, Span<byte> outUIDs); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void ReadUIDs([IsReadOnly] in HierarchyUIDInfo info, ReadOnlySpan<byte> uids, Span<HierarchyNode> outNodes); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual bool UndoRedoSupported(); // 0x00000001802E7840-0x00000001802E7850
		[VisibleToOtherModules(new string[1] {"UnityEngine.HierarchyModule" })]
		internal static HierarchyNodeTypeHandlerBase FromIntPtr(IntPtr handlePtr); // 0x0000000182272BC0-0x0000000182272CB0
		internal void Internal_SearchBegin(HierarchySearchQueryDescriptor query); // 0x0000000182273490-0x00000001822734B0
		[RequiredByNativeCode]
		private static IntPtr CreateNodeTypeHandlerFromType(IntPtr nativePtr, Type handlerType, IntPtr hierarchyPtr, IntPtr cmdListPtr); // 0x00000001822727F0-0x0000000182272BC0
		[RequiredByNativeCode]
		private static bool TryGetStaticNodeType(Type handlerType, out int nodeType); // 0x0000000182274060-0x00000001822741D0
		[RequiredByNativeCode]
		private static void InvokeInitialize(IntPtr handlePtr); // 0x0000000182273A50-0x0000000182273AC0
		[RequiredByNativeCode]
		private static void InvokeDispose(IntPtr handlePtr); // 0x00000001822734B0-0x0000000182273550
		[RequiredByNativeCode]
		private static string InvokeGetNodeTypeName(IntPtr handlePtr); // 0x0000000182273830-0x00000001822738A0
		[RequiredByNativeCode]
		private static int InvokeGetDefaultNodeFlags(IntPtr handlePtr, [IsReadOnly] in HierarchyNode node, HierarchyNodeFlags defaultFlags); // 0x0000000182273550-0x00000001822735E0
		[RequiredByNativeCode]
		private static bool InvokeSearchMatch(IntPtr handlePtr, [IsReadOnly] in HierarchyNode node); // 0x0000000182273C60-0x0000000182273CE0
		[RequiredByNativeCode]
		private static void InvokeSearchEnd(IntPtr handlePtr); // 0x0000000182273BF0-0x0000000182273C60
		[RequiredByNativeCode]
		private static void InvokeUpdateBegin(IntPtr handlePtr); // 0x0000000182273D50-0x0000000182273DC0
		[RequiredByNativeCode]
		private static void InvokeUpdateEnd(IntPtr handlePtr); // 0x0000000182273DC0-0x0000000182273E30
		[RequiredByNativeCode]
		private static void InvokeViewModelPostUpdate(IntPtr handlePtr, IntPtr viewModelPtr); // 0x0000000182273EC0-0x0000000182273F50
		[RequiredByNativeCode]
		private static void InvokeViewModelPostSetState(IntPtr handlePtr, IntPtr viewModelPtr); // 0x0000000182273E30-0x0000000182273EC0
		[RequiredByNativeCode]
		private static void InvokeGetNodeFromEntityId(IntPtr handlePtr, [IsReadOnly] in EntityId entityId, out HierarchyNode result); // 0x00000001822737A0-0x0000000182273830
		[RequiredByNativeCode]
		private static void InvokeGetNodesFromEntityIds(IntPtr handlePtr, IntPtr entityIds, int count, IntPtr outNodes, out int remaining); // 0x00000001822738A0-0x00000001822739D0
		[RequiredByNativeCode]
		private static void InvokeGetEntityIdFromNode(IntPtr handlePtr, [IsReadOnly] in HierarchyNode node, out EntityId result); // 0x00000001822735E0-0x0000000182273670
		[RequiredByNativeCode]
		private static void InvokeGetEntityIdsFromNodes(IntPtr handlePtr, IntPtr nodes, int count, IntPtr outEntityIds, out int remaining); // 0x0000000182273670-0x00000001822737A0
		[RequiredByNativeCode]
		private static void InvokeGetUIDInfo(IntPtr handlePtr, out HierarchyUIDInfo info); // 0x00000001822739D0-0x0000000182273A50
		[RequiredByNativeCode]
		private static void InvokeWriteUIDs(IntPtr handlePtr, IntPtr nodes, int count, IntPtr outUIDs, [IsReadOnly] in HierarchyUIDInfo info); // 0x0000000182273F50-0x0000000182274060
		[RequiredByNativeCode]
		private static void InvokeReadUIDs(IntPtr handlePtr, IntPtr uids, [IsReadOnly] in HierarchyUIDInfo info, IntPtr outNodes, int count); // 0x0000000182273AC0-0x0000000182273BF0
		[RequiredByNativeCode]
		private static bool InvokeUndoRedoSupported(IntPtr handlePtr); // 0x0000000182273CE0-0x0000000182273D50
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822741D0-0x0000000182274230
		private static void GetNodeTypeName_Injected(IntPtr _unity_self, ); // 0x0000000182273170-0x00000001822731C0
		private static HierarchyNodeFlags GetDefaultNodeFlags_Injected(IntPtr _unity_self, [IsReadOnly] in HierarchyNode node, HierarchyNodeFlags defaultFlags); // 0x0000000182272CB0-0x0000000182272D10
		private static void GetNodeFromEntityId_Injected(IntPtr _unity_self, in EntityId entityId, ); // 0x0000000182273060-0x00000001822730C0
		private static int GetNodesFromEntityIds_Injected(IntPtr _unity_self, ref ManagedSpanWrapper entityIds, ref ManagedSpanWrapper outNodes); // 0x00000001822732F0-0x0000000182273350
		private static void GetEntityIdFromNode_Injected(IntPtr _unity_self, [IsReadOnly] in HierarchyNode node, ); // 0x0000000182272DC0-0x0000000182272E20
		private static int GetEntityIdsFromNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, ref ManagedSpanWrapper outEntityIds); // 0x0000000182272ED0-0x0000000182272F30
	}
}
