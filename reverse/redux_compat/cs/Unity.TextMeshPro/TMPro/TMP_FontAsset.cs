/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[TMPHelpURL("FontAssets")]
	public class TMP_FontAsset : TMP_Asset // TypeDefIndex: 11814
	{
		// Fields
		[SerializeField]
		internal string m_SourceFontFileGUID; // 0xA0
		[SerializeField]
		internal FontAssetCreationSettings m_CreationSettings; // 0xA8
		[SerializeField]
		private Font m_SourceFontFile; // 0x108
		[SerializeField]
		private string m_SourceFontFilePath; // 0x110
		[SerializeField]
		private AtlasPopulationMode m_AtlasPopulationMode; // 0x118
		[SerializeField]
		internal bool InternalDynamicOS; // 0x11C
		private int m_FamilyNameHashCode; // 0x120
		private int m_StyleNameHashCode; // 0x124
		[SerializeField]
		internal List<Glyph> m_GlyphTable; // 0x128
		internal Dictionary<uint, Glyph> m_GlyphLookupDictionary; // 0x130
		[SerializeField]
		internal List<TMP_Character> m_CharacterTable; // 0x138
		internal Dictionary<uint, TMP_Character> m_CharacterLookupDictionary; // 0x140
		internal Texture2D m_AtlasTexture; // 0x148
		[SerializeField]
		internal Texture2D[] m_AtlasTextures; // 0x150
		[SerializeField]
		internal int m_AtlasTextureIndex; // 0x158
		[SerializeField]
		private bool m_IsMultiAtlasTexturesEnabled; // 0x15C
		[SerializeField]
		private bool m_GetFontFeatures; // 0x15D
		[SerializeField]
		private bool m_ClearDynamicDataOnBuild; // 0x15E
		[SerializeField]
		internal int m_AtlasWidth; // 0x160
		[SerializeField]
		internal int m_AtlasHeight; // 0x164
		[SerializeField]
		internal int m_AtlasPadding; // 0x168
		[SerializeField]
		internal GlyphRenderMode m_AtlasRenderMode; // 0x16C
		[SerializeField]
		private List<GlyphRect> m_UsedGlyphRects; // 0x170
		[SerializeField]
		private List<GlyphRect> m_FreeGlyphRects; // 0x178
		[SerializeField]
		internal TMP_FontFeatureTable m_FontFeatureTable; // 0x180
		[SerializeField]
		internal bool m_ShouldReimportFontFeatures; // 0x188
		[SerializeField]
		internal List<TMP_FontAsset> m_FallbackFontAssetTable; // 0x190
		[SerializeField]
		private TMP_FontWeightPair[] m_FontWeightTable; // 0x198
		[SerializeField]
		private TMP_FontWeightPair[] fontWeights; // 0x1A0
		public float normalStyle; // 0x1A8
		public float normalSpacingOffset; // 0x1AC
		public float boldStyle; // 0x1B0
		public float boldSpacing; // 0x1B4
		public byte italicStyle; // 0x1B8
		public byte tabSize; // 0x1B9
		internal bool IsFontAssetLookupTablesDirty; // 0x1BA
		private FontFaceHandle m_FontFaceHandle; // 0x1C0
		[SerializeField]
		private FaceInfo_Legacy m_fontInfo; // 0x1D0
		[SerializeField]
		internal List<TMP_Glyph> m_glyphInfoList; // 0x1D8
		[FormerlySerializedAs("m_kerningInfo")]
		[SerializeField]
		internal KerningTable m_KerningTable; // 0x1E0
		[SerializeField]
		private List<TMP_FontAsset> fallbackFontAssets; // 0x1E8
		[SerializeField]
		public Texture2D atlas; // 0x1F0
		private static readonly List<WeakReference<TMP_FontAsset>> s_CallbackInstances; // 0x00
		private static readonly ProfilerMarker k_ReadFontAssetDefinitionMarker; // 0x08
		private static readonly ProfilerMarker k_AddSynthesizedCharactersMarker; // 0x10
		private static readonly ProfilerMarker k_TryAddGlyphMarker; // 0x18
		private static readonly ProfilerMarker k_TryAddCharacterMarker; // 0x20
		private static readonly ProfilerMarker k_TryAddCharactersMarker; // 0x28
		private static readonly ProfilerMarker k_UpdateLigatureSubstitutionRecordsMarker; // 0x30
		private static readonly ProfilerMarker k_UpdateGlyphAdjustmentRecordsMarker; // 0x38
		private static readonly ProfilerMarker k_UpdateDiacriticalMarkAdjustmentRecordsMarker; // 0x40
		private static readonly ProfilerMarker k_ClearFontAssetDataMarker; // 0x48
		private static readonly ProfilerMarker k_UpdateFontAssetDataMarker; // 0x50
		private const string k_DefaultMaterialSuffix = " Atlas Material"; // Metadata: 0x006A1F60
		private static HashSet<EntityId> k_SearchedFontAssetLookup; // 0x58
		private static readonly List<TMP_FontAsset> k_FontAssets_FontFeaturesUpdateQueue; // 0x60
		private static readonly HashSet<EntityId> k_FontAssets_FontFeaturesUpdateQueueLookup; // 0x68
		private static readonly List<Texture2D> k_FontAssets_AtlasTexturesUpdateQueue; // 0x70
		private static readonly HashSet<EntityId> k_FontAssets_AtlasTexturesUpdateQueueLookup; // 0x78
		private List<Glyph> m_GlyphsToRender; // 0x1F8
		private List<Glyph> m_GlyphsRendered; // 0x200
		private List<uint> m_GlyphIndexList; // 0x208
		private List<uint> m_GlyphIndexListNewlyAdded; // 0x210
		internal List<uint> m_GlyphsToAdd; // 0x218
		internal HashSet<uint> m_GlyphsToAddLookup; // 0x220
		internal List<TMP_Character> m_CharactersToAdd; // 0x228
		internal HashSet<uint> m_CharactersToAddLookup; // 0x230
		internal List<uint> s_MissingCharacterList; // 0x238
		internal HashSet<uint> m_MissingUnicodesFromFontFile; // 0x240
	
		// Properties
		public FontAssetCreationSettings creationSettings { get; set; } // 0x0000000182081DB0-0x0000000182081E00 0x0000000182081F60-0x0000000182081FB0
		public Font sourceFontFile { get; internal set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000180CDC990-0x0000000180CDC9B0
		public AtlasPopulationMode atlasPopulationMode { get; set; } // 0x0000000181F63E40-0x0000000181F63E50 0x0000000182081F30-0x0000000182081F40
		internal int familyNameHashCode { get; set; } // 0x0000000182081E00-0x0000000182081E70 0x000000018033ED20-0x000000018033ED30
		internal int styleNameHashCode { get; set; } // 0x0000000182081EB0-0x0000000182081F20 0x000000018033ECD0-0x000000018033ECE0
		public List<Glyph> glyphTable { get; internal set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		public Dictionary<uint, Glyph> glyphLookupTable { get; } // 0x0000000182081E70-0x0000000182081EB0 
		public List<TMP_Character> characterTable { get; internal set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
		public Dictionary<uint, TMP_Character> characterLookupTable { get; } // 0x0000000182081D70-0x0000000182081DB0 
		public Texture2D atlasTexture { get; } // 0x0000000182081CC0-0x0000000182081D60 
		public Texture2D[] atlasTextures { get; set; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 0x0000000181D8A7C0-0x0000000181D8A7E0
		public int atlasTextureCount { get; } // 0x00000001819747F0-0x0000000181974800 
		public bool isMultiAtlasTexturesEnabled { get; set; } // 0x0000000181C4BAD0-0x0000000181C4BAE0 0x0000000181C4C290-0x0000000181C4C2A0
		public bool getFontFeatures { get; set; } // 0x0000000181C4BC10-0x0000000181C4BC20 0x0000000181C4C340-0x0000000181C4C350
		internal bool clearDynamicDataOnBuild { get; set; } // 0x0000000181C4BC30-0x0000000181C4BC40 0x0000000181C4C360-0x0000000181C4C370
		public int atlasWidth { get; internal set; } // 0x0000000182081D60-0x0000000182081D70 0x0000000182081F50-0x0000000182081F60
		public int atlasHeight { get; internal set; } // 0x0000000181C4BDD0-0x0000000181C4BDE0 0x0000000181C4C380-0x0000000181C4C390
		public int atlasPadding { get; internal set; } // 0x0000000182081CA0-0x0000000182081CB0 0x0000000182081F20-0x0000000182081F30
		public GlyphRenderMode atlasRenderMode { get; internal set; } // 0x0000000182081CB0-0x0000000182081CC0 0x0000000182081F40-0x0000000182081F50
		internal List<GlyphRect> usedGlyphRects { get; set; } // 0x0000000181974700-0x0000000181974710 0x00000001813800D0-0x00000001813800F0
		internal List<GlyphRect> freeGlyphRects { get; set; } // 0x0000000181CF6CA0-0x0000000181CF6CB0 0x00000001813800F0-0x0000000181380110
		public TMP_FontFeatureTable fontFeatureTable { get; internal set; } // 0x0000000181C4BCD0-0x0000000181C4BCE0 0x0000000181CF6CF0-0x0000000181CF6D10
		public List<TMP_FontAsset> fallbackFontAssetTable { get; set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public TMP_FontWeightPair[] fontWeightTable { get; internal set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		[Obsolete("The fontInfo property and underlying type is now obsolete. Please use the faceInfo property and FaceInfo type instead.", true)]
		public FaceInfo_Legacy fontInfo { get; } // 0x0000000181CB22D0-0x0000000181CB22E0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11815
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<TMP_Character, uint> __9__147_0; // 0x08
			public static Func<Glyph, uint> __9__148_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182095A40-0x0000000182095AB0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortCharacterTable_b__147_0(TMP_Character c); // 0x0000000182095970-0x0000000182095990
			internal uint _SortGlyphTable_b__148_0(Glyph c); // 0x000000018030F200-0x000000018030F220
		}
	
		// Constructors
		public TMP_FontAsset(); // 0x00000001820818C0-0x0000000182081CA0
		static TMP_FontAsset(); // 0x0000000182081480-0x00000001820818C0
	
		// Methods
		public static TMP_FontAsset CreateFontAsset(string familyName, string styleName, int pointSize = 90 /* Metadata: 0x006A1F48 */); // 0x0000000182078B20-0x0000000182078D50
		public static TMP_FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight); // 0x0000000182079450-0x0000000182079500
		private static TMP_FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport = true /* Metadata: 0x006A1F4A */); // 0x00000001820792A0-0x0000000182079450
		public static TMP_FontAsset CreateFontAsset(Font font); // 0x0000000182078D50-0x0000000182078F40
		public static TMP_FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic /* Metadata: 0x006A1F4B */, bool enableMultiAtlasSupport = true /* Metadata: 0x006A1F4C */); // 0x00000001820790E0-0x00000001820792A0
		private static TMP_FontAsset CreateFontAsset(Font font, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic /* Metadata: 0x006A1F4D */, bool enableMultiAtlasSupport = true /* Metadata: 0x006A1F4E */); // 0x0000000182078F40-0x00000001820790E0
		private static TMP_FontAsset CreateFontAssetInstance(Font font, FontFaceHandle faceHandle, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport); // 0x00000001820784F0-0x0000000182078B20
		private void RegisterCallbackInstance(TMP_FontAsset instance); // 0x000000018207C580-0x000000018207C8A0
		private void OnDestroy(); // 0x000000018207BCC0-0x000000018207BE10
		public void ReadFontAssetDefinition(); // 0x000000018207BE10-0x000000018207C450
		internal void InitializeDictionaryLookupTables(); // 0x000000018207ACD0-0x000000018207B120
		internal void InitializeGlyphLookupDictionary(); // 0x000000018207B120-0x000000018207B360
		internal void InitializeCharacterLookupDictionary(); // 0x000000018207AAF0-0x000000018207ACD0
		internal void ClearFallbackCharacterTable(); // 0x0000000182077FA0-0x0000000182078260
		internal void InitializeLigatureSubstitutionLookupDictionary(); // 0x000000018207B570-0x000000018207B7E0
		internal void InitializeGlyphPaidAdjustmentRecordsLookupDictionary(); // 0x000000018207B360-0x000000018207B570
		internal void InitializeMarkToBaseAdjustmentRecordsLookupDictionary(); // 0x000000018207B7E0-0x000000018207B990
		internal void InitializeMarkToMarkAdjustmentRecordsLookupDictionary(); // 0x000000018207B990-0x000000018207BB40
		internal void AddSynthesizedCharactersAndFaceMetrics(); // 0x0000000182077910-0x0000000182077B20
		private void AddSynthesizedCharacter(uint unicode, bool isFontFaceLoaded, bool addImmediately = false /* Metadata: 0x006A1F4F */); // 0x00000001820775A0-0x0000000182077910
		internal void AddCharacterToLookupCache(uint unicode, TMP_Character character, FontStyles fontStyle = FontStyles.Normal /* Metadata: 0x006A1F50 */, FontWeight fontWeight = FontWeight.Regular /* Metadata: 0x006A1F51 */, bool isAlternativeTypeface = false /* Metadata: 0x006A1F53 */); // 0x0000000182076910-0x00000001820769B0
		internal FontEngineError LoadFontFace(out FontFaceHandle faceHandle); // 0x000000018207BB40-0x000000018207BB70
		internal FontEngineError LoadFontFace(); // 0x000000018207BB70-0x000000018207BCC0
		internal void SortCharacterTable(); // 0x000000018207CF40-0x000000018207D0A0
		internal void SortGlyphTable(); // 0x000000018207D0F0-0x000000018207D250
		internal void SortFontFeatureTable(); // 0x000000018207D0A0-0x000000018207D0F0
		internal void SortAllTables(); // 0x000000018207CC80-0x000000018207CF40
		public bool HasCharacter(int character); // 0x0000000182079BB0-0x0000000182079C30
		public bool HasCharacter(char character, bool searchFallbacks = false /* Metadata: 0x006A1F54 */, bool tryAddCharacter = false /* Metadata: 0x006A1F55 */); // 0x0000000182079C30-0x000000018207A0F0
		private bool HasCharacter_Internal(uint character, bool searchFallbacks = false /* Metadata: 0x006A1F56 */, bool tryAddCharacter = false /* Metadata: 0x006A1F57 */); // 0x0000000182079950-0x0000000182079BB0
		public bool HasCharacters(string text, out List<char> missingCharacters); // 0x000000018207A0F0-0x000000018207A250
		public bool HasCharacters(string text, out uint[] missingCharacters, bool searchFallbacks = false /* Metadata: 0x006A1F58 */, bool tryAddCharacter = false /* Metadata: 0x006A1F59 */); // 0x000000018207A250-0x000000018207A910
		public bool HasCharacters(string text); // 0x000000018207A910-0x000000018207A9E0
		public static string GetCharacters(TMP_FontAsset fontAsset); // 0x00000001820796E0-0x00000001820797B0
		public static int[] GetCharactersArray(TMP_FontAsset fontAsset); // 0x0000000182079620-0x00000001820796E0
		internal uint GetGlyphIndex(uint unicode); // 0x00000001820797B0-0x00000001820798B0
		internal uint GetGlyphVariantIndex(uint unicode, uint variantSelectorUnicode); // 0x00000001820798B0-0x0000000182079950
		internal static void RegisterFontAssetForFontFeatureUpdate(TMP_FontAsset fontAsset); // 0x000000018207C8A0-0x000000018207C9F0
		internal static void UpdateFontFeaturesForFontAssetsInQueue(); // 0x0000000182080A00-0x0000000182080B40
		internal static void RegisterAtlasTextureForApply(Texture2D texture); // 0x000000018207C450-0x000000018207C580
		internal static void UpdateAtlasTexturesInQueue(); // 0x0000000182080420-0x0000000182080550
		internal static void UpdateFontAssetsInUpdateQueue(); // 0x0000000182080770-0x0000000182080A00
		public bool TryAddCharacters(uint[] unicodes, bool includeFontFeatures = false /* Metadata: 0x006A1F5A */); // 0x000000018207F2D0-0x000000018207F300
		public bool TryAddCharacters(uint[] unicodes, out uint[] missingUnicodes, bool includeFontFeatures = false /* Metadata: 0x006A1F5B */); // 0x000000018207DAD0-0x000000018207E6D0
		public bool TryAddCharacters(string characters, bool includeFontFeatures = false /* Metadata: 0x006A1F5C */); // 0x000000018207E6D0-0x000000018207E700
		public bool TryAddCharacters(string characters, out string missingCharacters, bool includeFontFeatures = false /* Metadata: 0x006A1F5D */); // 0x000000018207E700-0x000000018207F2D0
		internal bool AddGlyphInternal(uint glyphIndex); // 0x00000001820769B0-0x00000001820769D0
		internal bool TryAddGlyphInternal(uint glyphIndex, out Glyph glyph); // 0x000000018207F300-0x000000018207F9A0
		internal bool TryAddCharacterInternal(uint unicode, out TMP_Character character); // 0x000000018207D250-0x000000018207DAD0
		internal bool TryGetCharacter_and_QueueRenderToTexture(uint unicode, out TMP_Character character); // 0x000000018207FDF0-0x0000000182080280
		internal void TryAddGlyphsToAtlasTextures(); // 0x00000001802E76C0-0x00000001802E76D0
		private bool TryAddGlyphsToNewAtlasTexture(); // 0x000000018207F9A0-0x000000018207FDF0
		private void SetupNewAtlasTexture(); // 0x000000018207C9F0-0x000000018207CC80
		internal void UpdateAtlasTexture(); // 0x0000000182080280-0x0000000182080420
		private void UpdateFontFeaturesForNewlyAddedGlyphs(); // 0x0000000182080B40-0x0000000182080C00
		private void UpdateGPOSFontFeaturesForNewlyAddedGlyphs(); // 0x0000000182080C00-0x0000000182080C40
		internal void ImportFontFeatures(); // 0x000000018207A9E0-0x000000018207AAF0
		private void UpdateGSUBFontFeaturesForNewGlyphIndex(uint glyphIndex); // 0x0000000182080C40-0x0000000182080CD0
		internal void UpdateLigatureSubstitutionRecords(); // 0x0000000182080FE0-0x0000000182081070
		private void AddLigatureSubstitutionRecords(LigatureSubstitutionRecord[] records); // 0x00000001820769D0-0x0000000182076E30
		internal void UpdateGlyphAdjustmentRecords(); // 0x0000000182080CD0-0x0000000182080D60
		private void AddPairAdjustmentRecords(GlyphPairAdjustmentRecord[] records); // 0x00000001820772F0-0x00000001820775A0
		internal void UpdateGlyphAdjustmentRecords(uint[] glyphIndexes); // 0x0000000182080D60-0x0000000182080FE0
		internal void UpdateDiacriticalMarkAdjustmentRecords(); // 0x0000000182080550-0x0000000182080610
		private void AddMarkToBaseAdjustmentRecords(MarkToBaseAdjustmentRecord[] records); // 0x0000000182076E30-0x0000000182077090
		private void AddMarkToMarkAdjustmentRecords(MarkToMarkAdjustmentRecord[] records); // 0x0000000182077090-0x00000001820772F0
		private void CopyListDataToArray<T>(List<T> srcList, ref ref T[] dstArray);
		internal void UpdateFontAssetData(); // 0x0000000182080610-0x0000000182080770
		public void ClearFontAssetData(bool setAtlasSizeToZero = false /* Metadata: 0x006A1F5E */); // 0x0000000182078260-0x0000000182078410
		internal void ClearCharacterAndGlyphTablesInternal(); // 0x0000000182077D90-0x0000000182077DC0
		internal void ClearFontFeaturesInternal(); // 0x0000000182078410-0x0000000182078430
		private void ClearCharacterAndGlyphTables(); // 0x0000000182077DC0-0x0000000182077FA0
		private void ClearFontFeaturesTables(); // 0x0000000182078430-0x00000001820784F0
		internal void ClearAtlasTextures(bool setAtlasSizeToZero = false /* Metadata: 0x006A1F5F */); // 0x0000000182077B20-0x0000000182077D90
		private void DestroyAtlasTextures(); // 0x0000000182079500-0x0000000182079620
		private void UpgradeGlyphAdjustmentTableToFontFeatureTable(); // 0x0000000182081070-0x0000000182081480
	}
}
