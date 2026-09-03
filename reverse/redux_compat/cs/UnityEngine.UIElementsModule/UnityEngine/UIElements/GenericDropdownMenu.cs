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
	public class GenericDropdownMenu : AbstractGenericMenu // TypeDefIndex: 3883
	{
		// Fields
		public static readonly string ussClassName; // 0x00
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x08
		public static readonly string itemUssClassName; // 0x10
		internal static readonly UniqueStyleString itemUssClassNameUnique; // 0x18
		public static readonly string itemContentUssClassName; // 0x20
		internal static readonly UniqueStyleString itemContentUssClassNameUnique; // 0x28
		public static readonly string labelUssClassName; // 0x30
		internal static readonly UniqueStyleString labelUssClassNameUnique; // 0x38
		public static readonly string containerInnerUssClassName; // 0x40
		internal static readonly UniqueStyleString containerInnerUssClassNameUnique; // 0x48
		public static readonly string containerOuterUssClassName; // 0x50
		internal static readonly UniqueStyleString containerOuterUssClassNameUnique; // 0x58
		public static readonly string checkmarkUssClassName; // 0x60
		internal static readonly UniqueStyleString checkmarkUssClassNameUnique; // 0x68
		public static readonly string separatorUssClassName; // 0x70
		internal static readonly UniqueStyleString separatorUssClassNameUnique; // 0x78
		public static readonly string contentWidthUssClassName; // 0x80
		internal static readonly UniqueStyleString contentWidthUssClassNameUnique; // 0x88
		private List<MenuItem> m_Items; // 0x10
		private VisualElement m_MenuContainer; // 0x18
		private VisualElement m_OuterContainer; // 0x20
		private ScrollView m_ScrollView; // 0x28
		private VisualElement m_PanelRootVisualContainer; // 0x30
		private VisualElement m_TargetElement; // 0x38
		private Rect m_DesiredRect; // 0x40
		private KeyboardNavigationManipulator m_NavigationManipulator; // 0x50
		private float m_PositionTop; // 0x58
		private float m_PositionLeft; // 0x5C
		private float m_ContentWidth; // 0x60
		private bool m_FitContentWidth; // 0x64
		private bool m_ShownAboveTarget; // 0x65
		[CompilerGenerated]
		private bool _isSingleSelectionDropdown_k__BackingField; // 0x66
		[CompilerGenerated]
		private bool _closeOnParentResize_k__BackingField; // 0x67
		[CompilerGenerated]
		private Action onClose; // 0x68
		private Vector2 m_MousePosition; // 0x70
	
		// Properties
		internal bool isSingleSelectionDropdown { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181889B00-0x0000000181889B10 0x000000018238DFF0-0x000000018238E000
		internal bool closeOnParentResize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181889AF0-0x0000000181889B00 0x000000018238DFE0-0x000000018238DFF0
		public VisualElement contentContainer { get; } // 0x000000018238DFB0-0x000000018238DFE0 
	
		// Nested types
		internal class MenuItem // TypeDefIndex: 3884
		{
			// Fields
			public VisualElement element; // 0x10
			public Action action; // 0x18
			public Action<object> actionUserData; // 0x20
	
			// Constructors
			public MenuItem(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private struct __c__DisplayClass65_0 // TypeDefIndex: 3885
		{
			// Fields
			public GenericDropdownMenu __4__this; // 0x00
			public int selectedIndex; // 0x08
		}
	
		// Constructors
		public GenericDropdownMenu(); // 0x000000018238DC40-0x000000018238DFB0
		static GenericDropdownMenu(); // 0x000000018238D720-0x000000018238DC40
	
		// Methods
		private void OnAttachToPanel(AttachToPanelEvent evt); // 0x000000018238C7B0-0x000000018238CBD0
		private void OnDetachFromPanel(DetachFromPanelEvent evt); // 0x000000018238CBE0-0x000000018238CF20
		private void Hide(bool giveFocusBack = false /* Metadata: 0x0066048E */); // 0x000000018238C620-0x000000018238C7B0
		private void Apply(KeyboardNavigationOperation op, EventBase sourceEvent); // 0x000000018238B480-0x000000018238B4C0
		private bool Apply(KeyboardNavigationOperation op); // 0x000000018238B1A0-0x000000018238B480
		private void OnPointerDown(PointerDownEvent evt); // 0x000000018238D100-0x000000018238D240
		private void OnPointerMove(PointerMoveEvent evt); // 0x000000018238D240-0x000000018238D380
		private void OnPointerUp(PointerUpEvent evt); // 0x000000018238D380-0x000000018238D4C0
		private void OnFocusOut(FocusOutEvent evt); // 0x000000018238CF20-0x000000018238D0B0
		private void OnParentResized(GeometryChangedEvent evt); // 0x000000018238D0E0-0x000000018238D100
		private void UpdateSelection(VisualElement target); // 0x000000018238D5F0-0x000000018238D720
		private void ChangeSelectedIndex(int newIndex, int previousIndex); // 0x000000018238B4C0-0x000000018238B5C0
		private int GetSelectedIndex(); // 0x000000018238C590-0x000000018238C620
		private void OnTargetElementDetachFromPanel(DetachFromPanelEvent evt); // 0x000000018238D4C0-0x000000018238D4D0
		private void OnContainerGeometryChanged(GeometryChangedEvent evt); // 0x000000018238CBD0-0x000000018238CBE0
		private void OnInitialDisplay(GeometryChangedEvent evt); // 0x000000018238D0B0-0x000000018238D0E0
		private void EnsureVisibilityInParent(); // 0x000000018238B5C0-0x000000018238BEA0
		private float GetLargestItemWidth(); // 0x000000018238BEA0-0x000000018238C590
		[CompilerGenerated]
		private void _Apply_g__UpdateSelectionDown_65_0(int newIndex, ref __c__DisplayClass65_0 param_000062ed); // 0x000000018238D4D0-0x000000018238D560
		[CompilerGenerated]
		private void _Apply_g__UpdateSelectionUp_65_1(int newIndex, ref __c__DisplayClass65_0 param_000062ef); // 0x000000018238D560-0x000000018238D5F0
	}
}
