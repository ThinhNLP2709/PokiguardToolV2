/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 56: UnityEngine.HierarchyCoreModule.dll - Assembly: UnityEngine.HierarchyCoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15636-15666

namespace Unity.Hierarchy
{
	[NativeHeader("Modules/HierarchyCore/Public/Hierarchy.h")]
	[NativeHeader("Modules/HierarchyCore/HierarchyBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeTypeHandlerBase.h")]
	[RequiredByNativeCode]
	public sealed class Hierarchy : IDisposable // TypeDefIndex: 15648
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		private readonly IntPtr m_RootPtr; // 0x18
		private readonly IntPtr m_VersionPtr; // 0x20
		private readonly bool m_IsOwner; // 0x28
		[CompilerGenerated]
		private HandlerCreatedEventHandler HandlerCreated; // 0x30
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15649
		{
			// Methods
			public static IntPtr ConvertToUnmanaged(Hierarchy hierarchy); // 0x00000001808586A0-0x00000001808586C0
		}
	
		[VisibleToOtherModules(new string[1] {"UnityEngine.HierarchyModule" })]
		internal delegate void HandlerCreatedEventHandler(HierarchyNodeTypeHandlerBase handler); // TypeDefIndex: 15650; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		private Hierarchy(IntPtr nativePtr, IntPtr rootPtr, IntPtr versionPtr); // 0x0000000182276790-0x00000001822767E0
	
		// Methods
		~Hierarchy(); // 0x00000001822763F0-0x00000001822764A0
		public void Dispose(); // 0x0000000182276360-0x00000001822763F0
		private void Dispose(bool disposing); // 0x0000000182276300-0x0000000182276360
		public HierarchyNodeTypeHandlerBaseEnumerable EnumerateNodeTypeHandlersBase(); // 0x0000000180E10430-0x0000000180E10450
		internal static Hierarchy FromIntPtr(IntPtr handlePtr); // 0x00000001822764A0-0x0000000182276570
		[FreeFunction("HierarchyBindings::Destroy", IsThreadSafe = true)]
		private static void Destroy(IntPtr nativePtr); // 0x00000001822762C0-0x0000000182276300
		[FreeFunction("HierarchyBindings::GetNodeTypeHandlersBaseCount", HasExplicitThis = true, IsThreadSafe = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.HierarchyModule" })]
		internal int GetNodeTypeHandlersBaseCount(); // 0x00000001822765B0-0x0000000182276610
		[FreeFunction("HierarchyBindings::GetNodeTypeHandlersBaseSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.HierarchyModule" })]
		internal int GetNodeTypeHandlersBaseSpan(Span<IntPtr> outHandlers); // 0x0000000182276660-0x0000000182276700
		[RequiredByNativeCode]
		private static IntPtr CreateHierarchy(IntPtr nativePtr, IntPtr rootPtr, IntPtr versionPtr); // 0x0000000182276230-0x00000001822762C0
		[RequiredByNativeCode]
		private static void InvokeHandlerCreated(IntPtr hierarchyPtr, IntPtr handlerPtr); // 0x0000000182276700-0x0000000182276790
		private static int GetNodeTypeHandlersBaseCount_Injected(IntPtr _unity_self); // 0x0000000182276570-0x00000001822765B0
		private static int GetNodeTypeHandlersBaseSpan_Injected(IntPtr _unity_self, ref ManagedSpanWrapper outHandlers); // 0x0000000182276610-0x0000000182276660
	}
}
