/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Serialization;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[ExcludeFromPreset]
	[HelpURL("UIE-font-asset-landing")]
	[NativeHeader("Modules/TextCoreTextEngine/Native/FontAsset.h")]
	public class FontAsset : TextAsset // TypeDefIndex: 12659
	{
		// Fields
		[SerializeField]
		internal string m_SourceFontFileGUID; // 0x40
		[SerializeField]
		internal bool m_ShowObsoleteProperties; // 0x48
		[SerializeField]
		internal FontAssetCreationEditorSettings m_fontAssetCreationEditorSettings; // 0x50
		[SerializeField]
		private Font m_SourceFontFile; // 0xA8
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal string m_SourceFontFilePath; // 0xB0
		private FontFaceHandle m_FontFaceHandle; // 0xB8
		[SerializeField]
		private AtlasPopulationMode m_AtlasPopulationMode; // 0xC8
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal bool InternalDynamicOS; // 0xCC
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool IsEditorFont; // 0xCD
		[SerializeField]
		internal FaceInfo m_FaceInfo; // 0xD0
		private int m_FamilyNameHashCode; // 0x130
		private int m_StyleNameHashCode; // 0x134
		[Nullable(1)]
		[SerializeField]
		internal List<Glyph> m_GlyphTable; // 0x138
		internal Dictionary<uint, Glyph> m_GlyphLookupDictionary; // 0x140
		[SerializeField]
		internal List<Character> m_CharacterTable; // 0x148
		internal Texture2D m_AtlasTexture; // 0x150
		[SerializeField]
		internal Texture2D[] m_AtlasTextures; // 0x158
		[SerializeField]
		internal int m_AtlasTextureIndex; // 0x160
		[SerializeField]
		private bool m_IsMultiAtlasTexturesEnabled; // 0x164
		[SerializeField]
		private bool m_GetFontFeatures; // 0x165
		[SerializeField]
		private bool m_ClearDynamicDataOnBuild; // 0x166
		[SerializeField]
		internal int m_AtlasWidth; // 0x168
		[SerializeField]
		internal int m_AtlasHeight; // 0x16C
		[SerializeField]
		internal int m_AtlasPadding; // 0x170
		[SerializeField]
		internal GlyphRenderMode m_AtlasRenderMode; // 0x174
		[SerializeField]
		private List<GlyphRect> m_UsedGlyphRects; // 0x178
		[SerializeField]
		private List<GlyphRect> m_FreeGlyphRects; // 0x180
		[SerializeField]
		internal FontFeatureTable m_FontFeatureTable; // 0x188
		[SerializeField]
		internal bool m_ShouldReimportFontFeatures; // 0x190
		[SerializeField]
		internal List<FontAsset> m_FallbackFontAssetTable; // 0x198
		[SerializeField]
		private FontWeightPair[] m_FontWeightTable; // 0x1A0
		[FormerlySerializedAs("normalStyle")]
		[SerializeField]
		internal float m_RegularStyleWeight; // 0x1A8
		[FormerlySerializedAs("normalSpacingOffset")]
		[SerializeField]
		internal float m_RegularStyleSpacing; // 0x1AC
		[FormerlySerializedAs("boldStyle")]
		[SerializeField]
		internal float m_BoldStyleWeight; // 0x1B0
		[FormerlySerializedAs("boldSpacing")]
		[SerializeField]
		internal float m_BoldStyleSpacing; // 0x1B4
		[FormerlySerializedAs("italicStyle")]
		[SerializeField]
		internal byte m_ItalicStyleSlant; // 0x1B8
		[FormerlySerializedAs("tabSize")]
		[SerializeField]
		internal byte m_TabMultiple; // 0x1B9
		internal bool IsFontAssetLookupTablesDirty; // 0x1BA
		private IntPtr m_NativeFontAsset; // 0x1C0
		private List<Glyph> m_GlyphsToRender; // 0x1C8
		private List<Glyph> m_GlyphsRendered; // 0x1D0
		private List<uint> m_GlyphIndexList; // 0x1D8
		private List<uint> m_GlyphIndexListNewlyAdded; // 0x1E0
		internal List<uint> m_GlyphsToAdd; // 0x1E8
		internal HashSet<uint> m_GlyphsToAddLookup; // 0x1F0
		internal List<Character> m_CharactersToAdd; // 0x1F8
		internal HashSet<uint> m_CharactersToAddLookup; // 0x200
		internal List<uint> s_MissingCharacterList; // 0x208
		internal HashSet<uint> m_MissingUnicodesFromFontFile; // 0x210
		internal Dictionary<ValueTuple<uint, uint>, uint> m_VariantGlyphIndexes; // 0x218
		internal bool m_IsClone; // 0x220
		private static readonly List<WeakReference<FontAsset>> s_CallbackInstances; // 0x00
		private static ProfilerMarker k_ReadFontAssetDefinitionMarker; // 0x08
		private static ProfilerMarker k_AddSynthesizedCharactersMarker; // 0x10
		private static ProfilerMarker k_TryAddGlyphMarker; // 0x18
		private static ProfilerMarker k_TryAddCharacterMarker; // 0x20
		private static ProfilerMarker k_TryAddCharactersMarker; // 0x28
		private static ProfilerMarker k_UpdateLigatureSubstitutionRecordsMarker; // 0x30
		private static ProfilerMarker k_UpdateGlyphAdjustmentRecordsMarker; // 0x38
		private static ProfilerMarker k_UpdateDiacriticalMarkAdjustmentRecordsMarker; // 0x40
		private static ProfilerMarker k_ClearFontAssetDataMarker; // 0x48
		private static ProfilerMarker k_UpdateFontAssetDataMarker; // 0x50
		private static string s_DefaultMaterialSuffix; // 0x58
		private static HashSet<EntityId> k_SearchedFontAssetLookup; // 0x60
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal Dictionary<uint, Character> m_CharacterLookupDictionary; // 0x228
		private static List<FontAsset> k_FontAssets_FontFeaturesUpdateQueue; // 0x68
		private static HashSet<EntityId> k_FontAssets_FontFeaturesUpdateQueueLookup; // 0x70
		private static List<FontAsset> k_FontAssets_KerningUpdateQueue; // 0x78
		private static HashSet<EntityId> k_FontAssets_KerningUpdateQueueLookup; // 0x80
		private static List<Texture2D> k_FontAssets_AtlasTexturesUpdateQueue; // 0x88
		private static HashSet<EntityId> k_FontAssets_AtlasTexturesUpdateQueueLookup; // 0x90
		private static HashSet<EntityId> visitedFontAssets; // 0x98
	
		// Properties
		public FontAssetCreationEditorSettings fontAssetCreationEditorSettings { get; set; } // 0x0000000182302B50-0x0000000182302B90 0x0000000182302E90-0x0000000182302EE0
		public Font sourceFontFile { get; internal set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		public AtlasPopulationMode atlasPopulationMode { get; set; } // 0x000000018158B020-0x000000018158B030 0x00000001819DB6D0-0x00000001819DB6E0
		public FaceInfo faceInfo { get; set; } // 0x0000000182302AC0-0x0000000182302B10 0x0000000182302CD0-0x0000000182302E90
		internal int familyNameHashCode { get; set; } // 0x0000000182302B10-0x0000000182302B50 0x0000000181CE61F0-0x0000000181CE6200
		internal int styleNameHashCode { get; set; } // 0x0000000182302C30-0x0000000182302C70 0x0000000182302F30-0x0000000182302F40
		public Texture2D atlasTexture { get; } // 0x00000001823029B0-0x0000000182302A50 
		public Texture2D[] atlasTextures { get; set; } // 0x0000000181F64850-0x0000000181F64860 0x00000001813800B0-0x00000001813800D0
		public int atlasTextureCount { get; } // 0x00000001823029A0-0x00000001823029B0 
		public bool isMultiAtlasTexturesEnabled { get; set; } // 0x0000000182019890-0x00000001820198A0 0x0000000182302EF0-0x0000000182302F00
		public bool getFontFeatures { get; set; } // 0x0000000182302B90-0x0000000182302BA0 0x0000000182302EE0-0x0000000182302EF0
		internal bool clearDynamicDataOnBuild { get; set; } // 0x0000000182302AB0-0x0000000182302AC0 0x0000000182302CC0-0x0000000182302CD0
		public int atlasWidth { get; internal set; } // 0x0000000182081CA0-0x0000000182081CB0 0x0000000182081F20-0x0000000182081F30
		public int atlasHeight { get; internal set; } // 0x0000000182081CB0-0x0000000182081CC0 0x0000000182081F40-0x0000000182081F50
		public int atlasPadding { get; internal set; } // 0x00000001820937B0-0x00000001820937C0 0x0000000182302C80-0x0000000182302C90
		public GlyphRenderMode atlasRenderMode { get; internal set; } // 0x0000000182093930-0x0000000182093940 0x0000000182302C90-0x0000000182302CA0
		internal List<GlyphRect> usedGlyphRects { get; set; } // 0x0000000181CF6CA0-0x0000000181CF6CB0 0x00000001813800F0-0x0000000181380110
		internal List<GlyphRect> freeGlyphRects { get; set; } // 0x0000000181C4BCD0-0x0000000181C4BCE0 0x0000000181CF6CF0-0x0000000181CF6D10
		public List<FontAsset> fallbackFontAssetTable { get; set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public FontWeightPair[] fontWeightTable { get; internal set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		public float regularStyleWeight { get; set; } // 0x0000000182302C20-0x0000000182302C30 0x0000000182302F20-0x0000000182302F30
		public float regularStyleSpacing { get; set; } // 0x0000000182302C10-0x0000000182302C20 0x0000000182302F10-0x0000000182302F20
		public float boldStyleWeight { get; set; } // 0x0000000182302A60-0x0000000182302A70 0x0000000182302CB0-0x0000000182302CC0
		public float boldStyleSpacing { get; set; } // 0x0000000182302A50-0x0000000182302A60 0x0000000182302CA0-0x0000000182302CB0
		public byte italicStyleSlant { get; set; } // 0x0000000182302BE0-0x0000000182302BF0 0x0000000182302F00-0x0000000182302F10
		public byte tabMultiple { get; set; } // 0x0000000182302C70-0x0000000182302C80 0x0000000182302F40-0x0000000182302F50
		[Obsolete("characterTable is deprecated and will be removed in a future release. Advanced Text Generator (ATG) text backend no longer requires character data.", false)]
		public List<Character> characterTable { get; internal set; } // 0x000000018033D220-0x000000018033D230 0x000000018033E800-0x000000018033E820
		[Obsolete("characterLookupTable is deprecated and will be removed in a future release. Advanced Text Generator (ATG) text backend no longer requires character data.", false)]
		public Dictionary<uint, Character> characterLookupTable { get; } // 0x0000000182302A70-0x0000000182302AB0 
		[Obsolete("Font feature tables and OTL feature tags are obsolete. OpenType layout is now handled natively by Advanced Text Generator (ATG).", false)]
		public FontFeatureTable fontFeatureTable { get; internal set; } // 0x000000018033D500-0x000000018033D510 0x000000018033EA90-0x000000018033EAB0
		[Obsolete("glyphTable is deprecated and will be removed in a future release.", false)]
		public List<Glyph> glyphTable { get; internal set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
		[Obsolete("glyphLookupTable is deprecated and will be removed in a future release.", false)]
		public Dictionary<uint, Glyph> glyphLookupTable { get; } // 0x0000000182302BA0-0x0000000182302BE0 
		internal IntPtr nativeFontAsset { [VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })] get; } // 0x0000000182302BF0-0x0000000182302C10 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12660
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Character, uint> __9__178_0; // 0x08
			public static Func<Glyph, uint> __9__179_0; // 0x10
	
			// Constructors
			static __c(); // 0x000000018234B9C0-0x000000018234BA30
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortCharacterTable_b__178_0(Character c); // 0x0000000182095970-0x0000000182095990
			internal uint _SortGlyphTable_b__179_0(Glyph c); // 0x000000018030F200-0x000000018030F220
		}
	
		// Constructors
		public FontAsset(); // 0x00000001823025A0-0x00000001823029A0
		static FontAsset(); // 0x0000000182302020-0x00000001823025A0
	
		// Methods
		private static void EnsureAdditionalCapacity<T>(List<T> container, int additionalCapacity);
		private static void EnsureAdditionalCapacity<TKey, TValue>(Dictionary<TKey, TValue> container, int additionalCapacity);
		public bool IsBitmap(); // 0x00000001822FB8D0-0x00000001822FB8F0
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool IsRaster(); // 0x00000001822FB900-0x00000001822FB910
		internal bool IsColor(); // 0x00000001822FB8F0-0x00000001822FB900
		public static FontAsset CreateFontAsset(string familyName, string styleName, int pointSize = 90 /* Metadata: 0x006A48CA */); // 0x00000001822F79E0-0x00000001822F7BB0
		[NullableContext(1)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static FontAsset CreateFontAssetInternal(string familyName, string styleName, int pointSize = 90 /* Metadata: 0x006A48CC */); // 0x00000001822F74D0-0x00000001822F75D0
		[NullableContext(1)]
		public static FontAsset CreateFontAsset(string familyName, string styleName, int pointSize, int padding, GlyphRenderMode renderMode); // 0x00000001822F7830-0x00000001822F7930
		internal static FontAsset CreateFontAssetFromFontReference(FontReference fontRef, int pointSize = 90 /* Metadata: 0x006A48CE */); // 0x00000001822F6B70-0x00000001822F6CD0
		public static FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight); // 0x00000001822F7930-0x00000001822F79E0
		internal static FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport = true /* Metadata: 0x006A48D0 */); // 0x00000001822F75D0-0x00000001822F77B0
		public static FontAsset CreateFontAsset(Font font); // 0x00000001822F77B0-0x00000001822F7830
		public static FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic /* Metadata: 0x006A48D1 */, bool enableMultiAtlasSupport = true /* Metadata: 0x006A48D2 */); // 0x00000001822F7BB0-0x00000001822F7E00
		internal static FontAsset CreateFontAsset(Font font, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic /* Metadata: 0x006A48D3 */, bool enableMultiAtlasSupport = true /* Metadata: 0x006A48D4 */); // 0x00000001822F7E00-0x00000001822F8030
		private static FontAsset CreateFontAssetInstance(Font font, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport, FontFaceHandle faceHandle); // 0x00000001822F6CD0-0x00000001822F74D0
		private void RegisterCallbackInstance(FontAsset instance); // 0x00000001822FC5F0-0x00000001822FC910
		private void OnDisable(); // 0x00000001822FBBF0-0x00000001822FBC00
		internal override void OnDestroy(); // 0x00000001822FBA40-0x00000001822FBBF0
		private void DestroyNativeFontAsset(); // 0x00000001822F8650-0x00000001822F86F0
		public void ReadFontAssetDefinition(); // 0x00000001822FBC00-0x00000001822FC480
		internal void InitializeDictionaryLookupTables(); // 0x00000001822FAD70-0x00000001822FAEE0
		private static void InitializeLookup<T>(ICollection source, ref Dictionary<uint, T> lookup, int defaultCapacity = 16 /* Metadata: 0x006A48D5 */);
		private static void InitializeList<T>(ICollection source, ref List<T> list, int defaultCapacity = 16 /* Metadata: 0x006A48D6 */);
		internal void InitializeGlyphLookupDictionary(); // 0x00000001822FAEE0-0x00000001822FB0D0
		internal void InitializeCharacterLookupDictionary(); // 0x00000001822FAB70-0x00000001822FAD70
		internal void ClearFallbackCharacterTable(); // 0x00000001822F6230-0x00000001822F64F0
		internal void InitializeLigatureSubstitutionLookupDictionary(); // 0x00000001822FB2C0-0x00000001822FB570
		internal void InitializeGlyphPairAdjustmentRecordsLookupDictionary(); // 0x00000001822FB0D0-0x00000001822FB2C0
		internal void InitializeMarkToBaseAdjustmentRecordsLookupDictionary(); // 0x00000001822FB570-0x00000001822FB720
		internal void InitializeMarkToMarkAdjustmentRecordsLookupDictionary(); // 0x00000001822FB720-0x00000001822FB8D0
		internal void AddSynthesizedCharactersAndFaceMetrics(); // 0x00000001822F5AF0-0x00000001822F5DB0
		private void AddSynthesizedCharacter(uint unicode, bool isFontFaceLoaded, bool addImmediately = false /* Metadata: 0x006A48D7 */); // 0x00000001822F5310-0x00000001822F5AF0
		internal void AddCharacterToLookupCache(uint unicode, Character character); // 0x00000001822F46D0-0x00000001822F4750
		internal void AddCharacterToLookupCache(uint unicode, Character character, FontStyles fontStyle, TextFontWeight fontWeight); // 0x00000001822F4600-0x00000001822F46D0
		internal bool GetCharacterInLookupCache(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight, out Character character); // 0x00000001822F8B10-0x00000001822F8BE0
		internal void RemoveCharacterInLookupCache(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight); // 0x00000001822FCB70-0x00000001822FCC40
		internal bool ContainsCharacterInLookupCache(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight); // 0x00000001822F6840-0x00000001822F6910
		private uint CreateCompositeKey(uint unicode, FontStyles fontStyle = FontStyles.Normal /* Metadata: 0x006A48D8 */, TextFontWeight fontWeight = TextFontWeight.Regular /* Metadata: 0x006A48D9 */); // 0x00000001822F6B00-0x00000001822F6B70
		internal FontEngineError LoadFontFace(); // 0x00000001822FB910-0x00000001822FBA40
		internal void SortCharacterTable(); // 0x00000001822FD1B0-0x00000001822FD310
		internal void SortGlyphTable(); // 0x00000001822FD890-0x00000001822FD9F0
		internal void SortFontFeatureTable(); // 0x00000001822FD310-0x00000001822FD890
		internal void SortAllTables(); // 0x00000001822FCF30-0x00000001822FD1B0
		private bool HasCharacterWithStyle_Internal(uint character, FontStyles fontStyle, TextFontWeight fontWeight, bool searchFallbacks = false /* Metadata: 0x006A48DB */, bool tryAddCharacter = false /* Metadata: 0x006A48DC */); // 0x00000001822F9860-0x00000001822F9880
		private bool HasCharacter_Internal(uint character, FontStyles fontStyle = FontStyles.Normal /* Metadata: 0x006A48DD */, TextFontWeight fontWeight = TextFontWeight.Regular /* Metadata: 0x006A48DE */, bool searchFallbacks = false /* Metadata: 0x006A48E0 */, bool tryAddCharacter = false /* Metadata: 0x006A48E1 */); // 0x00000001822F9880-0x00000001822F9B80
		internal uint GetGlyphIndex(uint unicode); // 0x00000001822F9320-0x00000001822F9490
		internal Glyph GetGlyphInCache(uint glyphID); // 0x00000001822F9050-0x00000001822F90D0
		internal uint GetGlyphIndex(uint unicode, out bool success); // 0x00000001822F9190-0x00000001822F9320
		internal uint GetGlyphVariantIndex(uint unicode, uint variantSelectorUnicode); // 0x00000001822F9490-0x00000001822F9530
		internal void UpdateFontAssetData(); // 0x00000001823011C0-0x00000001823013B0
		public void ClearFontAssetData(bool setAtlasSizeToZero = false /* Metadata: 0x006A48E2 */); // 0x00000001822F64F0-0x00000001822F6780
		internal void ClearCharacterAndGlyphTablesInternal(); // 0x00000001822F6020-0x00000001822F6050
		private void ClearCharacterAndGlyphTables(); // 0x00000001822F6050-0x00000001822F6230
		private void ClearFontFeaturesTables(); // 0x00000001822F6780-0x00000001822F6840
		internal void ClearAtlasTextures(bool setAtlasSizeToZero = false /* Metadata: 0x006A48E3 */); // 0x00000001822F5DB0-0x00000001822F6020
		private void DestroyAtlasTextures(); // 0x00000001822F8520-0x00000001822F8650
		private uint GetGlyphIndexWithFallback(uint unicode); // 0x00000001822F90D0-0x00000001822F9190
		internal static void RegisterFontAssetForFontFeatureUpdate(FontAsset fontAsset); // 0x00000001822FC910-0x00000001822FCA40
		internal static void RegisterFontAssetForKerningUpdate(FontAsset fontAsset); // 0x00000001822FCA40-0x00000001822FCB70
		internal static void UpdateFontFeaturesForFontAssetsInQueue(); // 0x0000000182301520-0x0000000182301750
		internal static void RegisterAtlasTextureForApply(Texture2D texture); // 0x00000001822FC480-0x00000001822FC5F0
		internal static void UpdateAtlasTexturesInQueue(); // 0x00000001823008E0-0x0000000182300A10
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static void UpdateFontAssetsInUpdateQueue(); // 0x00000001823013B0-0x0000000182301520
		public bool HasCharacter(int character); // 0x00000001822F9E90-0x00000001822F9F10
		public bool HasCharacter(char character, bool searchFallbacks = false /* Metadata: 0x006A48E4 */, bool tryAddCharacter = false /* Metadata: 0x006A48E5 */); // 0x00000001822F9F10-0x00000001822F9F30
		public bool HasCharacter(uint character, bool searchFallbacks = false /* Metadata: 0x006A48E6 */, bool tryAddCharacter = false /* Metadata: 0x006A48E7 */); // 0x00000001822F9B80-0x00000001822F9E90
		public bool HasCharacters(string text, out List<char> missingCharacters); // 0x00000001822FA4D0-0x00000001822FA630
		public bool HasCharacters(string text, out uint[] missingCharacters, bool searchFallbacks = false /* Metadata: 0x006A48E8 */, bool tryAddCharacter = false /* Metadata: 0x006A48E9 */); // 0x00000001822FA000-0x00000001822FA4D0
		public bool HasCharacters(string text); // 0x00000001822F9F30-0x00000001822FA000
		public static string GetCharacters(FontAsset fontAsset); // 0x00000001822F8CA0-0x00000001822F8D70
		public static int[] GetCharactersArray(FontAsset fontAsset); // 0x00000001822F8BE0-0x00000001822F8CA0
		public bool TryAddCharacters(uint[] unicodes, bool includeFontFeatures = false /* Metadata: 0x006A48EA */); // 0x00000001822FDF00-0x00000001822FDF30
		public bool TryAddCharacters(uint[] unicodes, out uint[] missingUnicodes, bool includeFontFeatures = false /* Metadata: 0x006A48EB */); // 0x00000001822FDF30-0x00000001822FEF90
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal bool TryAddGlyphs(List<uint> glyphsToAdd, bool populateFontFeatures = true /* Metadata: 0x006A48EC */); // 0x00000001823000D0-0x0000000182300840
		public bool TryAddCharacters(string characters, bool includeFontFeatures = false /* Metadata: 0x006A48ED */); // 0x00000001822FDD60-0x00000001822FDF00
		public bool TryAddCharacters(string characters, out string missingCharacters, bool includeFontFeatures = false /* Metadata: 0x006A48EE */); // 0x00000001822FEF90-0x00000001822FF120
		internal bool TryAddGlyphVariantIndexInternal(uint unicode, uint nextCharacter, uint variantGlyphIndex); // 0x00000001822FFBE0-0x00000001822FFC80
		internal bool TryGetGlyphVariantIndexInternal(uint unicode, uint nextCharacter, out uint variantGlyphIndex); // 0x0000000182300840-0x00000001823008E0
		internal bool TryAddGlyphInternal(uint glyphIndex, out Glyph glyph, bool populateLigatures = true /* Metadata: 0x006A48EF */); // 0x00000001822FF120-0x00000001822FF2F0
		internal bool TryAddCharacterInternal(uint unicode, out Character character); // 0x00000001822FDD30-0x00000001822FDD60
		internal bool TryAddCharacterInternal(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight, out Character character, bool populateLigatures = true /* Metadata: 0x006A48F0 */); // 0x00000001822FD9F0-0x00000001822FDD30
		private bool TryAddGlyphToAtlas(uint glyphIndex, out Glyph glyph, bool populateLigatures = true /* Metadata: 0x006A48F1 */); // 0x00000001822FF2F0-0x00000001822FF740
		private bool TryAddGlyphToTexture(uint glyphIndex, out Glyph glyph, bool populateLigatures = true /* Metadata: 0x006A48F2 */); // 0x00000001822FF740-0x00000001822FFBE0
		private bool TryAddGlyphsToNewAtlasTexture(); // 0x00000001822FFC80-0x00000001823000D0
		private void SetupNewAtlasTexture(); // 0x00000001822FCC40-0x00000001822FCF30
		private Character CreateCharacterAndAddToCache(uint unicode, Glyph glyph, FontStyles fontStyle, TextFontWeight fontWeight); // 0x00000001822F6910-0x00000001822F6B00
		private void UpdateFontFeaturesForNewlyAddedGlyphs(); // 0x0000000182301750-0x00000001823017A0
		private void UpdateGlyphAdjustmentRecordsForNewGlyphs(); // 0x0000000182301870-0x00000001823018B0
		private void UpdateGPOSFontFeaturesForNewlyAddedGlyphs(); // 0x00000001823017A0-0x00000001823017E0
		internal void ImportFontFeatures(); // 0x00000001822FAA60-0x00000001822FAB70
		private void UpdateGSUBFontFeaturesForNewGlyphIndex(uint glyphIndex); // 0x00000001823017E0-0x0000000182301870
		internal void UpdateLigatureSubstitutionRecords(); // 0x0000000182301AF0-0x0000000182301C40
		private void AddLigatureSubstitutionRecords(LigatureSubstitutionRecord[] records); // 0x00000001822F4750-0x00000001822F4B30
		internal void UpdateGlyphAdjustmentRecords(); // 0x00000001823018B0-0x0000000182301A10
		private void AddPairAdjustmentRecords(GlyphPairAdjustmentRecord[] records); // 0x00000001822F5040-0x00000001822F5310
		internal void UpdateDiacriticalMarkAdjustmentRecords(); // 0x0000000182300BE0-0x0000000182300D60
		private void AddMarkToBaseAdjustmentRecords(MarkToBaseAdjustmentRecord[] records); // 0x00000001822F4B30-0x00000001822F4DE0
		private void AddMarkToMarkAdjustmentRecords(MarkToMarkAdjustmentRecord[] records); // 0x00000001822F4DE0-0x00000001822F5040
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void EnsureNativeFontAssetIsCreated(); // 0x00000001822F8740-0x00000001822F8B10
		internal void UpdateFallbacks(); // 0x0000000182300FE0-0x00000001823010F0
		internal void UpdateWeightFallbacks(); // 0x0000000182301D70-0x0000000182301EF0
		internal void UpdateFaceInfo(); // 0x0000000182300E30-0x0000000182300F90
		internal void UpdateRenderMode(); // 0x0000000182301C80-0x0000000182301D10
		internal void UpdateItalicAngle(); // 0x0000000182301A10-0x0000000182301AA0
		internal void UpdateBoldWeight(); // 0x0000000182300AF0-0x0000000182300B90
		internal void UpdateBoldSpacing(); // 0x0000000182300A50-0x0000000182300AF0
		internal IntPtr[] GetFallbacks(); // 0x00000001822F8D70-0x00000001822F9050
		private bool HasRecursion(FontAsset fontAsset); // 0x00000001822FA9D0-0x00000001822FAA60
		private bool HasRecursionInternal(FontAsset fontAsset); // 0x00000001822FA630-0x00000001822FA9D0
		private ValueTuple<IntPtr[], IntPtr[]> GetWeightFallbacks(); // 0x00000001822F9530-0x00000001822F9860
		private static void UpdateFallbacks(IntPtr ptr, IntPtr[] fallbacks); // 0x00000001823010F0-0x00000001823011C0
		private static void UpdateWeightFallbacks(IntPtr ptr, IntPtr[] regularFallbacks, IntPtr[] italicFallbacks); // 0x0000000182301EF0-0x0000000182302020
		private static IntPtr Create(FaceInfo faceInfo, Font sourceFontFile, Font sourceFont_EditorRef, string sourceFontFilePath, EntityId fontEntityId, IntPtr[] fallbacks, IntPtr[] weightFallbacks, IntPtr[] italicFallbacks, GlyphRenderMode renderMode, byte italicSlant, float boldWeight, int boldSpacing, IntPtr managedObject); // 0x00000001822F80E0-0x00000001822F8520
		private static void UpdateFaceInfo(IntPtr ptr, FaceInfo faceInfo); // 0x0000000182300DB0-0x0000000182300E30
		private static void UpdateRenderMode(IntPtr ptr, GlyphRenderMode renderMode); // 0x0000000182301C40-0x0000000182301C80
		private static void UpdateItalicAngle(IntPtr ptr, byte italicAngle); // 0x0000000182301AA0-0x0000000182301AF0
		private static void UpdateBoldWeight(IntPtr ptr, float boldWeight); // 0x0000000182300B90-0x0000000182300BE0
		private static void UpdateBoldSpacing(IntPtr ptr, int boldSpacing); // 0x0000000182300A10-0x0000000182300A50
		[FreeFunction("FontAsset::Destroy")]
		private static void Destroy(IntPtr ptr, IntPtr managedObject); // 0x00000001822F86F0-0x00000001822F8740
		[FreeFunction("FontAsset::CreateHbFaceIfNeeded")]
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal static void CreateHbFaceIfNeeded(); // 0x00000001822F8030-0x00000001822F8060
		private static void UpdateFallbacks_Injected(IntPtr ptr, ref ManagedSpanWrapper fallbacks); // 0x0000000182300F90-0x0000000182300FE0
		private static void UpdateWeightFallbacks_Injected(IntPtr ptr, ref ManagedSpanWrapper regularFallbacks, ref ManagedSpanWrapper italicFallbacks); // 0x0000000182301D10-0x0000000182301D70
		private static IntPtr Create_Injected(in FaceInfo faceInfo, IntPtr sourceFontFile, IntPtr sourceFont_EditorRef, ref ManagedSpanWrapper sourceFontFilePath, in EntityId fontEntityId, ref ManagedSpanWrapper fallbacks, ref ManagedSpanWrapper weightFallbacks, ref ManagedSpanWrapper italicFallbacks, GlyphRenderMode renderMode, byte italicSlant, float boldWeight, int boldSpacing, IntPtr managedObject); // 0x00000001822F8060-0x00000001822F80E0
		private static void UpdateFaceInfo_Injected(IntPtr ptr, in FaceInfo faceInfo); // 0x0000000182300D60-0x0000000182300DB0
	}
}
