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
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class UIToolkitConverters // TypeDefIndex: 4628
	{
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4629
		{
			// Fields
			public static TypeConverter<StyleEnum<Align>, Align> _0___ConvertStyleAlignEnumToAlign; // 0x00
			public static TypeConverter<StyleEnum<Align>, StyleKeyword> _1___ConvertAlignToStyleKeyword; // 0x08
			public static TypeConverter<Align, StyleEnum<Align>> _2___ConvertAlignToStyleAlignEnum; // 0x10
			public static TypeConverter<StyleKeyword, StyleEnum<Align>> _3___ConvertStyleKeywordToStyleAlignEnum; // 0x18
			public static TypeConverter<StyleEnum<AnimationPlayState>, AnimationPlayState> _4___ConvertStyleAnimationPlayStateEnumToAnimationPlayState; // 0x20
			public static TypeConverter<StyleEnum<AnimationPlayState>, StyleKeyword> _5___ConvertAnimationPlayStateToStyleKeyword; // 0x28
			public static TypeConverter<AnimationPlayState, StyleEnum<AnimationPlayState>> _6___ConvertAnimationPlayStateToStyleAnimationPlayStateEnum; // 0x30
			public static TypeConverter<StyleKeyword, StyleEnum<AnimationPlayState>> _7___ConvertStyleKeywordToStyleAnimationPlayStateEnum; // 0x38
			public static TypeConverter<StyleRatio, Ratio> _8___ConvertStyleRatioToRatio; // 0x40
			public static TypeConverter<StyleRatio, StyleKeyword> _9___ConvertRatioToStyleKeyword; // 0x48
			public static TypeConverter<Ratio, StyleRatio> _10___ConvertRatioToStyleRatio; // 0x50
			public static TypeConverter<StyleKeyword, StyleRatio> _11___ConvertStyleKeywordToStyleRatio; // 0x58
			public static TypeConverter<StyleList<FilterFunction>, List<FilterFunction>> _12___ConvertStyleFilterFunctionListToFilterFunctionList; // 0x60
			public static TypeConverter<StyleList<FilterFunction>, StyleKeyword> _13___ConvertFilterFunctionListToStyleKeyword; // 0x68
			public static TypeConverter<List<FilterFunction>, StyleList<FilterFunction>> _14___ConvertFilterFunctionListToStyleFilterFunctionList; // 0x70
			public static TypeConverter<StyleKeyword, StyleList<FilterFunction>> _15___ConvertStyleKeywordToStyleFilterFunctionList; // 0x78
			public static TypeConverter<StyleColor, Color> _16___ConvertStyleColorToColor; // 0x80
			public static TypeConverter<StyleColor, StyleKeyword> _17___ConvertColorToStyleKeyword; // 0x88
			public static TypeConverter<Color, StyleColor> _18___ConvertColorToStyleColor; // 0x90
			public static TypeConverter<StyleKeyword, StyleColor> _19___ConvertStyleKeywordToStyleColor; // 0x98
			public static TypeConverter<StyleBackground, Background> _20___ConvertStyleBackgroundToBackground; // 0xA0
			public static TypeConverter<StyleBackground, StyleKeyword> _21___ConvertBackgroundToStyleKeyword; // 0xA8
			public static TypeConverter<Background, StyleBackground> _22___ConvertBackgroundToStyleBackground; // 0xB0
			public static TypeConverter<StyleKeyword, StyleBackground> _23___ConvertStyleKeywordToStyleBackground; // 0xB8
			public static TypeConverter<StyleBackgroundPosition, BackgroundPosition> _24___ConvertStyleBackgroundPositionToBackgroundPosition; // 0xC0
			public static TypeConverter<StyleBackgroundPosition, StyleKeyword> _25___ConvertBackgroundPositionToStyleKeyword; // 0xC8
			public static TypeConverter<BackgroundPosition, StyleBackgroundPosition> _26___ConvertBackgroundPositionToStyleBackgroundPosition; // 0xD0
			public static TypeConverter<StyleKeyword, StyleBackgroundPosition> _27___ConvertStyleKeywordToStyleBackgroundPosition; // 0xD8
			public static TypeConverter<StyleBackgroundRepeat, BackgroundRepeat> _28___ConvertStyleBackgroundRepeatToBackgroundRepeat; // 0xE0
			public static TypeConverter<StyleBackgroundRepeat, StyleKeyword> _29___ConvertBackgroundRepeatToStyleKeyword; // 0xE8
			public static TypeConverter<BackgroundRepeat, StyleBackgroundRepeat> _30___ConvertBackgroundRepeatToStyleBackgroundRepeat; // 0xF0
			public static TypeConverter<StyleKeyword, StyleBackgroundRepeat> _31___ConvertStyleKeywordToStyleBackgroundRepeat; // 0xF8
			public static TypeConverter<StyleBackgroundSize, BackgroundSize> _32___ConvertStyleBackgroundSizeToBackgroundSize; // 0x100
			public static TypeConverter<StyleBackgroundSize, StyleKeyword> _33___ConvertBackgroundSizeToStyleKeyword; // 0x108
			public static TypeConverter<BackgroundSize, StyleBackgroundSize> _34___ConvertBackgroundSizeToStyleBackgroundSize; // 0x110
			public static TypeConverter<StyleKeyword, StyleBackgroundSize> _35___ConvertStyleKeywordToStyleBackgroundSize; // 0x118
			public static TypeConverter<StyleLength, Length> _36___ConvertStyleLengthToLength; // 0x120
			public static TypeConverter<StyleLength, StyleKeyword> _37___ConvertLengthToStyleKeyword; // 0x128
			public static TypeConverter<Length, StyleLength> _38___ConvertLengthToStyleLength; // 0x130
			public static TypeConverter<StyleKeyword, StyleLength> _39___ConvertStyleKeywordToStyleLength; // 0x138
			public static TypeConverter<StyleFloat, float> _40___ConvertStyleFloatToFloat; // 0x140
			public static TypeConverter<StyleFloat, StyleKeyword> _41___ConvertFloatToStyleKeyword; // 0x148
			public static TypeConverter<float, StyleFloat> _42___ConvertFloatToStyleFloat; // 0x150
			public static TypeConverter<StyleKeyword, StyleFloat> _43___ConvertStyleKeywordToStyleFloat; // 0x158
			public static TypeConverter<StyleCursor, Cursor> _44___ConvertStyleCursorToCursor; // 0x160
			public static TypeConverter<StyleCursor, StyleKeyword> _45___ConvertCursorToStyleKeyword; // 0x168
			public static TypeConverter<Cursor, StyleCursor> _46___ConvertCursorToStyleCursor; // 0x170
			public static TypeConverter<StyleKeyword, StyleCursor> _47___ConvertStyleKeywordToStyleCursor; // 0x178
			public static TypeConverter<StyleEnum<DisplayStyle>, DisplayStyle> _48___ConvertStyleDisplayStyleEnumToDisplayStyle; // 0x180
			public static TypeConverter<StyleEnum<DisplayStyle>, StyleKeyword> _49___ConvertDisplayStyleToStyleKeyword; // 0x188
			public static TypeConverter<DisplayStyle, StyleEnum<DisplayStyle>> _50___ConvertDisplayStyleToStyleDisplayStyleEnum; // 0x190
			public static TypeConverter<StyleKeyword, StyleEnum<DisplayStyle>> _51___ConvertStyleKeywordToStyleDisplayStyleEnum; // 0x198
			public static TypeConverter<StyleEnum<FlexDirection>, FlexDirection> _52___ConvertStyleFlexDirectionEnumToFlexDirection; // 0x1A0
			public static TypeConverter<StyleEnum<FlexDirection>, StyleKeyword> _53___ConvertFlexDirectionToStyleKeyword; // 0x1A8
			public static TypeConverter<FlexDirection, StyleEnum<FlexDirection>> _54___ConvertFlexDirectionToStyleFlexDirectionEnum; // 0x1B0
			public static TypeConverter<StyleKeyword, StyleEnum<FlexDirection>> _55___ConvertStyleKeywordToStyleFlexDirectionEnum; // 0x1B8
			public static TypeConverter<StyleEnum<Wrap>, Wrap> _56___ConvertStyleWrapEnumToWrap; // 0x1C0
			public static TypeConverter<StyleEnum<Wrap>, StyleKeyword> _57___ConvertWrapToStyleKeyword; // 0x1C8
			public static TypeConverter<Wrap, StyleEnum<Wrap>> _58___ConvertWrapToStyleWrapEnum; // 0x1D0
			public static TypeConverter<StyleKeyword, StyleEnum<Wrap>> _59___ConvertStyleKeywordToStyleWrapEnum; // 0x1D8
			public static TypeConverter<StyleEnum<Justify>, Justify> _60___ConvertStyleJustifyEnumToJustify; // 0x1E0
			public static TypeConverter<StyleEnum<Justify>, StyleKeyword> _61___ConvertJustifyToStyleKeyword; // 0x1E8
			public static TypeConverter<Justify, StyleEnum<Justify>> _62___ConvertJustifyToStyleJustifyEnum; // 0x1F0
			public static TypeConverter<StyleKeyword, StyleEnum<Justify>> _63___ConvertStyleKeywordToStyleJustifyEnum; // 0x1F8
			public static TypeConverter<StyleEnum<Overflow>, Overflow> _64___ConvertStyleOverflowEnumToOverflow; // 0x200
			public static TypeConverter<StyleEnum<Overflow>, StyleKeyword> _65___ConvertOverflowToStyleKeyword; // 0x208
			public static TypeConverter<Overflow, StyleEnum<Overflow>> _66___ConvertOverflowToStyleOverflowEnum; // 0x210
			public static TypeConverter<StyleKeyword, StyleEnum<Overflow>> _67___ConvertStyleKeywordToStyleOverflowEnum; // 0x218
			public static TypeConverter<StyleEnum<Position>, Position> _68___ConvertStylePositionEnumToPosition; // 0x220
			public static TypeConverter<StyleEnum<Position>, StyleKeyword> _69___ConvertPositionToStyleKeyword; // 0x228
			public static TypeConverter<Position, StyleEnum<Position>> _70___ConvertPositionToStylePositionEnum; // 0x230
			public static TypeConverter<StyleKeyword, StyleEnum<Position>> _71___ConvertStyleKeywordToStylePositionEnum; // 0x238
			public static TypeConverter<StyleRotate, Rotate> _72___ConvertStyleRotateToRotate; // 0x240
			public static TypeConverter<StyleRotate, StyleKeyword> _73___ConvertRotateToStyleKeyword; // 0x248
			public static TypeConverter<Rotate, StyleRotate> _74___ConvertRotateToStyleRotate; // 0x250
			public static TypeConverter<StyleKeyword, StyleRotate> _75___ConvertStyleKeywordToStyleRotate; // 0x258
			public static TypeConverter<StyleScale, Scale> _76___ConvertStyleScaleToScale; // 0x260
			public static TypeConverter<StyleScale, StyleKeyword> _77___ConvertScaleToStyleKeyword; // 0x268
			public static TypeConverter<Scale, StyleScale> _78___ConvertScaleToStyleScale; // 0x270
			public static TypeConverter<StyleKeyword, StyleScale> _79___ConvertStyleKeywordToStyleScale; // 0x278
			public static TypeConverter<StyleEnum<TextOverflow>, TextOverflow> _80___ConvertStyleTextOverflowEnumToTextOverflow; // 0x280
			public static TypeConverter<StyleEnum<TextOverflow>, StyleKeyword> _81___ConvertTextOverflowToStyleKeyword; // 0x288
			public static TypeConverter<TextOverflow, StyleEnum<TextOverflow>> _82___ConvertTextOverflowToStyleTextOverflowEnum; // 0x290
			public static TypeConverter<StyleKeyword, StyleEnum<TextOverflow>> _83___ConvertStyleKeywordToStyleTextOverflowEnum; // 0x298
			public static TypeConverter<StyleTextShadow, TextShadow> _84___ConvertStyleTextShadowToTextShadow; // 0x2A0
			public static TypeConverter<StyleTextShadow, StyleKeyword> _85___ConvertTextShadowToStyleKeyword; // 0x2A8
			public static TypeConverter<TextShadow, StyleTextShadow> _86___ConvertTextShadowToStyleTextShadow; // 0x2B0
			public static TypeConverter<StyleKeyword, StyleTextShadow> _87___ConvertStyleKeywordToStyleTextShadow; // 0x2B8
			public static TypeConverter<StyleTransformOrigin, TransformOrigin> _88___ConvertStyleTransformOriginToTransformOrigin; // 0x2C0
			public static TypeConverter<StyleTransformOrigin, StyleKeyword> _89___ConvertTransformOriginToStyleKeyword; // 0x2C8
			public static TypeConverter<TransformOrigin, StyleTransformOrigin> _90___ConvertTransformOriginToStyleTransformOrigin; // 0x2D0
			public static TypeConverter<StyleKeyword, StyleTransformOrigin> _91___ConvertStyleKeywordToStyleTransformOrigin; // 0x2D8
			public static TypeConverter<StyleList<TimeValue>, List<TimeValue>> _92___ConvertStyleTimeValueListToTimeValueList; // 0x2E0
			public static TypeConverter<StyleList<TimeValue>, StyleKeyword> _93___ConvertTimeValueListToStyleKeyword; // 0x2E8
			public static TypeConverter<List<TimeValue>, StyleList<TimeValue>> _94___ConvertTimeValueListToStyleTimeValueList; // 0x2F0
			public static TypeConverter<StyleKeyword, StyleList<TimeValue>> _95___ConvertStyleKeywordToStyleTimeValueList; // 0x2F8
			public static TypeConverter<StyleList<StylePropertyName>, List<StylePropertyName>> _96___ConvertStyleStylePropertyNameListToStylePropertyNameList; // 0x300
			public static TypeConverter<StyleList<StylePropertyName>, StyleKeyword> _97___ConvertStylePropertyNameListToStyleKeyword; // 0x308
			public static TypeConverter<List<StylePropertyName>, StyleList<StylePropertyName>> _98___ConvertStylePropertyNameListToStyleStylePropertyNameList; // 0x310
			public static TypeConverter<StyleKeyword, StyleList<StylePropertyName>> _99___ConvertStyleKeywordToStyleStylePropertyNameList; // 0x318
			public static TypeConverter<StyleList<EasingFunction>, List<EasingFunction>> _100___ConvertStyleEasingFunctionListToEasingFunctionList; // 0x320
			public static TypeConverter<StyleList<EasingFunction>, StyleKeyword> _101___ConvertEasingFunctionListToStyleKeyword; // 0x328
			public static TypeConverter<List<EasingFunction>, StyleList<EasingFunction>> _102___ConvertEasingFunctionListToStyleEasingFunctionList; // 0x330
			public static TypeConverter<StyleKeyword, StyleList<EasingFunction>> _103___ConvertStyleKeywordToStyleEasingFunctionList; // 0x338
			public static TypeConverter<StyleTranslate, Translate> _104___ConvertStyleTranslateToTranslate; // 0x340
			public static TypeConverter<StyleTranslate, StyleKeyword> _105___ConvertTranslateToStyleKeyword; // 0x348
			public static TypeConverter<Translate, StyleTranslate> _106___ConvertTranslateToStyleTranslate; // 0x350
			public static TypeConverter<StyleKeyword, StyleTranslate> _107___ConvertStyleKeywordToStyleTranslate; // 0x358
			public static TypeConverter<StyleUIAnimationClip, UIAnimationClip> _108___ConvertStyleUIAnimationClipToUIAnimationClip; // 0x360
			public static TypeConverter<StyleUIAnimationClip, StyleKeyword> _109___ConvertUIAnimationClipToStyleKeyword; // 0x368
			public static TypeConverter<UIAnimationClip, StyleUIAnimationClip> _110___ConvertUIAnimationClipToStyleUIAnimationClip; // 0x370
			public static TypeConverter<StyleKeyword, StyleUIAnimationClip> _111___ConvertStyleKeywordToStyleUIAnimationClip; // 0x378
			public static TypeConverter<StyleEnum<EditorTextRenderingMode>, EditorTextRenderingMode> _112___ConvertStyleEditorTextRenderingModeEnumToEditorTextRenderingMode; // 0x380
			public static TypeConverter<StyleEnum<EditorTextRenderingMode>, StyleKeyword> _113___ConvertEditorTextRenderingModeToStyleKeyword; // 0x388
			public static TypeConverter<EditorTextRenderingMode, StyleEnum<EditorTextRenderingMode>> _114___ConvertEditorTextRenderingModeToStyleEditorTextRenderingModeEnum; // 0x390
			public static TypeConverter<StyleKeyword, StyleEnum<EditorTextRenderingMode>> _115___ConvertStyleKeywordToStyleEditorTextRenderingModeEnum; // 0x398
			public static TypeConverter<StyleFont, Font> _116___ConvertStyleFontToFont; // 0x3A0
			public static TypeConverter<StyleFont, StyleKeyword> _117___ConvertFontToStyleKeyword; // 0x3A8
			public static TypeConverter<Font, StyleFont> _118___ConvertFontToStyleFont; // 0x3B0
			public static TypeConverter<StyleKeyword, StyleFont> _119___ConvertStyleKeywordToStyleFont; // 0x3B8
			public static TypeConverter<StyleFontDefinition, FontDefinition> _120___ConvertStyleFontDefinitionToFontDefinition; // 0x3C0
			public static TypeConverter<StyleFontDefinition, StyleKeyword> _121___ConvertFontDefinitionToStyleKeyword; // 0x3C8
			public static TypeConverter<FontDefinition, StyleFontDefinition> _122___ConvertFontDefinitionToStyleFontDefinition; // 0x3D0
			public static TypeConverter<StyleKeyword, StyleFontDefinition> _123___ConvertStyleKeywordToStyleFontDefinition; // 0x3D8
			public static TypeConverter<StyleEnum<FontStyle>, FontStyle> _124___ConvertStyleFontStyleEnumToFontStyle; // 0x3E0
			public static TypeConverter<StyleEnum<FontStyle>, StyleKeyword> _125___ConvertFontStyleToStyleKeyword; // 0x3E8
			public static TypeConverter<FontStyle, StyleEnum<FontStyle>> _126___ConvertFontStyleToStyleFontStyleEnum; // 0x3F0
			public static TypeConverter<StyleKeyword, StyleEnum<FontStyle>> _127___ConvertStyleKeywordToStyleFontStyleEnum; // 0x3F8
			public static TypeConverter<StyleMaterialDefinition, MaterialDefinition> _128___ConvertStyleMaterialDefinitionToMaterialDefinition; // 0x400
			public static TypeConverter<StyleMaterialDefinition, StyleKeyword> _129___ConvertMaterialDefinitionToStyleKeyword; // 0x408
			public static TypeConverter<MaterialDefinition, StyleMaterialDefinition> _130___ConvertMaterialDefinitionToStyleMaterialDefinition; // 0x410
			public static TypeConverter<StyleKeyword, StyleMaterialDefinition> _131___ConvertStyleKeywordToStyleMaterialDefinition; // 0x418
			public static TypeConverter<StyleEnum<OverflowClipBox>, OverflowClipBox> _132___ConvertStyleOverflowClipBoxEnumToOverflowClipBox; // 0x420
			public static TypeConverter<StyleEnum<OverflowClipBox>, StyleKeyword> _133___ConvertOverflowClipBoxToStyleKeyword; // 0x428
			public static TypeConverter<OverflowClipBox, StyleEnum<OverflowClipBox>> _134___ConvertOverflowClipBoxToStyleOverflowClipBoxEnum; // 0x430
			public static TypeConverter<StyleKeyword, StyleEnum<OverflowClipBox>> _135___ConvertStyleKeywordToStyleOverflowClipBoxEnum; // 0x438
			public static TypeConverter<StyleInt, int> _136___ConvertStyleIntToInt; // 0x440
			public static TypeConverter<StyleInt, StyleKeyword> _137___ConvertIntToStyleKeyword; // 0x448
			public static TypeConverter<int, StyleInt> _138___ConvertIntToStyleInt; // 0x450
			public static TypeConverter<StyleKeyword, StyleInt> _139___ConvertStyleKeywordToStyleInt; // 0x458
			public static TypeConverter<StyleEnum<SliceType>, SliceType> _140___ConvertStyleSliceTypeEnumToSliceType; // 0x460
			public static TypeConverter<StyleEnum<SliceType>, StyleKeyword> _141___ConvertSliceTypeToStyleKeyword; // 0x468
			public static TypeConverter<SliceType, StyleEnum<SliceType>> _142___ConvertSliceTypeToStyleSliceTypeEnum; // 0x470
			public static TypeConverter<StyleKeyword, StyleEnum<SliceType>> _143___ConvertStyleKeywordToStyleSliceTypeEnum; // 0x478
			public static TypeConverter<StyleEnum<TextAnchor>, TextAnchor> _144___ConvertStyleTextAnchorEnumToTextAnchor; // 0x480
			public static TypeConverter<StyleEnum<TextAnchor>, StyleKeyword> _145___ConvertTextAnchorToStyleKeyword; // 0x488
			public static TypeConverter<TextAnchor, StyleEnum<TextAnchor>> _146___ConvertTextAnchorToStyleTextAnchorEnum; // 0x490
			public static TypeConverter<StyleKeyword, StyleEnum<TextAnchor>> _147___ConvertStyleKeywordToStyleTextAnchorEnum; // 0x498
			public static TypeConverter<StyleTextAutoSize, TextAutoSize> _148___ConvertStyleTextAutoSizeToTextAutoSize; // 0x4A0
			public static TypeConverter<StyleTextAutoSize, StyleKeyword> _149___ConvertTextAutoSizeToStyleKeyword; // 0x4A8
			public static TypeConverter<TextAutoSize, StyleTextAutoSize> _150___ConvertTextAutoSizeToStyleTextAutoSize; // 0x4B0
			public static TypeConverter<StyleKeyword, StyleTextAutoSize> _151___ConvertStyleKeywordToStyleTextAutoSize; // 0x4B8
			public static TypeConverter<StyleEnum<TextGeneratorType>, TextGeneratorType> _152___ConvertStyleTextGeneratorTypeEnumToTextGeneratorType; // 0x4C0
			public static TypeConverter<StyleEnum<TextGeneratorType>, StyleKeyword> _153___ConvertTextGeneratorTypeToStyleKeyword; // 0x4C8
			public static TypeConverter<TextGeneratorType, StyleEnum<TextGeneratorType>> _154___ConvertTextGeneratorTypeToStyleTextGeneratorTypeEnum; // 0x4D0
			public static TypeConverter<StyleKeyword, StyleEnum<TextGeneratorType>> _155___ConvertStyleKeywordToStyleTextGeneratorTypeEnum; // 0x4D8
			public static TypeConverter<StyleEnum<TextOverflowPosition>, TextOverflowPosition> _156___ConvertStyleTextOverflowPositionEnumToTextOverflowPosition; // 0x4E0
			public static TypeConverter<StyleEnum<TextOverflowPosition>, StyleKeyword> _157___ConvertTextOverflowPositionToStyleKeyword; // 0x4E8
			public static TypeConverter<TextOverflowPosition, StyleEnum<TextOverflowPosition>> _158___ConvertTextOverflowPositionToStyleTextOverflowPositionEnum; // 0x4F0
			public static TypeConverter<StyleKeyword, StyleEnum<TextOverflowPosition>> _159___ConvertStyleKeywordToStyleTextOverflowPositionEnum; // 0x4F8
			public static TypeConverter<StyleEnum<Visibility>, Visibility> _160___ConvertStyleVisibilityEnumToVisibility; // 0x500
			public static TypeConverter<StyleEnum<Visibility>, StyleKeyword> _161___ConvertVisibilityToStyleKeyword; // 0x508
			public static TypeConverter<Visibility, StyleEnum<Visibility>> _162___ConvertVisibilityToStyleVisibilityEnum; // 0x510
			public static TypeConverter<StyleKeyword, StyleEnum<Visibility>> _163___ConvertStyleKeywordToStyleVisibilityEnum; // 0x518
			public static TypeConverter<StyleEnum<WhiteSpace>, WhiteSpace> _164___ConvertStyleWhiteSpaceEnumToWhiteSpace; // 0x520
			public static TypeConverter<StyleEnum<WhiteSpace>, StyleKeyword> _165___ConvertWhiteSpaceToStyleKeyword; // 0x528
			public static TypeConverter<WhiteSpace, StyleEnum<WhiteSpace>> _166___ConvertWhiteSpaceToStyleWhiteSpaceEnum; // 0x530
			public static TypeConverter<StyleKeyword, StyleEnum<WhiteSpace>> _167___ConvertStyleKeywordToStyleWhiteSpaceEnum; // 0x538
			public static TypeConverter<OverflowInternal, Overflow> _168___ConvertOverflowInternalToOverflow; // 0x540
			public static TypeConverter<OverflowInternal, StyleEnum<Overflow>> _169___ConvertOverflowInternalToStyleOverflow; // 0x548
			public static TypeConverter<Overflow, OverflowInternal> _170___ConvertOverflowToOverflowInternal; // 0x550
			public static TypeConverter<StyleEnum<Overflow>, OverflowInternal> _171___ConvertStyleOverflowToOverflowInternal; // 0x558
			public static TypeConverter<Color32, StyleColor> _172___ConvertColor32ToStyleColor; // 0x560
			public static TypeConverter<StyleColor, Color32> _173___ConvertStyleColorToColor32; // 0x568
			public static TypeConverter<float, StyleRatio> _174___ConvertStyleRatioToFloat; // 0x570
			public static TypeConverter<StyleRatio, float> _175___ConvertFloatToStyleRatio; // 0x578
			public static TypeConverter<Texture2D, StyleBackground> _176___ConvertTexture2DToStyleBackground; // 0x580
			public static TypeConverter<Sprite, StyleBackground> _177___ConvertSpriteToStyleBackground; // 0x588
			public static TypeConverter<VectorImage, StyleBackground> _178___ConvertVectorImageToStyleBackground; // 0x590
			public static TypeConverter<RenderTexture, StyleBackground> _179___ConvertRenderTextureToStyleBackground; // 0x598
			public static TypeConverter<StyleBackground, Texture2D> _180___ConvertStyleBackgroundToTexture2D; // 0x5A0
			public static TypeConverter<StyleBackground, Sprite> _181___ConvertStyleBackgroundToSprite; // 0x5A8
			public static TypeConverter<StyleBackground, VectorImage> _182___ConvertStyleBackgroundToVectorImage; // 0x5B0
			public static TypeConverter<StyleBackground, RenderTexture> _183___ConvertStyleBackgroundToRenderTexture; // 0x5B8
			public static TypeConverter<StyleLength, float> _184___ConvertStyleLengthToFloat; // 0x5C0
			public static TypeConverter<StyleLength, int> _185___ConvertStyleLengthToInt; // 0x5C8
			public static TypeConverter<float, StyleLength> _186___ConvertFloatToStyleLength; // 0x5D0
			public static TypeConverter<int, StyleLength> _187___ConvertIntToStyleLength; // 0x5D8
			public static TypeConverter<StyleFloat, int> _188___ConvertStyleFloatToInt; // 0x5E0
			public static TypeConverter<int, StyleFloat> _189___ConvertIntToStyleFloat; // 0x5E8
			public static TypeConverter<Font, StyleFontDefinition> _190___ConvertFontToStyleFontDefinition; // 0x5F0
			public static TypeConverter<FontAsset, StyleFontDefinition> _191___ConvertFontAssetToStyleFontDefinition; // 0x5F8
			public static TypeConverter<StyleFontDefinition, Font> _192___ConvertStyleFontDefinitionToFont; // 0x600
			public static TypeConverter<StyleFontDefinition, FontAsset> _193___ConvertStyleFontDefinitionToFontAsset; // 0x608
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4630
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Delegate> __9__168_0; // 0x08
			public static Func<Delegate> __9__168_1; // 0x10
			public static Func<Delegate> __9__168_2; // 0x18
			public static Func<Delegate> __9__168_3; // 0x20
			public static Func<Delegate> __9__168_4; // 0x28
			public static Func<Delegate> __9__168_5; // 0x30
			public static Func<Delegate> __9__168_6; // 0x38
			public static Func<Delegate> __9__168_7; // 0x40
			public static Func<Delegate> __9__168_8; // 0x48
			public static Func<Delegate> __9__168_9; // 0x50
			public static Func<Delegate> __9__168_10; // 0x58
			public static Func<Delegate> __9__168_11; // 0x60
			public static Func<Delegate> __9__168_12; // 0x68
			public static Func<Delegate> __9__168_13; // 0x70
			public static Func<Delegate> __9__168_14; // 0x78
			public static Func<Delegate> __9__168_15; // 0x80
			public static Func<Delegate> __9__168_16; // 0x88
			public static Func<Delegate> __9__168_17; // 0x90
			public static Func<Delegate> __9__168_18; // 0x98
			public static Func<Delegate> __9__168_19; // 0xA0
			public static Func<Delegate> __9__168_20; // 0xA8
			public static Func<Delegate> __9__168_21; // 0xB0
			public static Func<Delegate> __9__168_22; // 0xB8
			public static Func<Delegate> __9__168_23; // 0xC0
			public static Func<Delegate> __9__168_24; // 0xC8
			public static Func<Delegate> __9__168_25; // 0xD0
			public static Func<Delegate> __9__168_26; // 0xD8
			public static Func<Delegate> __9__168_27; // 0xE0
			public static Func<Delegate> __9__168_28; // 0xE8
			public static Func<Delegate> __9__168_29; // 0xF0
			public static Func<Delegate> __9__168_30; // 0xF8
			public static Func<Delegate> __9__168_31; // 0x100
			public static Func<Delegate> __9__168_32; // 0x108
			public static Func<Delegate> __9__168_33; // 0x110
			public static Func<Delegate> __9__168_34; // 0x118
			public static Func<Delegate> __9__168_35; // 0x120
			public static Func<Delegate> __9__168_36; // 0x128
			public static Func<Delegate> __9__168_37; // 0x130
			public static Func<Delegate> __9__168_38; // 0x138
			public static Func<Delegate> __9__168_39; // 0x140
			public static Func<Delegate> __9__168_40; // 0x148
			public static Func<Delegate> __9__168_41; // 0x150
			public static Func<Delegate> __9__168_42; // 0x158
			public static Func<Delegate> __9__168_43; // 0x160
			public static Func<Delegate> __9__168_44; // 0x168
			public static Func<Delegate> __9__168_45; // 0x170
			public static Func<Delegate> __9__168_46; // 0x178
			public static Func<Delegate> __9__168_47; // 0x180
			public static Func<Delegate> __9__168_48; // 0x188
			public static Func<Delegate> __9__168_49; // 0x190
			public static Func<Delegate> __9__168_50; // 0x198
			public static Func<Delegate> __9__168_51; // 0x1A0
			public static Func<Delegate> __9__168_52; // 0x1A8
			public static Func<Delegate> __9__168_53; // 0x1B0
			public static Func<Delegate> __9__168_54; // 0x1B8
			public static Func<Delegate> __9__168_55; // 0x1C0
			public static Func<Delegate> __9__168_56; // 0x1C8
			public static Func<Delegate> __9__168_57; // 0x1D0
			public static Func<Delegate> __9__168_58; // 0x1D8
			public static Func<Delegate> __9__168_59; // 0x1E0
			public static Func<Delegate> __9__168_60; // 0x1E8
			public static Func<Delegate> __9__168_61; // 0x1F0
			public static Func<Delegate> __9__168_62; // 0x1F8
			public static Func<Delegate> __9__168_63; // 0x200
			public static Func<Delegate> __9__168_64; // 0x208
			public static Func<Delegate> __9__168_65; // 0x210
			public static Func<Delegate> __9__168_66; // 0x218
			public static Func<Delegate> __9__168_67; // 0x220
			public static Func<Delegate> __9__168_68; // 0x228
			public static Func<Delegate> __9__168_69; // 0x230
			public static Func<Delegate> __9__168_70; // 0x238
			public static Func<Delegate> __9__168_71; // 0x240
			public static Func<Delegate> __9__168_72; // 0x248
			public static Func<Delegate> __9__168_73; // 0x250
			public static Func<Delegate> __9__168_74; // 0x258
			public static Func<Delegate> __9__168_75; // 0x260
			public static Func<Delegate> __9__168_76; // 0x268
			public static Func<Delegate> __9__168_77; // 0x270
			public static Func<Delegate> __9__168_78; // 0x278
			public static Func<Delegate> __9__168_79; // 0x280
			public static Func<Delegate> __9__168_80; // 0x288
			public static Func<Delegate> __9__168_81; // 0x290
			public static Func<Delegate> __9__168_82; // 0x298
			public static Func<Delegate> __9__168_83; // 0x2A0
			public static Func<Delegate> __9__168_84; // 0x2A8
			public static Func<Delegate> __9__168_85; // 0x2B0
			public static Func<Delegate> __9__168_86; // 0x2B8
			public static Func<Delegate> __9__168_87; // 0x2C0
			public static Func<Delegate> __9__168_88; // 0x2C8
			public static Func<Delegate> __9__168_89; // 0x2D0
			public static Func<Delegate> __9__168_90; // 0x2D8
			public static Func<Delegate> __9__168_91; // 0x2E0
			public static Func<Delegate> __9__168_92; // 0x2E8
			public static Func<Delegate> __9__168_93; // 0x2F0
			public static Func<Delegate> __9__168_94; // 0x2F8
			public static Func<Delegate> __9__168_95; // 0x300
			public static Func<Delegate> __9__168_96; // 0x308
			public static Func<Delegate> __9__168_97; // 0x310
			public static Func<Delegate> __9__168_98; // 0x318
			public static Func<Delegate> __9__168_99; // 0x320
			public static Func<Delegate> __9__168_100; // 0x328
			public static Func<Delegate> __9__168_101; // 0x330
			public static Func<Delegate> __9__168_102; // 0x338
			public static Func<Delegate> __9__168_103; // 0x340
			public static Func<Delegate> __9__168_104; // 0x348
			public static Func<Delegate> __9__168_105; // 0x350
			public static Func<Delegate> __9__168_106; // 0x358
			public static Func<Delegate> __9__168_107; // 0x360
			public static Func<Delegate> __9__168_108; // 0x368
			public static Func<Delegate> __9__168_109; // 0x370
			public static Func<Delegate> __9__168_110; // 0x378
			public static Func<Delegate> __9__168_111; // 0x380
			public static Func<Delegate> __9__168_112; // 0x388
			public static Func<Delegate> __9__168_113; // 0x390
			public static Func<Delegate> __9__168_114; // 0x398
			public static Func<Delegate> __9__168_115; // 0x3A0
			public static Func<Delegate> __9__168_116; // 0x3A8
			public static Func<Delegate> __9__168_117; // 0x3B0
			public static Func<Delegate> __9__168_118; // 0x3B8
			public static Func<Delegate> __9__168_119; // 0x3C0
			public static Func<Delegate> __9__168_120; // 0x3C8
			public static Func<Delegate> __9__168_121; // 0x3D0
			public static Func<Delegate> __9__168_122; // 0x3D8
			public static Func<Delegate> __9__168_123; // 0x3E0
			public static Func<Delegate> __9__168_124; // 0x3E8
			public static Func<Delegate> __9__168_125; // 0x3F0
			public static Func<Delegate> __9__168_126; // 0x3F8
			public static Func<Delegate> __9__168_127; // 0x400
			public static Func<Delegate> __9__168_128; // 0x408
			public static Func<Delegate> __9__168_129; // 0x410
			public static Func<Delegate> __9__168_130; // 0x418
			public static Func<Delegate> __9__168_131; // 0x420
			public static Func<Delegate> __9__168_132; // 0x428
			public static Func<Delegate> __9__168_133; // 0x430
			public static Func<Delegate> __9__168_134; // 0x438
			public static Func<Delegate> __9__168_135; // 0x440
			public static Func<Delegate> __9__168_136; // 0x448
			public static Func<Delegate> __9__168_137; // 0x450
			public static Func<Delegate> __9__168_138; // 0x458
			public static Func<Delegate> __9__168_139; // 0x460
			public static Func<Delegate> __9__168_140; // 0x468
			public static Func<Delegate> __9__168_141; // 0x470
			public static Func<Delegate> __9__168_142; // 0x478
			public static Func<Delegate> __9__168_143; // 0x480
			public static Func<Delegate> __9__168_144; // 0x488
			public static Func<Delegate> __9__168_145; // 0x490
			public static Func<Delegate> __9__168_146; // 0x498
			public static Func<Delegate> __9__168_147; // 0x4A0
			public static Func<Delegate> __9__168_148; // 0x4A8
			public static Func<Delegate> __9__168_149; // 0x4B0
			public static Func<Delegate> __9__168_150; // 0x4B8
			public static Func<Delegate> __9__168_151; // 0x4C0
			public static Func<Delegate> __9__168_152; // 0x4C8
			public static Func<Delegate> __9__168_153; // 0x4D0
			public static Func<Delegate> __9__168_154; // 0x4D8
			public static Func<Delegate> __9__168_155; // 0x4E0
			public static Func<Delegate> __9__168_156; // 0x4E8
			public static Func<Delegate> __9__168_157; // 0x4F0
			public static Func<Delegate> __9__168_158; // 0x4F8
			public static Func<Delegate> __9__168_159; // 0x500
			public static Func<Delegate> __9__168_160; // 0x508
			public static Func<Delegate> __9__168_161; // 0x510
			public static Func<Delegate> __9__168_162; // 0x518
			public static Func<Delegate> __9__168_163; // 0x520
			public static Func<Delegate> __9__168_164; // 0x528
			public static Func<Delegate> __9__168_165; // 0x530
			public static Func<Delegate> __9__168_166; // 0x538
			public static Func<Delegate> __9__168_167; // 0x540
			public static Func<Delegate> __9__196_0; // 0x548
			public static Func<Delegate> __9__196_1; // 0x550
			public static Func<Delegate> __9__196_2; // 0x558
			public static Func<Delegate> __9__196_3; // 0x560
			public static Func<Delegate> __9__196_4; // 0x568
			public static Func<Delegate> __9__196_5; // 0x570
			public static Func<Delegate> __9__196_6; // 0x578
			public static Func<Delegate> __9__196_7; // 0x580
			public static Func<Delegate> __9__196_8; // 0x588
			public static Func<Delegate> __9__196_9; // 0x590
			public static Func<Delegate> __9__196_10; // 0x598
			public static Func<Delegate> __9__196_11; // 0x5A0
			public static Func<Delegate> __9__196_12; // 0x5A8
			public static Func<Delegate> __9__196_13; // 0x5B0
			public static Func<Delegate> __9__196_14; // 0x5B8
			public static Func<Delegate> __9__196_15; // 0x5C0
			public static Func<Delegate> __9__196_16; // 0x5C8
			public static Func<Delegate> __9__196_17; // 0x5D0
			public static Func<Delegate> __9__196_18; // 0x5D8
			public static Func<Delegate> __9__196_19; // 0x5E0
			public static Func<Delegate> __9__196_20; // 0x5E8
			public static Func<Delegate> __9__196_21; // 0x5F0
			public static Func<Delegate> __9__196_22; // 0x5F8
			public static Func<Delegate> __9__196_23; // 0x600
			public static Func<Delegate> __9__196_24; // 0x608
			public static Func<Delegate> __9__196_25; // 0x610
	
			// Constructors
			static __c(); // 0x0000000182551000-0x0000000182551070
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Delegate _RegisterBuiltInStyleConverters_b__168_0(); // 0x0000000182549300-0x00000001825493B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_1(); // 0x000000018254CDD0-0x000000018254CE80
			internal Delegate _RegisterBuiltInStyleConverters_b__168_2(); // 0x000000018254D600-0x000000018254D6B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_3(); // 0x000000018254DE30-0x000000018254DEE0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_4(); // 0x000000018254E660-0x000000018254E710
			internal Delegate _RegisterBuiltInStyleConverters_b__168_5(); // 0x000000018254EE90-0x000000018254EF40
			internal Delegate _RegisterBuiltInStyleConverters_b__168_6(); // 0x000000018254F6C0-0x000000018254F770
			internal Delegate _RegisterBuiltInStyleConverters_b__168_7(); // 0x000000018254FEF0-0x000000018254FFA0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_8(); // 0x0000000182550720-0x00000001825507D0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_9(); // 0x0000000182550F50-0x0000000182551000
			internal Delegate _RegisterBuiltInStyleConverters_b__168_10(); // 0x0000000182549B30-0x0000000182549BE0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_11(); // 0x000000018254A360-0x000000018254A410
			internal Delegate _RegisterBuiltInStyleConverters_b__168_12(); // 0x000000018254AB90-0x000000018254AC40
			internal Delegate _RegisterBuiltInStyleConverters_b__168_13(); // 0x000000018254B3C0-0x000000018254B470
			internal Delegate _RegisterBuiltInStyleConverters_b__168_14(); // 0x000000018254BBF0-0x000000018254BCA0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_15(); // 0x000000018254C420-0x000000018254C4D0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_16(); // 0x000000018254CAD0-0x000000018254CB90
			internal Delegate _RegisterBuiltInStyleConverters_b__168_17(); // 0x000000018254CB90-0x000000018254CC50
			internal Delegate _RegisterBuiltInStyleConverters_b__168_18(); // 0x000000018254CC50-0x000000018254CD10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_19(); // 0x000000018254CD10-0x000000018254CDD0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_20(); // 0x000000018254CE80-0x000000018254CF40
			internal Delegate _RegisterBuiltInStyleConverters_b__168_21(); // 0x000000018254CF40-0x000000018254D000
			internal Delegate _RegisterBuiltInStyleConverters_b__168_22(); // 0x000000018254D000-0x000000018254D0C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_23(); // 0x000000018254D0C0-0x000000018254D180
			internal Delegate _RegisterBuiltInStyleConverters_b__168_24(); // 0x000000018254D180-0x000000018254D240
			internal Delegate _RegisterBuiltInStyleConverters_b__168_25(); // 0x000000018254D240-0x000000018254D300
			internal Delegate _RegisterBuiltInStyleConverters_b__168_26(); // 0x000000018254D300-0x000000018254D3C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_27(); // 0x000000018254D3C0-0x000000018254D480
			internal Delegate _RegisterBuiltInStyleConverters_b__168_28(); // 0x000000018254D480-0x000000018254D540
			internal Delegate _RegisterBuiltInStyleConverters_b__168_29(); // 0x000000018254D540-0x000000018254D600
			internal Delegate _RegisterBuiltInStyleConverters_b__168_30(); // 0x000000018254D6B0-0x000000018254D770
			internal Delegate _RegisterBuiltInStyleConverters_b__168_31(); // 0x000000018254D770-0x000000018254D830
			internal Delegate _RegisterBuiltInStyleConverters_b__168_32(); // 0x000000018254D830-0x000000018254D8F0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_33(); // 0x000000018254D8F0-0x000000018254D9B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_34(); // 0x000000018254D9B0-0x000000018254DA70
			internal Delegate _RegisterBuiltInStyleConverters_b__168_35(); // 0x000000018254DA70-0x000000018254DB30
			internal Delegate _RegisterBuiltInStyleConverters_b__168_36(); // 0x000000018254DB30-0x000000018254DBF0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_37(); // 0x000000018254DBF0-0x000000018254DCB0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_38(); // 0x000000018254DCB0-0x000000018254DD70
			internal Delegate _RegisterBuiltInStyleConverters_b__168_39(); // 0x000000018254DD70-0x000000018254DE30
			internal Delegate _RegisterBuiltInStyleConverters_b__168_40(); // 0x000000018254DEE0-0x000000018254DFA0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_41(); // 0x000000018254DFA0-0x000000018254E060
			internal Delegate _RegisterBuiltInStyleConverters_b__168_42(); // 0x000000018254E060-0x000000018254E120
			internal Delegate _RegisterBuiltInStyleConverters_b__168_43(); // 0x000000018254E120-0x000000018254E1E0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_44(); // 0x000000018254E1E0-0x000000018254E2A0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_45(); // 0x000000018254E2A0-0x000000018254E360
			internal Delegate _RegisterBuiltInStyleConverters_b__168_46(); // 0x000000018254E360-0x000000018254E420
			internal Delegate _RegisterBuiltInStyleConverters_b__168_47(); // 0x000000018254E420-0x000000018254E4E0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_48(); // 0x000000018254E4E0-0x000000018254E5A0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_49(); // 0x000000018254E5A0-0x000000018254E660
			internal Delegate _RegisterBuiltInStyleConverters_b__168_50(); // 0x000000018254E710-0x000000018254E7D0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_51(); // 0x000000018254E7D0-0x000000018254E890
			internal Delegate _RegisterBuiltInStyleConverters_b__168_52(); // 0x000000018254E890-0x000000018254E950
			internal Delegate _RegisterBuiltInStyleConverters_b__168_53(); // 0x000000018254E950-0x000000018254EA10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_54(); // 0x000000018254EA10-0x000000018254EAD0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_55(); // 0x000000018254EAD0-0x000000018254EB90
			internal Delegate _RegisterBuiltInStyleConverters_b__168_56(); // 0x000000018254EB90-0x000000018254EC50
			internal Delegate _RegisterBuiltInStyleConverters_b__168_57(); // 0x000000018254EC50-0x000000018254ED10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_58(); // 0x000000018254ED10-0x000000018254EDD0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_59(); // 0x000000018254EDD0-0x000000018254EE90
			internal Delegate _RegisterBuiltInStyleConverters_b__168_60(); // 0x000000018254EF40-0x000000018254F000
			internal Delegate _RegisterBuiltInStyleConverters_b__168_61(); // 0x000000018254F000-0x000000018254F0C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_62(); // 0x000000018254F0C0-0x000000018254F180
			internal Delegate _RegisterBuiltInStyleConverters_b__168_63(); // 0x000000018254F180-0x000000018254F240
			internal Delegate _RegisterBuiltInStyleConverters_b__168_64(); // 0x000000018254F240-0x000000018254F300
			internal Delegate _RegisterBuiltInStyleConverters_b__168_65(); // 0x000000018254F300-0x000000018254F3C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_66(); // 0x000000018254F3C0-0x000000018254F480
			internal Delegate _RegisterBuiltInStyleConverters_b__168_67(); // 0x000000018254F480-0x000000018254F540
			internal Delegate _RegisterBuiltInStyleConverters_b__168_68(); // 0x000000018254F540-0x000000018254F600
			internal Delegate _RegisterBuiltInStyleConverters_b__168_69(); // 0x000000018254F600-0x000000018254F6C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_70(); // 0x000000018254F770-0x000000018254F830
			internal Delegate _RegisterBuiltInStyleConverters_b__168_71(); // 0x000000018254F830-0x000000018254F8F0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_72(); // 0x000000018254F8F0-0x000000018254F9B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_73(); // 0x000000018254F9B0-0x000000018254FA70
			internal Delegate _RegisterBuiltInStyleConverters_b__168_74(); // 0x000000018254FA70-0x000000018254FB30
			internal Delegate _RegisterBuiltInStyleConverters_b__168_75(); // 0x000000018254FB30-0x000000018254FBF0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_76(); // 0x000000018254FBF0-0x000000018254FCB0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_77(); // 0x000000018254FCB0-0x000000018254FD70
			internal Delegate _RegisterBuiltInStyleConverters_b__168_78(); // 0x000000018254FD70-0x000000018254FE30
			internal Delegate _RegisterBuiltInStyleConverters_b__168_79(); // 0x000000018254FE30-0x000000018254FEF0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_80(); // 0x000000018254FFA0-0x0000000182550060
			internal Delegate _RegisterBuiltInStyleConverters_b__168_81(); // 0x0000000182550060-0x0000000182550120
			internal Delegate _RegisterBuiltInStyleConverters_b__168_82(); // 0x0000000182550120-0x00000001825501E0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_83(); // 0x00000001825501E0-0x00000001825502A0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_84(); // 0x00000001825502A0-0x0000000182550360
			internal Delegate _RegisterBuiltInStyleConverters_b__168_85(); // 0x0000000182550360-0x0000000182550420
			internal Delegate _RegisterBuiltInStyleConverters_b__168_86(); // 0x0000000182550420-0x00000001825504E0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_87(); // 0x00000001825504E0-0x00000001825505A0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_88(); // 0x00000001825505A0-0x0000000182550660
			internal Delegate _RegisterBuiltInStyleConverters_b__168_89(); // 0x0000000182550660-0x0000000182550720
			internal Delegate _RegisterBuiltInStyleConverters_b__168_90(); // 0x00000001825507D0-0x0000000182550890
			internal Delegate _RegisterBuiltInStyleConverters_b__168_91(); // 0x0000000182550890-0x0000000182550950
			internal Delegate _RegisterBuiltInStyleConverters_b__168_92(); // 0x0000000182550950-0x0000000182550A10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_93(); // 0x0000000182550A10-0x0000000182550AD0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_94(); // 0x0000000182550AD0-0x0000000182550B90
			internal Delegate _RegisterBuiltInStyleConverters_b__168_95(); // 0x0000000182550B90-0x0000000182550C50
			internal Delegate _RegisterBuiltInStyleConverters_b__168_96(); // 0x0000000182550C50-0x0000000182550D10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_97(); // 0x0000000182550D10-0x0000000182550DD0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_98(); // 0x0000000182550DD0-0x0000000182550E90
			internal Delegate _RegisterBuiltInStyleConverters_b__168_99(); // 0x0000000182550E90-0x0000000182550F50
			internal Delegate _RegisterBuiltInStyleConverters_b__168_100(); // 0x00000001825493B0-0x0000000182549470
			internal Delegate _RegisterBuiltInStyleConverters_b__168_101(); // 0x0000000182549470-0x0000000182549530
			internal Delegate _RegisterBuiltInStyleConverters_b__168_102(); // 0x0000000182549530-0x00000001825495F0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_103(); // 0x00000001825495F0-0x00000001825496B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_104(); // 0x00000001825496B0-0x0000000182549770
			internal Delegate _RegisterBuiltInStyleConverters_b__168_105(); // 0x0000000182549770-0x0000000182549830
			internal Delegate _RegisterBuiltInStyleConverters_b__168_106(); // 0x0000000182549830-0x00000001825498F0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_107(); // 0x00000001825498F0-0x00000001825499B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_108(); // 0x00000001825499B0-0x0000000182549A70
			internal Delegate _RegisterBuiltInStyleConverters_b__168_109(); // 0x0000000182549A70-0x0000000182549B30
			internal Delegate _RegisterBuiltInStyleConverters_b__168_110(); // 0x0000000182549BE0-0x0000000182549CA0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_111(); // 0x0000000182549CA0-0x0000000182549D60
			internal Delegate _RegisterBuiltInStyleConverters_b__168_112(); // 0x0000000182549D60-0x0000000182549E20
			internal Delegate _RegisterBuiltInStyleConverters_b__168_113(); // 0x0000000182549E20-0x0000000182549EE0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_114(); // 0x0000000182549EE0-0x0000000182549FA0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_115(); // 0x0000000182549FA0-0x000000018254A060
			internal Delegate _RegisterBuiltInStyleConverters_b__168_116(); // 0x000000018254A060-0x000000018254A120
			internal Delegate _RegisterBuiltInStyleConverters_b__168_117(); // 0x000000018254A120-0x000000018254A1E0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_118(); // 0x000000018254A1E0-0x000000018254A2A0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_119(); // 0x000000018254A2A0-0x000000018254A360
			internal Delegate _RegisterBuiltInStyleConverters_b__168_120(); // 0x000000018254A410-0x000000018254A4D0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_121(); // 0x000000018254A4D0-0x000000018254A590
			internal Delegate _RegisterBuiltInStyleConverters_b__168_122(); // 0x000000018254A590-0x000000018254A650
			internal Delegate _RegisterBuiltInStyleConverters_b__168_123(); // 0x000000018254A650-0x000000018254A710
			internal Delegate _RegisterBuiltInStyleConverters_b__168_124(); // 0x000000018254A710-0x000000018254A7D0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_125(); // 0x000000018254A7D0-0x000000018254A890
			internal Delegate _RegisterBuiltInStyleConverters_b__168_126(); // 0x000000018254A890-0x000000018254A950
			internal Delegate _RegisterBuiltInStyleConverters_b__168_127(); // 0x000000018254A950-0x000000018254AA10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_128(); // 0x000000018254AA10-0x000000018254AAD0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_129(); // 0x000000018254AAD0-0x000000018254AB90
			internal Delegate _RegisterBuiltInStyleConverters_b__168_130(); // 0x000000018254AC40-0x000000018254AD00
			internal Delegate _RegisterBuiltInStyleConverters_b__168_131(); // 0x000000018254AD00-0x000000018254ADC0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_132(); // 0x000000018254ADC0-0x000000018254AE80
			internal Delegate _RegisterBuiltInStyleConverters_b__168_133(); // 0x000000018254AE80-0x000000018254AF40
			internal Delegate _RegisterBuiltInStyleConverters_b__168_134(); // 0x000000018254AF40-0x000000018254B000
			internal Delegate _RegisterBuiltInStyleConverters_b__168_135(); // 0x000000018254B000-0x000000018254B0C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_136(); // 0x000000018254B0C0-0x000000018254B180
			internal Delegate _RegisterBuiltInStyleConverters_b__168_137(); // 0x000000018254B180-0x000000018254B240
			internal Delegate _RegisterBuiltInStyleConverters_b__168_138(); // 0x000000018254B240-0x000000018254B300
			internal Delegate _RegisterBuiltInStyleConverters_b__168_139(); // 0x000000018254B300-0x000000018254B3C0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_140(); // 0x000000018254B470-0x000000018254B530
			internal Delegate _RegisterBuiltInStyleConverters_b__168_141(); // 0x000000018254B530-0x000000018254B5F0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_142(); // 0x000000018254B5F0-0x000000018254B6B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_143(); // 0x000000018254B6B0-0x000000018254B770
			internal Delegate _RegisterBuiltInStyleConverters_b__168_144(); // 0x000000018254B770-0x000000018254B830
			internal Delegate _RegisterBuiltInStyleConverters_b__168_145(); // 0x000000018254B830-0x000000018254B8F0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_146(); // 0x000000018254B8F0-0x000000018254B9B0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_147(); // 0x000000018254B9B0-0x000000018254BA70
			internal Delegate _RegisterBuiltInStyleConverters_b__168_148(); // 0x000000018254BA70-0x000000018254BB30
			internal Delegate _RegisterBuiltInStyleConverters_b__168_149(); // 0x000000018254BB30-0x000000018254BBF0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_150(); // 0x000000018254BCA0-0x000000018254BD60
			internal Delegate _RegisterBuiltInStyleConverters_b__168_151(); // 0x000000018254BD60-0x000000018254BE20
			internal Delegate _RegisterBuiltInStyleConverters_b__168_152(); // 0x000000018254BE20-0x000000018254BEE0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_153(); // 0x000000018254BEE0-0x000000018254BFA0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_154(); // 0x000000018254BFA0-0x000000018254C060
			internal Delegate _RegisterBuiltInStyleConverters_b__168_155(); // 0x000000018254C060-0x000000018254C120
			internal Delegate _RegisterBuiltInStyleConverters_b__168_156(); // 0x000000018254C120-0x000000018254C1E0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_157(); // 0x000000018254C1E0-0x000000018254C2A0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_158(); // 0x000000018254C2A0-0x000000018254C360
			internal Delegate _RegisterBuiltInStyleConverters_b__168_159(); // 0x000000018254C360-0x000000018254C420
			internal Delegate _RegisterBuiltInStyleConverters_b__168_160(); // 0x000000018254C4D0-0x000000018254C590
			internal Delegate _RegisterBuiltInStyleConverters_b__168_161(); // 0x000000018254C590-0x000000018254C650
			internal Delegate _RegisterBuiltInStyleConverters_b__168_162(); // 0x000000018254C650-0x000000018254C710
			internal Delegate _RegisterBuiltInStyleConverters_b__168_163(); // 0x000000018254C710-0x000000018254C7D0
			internal Delegate _RegisterBuiltInStyleConverters_b__168_164(); // 0x000000018254C7D0-0x000000018254C890
			internal Delegate _RegisterBuiltInStyleConverters_b__168_165(); // 0x000000018254C890-0x000000018254C950
			internal Delegate _RegisterBuiltInStyleConverters_b__168_166(); // 0x000000018254C950-0x000000018254CA10
			internal Delegate _RegisterBuiltInStyleConverters_b__168_167(); // 0x000000018254CA10-0x000000018254CAD0
			internal Delegate _RegisterAdditionalConverters_b__196_0(); // 0x0000000182547F80-0x0000000182548040
			internal Delegate _RegisterAdditionalConverters_b__196_1(); // 0x00000001825487C0-0x0000000182548880
			internal Delegate _RegisterAdditionalConverters_b__196_2(); // 0x0000000182548D00-0x0000000182548DC0
			internal Delegate _RegisterAdditionalConverters_b__196_3(); // 0x0000000182548DC0-0x0000000182548E80
			internal Delegate _RegisterAdditionalConverters_b__196_4(); // 0x0000000182548E80-0x0000000182548F40
			internal Delegate _RegisterAdditionalConverters_b__196_5(); // 0x0000000182548F40-0x0000000182549000
			internal Delegate _RegisterAdditionalConverters_b__196_6(); // 0x0000000182549000-0x00000001825490C0
			internal Delegate _RegisterAdditionalConverters_b__196_7(); // 0x00000001825490C0-0x0000000182549180
			internal Delegate _RegisterAdditionalConverters_b__196_8(); // 0x0000000182549180-0x0000000182549240
			internal Delegate _RegisterAdditionalConverters_b__196_9(); // 0x0000000182549240-0x0000000182549300
			internal Delegate _RegisterAdditionalConverters_b__196_10(); // 0x0000000182548040-0x0000000182548100
			internal Delegate _RegisterAdditionalConverters_b__196_11(); // 0x0000000182548100-0x00000001825481C0
			internal Delegate _RegisterAdditionalConverters_b__196_12(); // 0x00000001825481C0-0x0000000182548280
			internal Delegate _RegisterAdditionalConverters_b__196_13(); // 0x0000000182548280-0x0000000182548340
			internal Delegate _RegisterAdditionalConverters_b__196_14(); // 0x0000000182548340-0x0000000182548400
			internal Delegate _RegisterAdditionalConverters_b__196_15(); // 0x0000000182548400-0x00000001825484C0
			internal Delegate _RegisterAdditionalConverters_b__196_16(); // 0x00000001825484C0-0x0000000182548580
			internal Delegate _RegisterAdditionalConverters_b__196_17(); // 0x0000000182548580-0x0000000182548640
			internal Delegate _RegisterAdditionalConverters_b__196_18(); // 0x0000000182548640-0x0000000182548700
			internal Delegate _RegisterAdditionalConverters_b__196_19(); // 0x0000000182548700-0x00000001825487C0
			internal Delegate _RegisterAdditionalConverters_b__196_20(); // 0x0000000182548880-0x0000000182548940
			internal Delegate _RegisterAdditionalConverters_b__196_21(); // 0x0000000182548940-0x0000000182548A00
			internal Delegate _RegisterAdditionalConverters_b__196_22(); // 0x0000000182548A00-0x0000000182548AC0
			internal Delegate _RegisterAdditionalConverters_b__196_23(); // 0x0000000182548AC0-0x0000000182548B80
			internal Delegate _RegisterAdditionalConverters_b__196_24(); // 0x0000000182548B80-0x0000000182548C40
			internal Delegate _RegisterAdditionalConverters_b__196_25(); // 0x0000000182548C40-0x0000000182548D00
		}
	
		// Methods
		private static Align ConvertStyleAlignEnumToAlign(ref StyleEnum<Align> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertAlignToStyleKeyword(ref StyleEnum<Align> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<Align> ConvertAlignToStyleAlignEnum(ref Align value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<Align> ConvertStyleKeywordToStyleAlignEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static AnimationPlayState ConvertStyleAnimationPlayStateEnumToAnimationPlayState(ref StyleEnum<AnimationPlayState> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertAnimationPlayStateToStyleKeyword(ref StyleEnum<AnimationPlayState> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<AnimationPlayState> ConvertAnimationPlayStateToStyleAnimationPlayStateEnum(ref AnimationPlayState value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<AnimationPlayState> ConvertStyleKeywordToStyleAnimationPlayStateEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Ratio ConvertStyleRatioToRatio(ref StyleRatio value); // 0x0000000182551DF0-0x0000000182551E00
		private static StyleKeyword ConvertRatioToStyleKeyword(ref StyleRatio value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleRatio ConvertRatioToStyleRatio(ref Ratio value); // 0x0000000182551070-0x0000000182551080
		private static StyleRatio ConvertStyleKeywordToStyleRatio(ref StyleKeyword value); // 0x0000000182551CA0-0x0000000182551CB0
		private static List<FilterFunction> ConvertStyleFilterFunctionListToFilterFunctionList(ref StyleList<FilterFunction> value); // 0x0000000182551980-0x0000000182551990
		private static StyleKeyword ConvertFilterFunctionListToStyleKeyword(ref StyleList<FilterFunction> value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleList<FilterFunction> ConvertFilterFunctionListToStyleFilterFunctionList(ref List<FilterFunction> value); // 0x00000001825512F0-0x0000000182551320
		private static StyleList<FilterFunction> ConvertStyleKeywordToStyleFilterFunctionList(ref StyleKeyword value); // 0x0000000182551B90-0x0000000182551BC0
		private static Color ConvertStyleColorToColor(ref StyleColor value); // 0x0000000182551920-0x0000000182551950
		private static StyleKeyword ConvertColorToStyleKeyword(ref StyleColor value); // 0x00000001802E64B0-0x00000001802E64C0
		private static StyleColor ConvertColorToStyleColor(ref Color value); // 0x0000000182551260-0x00000001825512A0
		private static StyleColor ConvertStyleKeywordToStyleColor(ref StyleKeyword value); // 0x0000000182551B30-0x0000000182551B60
		private static Background ConvertStyleBackgroundToBackground(ref StyleBackground value); // 0x0000000182551710-0x0000000182551750
		private static StyleKeyword ConvertBackgroundToStyleKeyword(ref StyleBackground value); // 0x000000018033D790-0x000000018033D7A0
		private static StyleBackground ConvertBackgroundToStyleBackground(ref Background value); // 0x0000000182551140-0x00000001825511C0
		private static StyleBackground ConvertStyleKeywordToStyleBackground(ref StyleKeyword value); // 0x0000000182551AE0-0x0000000182551B30
		private static BackgroundPosition ConvertStyleBackgroundPositionToBackgroundPosition(ref StyleBackgroundPosition value); // 0x00000001825516A0-0x00000001825516D0
		private static StyleKeyword ConvertBackgroundPositionToStyleKeyword(ref StyleBackgroundPosition value); // 0x0000000180732D30-0x0000000180732D40
		private static StyleBackgroundPosition ConvertBackgroundPositionToStyleBackgroundPosition(ref BackgroundPosition value); // 0x0000000182551080-0x00000001825510C0
		private static StyleBackgroundPosition ConvertStyleKeywordToStyleBackgroundPosition(ref StyleKeyword value); // 0x0000000182551A40-0x0000000182551A70
		private static BackgroundRepeat ConvertStyleBackgroundRepeatToBackgroundRepeat(ref StyleBackgroundRepeat value); // 0x00000001825516D0-0x00000001825516E0
		private static StyleKeyword ConvertBackgroundRepeatToStyleKeyword(ref StyleBackgroundRepeat value); // 0x0000000180732D20-0x0000000180732D30
		private static StyleBackgroundRepeat ConvertBackgroundRepeatToStyleBackgroundRepeat(ref BackgroundRepeat value); // 0x00000001825510C0-0x00000001825510F0
		private static StyleBackgroundRepeat ConvertStyleKeywordToStyleBackgroundRepeat(ref StyleKeyword value); // 0x0000000182551A70-0x0000000182551AA0
		private static BackgroundSize ConvertStyleBackgroundSizeToBackgroundSize(ref StyleBackgroundSize value); // 0x00000001825516E0-0x0000000182551710
		private static StyleKeyword ConvertBackgroundSizeToStyleKeyword(ref StyleBackgroundSize value); // 0x0000000180A5E110-0x0000000180A5E120
		private static StyleBackgroundSize ConvertBackgroundSizeToStyleBackgroundSize(ref BackgroundSize value); // 0x00000001825510F0-0x0000000182551140
		private static StyleBackgroundSize ConvertStyleKeywordToStyleBackgroundSize(ref StyleKeyword value); // 0x0000000182551AA0-0x0000000182551AE0
		private static Length ConvertStyleLengthToLength(ref StyleLength value); // 0x0000000182551DA0-0x0000000182551DB0
		private static StyleKeyword ConvertLengthToStyleKeyword(ref StyleLength value); // 0x0000000180732D20-0x0000000180732D30
		private static StyleLength ConvertLengthToStyleLength(ref Length value); // 0x00000001825514B0-0x00000001825514E0
		private static StyleLength ConvertStyleKeywordToStyleLength(ref StyleKeyword value); // 0x0000000182551C30-0x0000000182551C60
		private static float ConvertStyleFloatToFloat(ref StyleFloat value); // 0x0000000182551990-0x00000001825519A0
		private static StyleKeyword ConvertFloatToStyleKeyword(ref StyleFloat value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleFloat ConvertFloatToStyleFloat(ref float value); // 0x0000000182551320-0x0000000182551330
		private static StyleFloat ConvertStyleKeywordToStyleFloat(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Cursor ConvertStyleCursorToCursor(ref StyleCursor value); // 0x0000000182551950-0x0000000182551980
		private static StyleKeyword ConvertCursorToStyleKeyword(ref StyleCursor value); // 0x0000000180B23260-0x0000000180B23270
		private static StyleCursor ConvertCursorToStyleCursor(ref Cursor value); // 0x00000001825512A0-0x00000001825512F0
		private static StyleCursor ConvertStyleKeywordToStyleCursor(ref StyleKeyword value); // 0x0000000182551B60-0x0000000182551B90
		private static DisplayStyle ConvertStyleDisplayStyleEnumToDisplayStyle(ref StyleEnum<DisplayStyle> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertDisplayStyleToStyleKeyword(ref StyleEnum<DisplayStyle> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<DisplayStyle> ConvertDisplayStyleToStyleDisplayStyleEnum(ref DisplayStyle value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<DisplayStyle> ConvertStyleKeywordToStyleDisplayStyleEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static FlexDirection ConvertStyleFlexDirectionEnumToFlexDirection(ref StyleEnum<FlexDirection> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertFlexDirectionToStyleKeyword(ref StyleEnum<FlexDirection> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<FlexDirection> ConvertFlexDirectionToStyleFlexDirectionEnum(ref FlexDirection value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<FlexDirection> ConvertStyleKeywordToStyleFlexDirectionEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Wrap ConvertStyleWrapEnumToWrap(ref StyleEnum<Wrap> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertWrapToStyleKeyword(ref StyleEnum<Wrap> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<Wrap> ConvertWrapToStyleWrapEnum(ref Wrap value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<Wrap> ConvertStyleKeywordToStyleWrapEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Justify ConvertStyleJustifyEnumToJustify(ref StyleEnum<Justify> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertJustifyToStyleKeyword(ref StyleEnum<Justify> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<Justify> ConvertJustifyToStyleJustifyEnum(ref Justify value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<Justify> ConvertStyleKeywordToStyleJustifyEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Overflow ConvertStyleOverflowEnumToOverflow(ref StyleEnum<Overflow> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertOverflowToStyleKeyword(ref StyleEnum<Overflow> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<Overflow> ConvertOverflowToStyleOverflowEnum(ref Overflow value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<Overflow> ConvertStyleKeywordToStyleOverflowEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Position ConvertStylePositionEnumToPosition(ref StyleEnum<Position> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertPositionToStyleKeyword(ref StyleEnum<Position> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<Position> ConvertPositionToStylePositionEnum(ref Position value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<Position> ConvertStyleKeywordToStylePositionEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Rotate ConvertStyleRotateToRotate(ref StyleRotate value); // 0x0000000182551E00-0x0000000182551E30
		private static StyleKeyword ConvertRotateToStyleKeyword(ref StyleRotate value); // 0x0000000180B23260-0x0000000180B23270
		private static StyleRotate ConvertRotateToStyleRotate(ref Rotate value); // 0x00000001825515B0-0x0000000182551600
		private static StyleRotate ConvertStyleKeywordToStyleRotate(ref StyleKeyword value); // 0x0000000182551CB0-0x0000000182551CF0
		private static Scale ConvertStyleScaleToScale(ref StyleScale value); // 0x0000000182551E30-0x0000000182551E60
		private static StyleKeyword ConvertScaleToStyleKeyword(ref StyleScale value); // 0x00000001802E64B0-0x00000001802E64C0
		private static StyleScale ConvertScaleToStyleScale(ref Scale value); // 0x0000000182551260-0x00000001825512A0
		private static StyleScale ConvertStyleKeywordToStyleScale(ref StyleKeyword value); // 0x0000000182551B30-0x0000000182551B60
		private static TextOverflow ConvertStyleTextOverflowEnumToTextOverflow(ref StyleEnum<TextOverflow> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertTextOverflowToStyleKeyword(ref StyleEnum<TextOverflow> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<TextOverflow> ConvertTextOverflowToStyleTextOverflowEnum(ref TextOverflow value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<TextOverflow> ConvertStyleKeywordToStyleTextOverflowEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static TextShadow ConvertStyleTextShadowToTextShadow(ref StyleTextShadow value); // 0x0000000182551E90-0x0000000182551ED0
		private static StyleKeyword ConvertTextShadowToStyleKeyword(ref StyleTextShadow value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleTextShadow ConvertTextShadowToStyleTextShadow(ref TextShadow value); // 0x0000000182551F80-0x0000000182551FD0
		private static StyleTextShadow ConvertStyleKeywordToStyleTextShadow(ref StyleKeyword value); // 0x0000000182551D30-0x0000000182551D60
		private static TransformOrigin ConvertStyleTransformOriginToTransformOrigin(ref StyleTransformOrigin value); // 0x0000000182551ED0-0x0000000182551F00
		private static StyleKeyword ConvertTransformOriginToStyleKeyword(ref StyleTransformOrigin value); // 0x0000000180A5E110-0x0000000180A5E120
		private static StyleTransformOrigin ConvertTransformOriginToStyleTransformOrigin(ref TransformOrigin value); // 0x00000001825510F0-0x0000000182551140
		private static StyleTransformOrigin ConvertStyleKeywordToStyleTransformOrigin(ref StyleKeyword value); // 0x0000000182551AA0-0x0000000182551AE0
		private static List<TimeValue> ConvertStyleTimeValueListToTimeValueList(ref StyleList<TimeValue> value); // 0x0000000182551980-0x0000000182551990
		private static StyleKeyword ConvertTimeValueListToStyleKeyword(ref StyleList<TimeValue> value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleList<TimeValue> ConvertTimeValueListToStyleTimeValueList(ref List<TimeValue> value); // 0x00000001825512F0-0x0000000182551320
		private static StyleList<TimeValue> ConvertStyleKeywordToStyleTimeValueList(ref StyleKeyword value); // 0x0000000182551B90-0x0000000182551BC0
		private static List<StylePropertyName> ConvertStyleStylePropertyNameListToStylePropertyNameList(ref StyleList<StylePropertyName> value); // 0x0000000182551980-0x0000000182551990
		private static StyleKeyword ConvertStylePropertyNameListToStyleKeyword(ref StyleList<StylePropertyName> value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleList<StylePropertyName> ConvertStylePropertyNameListToStyleStylePropertyNameList(ref List<StylePropertyName> value); // 0x00000001825512F0-0x0000000182551320
		private static StyleList<StylePropertyName> ConvertStyleKeywordToStyleStylePropertyNameList(ref StyleKeyword value); // 0x0000000182551B90-0x0000000182551BC0
		private static List<EasingFunction> ConvertStyleEasingFunctionListToEasingFunctionList(ref StyleList<EasingFunction> value); // 0x0000000182551980-0x0000000182551990
		private static StyleKeyword ConvertEasingFunctionListToStyleKeyword(ref StyleList<EasingFunction> value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleList<EasingFunction> ConvertEasingFunctionListToStyleEasingFunctionList(ref List<EasingFunction> value); // 0x00000001825512F0-0x0000000182551320
		private static StyleList<EasingFunction> ConvertStyleKeywordToStyleEasingFunctionList(ref StyleKeyword value); // 0x0000000182551B90-0x0000000182551BC0
		private static Translate ConvertStyleTranslateToTranslate(ref StyleTranslate value); // 0x0000000182551F00-0x0000000182551F30
		private static StyleKeyword ConvertTranslateToStyleKeyword(ref StyleTranslate value); // 0x0000000180B23260-0x0000000180B23270
		private static StyleTranslate ConvertTranslateToStyleTranslate(ref Translate value); // 0x00000001825515B0-0x0000000182551600
		private static StyleTranslate ConvertStyleKeywordToStyleTranslate(ref StyleKeyword value); // 0x0000000182551CB0-0x0000000182551CF0
		private static UIAnimationClip ConvertStyleUIAnimationClipToUIAnimationClip(ref StyleUIAnimationClip value); // 0x00000001825516D0-0x00000001825516E0
		private static StyleKeyword ConvertUIAnimationClipToStyleKeyword(ref StyleUIAnimationClip value); // 0x0000000180732D20-0x0000000180732D30
		private static StyleUIAnimationClip ConvertUIAnimationClipToStyleUIAnimationClip(ref UIAnimationClip value); // 0x0000000182551430-0x0000000182551460
		private static StyleUIAnimationClip ConvertStyleKeywordToStyleUIAnimationClip(ref StyleKeyword value); // 0x0000000182551C00-0x0000000182551C30
		private static EditorTextRenderingMode ConvertStyleEditorTextRenderingModeEnumToEditorTextRenderingMode(ref StyleEnum<EditorTextRenderingMode> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertEditorTextRenderingModeToStyleKeyword(ref StyleEnum<EditorTextRenderingMode> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<EditorTextRenderingMode> ConvertEditorTextRenderingModeToStyleEditorTextRenderingModeEnum(ref EditorTextRenderingMode value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<EditorTextRenderingMode> ConvertStyleKeywordToStyleEditorTextRenderingModeEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Font ConvertStyleFontToFont(ref StyleFont value); // 0x00000001825516D0-0x00000001825516E0
		private static StyleKeyword ConvertFontToStyleKeyword(ref StyleFont value); // 0x0000000180732D20-0x0000000180732D30
		private static StyleFont ConvertFontToStyleFont(ref Font value); // 0x0000000182551430-0x0000000182551460
		private static StyleFont ConvertStyleKeywordToStyleFont(ref StyleKeyword value); // 0x0000000182551C00-0x0000000182551C30
		private static FontDefinition ConvertStyleFontDefinitionToFontDefinition(ref StyleFontDefinition value); // 0x00000001825519E0-0x0000000182551A10
		private static StyleKeyword ConvertFontDefinitionToStyleKeyword(ref StyleFontDefinition value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleFontDefinition ConvertFontDefinitionToStyleFontDefinition(ref FontDefinition value); // 0x00000001825513C0-0x0000000182551400
		private static StyleFontDefinition ConvertStyleKeywordToStyleFontDefinition(ref StyleKeyword value); // 0x0000000182551BC0-0x0000000182551C00
		private static FontStyle ConvertStyleFontStyleEnumToFontStyle(ref StyleEnum<FontStyle> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertFontStyleToStyleKeyword(ref StyleEnum<FontStyle> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<FontStyle> ConvertFontStyleToStyleFontStyleEnum(ref FontStyle value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<FontStyle> ConvertStyleKeywordToStyleFontStyleEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static MaterialDefinition ConvertStyleMaterialDefinitionToMaterialDefinition(ref StyleMaterialDefinition value); // 0x0000000182551920-0x0000000182551950
		private static StyleKeyword ConvertMaterialDefinitionToStyleKeyword(ref StyleMaterialDefinition value); // 0x00000001802E64B0-0x00000001802E64C0
		private static StyleMaterialDefinition ConvertMaterialDefinitionToStyleMaterialDefinition(ref MaterialDefinition value); // 0x00000001825514E0-0x0000000182551520
		private static StyleMaterialDefinition ConvertStyleKeywordToStyleMaterialDefinition(ref StyleKeyword value); // 0x0000000182551C60-0x0000000182551CA0
		private static OverflowClipBox ConvertStyleOverflowClipBoxEnumToOverflowClipBox(ref StyleEnum<OverflowClipBox> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertOverflowClipBoxToStyleKeyword(ref StyleEnum<OverflowClipBox> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<OverflowClipBox> ConvertOverflowClipBoxToStyleOverflowClipBoxEnum(ref OverflowClipBox value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<OverflowClipBox> ConvertStyleKeywordToStyleOverflowClipBoxEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static int ConvertStyleIntToInt(ref StyleInt value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertIntToStyleKeyword(ref StyleInt value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleInt ConvertIntToStyleInt(ref int value); // 0x0000000182551070-0x0000000182551080
		private static StyleInt ConvertStyleKeywordToStyleInt(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static SliceType ConvertStyleSliceTypeEnumToSliceType(ref StyleEnum<SliceType> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertSliceTypeToStyleKeyword(ref StyleEnum<SliceType> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<SliceType> ConvertSliceTypeToStyleSliceTypeEnum(ref SliceType value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<SliceType> ConvertStyleKeywordToStyleSliceTypeEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static TextAnchor ConvertStyleTextAnchorEnumToTextAnchor(ref StyleEnum<TextAnchor> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertTextAnchorToStyleKeyword(ref StyleEnum<TextAnchor> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<TextAnchor> ConvertTextAnchorToStyleTextAnchorEnum(ref TextAnchor value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<TextAnchor> ConvertStyleKeywordToStyleTextAnchorEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static TextAutoSize ConvertStyleTextAutoSizeToTextAutoSize(ref StyleTextAutoSize value); // 0x0000000182551E60-0x0000000182551E90
		private static StyleKeyword ConvertTextAutoSizeToStyleKeyword(ref StyleTextAutoSize value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleTextAutoSize ConvertTextAutoSizeToStyleTextAutoSize(ref TextAutoSize value); // 0x0000000182551F30-0x0000000182551F80
		private static StyleTextAutoSize ConvertStyleKeywordToStyleTextAutoSize(ref StyleKeyword value); // 0x0000000182551CF0-0x0000000182551D30
		private static TextGeneratorType ConvertStyleTextGeneratorTypeEnumToTextGeneratorType(ref StyleEnum<TextGeneratorType> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertTextGeneratorTypeToStyleKeyword(ref StyleEnum<TextGeneratorType> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<TextGeneratorType> ConvertTextGeneratorTypeToStyleTextGeneratorTypeEnum(ref TextGeneratorType value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<TextGeneratorType> ConvertStyleKeywordToStyleTextGeneratorTypeEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static TextOverflowPosition ConvertStyleTextOverflowPositionEnumToTextOverflowPosition(ref StyleEnum<TextOverflowPosition> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertTextOverflowPositionToStyleKeyword(ref StyleEnum<TextOverflowPosition> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<TextOverflowPosition> ConvertTextOverflowPositionToStyleTextOverflowPositionEnum(ref TextOverflowPosition value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<TextOverflowPosition> ConvertStyleKeywordToStyleTextOverflowPositionEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static Visibility ConvertStyleVisibilityEnumToVisibility(ref StyleEnum<Visibility> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertVisibilityToStyleKeyword(ref StyleEnum<Visibility> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<Visibility> ConvertVisibilityToStyleVisibilityEnum(ref Visibility value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<Visibility> ConvertStyleKeywordToStyleVisibilityEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static WhiteSpace ConvertStyleWhiteSpaceEnumToWhiteSpace(ref StyleEnum<WhiteSpace> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleKeyword ConvertWhiteSpaceToStyleKeyword(ref StyleEnum<WhiteSpace> value); // 0x00000001802E7C60-0x00000001802E7DA0
		private static StyleEnum<WhiteSpace> ConvertWhiteSpaceToStyleWhiteSpaceEnum(ref WhiteSpace value); // 0x0000000182551070-0x0000000182551080
		private static StyleEnum<WhiteSpace> ConvertStyleKeywordToStyleWhiteSpaceEnum(ref StyleKeyword value); // 0x0000000182551A30-0x0000000182551A40
		private static void RegisterBuiltInStyleConverters(); // 0x0000000182553390-0x000000018255A860
		private static Overflow ConvertOverflowInternalToOverflow(ref OverflowInternal value); // 0x0000000180732D10-0x0000000180732D20
		private static StyleEnum<Overflow> ConvertOverflowInternalToStyleOverflow(ref OverflowInternal value); // 0x0000000182551070-0x0000000182551080
		private static OverflowInternal ConvertOverflowToOverflowInternal(ref Overflow value); // 0x0000000180732D10-0x0000000180732D20
		private static OverflowInternal ConvertStyleOverflowToOverflowInternal(ref StyleEnum<Overflow> value); // 0x0000000182551690-0x00000001825516A0
		private static StyleColor ConvertColor32ToStyleColor(ref Color32 value); // 0x00000001825511C0-0x0000000182551260
		private static Color32 ConvertStyleColorToColor32(ref StyleColor value); // 0x0000000182551810-0x0000000182551920
		private static StyleRatio ConvertStyleRatioToFloat(ref float v); // 0x0000000182551DB0-0x0000000182551DF0
		private static float ConvertFloatToStyleRatio(ref StyleRatio sv); // 0x0000000182551370-0x0000000182551390
		private static StyleBackground ConvertTexture2DToStyleBackground(ref Texture2D source); // 0x0000000182551FD0-0x0000000182552060
		private static StyleBackground ConvertSpriteToStyleBackground(ref Sprite source); // 0x0000000182551600-0x0000000182551690
		private static StyleBackground ConvertVectorImageToStyleBackground(ref VectorImage source); // 0x0000000182552060-0x00000001825520F0
		private static StyleBackground ConvertRenderTextureToStyleBackground(ref RenderTexture source); // 0x0000000182551520-0x00000001825515B0
		private static Texture2D ConvertStyleBackgroundToTexture2D(ref StyleBackground source); // 0x00000001825517B0-0x00000001825517E0
		private static Sprite ConvertStyleBackgroundToSprite(ref StyleBackground source); // 0x0000000182551780-0x00000001825517B0
		private static VectorImage ConvertStyleBackgroundToVectorImage(ref StyleBackground source); // 0x00000001825517E0-0x0000000182551810
		private static RenderTexture ConvertStyleBackgroundToRenderTexture(ref StyleBackground source); // 0x0000000182551750-0x0000000182551780
		private static float ConvertStyleLengthToFloat(ref StyleLength source); // 0x0000000182551D60-0x0000000182551D80
		private static int ConvertStyleLengthToInt(ref StyleLength source); // 0x0000000182551D80-0x0000000182551DA0
		private static StyleLength ConvertFloatToStyleLength(ref float source); // 0x0000000182551330-0x0000000182551370
		private static StyleLength ConvertIntToStyleLength(ref int source); // 0x0000000182551470-0x00000001825514B0
		private static int ConvertStyleFloatToInt(ref StyleFloat source); // 0x00000001825519A0-0x00000001825519C0
		private static StyleFloat ConvertIntToStyleFloat(ref int source); // 0x0000000182551460-0x0000000182551470
		private static StyleFontDefinition ConvertFontToStyleFontDefinition(ref Font source); // 0x0000000182551400-0x0000000182551430
		private static StyleFontDefinition ConvertFontAssetToStyleFontDefinition(ref FontAsset source); // 0x0000000182551390-0x00000001825513C0
		private static Font ConvertStyleFontDefinitionToFont(ref StyleFontDefinition source); // 0x0000000182551A10-0x0000000182551A30
		private static FontAsset ConvertStyleFontDefinitionToFontAsset(ref StyleFontDefinition source); // 0x00000001825519C0-0x00000001825519E0
		public static void Register(); // 0x000000018255A860-0x000000018255A880
		private static void RegisterAdditionalConverters(); // 0x00000001825520F0-0x0000000182553390
	}
}
