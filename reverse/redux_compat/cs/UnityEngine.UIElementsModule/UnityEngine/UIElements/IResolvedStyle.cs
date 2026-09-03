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
	public interface IResolvedStyle // TypeDefIndex: 4507
	{
		// Properties
		Align alignContent { get; } // 0x00000001802E7860-0x00000001802E7870 
		Align alignItems { get; } // 0x00000001802E7860-0x00000001802E7870 
		Align alignSelf { get; } // 0x00000001802E7860-0x00000001802E7870 
		AnimationPlayState animationPlayState { get; } // 0x00000001802E7860-0x00000001802E7870 
		Ratio aspectRatio { get; } // 0x0000000180CC8D80-0x0000000180CC8D90 
		IEnumerable<FilterFunction> backdropFilter { get; } // 0x00000001802E7860-0x00000001802E7870 
		Color backgroundColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		Background backgroundImage { get; } // 0x0000000180CC8D30-0x0000000180CC8D50 
		BackgroundPosition backgroundPositionX { get; } // 0x0000000180CC8D20-0x0000000180CC8D30 
		BackgroundPosition backgroundPositionY { get; } // 0x0000000180CC8D20-0x0000000180CC8D30 
		BackgroundRepeat backgroundRepeat { get; } // 0x00000001802E7860-0x00000001802E7870 
		BackgroundSize backgroundSize { get; } // 0x0000000180CC8CF0-0x0000000180CC8D00 
		Color borderBottomColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		float borderBottomLeftRadius { get; } // 0x00000001807185C0-0x00000001807185D0 
		float borderBottomRightRadius { get; } // 0x00000001807185C0-0x00000001807185D0 
		float borderBottomWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		Color borderLeftColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		float borderLeftWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		Color borderRightColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		float borderRightWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		Color borderTopColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		float borderTopLeftRadius { get; } // 0x00000001807185C0-0x00000001807185D0 
		float borderTopRightRadius { get; } // 0x00000001807185C0-0x00000001807185D0 
		float borderTopWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		float bottom { get; } // 0x00000001807185C0-0x00000001807185D0 
		Color color { get; } // 0x0000000180A69580-0x0000000180A69590 
		float columnGap { get; } // 0x00000001807185C0-0x00000001807185D0 
		DisplayStyle display { get; } // 0x00000001802E7860-0x00000001802E7870 
		IEnumerable<FilterFunction> filter { get; } // 0x00000001802E7860-0x00000001802E7870 
		StyleFloat flexBasis { get; } // 0x00000001802E7860-0x00000001802E7870 
		FlexDirection flexDirection { get; } // 0x00000001802E7860-0x00000001802E7870 
		float flexGrow { get; } // 0x00000001807185C0-0x00000001807185D0 
		float flexShrink { get; } // 0x00000001807185C0-0x00000001807185D0 
		Wrap flexWrap { get; } // 0x00000001802E7860-0x00000001802E7870 
		float fontSize { get; } // 0x00000001807185C0-0x00000001807185D0 
		float height { get; } // 0x00000001807185C0-0x00000001807185D0 
		Justify justifyContent { get; } // 0x00000001802E7860-0x00000001802E7870 
		float left { get; } // 0x00000001807185C0-0x00000001807185D0 
		float letterSpacing { get; } // 0x00000001807185C0-0x00000001807185D0 
		float marginBottom { get; } // 0x00000001807185C0-0x00000001807185D0 
		float marginLeft { get; } // 0x00000001807185C0-0x00000001807185D0 
		float marginRight { get; } // 0x00000001807185C0-0x00000001807185D0 
		float marginTop { get; } // 0x00000001807185C0-0x00000001807185D0 
		StyleFloat maxHeight { get; } // 0x00000001802E7860-0x00000001802E7870 
		StyleFloat maxWidth { get; } // 0x00000001802E7860-0x00000001802E7870 
		StyleFloat minHeight { get; } // 0x00000001802E7860-0x00000001802E7870 
		StyleFloat minWidth { get; } // 0x00000001802E7860-0x00000001802E7870 
		float opacity { get; } // 0x00000001807185C0-0x00000001807185D0 
		float paddingBottom { get; } // 0x00000001807185C0-0x00000001807185D0 
		float paddingLeft { get; } // 0x00000001807185C0-0x00000001807185D0 
		float paddingRight { get; } // 0x00000001807185C0-0x00000001807185D0 
		float paddingTop { get; } // 0x00000001807185C0-0x00000001807185D0 
		Position position { get; } // 0x00000001802E7860-0x00000001802E7870 
		float right { get; } // 0x00000001807185C0-0x00000001807185D0 
		Rotate rotate { get; } // 0x0000000180A69590-0x0000000180A695A0 
		float rowGap { get; } // 0x00000001807185C0-0x00000001807185D0 
		Scale scale { get; } // 0x0000000180A69580-0x0000000180A69590 
		TextOverflow textOverflow { get; } // 0x00000001802E7860-0x00000001802E7870 
		TextShadow textShadow { get; } // 0x0000000180CC8D00-0x0000000180CC8D20 
		float top { get; } // 0x00000001807185C0-0x00000001807185D0 
		Vector3 transformOrigin { get; } // 0x0000000180CC8D20-0x0000000180CC8D30 
		IEnumerable<TimeValue> transitionDelay { get; } // 0x00000001802E7860-0x00000001802E7870 
		IEnumerable<TimeValue> transitionDuration { get; } // 0x00000001802E7860-0x00000001802E7870 
		IEnumerable<StylePropertyName> transitionProperty { get; } // 0x00000001802E7860-0x00000001802E7870 
		IEnumerable<EasingFunction> transitionTimingFunction { get; } // 0x00000001802E7860-0x00000001802E7870 
		Vector3 translate { get; } // 0x0000000180CC8D20-0x0000000180CC8D30 
		UIAnimationClip unityAnimationClip { get; } // 0x00000001802E7860-0x00000001802E7870 
		Color unityBackgroundImageTintColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		EditorTextRenderingMode unityEditorTextRenderingMode { get; } // 0x00000001802E7860-0x00000001802E7870 
		Font unityFont { get; } // 0x00000001802E7860-0x00000001802E7870 
		FontDefinition unityFontDefinition { get; } // 0x0000000180A69580-0x0000000180A69590 
		FontStyle unityFontStyleAndWeight { get; } // 0x00000001802E7860-0x00000001802E7870 
		MaterialDefinition unityMaterial { get; } // 0x0000000180A69580-0x0000000180A69590 
		float unityParagraphSpacing { get; } // 0x00000001807185C0-0x00000001807185D0 
		int unitySliceBottom { get; } // 0x00000001802E7860-0x00000001802E7870 
		int unitySliceLeft { get; } // 0x00000001802E7860-0x00000001802E7870 
		int unitySliceRight { get; } // 0x00000001802E7860-0x00000001802E7870 
		float unitySliceScale { get; } // 0x00000001807185C0-0x00000001807185D0 
		int unitySliceTop { get; } // 0x00000001802E7860-0x00000001802E7870 
		SliceType unitySliceType { get; } // 0x00000001802E7860-0x00000001802E7870 
		TextAnchor unityTextAlign { get; } // 0x00000001802E7860-0x00000001802E7870 
		TextGeneratorType unityTextGenerator { get; } // 0x00000001802E7860-0x00000001802E7870 
		Color unityTextOutlineColor { get; } // 0x0000000180A69580-0x0000000180A69590 
		float unityTextOutlineWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		TextOverflowPosition unityTextOverflowPosition { get; } // 0x00000001802E7860-0x00000001802E7870 
		Visibility visibility { get; } // 0x00000001802E7860-0x00000001802E7870 
		WhiteSpace whiteSpace { get; } // 0x00000001802E7860-0x00000001802E7870 
		float width { get; } // 0x00000001807185C0-0x00000001807185D0 
		float wordSpacing { get; } // 0x00000001807185C0-0x00000001807185D0 
	}
}
