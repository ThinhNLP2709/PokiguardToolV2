/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[AddComponentMenu("UI Toolkit/Panel Renderer (UI Toolkit)")]
	[ExtensionOfNativeClass]
	[HelpURL("ui-systems/panel-renderer-component")]
	[NativeClass("PanelRenderer", PersistentTypeId = 1931382934)]
	[NativeHeader("Modules/UIElements/Core/Native/Renderer/PanelRenderer.h")]
	public sealed class PanelRenderer : Renderer, IPanelComponent // TypeDefIndex: 4244
	{
		// Fields
		private PanelRendererRootElement m_RootVisualElement; // 0x18
		private VisualElementReferenceProvider m_ReferenceProvider; // 0x20
		private UIReloadCallback m_OnUIReloadCallback; // 0x28
		private VersionedUIReloadCallback m_OnVersionedUIReloadCallback; // 0x30
		private int m_UIVersion; // 0x38
		private bool m_UIReloadCallbackPending; // 0x3C
		private bool m_RequiresReinsertion; // 0x3D
		private bool m_IsAssetDirty; // 0x3E
		[CompilerGenerated]
		private PanelSettings _previousPanelSettings_k__BackingField; // 0x40
		[CompilerGenerated]
		private VisualTreeAsset _previousVisualTreeAsset_k__BackingField; // 0x48
		private int m_PreviousVisualTreeAssetContentHash; // 0x50
		[CompilerGenerated]
		private bool _previousEnabled_k__BackingField; // 0x54
		[CompilerGenerated]
		private int _previousSortingOrder_k__BackingField; // 0x58
		private int m_SoftPointerCaptures; // 0x5C
		[CompilerGenerated]
		private VisualElementFocusRing _UnityEngine_UIElements_IPanelComponent_focusRing_k__BackingField; // 0x60
		private int m_FirstChildInsertIndex; // 0x68
		[NoAutoStaticsCleanup]
		private static int s_CurrentPanelRendererCounter; // 0x00
		private int m_PanelRendererCreationIndex; // 0x6C
		private BoxCollider m_WorldSpaceCollider; // 0x70
		internal List<CommandList>[] commandLists; // 0x78
		[NoAutoStaticsCleanup]
		internal static bool shouldCheckForRequiredReinsertions; // 0x04
		private PanelComponentList m_ChildrenContent; // 0x80
		private bool m_RootHasWorldTransform; // 0x88
	
		// Properties
		public PanelSettings panelSettings { get; set; } // 0x00000001824B9950-0x00000001824B9C70 0x00000001824BA0D0-0x00000001824BA2E0
		public VisualTreeAsset visualTreeAsset { get; } // 0x00000001824B9D10-0x00000001824B9E10 
		internal PanelRendererRootElement rootVisualElement { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElementReferenceProvider referenceProvider { get; } // 0x00000001824B9CA0-0x00000001824B9D10 
		private ScriptableObject nativePanelSettings { get; set; } // 0x00000001824B93F0-0x00000001824B9480 0x00000001824B9F80-0x00000001824BA000
		private ScriptableObject nativeVisualTreeAsset { get; } // 0x00000001824B96E0-0x00000001824B9770 
		private PanelRenderer nativeParentUI { get; set; } // 0x00000001824B8930-0x00000001824B89C0 0x00000001824BA050-0x00000001824BA0D0
		private int nativeWorldSpaceSizeMode { get; } // 0x00000001824B9850-0x00000001824B98B0 
		private float nativeWorldSpaceSizeWidth { get; } // 0x00000001824B98F0-0x00000001824B9950 
		private float nativeWorldSpaceSizeHeight { get; } // 0x00000001824B97B0-0x00000001824B9810 
		private int nativePivotReferenceSize { get; } // 0x00000001824B9500-0x00000001824B9560 
		private int nativePivot { get; } // 0x00000001824B95A0-0x00000001824B9600 
		private int nativePosition { get; } // 0x00000001824B9640-0x00000001824B96A0 
		internal bool requiresReinsertion { get; set; } // 0x0000000182141F90-0x0000000182141FA0 0x00000001824BA2E0-0x00000001824BA360
		internal bool isAssetDirty { set; } // 0x00000001824B9EC0-0x00000001824B9F30
		internal PanelSettings previousPanelSettings { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		internal VisualTreeAsset previousVisualTreeAsset { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		internal bool previousEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D250-0x000000018033D260 0x000000018033E860-0x000000018033E870
		internal int previousSortingOrder { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		float IPanelComponent.sortingOrder { get; } // 0x00000001824B89C0-0x00000001824B89E0 
		int IPanelComponent.softPointerCaptures { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		VisualElementFocusRing IPanelComponent.focusRing { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public WorldSpaceSizeMode worldSpaceSizeMode { get; } // 0x00000001824B9850-0x00000001824B98B0 
		public Vector2 worldSpaceSize { get; } // 0x00000001824B9E10-0x00000001824B9EC0 
		public Position position { get; } // 0x00000001824B9640-0x00000001824B96A0 
		public PivotReferenceSize pivotReferenceSize { get; } // 0x00000001824B9500-0x00000001824B9560 
		public Pivot pivot { get; } // 0x00000001824B95A0-0x00000001824B9600 
		public PanelRenderer parentUI { get; private set; } // 0x00000001824B8930-0x00000001824B89C0 0x00000001824BA050-0x00000001824BA0D0
		IPanelComponent IPanelComponent.parentUI { get; } // 0x00000001824B8930-0x00000001824B89C0 
		internal int firstChildInsertIndex { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
		int IPanelComponent.creationIndex { get; } // 0x0000000180C55C40-0x0000000180C55C50 
		internal RuntimePanel containerPanel { get; } // 0x00000001824B92A0-0x00000001824B9320 
		GameObject IPanelComponent.gameObject { get; } // 0x00000001824B8920-0x00000001824B8930 
		private bool isWorldSpace { get; } // 0x00000001824B9320-0x00000001824B93B0 
		internal float pixelsPerUnit { get; } // 0x00000001824B9C70-0x00000001824B9CA0 
	
		// Nested types
		[Obsolete("This callback type is deprecated. Use VersionedUIReloadCallback instead, which provides a version number so the callback can skip redundant work when the UI has not actually changed.")]
		public delegate void UIReloadCallback(PanelRenderer panelRenderer, VisualElement rootElement); // TypeDefIndex: 4245; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void VersionedUIReloadCallback(PanelRenderer panelRenderer, VisualElement rootElement, int version); // TypeDefIndex: 4246; 0x0000000180A72B30-0x0000000180A72B50
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass166_0 // TypeDefIndex: 4247
		{
			// Fields
			public UIAnimationBinder binder; // 0x10
	
			// Constructors
			public __c__DisplayClass166_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ConnectToAnimationBinder_b__0(PanelRenderer pr, VisualElement root, int version); // 0x00000001824BE570-0x00000001824BE5E0
		}
	
		// Methods
		VisualElement IPanelComponent.GetRootVisualElement(); // 0x00000001802F8EC0-0x00000001802F8ED0
		IEventHandler IPanelComponent.GetRoot(); // 0x00000001824B8810-0x00000001824B8850
		public void RegisterUIReloadCallback(VersionedUIReloadCallback callback); // 0x00000001824B6D60-0x00000001824B6EA0
		private void InvokeUIReloadCallbacks(); // 0x00000001824B6740-0x00000001824B67C0
		void IPanelComponent.SetComponentEnabled(bool enabled); // 0x00000001824B8910-0x00000001824B8920
		bool IPanelComponent.GetComponentEnabled(); // 0x00000001824B8770-0x00000001824B8780
		Vector3 IPanelComponent.GetPanelPosition(IEventHandler pickedElement, Ray worldRay); // 0x00000001824B8790-0x00000001824B8810
		internal void AddDrawCallData(int safeFrameIndex, Material mat, uint textureSlotCount, uint forceRenderType, IntPtr serializedCommandsPtr, int commandCount, CommandListState state); // 0x00000001824B54D0-0x00000001824B55A0
		internal void ResetDrawCallData(int safeFrameIndex); // 0x00000001824B7280-0x00000001824B72E0
		internal void ResetAllDrawCallData(); // 0x00000001824B71E0-0x00000001824B7240
		[RequiredByNativeCode(Optional = true)]
		private void OnPanelRendererAwake(); // 0x00000001824B6800-0x00000001824B6910
		[RequiredByNativeCode(Optional = true)]
		private void OnPanelRendererCleanup(); // 0x00000001824B6920-0x00000001824B6A10
		[RequiredByNativeCode(Optional = true)]
		private void OnPanelRendererDeactivated(); // 0x00000001824B6A10-0x00000001824B6AA0
		[RequiredByNativeCode(Optional = true)]
		private void OnPanelRendererCheckConsistency(); // 0x00000001824B6910-0x00000001824B6920
		private void SetAllDirty(); // 0x00000001824B72E0-0x00000001824B73A0
		private bool IsActiveAndEnabled(); // 0x00000001824B67C0-0x00000001824B6800
		internal void RefreshAssets(); // 0x00000001824B6C30-0x00000001824B6D60
		private void InitRootVisualElement(bool visualTreeAssetChanged = false /* Metadata: 0x00660654 */); // 0x00000001824B6110-0x00000001824B6740
		internal void SetupFromHierarchy(); // 0x00000001824B7AF0-0x00000001824B7DB0
		private PanelRenderer FindParentPanelRenderer(); // 0x00000001824B5F80-0x00000001824B6040
		internal void AddRootVisualElementToTree(); // 0x00000001824B55A0-0x00000001824B58E0
		private void AddChildAndInsertContentToVisualTree(PanelRenderer child); // 0x00000001824B5300-0x00000001824B5470
		internal void RemoveFromHierarchy(); // 0x00000001824B6F40-0x00000001824B7130
		internal void ReactToHierarchyChanges(); // 0x00000001824B6B90-0x00000001824B6C30
		private void RemoveChild(PanelRenderer child); // 0x00000001824B6EA0-0x00000001824B6F40
		internal void SetupPosition(); // 0x00000001824B7DB0-0x00000001824B7FB0
		IRuntimePanel IPanelComponent.GetContainerPanel(); // 0x00000001824B8780-0x00000001824B8790
		void IPanelComponent.PerformValidation(bool forced); // 0x00000001824B6910-0x00000001824B6920
		void IPanelComponent.PerformUpdate(); // 0x00000001824B8850-0x00000001824B8910
		private void SetTransform(); // 0x00000001824B73A0-0x00000001824B7AF0
		private void ClearTransform(); // 0x00000001824B58E0-0x00000001824B5CB0
		internal Vector2 PivotOffset(); // 0x00000001824B6AA0-0x00000001824B6B90
		private void UpdateLocalBounds(); // 0x00000001824B8B70-0x00000001824B8DD0
		internal void UpdateWorldSpaceCollider(ColliderUpdateMode mode); // 0x00000001824B8DD0-0x00000001824B92A0
		internal void RemoveWorldSpaceCollider(); // 0x00000001824B7130-0x00000001824B71A0
		private void UpdateIsWorldSpaceRootFlag(); // 0x00000001824B89E0-0x00000001824B8B70
		internal void SetupRootClassList(); // 0x00000001824B7FB0-0x00000001824B8300
		private void SetupWorldSpaceSize(); // 0x00000001824B8300-0x00000001824B8770
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal UIAnimationBinder GetAnimationBinder(); // 0x00000001824B6080-0x00000001824B6110
		[RequiredByNativeCode(Optional = true)]
		internal void ConnectToAnimationBinder(); // 0x00000001824B5CB0-0x00000001824B5F80
		private static IntPtr get_nativePanelSettings_Injected(IntPtr _unity_self); // 0x00000001824B93B0-0x00000001824B93F0
		private static void set_nativePanelSettings_Injected(IntPtr _unity_self, IntPtr value); // 0x00000001824B9F30-0x00000001824B9F80
		private static IntPtr get_nativeVisualTreeAsset_Injected(IntPtr _unity_self); // 0x00000001824B96A0-0x00000001824B96E0
		private static IntPtr get_nativeParentUI_Injected(IntPtr _unity_self); // 0x00000001824B9480-0x00000001824B94C0
		private static void set_nativeParentUI_Injected(IntPtr _unity_self, IntPtr value); // 0x00000001824BA000-0x00000001824BA050
		private static int get_nativeWorldSpaceSizeMode_Injected(IntPtr _unity_self); // 0x00000001824B9810-0x00000001824B9850
		private static float get_nativeWorldSpaceSizeWidth_Injected(IntPtr _unity_self); // 0x00000001824B98B0-0x00000001824B98F0
		private static float get_nativeWorldSpaceSizeHeight_Injected(IntPtr _unity_self); // 0x00000001824B9770-0x00000001824B97B0
		private static int get_nativePivotReferenceSize_Injected(IntPtr _unity_self); // 0x00000001824B94C0-0x00000001824B9500
		private static int get_nativePivot_Injected(IntPtr _unity_self); // 0x00000001824B9560-0x00000001824B95A0
		private static int get_nativePosition_Injected(IntPtr _unity_self); // 0x00000001824B9600-0x00000001824B9640
		private static void AddDrawCallData_Injected(IntPtr _unity_self, int safeFrameIndex, IntPtr mat, uint textureSlotCount, uint forceRenderType, IntPtr serializedCommandsPtr, int commandCount, in CommandListState state); // 0x00000001824B5470-0x00000001824B54D0
		private static void ResetDrawCallData_Injected(IntPtr _unity_self, int safeFrameIndex); // 0x00000001824B7240-0x00000001824B7280
		private static void ResetAllDrawCallData_Injected(IntPtr _unity_self); // 0x00000001824B71A0-0x00000001824B71E0
		private static IntPtr GetAnimationBinder_Injected(IntPtr _unity_self); // 0x00000001824B6040-0x00000001824B6080
	}
}
