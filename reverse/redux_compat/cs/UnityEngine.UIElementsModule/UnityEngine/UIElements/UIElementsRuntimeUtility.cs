/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal static class UIElementsRuntimeUtility // TypeDefIndex: 4866
	{
		// Fields
		[CompilerGenerated]
		private static Action<IRuntimePanel> onCreatePanel; // 0x00
		[CompilerGenerated]
		private static Action<IRuntimePanel> onWillDestroyPanel; // 0x08
		public static readonly ProfilerMarker s_PreUpdatePanelRenderersMarker; // 0x10
		public static readonly ProfilerMarker s_UpdatePanelRenderersMarker; // 0x18
		private static bool s_RegisteredPlayerloopCallback; // 0x20
		private static readonly List<BaseRuntimePanel> s_SortedScreenOverlayPanels; // 0x28
		private static readonly List<BaseRuntimePanel> s_CachedWorldSpacePanels; // 0x30
		private static readonly List<BaseRuntimePanel> s_SortedPlayerPanels; // 0x38
		private static bool s_PanelOrderingOrDrawInCameraDirty; // 0x40
		internal static int s_ResolvedSortingIndexMax; // 0x44
		private static readonly HashSet<PanelRenderer> s_AllPanelRenderers; // 0x48
		private static readonly HashSet<PanelRenderer> s_DirtyPanelRenderers; // 0x50
		private static int currentOverlayIndex; // 0x58
		[CompilerGenerated]
		private static UnityEngine.Object _activeEventSystem_k__BackingField; // 0x60
		[CompilerGenerated]
		private static bool? _overrideUseDefaultEventSystem_k__BackingField; // 0x68
		[CompilerGenerated]
		private static bool _autoUpdateEventSystem_k__BackingField; // 0x6A
		[CompilerGenerated]
		private static DefaultEventSystem.UpdateMode _eventSystemUpdateMode_k__BackingField; // 0x6C
		private static DefaultEventSystem s_DefaultEventSystem; // 0x70
		private static List<PanelSettings> s_PotentiallyEmptyPanelSettings; // 0x78
	
		// Properties
		internal static UnityEngine.Object activeEventSystem { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001823DBF50-0x00000001823DBFA0 0x00000001823DC350-0x00000001823DC3C0
		internal static bool useDefaultEventSystem { get; } // 0x00000001823DC150-0x00000001823DC260 
		internal static bool? overrideUseDefaultEventSystem { [CompilerGenerated] get; } // 0x00000001823DC100-0x00000001823DC150 
		internal static bool autoUpdateEventSystem { [CompilerGenerated] get; } // 0x00000001823DBFA0-0x00000001823DBFF0 
		internal static DefaultEventSystem.UpdateMode eventSystemUpdateMode { [CompilerGenerated] get; } // 0x00000001823DC0B0-0x00000001823DC100 
		internal static DefaultEventSystem defaultEventSystem { get; } // 0x00000001823DBFF0-0x00000001823DC0B0 
	
		// Events
		public static event Action<IRuntimePanel> onCreatePanel {
			add; // 0x00000001823DBE60-0x00000001823DBF50
			remove; // 0x00000001823DC260-0x00000001823DC350
		}
	
		// Nested types
		public delegate BaseRuntimePanel CreateRuntimePanelDelegate(ScriptableObject ownerObject); // TypeDefIndex: 4867; 0x00000001804A78A0-0x00000001804A78B0
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4868
		{
			// Fields
			public static Action<bool> _0___RepaintPanels; // 0x00
			public static Action _1___RenderOffscreenPanels; // 0x08
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4869
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<BaseRuntimePanel> __9__84_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001823D3AD0-0x00000001823D3B40
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__14_0(int displayIndex, int sortOrder); // 0x00000001823D34C0-0x00000001823D3520
			internal int _SortPanels_b__84_0(BaseRuntimePanel runtimePanelA, BaseRuntimePanel runtimePanelB); // 0x00000001823D3380-0x00000001823D3420
		}
	
		// Constructors
		static UIElementsRuntimeUtility(); // 0x00000001823DB890-0x00000001823DBE60
	
		// Methods
		public static bool AnyOverlayPanelHasBackdropFilter(); // 0x00000001823D81D0-0x00000001823D8340
		public static BaseRuntimePanel FindOrCreateRuntimePanel(ScriptableObject ownerObject, CreateRuntimePanelDelegate createDelegate); // 0x00000001823D8770-0x00000001823D89E0
		public static void DisposeRuntimePanel(ScriptableObject ownerObject); // 0x00000001823D8410-0x00000001823D85C0
		private static void GetPlayerPanelsByRenderMode(List<BaseRuntimePanel> outScreenSpaceOverlayPanels, List<BaseRuntimePanel> outWorldSpacePanels); // 0x00000001823D8A00-0x00000001823D8C90
		private static void RegisterCachedPanelInternal(EntityId entityId, IPanel panel); // 0x00000001823D97C0-0x00000001823D9A80
		private static void RemoveCachedPanelInternal(EntityId entityId); // 0x00000001823D9CA0-0x00000001823D9F20
		public static void RenderOffscreenPanels(); // 0x00000001823DA160-0x00000001823DA3B0
		public static void RepaintPanel(BaseRuntimePanel panel); // 0x00000001823DA6C0-0x00000001823DA760
		public static void RenderPanel(BaseRuntimePanel panel, bool restoreState = true /* Metadata: 0x0066080A */); // 0x00000001823DA5C0-0x00000001823DA6C0
		internal static void BeginRenderOverlays(int displayIndex); // 0x00000001823D8340-0x00000001823D83A0
		internal static void RenderOverlaysBeforePriority(int displayIndex, float maxPriority); // 0x00000001823DA3B0-0x00000001823DA5C0
		internal static void EndRenderOverlays(int displayIndex); // 0x00000001823D8700-0x00000001823D8770
		public static void RepaintPanels(bool onlyOffscreen); // 0x00000001823DA760-0x00000001823DA970
		public static void RegisterEventSystem(UnityEngine.Object eventSystem); // 0x00000001823D9A80-0x00000001823D9CA0
		public static void UnregisterEventSystem(UnityEngine.Object eventSystem); // 0x00000001823DAFB0-0x00000001823DB0E0
		public static void UpdatePanels(); // 0x00000001823DB2D0-0x00000001823DB5F0
		private static void _UpdateEventSystem(); // 0x00000001823DB640-0x00000001823DB890
		internal static void MarkPotentiallyEmpty(PanelSettings settings); // 0x00000001823D9120-0x00000001823D9230
		internal static void MarkPanelRendererDirty(PanelRenderer panelRenderer); // 0x00000001823D9080-0x00000001823D9120
		internal static void RemovePanelRenderer(PanelRenderer panelRenderer); // 0x00000001823D9F20-0x00000001823D9FF0
		private static void PreUpdatePanelRenderers(); // 0x00000001823D9310-0x00000001823D97C0
		private static void UpdatePanelRenderers(); // 0x00000001823DB180-0x00000001823DB2D0
		private static void UpdateEnabledState(PanelRenderer panelRenderer); // 0x00000001823DB0E0-0x00000001823DB180
		private static void UpdateSortingOrder(PanelRenderer panelRenderer); // 0x00000001823DB5F0-0x00000001823DB640
		internal static void RemoveUnusedPanels(); // 0x00000001823D9FF0-0x00000001823DA160
		public static void EnableRenderingAndInputCallbacks(); // 0x00000001823D85C0-0x00000001823D8700
		public static void DisableRenderingAndInputCallbacks(); // 0x00000001823D83A0-0x00000001823D8410
		internal static void SetPanelOrderingDirty(); // 0x00000001823DA970-0x00000001823DA9C0
		internal static void SetPanelsDrawInCameraDirty(); // 0x00000001823DA9C0-0x00000001823DAA10
		internal static List<BaseRuntimePanel> GetWorldSpacePlayerPanels(); // 0x00000001823D9010-0x00000001823D9080
		public static List<BaseRuntimePanel> GetSortedScreenOverlayPlayerPanels(); // 0x00000001823D8FA0-0x00000001823D9010
		public static List<BaseRuntimePanel> GetSortedPlayerPanels(); // 0x00000001823D8F30-0x00000001823D8FA0
		internal static List<IRuntimePanel> GetSortedPlayerPanelsInternal(); // 0x00000001823D8D40-0x00000001823D8F30
		private static void SortPanels(); // 0x00000001823DAA10-0x00000001823DAFB0
		internal static Vector2 PanelToScreenBottomLeftPosition(Vector2 panelPosition, int targetDisplay); // 0x00000001823D9230-0x00000001823D9310
		internal static Vector2 FlipY(Vector2 p, float displayHeight); // 0x00000001823D89E0-0x00000001823D8A00
		internal static float GetScreenHeightForDisplay(int targetDisplay); // 0x00000001823D8C90-0x00000001823D8D40
	}
}
