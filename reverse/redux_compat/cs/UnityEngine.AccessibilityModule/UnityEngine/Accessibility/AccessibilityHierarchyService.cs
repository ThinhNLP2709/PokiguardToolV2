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

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	internal static class AccessibilityHierarchyService // TypeDefIndex: 15631
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static AccessibilityHierarchy s_ActiveHierarchy; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		internal static AccessibilityHierarchy activeHierarchy { get; set; } // 0x00000001821286D0-0x0000000182128720 0x0000000182128720-0x0000000182128870
	
		// Constructors
		static AccessibilityHierarchyService(); // 0x00000001821285B0-0x00000001821286D0
	
		// Methods
		internal static IReadOnlyList<AccessibilityNode> GetRootNodes(); // 0x0000000182128320-0x0000000182128380
		internal static bool TryGetNode(int id, out AccessibilityNode node); // 0x0000000182128470-0x0000000182128540
		internal static bool TryGetNodeAt(float x, float y, out AccessibilityNode node); // 0x0000000182128380-0x0000000182128470
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182128540-0x00000001821285B0
	}
}
