/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UIElements.Layout;
using UnityEngine.UIElements.StyleSheets;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[UxmlElement(libraryPath = "Containers")]
	public class VisualElement : Focusable, IResolvedStyle, IStylePropertyAnimations, IVisualElementScheduler, ICustomStyle // TypeDefIndex: 4000
	{
		// Fields
		[CompilerGenerated]
		private int _UnityEngine_UIElements_IStylePropertyAnimations_runningAnimationCount_k__BackingField; // 0x30
		[CompilerGenerated]
		private int _UnityEngine_UIElements_IStylePropertyAnimations_completedAnimationCount_k__BackingField; // 0x34
		internal static uint s_NextId; // 0x00
		internal static readonly PropertyName userDataPropertyKey; // 0x04
		public static readonly string disabledUssClassName; // 0x08
		internal static readonly UniqueStyleString disabledUssClassNameUnique; // 0x10
		private string m_Name; // 0x38
		private StyleClassList m_ClassList; // 0x40
		private Dictionary<PropertyName, object> m_PropertyBag; // 0x48
		private VisualElementFlags m_Flags; // 0x50
		private RenderHints m_RenderHints; // 0x54
		internal Rect lastLayout; // 0x58
		internal Rect lastPseudoPadding; // 0x68
		internal RenderData renderData; // 0x78
		internal RenderData nestedRenderData; // 0x80
		internal int insertionIndex; // 0x88
		[CompilerGenerated]
		private int _containedPointerIds_k__BackingField; // 0x8C
		private string m_ViewDataKey; // 0x90
		internal static readonly PropertyName tooltipPropertyKey; // 0x14
		private LanguageDirection m_LanguageDirection; // 0x98
		private LayoutNode m_LayoutNode; // 0xA0
		private readonly unsafe VisualElementTransformData* m_TransformDataPTr; // 0xE0
		private readonly unsafe VisualElementSelectorData* m_SelectorDataPtr; // 0xE8
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleVariableContext variableContext; // 0xF0
		internal int inheritedStylesHash; // 0xF8
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal readonly uint controlid; // 0xFC
		internal int imguiContainerDescendantCount; // 0x100
		internal static int s_FinalizerCount; // 0x18
		private LanguageDirection m_LocalLanguageDirection; // 0x104
		[CompilerGenerated]
		private Action<MeshGenerationContext> _generateVisualContent_k__BackingField; // 0x108
		private static readonly ProfilerMarker k_GenerateVisualContentMarker; // 0x20
		private List<IValueAnimationUpdate> m_RunningAnimations; // 0x110
		internal static readonly BindingId childCountProperty; // 0x28
		internal static readonly BindingId contentRectProperty; // 0xC0
		internal static readonly BindingId dataSourcePathProperty; // 0x158
		internal static readonly BindingId dataSourceProperty; // 0x1F0
		internal static readonly BindingId disablePlayModeTintProperty; // 0x288
		internal static readonly BindingId enabledInHierarchyProperty; // 0x320
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static readonly BindingId enabledSelfProperty; // 0x3B8
		internal static readonly BindingId layoutProperty; // 0x450
		internal static readonly BindingId languageDirectionProperty; // 0x4E8
		internal static readonly BindingId localBoundProperty; // 0x580
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static readonly BindingId nameProperty; // 0x618
		internal static readonly BindingId panelProperty; // 0x6B0
		internal static readonly BindingId pickingModeProperty; // 0x748
		internal static readonly BindingId styleSheetsProperty; // 0x7E0
		internal static readonly BindingId tooltipProperty; // 0x878
		internal static readonly BindingId usageHintsProperty; // 0x910
		internal static readonly BindingId userDataProperty; // 0x9A8
		internal static readonly BindingId viewDataKeyProperty; // 0xA40
		internal static readonly BindingId visibleProperty; // 0xAD8
		internal static readonly BindingId visualTreeAssetSourceProperty; // 0xB70
		internal static readonly BindingId worldBoundProperty; // 0xC08
		internal static readonly BindingId worldTransformProperty; // 0xCA0
		private object m_DataSource; // 0x118
		private PathRef m_DataSourcePath; // 0x120
		private readonly int m_TrickleDownHandleEventCategories; // 0x128
		private readonly int m_BubbleUpHandleEventCategories; // 0x12C
		private int m_BubbleUpEventCallbackCategories; // 0x130
		private int m_TrickleDownEventCallbackCategories; // 0x134
		private int m_EventInterestSelfCategories; // 0x138
		private int m_CachedEventInterestParentCategories; // 0x13C
		private static uint s_NextParentVersion; // 0xD38
		private uint m_NextParentCachedVersion; // 0x140
		private uint m_NextParentRequiredVersion; // 0x144
		private VisualElement m_CachedNextParentWithEventInterests; // 0x148
		[CompilerGenerated]
		private readonly Hierarchy _hierarchy_k__BackingField; // 0x150
		private VisualElement m_PhysicalParent; // 0x158
		private VisualElement m_LogicalParent; // 0x160
		private static readonly List<VisualElement> s_EmptyList; // 0xD40
		private List<VisualElement> m_Children; // 0x168
		[CompilerGenerated]
		private BaseVisualElementPanel _elementPanel_k__BackingField; // 0x170
		private VisualTreeAsset m_VisualTreeAssetSource; // 0x178
		internal List<MeshModifierRegistration> m_MeshModifiers; // 0x180
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal InlineStyleAccess inlineStyleAccess; // 0x188
		internal ResolvedStyleAccess resolvedStyleAccess; // 0x190
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal List<StyleSheet> styleSheetList; // 0x198
		private static readonly Regex s_InternalStyleSheetPath; // 0xD48
		private readonly TypeData m_TypeData; // 0x1A0
		private static readonly Dictionary<Type, TypeData> s_TypeData; // 0xD50
	
		// Properties
		Align IResolvedStyle.alignContent { get; } // 0x0000000182481BE0-0x0000000182481C30 
		Align IResolvedStyle.alignItems { get; } // 0x0000000182481C30-0x0000000182481C90 
		Align IResolvedStyle.alignSelf { get; } // 0x0000000182481C90-0x0000000182481CF0 
		AnimationPlayState IResolvedStyle.animationPlayState { get; } // 0x0000000182481CF0-0x0000000182481D50 
		Ratio IResolvedStyle.aspectRatio { get; } // 0x0000000182481D50-0x0000000182481E20 
		IEnumerable<FilterFunction> IResolvedStyle.backdropFilter { get; } // 0x0000000182481E20-0x0000000182481E80 
		Color IResolvedStyle.backgroundColor { get; } // 0x0000000182481E80-0x0000000182481F50 
		Background IResolvedStyle.backgroundImage { get; } // 0x0000000182481F50-0x0000000182482040 
		BackgroundPosition IResolvedStyle.backgroundPositionX { get; } // 0x0000000182482040-0x0000000182482120 
		BackgroundPosition IResolvedStyle.backgroundPositionY { get; } // 0x0000000182482120-0x0000000182482200 
		BackgroundRepeat IResolvedStyle.backgroundRepeat { get; } // 0x0000000182482200-0x00000001824822D0 
		BackgroundSize IResolvedStyle.backgroundSize { get; } // 0x00000001824822D0-0x00000001824823B0 
		Color IResolvedStyle.borderBottomColor { get; } // 0x00000001824823B0-0x0000000182482480 
		float IResolvedStyle.borderBottomLeftRadius { get; } // 0x0000000182482480-0x00000001824824E0 
		float IResolvedStyle.borderBottomRightRadius { get; } // 0x00000001824824E0-0x0000000182482540 
		float IResolvedStyle.borderBottomWidth { get; } // 0x0000000182482540-0x00000001824825A0 
		Color IResolvedStyle.borderLeftColor { get; } // 0x00000001824825A0-0x0000000182482670 
		float IResolvedStyle.borderLeftWidth { get; } // 0x0000000182482670-0x00000001824826D0 
		Color IResolvedStyle.borderRightColor { get; } // 0x00000001824826D0-0x00000001824827A0 
		float IResolvedStyle.borderRightWidth { get; } // 0x00000001824827A0-0x0000000182482800 
		Color IResolvedStyle.borderTopColor { get; } // 0x0000000182482800-0x00000001824828D0 
		float IResolvedStyle.borderTopLeftRadius { get; } // 0x00000001824828D0-0x0000000182482930 
		float IResolvedStyle.borderTopRightRadius { get; } // 0x0000000182482930-0x0000000182482990 
		float IResolvedStyle.borderTopWidth { get; } // 0x0000000182482990-0x00000001824829F0 
		float IResolvedStyle.bottom { get; } // 0x00000001824829F0-0x0000000182482A50 
		Color IResolvedStyle.color { get; } // 0x0000000182482A50-0x0000000182482B20 
		float IResolvedStyle.columnGap { get; } // 0x0000000182482B20-0x0000000182482B80 
		DisplayStyle IResolvedStyle.display { get; } // 0x0000000182482B80-0x0000000182482BE0 
		IEnumerable<FilterFunction> IResolvedStyle.filter { get; } // 0x0000000182482BE0-0x0000000182482C40 
		StyleFloat IResolvedStyle.flexBasis { get; } // 0x0000000182482C40-0x0000000182482CA0 
		FlexDirection IResolvedStyle.flexDirection { get; } // 0x0000000182482CA0-0x0000000182482D00 
		float IResolvedStyle.flexGrow { get; } // 0x0000000182482D00-0x0000000182482D60 
		float IResolvedStyle.flexShrink { get; } // 0x0000000182482D60-0x0000000182482DC0 
		Wrap IResolvedStyle.flexWrap { get; } // 0x0000000182482DC0-0x0000000182482E20 
		float IResolvedStyle.fontSize { get; } // 0x0000000182482E20-0x0000000182482E80 
		float IResolvedStyle.height { get; } // 0x0000000182482E80-0x0000000182482EE0 
		Justify IResolvedStyle.justifyContent { get; } // 0x0000000182482EE0-0x0000000182482F40 
		float IResolvedStyle.left { get; } // 0x0000000182482F40-0x0000000182482FA0 
		float IResolvedStyle.letterSpacing { get; } // 0x0000000182482FA0-0x0000000182483000 
		float IResolvedStyle.marginBottom { get; } // 0x0000000182483000-0x0000000182483060 
		float IResolvedStyle.marginLeft { get; } // 0x0000000182483060-0x00000001824830C0 
		float IResolvedStyle.marginRight { get; } // 0x00000001824830C0-0x0000000182483120 
		float IResolvedStyle.marginTop { get; } // 0x0000000182483120-0x0000000182483180 
		StyleFloat IResolvedStyle.maxHeight { get; } // 0x0000000182483180-0x00000001824831E0 
		StyleFloat IResolvedStyle.maxWidth { get; } // 0x00000001824831E0-0x0000000182483240 
		StyleFloat IResolvedStyle.minHeight { get; } // 0x0000000182483240-0x00000001824832A0 
		StyleFloat IResolvedStyle.minWidth { get; } // 0x00000001824832A0-0x0000000182483300 
		float IResolvedStyle.opacity { get; } // 0x0000000182483300-0x0000000182483360 
		float IResolvedStyle.paddingBottom { get; } // 0x0000000182483360-0x00000001824833C0 
		float IResolvedStyle.paddingLeft { get; } // 0x00000001824833C0-0x0000000182483420 
		float IResolvedStyle.paddingRight { get; } // 0x0000000182483420-0x0000000182483480 
		float IResolvedStyle.paddingTop { get; } // 0x0000000182483480-0x00000001824834E0 
		Position IResolvedStyle.position { get; } // 0x00000001824834E0-0x0000000182483540 
		float IResolvedStyle.right { get; } // 0x0000000182483540-0x00000001824835A0 
		Rotate IResolvedStyle.rotate { get; } // 0x00000001824835A0-0x0000000182483680 
		float IResolvedStyle.rowGap { get; } // 0x0000000182483680-0x00000001824836E0 
		Scale IResolvedStyle.scale { get; } // 0x00000001824836E0-0x00000001824837B0 
		TextOverflow IResolvedStyle.textOverflow { get; } // 0x00000001824837B0-0x0000000182483810 
		TextShadow IResolvedStyle.textShadow { get; } // 0x0000000182483810-0x00000001824838F0 
		float IResolvedStyle.top { get; } // 0x00000001824838F0-0x0000000182483950 
		Vector3 IResolvedStyle.transformOrigin { get; } // 0x0000000182483950-0x0000000182483A30 
		IEnumerable<TimeValue> IResolvedStyle.transitionDelay { get; } // 0x0000000182483A30-0x0000000182483A90 
		IEnumerable<TimeValue> IResolvedStyle.transitionDuration { get; } // 0x0000000182483A90-0x0000000182483AF0 
		IEnumerable<StylePropertyName> IResolvedStyle.transitionProperty { get; } // 0x0000000182483AF0-0x0000000182483B50 
		IEnumerable<EasingFunction> IResolvedStyle.transitionTimingFunction { get; } // 0x0000000182483B50-0x0000000182483BB0 
		Vector3 IResolvedStyle.translate { get; } // 0x0000000182483BB0-0x0000000182483C90 
		UIAnimationClip IResolvedStyle.unityAnimationClip { get; } // 0x0000000182483C90-0x0000000182483D60 
		Color IResolvedStyle.unityBackgroundImageTintColor { get; } // 0x0000000182483D60-0x0000000182483E30 
		EditorTextRenderingMode IResolvedStyle.unityEditorTextRenderingMode { get; } // 0x0000000182483E30-0x0000000182483E90 
		Font IResolvedStyle.unityFont { get; } // 0x0000000182483FC0-0x0000000182484090 
		FontDefinition IResolvedStyle.unityFontDefinition { get; } // 0x0000000182483E90-0x0000000182483F60 
		FontStyle IResolvedStyle.unityFontStyleAndWeight { get; } // 0x0000000182483F60-0x0000000182483FC0 
		MaterialDefinition IResolvedStyle.unityMaterial { get; } // 0x0000000182484090-0x0000000182484160 
		float IResolvedStyle.unityParagraphSpacing { get; } // 0x0000000182484160-0x00000001824841C0 
		int IResolvedStyle.unitySliceBottom { get; } // 0x00000001824841C0-0x0000000182484220 
		int IResolvedStyle.unitySliceLeft { get; } // 0x0000000182484220-0x0000000182484280 
		int IResolvedStyle.unitySliceRight { get; } // 0x0000000182484280-0x00000001824842E0 
		float IResolvedStyle.unitySliceScale { get; } // 0x00000001824842E0-0x0000000182484340 
		int IResolvedStyle.unitySliceTop { get; } // 0x0000000182484340-0x00000001824843A0 
		SliceType IResolvedStyle.unitySliceType { get; } // 0x00000001824843A0-0x0000000182484400 
		TextAnchor IResolvedStyle.unityTextAlign { get; } // 0x0000000182484400-0x0000000182484460 
		TextGeneratorType IResolvedStyle.unityTextGenerator { get; } // 0x0000000182484460-0x00000001824844C0 
		Color IResolvedStyle.unityTextOutlineColor { get; } // 0x00000001824844C0-0x0000000182484590 
		float IResolvedStyle.unityTextOutlineWidth { get; } // 0x0000000182484590-0x00000001824845F0 
		TextOverflowPosition IResolvedStyle.unityTextOverflowPosition { get; } // 0x00000001824845F0-0x0000000182484650 
		Visibility IResolvedStyle.visibility { get; } // 0x0000000182484650-0x00000001824846B0 
		WhiteSpace IResolvedStyle.whiteSpace { get; } // 0x00000001824846B0-0x0000000182484710 
		float IResolvedStyle.width { get; } // 0x0000000182484710-0x0000000182484770 
		float IResolvedStyle.wordSpacing { get; } // 0x0000000182484770-0x00000001824847D0 
		internal bool hasRunningAnimations { get; } // 0x000000018248AA00-0x000000018248AA50 
		internal bool hasCompletedAnimations { get; } // 0x000000018248A880-0x000000018248A8D0 
		int IStylePropertyAnimations.runningAnimationCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		int IStylePropertyAnimations.completedAnimationCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		internal IStylePropertyAnimations styleAnimation { get; } // 0x0000000180370C60-0x0000000180370C70 
		internal bool isCompositeRoot { get; set; } // 0x000000018248AB10-0x000000018248AB20 0x000000018248CB20-0x000000018248CB50
		internal bool areAncestorsAndSelfDisplayed { get; set; } // 0x0000000182489B00-0x0000000182489B20 0x000000018248C500-0x000000018248C580
		internal bool hasOneOrMorePointerCaptures { get; set; } // 0x000000018248A9F0-0x000000018248AA00 0x000000018248CA90-0x000000018248CAC0
		internal VisualElementFlags flags { get; set; } // 0x000000018248A4A0-0x000000018248A4D0 0x000000018248C9E0-0x000000018248CA90
		internal ref VisualElementTransformFlags transformFlags { get; } // 0x000000018248BC50-0x000000018248BC60 
		internal bool enableViewDataPersistence { get; } // 0x000000018248A420-0x000000018248A430 
		[CreateProperty]
		public object userData { get; set; } // 0x000000018248C070-0x000000018248C110 0x000000018248D6F0-0x000000018248D820
		public override bool canGrabFocus { get; } // 0x0000000182489D70-0x0000000182489E80 
		public override FocusController focusController { get; } // 0x000000018248A4D0-0x000000018248A5A0 
		[CreateProperty]
		public bool disablePlayModeTint { get; set; } // 0x00000001802E7990-0x00000001802E79A0 0x00000001802E76C0-0x00000001802E76D0
		internal Color playModeTintColor { [VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })] get; } // 0x000000018248B7E0-0x000000018248B820 
		internal RenderHints renderHints { get; set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x000000018248D090-0x000000018248D0F0
		internal bool useRenderTexture { get; } // 0x000000018248BD60-0x000000018248C070 
		internal bool hasBackdropFilter { get; } // 0x000000018248A850-0x000000018248A880 
		public float scaledPixelsPerPoint { get; } // 0x000000018248BA70-0x000000018248BAF0 
		internal float scaledPixelsPerPoint_noChecks { get; } // 0x000000018248BAF0-0x000000018248BB10 
		[CreateProperty(ReadOnly = true)]
		public Rect layout { get; } // 0x000000018248AD10-0x000000018248ADD0 
		internal bool hasSize { get; } // 0x000000018248AA50-0x000000018248AAD0 
		[CreateProperty(ReadOnly = true)]
		public Rect contentRect { get; } // 0x0000000182489FD0-0x000000018248A2E0 
		protected Rect paddingRect { get; } // 0x000000018248B5E0-0x000000018248B7C0 
		internal bool needs3DBounds { get; set; } // 0x000000018248B400-0x000000018248B420 0x000000018248CE80-0x000000018248CEB0
		internal bool isLocalBounds3DDirty { get; set; } // 0x000000018248AB50-0x000000018248AB70 0x000000018248CB80-0x000000018248CBB0
		internal bool isLocalBoundsWithoutNested3DDirty { get; set; } // 0x000000018248AB70-0x000000018248AB90 0x000000018248CBB0-0x000000018248CBE0
		internal bool isBoundingBoxDirty { get; set; } // 0x000000018248AAD0-0x000000018248AAF0 0x000000018248CAC0-0x000000018248CAF0
		internal bool isBoundingBoxWithoutNestedDirty { get; set; } // 0x000000018248AAF0-0x000000018248AB10 0x000000018248CAF0-0x000000018248CB20
		internal Rect boundingBox { get; } // 0x0000000182489CC0-0x0000000182489D70 
		internal Rect boundingBoxWithoutNested { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x0000000182489C00-0x0000000182489CC0 
		private Rect boundingBoxInParentSpace { get; } // 0x0000000182489B40-0x0000000182489C00 
		internal Bounds localBounds3D { get; } // 0x000000018248B050-0x000000018248B210 
		internal Bounds localBoundsPicking3D { get; } // 0x000000018248B210-0x000000018248B3E0 
		internal Bounds localBounds3DWithoutNested3D { get; } // 0x000000018248AE80-0x000000018248B050 
		[CreateProperty(ReadOnly = true)]
		public Rect worldBound { get; } // 0x000000018248C170-0x000000018248C2C0 
		[CreateProperty(ReadOnly = true)]
		public Rect localBound { get; } // 0x000000018248ADD0-0x000000018248AE80 
		internal Rect rect { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018248B960-0x000000018248B9D0 
		internal Vector2 layoutSize { get; } // 0x000000018248ACA0-0x000000018248AD10 
		internal Vector2 layoutPosition { get; } // 0x000000018248AC30-0x000000018248ACA0 
		internal bool isWorldSpaceRootPanelComponent { get; set; } // 0x000000018248ABD0-0x000000018248ABE0 0x000000018248CBE0-0x000000018248CC10
		internal bool isWorldTransformDirty { get; } // 0x000000018248ABE0-0x000000018248AC00 
		internal bool isWorldTransformInverseDirty { set; } // 0x000000018248CC10-0x000000018248CC40
		internal bool isWorldTransformInverseOrDependenciesDirty { get; } // 0x000000018248AC00-0x000000018248AC20 
		[CreateProperty(ReadOnly = true)]
		public Matrix4x4 worldTransform { get; } // 0x000000018248C460-0x000000018248C500 
		internal ref Matrix4x4 worldTransformRef { get; } // 0x000000018248C3E0-0x000000018248C460 
		internal ref Matrix4x4 worldTransformInverse { [VisibleToOtherModules(new string[2] {"UnityEditor.GraphToolkitModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018248C380-0x000000018248C3E0 
		internal Rect worldClip { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018248C2C0-0x000000018248C380 
		internal bool receivesHierarchyGeometryChangedEvents { get; set; } // 0x000000018248B950-0x000000018248B960 0x000000018248D060-0x000000018248D090
		internal bool boundingBoxDirtiedSinceLastLayoutPass { get; set; } // 0x0000000182489B20-0x0000000182489B40 0x000000018248C580-0x000000018248C5B0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal PseudoStates pseudoStates { get; set; } // 0x000000018248B8D0-0x000000018248B950 0x000000018248CF90-0x000000018248D060
		internal int containedPointerIds { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D640-0x000000018033D650 0x000000018033EC20-0x000000018033EC30
		[CreateProperty]
		[HideInInspector]
		[UxmlAttribute]
		[UxmlInternalField]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		public string name { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018248CDA0-0x000000018248CE80
		[CreateProperty]
		[Tooltip("Sets the element to disabled which will not accept input. Utilizes the :disabled pseudo state.")]
		[UxmlAttribute("enabled")]
		public bool enabledSelf { get; set; } // 0x000000018248A450-0x000000018248A460 0x000000018247F8B0-0x000000018247F9F0
		[CreateProperty]
		[UxmlAttribute]
		public string viewDataKey { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x000000018248D850-0x000000018248D930
		[CreateProperty]
		[UxmlAttribute("picking-mode", new string[1] {"pickingMode" })]
		public PickingMode pickingMode { get; set; } // 0x000000018248B7C0-0x000000018248B7E0 0x000000018248CEB0-0x000000018248CF90
		[CreateProperty]
		[UxmlAttribute]
		public string tooltip { get; set; } // 0x000000018248BBC0-0x000000018248BC50 0x000000018248D200-0x000000018248D400
		[CreateProperty]
		[UxmlAttribute]
		public UsageHints usageHints { get; set; } // 0x000000018248BD20-0x000000018248BD60 0x000000018248D400-0x000000018248D6F0
		[CreateProperty]
		[UxmlAttribute]
		public LanguageDirection languageDirection { get; set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018248CC40-0x000000018248CCD0
		internal string typeName { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018248BCF0-0x000000018248BD20 
		internal int typeNameId { get; } // 0x000000018248BC60-0x000000018248BCF0 
		internal int nameId { get; } // 0x000000018248B3E0-0x000000018248B400 
		internal ref LayoutNode layoutNode { get; } // 0x000000018248AC20-0x000000018248AC30 
		private ref VisualElementTransformData transformData { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		internal unsafe VisualElementSelectorData* selectorDataPtr { get; } // 0x00000001806BAE70-0x00000001806BAE80 
		internal ref ComputedStyle computedStyle { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x0000000182489FC0-0x0000000182489FD0 
		internal bool hasInlineStyle { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018248A9E0-0x000000018248A9F0 
		internal bool styleInitialized { get; set; } // 0x000000018248BB10-0x000000018248BB20 0x000000018248D170-0x000000018248D1A0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool stylesDirty { get; set; } // 0x000000018248BBB0-0x000000018248BBC0 0x000000018248D1D0-0x000000018248D200
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool stylesAncestorOfDirty { get; set; } // 0x000000018248BBA0-0x000000018248BBB0 0x000000018248D1A0-0x000000018248D1D0
		public bool resourcesReleased { get; } // 0x000000018248BA60-0x000000018248BA70 
		[CreateProperty(ReadOnly = true)]
		public bool enabledInHierarchy { get; } // 0x000000018248A430-0x000000018248A450 
		internal LanguageDirection localLanguageDirection { get; set; } // 0x0000000181E8FE20-0x0000000181E8FE30 0x000000018248CCD0-0x000000018248CDA0
		[CreateProperty]
		public bool visible { get; set; } // 0x000000018248C110-0x000000018248C170 0x000000018248D930-0x000000018248DB60
		public Action<MeshGenerationContext> generateVisualContent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000180CDC990-0x0000000180CDC9B0
		internal bool requireMeasureFunction { get; set; } // 0x000000018248B9D0-0x000000018248B9E0 0x000000018248D0F0-0x000000018248D170
		internal bool usesContainsPoint { set; } // 0x000000018248D820-0x000000018248D850
		[CreateProperty]
		public object dataSource { get; set; } // 0x000000018171E0D0-0x000000018171E0E0 0x000000018248C860-0x000000018248C940
		[CreateProperty]
		public PropertyPath dataSourcePath { get; set; } // 0x000000018248A340-0x000000018248A3F0 0x000000018248C5B0-0x000000018248C860
		internal bool isDataSourcePathEmpty { get; } // 0x000000018248AB20-0x000000018248AB40 
		internal VisualElement nextParentWithEventInterests { get; } // 0x000000018248B420-0x000000018248B5E0 
		internal int eventInterestParentCategories { get; } // 0x000000018248A460-0x000000018248A4A0 
		internal bool isEventInterestParentCategoriesDirty { get; set; } // 0x000000018248AB40-0x000000018248AB50 0x000000018248CB50-0x000000018248CB80
		public Hierarchy hierarchy { [CompilerGenerated] get; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 
		internal bool isRootVisualContainer { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018248AB90-0x000000018248ABD0 
		internal bool disableClipping { get; set; } // 0x000000018248A3F0-0x000000018248A410 0x000000018248C940-0x000000018248C970
		internal bool disableRendering { get; set; } // 0x000000018248A410-0x000000018248A420 0x000000018248C970-0x000000018248C9E0
		public VisualElement parent { get; } // 0x00000001819746D0-0x00000001819746E0 
		internal BaseVisualElementPanel elementPanel { [VisibleToOtherModules(new string[3] {"UnityEditor.UIBuilderModule", "UnityEditor.GraphToolkitModule", "UnityEditor.UIToolkitAuthoringModule" })] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181974700-0x0000000181974710 0x00000001813800D0-0x00000001813800F0
		[CreateProperty(ReadOnly = true)]
		public IPanel panel { get; } // 0x0000000181974700-0x0000000181974710 
		public virtual VisualElement contentContainer { get; } // 0x0000000180370C60-0x0000000180370C70 
		[CreateProperty(ReadOnly = true)]
		public VisualTreeAsset visualTreeAssetSource { get; [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] internal set; } // 0x0000000181CF6CA0-0x0000000181CF6CB0 0x00000001813800F0-0x0000000181380110
		public VisualElement this[int key] { get => default; } // 0x0000000182489A60-0x0000000182489B00 
		[CreateProperty(ReadOnly = true)]
		public int childCount { get; } // 0x0000000182489E80-0x0000000182489F00 
		internal IReadOnlyList<VisualElement> children { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x0000000182489F00-0x0000000182489FC0 
		private Vector3 positionWithLayout { get; } // 0x000000018248B820-0x000000018248B8D0 
		internal bool hasDefaultRotationAndScale { get; } // 0x000000018248A8D0-0x000000018248A9E0 
		internal bool has3DTransform { get; } // 0x000000018248A6A0-0x000000018248A810 
		internal bool has3DTranslation { get; } // 0x000000018248A810-0x000000018248A850 
		private bool has3DRotation { get; } // 0x000000018248A5A0-0x000000018248A6A0 
		public IVisualElementScheduler schedule { get; } // 0x0000000180370C60-0x0000000180370C70 
		internal CustomStyleAccess customStyleAccess { get; } // 0x000000018248A2E0-0x000000018248A340 
		[CreateProperty]
		public IStyle style { get; } // 0x000000018248BB20-0x000000018248BBA0 
		[CreateProperty]
		public IResolvedStyle resolvedStyle { get; } // 0x000000018248B9E0-0x000000018248BA60 
		public ICustomStyle customStyle { get; } // 0x0000000180370C60-0x0000000180370C70 
		[CreateProperty(ReadOnly = true)]
		public VisualElementStyleSheetSet styleSheets { get; } // 0x0000000180E10430-0x0000000180E10450 
		internal TypeData typeData { get; } // 0x0000000181CC2A50-0x0000000181CC2A60 
	
		// Nested types
		public enum MeasureMode // TypeDefIndex: 4001
		{
			Undefined = 0,
			Exactly = 1,
			AtMost = 2
		}
	
		internal struct DefaultEventInterests // TypeDefIndex: 4002
		{
			// Fields
			public int DefaultActionCategories; // 0x00
			public int DefaultActionAtTargetCategories; // 0x04
			public int HandleEventTrickleDownCategories; // 0x08
			public int HandleEventBubbleUpCategories; // 0x0C
		}
	
		public struct Hierarchy // TypeDefIndex: 4003
		{
			// Fields
			private readonly VisualElement m_Owner; // 0x00
	
			// Properties
			public VisualElement parent { get; } // 0x0000000182477700-0x0000000182477720 
			internal List<VisualElement> children { get; } // 0x00000001824776E0-0x0000000182477700 
			public int childCount { get; } // 0x00000001824776B0-0x00000001824776E0 
			public VisualElement this[int key] { get => default; } // 0x0000000182476340-0x0000000182476370 
	
			// Constructors
			internal Hierarchy(VisualElement element); // 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			private void ValidateElementCanBeModified(); // 0x00000001824775C0-0x00000001824776B0
			public void Add(VisualElement child); // 0x0000000182475C50-0x0000000182475CE0
			public void Insert(int index, VisualElement child); // 0x0000000182476450-0x0000000182476A10
			public void Remove(VisualElement child); // 0x00000001824771B0-0x00000001824772E0
			public void RemoveAt(int index); // 0x0000000182476D30-0x00000001824770F0
			public void Clear(); // 0x0000000182475CE0-0x0000000182475CF0
			public void Clear(VisualElementClearOptions options); // 0x0000000182475CF0-0x0000000182476340
			public int IndexOf(VisualElement element); // 0x00000001824763F0-0x0000000182476450
			public VisualElement ElementAt(int index); // 0x0000000182476340-0x0000000182476370
			private void SetParent(VisualElement value); // 0x0000000182477420-0x0000000182477550
			private void SetParent(VisualElement value, List<VisualElement> selfAndDescendants); // 0x00000001824772E0-0x0000000182477420
			private void PutChildAtIndex(VisualElement child, int index); // 0x0000000182476A10-0x0000000182476C50
			private void RemoveChildAtIndex(int index); // 0x00000001824770F0-0x00000001824771B0
			private void ReleaseChildList(); // 0x0000000182476C50-0x0000000182476D30
			public bool Equals(Hierarchy other); // 0x000000018222B040-0x000000018222B050
			public override bool Equals(object obj); // 0x0000000182476370-0x00000001824763F0
			public override int GetHashCode(); // 0x0000000181302320-0x0000000181302340
			public static bool operator ==(Hierarchy x, Hierarchy y); // 0x0000000180A29AB0-0x0000000180A29AC0
			[CompilerGenerated]
			internal static void _Clear_g__ClearInternal_13_0(Hierarchy hierarchy, bool clearNativeData = true /* Metadata: 0x006604D7 */); // 0x0000000182477550-0x00000001824775C0
		}
	
		private abstract class BaseVisualElementScheduledItem : ScheduledItem, IVisualElementScheduledItem // TypeDefIndex: 4004
		{
			// Fields
			[CompilerGenerated]
			private VisualElement _element_k__BackingField; // 0x38
			public TimerEventScheduler scheduler; // 0x40
			[CompilerGenerated]
			private bool _isActive_k__BackingField; // 0x48
			[CompilerGenerated]
			private bool _isDetaching_k__BackingField; // 0x49
			private readonly EventCallback<AttachToPanelEvent> m_OnAttachToPanelCallback; // 0x50
			private readonly EventCallback<DetachFromPanelEvent> m_OnDetachFromPanelCallback; // 0x58
	
			// Properties
			public VisualElement element { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
			public bool isScheduled { get; } // 0x0000000180D905C0-0x0000000180D905D0 
			public bool isActive { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
			public bool isDetaching { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181A42150-0x0000000181A42160 0x0000000182042F70-0x0000000182042F80
	
			// Constructors
			protected BaseVisualElementScheduledItem(VisualElement handler); // 0x0000000182470040-0x0000000182470170
	
			// Methods
			private void SetActive(bool action); // 0x000000018246FF30-0x0000000182470030
			private void SendActivation(); // 0x000000018246FE10-0x000000018246FEC0
			private void SendDeactivation(); // 0x000000018246FEC0-0x000000018246FF30
			private void OnElementAttachToPanelCallback(AttachToPanelEvent evt); // 0x000000018246FB40-0x000000018246FC60
			private void OnElementDetachFromPanelCallback(DetachFromPanelEvent evt); // 0x000000018246FC60-0x000000018246FCD0
			public IVisualElementScheduledItem StartingIn(long delayMs); // 0x0000000182470030-0x0000000182470040
			public IVisualElementScheduledItem Every(long intervalMs); // 0x000000018246FA40-0x000000018246FAE0
			internal override void OnItemUnscheduled(); // 0x000000018246FCD0-0x000000018246FD20
			public void Resume(); // 0x000000018246FE00-0x000000018246FE10
			public void Pause(); // 0x000000018246FDF0-0x000000018246FE00
			public void ExecuteLater(long delayMs); // 0x000000018246FAE0-0x000000018246FB40
			public void OnPanelActivate(); // 0x000000018246FD20-0x000000018246FDA0
			public void OnPanelDeactivate(); // 0x000000018246FDA0-0x000000018246FDF0
			public bool CanBeActivated(); // 0x000000018246FA00-0x000000018246FA40
		}
	
		private abstract class VisualElementScheduledItem<ActionType> : BaseVisualElementScheduledItem // TypeDefIndex: 4005
		{
			// Fields
			public ActionType updateEvent;
	
			// Constructors
			public VisualElementScheduledItem(VisualElement handler, ActionType upEvent);
		}
	
		private class TimerStateScheduledItem : VisualElementScheduledItem<Action<TimerState>> // TypeDefIndex: 4006
		{
			// Constructors
			public TimerStateScheduledItem(VisualElement handler, Action<TimerState> updateEvent); // 0x0000000182477760-0x0000000182477770
	
			// Methods
			public override void PerformTimerUpdate(TimerState state); // 0x0000000182477770-0x00000001824777B0
		}
	
		private class SimpleScheduledItem : VisualElementScheduledItem<Action> // TypeDefIndex: 4007
		{
			// Constructors
			public SimpleScheduledItem(VisualElement handler, Action updateEvent); // 0x0000000182477760-0x0000000182477770
	
			// Methods
			public override void PerformTimerUpdate(TimerState state); // 0x0000000182477720-0x0000000182477760
		}
	
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		internal struct CustomStyleAccess // TypeDefIndex: 4008
		{
			// Fields
			private CustomPropertyListRef m_CustomProperties; // 0x00
			private float m_DpiScaling; // 0x08
	
			// Constructors
			public CustomStyleAccess(VisualElement self); // 0x0000000182470560-0x00000001824705C0
	
			// Methods
			public bool TryGetValue(CustomStyleProperty<float> property, out float value); // 0x0000000182470400-0x0000000182470560
			public bool TryGetValue(CustomStyleProperty<Color> property, out Color value); // 0x0000000182470240-0x00000001824702E0
			private bool TryGetValue(int nameId, string nameForLog, StyleValueType valueType, out StylePropertyValue customProp); // 0x00000001824702E0-0x0000000182470400
			private static void LogCustomPropertyWarning(string propertyName, StyleValueType valueType, StylePropertyValue customProp); // 0x0000000182470170-0x0000000182470240
		}
	
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal class TypeData // TypeDefIndex: 4009
		{
			// Fields
			[CompilerGenerated]
			private readonly Type _type_k__BackingField; // 0x10
			private readonly DefaultEventInterests m_DefaultEventInterests; // 0x18
			[CompilerGenerated]
			private readonly bool _hasContainsPoint_k__BackingField; // 0x28
			[CompilerGenerated]
			private readonly IEventInvoker _selfEventInvoker_k__BackingField; // 0x30
			private string m_FullTypeName; // 0x38
			private string m_TypeName; // 0x40
			private int m_TypeNameId; // 0x48
	
			// Properties
			public Type type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
			internal DefaultEventInterests defaultEventInterests { get; } // 0x0000000180A5E120-0x0000000180A5E130 
			internal bool hasContainsPoint { [CompilerGenerated] get; } // 0x0000000180327270-0x0000000180327280 
			internal IEventInvoker selfEventInvoker { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
			public string typeName { get; } // 0x0000000182477B90-0x0000000182477C60 
			public int typeNameId { get; } // 0x0000000182477B00-0x0000000182477B90 
	
			// Constructors
			public TypeData(Type type); // 0x00000001824777B0-0x0000000182477B00
		}
	
		private class TypeReferenceComparer : IEqualityComparer<Type> // TypeDefIndex: 4010
		{
			// Constructors
			public TypeReferenceComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool Equals(Type x, Type y); // 0x000000018171AC80-0x000000018171AC90
			public int GetHashCode(Type obj); // 0x000000018171AC90-0x000000018171ACA0
		}
	
		// Constructors
		public VisualElement(); // 0x0000000182489420-0x0000000182489A60
		static VisualElement(); // 0x0000000182488060-0x0000000182489420
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal IStylePropertyAnimationSystem GetStylePropertyAnimationSystem(); // 0x000000018247CB50-0x000000018247CB80
		bool IStylePropertyAnimations.Start(StylePropertyId id, float from, float to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x00000001824853E0-0x0000000182485530
		bool IStylePropertyAnimations.Start(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485C60-0x0000000182485D20
		bool IStylePropertyAnimations.Start(StylePropertyId id, Length from, Length to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182484E10-0x0000000182484F50
		bool IStylePropertyAnimations.Start(StylePropertyId id, Color from, Color to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485E60-0x0000000182485FD0
		bool IStylePropertyAnimations.StartEnum(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182484AB0-0x0000000182484B70
		bool IStylePropertyAnimations.Start(StylePropertyId id, EntityId from, EntityId to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182484B70-0x0000000182484CB0
		bool IStylePropertyAnimations.Start(StylePropertyId id, TextShadow from, TextShadow to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182486160-0x0000000182486300
		bool IStylePropertyAnimations.Start(StylePropertyId id, Scale from, Scale to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x00000001824856A0-0x0000000182485810
		bool IStylePropertyAnimations.Start(StylePropertyId id, Translate from, Translate to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485FD0-0x0000000182486160
		bool IStylePropertyAnimations.Start(StylePropertyId id, Rotate from, Rotate to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485250-0x00000001824853E0
		bool IStylePropertyAnimations.Start(StylePropertyId id, Ratio from, Ratio to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182484CB0-0x0000000182484E10
		bool IStylePropertyAnimations.Start(StylePropertyId id, TransformOrigin from, TransformOrigin to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485950-0x0000000182485AD0
		bool IStylePropertyAnimations.Start(StylePropertyId id, BackgroundPosition from, BackgroundPosition to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x00000001824850D0-0x0000000182485250
		bool IStylePropertyAnimations.Start(StylePropertyId id, BackgroundRepeat from, BackgroundRepeat to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485D20-0x0000000182485E60
		bool IStylePropertyAnimations.Start(StylePropertyId id, BackgroundSize from, BackgroundSize to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182484F50-0x00000001824850D0
		bool IStylePropertyAnimations.Start(StylePropertyId id, List<FilterFunction> from, List<FilterFunction> to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485810-0x0000000182485950
		bool IStylePropertyAnimations.Start(StylePropertyId id, MaterialDefinition from, MaterialDefinition to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485530-0x00000001824856A0
		bool IStylePropertyAnimations.Start(StylePropertyId id, Cursor from, Cursor to, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182485AD0-0x0000000182485C60
		void IStylePropertyAnimations.CancelAnimation(StylePropertyId id); // 0x00000001824848C0-0x0000000182484940
		void IStylePropertyAnimations.CancelAllAnimations(); // 0x00000001824847D0-0x00000001824848C0
		void IStylePropertyAnimations.UpdateAnimation(StylePropertyId id); // 0x0000000182486300-0x0000000182486380
		void IStylePropertyAnimations.GetAllAnimations(List<StylePropertyId> outPropertyIds); // 0x0000000182484940-0x0000000182484AB0
		internal bool TryConvertLengthUnits(StylePropertyId id, ref Length from, ref Length to, int subPropertyIndex = 0 /* Metadata: 0x006604D1 */); // 0x0000000182481450-0x0000000182481690
		internal bool TryConvertTransformOriginUnits(ref TransformOrigin from, ref TransformOrigin to); // 0x0000000182481690-0x0000000182481740
		internal bool TryConvertTranslateUnits(ref Translate from, ref Translate to); // 0x0000000182481740-0x00000001824817F0
		internal bool TryConvertBackgroundSizeUnits(ref BackgroundSize from, ref BackgroundSize to); // 0x0000000182481390-0x0000000182481450
		private float? GetParentSizeForLengthConversion(StylePropertyId id, int subPropertyIndex = 0 /* Metadata: 0x006604D2 */); // 0x000000018247C210-0x000000018247C4B0
		internal void MarkRenderHintsClean(); // 0x000000018247D620-0x000000018247D630
		internal void UpdateBoundingBox(); // 0x0000000182486B10-0x0000000182486B60
		internal void UpdateBoundingBoxWithoutNested(); // 0x0000000182486640-0x0000000182486B10
		private void UpdateBounds3D(); // 0x0000000182486B60-0x0000000182487130
		internal void UpdateWorldTransform(); // 0x0000000182487D00-0x0000000182487D50
		internal void UpdateWorldTransformNative(); // 0x0000000182487CB0-0x0000000182487D00
		internal void UpdateWorldTransformInverse(); // 0x0000000182487C60-0x0000000182487CB0
		internal void EnsureWorldTransformAndClipUpToDate(); // 0x000000018247B7C0-0x000000018247B860
		internal void UpdatePseudoState(PseudoStates bit, bool on); // 0x0000000182487BD0-0x0000000182487C60
		private void ApplyPseudoStateChange(PseudoStates value); // 0x000000018247A430-0x000000018247A490
		public void SetActivePseudoState(bool value); // 0x000000018247F5B0-0x000000018247F5F0
		internal void UpdateHoverPseudoState(); // 0x00000001824879D0-0x0000000182487B10
		private static bool IsPartOfCapturedChain(VisualElement self, [IsReadOnly] in IEventHandler capturingElement); // 0x000000018247D520-0x000000018247D5F0
		internal void UpdateHoverPseudoStateAfterCaptureChange(int pointerId); // 0x0000000182487940-0x00000001824879D0
		internal void UpdatePointerCaptureFlag(); // 0x0000000182487B10-0x0000000182487BD0
		[VisibleToOtherModules(new string[3] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule", "UnityEngine.HierarchyModule" })]
		internal void SetName(UniqueStyleString uniqueName); // 0x000000018247FBC0-0x000000018247FC60
		private void SetNameId(int nameId); // 0x000000018247FAC0-0x000000018247FBC0
		private void ChangeIMGUIContainerCount(int delta); // 0x000000018247B080-0x000000018247B0C0
		~VisualElement(); // 0x000000018247B8F0-0x000000018247BA50
		public void ReleaseResources(); // 0x000000018247E880-0x000000018247E9B0
		internal void ReleaseResourcesNoChecks(); // 0x000000018247E710-0x000000018247E880
		internal void SetTooltip(TooltipEvent e); // 0x0000000182480830-0x0000000182480BB0
		public sealed override void Focus(); // 0x000000018247BBE0-0x000000018247BC60
		internal long TimeSinceStartupMs(); // 0x0000000182480C00-0x0000000182480C80
		internal void SetPanel(BaseVisualElementPanel p); // 0x0000000182480560-0x0000000182480700
		internal void SetPanelBatched(BaseVisualElementPanel p, List<VisualElement> elements); // 0x000000018247FC60-0x0000000182480560
		private void WillChangePanel(BaseVisualElementPanel destinationPanel); // 0x0000000182487D50-0x0000000182488060
		private void HasChangedPanel(BaseVisualElementPanel prevPanel); // 0x000000018247CBC0-0x000000018247CFE0
		public sealed override void SendEvent(EventBase e); // 0x000000018247F570-0x000000018247F590
		internal sealed override void SendEvent(EventBase e, DispatchMode dispatchMode); // 0x000000018247F590-0x000000018247F5B0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void IncrementVersion(VersionChangeType changeType); // 0x000000018247D1A0-0x000000018247D1D0
		internal void InvokeHierarchyChanged(HierarchyChangeType changeType, IReadOnlyList<VisualElement> additionalContext = null); // 0x000000018247D4F0-0x000000018247D520
		private void ApplyDisableHierarchy(); // 0x000000018247A2F0-0x000000018247A430
		private void RemoveDisableHierarchy(); // 0x000000018247E9B0-0x000000018247EAF0
		private void BlurHierarchyImmediately(); // 0x000000018247A4D0-0x000000018247A720
		public void SetEnabled(bool value); // 0x000000018247F8B0-0x000000018247F9F0
		private void PropagateParentEnabled(bool parentEnabled); // 0x000000018247E260-0x000000018247E320
		private void PropagateSelfEnabled(bool value); // 0x000000018247E320-0x000000018247E550
		public void MarkDirtyRepaint(); // 0x000000018247D5F0-0x000000018247D620
		internal void InvokeGenerateVisualContent(MeshGenerationContext mgc); // 0x000000018247D3A0-0x000000018247D4F0
		internal void GetFullHierarchicalViewDataKey(StringBuilder key); // 0x000000018247BF70-0x000000018247C010
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal string GetFullHierarchicalViewDataKey(); // 0x000000018247BEB0-0x000000018247BF70
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void OverwriteFromViewData(object obj, string key); // 0x000000018247DDB0-0x000000018247E120
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void SaveViewData(); // 0x000000018247F4D0-0x000000018247F570
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal virtual void OnViewDataReady(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual bool ContainsPoint(Vector2 localPoint); // 0x000000018247B440-0x000000018247B530
		private void AssignMeasureFunction(); // 0x000000018247A490-0x000000018247A4B0
		private void RemoveMeasureFunction(); // 0x000000018247EC90-0x000000018247ECB0
		protected internal virtual Vector2 DoMeasure(float desiredWidth, MeasureMode widthMode, float desiredHeight, MeasureMode heightMode); // 0x000000018247B6E0-0x000000018247B700
		internal static void Measure(ref LayoutNode node, float width, LayoutMeasureMode widthMode, float height, LayoutMeasureMode heightMode, out LayoutSize result); // 0x000000018247D640-0x000000018247D940
		private void FinalizeLayout(VersionChangeType changes); // 0x000000018247B860-0x000000018247B8F0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void SetInlineRule(StyleSheet sheet, StyleRule rule, StyleVariableContext variableContext = null); // 0x000000018247F9F0-0x000000018247FAC0
		internal void SetComputedStyle(ref ComputedStyle newStyle); // 0x000000018247F6B0-0x000000018247F8B0
		public override string ToString(); // 0x0000000182480C80-0x0000000182480F60
		internal StyleClassListRef GetClassesForIteration(); // 0x0000000180377940-0x0000000180377950
		private void UpdateClassSelectorData(); // 0x0000000182487130-0x00000001824871F0
		public void AddToClassList(string className); // 0x000000018247A030-0x000000018247A070
		public void AddToClassList(UniqueStyleString className); // 0x0000000182479F90-0x000000018247A030
		public void AddToClassList(params UniqueStyleString[] classNames); // 0x0000000182479EA0-0x0000000182479F90
		public void AddToClassList(ReadOnlySpan<UniqueStyleString> classNames); // 0x000000018247A070-0x000000018247A120
		public void RemoveFromClassList(UniqueStyleString className); // 0x000000018247EAF0-0x000000018247EB90
		public void EnableInClassList(UniqueStyleString className, bool enable); // 0x000000018247B700-0x000000018247B7C0
		public bool ClassListContains(string cls); // 0x000000018247B280-0x000000018247B340
		public bool ClassListContains(UniqueStyleString cls); // 0x000000018247B340-0x000000018247B3A0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal object GetProperty(PropertyName key); // 0x000000018247CA00-0x000000018247CAA0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void SetProperty(PropertyName key, object value); // 0x00000001824807C0-0x0000000182480830
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal bool HasProperty(PropertyName key); // 0x000000018247D0A0-0x000000018247D130
		private static void CheckUserKeyArgument(PropertyName key); // 0x000000018247B0C0-0x000000018247B230
		private void SetPropertyInternal(PropertyName key, object value); // 0x0000000182480700-0x00000001824807C0
		internal void UpdateCursorStyle(long eventType); // 0x00000001824871F0-0x0000000182487590
		private VisualElementAnimationSystem GetAnimationSystem(); // 0x000000018247BD10-0x000000018247BDC0
		internal void RegisterAnimation(IValueAnimationUpdate anim); // 0x000000018247E550-0x000000018247E670
		internal void UnregisterAnimation(IValueAnimationUpdate anim); // 0x0000000182486500-0x0000000182486580
		private void UnregisterRunningAnimations(); // 0x0000000182486580-0x0000000182486640
		private void RegisterRunningAnimations(); // 0x000000018247E670-0x000000018247E710
		public bool TryGetBinding(BindingId bindingId, out Binding binding); // 0x00000001824817F0-0x00000001824818B0
		private void ProcessBindingRequests(); // 0x000000018247E120-0x000000018247E1E0
		private void CreateBindingRequests(); // 0x000000018247B580-0x000000018247B620
		private void TrackSource(object previous, object current); // 0x0000000182480F60-0x0000000182480FF0
		private void DetachDataSource(); // 0x000000018247B620-0x000000018247B650
		private void AttachDataSource(); // 0x000000018247A4B0-0x000000018247A4D0
		private void DirtyNextParentWithEventInterests(); // 0x000000018247B650-0x000000018247B6E0
		internal void SetAsNextParentWithEventInterests(); // 0x000000018247F5F0-0x000000018247F6B0
		internal bool GetCachedNextParentWithEventInterests(out VisualElement nextParent); // 0x000000018247BDC0-0x000000018247BE20
		private void PropagateCachedNextParentWithEventInterests(VisualElement nextParent, VisualElement stopParent); // 0x000000018247E1E0-0x000000018247E260
		internal void AddEventCallbackCategories(int trickleDownCategories, int bubbleUpCategories); // 0x0000000182479C70-0x0000000182479C90
		internal void AddEventCallbackCategories(int eventCategories, CallbackOptionsInternal callbackOptions); // 0x0000000182479C50-0x0000000182479C70
		private void UpdateEventInterestSelfCategories(); // 0x00000001824877C0-0x0000000182487900
		private void UpdateEventInterestParentCategories(); // 0x0000000182487590-0x00000001824877C0
		internal bool HasParentEventInterests(EventCategory eventCategory); // 0x000000018247D040-0x000000018247D0A0
		internal bool HasParentEventInterests(int eventCategories); // 0x000000018247CFE0-0x000000018247D040
		internal bool HasSelfEventInterests(EventCategory eventCategory); // 0x000000018247D130-0x000000018247D150
		internal bool HasSelfEventInterests(int eventCategories); // 0x000000018247D150-0x000000018247D160
		internal bool HasTrickleDownEventInterests(int eventCategories); // 0x000000018247D170-0x000000018247D190
		internal bool HasBubbleUpEventInterests(int eventCategories); // 0x000000018247CB90-0x000000018247CBB0
		internal bool HasTrickleDownEventCallbacks(int eventCategories); // 0x000000018247D160-0x000000018247D170
		internal bool HasBubbleUpEventCallbacks(int eventCategories); // 0x000000018247CB80-0x000000018247CB90
		internal bool HasTrickleDownHandleEvent(int eventCategories); // 0x000000018247D190-0x000000018247D1A0
		internal bool HasBubbleUpHandleEvent(int eventCategories); // 0x000000018247CBB0-0x000000018247CBC0
		internal bool ShouldClip(); // 0x0000000182480BB0-0x0000000182480C00
		private void UpdateHierarchySelectorData(VisualElement logicalParent); // 0x0000000182487900-0x0000000182487940
		public void Add(VisualElement child); // 0x000000018247A1D0-0x000000018247A2F0
		internal void Add(VisualElement child, bool ignoreContentContainer); // 0x000000018247A120-0x000000018247A1D0
		public void Insert(int index, VisualElement element); // 0x000000018247D1D0-0x000000018247D2A0
		internal void Insert(int index, VisualElement element, bool ignoreContentContainer); // 0x000000018247D2A0-0x000000018247D3A0
		public void Clear(); // 0x000000018247B3A0-0x000000018247B3B0
		public void Clear(VisualElementClearOptions options); // 0x000000018247B3B0-0x000000018247B440
		internal int ChildCount(bool ignoreContentContainer); // 0x000000018247B230-0x000000018247B270
		public IEnumerable<VisualElement> Children(); // 0x000000018247B270-0x000000018247B280
		internal virtual void OnChildAdded(VisualElement child); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void OnChildRemoved(VisualElement child); // 0x00000001802E76C0-0x00000001802E76D0
		public void RemoveFromHierarchy(); // 0x000000018247EB90-0x000000018247EC90
		public T GetFirstOfType<T>()
			where T : class;
		public T GetFirstAncestorOfType<T>()
			where T : class;
		[VisibleToOtherModules(new string[3] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule", "UnityEditor.GraphToolkitModule" })]
		internal VisualElement GetFirstAncestorWhere(Predicate<VisualElement> predicate); // 0x000000018247BE20-0x000000018247BEB0
		public bool Contains(VisualElement child); // 0x000000018247B530-0x000000018247B580
		private void GatherAllChildren(List<VisualElement> elements); // 0x000000018247BC60-0x000000018247BD10
		public VisualElement FindCommonAncestor(VisualElement other); // 0x000000018247BA50-0x000000018247BBE0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElement GetRootVisualContainer(bool stopAtNearestRoot = false /* Metadata: 0x006604D3 */); // 0x000000018247CAA0-0x000000018247CB50
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElement GetNextElementDepthFirst(); // 0x000000018247C010-0x000000018247C100
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElement GetPreviousElementDepthFirst(); // 0x000000018247C900-0x000000018247CA00
		internal VisualElement RetargetElement(VisualElement retargetAgainst); // 0x000000018247F430-0x000000018247F4D0
		internal void GetPivotedMatrixWithLayout(out Matrix4x4 result); // 0x000000018247C4B0-0x000000018247C900
		internal static float Min(float a, float b, float c, float d); // 0x000000018247D940-0x000000018247D950
		internal static float Max(float a, float b, float c, float d); // 0x000000018247D630-0x000000018247D640
		internal void TransformAlignedBoundsToParentSpace(ref Bounds bounds); // 0x0000000182480FF0-0x0000000182481140
		private void TransformAlignedRectToParentSpace(ref Rect rect); // 0x00000001824811E0-0x0000000182481310
		internal static Rect CalculateConservativeRect(ref Matrix4x4 matrix, Rect rect); // 0x000000018247AC30-0x000000018247B080
		internal static Bounds CalculateConservativeBounds(ref Matrix4x4 matrix, Bounds bounds); // 0x000000018247A720-0x000000018247AC30
		internal static void TransformAlignedRect(ref Matrix4x4 matrix, ref Rect rect); // 0x0000000182481310-0x0000000182481390
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static void TransformAlignedBounds(ref Matrix4x4 matrix, ref Bounds bounds); // 0x0000000182481140-0x00000001824811E0
		internal static void OrderMinMaxRect(ref Rect rect); // 0x000000018247DD20-0x000000018247DDB0
		internal static void OrderMinMaxBounds(ref Bounds bounds); // 0x000000018247DCE0-0x000000018247DD20
		internal static Vector2 MultiplyMatrix44Point2(ref Matrix4x4 lhs, Vector2 point); // 0x000000018247DBF0-0x000000018247DC40
		internal static Vector3 MultiplyMatrix44Point2ToPoint3(ref Matrix4x4 lhs, Vector2 point); // 0x000000018247DB80-0x000000018247DBF0
		internal static Vector2 MultiplyMatrix44Point3ToPoint2(ref Matrix4x4 lhs, Vector3 point); // 0x000000018247DC40-0x000000018247DCA0
		internal static Vector2 MultiplyVector2(ref Matrix4x4 lhs, Vector2 vector); // 0x000000018247DCA0-0x000000018247DCE0
		internal static void MultiplyMatrix34(ref Matrix4x4 lhs, ref Matrix4x4 rhs, out Matrix4x4 res); // 0x000000018247D950-0x000000018247DB80
		private static void TranslateMatrix34InPlace(ref Matrix4x4 lhs, Vector3 rhs); // 0x0000000181EACA40-0x0000000181EACAD0
		IVisualElementScheduledItem IVisualElementScheduler.Execute(Action<TimerState> timerUpdateEvent); // 0x0000000182486380-0x0000000182486440
		IVisualElementScheduledItem IVisualElementScheduler.Execute(Action updateEvent); // 0x0000000182486440-0x0000000182486500
		[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
		internal void AddStyleSheetPath(string sheetPath); // 0x0000000182479C90-0x0000000182479EA0
		internal StyleFloat ResolveLengthValue(Length length, bool isRow); // 0x000000018247ECB0-0x000000018247EE10
		internal Vector3 ResolveTranslate(); // 0x000000018247F270-0x000000018247F430
		internal Vector3 ResolveTransformOrigin(); // 0x000000018247F030-0x000000018247F270
		private Quaternion ResolveRotation(); // 0x000000018247EE10-0x000000018247EF60
		private Vector3 ResolveScale(); // 0x000000018247EF60-0x000000018247F030
		bool ICustomStyle.TryGetValue(CustomStyleProperty<float> property, out float value); // 0x0000000182481A00-0x0000000182481BE0
		bool ICustomStyle.TryGetValue(CustomStyleProperty<Color> property, out Color value); // 0x00000001824818E0-0x0000000182481A00
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static TypeData GetOrCreateTypeData(Type t); // 0x000000018247C100-0x000000018247C210
		[CompilerGenerated]
		internal static bool _CalculateConservativeBounds_g__IsNaN_840_0(Vector3 v); // 0x00000001824818B0-0x00000001824818E0
	}
}
