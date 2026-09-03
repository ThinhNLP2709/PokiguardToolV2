/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[UxmlElement]
	public abstract class BaseSlider<TValueType> : BaseField<TValueType>, IValueField<TValueType> // TypeDefIndex: 3875
		where TValueType : IComparable<TValueType>
	{
		// Fields
		internal static readonly BindingId lowValueProperty;
		internal static readonly BindingId highValueProperty;
		internal static readonly BindingId rangeProperty;
		internal static readonly BindingId pageSizeProperty;
		internal static readonly BindingId showInputFieldProperty;
		internal static readonly BindingId directionProperty;
		internal static readonly BindingId invertedProperty;
		internal static readonly BindingId fillProperty;
		[CompilerGenerated]
		private VisualElement _dragContainer_k__BackingField;
		[CompilerGenerated]
		private VisualElement _dragElement_k__BackingField;
		[CompilerGenerated]
		private VisualElement _trackElement_k__BackingField;
		[CompilerGenerated]
		private VisualElement _dragBorderElement_k__BackingField;
		[CompilerGenerated]
		private TextField _inputTextField_k__BackingField;
		private VisualElement m_FillElement;
		private float m_AdjustedPageSizeFromClick;
		private bool m_IsEditingTextField;
		private bool m_Fill;
		[DontCreateProperty]
		[SerializeField]
		private TValueType m_LowValue;
		[DontCreateProperty]
		[SerializeField]
		private TValueType m_HighValue;
		private float m_PageSize;
		private bool m_ShowInputField;
		[CompilerGenerated]
		private bool _clamped_k__BackingField;
		[CompilerGenerated]
		private ClampedDragger _clampedDragger_k__BackingField;
		private Rect m_DragElementStartPos;
		[CompilerGenerated]
		private Action<TValueType> onSetValueWithoutNotify;
		private SliderDirection m_Direction;
		private bool m_Inverted;
		public static readonly string ussClassName;
		internal static readonly UniqueStyleString ussClassNameUnique;
		public static readonly string labelUssClassName;
		internal static readonly UniqueStyleString labelUssClassNameUnique;
		public static readonly string inputUssClassName;
		internal static readonly UniqueStyleString inputUssClassNameUnique;
		public static readonly string horizontalVariantUssClassName;
		internal static readonly UniqueStyleString horizontalVariantUssClassNameUnique;
		public static readonly string verticalVariantUssClassName;
		internal static readonly UniqueStyleString verticalVariantUssClassNameUnique;
		public static readonly string dragContainerUssClassName;
		internal static readonly UniqueStyleString dragContainerUssClassNameUnique;
		public static readonly string trackerUssClassName;
		internal static readonly UniqueStyleString trackerUssClassNameUnique;
		public static readonly string draggerUssClassName;
		internal static readonly UniqueStyleString draggerUssClassNameUnique;
		public static readonly string draggerBorderUssClassName;
		internal static readonly UniqueStyleString draggerBorderUssClassNameUnique;
		public static readonly string textFieldClassName;
		internal static readonly UniqueStyleString textFieldClassNameUnique;
		public static readonly string fillUssClassName;
		internal static readonly UniqueStyleString fillUssClassNameUnique;
		public static readonly string movableUssClassName;
		internal static readonly UniqueStyleString movableUssClassNameUnique;
	
		// Properties
		internal VisualElement dragContainer { [CompilerGenerated] get; [CompilerGenerated] private set; }
		internal VisualElement dragElement { [CompilerGenerated] get; [CompilerGenerated] private set; }
		internal VisualElement trackElement { [CompilerGenerated] get; [CompilerGenerated] private set; }
		internal VisualElement dragBorderElement { [CompilerGenerated] get; [CompilerGenerated] private set; }
		internal TextField inputTextField { [CompilerGenerated] get; [CompilerGenerated] private set; }
		internal VisualElement fillElement { get; private set; }
		private protected override bool canSwitchToMixedValue { get; }
		[CreateProperty]
		[Delayed]
		[UxmlAttribute]
		public TValueType lowValue { get; set; }
		[CreateProperty]
		[Delayed]
		[UxmlAttribute]
		public TValueType highValue { get; set; }
		[CreateProperty(ReadOnly = true)]
		public TValueType range { get; }
		[CreateProperty]
		[UxmlAttribute]
		public bool fill { get; set; }
		[CreateProperty]
		public virtual float pageSize { get; set; }
		[CreateProperty]
		public virtual bool showInputField { get; set; }
		internal bool clamped { [CompilerGenerated] get; [CompilerGenerated] set; }
		internal ClampedDragger clampedDragger { [CompilerGenerated] get; [CompilerGenerated] private set; }
		public override TValueType value { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public SliderDirection direction { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool inverted { get; set; }
	
		// Events
		internal event Action<TValueType> onSetValueWithoutNotify {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Nested types
		internal enum SliderKey // TypeDefIndex: 3876
		{
			None = 0,
			Lowest = 1,
			LowerPage = 2,
			Lower = 3,
			Higher = 4,
			HigherPage = 5,
			Highest = 6
		}
	
		private static class Callbacks // TypeDefIndex: 3877
		{
			// Fields
			public static readonly EventCallbackDefinition<VisualElement> OnDragGeometryChangedUpdatePosition;
			public static readonly EventCallbackDefinition<VisualElement> OnLabelOrDragPointerDownStartEditing;
			public static readonly EventCallbackDefinition<VisualElement> OnDragPointerUpEndEditing;
			public static readonly EventCallbackGroup<BaseSlider<TValueType>> OnKeyFocusNavigation;
			public static readonly EventCallbackGroup<TextField> OnInputTextFieldFocusValue;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3878
			{
				// Fields
				public static readonly __c<TValueType> __9;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal void _.cctor_b__6_0(GeometryChangedEvent e, VisualElement dragElement);
				internal void _.cctor_b__6_1(PointerDownEvent e, VisualElement labelOrDrag);
				internal void _.cctor_b__6_2(PointerUpEvent e, VisualElement dragContainer);
				internal void _.cctor_b__6_3(KeyDownEvent e, BaseSlider<TValueType> self);
				internal void _.cctor_b__6_4(FocusInEvent e, BaseSlider<TValueType> self);
				internal void _.cctor_b__6_5(FocusOutEvent e, BaseSlider<TValueType> self);
				internal void _.cctor_b__6_6(NavigationSubmitEvent e, BaseSlider<TValueType> self);
				internal void _.cctor_b__6_7(NavigationMoveEvent e, BaseSlider<TValueType> self);
				internal void _.cctor_b__6_8(FocusInEvent e, TextField textField);
				internal void _.cctor_b__6_9(FocusOutEvent e, TextField textField);
				internal void _.cctor_b__6_10(ChangeEvent<string> e, TextField textField);
			}
	
			// Constructors
			static Callbacks();
	
			// Methods
			private static BaseSlider<TValueType> GetBaseSlider(VisualElement child);
		}
	
		// Constructors
		internal BaseSlider(string label, TValueType start, TValueType end, SliderDirection direction = SliderDirection.Horizontal /* Metadata: 0x00660482 */, float pageSize = 0f /* Metadata: 0x00660483 */);
		static BaseSlider();
	
		// Methods
		private TValueType Clamp(TValueType value, TValueType lowBound, TValueType highBound);
		private TValueType GetClampedValue(TValueType newValue);
		public virtual void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, TValueType startValue);
		void IValueField<TValueType>.StartDragging();
		void IValueField<TValueType>.StopDragging();
		public override void SetValueWithoutNotify(TValueType newValue);
		protected internal static float GetClosestPowerOfTen(float positiveNumber);
		protected internal static float RoundToMultipleOf(float value, float roundingValue);
		private void ClampValue();
		internal abstract TValueType SliderLerpUnclamped(TValueType a, TValueType b, float interpolant);
		internal abstract float SliderNormalizeValue(TValueType currentValue, TValueType lowerValue, TValueType higherValue);
		internal abstract TValueType SliderRange();
		internal abstract TValueType ParseStringToValue(string previousValue, string newValue);
		internal abstract void ComputeValueFromKey(SliderKey sliderKey, bool isShift);
		private TValueType SliderLerpDirectionalUnclamped(TValueType a, TValueType b, float positionInterpolant);
		private void SetSliderValueFromDrag();
		private void ComputeValueAndDirectionFromDrag(float sliderLength, float dragElementLength, float dragElementPos);
		private void SetSliderValueFromClick();
		private void OnKeyDown(KeyDownEvent evt);
		private void OnNavigationMove(NavigationMoveEvent evt);
		private void OnNavigationSubmit(NavigationSubmitEvent evt);
		internal virtual void ComputeValueAndDirectionFromClick(float sliderLength, float dragElementLength, float dragElementPos, float dragElementLastPos);
		public void AdjustDragElement(float factor);
		private void UpdateDragElementPosition(GeometryChangedEvent evt);
		internal override void OnViewDataReady();
		private void UpdateDragElementPosition();
		[EventInterest(new Type[1] {typeof(GeometryChangedEvent) })]
		protected override void HandleEventBubbleUp(EventBase evt);
		[EventInterest(EventInterestOptions.Inherit)]
		[Obsolete("ExecuteDefaultAction override has been removed because default event handling was migrated to HandleEventBubbleUp. Please use HandleEventBubbleUp.", false)]
		protected override void ExecuteDefaultAction(EventBase evt);
		private void UpdateTextFieldVisibility();
		private void UpdateTextFieldValue();
		private void OnFocusIn(FocusInEvent evt);
		private void OnFocusOut(FocusOutEvent evt);
		private void OnTextFieldFocusIn(FocusInEvent evt);
		private void OnTextFieldFocusOut(FocusOutEvent evt);
		private void OnTextFieldValueChange(ChangeEvent<string> evt);
		protected override void UpdateMixedValueContent();
		internal override void RegisterEditingCallbacks();
		internal override void UnregisterEditingCallbacks();
	}
}
