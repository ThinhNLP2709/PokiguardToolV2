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

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeManager.h")]
	internal static class AccessibilityNodeManager // TypeDefIndex: 15624
	{
		// Methods
		internal static bool CreateNativeNodeWithData(AccessibilityNodeData nodeData); // 0x000000018212B870-0x000000018212B8B0
		internal static void DestroyNativeNode(int nodeId); // 0x000000018212B8B0-0x000000018212B8F0
		internal static void SetFrame(int nodeId, Rect frame); // 0x000000018212BDD0-0x000000018212BE10
		[RequiredByNativeCode]
		internal static void Internal_InvokeFocusChanged(int nodeId, bool isNodeFocused); // 0x000000018212BA10-0x000000018212BBD0
		[RequiredByNativeCode]
		internal static bool Internal_InvokeNodeInvoked(int nodeId); // 0x000000018212BC60-0x000000018212BCF0
		[RequiredByNativeCode]
		internal static bool Internal_InvokeIncremented(int nodeId); // 0x000000018212BBD0-0x000000018212BC60
		[RequiredByNativeCode]
		internal static bool Internal_InvokeDecremented(int nodeId); // 0x000000018212B8F0-0x000000018212B980
		[RequiredByNativeCode]
		internal static bool Internal_InvokeScrolled(int nodeId, AccessibilityScrollDirection direction); // 0x000000018212BCF0-0x000000018212BD90
		[RequiredByNativeCode]
		internal static bool Internal_InvokeDismissed(int nodeId); // 0x000000018212B980-0x000000018212BA10
		private static bool CreateNativeNodeWithData_Injected(in AccessibilityNodeData nodeData); // 0x000000018212B830-0x000000018212B870
		private static void SetFrame_Injected(int nodeId, in Rect frame); // 0x000000018212BD90-0x000000018212BDD0
	}
}
