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
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class StylePropertyReader // TypeDefIndex: 5246
	{
		// Fields
		internal static GetCursorIdFunction getCursorIdFunc; // 0x00
		private static bool s_WarnedCircleCoerce; // 0x08
		private static bool s_WarnedRadialPositionUnit; // 0x09
		private static bool s_WarnedPixelStopPosition; // 0x0A
		private List<StylePropertyValue> m_Values; // 0x10
		private List<int> m_ValueCount; // 0x18
		private StyleVariableResolver m_Resolver; // 0x20
		private StyleSheet m_Sheet; // 0x28
		private StyleProperty[] m_Properties; // 0x30
		[CompilerGenerated]
		private int _m_CurrentValueIndex_k__BackingField; // 0x38
		private int m_CurrentPropertyIndex; // 0x3C
		[CompilerGenerated]
		private StyleProperty _property_k__BackingField; // 0x40
		[CompilerGenerated]
		private StylePropertyId _propertyId_k__BackingField; // 0x48
		[CompilerGenerated]
		private int _valueCount_k__BackingField; // 0x4C
		[CompilerGenerated]
		private float _dpiScaling_k__BackingField; // 0x50
	
		// Properties
		private int m_CurrentValueIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		public StyleProperty property { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public StylePropertyId propertyId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public int valueCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1B0-0x000000018033D1C0 0x000000018033E790-0x000000018033E7A0
		public float dpiScaling { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x0000000182141FC0-0x0000000182141FD0
	
		// Nested types
		internal delegate int GetCursorIdFunction(StyleSheet sheet, StyleValueHandle handle); // TypeDefIndex: 5247; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Constructors
		public StylePropertyReader(); // 0x000000018245E640-0x000000018245E740
	
		// Methods
		public void SetContext(StyleSheet sheet, StyleComplexSelector selector, StyleVariableContext varContext, float dpiScaling = 1f /* Metadata: 0x00660BFB */); // 0x000000018245D6A0-0x000000018245D730
		public void SetInlineContext(StyleSheet sheet, StyleProperty[] properties, StyleVariableContext varContext, float dpiScaling = 1f /* Metadata: 0x00660BFF */); // 0x000000018245D7D0-0x000000018245D850
		public StylePropertyId MoveNextProperty(); // 0x00000001824578B0-0x00000001824578E0
		public StylePropertyValue GetValue(int index); // 0x0000000182457440-0x0000000182457480
		public StyleValueType GetValueType(int index); // 0x0000000182457410-0x0000000182457440
		public bool IsValueType(int index, StyleValueType type); // 0x00000001824574E0-0x0000000182457520
		public bool IsKeyword(int index, StyleValueKeyword keyword); // 0x0000000182457480-0x00000001824574E0
		public string ReadAsString(int index); // 0x0000000182457F80-0x0000000182457FD0
		public Length ReadLength(int index); // 0x000000018245A4F0-0x000000018245A5C0
		public TimeValue ReadTimeValue(int index); // 0x000000018245CBD0-0x000000018245CC50
		public Translate ReadTranslate(int index); // 0x000000018245D200-0x000000018245D320
		public TransformOrigin ReadTransformOrigin(int index); // 0x000000018245CE30-0x000000018245D070
		public Rotate ReadRotate(int index); // 0x000000018245BE40-0x000000018245BFC0
		public Scale ReadScale(int index); // 0x000000018245C150-0x000000018245C3A0
		public float ReadFloat(int index); // 0x0000000182459EC0-0x0000000182459F10
		public int ReadInt(int index); // 0x000000018245A4A0-0x000000018245A4F0
		public Color ReadColor(int index); // 0x00000001824598E0-0x0000000182459940
		public int ReadEnum(StyleEnumType enumType, int index); // 0x0000000182459DE0-0x0000000182459EC0
		public UnityEngine.Object ReadAsset(int index); // 0x0000000182457FD0-0x00000001824580B0
		public EntityId ReadFontDefinition(int index); // 0x0000000182459F10-0x000000018245A3F0
		public EntityId ReadFont(int index); // 0x000000018245A3F0-0x000000018245A4A0
		public EntityId ReadUIAnimationClip(int index); // 0x000000018245D5F0-0x000000018245D6A0
		private T ReadAssetObject<T>(int index)
			where T : UnityEngine.Object;
		public void ReadMaterialDefinition(ref UnmanagedMaterialDefinition data, int index); // 0x000000018245B600-0x000000018245B680
		public void ReadBackground(ref UnmanagedBackground target, int index); // 0x0000000182458DF0-0x0000000182459210
		public UnityEngine.UIElements.Cursor ReadCursor(int index); // 0x0000000182459940-0x0000000182459BB0
		public TextShadow ReadTextShadow(int index); // 0x000000018245CA50-0x000000018245CBD0
		public TextAutoSize ReadTextAutoSize(int index); // 0x000000018245C5B0-0x000000018245C6D0
		public BackgroundPosition ReadBackgroundPositionX(int index); // 0x0000000182458210-0x0000000182458250
		public BackgroundPosition ReadBackgroundPositionY(int index); // 0x0000000182458250-0x0000000182458290
		private BackgroundPosition ReadBackgroundPosition(int index, BackgroundPositionKeyword keyword); // 0x0000000182458290-0x0000000182458370
		public BackgroundRepeat ReadBackgroundRepeat(int index); // 0x0000000182458680-0x0000000182458720
		public BackgroundSize ReadBackgroundSize(int index); // 0x00000001824589F0-0x0000000182458AC0
		private BackgroundGradient ReadBackgroundGradient(int index); // 0x00000001824580B0-0x0000000182458210
		private BackgroundGradient ParseLinearGradient(ref int cursor, int argsEnd); // 0x00000001824578E0-0x0000000182457BC0
		private BackgroundGradient ParseRadialGradient(ref int cursor, int argsEnd); // 0x0000000182457BC0-0x0000000182457E60
		private BackgroundGradientStop[] ReadColorStops(ref int cursor, int argsEnd); // 0x0000000182459210-0x00000001824598E0
		private Vector2 ReadRadialPosition(ref int cursor, int argsEnd); // 0x000000018245B680-0x000000018245B900
		private static bool TryReadAngle(StylePropertyValue value, out float radians); // 0x000000018245E390-0x000000018245E4D0
		private static bool TryGetSideAngle(string sideKeyword, out float radians); // 0x000000018245E260-0x000000018245E390
		private static float AverageAngles(float a, float b); // 0x00000001824573B0-0x0000000182457410
		private static bool TryGetRadialExtent(string kw, out BackgroundGradientSize size); // 0x000000018245E130-0x000000018245E260
		private static bool TryGetPositionFraction(string kw, out float fracX, out float fracY); // 0x000000018245DFC0-0x000000018245E130
		private bool TryReadStopColor(StylePropertyValue value, out Color color); // 0x000000018245E570-0x000000018245E640
		public void ReadListEasingFunction(ref UnmanagedRefCountedList<EasingFunction> result, int index); // 0x000000018245A5C0-0x000000018245A7F0
		public void ReadListTimeValue(ref UnmanagedRefCountedList<TimeValue> result, int index); // 0x000000018245AA20-0x000000018245AC10
		public void ReadListUnmanagedFilterFunction(ref UnmanagedRefCountedList<UnmanagedFilterFunction> result, int index); // 0x000000018245AC10-0x000000018245B600
		public void ReadListStylePropertyId(ref UnmanagedRefCountedList<StylePropertyId> result, int index); // 0x000000018245A7F0-0x000000018245AA20
		public StyleRatio ReadRatio(int index); // 0x000000018245B900-0x000000018245BBE0
		private void LoadProperties(); // 0x0000000182457520-0x00000001824578B0
		private void SetCurrentProperty(); // 0x000000018245D730-0x000000018245D7D0
		public static TransformOrigin ReadTransformOrigin(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue zVvalue); // 0x000000018245D070-0x000000018245D200
		private static Length ReadTransformOriginEnum(StylePropertyValue value, out bool isVertical, out bool isHorizontal); // 0x000000018245CC50-0x000000018245CE30
		public static Translate ReadTranslate(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3); // 0x000000018245D320-0x000000018245D5F0
		public static Scale ReadScale(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3); // 0x000000018245BFC0-0x000000018245C150
		public static Rotate ReadRotate(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3, StylePropertyValue val4); // 0x000000018245BBE0-0x000000018245BE40
		private static bool TryReadEnum(StyleEnumType enumType, StylePropertyValue value, out int intValue); // 0x000000018245E4D0-0x000000018245E570
		private static int ReadEnum(StyleEnumType enumType, StylePropertyValue value); // 0x0000000182459D40-0x0000000182459DE0
		public static Angle ReadAngle(StylePropertyValue value); // 0x0000000182457E60-0x0000000182457F80
		public static BackgroundPosition ReadBackgroundPosition(int valCount, StylePropertyValue val1, StylePropertyValue val2, BackgroundPositionKeyword keyword); // 0x0000000182458370-0x0000000182458680
		public static BackgroundRepeat ReadBackgroundRepeat(int valCount, StylePropertyValue val1, StylePropertyValue val2); // 0x0000000182458720-0x00000001824589F0
		public static BackgroundSize ReadBackgroundSize(int valCount, StylePropertyValue val1, StylePropertyValue val2); // 0x0000000182458AC0-0x0000000182458DF0
		public static TextShadow ReadTextShadow(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3, StylePropertyValue val4); // 0x000000018245C6D0-0x000000018245CA50
		public static TextAutoSize ReadTextAutoSize(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3); // 0x000000018245C3A0-0x000000018245C5B0
		internal static UnityEngine.UIElements.Cursor ReadCursor(int valueCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3, float dpiScaling = 1f /* Metadata: 0x00660C03 */); // 0x0000000182459BB0-0x0000000182459D40
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal static bool TryGetImageSourceFromValue(StylePropertyValue propertyValue, float dpiScaling, out ImageSource source); // 0x000000018245D850-0x000000018245DFC0
	}
}
