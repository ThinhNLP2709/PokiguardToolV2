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
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class InlineStyleAccess : StyleValueCollection, IStyle // TypeDefIndex: 4387
	{
		// Fields
		private static StylePropertyReader s_StylePropertyReader; // 0x00
		private List<StyleValueManaged> m_ValuesManaged; // 0x18
		[CompilerGenerated]
		private VisualElement _ve_k__BackingField; // 0x20
		private bool m_HasInlineCursor; // 0x28
		private StyleCursor m_InlineCursor; // 0x30
		private bool m_HasInlineTextShadow; // 0x50
		private StyleTextShadow m_InlineTextShadow; // 0x54
		private bool m_HasInlineTextAutoSize; // 0x74
		private StyleTextAutoSize m_InlineTextAutoSize; // 0x78
		private bool m_HasInlineTransformOrigin; // 0x90
		private StyleTransformOrigin m_InlineTransformOrigin; // 0x94
		private bool m_HasInlineTranslate; // 0xAC
		private StyleTranslate m_InlineTranslateOperation; // 0xB0
		private bool m_HasInlineRotate; // 0xCC
		private StyleRotate m_InlineRotateOperation; // 0xD0
		private bool m_HasInlineScale; // 0xEC
		private StyleScale m_InlineScale; // 0xF0
		private bool m_HasInlineBackgroundSize; // 0x104
		public StyleBackgroundSize m_InlineBackgroundSize; // 0x108
		private InlineRule m_InlineRule; // 0x120
	
		// Properties
		StyleEnum<Align> IStyle.alignContent { get; set; } // 0x000000018252F9B0-0x000000018252FA10 0x0000000182531380-0x00000001825313E0
		StyleEnum<Align> IStyle.alignItems { get; set; } // 0x000000018252FA10-0x000000018252FA70 0x00000001825313E0-0x0000000182531440
		StyleEnum<Align> IStyle.alignSelf { get; set; } // 0x000000018252FA70-0x000000018252FAD0 0x0000000182531440-0x00000001825314A0
		StyleEnum<AnimationPlayState> IStyle.animationPlayState { get; set; } // 0x000000018252FAD0-0x000000018252FB30 0x00000001825314A0-0x00000001825314F0
		StyleRatio IStyle.aspectRatio { get; set; } // 0x000000018252FB30-0x000000018252FB40 0x00000001825314F0-0x0000000182531650
		StyleList<FilterFunction> IStyle.backdropFilter { get; set; } // 0x000000018252FB40-0x000000018252FBA0 0x0000000182531650-0x00000001825316D0
		StyleColor IStyle.backgroundColor { get; set; } // 0x000000018252FBA0-0x000000018252FBE0 0x00000001825316D0-0x0000000182531730
		StyleBackground IStyle.backgroundImage { get; set; } // 0x000000018252FBE0-0x000000018252FC30 0x0000000182531730-0x0000000182531970
		StyleBackgroundPosition IStyle.backgroundPositionX { get; set; } // 0x000000018252FC30-0x000000018252FC60 0x0000000182531970-0x00000001825319C0
		StyleBackgroundPosition IStyle.backgroundPositionY { get; set; } // 0x000000018252FC60-0x000000018252FC90 0x00000001825319C0-0x0000000182531A10
		StyleBackgroundRepeat IStyle.backgroundRepeat { get; set; } // 0x000000018252FC90-0x000000018252FCD0 0x0000000182531A10-0x0000000182531B50
		StyleColor IStyle.borderBottomColor { get; set; } // 0x000000018252FD30-0x000000018252FD70 0x0000000182531C10-0x0000000182531C70
		StyleLength IStyle.borderBottomLeftRadius { get; set; } // 0x000000018252FD70-0x000000018252FDB0 0x0000000182531C70-0x0000000182531CD0
		StyleLength IStyle.borderBottomRightRadius { get; set; } // 0x000000018252FDB0-0x000000018252FDF0 0x0000000182531CD0-0x0000000182531D30
		StyleFloat IStyle.borderBottomWidth { get; set; } // 0x000000018252FDF0-0x000000018252FE00 0x0000000182531D30-0x0000000182531D90
		StyleColor IStyle.borderLeftColor { get; set; } // 0x000000018252FE00-0x000000018252FE40 0x0000000182531D90-0x0000000182531DF0
		StyleFloat IStyle.borderLeftWidth { get; set; } // 0x000000018252FE40-0x000000018252FE50 0x0000000182531DF0-0x0000000182531E50
		StyleColor IStyle.borderRightColor { get; set; } // 0x000000018252FE50-0x000000018252FE90 0x0000000182531E50-0x0000000182531EB0
		StyleFloat IStyle.borderRightWidth { get; set; } // 0x000000018252FE90-0x000000018252FEA0 0x0000000182531EB0-0x0000000182531F10
		StyleColor IStyle.borderTopColor { get; set; } // 0x000000018252FEA0-0x000000018252FEE0 0x0000000182531F10-0x0000000182531F70
		StyleLength IStyle.borderTopLeftRadius { get; set; } // 0x000000018252FEE0-0x000000018252FF20 0x0000000182531F70-0x0000000182531FD0
		StyleLength IStyle.borderTopRightRadius { get; set; } // 0x000000018252FF20-0x000000018252FF60 0x0000000182531FD0-0x0000000182532030
		StyleFloat IStyle.borderTopWidth { get; set; } // 0x000000018252FF60-0x000000018252FF70 0x0000000182532030-0x0000000182532090
		StyleLength IStyle.bottom { get; set; } // 0x000000018252FF70-0x000000018252FFB0 0x0000000182532090-0x0000000182532110
		StyleColor IStyle.color { get; set; } // 0x000000018252FFB0-0x000000018252FFF0 0x0000000182532110-0x0000000182532170
		StyleLength IStyle.columnGap { get; set; } // 0x000000018252FFF0-0x0000000182530030 0x0000000182532170-0x00000001825321F0
		StyleEnum<DisplayStyle> IStyle.display { get; set; } // 0x0000000182530080-0x00000001825300E0 0x00000001825323D0-0x0000000182532430
		StyleList<FilterFunction> IStyle.filter { get; set; } // 0x00000001825300E0-0x0000000182530140 0x0000000182532430-0x00000001825324B0
		StyleLength IStyle.flexBasis { get; set; } // 0x0000000182530140-0x0000000182530180 0x00000001825324B0-0x0000000182532530
		StyleEnum<FlexDirection> IStyle.flexDirection { get; set; } // 0x0000000182530180-0x00000001825301E0 0x0000000182532530-0x0000000182532590
		StyleFloat IStyle.flexGrow { get; set; } // 0x00000001825301E0-0x00000001825301F0 0x0000000182532590-0x00000001825325F0
		StyleFloat IStyle.flexShrink { get; set; } // 0x00000001825301F0-0x0000000182530200 0x00000001825325F0-0x0000000182532650
		StyleEnum<Wrap> IStyle.flexWrap { get; set; } // 0x0000000182530200-0x0000000182530260 0x0000000182532650-0x00000001825326B0
		StyleLength IStyle.fontSize { get; set; } // 0x0000000182530260-0x00000001825302A0 0x00000001825326B0-0x0000000182532710
		StyleLength IStyle.height { get; set; } // 0x00000001825302A0-0x00000001825302E0 0x0000000182532710-0x0000000182532790
		StyleEnum<Justify> IStyle.justifyContent { get; set; } // 0x00000001825302E0-0x0000000182530340 0x0000000182532790-0x00000001825327F0
		StyleLength IStyle.left { get; set; } // 0x0000000182530340-0x0000000182530380 0x00000001825327F0-0x0000000182532870
		StyleLength IStyle.letterSpacing { get; set; } // 0x0000000182530380-0x00000001825303C0 0x0000000182532870-0x00000001825328D0
		StyleLength IStyle.marginBottom { get; set; } // 0x00000001825303C0-0x0000000182530400 0x00000001825328D0-0x0000000182532950
		StyleLength IStyle.marginLeft { get; set; } // 0x0000000182530400-0x0000000182530440 0x0000000182532950-0x00000001825329D0
		StyleLength IStyle.marginRight { get; set; } // 0x0000000182530440-0x0000000182530480 0x00000001825329D0-0x0000000182532A50
		StyleLength IStyle.marginTop { get; set; } // 0x0000000182530480-0x00000001825304C0 0x0000000182532A50-0x0000000182532AD0
		StyleLength IStyle.maxHeight { get; set; } // 0x00000001825304C0-0x0000000182530500 0x0000000182532AD0-0x0000000182532B50
		StyleLength IStyle.maxWidth { get; set; } // 0x0000000182530500-0x0000000182530540 0x0000000182532B50-0x0000000182532BD0
		StyleLength IStyle.minHeight { get; set; } // 0x0000000182530540-0x0000000182530580 0x0000000182532BD0-0x0000000182532C50
		StyleLength IStyle.minWidth { get; set; } // 0x0000000182530580-0x00000001825305C0 0x0000000182532C50-0x0000000182532CD0
		StyleFloat IStyle.opacity { get; set; } // 0x00000001825305C0-0x00000001825305D0 0x0000000182532CD0-0x0000000182532D20
		StyleEnum<Overflow> IStyle.overflow { get; set; } // 0x00000001825305D0-0x0000000182530630 0x0000000182532D20-0x0000000182532DB0
		StyleLength IStyle.paddingBottom { get; set; } // 0x0000000182530630-0x0000000182530670 0x0000000182532DB0-0x0000000182532E30
		StyleLength IStyle.paddingLeft { get; set; } // 0x0000000182530670-0x00000001825306B0 0x0000000182532E30-0x0000000182532EB0
		StyleLength IStyle.paddingRight { get; set; } // 0x00000001825306B0-0x00000001825306F0 0x0000000182532EB0-0x0000000182532F30
		StyleLength IStyle.paddingTop { get; set; } // 0x00000001825306F0-0x0000000182530730 0x0000000182532F30-0x0000000182532FB0
		StyleEnum<Position> IStyle.position { get; set; } // 0x0000000182530730-0x0000000182530790 0x0000000182532FB0-0x0000000182533010
		StyleLength IStyle.right { get; set; } // 0x0000000182530790-0x00000001825307D0 0x0000000182533010-0x0000000182533090
		StyleLength IStyle.rowGap { get; set; } // 0x0000000182530840-0x0000000182530880 0x0000000182533150-0x00000001825331D0
		StyleEnum<TextOverflow> IStyle.textOverflow { get; set; } // 0x00000001825308E0-0x0000000182530940 0x0000000182533290-0x00000001825332E0
		StyleLength IStyle.top { get; set; } // 0x0000000182530990-0x00000001825309D0 0x00000001825333A0-0x0000000182533420
		StyleList<TimeValue> IStyle.transitionDelay { get; set; } // 0x0000000182530A30-0x0000000182530A90 0x00000001825334E0-0x0000000182533560
		StyleList<TimeValue> IStyle.transitionDuration { get; set; } // 0x0000000182530A90-0x0000000182530AF0 0x0000000182533560-0x00000001825335E0
		StyleList<StylePropertyName> IStyle.transitionProperty { get; set; } // 0x0000000182530AF0-0x0000000182530B50 0x00000001825335E0-0x0000000182533660
		StyleList<EasingFunction> IStyle.transitionTimingFunction { get; set; } // 0x0000000182530B50-0x0000000182530BB0 0x0000000182533660-0x00000001825336E0
		StyleUIAnimationClip IStyle.unityAnimationClip { get; set; } // 0x0000000182530C20-0x0000000182530CE0 0x00000001825337A0-0x0000000182533910
		StyleColor IStyle.unityBackgroundImageTintColor { get; set; } // 0x0000000182530CE0-0x0000000182530D20 0x0000000182533910-0x0000000182533970
		StyleEnum<EditorTextRenderingMode> IStyle.unityEditorTextRenderingMode { get; set; } // 0x0000000182530D20-0x0000000182530D80 0x0000000182533970-0x00000001825339C0
		StyleFont IStyle.unityFont { get; set; } // 0x0000000182530E20-0x0000000182530EE0 0x0000000182533C30-0x0000000182533DF0
		StyleFontDefinition IStyle.unityFontDefinition { get; set; } // 0x0000000182530D80-0x0000000182530DC0 0x00000001825339C0-0x0000000182533BE0
		StyleEnum<FontStyle> IStyle.unityFontStyleAndWeight { get; set; } // 0x0000000182530DC0-0x0000000182530E20 0x0000000182533BE0-0x0000000182533C30
		StyleMaterialDefinition IStyle.unityMaterial { get; set; } // 0x0000000182530EE0-0x0000000182530F20 0x0000000182533DF0-0x0000000182533F50
		StyleEnum<OverflowClipBox> IStyle.unityOverflowClipBox { get; set; } // 0x0000000182530F20-0x0000000182530F80 0x0000000182533F50-0x0000000182533FA0
		StyleLength IStyle.unityParagraphSpacing { get; set; } // 0x0000000182530F80-0x0000000182530FC0 0x0000000182533FA0-0x0000000182534000
		StyleInt IStyle.unitySliceBottom { get; set; } // 0x0000000182530FC0-0x0000000182530FD0 0x0000000182534000-0x0000000182534050
		StyleInt IStyle.unitySliceLeft { get; set; } // 0x0000000182530FD0-0x0000000182530FE0 0x0000000182534050-0x00000001825340A0
		StyleInt IStyle.unitySliceRight { get; set; } // 0x0000000182530FE0-0x0000000182530FF0 0x00000001825340A0-0x00000001825340F0
		StyleFloat IStyle.unitySliceScale { get; set; } // 0x0000000182530FF0-0x0000000182531000 0x00000001825340F0-0x0000000182534140
		StyleInt IStyle.unitySliceTop { get; set; } // 0x0000000182531000-0x0000000182531010 0x0000000182534140-0x0000000182534190
		StyleEnum<SliceType> IStyle.unitySliceType { get; set; } // 0x0000000182531010-0x0000000182531070 0x0000000182534190-0x00000001825341E0
		StyleEnum<TextAnchor> IStyle.unityTextAlign { get; set; } // 0x0000000182531070-0x00000001825310D0 0x00000001825341E0-0x0000000182534230
		StyleEnum<TextGeneratorType> IStyle.unityTextGenerator { get; set; } // 0x0000000182531130-0x0000000182531190 0x0000000182534440-0x0000000182534490
		StyleColor IStyle.unityTextOutlineColor { get; set; } // 0x0000000182531190-0x00000001825311D0 0x0000000182534490-0x00000001825344F0
		StyleFloat IStyle.unityTextOutlineWidth { get; set; } // 0x00000001825311D0-0x00000001825311E0 0x00000001825344F0-0x0000000182534540
		StyleEnum<TextOverflowPosition> IStyle.unityTextOverflowPosition { get; set; } // 0x00000001825311E0-0x0000000182531240 0x0000000182534540-0x0000000182534590
		StyleEnum<Visibility> IStyle.visibility { get; set; } // 0x0000000182531240-0x00000001825312A0 0x0000000182534590-0x00000001825345E0
		StyleEnum<WhiteSpace> IStyle.whiteSpace { get; set; } // 0x00000001825312A0-0x0000000182531300 0x00000001825345E0-0x0000000182534630
		StyleLength IStyle.width { get; set; } // 0x0000000182531300-0x0000000182531340 0x0000000182534630-0x00000001825346B0
		StyleLength IStyle.wordSpacing { get; set; } // 0x0000000182531340-0x0000000182531380 0x00000001825346B0-0x0000000182534710
		private VisualElement ve { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public InlineRule inlineRule { get; } // 0x00000001825347D0-0x00000001825347E0 
		StyleCursor IStyle.cursor { get; set; } // 0x0000000182530030-0x0000000182530080 0x00000001825321F0-0x00000001825323D0
		StyleTextShadow IStyle.textShadow { get; set; } // 0x0000000182530940-0x0000000182530990 0x00000001825332E0-0x00000001825333A0
		StyleTextAutoSize IStyle.unityTextAutoSize { get; set; } // 0x00000001825310D0-0x0000000182531130 0x0000000182534230-0x0000000182534440
		StyleBackgroundSize IStyle.backgroundSize { get; set; } // 0x000000018252FCD0-0x000000018252FD30 0x0000000182531B50-0x0000000182531C10
		StyleTransformOrigin IStyle.transformOrigin { get; set; } // 0x00000001825309D0-0x0000000182530A30 0x0000000182533420-0x00000001825334E0
		StyleTranslate IStyle.translate { get; set; } // 0x0000000182530BB0-0x0000000182530C20 0x00000001825336E0-0x00000001825337A0
		StyleRotate IStyle.rotate { get; set; } // 0x00000001825307D0-0x0000000182530840 0x0000000182533090-0x0000000182533150
		StyleScale IStyle.scale { get; set; } // 0x0000000182530880-0x00000001825308E0 0x00000001825331D0-0x0000000182533290
	
		// Nested types
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal struct InlineRule // TypeDefIndex: 4388
		{
			// Fields
			public StyleSheet sheet; // 0x00
			public StyleRule rule; // 0x08
		}
	
		// Constructors
		public InlineStyleAccess(VisualElement ve); // 0x0000000182534790-0x00000001825347D0
		static InlineStyleAccess(); // 0x0000000182534710-0x0000000182534790
	
		// Methods
		private bool TryGetObject<T>(StylePropertyId id, out ref T value, out StyleKeyword keyword)
			where T : class;
		private StyleBackground GetStyleBackground(StylePropertyId id); // 0x000000018252C8B0-0x000000018252CA80
		private StyleUIAnimationClip GetStyleUIAnimationClip(StylePropertyId id); // 0x000000018252CE40-0x000000018252CEF0
		private bool SetStyleValue(StylePropertyId id, StyleUIAnimationClip inlineValue); // 0x000000018252E860-0x000000018252E9C0
		private bool SetStyleValue(StylePropertyId id, StyleBackground inlineValue); // 0x000000018252F300-0x000000018252F500
		public StyleFontDefinition GetStyleFontDefinition(StylePropertyId id); // 0x000000018252CA80-0x000000018252CC60
		private bool SetStyleValue(StylePropertyId id, StyleFontDefinition inlineValue); // 0x000000018252E6B0-0x000000018252E860
		public StyleFont GetStyleFont(StylePropertyId id); // 0x000000018252CC60-0x000000018252CD10
		private bool SetStyleValue(StylePropertyId id, StyleFont inlineValue); // 0x000000018252F070-0x000000018252F1D0
		public StyleMaterialDefinition GetStyleMaterialDefinition(StylePropertyId id); // 0x000000018252CD10-0x000000018252CE40
		private bool SetStyleValue(StylePropertyId id, StyleMaterialDefinition inlineValue); // 0x000000018252E9C0-0x000000018252EB00
		public void SetInlineRule(StyleSheet sheet, StyleRule rule, StyleVariableContext variableContext = null); // 0x000000018252D800-0x000000018252D880
		public bool IsValueSet(StylePropertyId id); // 0x000000018252CEF0-0x000000018252D180
		public void ApplyInlineStyles(ref ComputedStyle computedStyle, StyleVariableContext variableContext); // 0x000000018252A900-0x000000018252B6D0
		private StyleList<T> GetStyleList<T>(StylePropertyId id);
		private void SetStyleValueManaged(StyleValueManaged value); // 0x000000018252E260-0x000000018252E420
		private bool TryGetStyleValueManaged(StylePropertyId id, ref StyleValueManaged value); // 0x000000018252F650-0x000000018252F760
		private bool SetStyleValue(StylePropertyId id, StyleBackgroundPosition inlineValue); // 0x000000018252E420-0x000000018252E580
		private bool SetStyleValue(StylePropertyId id, StyleBackgroundRepeat inlineValue); // 0x000000018252EB00-0x000000018252EC40
		private bool SetStyleValue(StylePropertyId id, StyleLength inlineValue); // 0x000000018252E580-0x000000018252E6B0
		private bool SetStyleValue(StylePropertyId id, StyleFloat inlineValue); // 0x000000018252F1D0-0x000000018252F300
		private bool SetStyleValue(StylePropertyId id, StyleInt inlineValue); // 0x000000018252EF30-0x000000018252F070
		private bool SetStyleValue(StylePropertyId id, StyleColor inlineValue); // 0x000000018252ED90-0x000000018252EF30
		private bool SetStyleValue<T>(StylePropertyId id, StyleEnum<T> inlineValue)
			where T : struct, IConvertible;
		private bool SetStyleValue<T>(StylePropertyId id, StyleList<T> inlineValue);
		private bool SetStyleValue(StylePropertyId id, StyleRatio inlineValue); // 0x000000018252EC40-0x000000018252ED90
		private bool SetInlineCursor(StyleCursor inlineValue); // 0x000000018252D480-0x000000018252D5D0
		private bool TryStartInlineTransition(StylePropertyId id, out ComputedTransitionProperty transition); // 0x000000018252F760-0x000000018252F9B0
		private void ApplyStyleCursor(StyleCursor cursor); // 0x000000018252B800-0x000000018252BAC0
		private bool SetInlineTextShadow(StyleTextShadow inlineValue); // 0x000000018252DBE0-0x000000018252DE30
		private void ApplyStyleTextShadow(StyleTextShadow textShadow); // 0x000000018252BD90-0x000000018252BED0
		private bool SetInlineTextAutoSize(StyleTextAutoSize inlineValue); // 0x000000018252DA60-0x000000018252DBE0
		private void ApplyStyleTextAutoSize(StyleTextAutoSize textAutoSize); // 0x000000018252BD20-0x000000018252BD90
		private bool SetInlineTransformOrigin(StyleTransformOrigin inlineValue); // 0x000000018252DE30-0x000000018252E030
		private void ApplyStyleTransformOrigin(StyleTransformOrigin transformOrigin); // 0x000000018252BED0-0x000000018252C000
		private bool SetInlineTranslate(StyleTranslate inlineValue); // 0x000000018252E030-0x000000018252E260
		private void ApplyStyleTranslate(StyleTranslate translate); // 0x000000018252C000-0x000000018252C140
		private bool SetInlineScale(StyleScale inlineValue); // 0x000000018252D880-0x000000018252DA60
		private void ApplyStyleScale(StyleScale scale); // 0x000000018252BC00-0x000000018252BD20
		private bool SetInlineRotate(StyleRotate inlineValue); // 0x000000018252D5D0-0x000000018252D800
		private void ApplyStyleRotate(StyleRotate rotate); // 0x000000018252BAC0-0x000000018252BC00
		private bool SetInlineBackgroundSize(StyleBackgroundSize inlineValue); // 0x000000018252D280-0x000000018252D480
		private void ApplyStyleBackgroundSize(StyleBackgroundSize backgroundSize); // 0x000000018252B6D0-0x000000018252B800
		private void ApplyStyleValue(StyleValue value); // 0x000000018252C140-0x000000018252C510
		private void ApplyStyleValue(StyleValueManaged value); // 0x000000018252C510-0x000000018252C8B0
		private bool RemoveInlineStyle(StylePropertyId id); // 0x000000018252D180-0x000000018252D280
		private void ApplyFromComputedStyle(StylePropertyId id, ref ComputedStyle newStyle); // 0x000000018252A5E0-0x000000018252A900
		public bool TryGetInlineCursor(ref StyleCursor value); // 0x000000018252F530-0x000000018252F550
		public bool TryGetInlineTextShadow(ref StyleTextShadow value); // 0x000000018252F5D0-0x000000018252F5F0
		public bool TryGetInlineTextAutoSize(ref StyleTextAutoSize value); // 0x000000018252F5B0-0x000000018252F5D0
		public bool TryGetInlineTransformOrigin(ref StyleTransformOrigin value); // 0x000000018252F5F0-0x000000018252F620
		public bool TryGetInlineTranslate(ref StyleTranslate value); // 0x000000018252F620-0x000000018252F650
		public bool TryGetInlineRotate(ref StyleRotate value); // 0x000000018252F550-0x000000018252F580
		public bool TryGetInlineScale(ref StyleScale value); // 0x000000018252F580-0x000000018252F5B0
		public bool TryGetInlineBackgroundSize(ref StyleBackgroundSize value); // 0x000000018252F500-0x000000018252F530
	}
}
