/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore;

// Image 50: UnityEngine.TextCoreFontEngineModule.dll - Assembly: UnityEngine.TextCoreFontEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15505-15532

namespace UnityEngine.TextCore.LowLevel
{
	[NativeHeader("Modules/TextCoreFontEngine/Native/FontEngine.h")]
	public sealed class FontEngine // TypeDefIndex: 15519
	{
		// Fields
		private static Glyph[] s_Glyphs; // 0x00
		private static uint[] s_GlyphIndexes_MarshallingArray_A; // 0x08
		private static GlyphMarshallingStruct[] s_GlyphMarshallingStruct_IN; // 0x10
		private static GlyphMarshallingStruct[] s_GlyphMarshallingStruct_OUT; // 0x18
		private static GlyphRect[] s_FreeGlyphRects; // 0x20
		private static GlyphRect[] s_UsedGlyphRects; // 0x28
		private static LigatureSubstitutionRecord[] s_LigatureSubstitutionRecords_MarshallingArray; // 0x30
		private static GlyphPairAdjustmentRecord[] s_PairAdjustmentRecords_MarshallingArray; // 0x38
		private static MarkToBaseAdjustmentRecord[] s_MarkToBaseAdjustmentRecords_MarshallingArray; // 0x40
		private static MarkToMarkAdjustmentRecord[] s_MarkToMarkAdjustmentRecords_MarshallingArray; // 0x48
		private static Dictionary<uint, Glyph> s_GlyphLookupDictionary; // 0x50
		private static readonly ProfilerMarker s_TryAddGlyphsToTextureMarker; // 0x58
	
		// Constructors
		static FontEngine(); // 0x00000001822F34A0-0x00000001822F36C0
	
		// Methods
		public static FontEngineError LoadFontFace(string filePath); // 0x00000001822F0CA0-0x00000001822F0CF0
		[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
		private static int LoadFontFace_Internal(string filePath); // 0x00000001822F01B0-0x00000001822F0340
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static FontEngineError LoadFontFace(string filePath, float pointSize, int faceIndex, out FontFaceHandle faceHandle); // 0x00000001822F0BA0-0x00000001822F0CA0
		[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
		private static int LoadFontFace_With_Size_And_FaceIndex_FontFaceHandle_Internal(string filePath, int pointSize, int faceIndex, out FontFaceHandle faceHandle); // 0x00000001822F03A0-0x00000001822F0540
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static FontEngineError LoadFontFace(Font font, float pointSize, int faceIndex, out FontFaceHandle faceHandle); // 0x00000001822F0940-0x00000001822F0AA0
		[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
		private static int LoadFontFace_With_Size_and_FaceIndex_FromFont_FontFaceHandle_Internal(Font font, int pointSize, int faceIndex, out FontFaceHandle faceHandle); // 0x00000001822F05A0-0x00000001822F0640
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static FontEngineError LoadFontFace(string familyName, string styleName, float pointSize, out FontFaceHandle faceHandle); // 0x00000001822F0AA0-0x00000001822F0BA0
		[NativeMethod(Name = "TextCore::FontEngine::LoadFontFace", IsFreeFunction = true)]
		private static int LoadFontFace_With_Size_by_FamilyName_and_StyleName_FontFaceHandle_Internal(string familyName, string styleName, int pointSize, out FontFaceHandle faceHandle); // 0x00000001822F06B0-0x00000001822F0940
		public static FontEngineError UnloadFontFace(); // 0x00000001822F3440-0x00000001822F34A0
		[NativeMethod(Name = "TextCore::FontEngine::UnloadFontFace", IsFreeFunction = true)]
		private static int UnloadFontFace_Internal(); // 0x00000001822F3410-0x00000001822F3440
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static bool IsColorFontFace(FontFaceHandle faceHandle); // 0x00000001822F0100-0x00000001822F0170
		[NativeMethod(Name = "TextCore::FontEngine::IsColorFontFace", IsFreeFunction = true)]
		private static bool IsColorFontFace_FontFaceHandle_Internal(ref FontFaceHandle faceHandle); // 0x00000001822F00C0-0x00000001822F0100
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static bool TryGetSystemFontReference(string familyName, string styleName, out FontReference fontRef); // 0x00000001822F33A0-0x00000001822F3410
		[NativeMethod(Name = "TextCore::FontEngine::TryGetSystemFontReference", IsThreadSafe = true, IsFreeFunction = true)]
		private static bool TryGetSystemFontReference_Internal(string familyName, string styleName, out FontReference fontRef); // 0x00000001822F3120-0x00000001822F33A0
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static FaceInfo GetFaceInfo(FontFaceHandle faceHandle); // 0x00000001822EEB90-0x00000001822EEC20
		[NativeMethod(Name = "TextCore::FontEngine::GetFaceInfo", IsThreadSafe = true, IsFreeFunction = true)]
		private static int GetFaceInfo_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, ref FaceInfo faceInfo); // 0x00000001822EEB40-0x00000001822EEB90
		public static string[] GetFontFaces(); // 0x00000001822EEC50-0x00000001822EECC0
		[NativeMethod(Name = "TextCore::FontEngine::GetFontFaces", IsThreadSafe = true, IsFreeFunction = true)]
		private static string[] GetFontFaces_Internal(); // 0x00000001822EEC20-0x00000001822EEC50
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static uint GetVariantGlyphIndex(FontFaceHandle faceHandle, uint unicode, uint variantSelectorUnicode); // 0x00000001822EFF90-0x00000001822F0020
		[NativeMethod(Name = "TextCore::FontEngine::GetVariantGlyphIndex", IsThreadSafe = true, IsFreeFunction = true)]
		private static uint GetVariantGlyphIndex_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, uint unicode, uint variantSelectorUnicode); // 0x00000001822EFF40-0x00000001822EFF90
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static uint GetGlyphIndex(FontFaceHandle faceHandle, uint unicode); // 0x00000001822EED00-0x00000001822EED80
		[NativeMethod(Name = "TextCore::FontEngine::GetGlyphIndex", IsThreadSafe = true, IsFreeFunction = true)]
		private static uint GetGlyphIndex_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, uint unicode); // 0x00000001822EECC0-0x00000001822EED00
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static bool TryGetGlyphWithUnicodeValue(FontFaceHandle faceHandle, uint unicode, GlyphLoadFlags flags, out Glyph glyph); // 0x00000001822F2F10-0x00000001822F30C0
		[NativeMethod(Name = "TextCore::FontEngine::TryGetGlyphWithUnicodeValue", IsThreadSafe = true, IsFreeFunction = true)]
		private static bool TryGetGlyphWithUnicodeValue_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, uint unicode, GlyphLoadFlags loadFlags, ref GlyphMarshallingStruct glyphStruct); // 0x00000001822F2EB0-0x00000001822F2F10
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static bool TryGetGlyphWithIndexValue(FontFaceHandle faceHandle, uint glyphIndex, GlyphLoadFlags flags, out Glyph glyph); // 0x00000001822F2D00-0x00000001822F2EB0
		[NativeMethod(Name = "TextCore::FontEngine::TryGetGlyphWithIndexValue", IsThreadSafe = true, IsFreeFunction = true)]
		private static bool TryGetGlyphWithIndexValue_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, uint glyphIndex, GlyphLoadFlags loadFlags, ref GlyphMarshallingStruct glyphStruct); // 0x00000001822F2CA0-0x00000001822F2D00
		[NativeMethod(Name = "TextCore::FontEngine::SetTextureUploadMode", IsThreadSafe = true, IsFreeFunction = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static void SetTextureUploadMode(bool shouldUploadImmediately); // 0x00000001822F13E0-0x00000001822F1420
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static bool TryAddGlyphToTexture(FontFaceHandle faceHandle, uint glyphIndex, int padding, GlyphPackingMode packingMode, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects, GlyphRenderMode renderMode, Texture2D texture, out Glyph glyph); // 0x00000001822F1660-0x00000001822F1CD0
		[NativeMethod(Name = "TextCore::FontEngine::TryAddGlyphToTexture", IsThreadSafe = true, IsFreeFunction = true)]
		private static bool TryAddGlyphToTexture_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, uint glyphIndex, int padding, GlyphPackingMode packingMode, out GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, out GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, Texture2D texture, out GlyphMarshallingStruct glyph); // 0x00000001822F1490-0x00000001822F1660
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static bool TryAddGlyphsToTexture(FontFaceHandle faceHandle, List<uint> glyphIndexes, int padding, GlyphPackingMode packingMode, List<GlyphRect> freeGlyphRects, List<GlyphRect> usedGlyphRects, GlyphRenderMode renderMode, Texture2D texture, out Glyph[] glyphs); // 0x00000001822F1F70-0x00000001822F2CA0
		[NativeMethod(Name = "TextCore::FontEngine::TryAddGlyphsToTexture", IsThreadSafe = true, IsFreeFunction = true)]
		private static bool TryAddGlyphsToTexture_FontFaceHandle_Internal(ref FontFaceHandle faceHandle, uint[] glyphIndex, int padding, GlyphPackingMode packingMode, out GlyphRect[] freeGlyphRects, ref int freeGlyphRectCount, out GlyphRect[] usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, Texture2D texture, [In, Out] GlyphMarshallingStruct[] glyphs, ref int glyphCount); // 0x00000001822F1D40-0x00000001822F1F70
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static LigatureSubstitutionRecord[] GetAllLigatureSubstitutionRecords(FontFaceHandle faceHandle); // 0x00000001822EE5F0-0x00000001822EE660
		[NativeMethod(Name = "TextCore::FontEngine::GetAllLigatureSubstitutionRecords", IsFreeFunction = true)]
		private static LigatureSubstitutionRecord[] GetAllLigatureSubstitutionRecords_FontFaceHandle_Internal(ref FontFaceHandle faceHandle); // 0x00000001822EE5B0-0x00000001822EE5F0
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(FontFaceHandle faceHandle, uint glyphIndex); // 0x00000001822EF020-0x00000001822EF130
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(FontFaceHandle faceHandle, List<uint> glyphIndexes); // 0x00000001822EF300-0x00000001822EF3A0
		private static LigatureSubstitutionRecord[] GetLigatureSubstitutionRecords(FontFaceHandle faceHandle, uint[] glyphIndexes); // 0x00000001822EF130-0x00000001822EF300
		[NativeMethod(Name = "TextCore::FontEngine::PopulateLigatureSubstitutionRecordMarshallingArray", IsFreeFunction = true)]
		private static int PopulateLigatureSubstitutionRecordMarshallingArray_FontFaceHandle(ref FontFaceHandle faceHandle, uint[] glyphIndexes, out int recordCount); // 0x00000001822F0D50-0x00000001822F0E30
		[NativeMethod(Name = "TextCore::FontEngine::GetLigatureSubstitutionRecordsFromMarshallingArray", IsFreeFunction = true)]
		private static int GetLigatureSubstitutionRecordsFromMarshallingArray(out LigatureSubstitutionRecord[] ligatureSubstitutionRecords); // 0x00000001822EEFE0-0x00000001822EF020
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static GlyphPairAdjustmentRecord[] GetGlyphPairAdjustmentTable(FontFaceHandle faceHandle, uint[] glyphIndexes); // 0x00000001822EED80-0x00000001822EEFE0
		[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArrayFromKernTable", IsFreeFunction = true)]
		private static int PopulatePairAdjustmentRecordMarshallingArray_from_KernTable_FontFaceHandle(ref FontFaceHandle faceHandle, uint[] glyphIndexes, out int recordCount); // 0x00000001822F1250-0x00000001822F1330
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static GlyphPairAdjustmentRecord[] GetAllPairAdjustmentRecords(FontFaceHandle faceHandle); // 0x00000001822EEAF0-0x00000001822EEB40
		[NativeMethod(Name = "TextCore::FontEngine::GetAllPairAdjustmentRecords", IsFreeFunction = true)]
		private static GlyphPairAdjustmentRecord[] GetAllPairAdjustmentRecords_FontFaceHandle_Internal(ref FontFaceHandle faceHandle); // 0x00000001822EE9F0-0x00000001822EEAF0
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(FontFaceHandle faceHandle, List<uint> glyphIndexes); // 0x00000001822EFEA0-0x00000001822EFF40
		private static GlyphPairAdjustmentRecord[] GetPairAdjustmentRecords(FontFaceHandle faceHandle, uint[] glyphIndexes); // 0x00000001822EFC40-0x00000001822EFEA0
		[NativeMethod(Name = "TextCore::FontEngine::PopulatePairAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
		private static int PopulatePairAdjustmentRecordMarshallingArray_FontFaceHandle(ref FontFaceHandle faceHandle, uint[] glyphIndexes, out int recordCount); // 0x00000001822F1110-0x00000001822F11F0
		[NativeMethod(Name = "TextCore::FontEngine::GetGlyphPairAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
		private static int GetPairAdjustmentRecordsFromMarshallingArray(Span<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords); // 0x00000001822EFBA0-0x00000001822EFC40
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static MarkToBaseAdjustmentRecord[] GetAllMarkToBaseAdjustmentRecords(FontFaceHandle faceHandle); // 0x00000001822EE7B0-0x00000001822EE800
		[NativeMethod(Name = "TextCore::FontEngine::GetAllMarkToBaseAdjustmentRecords", IsFreeFunction = true)]
		private static MarkToBaseAdjustmentRecord[] GetAllMarkToBaseAdjustmentRecords_FontFaceHandle_Internal(ref FontFaceHandle faceHandle); // 0x00000001822EE6B0-0x00000001822EE7B0
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(FontFaceHandle faceHandle, List<uint> glyphIndexes); // 0x00000001822EF480-0x00000001822EF520
		private static MarkToBaseAdjustmentRecord[] GetMarkToBaseAdjustmentRecords(FontFaceHandle faceHandle, uint[] glyphIndexes); // 0x00000001822EF520-0x00000001822EF780
		[NativeMethod(Name = "TextCore::FontEngine::PopulateMarkToBaseAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
		private static int PopulateMarkToBaseAdjustmentRecordMarshallingArray_FontFaceHandle(ref FontFaceHandle faceHandle, uint[] glyphIndexes, out int recordCount); // 0x00000001822F0E90-0x00000001822F0F70
		[NativeMethod(Name = "TextCore::FontEngine::GetMarkToBaseAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
		private static int GetMarkToBaseAdjustmentRecordsFromMarshallingArray(Span<MarkToBaseAdjustmentRecord> adjustmentRecords); // 0x00000001822EF3E0-0x00000001822EF480
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static MarkToMarkAdjustmentRecord[] GetAllMarkToMarkAdjustmentRecords(FontFaceHandle faceHandle); // 0x00000001822EE950-0x00000001822EE9A0
		[NativeMethod(Name = "TextCore::FontEngine::GetAllMarkToMarkAdjustmentRecords", IsFreeFunction = true)]
		private static MarkToMarkAdjustmentRecord[] GetAllMarkToMarkAdjustmentRecords_FontFaceHandle_Internal(ref FontFaceHandle faceHandle); // 0x00000001822EE850-0x00000001822EE950
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(FontFaceHandle faceHandle, List<uint> glyphIndexes); // 0x00000001822EF860-0x00000001822EF900
		private static MarkToMarkAdjustmentRecord[] GetMarkToMarkAdjustmentRecords(FontFaceHandle faceHandle, uint[] glyphIndexes); // 0x00000001822EF900-0x00000001822EFB60
		[NativeMethod(Name = "TextCore::FontEngine::PopulateMarkToMarkAdjustmentRecordMarshallingArray", IsFreeFunction = true)]
		private static int PopulateMarkToMarkAdjustmentRecordMarshallingArray_FontFaceHandle(ref FontFaceHandle faceHandle, uint[] glyphIndexes, out int recordCount); // 0x00000001822F0FD0-0x00000001822F10B0
		[NativeMethod(Name = "TextCore::FontEngine::GetMarkToMarkAdjustmentRecordsFromMarshallingArray", IsFreeFunction = true)]
		private static int GetMarkToMarkAdjustmentRecordsFromMarshallingArray(Span<MarkToMarkAdjustmentRecord> adjustmentRecords); // 0x00000001822EF7C0-0x00000001822EF860
		private static void GlyphIndexToMarshallingArray(uint glyphIndex, ref uint[] dstArray); // 0x00000001822F0020-0x00000001822F00C0
		private static void GenericListToMarshallingArray<T>(ref List<T> srcList, ref ref T[] dstArray);
		private static void SetMarshallingArraySize<T>(ref ref T[] marshallingArray, int recordCount);
		[NativeMethod(Name = "TextCore::FontEngine::ResetAtlasTexture", IsFreeFunction = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static void ResetAtlasTexture(Texture2D texture); // 0x00000001822F1370-0x00000001822F13E0
		private static int LoadFontFace_Internal_Injected(ref ManagedSpanWrapper filePath); // 0x00000001822F0170-0x00000001822F01B0
		private static int LoadFontFace_With_Size_And_FaceIndex_FontFaceHandle_Internal_Injected(ref ManagedSpanWrapper filePath, int pointSize, int faceIndex, out FontFaceHandle faceHandle); // 0x00000001822F0340-0x00000001822F03A0
		private static int LoadFontFace_With_Size_and_FaceIndex_FromFont_FontFaceHandle_Internal_Injected(IntPtr font, int pointSize, int faceIndex, out FontFaceHandle faceHandle); // 0x00000001822F0540-0x00000001822F05A0
		private static int LoadFontFace_With_Size_by_FamilyName_and_StyleName_FontFaceHandle_Internal_Injected(ref ManagedSpanWrapper familyName, ref ManagedSpanWrapper styleName, int pointSize, out FontFaceHandle faceHandle); // 0x00000001822F0640-0x00000001822F06B0
		private static bool TryGetSystemFontReference_Internal_Injected(ref ManagedSpanWrapper familyName, ref ManagedSpanWrapper styleName, out FontReference fontRef); // 0x00000001822F30C0-0x00000001822F3120
		private static bool TryAddGlyphToTexture_FontFaceHandle_Internal_Injected(ref FontFaceHandle faceHandle, uint glyphIndex, int padding, GlyphPackingMode packingMode, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, IntPtr texture, out GlyphMarshallingStruct glyph); // 0x00000001822F1420-0x00000001822F1490
		private static bool TryAddGlyphsToTexture_FontFaceHandle_Internal_Injected(ref FontFaceHandle faceHandle, ref ManagedSpanWrapper glyphIndex, int padding, GlyphPackingMode packingMode, out BlittableArrayWrapper freeGlyphRects, ref int freeGlyphRectCount, out BlittableArrayWrapper usedGlyphRects, ref int usedGlyphRectCount, GlyphRenderMode renderMode, IntPtr texture, [In, Out] BlittableArrayWrapper glyphs, ref int glyphCount); // 0x00000001822F1CD0-0x00000001822F1D40
		private static int PopulateLigatureSubstitutionRecordMarshallingArray_FontFaceHandle_Injected(ref FontFaceHandle faceHandle, ref ManagedSpanWrapper glyphIndexes, out int recordCount); // 0x00000001822F0CF0-0x00000001822F0D50
		private static int PopulatePairAdjustmentRecordMarshallingArray_from_KernTable_FontFaceHandle_Injected(ref FontFaceHandle faceHandle, ref ManagedSpanWrapper glyphIndexes, out int recordCount); // 0x00000001822F11F0-0x00000001822F1250
		private static void GetAllPairAdjustmentRecords_FontFaceHandle_Internal_Injected(ref FontFaceHandle faceHandle, ); // 0x00000001822EE9A0-0x00000001822EE9F0
		private static int PopulatePairAdjustmentRecordMarshallingArray_FontFaceHandle_Injected(ref FontFaceHandle faceHandle, ref ManagedSpanWrapper glyphIndexes, out int recordCount); // 0x00000001822F10B0-0x00000001822F1110
		private static int GetPairAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper glyphPairAdjustmentRecords); // 0x00000001822EFB60-0x00000001822EFBA0
		private static void GetAllMarkToBaseAdjustmentRecords_FontFaceHandle_Internal_Injected(ref FontFaceHandle faceHandle, ); // 0x00000001822EE660-0x00000001822EE6B0
		private static int PopulateMarkToBaseAdjustmentRecordMarshallingArray_FontFaceHandle_Injected(ref FontFaceHandle faceHandle, ref ManagedSpanWrapper glyphIndexes, out int recordCount); // 0x00000001822F0E30-0x00000001822F0E90
		private static int GetMarkToBaseAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper adjustmentRecords); // 0x00000001822EF3A0-0x00000001822EF3E0
		private static void GetAllMarkToMarkAdjustmentRecords_FontFaceHandle_Internal_Injected(ref FontFaceHandle faceHandle, ); // 0x00000001822EE800-0x00000001822EE850
		private static int PopulateMarkToMarkAdjustmentRecordMarshallingArray_FontFaceHandle_Injected(ref FontFaceHandle faceHandle, ref ManagedSpanWrapper glyphIndexes, out int recordCount); // 0x00000001822F0F70-0x00000001822F0FD0
		private static int GetMarkToMarkAdjustmentRecordsFromMarshallingArray_Injected(ref ManagedSpanWrapper adjustmentRecords); // 0x00000001822EF780-0x00000001822EF7C0
		private static void ResetAtlasTexture_Injected(IntPtr texture); // 0x00000001822F1330-0x00000001822F1370
	}
}
