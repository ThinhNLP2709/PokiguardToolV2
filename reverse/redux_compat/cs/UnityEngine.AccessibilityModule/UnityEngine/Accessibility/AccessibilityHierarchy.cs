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
	public class AccessibilityHierarchy // TypeDefIndex: 15630
	{
		// Fields
		internal readonly Dictionary<int, AccessibilityNode> nodes; // 0x10
		private List<AccessibilityNode> m_RootNodes; // 0x18
		[NoAutoStaticsCleanup]
		private static readonly List<WeakReference<AccessibilityHierarchy>> s_LiveHierarchies; // 0x00
	
		// Properties
		public IReadOnlyList<AccessibilityNode> rootNodes { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		static AccessibilityHierarchy(); // 0x0000000182128F80-0x0000000182129010
	
		// Methods
		public bool TryGetNode(int id, out AccessibilityNode node); // 0x0000000182128D40-0x0000000182128DB0
		public bool TryGetNodeAt(float horizontalPosition, float verticalPosition, out AccessibilityNode node); // 0x0000000182128CA0-0x0000000182128D40
		internal void RefreshNodeFramesWithoutResetting(); // 0x0000000182128A10-0x0000000182128CA0
		internal void AllocateNative(); // 0x0000000182128870-0x0000000182128940
		internal void FreeNative(); // 0x0000000182128940-0x0000000182128A10
		[CompilerGenerated]
		internal static AccessibilityNode _TryGetNodeAt_g__FindNodeContainingPoint_17_0(IList<AccessibilityNode> nodes, Vector2 pos); // 0x0000000182128DB0-0x0000000182128F80
	}
}
