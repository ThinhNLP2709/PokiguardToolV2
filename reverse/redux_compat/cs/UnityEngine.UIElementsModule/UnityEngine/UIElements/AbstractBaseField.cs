/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[UxmlElement]
	public abstract class AbstractBaseField : BindableElement, IEditableElement // TypeDefIndex: 3889
	{
		// Fields
		internal static readonly BindingId labelProperty; // 0x00
		internal static readonly BindingId showMixedValueProperty; // 0x98
		public static readonly string ussClassName; // 0x130
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x138
		public static readonly string labelUssClassName; // 0x140
		internal static readonly UniqueStyleString labelUssClassNameUnique; // 0x148
		public static readonly string inputUssClassName; // 0x150
		internal static readonly UniqueStyleString inputUssClassNameUnique; // 0x158
		public static readonly string noLabelVariantUssClassName; // 0x160
		internal static readonly UniqueStyleString noLabelVariantUssClassNameUnique; // 0x168
		public static readonly string labelDraggerVariantUssClassName; // 0x170
		internal static readonly UniqueStyleString labelDraggerVariantUssClassNameUnique; // 0x178
		public static readonly string mixedValueLabelUssClassName; // 0x180
		internal static readonly UniqueStyleString mixedValueLabelUssClassNameUnique; // 0x188
		public static readonly string alignedFieldUssClassName; // 0x190
		internal static readonly UniqueStyleString alignedFieldUssClassNameUnique; // 0x198
		private static readonly string inspectorFieldUssClassName; // 0x1A0
		internal static readonly UniqueStyleString inspectorFieldUssClassNameUnique; // 0x1A8
		private static readonly UniqueStyleString inspectorElementUssClassNameUnique; // 0x1AC
		private static readonly UniqueStyleString inspectorMainContainerUssClassNameUnique; // 0x1B0
		protected internal static readonly string mixedValueString; // 0x1B8
		protected internal static readonly PropertyName serializedPropertyCopyName; // 0x1C0
		private static CustomStyleProperty<float> s_LabelWidthRatioProperty; // 0x1C8
		private static CustomStyleProperty<float> s_LabelExtraPaddingProperty; // 0x1D8
		private static CustomStyleProperty<float> s_LabelBaseMinWidthProperty; // 0x1E8
		private float m_LabelWidthRatio; // 0x1B8
		private float m_LabelExtraPadding; // 0x1BC
		private float m_LabelBaseMinWidth; // 0x1C0
		private VisualElement m_VisualInput; // 0x1C8
		internal Action<ExpressionEvaluator.Expression> expressionEvaluated; // 0x1D0
		[CompilerGenerated]
		private DispatchMode _dispatchMode_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private Label _labelElement_k__BackingField; // 0x1E0
		private bool m_ShowMixedValue; // 0x1E8
		private VisualElement m_CachedContextWidthElement; // 0x1F0
		private VisualElement m_CachedInspectorElement; // 0x1F8
		[CompilerGenerated]
		private Action _UnityEngine_UIElements_IEditableElement_editingStarted_k__BackingField; // 0x200
		[CompilerGenerated]
		private Action _UnityEngine_UIElements_IEditableElement_editingEnded_k__BackingField; // 0x208
	
		// Properties
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElement visualInput { get; set; } // 0x0000000181CB2300-0x0000000181CB2310 0x000000018237C7C0-0x000000018237C910
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal DispatchMode dispatchMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D440-0x000000018033D450 0x000000018033E9D0-0x000000018033E9E0
		public Label labelElement { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[CreateProperty]
		[MultilineTextField]
		[UxmlAttribute]
		public string label { get; set; } // 0x000000018237C500-0x000000018237C530 0x000000018237C530-0x000000018237C700
		[CreateProperty]
		public bool showMixedValue { get; set; } // 0x0000000181E816C0-0x0000000181E816D0 0x000000018237C700-0x000000018237C7C0
		private protected virtual bool canSwitchToMixedValue { get; } // 0x00000001802E7990-0x00000001802E79A0 
		Action IEditableElement.editingStarted { [CompilerGenerated] get; } // 0x000000018033D670-0x000000018033D680 
		Action IEditableElement.editingEnded { [CompilerGenerated] get; } // 0x0000000181CC28E0-0x0000000181CC28F0 
	
		// Nested types
		private static class Callbacks // TypeDefIndex: 3890
		{
			// Fields
			public static readonly EventCallbackDefinition<AbstractBaseField> OnAttachToPanel; // 0x00
			public static readonly EventCallbackDefinition<AbstractBaseField> OnDetachFromPanel; // 0x08
			public static readonly EventCallbackDefinition<AbstractBaseField> OnCustomStyleResolved; // 0x10
			public static readonly EventCallbackDefinition<AbstractBaseField> OnInspectorFieldGeometryChanged; // 0x18
			public static readonly EventCallbackDefinition<AbstractBaseField> OnFocusInStartEditing; // 0x20
			public static readonly EventCallbackDefinition<AbstractBaseField> OnFocusOutEndEditing; // 0x28
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3891
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001823934C0-0x0000000182393530
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.cctor_b__6_0(AttachToPanelEvent e, AbstractBaseField self); // 0x0000000182392FD0-0x0000000182393000
				internal void _.cctor_b__6_1(DetachFromPanelEvent e, AbstractBaseField self); // 0x0000000182393000-0x0000000182393110
				internal void _.cctor_b__6_2(CustomStyleResolvedEvent e, AbstractBaseField self); // 0x0000000182393110-0x0000000182393140
				internal void _.cctor_b__6_3(GeometryChangedEvent e, AbstractBaseField self); // 0x0000000182393140-0x0000000182393160
				internal void _.cctor_b__6_4(FocusInEvent e, AbstractBaseField self); // 0x0000000182393160-0x00000001823931C0
				internal void _.cctor_b__6_5(FocusOutEvent e, AbstractBaseField self); // 0x00000001823931C0-0x0000000182393230
			}
	
			// Constructors
			static Callbacks(); // 0x0000000182381910-0x0000000182381CF0
		}
	
		// Constructors
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal AbstractBaseField(string label); // 0x000000018237C2B0-0x000000018237C500
		private protected AbstractBaseField(string label, VisualElement visualInput); // 0x000000018237C150-0x000000018237C2B0
		static AbstractBaseField(); // 0x000000018237B870-0x000000018237C150
	
		// Methods
		private void OnAttachToPanel(AttachToPanelEvent e); // 0x000000018237AFE0-0x000000018237B290
		private void OnDetachFromPanel(DetachFromPanelEvent e); // 0x000000018237B580-0x000000018237B690
		private protected virtual void OnDetachFromPanelCleanup(); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void RegisterEditingCallbacks(); // 0x000000018237B6A0-0x000000018237B720
		internal virtual void UnregisterEditingCallbacks(); // 0x000000018237B780-0x000000018237B830
		internal void StartEditing(EventBase e); // 0x000000018237B720-0x000000018237B780
		internal void EndEditing(EventBase e); // 0x000000018237AE00-0x000000018237AE60
		private void OnCustomStyleResolved(CustomStyleResolvedEvent evt); // 0x000000018237B290-0x000000018237B580
		private void OnInspectorFieldGeometryChanged(GeometryChangedEvent e); // 0x000000018237B690-0x000000018237B6A0
		private void AlignLabel(); // 0x000000018237A990-0x000000018237AD60
		private Rect ComputeTooltipRect(); // 0x000000018237AD60-0x000000018237AE00
		[EventInterest(new Type[1] {typeof(TooltipEvent) })]
		protected override void HandleEventBubbleUp(EventBase evt); // 0x000000018237AE60-0x000000018237AFE0
		protected virtual void UpdateMixedValueContent(); // 0x000000018237B830-0x000000018237B870
	}
}
