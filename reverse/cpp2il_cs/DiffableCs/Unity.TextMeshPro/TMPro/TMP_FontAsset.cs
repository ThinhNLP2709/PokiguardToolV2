namespace TMPro;

[ExcludeFromPreset]
public class TMP_FontAsset : TMP_Asset
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<TMP_Character, UInt32> <>9__145_0; //Field offset: 0x8
		public static Func<Glyph, UInt32> <>9__146_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal uint <SortCharacterTable>b__145_0(TMP_Character c) { }

		internal uint <SortGlyphTable>b__146_0(Glyph c) { }

	}

	private static readonly List<WeakReference`1<TMP_FontAsset>> s_CallbackInstances; //Field offset: 0x0
	private static ProfilerMarker k_ReadFontAssetDefinitionMarker; //Field offset: 0x8
	private static ProfilerMarker k_AddSynthesizedCharactersMarker; //Field offset: 0x10
	private static ProfilerMarker k_TryAddGlyphMarker; //Field offset: 0x18
	private static ProfilerMarker k_TryAddCharacterMarker; //Field offset: 0x20
	private static ProfilerMarker k_TryAddCharactersMarker; //Field offset: 0x28
	private static ProfilerMarker k_UpdateLigatureSubstitutionRecordsMarker; //Field offset: 0x30
	private static ProfilerMarker k_UpdateGlyphAdjustmentRecordsMarker; //Field offset: 0x38
	private static ProfilerMarker k_UpdateDiacriticalMarkAdjustmentRecordsMarker; //Field offset: 0x40
	private static ProfilerMarker k_ClearFontAssetDataMarker; //Field offset: 0x48
	private static ProfilerMarker k_UpdateFontAssetDataMarker; //Field offset: 0x50
	private static string s_DefaultMaterialSuffix; //Field offset: 0x58
	private static HashSet<Int32> k_SearchedFontAssetLookup; //Field offset: 0x60
	private static List<TMP_FontAsset> k_FontAssets_FontFeaturesUpdateQueue; //Field offset: 0x68
	private static HashSet<Int32> k_FontAssets_FontFeaturesUpdateQueueLookup; //Field offset: 0x70
	private static List<Texture2D> k_FontAssets_AtlasTexturesUpdateQueue; //Field offset: 0x78
	private static HashSet<Int32> k_FontAssets_AtlasTexturesUpdateQueueLookup; //Field offset: 0x80
	internal static UInt32[] k_GlyphIndexArray; //Field offset: 0x88
	[SerializeField]
	internal string m_SourceFontFileGUID; //Field offset: 0x98
	[SerializeField]
	internal FontAssetCreationSettings m_CreationSettings; //Field offset: 0xA0
	[SerializeField]
	private Font m_SourceFontFile; //Field offset: 0x100
	[SerializeField]
	private string m_SourceFontFilePath; //Field offset: 0x108
	[SerializeField]
	private AtlasPopulationMode m_AtlasPopulationMode; //Field offset: 0x110
	[SerializeField]
	internal bool InternalDynamicOS; //Field offset: 0x114
	private int m_FamilyNameHashCode; //Field offset: 0x118
	private int m_StyleNameHashCode; //Field offset: 0x11C
	[SerializeField]
	internal List<Glyph> m_GlyphTable; //Field offset: 0x120
	internal Dictionary<UInt32, Glyph> m_GlyphLookupDictionary; //Field offset: 0x128
	[SerializeField]
	internal List<TMP_Character> m_CharacterTable; //Field offset: 0x130
	internal Dictionary<UInt32, TMP_Character> m_CharacterLookupDictionary; //Field offset: 0x138
	internal Texture2D m_AtlasTexture; //Field offset: 0x140
	[SerializeField]
	internal Texture2D[] m_AtlasTextures; //Field offset: 0x148
	[SerializeField]
	internal int m_AtlasTextureIndex; //Field offset: 0x150
	[SerializeField]
	private bool m_IsMultiAtlasTexturesEnabled; //Field offset: 0x154
	[SerializeField]
	private bool m_GetFontFeatures; //Field offset: 0x155
	[SerializeField]
	private bool m_ClearDynamicDataOnBuild; //Field offset: 0x156
	[SerializeField]
	internal int m_AtlasWidth; //Field offset: 0x158
	[SerializeField]
	internal int m_AtlasHeight; //Field offset: 0x15C
	[SerializeField]
	internal int m_AtlasPadding; //Field offset: 0x160
	[SerializeField]
	internal GlyphRenderMode m_AtlasRenderMode; //Field offset: 0x164
	[SerializeField]
	private List<GlyphRect> m_UsedGlyphRects; //Field offset: 0x168
	[SerializeField]
	private List<GlyphRect> m_FreeGlyphRects; //Field offset: 0x170
	[SerializeField]
	internal TMP_FontFeatureTable m_FontFeatureTable; //Field offset: 0x178
	[SerializeField]
	internal bool m_ShouldReimportFontFeatures; //Field offset: 0x180
	[SerializeField]
	internal List<TMP_FontAsset> m_FallbackFontAssetTable; //Field offset: 0x188
	[SerializeField]
	private TMP_FontWeightPair[] m_FontWeightTable; //Field offset: 0x190
	[SerializeField]
	private TMP_FontWeightPair[] fontWeights; //Field offset: 0x198
	public float normalStyle; //Field offset: 0x1A0
	public float normalSpacingOffset; //Field offset: 0x1A4
	public float boldStyle; //Field offset: 0x1A8
	public float boldSpacing; //Field offset: 0x1AC
	public byte italicStyle; //Field offset: 0x1B0
	public byte tabSize; //Field offset: 0x1B1
	internal bool IsFontAssetLookupTablesDirty; //Field offset: 0x1B2
	[SerializeField]
	private FaceInfo_Legacy m_fontInfo; //Field offset: 0x1B8
	[SerializeField]
	internal List<TMP_Glyph> m_glyphInfoList; //Field offset: 0x1C0
	[FormerlySerializedAs("m_kerningInfo")]
	[SerializeField]
	internal KerningTable m_KerningTable; //Field offset: 0x1C8
	[SerializeField]
	private List<TMP_FontAsset> fallbackFontAssets; //Field offset: 0x1D0
	[SerializeField]
	public Texture2D atlas; //Field offset: 0x1D8
	private List<Glyph> m_GlyphsToRender; //Field offset: 0x1E0
	private List<Glyph> m_GlyphsRendered; //Field offset: 0x1E8
	private List<UInt32> m_GlyphIndexList; //Field offset: 0x1F0
	private List<UInt32> m_GlyphIndexListNewlyAdded; //Field offset: 0x1F8
	internal List<UInt32> m_GlyphsToAdd; //Field offset: 0x200
	internal HashSet<UInt32> m_GlyphsToAddLookup; //Field offset: 0x208
	internal List<TMP_Character> m_CharactersToAdd; //Field offset: 0x210
	internal HashSet<UInt32> m_CharactersToAddLookup; //Field offset: 0x218
	internal List<UInt32> s_MissingCharacterList; //Field offset: 0x220
	internal HashSet<UInt32> m_MissingUnicodesFromFontFile; //Field offset: 0x228

	public internal int atlasHeight
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public internal int atlasPadding
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public AtlasPopulationMode atlasPopulationMode
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public internal GlyphRenderMode atlasRenderMode
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public Texture2D atlasTexture
	{
		 get { } //Length: 156
	}

	public int atlasTextureCount
	{
		 get { } //Length: 9
	}

	public Texture2D[] atlasTextures
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public internal int atlasWidth
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public Dictionary<UInt32, TMP_Character> characterLookupTable
	{
		 get { } //Length: 52
	}

	public internal List<TMP_Character> characterTable
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	internal bool clearDynamicDataOnBuild
	{
		internal get { } //Length: 8
		internal set { } //Length: 7
	}

	public FontAssetCreationSettings creationSettings
	{
		 get { } //Length: 69
		 set { } //Length: 79
	}

	public List<TMP_FontAsset> fallbackFontAssetTable
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	internal int familyNameHashCode
	{
		internal get { } //Length: 119
		internal set { } //Length: 7
	}

	public internal TMP_FontFeatureTable fontFeatureTable
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	[Obsolete("The fontInfo property and underlying type is now obsolete. Please use the faceInfo property and FaceInfo type instead.")]
	public FaceInfo_Legacy fontInfo
	{
		 get { } //Length: 8
	}

	public internal TMP_FontWeightPair[] fontWeightTable
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	internal List<GlyphRect> freeGlyphRects
	{
		internal get { } //Length: 8
		internal set { } //Length: 19
	}

	public bool getFontFeatures
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public Dictionary<UInt32, Glyph> glyphLookupTable
	{
		 get { } //Length: 52
	}

	public internal List<Glyph> glyphTable
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	public bool isMultiAtlasTexturesEnabled
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public internal Font sourceFontFile
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	internal int styleNameHashCode
	{
		internal get { } //Length: 119
		internal set { } //Length: 7
	}

	internal List<GlyphRect> usedGlyphRects
	{
		internal get { } //Length: 8
		internal set { } //Length: 19
	}

	private static TMP_FontAsset() { }

	public TMP_FontAsset() { }

	internal void AddCharacterToLookupCache(uint unicode, TMP_Character character) { }

	internal bool AddGlyphInternal(uint glyphIndex) { }

	private void AddLigatureSubstitutionRecords(LigatureSubstitutionRecord[] records) { }

	private void AddMarkToBaseAdjustmentRecords(MarkToBaseAdjustmentRecord[] records) { }

	private void AddMarkToMarkAdjustmentRecords(MarkToMarkAdjustmentRecord[] records) { }

	private void AddPairAdjustmentRecords(GlyphPairAdjustmentRecord[] records) { }

	private void AddSynthesizedCharacter(uint unicode, bool isFontFaceLoaded, bool addImmediately = false) { }

	internal void AddSynthesizedCharactersAndFaceMetrics() { }

	internal void ClearAtlasTextures(bool setAtlasSizeToZero = false) { }

	private void ClearCharacterAndGlyphTables() { }

	internal void ClearCharacterAndGlyphTablesInternal() { }

	internal void ClearFallbackCharacterTable() { }

	public void ClearFontAssetData(bool setAtlasSizeToZero = false) { }

	internal void ClearFontFeaturesInternal() { }

	private void ClearFontFeaturesTables() { }

	private void CopyListDataToArray(List<T> srcList, ref T[] dstArray) { }

	private static TMP_FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport = true) { }

	public static TMP_FontAsset CreateFontAsset(Font font) { }

	public static TMP_FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = 1, bool enableMultiAtlasSupport = true) { }

	private static TMP_FontAsset CreateFontAsset(Font font, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = 1, bool enableMultiAtlasSupport = true) { }

	public static TMP_FontAsset CreateFontAsset(string familyName, string styleName, int pointSize = 90) { }

	public static TMP_FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight) { }

	private static TMP_FontAsset CreateFontAssetInstance(Font font, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport) { }

	private void DestroyAtlasTextures() { }

	public int get_atlasHeight() { }

	public int get_atlasPadding() { }

	public AtlasPopulationMode get_atlasPopulationMode() { }

	public GlyphRenderMode get_atlasRenderMode() { }

	public Texture2D get_atlasTexture() { }

	public int get_atlasTextureCount() { }

	public Texture2D[] get_atlasTextures() { }

	public int get_atlasWidth() { }

	public Dictionary<UInt32, TMP_Character> get_characterLookupTable() { }

	public List<TMP_Character> get_characterTable() { }

	internal bool get_clearDynamicDataOnBuild() { }

	public FontAssetCreationSettings get_creationSettings() { }

	public List<TMP_FontAsset> get_fallbackFontAssetTable() { }

	internal int get_familyNameHashCode() { }

	public TMP_FontFeatureTable get_fontFeatureTable() { }

	public FaceInfo_Legacy get_fontInfo() { }

	public TMP_FontWeightPair[] get_fontWeightTable() { }

	internal List<GlyphRect> get_freeGlyphRects() { }

	public bool get_getFontFeatures() { }

	public Dictionary<UInt32, Glyph> get_glyphLookupTable() { }

	public List<Glyph> get_glyphTable() { }

	public bool get_isMultiAtlasTexturesEnabled() { }

	public Font get_sourceFontFile() { }

	internal int get_styleNameHashCode() { }

	internal List<GlyphRect> get_usedGlyphRects() { }

	public static string GetCharacters(TMP_FontAsset fontAsset) { }

	public static Int32[] GetCharactersArray(TMP_FontAsset fontAsset) { }

	internal uint GetGlyphIndex(uint unicode) { }

	internal uint GetGlyphVariantIndex(uint unicode, uint variantSelectorUnicode) { }

	public bool HasCharacter(int character) { }

	public bool HasCharacter(char character, bool searchFallbacks = false, bool tryAddCharacter = false) { }

	private bool HasCharacter_Internal(uint character, bool searchFallbacks = false, bool tryAddCharacter = false) { }

	public bool HasCharacters(string text, out List<Char>& missingCharacters) { }

	public bool HasCharacters(string text, out UInt32[] missingCharacters, bool searchFallbacks = false, bool tryAddCharacter = false) { }

	public bool HasCharacters(string text) { }

	internal void ImportFontFeatures() { }

	internal void InitializeCharacterLookupDictionary() { }

	internal void InitializeDictionaryLookupTables() { }

	internal void InitializeGlyphLookupDictionary() { }

	internal void InitializeGlyphPaidAdjustmentRecordsLookupDictionary() { }

	internal void InitializeLigatureSubstitutionLookupDictionary() { }

	internal void InitializeMarkToBaseAdjustmentRecordsLookupDictionary() { }

	internal void InitializeMarkToMarkAdjustmentRecordsLookupDictionary() { }

	private FontEngineError LoadFontFace() { }

	private void OnDestroy() { }

	public void ReadFontAssetDefinition() { }

	internal static void RegisterAtlasTextureForApply(Texture2D texture) { }

	private void RegisterCallbackInstance(TMP_FontAsset instance) { }

	internal static void RegisterFontAssetForFontFeatureUpdate(TMP_FontAsset fontAsset) { }

	internal void set_atlasHeight(int value) { }

	internal void set_atlasPadding(int value) { }

	public void set_atlasPopulationMode(AtlasPopulationMode value) { }

	internal void set_atlasRenderMode(GlyphRenderMode value) { }

	public void set_atlasTextures(Texture2D[] value) { }

	internal void set_atlasWidth(int value) { }

	internal void set_characterTable(List<TMP_Character> value) { }

	internal void set_clearDynamicDataOnBuild(bool value) { }

	public void set_creationSettings(FontAssetCreationSettings value) { }

	public void set_fallbackFontAssetTable(List<TMP_FontAsset> value) { }

	internal void set_familyNameHashCode(int value) { }

	internal void set_fontFeatureTable(TMP_FontFeatureTable value) { }

	internal void set_fontWeightTable(TMP_FontWeightPair[] value) { }

	internal void set_freeGlyphRects(List<GlyphRect> value) { }

	public void set_getFontFeatures(bool value) { }

	internal void set_glyphTable(List<Glyph> value) { }

	public void set_isMultiAtlasTexturesEnabled(bool value) { }

	internal void set_sourceFontFile(Font value) { }

	internal void set_styleNameHashCode(int value) { }

	internal void set_usedGlyphRects(List<GlyphRect> value) { }

	private void SetupNewAtlasTexture() { }

	internal void SortAllTables() { }

	internal void SortCharacterTable() { }

	internal void SortFontFeatureTable() { }

	internal void SortGlyphTable() { }

	internal bool TryAddCharacterInternal(uint unicode, out TMP_Character character) { }

	public bool TryAddCharacters(UInt32[] unicodes, out UInt32[] missingUnicodes, bool includeFontFeatures = false) { }

	public bool TryAddCharacters(UInt32[] unicodes, bool includeFontFeatures = false) { }

	public bool TryAddCharacters(string characters, bool includeFontFeatures = false) { }

	public bool TryAddCharacters(string characters, out string missingCharacters, bool includeFontFeatures = false) { }

	internal bool TryAddGlyphInternal(uint glyphIndex, out Glyph glyph) { }

	internal void TryAddGlyphsToAtlasTextures() { }

	private bool TryAddGlyphsToNewAtlasTexture() { }

	internal bool TryGetCharacter_and_QueueRenderToTexture(uint unicode, out TMP_Character character) { }

	internal void UpdateAtlasTexture() { }

	internal static void UpdateAtlasTexturesInQueue() { }

	internal void UpdateDiacriticalMarkAdjustmentRecords() { }

	internal void UpdateFontAssetData() { }

	internal static void UpdateFontAssetsInUpdateQueue() { }

	internal static void UpdateFontFeaturesForFontAssetsInQueue() { }

	private void UpdateFontFeaturesForNewlyAddedGlyphs() { }

	internal void UpdateGlyphAdjustmentRecords(UInt32[] glyphIndexes) { }

	internal void UpdateGlyphAdjustmentRecords() { }

	private void UpdateGPOSFontFeaturesForNewlyAddedGlyphs() { }

	private void UpdateGSUBFontFeaturesForNewGlyphIndex(uint glyphIndex) { }

	internal void UpdateLigatureSubstitutionRecords() { }

	private void UpgradeGlyphAdjustmentTableToFontFeatureTable() { }

}

