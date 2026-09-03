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
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct ComputedStyle // TypeDefIndex: 4365
	{
		// Fields
		public StyleDataRef<InheritedData> inheritedData; // 0x00
		public StyleDataRef<LayoutData> layoutData; // 0x08
		public StyleDataRef<RareData> rareData; // 0x10
		public StyleDataRef<TransformData> transformData; // 0x18
		public StyleDataRef<TransitionData> transitionData; // 0x20
		public StyleDataRef<VisualData> visualData; // 0x28
		private CustomPropertyList m_CustomProperties; // 0x30
		public long matchingRulesHash; // 0x38
		public float dpiScaling; // 0x40
	
		// Properties
		public CustomPropertyListRef customProperties { get; } // 0x00000001825198E0-0x00000001825198F0 
		public int customPropertiesCount { get; } // 0x00000001825198B0-0x00000001825198E0 
		public Align alignContent { get; } // 0x00000001825186A0-0x00000001825187A0 
		public Align alignItems { get; } // 0x00000001825187A0-0x00000001825188A0 
		public Align alignSelf { get; } // 0x00000001825188A0-0x00000001825189A0 
		public AnimationPlayState animationPlayState { get; } // 0x00000001825189A0-0x00000001825189F0 
		public Ratio aspectRatio { get; } // 0x00000001825189F0-0x0000000182518B10 
		public ReadOnlySpan<UnmanagedFilterFunction> backdropFilter { get; } // 0x0000000182518B10-0x0000000182518BC0 
		public Color backgroundColor { get; } // 0x0000000182518BC0-0x0000000182518C20 
		public UnmanagedBackground backgroundImage { get; } // 0x0000000182518C20-0x0000000182518C90 
		public BackgroundPosition backgroundPositionX { get; } // 0x0000000182518C90-0x0000000182518D00 
		public BackgroundPosition backgroundPositionY { get; } // 0x0000000182518D00-0x0000000182518D70 
		public BackgroundRepeat backgroundRepeat { get; } // 0x0000000182518D70-0x0000000182518DC0 
		public BackgroundSize backgroundSize { get; } // 0x0000000182518DC0-0x0000000182518E30 
		public Color borderBottomColor { get; } // 0x0000000182518E30-0x0000000182518EA0 
		public Length borderBottomLeftRadius { get; } // 0x0000000182518EA0-0x0000000182518EF0 
		public Length borderBottomRightRadius { get; } // 0x0000000182518EF0-0x0000000182518F40 
		public float borderBottomWidth { get; } // 0x0000000182518F40-0x0000000182519060 
		public Color borderLeftColor { get; } // 0x0000000182519060-0x00000001825190D0 
		public float borderLeftWidth { get; } // 0x00000001825190D0-0x00000001825191F0 
		public Color borderRightColor { get; } // 0x00000001825191F0-0x0000000182519260 
		public float borderRightWidth { get; } // 0x0000000182519260-0x0000000182519380 
		public Color borderTopColor { get; } // 0x0000000182519380-0x00000001825193F0 
		public Length borderTopLeftRadius { get; } // 0x00000001825193F0-0x0000000182519440 
		public Length borderTopRightRadius { get; } // 0x0000000182519440-0x00000001825194A0 
		public float borderTopWidth { get; } // 0x00000001825194A0-0x00000001825195C0 
		public Length bottom { get; } // 0x00000001825195C0-0x00000001825196E0 
		public Color color { get; } // 0x00000001825196E0-0x0000000182519740 
		public Length columnGap { get; } // 0x0000000182519740-0x0000000182519840 
		public Cursor cursor { get; } // 0x0000000182519840-0x00000001825198B0 
		public DisplayStyle display { get; } // 0x00000001825198F0-0x00000001825199F0 
		public ReadOnlySpan<UnmanagedFilterFunction> filter { get; } // 0x00000001825199F0-0x0000000182519AA0 
		public Length flexBasis { get; } // 0x0000000182519AA0-0x0000000182519BA0 
		public FlexDirection flexDirection { get; } // 0x0000000182519BA0-0x0000000182519CA0 
		public float flexGrow { get; } // 0x0000000182519CA0-0x0000000182519DA0 
		public float flexShrink { get; } // 0x0000000182519DA0-0x0000000182519EA0 
		public Wrap flexWrap { get; } // 0x0000000182519EA0-0x0000000182519FA0 
		public Length fontSize { get; } // 0x0000000182519FA0-0x0000000182519FF0 
		public Length height { get; } // 0x0000000182519FF0-0x000000018251A110 
		public Justify justifyContent { get; } // 0x000000018251A110-0x000000018251A210 
		public Length left { get; } // 0x000000018251A210-0x000000018251A330 
		public Length letterSpacing { get; } // 0x000000018251A330-0x000000018251A380 
		public Length marginBottom { get; } // 0x000000018251A380-0x000000018251A4A0 
		public Length marginLeft { get; } // 0x000000018251A4A0-0x000000018251A5C0 
		public Length marginRight { get; } // 0x000000018251A5C0-0x000000018251A6E0 
		public Length marginTop { get; } // 0x000000018251A6E0-0x000000018251A800 
		public Length maxHeight { get; } // 0x000000018251A800-0x000000018251A920 
		public Length maxWidth { get; } // 0x000000018251A920-0x000000018251AA40 
		public Length minHeight { get; } // 0x000000018251AA40-0x000000018251AB60 
		public Length minWidth { get; } // 0x000000018251AB60-0x000000018251AC80 
		public float opacity { get; } // 0x000000018251AC80-0x000000018251ACE0 
		public OverflowInternal overflow { get; } // 0x000000018251ACE0-0x000000018251ADE0 
		public Length paddingBottom { get; } // 0x000000018251ADE0-0x000000018251AF00 
		public Length paddingLeft { get; } // 0x000000018251AF00-0x000000018251B020 
		public Length paddingRight { get; } // 0x000000018251B020-0x000000018251B140 
		public Length paddingTop { get; } // 0x000000018251B140-0x000000018251B260 
		public Position position { get; } // 0x000000018251B260-0x000000018251B360 
		public Length right { get; } // 0x000000018251B360-0x000000018251B480 
		public Rotate rotate { get; } // 0x000000018251B480-0x000000018251B4F0 
		public Length rowGap { get; } // 0x000000018251B4F0-0x000000018251B5F0 
		public Scale scale { get; } // 0x000000018251B5F0-0x000000018251B650 
		public TextOverflow textOverflow { get; } // 0x000000018251B650-0x000000018251B6A0 
		public TextShadow textShadow { get; } // 0x000000018251B6A0-0x000000018251B710 
		public Length top { get; } // 0x000000018251B710-0x000000018251B830 
		public TransformOrigin transformOrigin { get; } // 0x000000018251B830-0x000000018251B8A0 
		public ReadOnlySpan<TimeValue> transitionDelay { get; } // 0x000000018251B8A0-0x000000018251B950 
		public ReadOnlySpan<TimeValue> transitionDuration { get; } // 0x000000018251B950-0x000000018251BA00 
		public ReadOnlySpan<StylePropertyId> transitionProperty { get; } // 0x000000018251BA00-0x000000018251BAB0 
		public ReadOnlySpan<EasingFunction> transitionTimingFunction { get; } // 0x000000018251BAB0-0x000000018251BB60 
		public Translate translate { get; } // 0x000000018251BB60-0x000000018251BBD0 
		public EntityId unityAnimationClip { get; } // 0x000000018251BBD0-0x000000018251BC20 
		public Color unityBackgroundImageTintColor { get; } // 0x000000018251BC20-0x000000018251BC80 
		public EditorTextRenderingMode unityEditorTextRenderingMode { get; } // 0x000000018251BC80-0x000000018251BCD0 
		public EntityId unityFont { get; } // 0x000000018251BD70-0x000000018251BDC0 
		public EntityId unityFontDefinition { get; } // 0x000000018251BCD0-0x000000018251BD20 
		public FontStyle unityFontStyleAndWeight { get; } // 0x000000018251BD20-0x000000018251BD70 
		public UnmanagedMaterialDefinition unityMaterial { get; } // 0x000000018251BDC0-0x000000018251BE20 
		public OverflowClipBox unityOverflowClipBox { get; } // 0x000000018251BE20-0x000000018251BE70 
		public Length unityParagraphSpacing { get; } // 0x000000018251BE70-0x000000018251BEC0 
		public int unitySliceBottom { get; } // 0x000000018251BEC0-0x000000018251BF10 
		public int unitySliceLeft { get; } // 0x000000018251BF10-0x000000018251BF60 
		public int unitySliceRight { get; } // 0x000000018251BF60-0x000000018251BFB0 
		public float unitySliceScale { get; } // 0x000000018251BFB0-0x000000018251C000 
		public int unitySliceTop { get; } // 0x000000018251C000-0x000000018251C050 
		public SliceType unitySliceType { get; } // 0x000000018251C050-0x000000018251C0A0 
		public TextAnchor unityTextAlign { get; } // 0x000000018251C0A0-0x000000018251C0F0 
		public TextAutoSize unityTextAutoSize { get; } // 0x000000018251C0F0-0x000000018251C160 
		public TextGeneratorType unityTextGenerator { get; } // 0x000000018251C160-0x000000018251C1B0 
		public Color unityTextOutlineColor { get; } // 0x000000018251C1B0-0x000000018251C210 
		public float unityTextOutlineWidth { get; } // 0x000000018251C210-0x000000018251C270 
		public TextOverflowPosition unityTextOverflowPosition { get; } // 0x000000018251C270-0x000000018251C2C0 
		public Visibility visibility { get; } // 0x000000018251C2C0-0x000000018251C310 
		public WhiteSpace whiteSpace { get; } // 0x000000018251C310-0x000000018251C360 
		public Length width { get; } // 0x000000018251C360-0x000000018251C480 
		public Length wordSpacing { get; } // 0x000000018251C480-0x000000018251C4D0 
	
		// Methods
		public void FinalizeApply(ref ComputedStyle parentStyle); // 0x00000001824F85A0-0x00000001824F8730
		private bool ApplyGlobalKeyword(StylePropertyReader reader, ref ComputedStyle parentStyle); // 0x00000001824E7E50-0x00000001824E7F30
		private bool ApplyGlobalKeyword(StylePropertyId id, StyleKeyword keyword, ref ComputedStyle parentStyle); // 0x00000001824E7F30-0x00000001824E7F50
		private void RemoveCustomStyleProperty(StylePropertyReader reader); // 0x00000001824FBFA0-0x00000001824FC060
		private void ApplyCustomStyleProperty(StylePropertyReader reader); // 0x00000001824E4A80-0x00000001824E4B10
		private void ApplyAllPropertyInitial(); // 0x00000001824E48A0-0x00000001824E4A80
		public static bool StartAnimationInlineTextShadow(VisualElement element, ref ComputedStyle computedStyle, StyleTextShadow textShadow, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182507D10-0x0000000182507F30
		public static bool StartAnimationInlineCursor(VisualElement element, ref ComputedStyle computedStyle, StyleCursor cursor, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182506A80-0x0000000182506CB0
		public static bool StartAnimationInlineRotate(VisualElement element, ref ComputedStyle computedStyle, StyleRotate rotate, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x00000001825078F0-0x0000000182507B20
		public static bool StartAnimationInlineTranslate(VisualElement element, ref ComputedStyle computedStyle, StyleTranslate translate, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182508140-0x0000000182508370
		public static bool StartAnimationInlineScale(VisualElement element, ref ComputedStyle computedStyle, StyleScale scale, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182507B20-0x0000000182507D10
		public static bool StartAnimationInlineTransformOrigin(VisualElement element, ref ComputedStyle computedStyle, StyleTransformOrigin transformOrigin, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182507F30-0x0000000182508140
		public static bool StartAnimationInlineBackgroundSize(VisualElement element, ref ComputedStyle computedStyle, StyleBackgroundSize backgroundSize, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182506890-0x0000000182506A80
		public static ComputedStyle Create(ref ComputedStyle parentStyle); // 0x00000001824F83D0-0x00000001824F85A0
		public static ComputedStyle CreateInitial(); // 0x00000001824F8210-0x00000001824F83D0
		public ComputedStyle Acquire(); // 0x00000001824E4730-0x00000001824E48A0
		public void Release(); // 0x00000001824FBE00-0x00000001824FBFA0
		public void SafeRelease(); // 0x00000001824FC060-0x00000001824FC200
		public void CopyFrom(ref ComputedStyle other); // 0x00000001824F8070-0x00000001824F8210
		public void ApplyProperties(StylePropertyReader reader, ref ComputedStyle parentStyle); // 0x00000001824ED1A0-0x00000001824EFE50
		public void ApplyStyleValue(StyleValue sv, ref ComputedStyle parentStyle); // 0x00000001824F4160-0x00000001824F5970
		public void ApplyStyleValueManaged(StyleValueManaged sv, ref ComputedStyle parentStyle); // 0x00000001824F36E0-0x00000001824F4160
		public void ApplyStyleCursor(Cursor cursor); // 0x00000001824F3370-0x00000001824F33F0
		public void ApplyStyleTextShadow(TextShadow st); // 0x00000001824F3560-0x00000001824F35E0
		public void ApplyStyleTextAutoSize(TextAutoSize st); // 0x00000001824F34E0-0x00000001824F3560
		public void ApplyFromComputedStyle(StylePropertyId id, ref ComputedStyle other); // 0x00000001824E4B10-0x00000001824E7E50
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Length newValue); // 0x00000001824F0C50-0x00000001824F16F0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, float newValue); // 0x00000001824F04C0-0x00000001824F0970
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, int newValue); // 0x00000001824F16F0-0x00000001824F2370
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, BackgroundPosition newValue); // 0x00000001824F2BD0-0x00000001824F2E30
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, BackgroundRepeat newValue); // 0x00000001824F28F0-0x00000001824F2A70
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, BackgroundSize newValue); // 0x00000001824F0AE0-0x00000001824F0C50
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Color newValue); // 0x00000001824F2FA0-0x00000001824F32F0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, List<FilterFunction> newValue); // 0x00000001824F0150-0x00000001824F0300
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Cursor newValue); // 0x00000001824F0300-0x00000001824F04C0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, TextShadow newValue); // 0x00000001824F2E30-0x00000001824F2FA0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Translate newValue); // 0x00000001824F2630-0x00000001824F2790
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, TransformOrigin newValue); // 0x00000001824F2A70-0x00000001824F2BD0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Rotate newValue); // 0x00000001824EFFF0-0x00000001824F0150
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Scale newValue); // 0x00000001824F2790-0x00000001824F28F0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, MaterialDefinition newValue); // 0x00000001824F0970-0x00000001824F0AE0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, Ratio newValue); // 0x00000001824EFE50-0x00000001824EFFF0
		public void ApplyPropertyAnimation(VisualElement ve, StylePropertyId id, EntityId newValue); // 0x00000001824F2370-0x00000001824F2630
		public Length ReadPropertyAnimationLength(StylePropertyId id); // 0x00000001824FA230-0x00000001824FB640
		public float ReadPropertyAnimationFloat(StylePropertyId id); // 0x00000001824F9030-0x00000001824F9760
		public int ReadPropertyAnimationInt(StylePropertyId id); // 0x00000001824F9760-0x00000001824FA230
		public BackgroundPosition ReadPropertyAnimationBackgroundPosition(StylePropertyId id); // 0x00000001824F8730-0x00000001824F88A0
		public BackgroundRepeat ReadPropertyAnimationBackgroundRepeat(StylePropertyId id); // 0x00000001824F88A0-0x00000001824F89B0
		public BackgroundSize ReadPropertyAnimationBackgroundSize(StylePropertyId id); // 0x00000001824F89B0-0x00000001824F8AE0
		public Color ReadPropertyAnimationColor(StylePropertyId id); // 0x00000001824F8AE0-0x00000001824F8D70
		public Cursor ReadPropertyAnimationCursor(StylePropertyId id); // 0x00000001824F8D70-0x00000001824F8EA0
		public TextShadow ReadPropertyAnimationTextShadow(StylePropertyId id); // 0x00000001824FBA70-0x00000001824FBBA0
		public Translate ReadPropertyAnimationTranslate(StylePropertyId id); // 0x00000001824FBCD0-0x00000001824FBE00
		public TransformOrigin ReadPropertyAnimationTransformOrigin(StylePropertyId id); // 0x00000001824FBBA0-0x00000001824FBCD0
		public Rotate ReadPropertyAnimationRotate(StylePropertyId id); // 0x00000001824FB820-0x00000001824FB950
		public Scale ReadPropertyAnimationScale(StylePropertyId id); // 0x00000001824FB950-0x00000001824FBA70
		public Ratio ReadPropertyAnimationRatio(StylePropertyId id); // 0x00000001824FB640-0x00000001824FB820
		public EntityId ReadPropertyAnimationEntityId(StylePropertyId id); // 0x00000001824F8EA0-0x00000001824F9030
		public static bool StartAnimation(VisualElement element, StylePropertyId id, ref ComputedStyle oldStyle, ref ComputedStyle newStyle, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x000000018250F710-0x00000001825186A0
		public static bool StartAnimationAllProperty(VisualElement element, ref ComputedStyle oldStyle, ref ComputedStyle newStyle, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x00000001824FC200-0x0000000182506890
		public static bool StartAnimationInline(VisualElement element, StylePropertyId id, ref ComputedStyle computedStyle, StyleValue sv, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182508370-0x000000018250F710
		public static bool StartAnimationInlineManaged(VisualElement element, StylePropertyId id, ref ComputedStyle computedStyle, StyleValueManaged sv, int durationMs, int delayMs, Func<float, float> easingCurve); // 0x0000000182506CB0-0x00000001825078F0
		public void ApplyStyleTransformOrigin(TransformOrigin st); // 0x00000001824F35E0-0x00000001824F3660
		public void ApplyStyleTranslate(Translate translateValue); // 0x00000001824F3660-0x00000001824F36E0
		public void ApplyStyleRotate(Rotate rotateValue); // 0x00000001824F33F0-0x00000001824F3470
		public void ApplyStyleScale(Scale scaleValue); // 0x00000001824F3470-0x00000001824F34E0
		public void ApplyStyleBackgroundSize(BackgroundSize backgroundSizeValue); // 0x00000001824F32F0-0x00000001824F3370
		public void ApplyInitialValue(StylePropertyReader reader); // 0x00000001824E7F50-0x00000001824E8160
		public void ApplyInitialValue(StylePropertyId id); // 0x00000001824E8160-0x00000001824ED1A0
		public void ApplyUnsetValue(StylePropertyReader reader, ref ComputedStyle parentStyle); // 0x00000001824F5970-0x00000001824F59A0
		public void ApplyUnsetValue(StylePropertyId id, ref ComputedStyle parentStyle); // 0x00000001824F59A0-0x00000001824F60D0
		public static VersionChangeType CompareChanges(ref ComputedStyle x, ref ComputedStyle y); // 0x00000001824F60D0-0x00000001824F8070
	}
}
