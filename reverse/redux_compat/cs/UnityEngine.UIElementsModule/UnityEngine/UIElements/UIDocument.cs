/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[AddComponentMenu("UI Toolkit/Legacy/UI Document (UI Toolkit)")]
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[HelpURL("UIE-get-started-with-runtime-ui")]
	public sealed class UIDocument : MonoBehaviour, IPanelComponent // TypeDefIndex: 4212
	{
		// Fields
		internal static readonly UniqueStyleString rootStyleClassNameUnique; // 0x00
		internal const string k_VisualElementNameSuffix = "-container"; // Metadata: 0x00660596
		internal const string k_EditorElementsWarningMessage = "The VisualTreeAsset contains editor-only elements that are incompatible at runtime.\nTo fix this, remove the editor elements from the VisualTreeAsset."; // Metadata: 0x006605A1
		private const int k_DefaultSortingOrder = 0; // Metadata: 0x00660638
		private static int s_CurrentUIDocumentCounter; // 0x04
		internal readonly int m_UIDocumentCreationIndex; // 0x20
		internal static int EnabledDocumentCount; // 0x08
		[SerializeField]
		private PanelSettings m_PanelSettings; // 0x28
		private PanelSettings m_PreviousPanelSettings; // 0x30
		[SerializeField]
		private UIDocument m_ParentUI; // 0x38
		private PanelComponentList m_ChildrenContent; // 0x40
		private List<IPanelComponent> m_ChildrenContentCopy; // 0x48
		[SerializeField]
		private VisualTreeAsset sourceAsset; // 0x50
		private UIDocumentRootElement m_RootVisualElement; // 0x58
		[CompilerGenerated]
		private VisualElementFocusRing _UnityEngine_UIElements_IPanelComponent_focusRing_k__BackingField; // 0x60
		private int m_SoftPointerCaptures; // 0x68
		private int m_FirstChildInsertIndex; // 0x6C
		[SerializeField]
		private float m_SortingOrder; // 0x70
		[SerializeField]
		private Position m_Position; // 0x74
		[SerializeField]
		private WorldSpaceSizeMode m_WorldSpaceSizeMode; // 0x78
		[SerializeField]
		private float m_WorldSpaceWidth; // 0x7C
		[SerializeField]
		private float m_WorldSpaceHeight; // 0x80
		[SerializeField]
		private PivotReferenceSize m_PivotReferenceSize; // 0x84
		[SerializeField]
		private Pivot m_Pivot; // 0x88
		[HideInInspector]
		[SerializeField]
		private BoxCollider m_WorldSpaceCollider; // 0x90
		private bool m_RootHasWorldTransform; // 0x98
	
		// Properties
		int IPanelComponent.creationIndex { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public PanelSettings panelSettings { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001824C9360-0x00000001824C96B0
		public UIDocument parentUI { get; private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		IPanelComponent IPanelComponent.parentUI { get; } // 0x00000001803272A0-0x00000001803272B0 
		public VisualTreeAsset visualTreeAsset { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001824C9810-0x00000001824C9840
		public VisualElement rootVisualElement { get; private set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001824C96C0-0x00000001824C97F0
		VisualElementFocusRing IPanelComponent.focusRing { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		int IPanelComponent.softPointerCaptures { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
		internal int firstChildInsertIndex { get; } // 0x0000000180C55C40-0x0000000180C55C50 
		public Position position { get; set; } // 0x0000000181974810-0x0000000181974820 0x00000001824C96B0-0x00000001824C96C0
		public WorldSpaceSizeMode worldSpaceSizeMode { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x00000001824C9840-0x00000001824C9850
		public Vector2 worldSpaceSize { get; set; } // 0x000000018042C5F0-0x000000018042C610 0x00000001824C9850-0x00000001824C98A0
		GameObject IPanelComponent.gameObject { get; } // 0x00000001824B8920-0x00000001824B8930 
		private bool isWorldSpace { get; } // 0x00000001824C92B0-0x00000001824C9330 
		public PivotReferenceSize pivotReferenceSize { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000180BE5D70-0x0000000180BE5D80
		public Pivot pivot { get; set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		public float sortingOrder { get; set; } // 0x0000000181F7C310-0x0000000181F7C320 0x00000001824C97F0-0x00000001824C9810
		float IPanelComponent.sortingOrder { get; } // 0x0000000181F7C310-0x0000000181F7C320 
		public IRuntimePanel runtimePanel { get; } // 0x00000001824C8410-0x00000001824C8420 
		internal RuntimePanel containerPanel { get; } // 0x00000001824C9230-0x00000001824C92B0 
		private float pixelsPerUnit { get; } // 0x00000001824C9330-0x00000001824C9360 
	
		// Constructors
		private UIDocument(); // 0x00000001824C91B0-0x00000001824C9230
		static UIDocument(); // 0x00000001824C9120-0x00000001824C91B0
	
		// Methods
		VisualElement IPanelComponent.GetRootVisualElement(); // 0x00000001802F4000-0x00000001802F4010
		IEventHandler IPanelComponent.GetRoot(); // 0x00000001824C8420-0x00000001824C8460
		internal void ApplySortingOrder(); // 0x00000001824C6030-0x00000001824C6040
		private void Awake(); // 0x00000001824C6040-0x00000001824C6050
		private void OnEnable(); // 0x00000001824C6670-0x00000001824C67B0
		private void _Enable(); // 0x00000001824C9030-0x00000001824C9120
		void IPanelComponent.SetComponentEnabled(bool enabled); // 0x00000001824C8670-0x00000001824C8680
		bool IPanelComponent.GetComponentEnabled(); // 0x00000001824C8400-0x00000001824C8410
		Vector3 IPanelComponent.GetPanelPosition(IEventHandler pickedElement, Ray worldRay); // 0x00000001824B8790-0x00000001824B8810
		IRuntimePanel IPanelComponent.GetContainerPanel(); // 0x00000001824C8410-0x00000001824C8420
		private void LateUpdate(); // 0x00000001824C64E0-0x00000001824C6520
		void IPanelComponent.PerformUpdate(); // 0x00000001824C8460-0x00000001824C8670
		private void UpdateRenderer(); // 0x00000001824C8760-0x00000001824C8BD0
		private Bounds SanitizeRendererBounds(Bounds b); // 0x00000001824C73A0-0x00000001824C74D0
		private void AddOrRemoveRendererComponent(); // 0x00000001824C5E70-0x00000001824C5F70
		internal void UpdateWorldSpaceCollider(ColliderUpdateMode mode); // 0x00000001824C8BD0-0x00000001824C9030
		internal void RemoveWorldSpaceCollider(); // 0x00000001824C7240-0x00000001824C72C0
		private void UpdateIsWorldSpaceRootFlag(); // 0x00000001824C8680-0x00000001824C8760
		private void SetTransform(); // 0x00000001824C74D0-0x00000001824C7AD0
		private void ClearTransform(); // 0x00000001824C6050-0x00000001824C6420
		internal Vector2 PivotOffset(); // 0x00000001824C69C0-0x00000001824C6A60
		private void SetupFromHierarchy(); // 0x00000001824C7AD0-0x00000001824C7C60
		private UIDocument FindUIDocumentParent(); // 0x00000001824C6420-0x00000001824C64E0
		internal void Reset(); // 0x00000001824C72C0-0x00000001824C73A0
		internal void AddChildAndInsertContentToVisualTree(UIDocument child); // 0x00000001824C5D50-0x00000001824C5E70
		private void RemoveChild(UIDocument child); // 0x00000001824C70A0-0x00000001824C7130
		private void RecreateUI(); // 0x00000001824C6B10-0x00000001824C70A0
		internal void SetupPosition(); // 0x00000001824C7C60-0x00000001824C7D50
		private void SetupRootClassList(); // 0x00000001824C7D50-0x00000001824C8040
		private void SetupWorldSpaceSize(); // 0x00000001824C8040-0x00000001824C8400
		private void AddRootVisualElementToTree(); // 0x00000001824C5F70-0x00000001824C6030
		private void RemoveFromHierarchy(); // 0x00000001824C7130-0x00000001824C7240
		private void OnDisable(); // 0x00000001824C6520-0x00000001824C6670
		private void OnTransformChildrenChanged(); // 0x00000001824C67B0-0x00000001824C69B0
		private void OnTransformParentChanged(); // 0x00000001824C69B0-0x00000001824C69C0
		internal void ReactToHierarchyChanged(); // 0x00000001824C6A60-0x00000001824C6B10
		void IPanelComponent.PerformValidation(bool forced); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
