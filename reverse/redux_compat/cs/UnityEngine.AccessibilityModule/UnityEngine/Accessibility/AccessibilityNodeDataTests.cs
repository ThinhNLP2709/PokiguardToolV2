/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeDataTests.h")]
	[VisibleToOtherModules(new string[1] {"UnityEditor.AccessibilityModule" })]
	internal class AccessibilityNodeDataTests // TypeDefIndex: 15623
	{
		// Fields
		[NoAutoStaticsCleanup]
		internal static AccessibilityNodeData nodeDataFromNative; // 0x00
	
		// Methods
		internal static AccessibilityNodeData Test_GetNodeDataFromNativePtr(IntPtr nodeDataPtr); // 0x000000018212B6D0-0x000000018212B730
		[RequiredByNativeCode]
		internal static void Internal_GetNodeDataFromManaged(IntPtr nodeDataPtr); // 0x000000018212B3D0-0x000000018212B5D0
		[RequiredByNativeCode]
		internal static void Internal_GetNodeDataToManaged(IntPtr nodeDataPtr); // 0x000000018212B5D0-0x000000018212B680
		private static void Test_GetNodeDataFromNativePtr_Injected(IntPtr nodeDataPtr, ); // 0x000000018212B680-0x000000018212B6D0
	}
}
