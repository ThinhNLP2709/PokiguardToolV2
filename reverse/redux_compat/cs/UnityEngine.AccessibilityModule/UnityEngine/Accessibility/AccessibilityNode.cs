/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	public class AccessibilityNode // TypeDefIndex: 15632
	{
		// Fields
		[CompilerGenerated]
		private Action<AccessibilityNode, bool> focusChanged; // 0x10
		[CompilerGenerated]
		private Func<bool> invoked; // 0x18
		[CompilerGenerated]
		private Action incremented; // 0x20
		[CompilerGenerated]
		private Action decremented; // 0x28
		[CompilerGenerated]
		private Func<AccessibilityScrollDirection, bool> scrolled; // 0x30
		[CompilerGenerated]
		private Func<bool> dismissed; // 0x38
		private AccessibilityHierarchy m_Hierarchy; // 0x40
		internal List<AccessibilityNode> childList; // 0x48
		[CompilerGenerated]
		private AccessibilityNode _parent_k__BackingField; // 0x50
		private string m_Label; // 0x58
		private string m_Value; // 0x60
		private string m_Hint; // 0x68
		private Rect m_Frame; // 0x70
		private Func<Rect> m_FrameGetter; // 0x80
		[CompilerGenerated]
		private int _id_k__BackingField; // 0x88
		private AccessibilityRole m_Role; // 0x8C
		private AccessibilityState m_State; // 0x8D
		private bool m_IsActive; // 0x8E
		private bool m_AllowsDirectInteraction; // 0x8F
	
		// Properties
		public IReadOnlyList<AccessibilityNode> children { get; } // 0x00000001803272B0-0x00000001803272C0 
		public AccessibilityNode parent { [CompilerGenerated] get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public string label { get; } // 0x00000001802F4000-0x00000001802F4010 
		public string value { get; } // 0x0000000180333260-0x0000000180333490 
		public string hint { get; } // 0x0000000180316960-0x0000000180316970 
		public Rect frame { get; set; } // 0x000000018212CCA0-0x000000018212CDE0 0x000000018212CE00-0x000000018212CEA0
		public Func<Rect> frameGetter { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public int id { [CompilerGenerated] get; } // 0x000000018033D620-0x000000018033D630 
		public AccessibilityRole role { get; } // 0x00000001814CB7E0-0x00000001814CB7F0 
		public AccessibilityState state { get; } // 0x000000018212CDF0-0x000000018212CE00 
		public bool isActive { get; } // 0x000000018212CDE0-0x000000018212CDF0 
		public bool allowsDirectInteraction { get; } // 0x000000018212CC90-0x000000018212CCA0 
	
		// Methods
		private void CreateNativeNodeWithData(ref AccessibilityNodeData nodeData); // 0x000000018212C300-0x000000018212C480
		internal void GetNodeData(ref AccessibilityNodeData nodeData); // 0x000000018212C6E0-0x000000018212C9F0
		internal void AllocateNative(); // 0x000000018212BE10-0x000000018212C300
		internal void FreeNative(bool freeChildren); // 0x000000018212C480-0x000000018212C6E0
		private bool IsInActiveHierarchy(); // 0x000000018212CAD0-0x000000018212CB30
		internal void NotifyFocusChanged(bool isNodeFocused); // 0x000000018212CB30-0x000000018212CC90
		internal void InvokeFocusChanged(bool isNodeFocused); // 0x000000018212CA40-0x000000018212CA60
		internal bool InvokeNodeInvoked(); // 0x000000018212CA90-0x000000018212CAB0
		internal bool InvokeIncremented(); // 0x000000018212CA60-0x000000018212CA90
		internal bool InvokeDecremented(); // 0x000000018212C9F0-0x000000018212CA20
		internal bool InvokeScrolled(AccessibilityScrollDirection direction); // 0x000000018212CAB0-0x000000018212CAD0
		internal bool InvokeDismissed(); // 0x000000018212CA20-0x000000018212CA40
	}
}
