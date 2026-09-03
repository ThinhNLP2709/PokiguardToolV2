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
	[Serializable]
	[HelpURL("UIE-USS")]
	public class StyleSheet : ScriptableObject // TypeDefIndex: 4803
	{
		// Fields
		[NonSerialized]
		private bool m_RequiresRebuild; // 0x18
		[SerializeField]
		private bool m_ImportedWithErrors; // 0x19
		[SerializeField]
		private bool m_ImportedWithWarnings; // 0x1A
		[SerializeField]
		private StyleRule[] m_Rules; // 0x20
		[SerializeField]
		internal ResourcePath[] resourcePaths; // 0x28
		[SerializeField]
		internal float[] floats; // 0x30
		[SerializeField]
		internal Dimension[] dimensions; // 0x38
		[SerializeField]
		internal Color[] colors; // 0x40
		[SerializeField]
		internal string[] strings; // 0x48
		[NonSerialized]
		private int[] variableNameIds; // 0x50
		[SerializeField]
		internal UnityEngine.Object[] assets; // 0x58
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal ImportStruct[] imports; // 0x60
		[SerializeField]
		private List<StyleSheet> m_FlattenedImportedStyleSheets; // 0x68
		[SerializeField]
		private int m_ContentHash; // 0x70
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIElementsModule" })]
		internal const string k_SerializationLayoutDependencyKey = "uitk/serialization-layout"; // Metadata: 0x006607BD
		[SerializeField]
		private int m_SerializationLayoutHash; // 0x74
		[NonSerialized]
		private bool m_SerializationLayoutChecked; // 0x78
		[SerializeField]
		internal ScalableImage[] scalableImages; // 0x80
		[NonSerialized]
		private bool m_IsDefaultStyleSheet; // 0x88
	
		// Properties
		public bool importedWithErrors { get; internal set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
		public bool importedWithWarnings { get; internal set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181780E20-0x0000000181780E30
		internal StyleRule[] rules { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x00000001802F8630-0x00000001802F8640 
		internal List<StyleSheet> flattenedRecursiveImports { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x0000000180316960-0x0000000180316970 
		public int contentHash { get; set; } // 0x0000000180CC2260-0x0000000180CC2270 0x0000000180CC2270-0x0000000180CC2280
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIElementsModule" })]
		internal static int currentSerializationLayoutHash { get; } // 0x000000018256D270-0x000000018256D280 
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIElementsModule" })]
		internal int serializationLayoutHash { get; set; } // 0x0000000181974810-0x0000000181974820 0x000000018198E760-0x000000018198E770
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal bool isDefaultStyleSheet { get; set; } // 0x00000001803B5710-0x00000001803B5720 0x000000018256D280-0x000000018256D360
	
		// Nested types
		[Flags]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal enum RebuildOptions // TypeDefIndex: 4804
		{
			None = 0,
			Synchronous = 1
		}
	
		[Serializable]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal struct ImportStruct // TypeDefIndex: 4805
		{
			// Fields
			public StyleSheet styleSheet; // 0x00
			public string[] mediaQueries; // 0x08
		}
	
		// Constructors
		public StyleSheet(); // 0x000000018256CE90-0x000000018256D270
	
		// Methods
		private bool TryCheckAccess<T>(T[] list, StyleValueType type, StyleValueHandle handle, out ref T value);
		private T CheckAccess<T>(T[] list, StyleValueType type, StyleValueHandle handle);
		internal virtual void OnEnable(); // 0x000000018256A700-0x000000018256A760
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIElementsModule" })]
		internal void EnsureSerializationLayoutChecked(); // 0x000000018256A3A0-0x000000018256A3C0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIElementsModule" })]
		internal void CheckSerializationLayout(); // 0x000000018256A1C0-0x000000018256A3A0
		internal virtual void OnDisable(); // 0x000000018256A6B0-0x000000018256A700
		internal void FlattenImportedStyleSheetsRecursive(); // 0x000000018256A4F0-0x000000018256A570
		private void FlattenImportedStyleSheetsRecursive(StyleSheet sheet); // 0x000000018256A3C0-0x000000018256A4F0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleRule AddRule(); // 0x0000000182569E80-0x0000000182569E90
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleRule AddRuleAtIndex(int index); // 0x0000000182569E70-0x0000000182569E80
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal StyleRule AddRule(string selector); // 0x0000000182569E90-0x0000000182569EA0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleRule AddRuleAtIndex(int index, string selector); // 0x0000000182569CB0-0x0000000182569E70
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal bool RemoveRule(StyleRule rule); // 0x000000018256B200-0x000000018256B380
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void RemoveRule(int ruleIndex); // 0x000000018256B100-0x000000018256B200
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void SetRules(StyleRule[] newRules); // 0x000000018256B3C0-0x000000018256B3F0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleSheet GetStyleSheetImportAtIndex(int index); // 0x000000018256A570-0x000000018256A600
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SetStyleSheetImportAtIndex(int index, StyleSheet styleSheet); // 0x000000018256B3F0-0x000000018256B4B0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void AddImportAtIndex(int index, ImportStruct import); // 0x0000000182569C20-0x0000000182569CB0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void RemoveImport(int index); // 0x000000018256B000-0x000000018256B100
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void RequestRebuild(RebuildOptions options = RebuildOptions.None /* Metadata: 0x006607BC */); // 0x000000018256B380-0x000000018256B3C0
		internal void RebuildIfNecessary(); // 0x000000018256AFF0-0x000000018256B000
		internal void SetupReferences(); // 0x000000018256B4B0-0x000000018256B980
		private int AddValueToArray<T>(ref ref T[] array, T value);
		private int InsertValueInArray<T>(ref ref T[] array, int index, T value);
		internal int AddValue(StyleValueKeyword keyword); // 0x0000000182569FC0-0x0000000182569FE0
		internal int AddValue(StyleValueFunction function); // 0x0000000182569FC0-0x0000000182569FE0
		internal int AddValue(float value); // 0x0000000182569FE0-0x000000018256A030
		internal int AddValue(Dimension value); // 0x000000018256A170-0x000000018256A1C0
		internal int AddValue(Color value); // 0x000000018256A030-0x000000018256A090
		internal int AddValue(ScalableImage value); // 0x000000018256A110-0x000000018256A170
		internal int AddValue(string value); // 0x000000018256A0C0-0x000000018256A110
		internal int AddValue(ResourcePath value); // 0x0000000182569EF0-0x0000000182569F40
		internal int AddValue(ResolvedResourcePath value); // 0x000000018256A090-0x000000018256A0C0
		internal int AddValue(UnityEngine.Object value); // 0x0000000182569EA0-0x0000000182569EF0
		internal int AddValue(Enum value); // 0x0000000182569F40-0x0000000182569FC0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleValueKeyword ReadKeyword(StyleValueHandle handle); // 0x00000001805ABD30-0x00000001805ABD40
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool TryReadKeyword(StyleValueHandle handle, out StyleValueKeyword value); // 0x000000018256BD20-0x000000018256BD40
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal float ReadFloat(StyleValueHandle handle); // 0x000000018256A9F0-0x000000018256AA40
		internal bool TryReadFloat(StyleValueHandle handle, out float value); // 0x000000018256BC60-0x000000018256BD00
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Dimension ReadDimension(StyleValueHandle handle); // 0x000000018256A960-0x000000018256A9C0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool TryReadDimension(StyleValueHandle handle, out Dimension value); // 0x000000018256BB70-0x000000018256BC30
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Color ReadColor(StyleValueHandle handle); // 0x000000018256A890-0x000000018256A960
		internal bool TryReadColor(StyleValueHandle handle, out Color value); // 0x000000018256BA80-0x000000018256BB70
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal string ReadString(StyleValueHandle handle); // 0x000000018256AE70-0x000000018256AEA0
		internal bool TryReadString(StyleValueHandle handle, out string value); // 0x000000018256BFF0-0x000000018256C020
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal string ReadEnum(StyleValueHandle handle); // 0x000000018256A9C0-0x000000018256A9F0
		internal bool TryReadEnum(StyleValueHandle handle, out string value); // 0x000000018256BC30-0x000000018256BC60
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal TEnum ReadEnum<TEnum>(StyleValueHandle handle)
			where TEnum : struct, Enum;
		internal bool TryReadEnum<TEnum>(StyleValueHandle handle, out ref TEnum value)
			where TEnum : struct, Enum;
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal string ReadVariable(StyleValueHandle handle); // 0x000000018256AFC0-0x000000018256AFF0
		internal int ReadVariableId(StyleValueHandle handle); // 0x000000018256AF80-0x000000018256AFC0
		internal bool TryReadVariable(StyleValueHandle handle, out string value); // 0x000000018256C100-0x000000018256C130
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal ResolvedResourcePath ReadResourcePath(StyleValueHandle handle); // 0x000000018256AD70-0x000000018256AE30
		internal bool TryReadResourcePath(StyleValueHandle handle, out ResolvedResourcePath value); // 0x000000018256BEF0-0x000000018256BFC0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal UnityEngine.Object ReadAssetReference(StyleValueHandle handle); // 0x000000018256A860-0x000000018256A890
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal string ReadMissingAssetReferenceUrl(StyleValueHandle handle); // 0x000000018256AC40-0x000000018256AC70
		internal bool TryReadMissingAssetReferenceUrl(StyleValueHandle handle, out string value); // 0x000000018256BDD0-0x000000018256BE00
		internal bool TryReadAssetReference(StyleValueHandle handle, out UnityEngine.Object value); // 0x000000018256BA50-0x000000018256BA80
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal StyleValueFunction ReadFunction(StyleValueHandle handle); // 0x00000001805ABD30-0x00000001805ABD40
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool TryReadFunction(StyleValueHandle handle, out StyleValueFunction value); // 0x000000018256BD00-0x000000018256BD20
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal string ReadFunctionName(StyleValueHandle handle); // 0x000000018256AA40-0x000000018256AB80
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal ScalableImage ReadScalableImage(StyleValueHandle handle); // 0x000000018256AE30-0x000000018256AE70
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool TryReadScalableImage(StyleValueHandle handle, out ScalableImage value); // 0x000000018256BFC0-0x000000018256BFF0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal StylePropertyName ReadStylePropertyName(StyleValueHandle handle); // 0x000000018256AEA0-0x000000018256AEF0
		internal bool TryReadStylePropertyName(StyleValueHandle handle, out StylePropertyName value); // 0x000000018256C020-0x000000018256C0A0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Length ReadLength(StyleValueHandle handle); // 0x000000018256AB80-0x000000018256AC40
		internal bool TryReadLength(StyleValueHandle handle, out Length value); // 0x000000018256BD40-0x000000018256BDD0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Angle ReadAngle(StyleValueHandle handle); // 0x000000018256A760-0x000000018256A860
		internal bool TryReadAngle(StyleValueHandle handle, out Angle value); // 0x000000018256B980-0x000000018256BA50
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal TimeValue ReadTimeValue(StyleValueHandle handle); // 0x000000018256AEF0-0x000000018256AF80
		internal bool TryReadTimeValue(StyleValueHandle handle, out TimeValue value); // 0x000000018256C0A0-0x000000018256C100
		internal Ratio ReadRatio(StyleValueHandle handle); // 0x000000018256AC70-0x000000018256AD70
		internal bool TryReadRatio(StyleValueHandle handle, out Ratio ratio); // 0x000000018256BE00-0x000000018256BEF0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteKeyword(ref StyleValueHandle handle, StyleValueKeyword value); // 0x000000018256C630-0x000000018256C650
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteFloat(ref StyleValueHandle handle, float value); // 0x000000018256C570-0x000000018256C610
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteDimension(ref StyleValueHandle handle, Dimension dimension); // 0x000000018256C420-0x000000018256C4C0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteColor(ref StyleValueHandle handle, Color color); // 0x000000018256C360-0x000000018256C410
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteString(ref StyleValueHandle handle, string value); // 0x000000018256CBD0-0x000000018256CC80
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteEnum<TEnum>(ref StyleValueHandle handle, TEnum value)
			where TEnum : Enum;
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteEnumAsString(ref StyleValueHandle handle, string valueStr); // 0x000000018256C4C0-0x000000018256C570
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteVariable(ref StyleValueHandle handle, string variableName); // 0x000000018256CDE0-0x000000018256CE90
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteResourcePath(ref StyleValueHandle handle, ResolvedResourcePath resolvedResource); // 0x000000018256C910-0x000000018256CB00
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteAssetReference(ref StyleValueHandle handle, UnityEngine.Object value); // 0x000000018256C270-0x000000018256C360
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteMissingAssetReferenceUrl(ref StyleValueHandle handle, string assetReference); // 0x000000018256C7A0-0x000000018256C850
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteFunction(ref StyleValueHandle handle, StyleValueFunction function); // 0x000000018256C610-0x000000018256C630
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteScalableImage(ref StyleValueHandle handle, ScalableImage scalableImage); // 0x000000018256CB00-0x000000018256CBD0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteStylePropertyName(ref StyleValueHandle handle, StylePropertyName propertyName); // 0x000000018256CC80-0x000000018256CD60
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void WriteCommaSeparator(ref StyleValueHandle handle); // 0x000000018256C410-0x000000018256C420
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteLength(ref StyleValueHandle handle, Length value); // 0x000000018256C650-0x000000018256C7A0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteAngle(ref StyleValueHandle handle, Angle value); // 0x000000018256C130-0x000000018256C270
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void WriteTimeValue(ref StyleValueHandle handle, TimeValue value); // 0x000000018256CD60-0x000000018256CDE0
		internal void WriteRatio(ref StyleValueHandle handle, Ratio value); // 0x000000018256C850-0x000000018256C910
		private void OnApplyUndoRedoINTERNAL(); // 0x000000018256A680-0x000000018256A6B0
		internal void MarkAsChanged(); // 0x000000018256A600-0x000000018256A680
	}
}
