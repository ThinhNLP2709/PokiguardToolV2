namespace TMPro;

[ExcludeFromPreset]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/TextMeshPro/Sprites.html")]
public class TMP_SpriteAsset : TMP_Asset
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<TMP_SpriteGlyph, UInt32> <>9__32_0; //Field offset: 0x8
		public static Func<TMP_SpriteCharacter, UInt32> <>9__33_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal uint <SortCharacterTable>b__33_0(TMP_SpriteCharacter c) { }

		internal uint <SortGlyphTable>b__32_0(TMP_SpriteGlyph item) { }

	}

	private static HashSet<Int32> k_searchedSpriteAssets; //Field offset: 0x0
	internal Dictionary<Int32, Int32> m_NameLookup; //Field offset: 0x98
	internal Dictionary<UInt32, Int32> m_GlyphIndexLookup; //Field offset: 0xA0
	public Texture spriteSheet; //Field offset: 0xA8
	[SerializeField]
	private List<TMP_SpriteCharacter> m_SpriteCharacterTable; //Field offset: 0xB0
	internal Dictionary<UInt32, TMP_SpriteCharacter> m_SpriteCharacterLookup; //Field offset: 0xB8
	[FormerlySerializedAs("m_SpriteGlyphTable")]
	[SerializeField]
	private List<TMP_SpriteGlyph> m_GlyphTable; //Field offset: 0xC0
	internal Dictionary<UInt32, TMP_SpriteGlyph> m_SpriteGlyphLookup; //Field offset: 0xC8
	public List<TMP_Sprite> spriteInfoList; //Field offset: 0xD0
	[SerializeField]
	public List<TMP_SpriteAsset> fallbackSpriteAssets; //Field offset: 0xD8
	internal bool m_IsSpriteAssetLookupTablesDirty; //Field offset: 0xE0

	public internal Dictionary<UInt32, TMP_SpriteCharacter> spriteCharacterLookupTable
	{
		 get { } //Length: 52
		internal set { } //Length: 19
	}

	public internal List<TMP_SpriteCharacter> spriteCharacterTable
	{
		 get { } //Length: 52
		internal set { } //Length: 19
	}

	public internal List<TMP_SpriteGlyph> spriteGlyphTable
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	public TMP_SpriteAsset() { }

	private void Awake() { }

	public Dictionary<UInt32, TMP_SpriteCharacter> get_spriteCharacterLookupTable() { }

	public List<TMP_SpriteCharacter> get_spriteCharacterTable() { }

	public List<TMP_SpriteGlyph> get_spriteGlyphTable() { }

	private Material GetDefaultSpriteMaterial() { }

	public int GetSpriteIndexFromHashcode(int hashCode) { }

	public int GetSpriteIndexFromName(string name) { }

	public int GetSpriteIndexFromUnicode(uint unicode) { }

	public static TMP_SpriteAsset SearchForSpriteByHashCode(TMP_SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(List<TMP_SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(TMP_SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, out int spriteIndex) { }

	public static TMP_SpriteAsset SearchForSpriteByUnicode(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(List<TMP_SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, out int spriteIndex) { }

	internal void set_spriteCharacterLookupTable(Dictionary<UInt32, TMP_SpriteCharacter> value) { }

	internal void set_spriteCharacterTable(List<TMP_SpriteCharacter> value) { }

	internal void set_spriteGlyphTable(List<TMP_SpriteGlyph> value) { }

	internal void SortCharacterTable() { }

	internal void SortGlyphAndCharacterTables() { }

	public void SortGlyphTable() { }

	public void UpdateLookupTables() { }

	private void UpgradeSpriteAsset() { }

}

