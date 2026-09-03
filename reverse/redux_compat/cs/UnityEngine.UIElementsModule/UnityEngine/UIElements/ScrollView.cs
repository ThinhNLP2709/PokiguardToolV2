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
	[UxmlElement(libraryPath = "Containers")]
	public class ScrollView : VisualElement // TypeDefIndex: 3914
	{
		// Fields
		internal static readonly BindingId horizontalScrollerVisibilityProperty; // 0x00
		internal static readonly BindingId verticalScrollerVisibilityProperty; // 0x98
		internal static readonly BindingId scrollOffsetProperty; // 0x130
		internal static readonly BindingId horizontalPageSizeProperty; // 0x1C8
		internal static readonly BindingId verticalPageSizeProperty; // 0x260
		internal static readonly BindingId mouseWheelScrollSizeProperty; // 0x2F8
		internal static readonly BindingId scrollDecelerationRateProperty; // 0x390
		internal static readonly BindingId elasticityProperty; // 0x428
		internal static readonly BindingId touchScrollBehaviorProperty; // 0x4C0
		internal static readonly BindingId nestedInteractionKindProperty; // 0x558
		internal static readonly BindingId modeProperty; // 0x5F0
		internal static readonly BindingId elasticAnimationIntervalMsProperty; // 0x688
		private VisualElement m_DeferredScrollToElement; // 0x1A8
		private IVisualElementScheduledItem m_DeferredScrollTo; // 0x1B0
		private Vector2 m_LastDeferredScrollOffset; // 0x1B8
		private int m_DeferredScrollToAttempts; // 0x1C0
		private int m_FirstLayoutPass; // 0x1C4
		private ScrollViewMode m_Mode; // 0x1C8
		private NestedInteractionKind m_NestedInteractionKind; // 0x1CC
		private ScrollerVisibility m_HorizontalScrollerVisibility; // 0x1D0
		private ScrollerVisibility m_VerticalScrollerVisibility; // 0x1D4
		private VisualElement m_AttachedRootVisualContainer; // 0x1D8
		private float m_SingleLineHeight; // 0x1E0
		private bool m_SingleLineHeightDirtyFlag; // 0x1E4
		private static readonly UniqueStyleString k_SingleLineHeightPropertyName; // 0x720
		internal bool m_MouseWheelScrollSizeIsInline; // 0x1E5
		[DontCreateProperty]
		[SerializeField]
		private Vector2 m_ScrollOffset; // 0x1E8
		private float m_HorizontalPageSize; // 0x1F0
		private float m_VerticalPageSize; // 0x1F4
		private float m_MouseWheelScrollSize; // 0x1F8
		private TouchScrollBehavior m_TouchScrollBehavior; // 0x1FC
		private static readonly float k_DefaultScrollDecelerationRate; // 0x724
		private float m_ScrollDecelerationRate; // 0x200
		private float k_ScaledPixelsPerPointMultiplier; // 0x204
		private float k_TouchScrollInertiaBaseTimeInterval; // 0x208
		private static readonly float k_DefaultElasticity; // 0x728
		private float m_Elasticity; // 0x20C
		private long m_ElasticAnimationIntervalMs; // 0x210
		[CompilerGenerated]
		private readonly VisualElement _contentViewport_k__BackingField; // 0x218
		[CompilerGenerated]
		private readonly Scroller _horizontalScroller_k__BackingField; // 0x220
		[CompilerGenerated]
		private readonly Scroller _verticalScroller_k__BackingField; // 0x228
		private VisualElement m_ContentContainer; // 0x230
		private VisualElement m_ContentAndVerticalScrollContainer; // 0x238
		private float previousVerticalTouchScrollTimeStamp; // 0x240
		private float previousHorizontalTouchScrollTimeStamp; // 0x244
		private float elapsedTimeSinceLastVerticalTouchScroll; // 0x248
		private float elapsedTimeSinceLastHorizontalTouchScroll; // 0x24C
		public static readonly string ussClassName; // 0x730
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x738
		public static readonly string viewportUssClassName; // 0x740
		internal static readonly UniqueStyleString viewportUssClassNameUnique; // 0x748
		public static readonly string horizontalVariantViewportUssClassName; // 0x750
		internal static readonly UniqueStyleString horizontalVariantViewportUssClassNameUnique; // 0x758
		public static readonly string verticalVariantViewportUssClassName; // 0x760
		internal static readonly UniqueStyleString verticalVariantViewportUssClassNameUnique; // 0x768
		public static readonly string verticalHorizontalVariantViewportUssClassName; // 0x770
		internal static readonly UniqueStyleString verticalHorizontalVariantViewportUssClassNameUnique; // 0x778
		public static readonly string contentAndVerticalScrollUssClassName; // 0x780
		internal static readonly UniqueStyleString contentAndVerticalScrollUssClassNameUnique; // 0x788
		public static readonly string contentUssClassName; // 0x790
		internal static readonly UniqueStyleString contentUssClassNameUnique; // 0x798
		public static readonly string horizontalVariantContentUssClassName; // 0x7A0
		internal static readonly UniqueStyleString horizontalVariantContentUssClassNameUnique; // 0x7A8
		public static readonly string verticalVariantContentUssClassName; // 0x7B0
		internal static readonly UniqueStyleString verticalVariantContentUssClassNameUnique; // 0x7B8
		public static readonly string verticalHorizontalVariantContentUssClassName; // 0x7C0
		internal static readonly UniqueStyleString verticalHorizontalVariantContentUssClassNameUnique; // 0x7C8
		public static readonly string hScrollerUssClassName; // 0x7D0
		internal static readonly UniqueStyleString hScrollerUssClassNameUnique; // 0x7D8
		public static readonly string vScrollerUssClassName; // 0x7E0
		internal static readonly UniqueStyleString vScrollerUssClassNameUnique; // 0x7E8
		public static readonly string scrollingUssClassName; // 0x7F0
		internal static readonly UniqueStyleString scrollingUssClassNameUnique; // 0x7F8
		public static readonly string horizontalVariantUssClassName; // 0x800
		internal static readonly UniqueStyleString horizontalVariantUssClassNameUnique; // 0x808
		public static readonly string verticalVariantUssClassName; // 0x810
		internal static readonly UniqueStyleString verticalVariantUssClassNameUnique; // 0x818
		public static readonly string verticalHorizontalVariantUssClassName; // 0x820
		internal static readonly UniqueStyleString verticalHorizontalVariantUssClassNameUnique; // 0x828
		public static readonly string scrollVariantUssClassName; // 0x830
		internal static readonly UniqueStyleString scrollVariantUssClassNameUnique; // 0x838
		private IVisualElementScheduledItem m_ScheduledLayoutPassResetItem; // 0x250
		private Vector2 m_StartPosition; // 0x258
		private Vector2 m_PointerStartPosition; // 0x260
		private Vector2 m_Velocity; // 0x268
		private Vector2 m_SpringBackVelocity; // 0x270
		private Vector2 m_LowBounds; // 0x278
		private Vector2 m_HighBounds; // 0x280
		private float m_LastVelocityLerpTime; // 0x288
		private int m_TouchDraggingPointerId; // 0x28C
		private bool m_StartedMoving; // 0x290
		private bool m_TouchPointerMoveAllowed; // 0x291
		private bool m_TouchStoppedVelocity; // 0x292
		private VisualElement m_CapturedTarget; // 0x298
		private EventCallback<PointerMoveEvent> m_CapturedTargetPointerMoveCallback; // 0x2A0
		private EventCallback<PointerUpEvent> m_CapturedTargetPointerUpCallback; // 0x2A8
		internal IVisualElementScheduledItem m_PostPointerUpAnimation; // 0x2B0
	
		// Properties
		[CreateProperty]
		[UxmlAttribute]
		public ScrollViewMode mode { get; set; } // 0x00000001823A97F0-0x00000001823A9800 0x00000001823A9F80-0x00000001823AA020
		[CreateProperty]
		[UxmlAttribute]
		public NestedInteractionKind nestedInteractionKind { get; set; } // 0x0000000182019820-0x0000000182019830 0x00000001823AA0F0-0x00000001823AA170
		[CreateProperty]
		[UxmlAttribute]
		public ScrollerVisibility horizontalScrollerVisibility { get; set; } // 0x0000000181DAAA10-0x0000000181DAAA20 0x00000001823A9E80-0x00000001823A9F80
		[CreateProperty]
		[UxmlAttribute]
		public ScrollerVisibility verticalScrollerVisibility { get; set; } // 0x0000000181DAAA00-0x0000000181DAAA10 0x00000001823AA700-0x00000001823AA810
		internal bool needsHorizontal { get; } // 0x00000001823A9810-0x00000001823A9860 
		internal bool needsVertical { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x00000001823A9860-0x00000001823A98B0 
		internal bool isVerticalScrollDisplayed { get; } // 0x00000001823A9780-0x00000001823A97F0 
		internal bool isHorizontalScrollDisplayed { get; } // 0x00000001823A9710-0x00000001823A9780 
		[CreateProperty]
		public Vector2 scrollOffset { get; set; } // 0x00000001823A98C0-0x00000001823A98E0 0x00000001823AA240-0x00000001823AA510
		[CreateProperty]
		[UxmlAttribute]
		public float horizontalPageSize { get; set; } // 0x00000001823A9700-0x00000001823A9710 0x00000001823A9DA0-0x00000001823A9E80
		[CreateProperty]
		[UxmlAttribute]
		public float verticalPageSize { get; set; } // 0x00000001823A9B70-0x00000001823A9B80 0x00000001823AA620-0x00000001823AA700
		[CreateProperty]
		[UxmlAttribute]
		public float mouseWheelScrollSize { get; set; } // 0x00000001823A9800-0x00000001823A9810 0x00000001823AA020-0x00000001823AA0F0
		[CreateProperty]
		[UxmlAttribute("touch-scroll-type")]
		public TouchScrollBehavior touchScrollBehavior { get; set; } // 0x00000001823A9B60-0x00000001823A9B70 0x00000001823AA510-0x00000001823AA620
		internal float scrollableWidth { get; } // 0x00000001823A9A20-0x00000001823A9B60 
		internal float scrollableHeight { get; } // 0x00000001823A98E0-0x00000001823A9A20 
		private bool hasInertia { get; } // 0x00000001823A96E0-0x00000001823A9700 
		[CreateProperty]
		[UxmlAttribute]
		public float scrollDecelerationRate { get; set; } // 0x00000001823A98B0-0x00000001823A98C0 0x00000001823AA170-0x00000001823AA240
		[CreateProperty]
		[UxmlAttribute]
		public float elasticity { get; set; } // 0x00000001823A96D0-0x00000001823A96E0 0x00000001823A9CD0-0x00000001823A9DA0
		[CreateProperty]
		[UxmlAttribute]
		public long elasticAnimationIntervalMs { get; set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x00000001823A9B80-0x00000001823A9CD0
		public VisualElement contentViewport { [CompilerGenerated] get; } // 0x0000000181CC2910-0x0000000181CC2920 
		public Scroller horizontalScroller { [CompilerGenerated] get; } // 0x0000000181CC28F0-0x0000000181CC2900 
		public Scroller verticalScroller { [CompilerGenerated] get; } // 0x0000000181CC2900-0x0000000181CC2910 
		public override VisualElement contentContainer { get; } // 0x000000018033D490-0x000000018033D4A0 
	
		// Nested types
		public enum TouchScrollBehavior // TypeDefIndex: 3915
		{
			Unrestricted = 0,
			Elastic = 1,
			Clamped = 2
		}
	
		public enum NestedInteractionKind // TypeDefIndex: 3916
		{
			Default = 0,
			StopScrolling = 1,
			ForwardScrolling = 2
		}
	
		internal enum TouchScrollingResult // TypeDefIndex: 3917
		{
			Apply = 0,
			Forward = 1,
			Block = 2
		}
	
		private static class Callbacks // TypeDefIndex: 3918
		{
			// Fields
			public static readonly EventCallbackDefinition<ScrollView> OnScrollWheel; // 0x00
			public static readonly EventCallbackDefinition<ScrollView> OnNavigationMove; // 0x08
			public static readonly EventCallbackDefinition<ScrollView> OnNavigationSubmit; // 0x10
			public static readonly EventCallbackDefinition<ScrollView> OnFocusOut; // 0x18
			public static readonly EventCallbackDefinition<ScrollView> OnRootCustomStyleResolved; // 0x20
			public static readonly EventCallbackDefinition<VisualElement> OnContentGeometryChanged; // 0x28
			public static readonly EventCallbackDefinition<VisualElement> OnContentAndVerticalScrollAttach; // 0x30
			public static readonly EventCallbackDefinition<VisualElement> OnContentAndVerticalScrollDetach; // 0x38
			public static readonly EventCallbackDefinition<VisualElement> OnContentAndVerticalScrollPointerMove; // 0x40
			public static readonly EventCallbackDefinition<Scroller> OnScrollerGeometryChanged; // 0x48
			public static readonly EventCallbackDefinition<VisualElement> OnHorizontalScrollDragElementGeometry; // 0x50
			public static readonly EventCallbackDefinition<VisualElement> OnVerticalScrollDragElementGeometry; // 0x58
			public static readonly EventCallbackGroup<VisualElement> OnContentContainerPointer; // 0x60
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3919
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001823B2320-0x00000001823B2390
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.cctor_b__14_0(WheelEvent e, ScrollView self); // 0x00000001823B1110-0x00000001823B1140
				internal void _.cctor_b__14_1(NavigationMoveEvent e, ScrollView self); // 0x00000001823B1830-0x00000001823B1860
				internal void _.cctor_b__14_2(NavigationSubmitEvent e, ScrollView self); // 0x00000001823B1860-0x00000001823B1950
				internal void _.cctor_b__14_3(FocusOutEvent e, ScrollView self); // 0x00000001823B1950-0x00000001823B19E0
				internal void _.cctor_b__14_4(CustomStyleResolvedEvent e, ScrollView self); // 0x00000001823B19E0-0x00000001823B1A00
				internal void _.cctor_b__14_5(GeometryChangedEvent e, VisualElement content); // 0x00000001823B1A00-0x00000001823B1AA0
				internal void _.cctor_b__14_6(AttachToPanelEvent e, VisualElement contentAndVerticalScroll); // 0x00000001823B1AA0-0x00000001823B1B40
				internal void _.cctor_b__14_7(DetachFromPanelEvent e, VisualElement contentAndVerticalScroll); // 0x00000001823B1B40-0x00000001823B1BE0
				internal void _.cctor_b__14_8(PointerMoveEvent e, VisualElement contentAndVerticalScroll); // 0x00000001823B1BE0-0x00000001823B1C80
				internal void _.cctor_b__14_9(GeometryChangedEvent e, Scroller scroller); // 0x00000001823B1C80-0x00000001823B1D20
				internal void _.cctor_b__14_10(GeometryChangedEvent e, VisualElement dragElement); // 0x00000001823B1140-0x00000001823B1260
				internal void _.cctor_b__14_11(GeometryChangedEvent e, VisualElement dragElement); // 0x00000001823B1260-0x00000001823B1380
				internal void _.cctor_b__14_12(PointerDownEvent e, VisualElement contentContainer); // 0x00000001823B1380-0x00000001823B1420
				internal void _.cctor_b__14_13(PointerCancelEvent e, VisualElement contentContainer); // 0x00000001823B1420-0x00000001823B14D0
				internal void _.cctor_b__14_14(PointerUpEvent e, VisualElement contentContainer); // 0x00000001823B14D0-0x00000001823B15C0
				internal void _.cctor_b__14_15(PointerCaptureEvent e, VisualElement contentContainer); // 0x00000001823B15C0-0x00000001823B16F0
				internal void _.cctor_b__14_16(PointerCaptureOutEvent e, VisualElement contentContainer); // 0x00000001823B16F0-0x00000001823B1830
			}
	
			// Constructors
			static Callbacks(); // 0x000000018239A5A0-0x000000018239AFF0
	
			// Methods
			private static ScrollView GetScrollView(VisualElement child); // 0x000000018239A460-0x000000018239A4B0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3920
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<VisualElement> __9__230_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001823B1F30-0x00000001823B1FA0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ReadSingleLineHeight_b__230_0(VisualElement x); // 0x00000001823B0E50-0x00000001823B0E70
		}
	
		// Constructors
		public ScrollView(); // 0x00000001823A96C0-0x00000001823A96D0
		public ScrollView(ScrollViewMode scrollViewMode); // 0x00000001823A8790-0x00000001823A96C0
		static ScrollView(); // 0x00000001823A7370-0x00000001823A8790
	
		// Methods
		private void OnHorizontalScrollDragElementChanged(GeometryChangedEvent evt); // 0x00000001823A3AB0-0x00000001823A3B60
		private void OnVerticalScrollDragElementChanged(GeometryChangedEvent evt); // 0x00000001823A51D0-0x00000001823A5280
		private void UpdateHorizontalSliderPageSize(); // 0x00000001823A6B10-0x00000001823A6C60
		private void UpdateVerticalSliderPageSize(); // 0x00000001823A7220-0x00000001823A7370
		internal void UpdateContentViewTransform(); // 0x00000001823A67B0-0x00000001823A6AE0
		public void ScrollTo(VisualElement child); // 0x00000001823A5C40-0x00000001823A5ED0
		private void ApplyScrollTo(VisualElement child); // 0x00000001823A1E50-0x00000001823A1F60
		private bool ShouldDeferScrollTo(); // 0x00000001823A6310-0x00000001823A6380
		private void StartDeferredScrollTo(VisualElement target); // 0x00000001823A6550-0x00000001823A66C0
		private void StopDeferredScrollTo(); // 0x00000001823A66C0-0x00000001823A6750
		private void PerformDeferredScrollTo(); // 0x00000001823A5410-0x00000001823A5510
		private float GetXDeltaOffset(VisualElement child); // 0x00000001823A2AB0-0x00000001823A2D60
		private float GetYDeltaOffset(VisualElement child); // 0x00000001823A2D60-0x00000001823A3020
		private float GetDeltaDistance(float viewMin, float viewMax, float childBoundaryMin, float childBoundaryMax); // 0x00000001823A2A50-0x00000001823A2AB0
		private void SetScrollViewMode(ScrollViewMode mode); // 0x00000001823A5ED0-0x00000001823A6310
		private void OnAttachToPanel(AttachToPanelEvent evt); // 0x00000001823A30C0-0x00000001823A33D0
		private void OnDetachFromPanel(DetachFromPanelEvent evt); // 0x00000001823A33D0-0x00000001823A3700
		private void OnPointerCapture(PointerCaptureEvent evt); // 0x00000001823A42C0-0x00000001823A4380
		private void OnPointerCaptureOut(PointerCaptureOutEvent evt); // 0x00000001823A41F0-0x00000001823A42C0
		private void OnGeometryChanged(GeometryChangedEvent evt); // 0x00000001823A3780-0x00000001823A3AB0
		private void OnVerticalSliderViewDataRestored(); // 0x00000001823A5290-0x00000001823A5320
		private void OnHorizontalSliderViewDataRestored(); // 0x00000001823A3B70-0x00000001823A3C00
		private void OnVerticalScrollerSetValueWithoutNotify(float value); // 0x00000001823A5280-0x00000001823A5290
		private void OnHorizontalScrollerSetValueWithoutNotify(float value); // 0x00000001823A3B60-0x00000001823A3B70
		private void ScheduleResetLayoutPass(); // 0x00000001823A5B20-0x00000001823A5C40
		private void ResetLayoutPass(); // 0x00000001823A5B10-0x00000001823A5B20
		private static float ComputeElasticOffset(float deltaPointer, float initialScrollOffset, float lowLimit, float hardLowLimit, float highLimit, float hardHighLimit); // 0x00000001823A2290-0x00000001823A23F0
		private void ComputeInitialSpringBackVelocity(); // 0x00000001823A23F0-0x00000001823A24B0
		private void SpringBack(); // 0x00000001823A6380-0x00000001823A6550
		internal void ApplyScrollInertia(); // 0x00000001823A1BB0-0x00000001823A1E50
		private void PostPointerUpAnimation(); // 0x00000001823A5510-0x00000001823A5640
		private void OnPointerDown(PointerDownEvent evt); // 0x00000001823A4380-0x00000001823A45E0
		private void OnPointerMove(PointerMoveEvent evt); // 0x00000001823A45E0-0x00000001823A4950
		private void OnPointerCancel(PointerCancelEvent evt); // 0x00000001823A41C0-0x00000001823A41F0
		private void OnPointerUp(PointerUpEvent evt); // 0x00000001823A4950-0x00000001823A49D0
		private void InitTouchScrolling(Vector2 position, int pointerId); // 0x00000001823A3020-0x00000001823A30B0
		private void UpdateTouchScrollingBounds(); // 0x00000001823A7130-0x00000001823A7220
		internal TouchScrollingResult ComputeTouchScrolling(Vector2 position); // 0x00000001823A24B0-0x00000001823A2890
		private bool ApplyTouchScrolling(Vector2 newScrollOffset); // 0x00000001823A1F60-0x00000001823A21E0
		private bool ReleaseScrolling(int pointerId, IEventHandler target); // 0x00000001823A59D0-0x00000001823A5B10
		private void ExecuteElasticSpringAnimation(); // 0x00000001823A2890-0x00000001823A2A50
		private void AdjustScrollers(); // 0x00000001823A1990-0x00000001823A1BB0
		internal void UpdateScrollers(bool displayHorizontal, bool displayVertical); // 0x00000001823A6C60-0x00000001823A7130
		private void OnScrollersGeometryChanged(GeometryChangedEvent evt); // 0x00000001823A4FE0-0x00000001823A51D0
		private void OnScrollWheel(WheelEvent evt); // 0x00000001823A49E0-0x00000001823A4FE0
		private bool CanAncestorScrollVertically(); // 0x00000001823A21E0-0x00000001823A2290
		private void OnNavigationMove(NavigationMoveEvent evt); // 0x00000001823A3C00-0x00000001823A40E0
		private void OnNavigationSubmit(NavigationSubmitEvent evt); // 0x00000001823A40E0-0x00000001823A41C0
		private void OnFocusOut(FocusOutEvent evt); // 0x00000001823A3700-0x00000001823A3780
		private void OnRootCustomStyleResolved(CustomStyleResolvedEvent evt); // 0x00000001823A30B0-0x00000001823A30C0
		private void MarkSingleLineHeightDirty(); // 0x00000001823A30B0-0x00000001823A30C0
		private void OnRootPointerUp(PointerUpEvent evt); // 0x00000001823A49D0-0x00000001823A49E0
		private void ReadSingleLineHeight(); // 0x00000001823A5640-0x00000001823A59D0
		private void UpdateElasticBehaviour(); // 0x00000001823A6AE0-0x00000001823A6B10
		internal override void OnViewDataReady(); // 0x00000001823A5320-0x00000001823A5410
		[CompilerGenerated]
		private void _.ctor_b__171_0(float value); // 0x00000001823A6750-0x00000001823A6780
		[CompilerGenerated]
		private void _.ctor_b__171_1(float value); // 0x00000001823A6780-0x00000001823A67B0
	}
}
