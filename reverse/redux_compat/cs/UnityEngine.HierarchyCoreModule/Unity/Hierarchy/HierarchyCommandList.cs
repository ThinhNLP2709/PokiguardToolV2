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
	[NativeHeader("Modules/HierarchyCore/HierarchyCommandListBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyCommandList.h")]
	[RequiredByNativeCode]
	public sealed class HierarchyCommandList : IDisposable // TypeDefIndex: 15651
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		private readonly bool m_IsOwner; // 0x18
	
		// Constructors
		private HierarchyCommandList(IntPtr nativePtr); // 0x0000000182271FC0-0x0000000182271FF0
	
		// Methods
		~HierarchyCommandList(); // 0x0000000182271E40-0x0000000182271EF0
		public void Dispose(); // 0x0000000182271DB0-0x0000000182271E40
		private void Dispose(bool disposing); // 0x0000000182271D50-0x0000000182271DB0
		internal static HierarchyCommandList FromIntPtr(IntPtr handlePtr); // 0x0000000182271EF0-0x0000000182271FC0
		[FreeFunction("HierarchyCommandListBindings::Destroy", IsThreadSafe = true)]
		private static void Destroy(IntPtr nativePtr); // 0x0000000182271D10-0x0000000182271D50
		[RequiredByNativeCode]
		private static IntPtr CreateCommandList(IntPtr nativePtr); // 0x0000000182271CA0-0x0000000182271D10
	}
}
