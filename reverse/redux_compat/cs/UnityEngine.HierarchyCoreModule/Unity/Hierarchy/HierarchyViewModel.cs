/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 56: UnityEngine.HierarchyCoreModule.dll - Assembly: UnityEngine.HierarchyCoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15636-15666

namespace Unity.Hierarchy
{
	[DefaultMember("Item")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyViewModel.h")]
	[NativeHeader("Modules/HierarchyCore/HierarchyViewModelBindings.h")]
	[RequiredByNativeCode]
	public sealed class HierarchyViewModel : IDisposable // TypeDefIndex: 15662
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		internal readonly Hierarchy m_Hierarchy; // 0x18
		internal readonly HierarchyFlattened m_HierarchyFlattened; // 0x20
		private ReadOnlyNativeVector<HierarchyFlattenedNode> m_FlattenedNodes; // 0x28
		private ReadOnlyNativeVector<HierarchyNode> m_Nodes; // 0x38
		private int m_Version; // 0x48
		private readonly bool m_IsOwner; // 0x4C
		[CompilerGenerated]
		private FlagsChangedEventHandler FlagsChanged; // 0x50
		[CompilerGenerated]
		private IHierarchySearchQueryParser _QueryParser_k__BackingField; // 0x58
	
		// Properties
		internal IHierarchySearchQueryParser QueryParser { [VisibleToOtherModules(new string[1] {"UnityEditor.HierarchyModule" })] [CompilerGenerated] set; } // 0x00000001802F4050-0x00000001802F4060
		internal HierarchySearchQueryDescriptor Query { [NativeMethod(IsThreadSafe = true)] [VisibleToOtherModules(new string[1] {"UnityEngine.HierarchyModule" })] get; } // 0x00000001822761D0-0x0000000182276230 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15663
		{
			// Methods
			public static IntPtr ConvertToUnmanaged(HierarchyViewModel viewModel); // 0x00000001808586A0-0x00000001808586C0
		}
	
		public delegate void FlagsChangedEventHandler(HierarchyNodeFlags flags); // TypeDefIndex: 15664; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		private HierarchyViewModel(IntPtr nativePtr, HierarchyFlattened hierarchyFlattened, IntPtr flattenedNodesPtr, int flattenedNodesCount, IntPtr nodesPtr, int nodesCount, int version); // 0x0000000182276070-0x0000000182276190
	
		// Methods
		~HierarchyViewModel(); // 0x0000000182275C30-0x0000000182275CF0
		public void Dispose(); // 0x0000000182275B20-0x0000000182275BC0
		private void Dispose(bool disposing); // 0x0000000182275BC0-0x0000000182275C30
		internal static HierarchyViewModel FromIntPtr(IntPtr handlePtr); // 0x0000000182275CF0-0x0000000182275DC0
		[FreeFunction("HierarchyViewModelBindings::Destroy", IsThreadSafe = true)]
		private static void Destroy(IntPtr nativePtr); // 0x0000000182275AE0-0x0000000182275B20
		[RequiredByNativeCode]
		private static IntPtr CreateHierarchyViewModel(IntPtr nativePtr, IntPtr flattenedPtr, IntPtr flattenedNodesPtr, int flattenedNodesCount, IntPtr nodesPtr, int nodesCount, int version); // 0x0000000182275970-0x0000000182275AE0
		[RequiredByNativeCode]
		private static void UpdateHierarchyViewModel(IntPtr handlePtr, IntPtr flattenedNodesPtr, int flattenedNodesCount, IntPtr nodesPtr, int nodesCount, int version); // 0x0000000182275FD0-0x0000000182276070
		[RequiredByNativeCode]
		private static void InvokeFlagsChanged(IntPtr handlePtr, HierarchyNodeFlags flags); // 0x0000000182275DC0-0x0000000182275E00
		[RequiredByNativeCode]
		private static void SearchBegin(IntPtr handlePtr); // 0x0000000182275E00-0x0000000182275FD0
		private static HierarchySearchQueryDescriptor get_Query_Injected(IntPtr _unity_self); // 0x0000000182276190-0x00000001822761D0
	}
}
