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
	[NativeHeader("Modules/HierarchyCore/HierarchyFlattenedBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattened.h")]
	[RequiredByNativeCode]
	public sealed class HierarchyFlattened : IDisposable // TypeDefIndex: 15652
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		internal readonly Hierarchy m_Hierarchy; // 0x18
		private ReadOnlyNativeVector<HierarchyFlattenedNode> m_FlattenedNodes; // 0x20
		private int m_Version; // 0x30
		private readonly bool m_IsOwner; // 0x34
	
		// Constructors
		private HierarchyFlattened(IntPtr nativePtr, Hierarchy hierarchy, IntPtr flattenedNodesPtr, int flattenedNodesCount, int version); // 0x0000000182272730-0x00000001822727C0
	
		// Methods
		~HierarchyFlattened(); // 0x0000000182272530-0x00000001822725F0
		public void Dispose(); // 0x0000000182272430-0x00000001822724D0
		private void Dispose(bool disposing); // 0x00000001822724D0-0x0000000182272530
		internal static HierarchyFlattened FromIntPtr(IntPtr handlePtr); // 0x00000001822725F0-0x00000001822726C0
		[FreeFunction("HierarchyFlattenedBindings::Destroy", IsThreadSafe = true)]
		private static void Destroy(IntPtr nativePtr); // 0x00000001822723F0-0x0000000182272430
		[RequiredByNativeCode]
		private static IntPtr CreateHierarchyFlattened(IntPtr nativePtr, IntPtr hierarchyPtr, IntPtr flattenedNodesPtr, int flattenedNodesCount, int version); // 0x0000000182272310-0x00000001822723F0
		[RequiredByNativeCode]
		private static void UpdateHierarchyFlattened(IntPtr handlePtr, IntPtr flattenedNodesPtr, int flattenedNodesCount, int version); // 0x00000001822726C0-0x0000000182272730
	}
}
