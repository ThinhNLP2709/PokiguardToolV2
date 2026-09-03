/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	[NativeHeader("Modules/Accessibility/Native/AccessibilityManager.h")]
	[VisibleToOtherModules(new string[1] {"UnityEditor.AccessibilityModule" })]
	internal class AccessibilityManager // TypeDefIndex: 15614
	{
		// Fields
		[CompilerGenerated]
		private static Action<bool> screenReaderStatusChanged; // 0x00
		[CompilerGenerated]
		private static Action<AccessibilityNode> nodeFocusChanged; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		internal static Queue<NotificationContext> asyncNotificationContexts; // 0x10
		private bool m_RefreshNodeFramesRequested; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Properties
		public static AccessibilityManager instance { get; } // 0x000000018212B140-0x000000018212B190 
		public static bool isSupportedPlatform { get; } // 0x000000018212B190-0x000000018212B1F0 
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool> screenReaderStatusChanged {
			add; // 0x000000018212B050-0x000000018212B140
			remove; // 0x000000018212B2E0-0x000000018212B3D0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<AccessibilityNode> nodeFocusChanged {
			add; // 0x000000018212AF60-0x000000018212B050
			remove; // 0x000000018212B1F0-0x000000018212B2E0
		}
	
		// Nested types
		public enum Notification : byte // TypeDefIndex: 15615
		{
			None = 0,
			ScreenReaderStatusChanged = 1,
			ElementFocused = 2,
			ElementUnfocused = 3,
			FontScaleChanged = 4,
			BoldTextStatusChanged = 5,
			ClosedCaptioningStatusChanged = 6
		}
	
		public struct NotificationContext // TypeDefIndex: 15616
		{
			// Fields
			[CompilerGenerated]
			private AccessibilityNode _focusedNode_k__BackingField; // 0x00
			[CompilerGenerated]
			private float _fontScale_k__BackingField; // 0x08
			[CompilerGenerated]
			private bool _isBoldTextEnabled_k__BackingField; // 0x0C
			[CompilerGenerated]
			private bool _isClosedCaptioningEnabled_k__BackingField; // 0x0D
			[CompilerGenerated]
			private bool _isScreenReaderEnabled_k__BackingField; // 0x0E
			[CompilerGenerated]
			private Notification _notification_k__BackingField; // 0x0F
	
			// Properties
			public AccessibilityNode focusedNode { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
			public float fontScale { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
			public bool isBoldTextEnabled { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000181D11B10-0x0000000181D11B20 0x000000018212F6B0-0x000000018212F6C0
			public bool isClosedCaptioningEnabled { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018212F690-0x000000018212F6A0 0x000000018212F6C0-0x000000018212F6D0
			public bool isScreenReaderEnabled { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D11B00-0x0000000181D11B10 0x000000018212F6D0-0x000000018212F6E0
			public Notification notification { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x000000018212F6A0-0x000000018212F6B0 0x000000018212F6E0-0x000000018212F6F0
		}
	
		private class Nested // TypeDefIndex: 15617
		{
			// Fields
			[NoAutoStaticsCleanup]
			internal static readonly AccessibilityManager s_Instance; // 0x00
	
			// Constructors
			static Nested(); // 0x000000018212F610-0x000000018212F690
		}
	
		private sealed class ExclusiveLock : IDisposable // TypeDefIndex: 15618
		{
			// Fields
			private bool m_Disposed; // 0x10
	
			// Constructors
			public ExclusiveLock(); // 0x000000018212F5A0-0x000000018212F610
	
			// Methods
			~ExclusiveLock(); // 0x000000018212F470-0x000000018212F530
			private void InternalDispose(); // 0x000000018212F530-0x000000018212F5A0
			public void Dispose(); // 0x000000018212F3C0-0x000000018212F470
		}
	
		// Constructors
		private AccessibilityManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static AccessibilityManager(); // 0x000000018212ADE0-0x000000018212AF60
	
		// Methods
		internal static bool IsScreenReaderEnabled(); // 0x000000018212A620-0x000000018212A650
		internal static void SendScreenChangedNotification(int nodeId = -1 /* Metadata: 0x006AA0FC */); // 0x000000018212A8B0-0x000000018212A8F0
		internal static void SendLayoutChangedNotification(int nodeId = -1 /* Metadata: 0x006AA0FD */); // 0x000000018212A870-0x000000018212A8B0
		[ExcludeFromCodeCoverage]
		[RequiredByNativeCode]
		[VisibleToOtherModules(new string[1] {"UnityEditor.AccessibilityModule" })]
		internal static void Internal_Initialize(); // 0x0000000182129D70-0x0000000182129DB0
		[RequiredByNativeCode]
		internal static void Internal_Update(); // 0x000000018212A590-0x000000018212A620
		private void Internal_Update_Impl(); // 0x000000018212A070-0x000000018212A590
		[RequiredByNativeCode]
		internal static void Internal_LateUpdate(); // 0x0000000182129DB0-0x0000000182129ED0
		[RequiredByNativeCode]
		internal static int[] Internal_GetRootNodeIds(); // 0x0000000182129960-0x0000000182129D70
		[FreeFunction("SetAccessibilityNodeDataPtr", IsThreadSafe = true)]
		[NativeHeader("Modules/Accessibility/Native/AccessibilityManager.h")]
		internal static void SetAccessibilityNodeDataPtr(IntPtr destNodeDataPtr, AccessibilityNodeData sourceNodeData); // 0x000000018212A940-0x000000018212A9C0
		internal static bool Internal_GetNode(int nodeId, out AccessibilityNodeData nodeData); // 0x0000000182129880-0x0000000182129960
		[RequiredByNativeCode]
		private static bool Internal_GetNode_Native(int nodeId, IntPtr nodeDataPtr); // 0x00000001821296D0-0x0000000182129880
		[RequiredByNativeCode]
		internal static int Internal_GetNodeIdAt(float x, float y); // 0x0000000182129580-0x00000001821296D0
		[RequiredByNativeCode]
		internal static bool Internal_GetFirstOrLastRootNodeId(bool first, out int managedRootId); // 0x00000001821291F0-0x0000000182129330
		[RequiredByNativeCode]
		internal static bool Internal_GetFirstOrLastChildId(int nodeId, bool first, out int childId); // 0x00000001821290B0-0x00000001821291F0
		[RequiredByNativeCode]
		internal static bool Internal_GetNextOrPreviousSiblingId(int nodeId, bool next, out int siblingId); // 0x0000000182129330-0x0000000182129580
		[RequiredByNativeCode]
		internal static void Internal_OnScreenReaderStatusChanged(bool enabled); // 0x0000000182129ED0-0x0000000182129FE0
		[RequiredByNativeCode]
		internal static void Internal_OnWindowGeometryChanged(); // 0x0000000182129FE0-0x000000018212A070
		internal static void QueueNotification(NotificationContext notification); // 0x000000018212A7C0-0x000000018212A870
		internal void QueueNotification_Impl(NotificationContext notification); // 0x000000018212A680-0x000000018212A7C0
		internal static IDisposable GetExclusiveLock(); // 0x0000000182129010-0x00000001821290B0
		[NativeMethod(IsThreadSafe = true)]
		private static void Lock(); // 0x000000018212A650-0x000000018212A680
		[NativeMethod(IsThreadSafe = true)]
		private static void Unlock(); // 0x000000018212A9C0-0x000000018212A9F0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018212A9F0-0x000000018212ADE0
		[CompilerGenerated]
		internal static int _Internal_GetNextOrPreviousSiblingId_g__IndexOf_32_0<T>(T elementToFind, IReadOnlyList<T> list);
		private static void SetAccessibilityNodeDataPtr_Injected(IntPtr destNodeDataPtr, in AccessibilityNodeData sourceNodeData); // 0x000000018212A8F0-0x000000018212A940
	}
}
