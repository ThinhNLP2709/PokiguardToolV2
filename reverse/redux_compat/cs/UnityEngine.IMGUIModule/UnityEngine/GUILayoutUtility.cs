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
using UnityEngine.Bindings;
using UnityEngineInternal;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[NativeHeader("Modules/IMGUI/GUILayoutUtility.bindings.h")]
	public class GUILayoutUtility // TypeDefIndex: 13930
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static Dictionary<EntityId, LayoutCache> s_StoredLayouts; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static Dictionary<int, LayoutCache> s_StoredWindows; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		internal static LayoutCache current; // 0x10
		internal static readonly Rect kDummyRect; // 0x18
		[CompilerGenerated]
		private static int _unbalancedgroupscount_k__BackingField; // 0x28
		[NoAutoStaticsCleanup]
		private static GUIStyle s_SpaceStyle; // 0x30
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x38
	
		// Properties
		[NoAutoStaticsCleanup]
		internal static int unbalancedgroupscount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018227F560-0x000000018227F5B0 0x000000018227F5B0-0x000000018227F610
		internal static GUIStyle spaceStyle { get; } // 0x000000018227F410-0x000000018227F560 
	
		// Nested types
		[DebuggerDisplay("id={id}, groups={layoutGroups.Count}")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal sealed class LayoutCache // TypeDefIndex: 13931
		{
			// Fields
			[CompilerGenerated]
			private long _id_k__BackingField; // 0x10
			public GUILayoutGroup topLevel; // 0x18
			internal GenericStack layoutGroups; // 0x20
			internal GUILayoutGroup windows; // 0x28
	
			// Properties
			private long id { [CompilerGenerated] set; } // 0x0000000180719060-0x0000000180719070
	
			// Constructors
			public LayoutCache(int windowID = -1 /* Metadata: 0x006A9141 */); // 0x000000018229B210-0x000000018229B310
			public LayoutCache(EntityId entityId); // 0x000000018229B310-0x000000018229B410
	
			// Methods
			public void ResetCursor(); // 0x000000018229AF90-0x000000018229B210
		}
	
		// Constructors
		static GUILayoutUtility(); // 0x000000018227F1C0-0x000000018227F410
	
		// Methods
		private static Rect Internal_GetWindowRect(int windowID); // 0x000000018227E160-0x000000018227E1E0
		private static void Internal_MoveWindow(int windowID, Rect r); // 0x000000018227E220-0x000000018227E2A0
		internal static LayoutCache GetLayoutCacheWindow(int id); // 0x000000018227DEC0-0x000000018227DF50
		internal static LayoutCache GetLayoutCache(EntityId id); // 0x000000018227DF50-0x000000018227DFE0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static LayoutCache SelectIDListWindow(int id); // 0x000000018227EE50-0x000000018227F010
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static LayoutCache SelectIDListLayout(EntityId ownerEntityId); // 0x000000018227EBB0-0x000000018227EE50
		internal static void RemoveSelectedIdListLayout(EntityId ownerEntityId); // 0x000000018227EB30-0x000000018227EBB0
		internal static void Begin(EntityId instanceID); // 0x000000018227CDE0-0x000000018227D070
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void BeginContainer(LayoutCache cache); // 0x000000018227C1A0-0x000000018227C390
		internal static void BeginWindow(int windowID, GUIStyle style, GUILayoutOption[] options); // 0x000000018227CA80-0x000000018227CDE0
		internal static void Layout(); // 0x000000018227E8B0-0x000000018227EB30
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void LayoutFromContainer(float w, float h); // 0x000000018227E430-0x000000018227E5F0
		internal static void LayoutFreeGroup(GUILayoutGroup toplevel); // 0x000000018227E2A0-0x000000018227E430
		private static void LayoutSingleGroup(GUILayoutGroup i); // 0x000000018227E5F0-0x000000018227E8B0
		private static GUILayoutGroup CreateGUILayoutGroupInstanceOfType(Type LayoutType); // 0x000000018227D070-0x000000018227D1A0
		internal static GUILayoutGroup BeginLayoutGroup(GUIStyle style, GUILayoutOption[] options, Type layoutType); // 0x000000018227C6F0-0x000000018227CA80
		internal static void EndLayoutGroup(); // 0x000000018227DBA0-0x000000018227DEC0
		internal static GUILayoutGroup BeginLayoutArea(GUIStyle style, Type layoutType); // 0x000000018227C390-0x000000018227C6F0
		internal static void EndLayoutArea(); // 0x000000018227D9B0-0x000000018227DBA0
		public static Rect GetRect(GUIContent content, GUIStyle style, params GUILayoutOption[] options); // 0x000000018227E090-0x000000018227E120
		private static Rect DoGetRect(GUIContent content, GUIStyle style, GUILayoutOption[] options); // 0x000000018227D3D0-0x000000018227D9B0
		public static Rect GetRect(float width, float height, GUIStyle style, params GUILayoutOption[] options); // 0x000000018227DFE0-0x000000018227E090
		private static Rect DoGetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style, GUILayoutOption[] options); // 0x000000018227D1A0-0x000000018227D3D0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018227F010-0x000000018227F1C0
		private static void Internal_GetWindowRect_Injected(int windowID, ); // 0x000000018227E120-0x000000018227E160
		private static void Internal_MoveWindow_Injected(int windowID, in Rect r); // 0x000000018227E1E0-0x000000018227E220
	}
}
