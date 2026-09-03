/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	public static class AssistiveSupport // TypeDefIndex: 15626
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static IAccessibilityNotificationDispatcher s_NotificationDispatcher; // 0x00
		[CompilerGenerated]
		private static Action<bool> screenReaderStatusChanged; // 0x08
		[CompilerGenerated]
		private static Action<AccessibilityHierarchy> s_ActiveHierarchyChanged; // 0x10
		[CompilerGenerated]
		private static Action<AccessibilityNode> nodeFocusChanged; // 0x18
		[AutoStaticsCleanupOnCodeReload]
		private static ScreenReaderStatusOverride s_ScreenReaderStatusOverride; // 0x20
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x28
	
		// Properties
		public static IAccessibilityNotificationDispatcher notificationDispatcher { get; } // 0x000000018212F050-0x000000018212F0A0 
		public static AccessibilityHierarchy activeHierarchy { get; } // 0x000000018212EED0-0x000000018212EF60 
		public static bool isScreenReaderEnabled { get; } // 0x000000018212EF60-0x000000018212F050 
		public static ScreenReaderStatusOverride screenReaderStatusOverride { get; } // 0x000000018212F0A0-0x000000018212F0F0 
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool> screenReaderStatusChanged {
			add; // 0x000000018212EDE0-0x000000018212EED0
			remove; // 0x000000018212F2D0-0x000000018212F3C0
		}
		[AutoStaticsCleanupOnCodeReload]
		private static event Action<AccessibilityHierarchy> s_ActiveHierarchyChanged {
			add; // 0x000000018212ECF0-0x000000018212EDE0
			remove; // 0x000000018212F1E0-0x000000018212F2D0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<AccessibilityNode> nodeFocusChanged {
			add; // 0x000000018212EC00-0x000000018212ECF0
			remove; // 0x000000018212F0F0-0x000000018212F1E0
		}
	
		// Nested types
		internal class NotificationDispatcher : IAccessibilityNotificationDispatcher // TypeDefIndex: 15627
		{
			// Constructors
			public NotificationDispatcher(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void SendScreenChanged(AccessibilityNode nodeToFocus = null); // 0x000000018212F770-0x000000018212F850
			public void SendLayoutChanged(AccessibilityNode nodeToFocus = null); // 0x000000018212F6F0-0x000000018212F770
		}
	
		public enum ScreenReaderStatusOverride : byte // TypeDefIndex: 15628
		{
			OSDriven = 0,
			ForceEnabled = 1,
			ForceDisabled = 2
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15629
		{
			// Fields
			public static Action<bool> _0___ScreenReaderStatusChanged; // 0x00
			public static Action<AccessibilityNode> _1___NodeFocusChanged; // 0x08
		}
	
		// Constructors
		static AssistiveSupport(); // 0x000000018212EA90-0x000000018212EC00
	
		// Methods
		[ExcludeFromCodeCoverage]
		internal static void Initialize(); // 0x000000018212DEE0-0x000000018212E1D0
		internal static void ScreenReaderStatusChanged(bool enabled); // 0x000000018212E250-0x000000018212E530
		private static void NodeFocusChanged(AccessibilityNode currentNode); // 0x000000018212E1D0-0x000000018212E250
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018212E530-0x000000018212EA90
	}
}
