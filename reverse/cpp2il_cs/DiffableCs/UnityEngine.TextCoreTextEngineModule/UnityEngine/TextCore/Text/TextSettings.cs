namespace UnityEngine.TextCore.Text;

[ExcludeFromObjectFactory]
[ExcludeFromPreset]
public class TextSettings : ScriptableObject
{
	private struct FontReferenceMap
	{
		public Font font; //Field offset: 0x0
		public FontAsset fontAsset; //Field offset: 0x8

		public FontReferenceMap(Font font, FontAsset fontAsset) { }

	}

	private static List<FontAsset> s_FallbackOSFontAssetInternal; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static SpriteAsset <s_GlobalSpriteAsset>k__BackingField; //Field offset: 0x8
	[SerializeField]
	protected string m_Version; //Field offset: 0x18
	[FormerlySerializedAs("m_defaultFontAsset")]
	[SerializeField]
	protected FontAsset m_DefaultFontAsset; //Field offset: 0x20
	[FormerlySerializedAs("m_defaultFontAssetPath")]
	[SerializeField]
	protected string m_DefaultFontAssetPath; //Field offset: 0x28
	[FormerlySerializedAs("m_fallbackFontAssets")]
	[SerializeField]
	protected List<FontAsset> m_FallbackFontAssets; //Field offset: 0x30
	[FormerlySerializedAs("m_matchMaterialPreset")]
	[SerializeField]
	protected bool m_MatchMaterialPreset; //Field offset: 0x38
	[FormerlySerializedAs("m_missingGlyphCharacter")]
	[SerializeField]
	protected int m_MissingCharacterUnicode; //Field offset: 0x3C
	[SerializeField]
	protected bool m_ClearDynamicDataOnBuild; //Field offset: 0x40
	[SerializeField]
	private bool m_EnableEmojiSupport; //Field offset: 0x41
	[SerializeField]
	private List<TextAsset> m_EmojiFallbackTextAssets; //Field offset: 0x48
	[FormerlySerializedAs("m_defaultSpriteAsset")]
	[SerializeField]
	protected SpriteAsset m_DefaultSpriteAsset; //Field offset: 0x50
	[FormerlySerializedAs("m_defaultSpriteAssetPath")]
	[SerializeField]
	protected string m_DefaultSpriteAssetPath; //Field offset: 0x58
	[SerializeField]
	protected List<SpriteAsset> m_FallbackSpriteAssets; //Field offset: 0x60
	[SerializeField]
	protected uint m_MissingSpriteCharacterUnicode; //Field offset: 0x68
	[FormerlySerializedAs("m_defaultStyleSheet")]
	[SerializeField]
	protected TextStyleSheet m_DefaultStyleSheet; //Field offset: 0x70
	[SerializeField]
	protected string m_StyleSheetsResourcePath; //Field offset: 0x78
	[FormerlySerializedAs("m_defaultColorGradientPresetsPath")]
	[SerializeField]
	protected string m_DefaultColorGradientPresetsPath; //Field offset: 0x80
	[SerializeField]
	protected UnicodeLineBreakingRules m_UnicodeLineBreakingRules; //Field offset: 0x88
	[FormerlySerializedAs("m_warningsDisabled")]
	[SerializeField]
	protected bool m_DisplayWarnings; //Field offset: 0x90
	internal Dictionary<Int32, FontAsset> m_FontLookup; //Field offset: 0x98
	private List<FontReferenceMap> m_FontReferences; //Field offset: 0xA0

	public bool clearDynamicDataOnBuild
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public string defaultColorGradientPresetsPath
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public FontAsset defaultFontAsset
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string defaultFontAssetPath
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public SpriteAsset defaultSpriteAsset
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string defaultSpriteAssetPath
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public TextStyleSheet defaultStyleSheet
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool displayWarnings
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public List<TextAsset> emojiFallbackTextAssets
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool enableEmojiSupport
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public List<FontAsset> fallbackFontAssets
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	internal List<FontAsset> fallbackOSFontAssets
	{
		internal get { } //Length: 217
	}

	[Obsolete("The Fallback Sprite Assets list is now obsolete. Use the emojiFallbackTextAssets instead.", True)]
	public List<SpriteAsset> fallbackSpriteAssets
	{
		 get { } //Length: 694
		 set { } //Length: 13
	}

	public UnicodeLineBreakingRules lineBreakingRules
	{
		 get { } //Length: 141
		 set { } //Length: 19
	}

	public bool matchMaterialPreset
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public int missingCharacterUnicode
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public uint missingSpriteCharacterUnicode
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	internal static SpriteAsset s_GlobalSpriteAsset
	{
		[CompilerGenerated]
		internal get { } //Length: 55
		[CompilerGenerated]
		private set { } //Length: 86
	}

	public string styleSheetsResourcePath
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public internal string version
	{
		 get { } //Length: 5
		internal set { } //Length: 13
	}

	public TextSettings() { }

	public bool get_clearDynamicDataOnBuild() { }

	public string get_defaultColorGradientPresetsPath() { }

	public FontAsset get_defaultFontAsset() { }

	public string get_defaultFontAssetPath() { }

	public SpriteAsset get_defaultSpriteAsset() { }

	public string get_defaultSpriteAssetPath() { }

	public TextStyleSheet get_defaultStyleSheet() { }

	public bool get_displayWarnings() { }

	public List<TextAsset> get_emojiFallbackTextAssets() { }

	public bool get_enableEmojiSupport() { }

	public List<FontAsset> get_fallbackFontAssets() { }

	internal List<FontAsset> get_fallbackOSFontAssets() { }

	public List<SpriteAsset> get_fallbackSpriteAssets() { }

	public UnicodeLineBreakingRules get_lineBreakingRules() { }

	public bool get_matchMaterialPreset() { }

	public int get_missingCharacterUnicode() { }

	public uint get_missingSpriteCharacterUnicode() { }

	[CompilerGenerated]
	internal static SpriteAsset get_s_GlobalSpriteAsset() { }

	public string get_styleSheetsResourcePath() { }

	public string get_version() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule"})]
	internal FontAsset GetCachedFontAsset(Font font, Shader shader) { }

	protected FontAsset GetCachedFontAssetInternal(Font font) { }

	internal override List<FontAsset> GetFallbackFontAssets(int textPixelSize = -1) { }

	internal override Shader GetFontShader() { }

	private List<FontAsset> GetOSFontAssetList() { }

	internal override List<FontAsset> GetStaticFallbackOSFontAsset() { }

	protected void InitializeFontReferenceLookup() { }

	private void OnEnable() { }

	public void set_clearDynamicDataOnBuild(bool value) { }

	public void set_defaultColorGradientPresetsPath(string value) { }

	public void set_defaultFontAsset(FontAsset value) { }

	public void set_defaultFontAssetPath(string value) { }

	public void set_defaultSpriteAsset(SpriteAsset value) { }

	public void set_defaultSpriteAssetPath(string value) { }

	public void set_defaultStyleSheet(TextStyleSheet value) { }

	public void set_displayWarnings(bool value) { }

	public void set_emojiFallbackTextAssets(List<TextAsset> value) { }

	public void set_enableEmojiSupport(bool value) { }

	public void set_fallbackFontAssets(List<FontAsset> value) { }

	public void set_fallbackSpriteAssets(List<SpriteAsset> value) { }

	public void set_lineBreakingRules(UnicodeLineBreakingRules value) { }

	public void set_matchMaterialPreset(bool value) { }

	public void set_missingCharacterUnicode(int value) { }

	public void set_missingSpriteCharacterUnicode(uint value) { }

	[CompilerGenerated]
	private static void set_s_GlobalSpriteAsset(SpriteAsset value) { }

	public void set_styleSheetsResourcePath(string value) { }

	internal void set_version(string value) { }

	internal override void SetStaticFallbackOSFontAsset(List<FontAsset> fontAssets) { }

}

