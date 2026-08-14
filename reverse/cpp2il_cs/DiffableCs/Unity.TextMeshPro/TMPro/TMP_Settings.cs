namespace TMPro;

[ExcludeFromPreset]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/TextMeshPro/Settings.html")]
public class TMP_Settings : ScriptableObject
{
	internal class LineBreakingTable
	{
		public HashSet<UInt32> leadingCharacters; //Field offset: 0x10
		public HashSet<UInt32> followingCharacters; //Field offset: 0x18

		public LineBreakingTable() { }

	}

	private static TMP_Settings s_Instance; //Field offset: 0x0
	internal static string s_CurrentAssetVersion; //Field offset: 0x8
	[SerializeField]
	internal string assetVersion; //Field offset: 0x18
	[FormerlySerializedAs("m_enableWordWrapping")]
	[SerializeField]
	private TextWrappingModes m_TextWrappingMode; //Field offset: 0x20
	[SerializeField]
	private bool m_enableKerning; //Field offset: 0x24
	[SerializeField]
	private List<OTL_FeatureTag> m_ActiveFontFeatures; //Field offset: 0x28
	[SerializeField]
	private bool m_enableExtraPadding; //Field offset: 0x30
	[SerializeField]
	private bool m_enableTintAllSprites; //Field offset: 0x31
	[SerializeField]
	private bool m_enableParseEscapeCharacters; //Field offset: 0x32
	[SerializeField]
	private bool m_EnableRaycastTarget; //Field offset: 0x33
	[SerializeField]
	private bool m_GetFontFeaturesAtRuntime; //Field offset: 0x34
	[SerializeField]
	private int m_missingGlyphCharacter; //Field offset: 0x38
	[SerializeField]
	private bool m_ClearDynamicDataOnBuild; //Field offset: 0x3C
	[SerializeField]
	private bool m_warningsDisabled; //Field offset: 0x3D
	[SerializeField]
	private TMP_FontAsset m_defaultFontAsset; //Field offset: 0x40
	[SerializeField]
	private string m_defaultFontAssetPath; //Field offset: 0x48
	[SerializeField]
	private float m_defaultFontSize; //Field offset: 0x50
	[SerializeField]
	private float m_defaultAutoSizeMinRatio; //Field offset: 0x54
	[SerializeField]
	private float m_defaultAutoSizeMaxRatio; //Field offset: 0x58
	[SerializeField]
	private Vector2 m_defaultTextMeshProTextContainerSize; //Field offset: 0x5C
	[SerializeField]
	private Vector2 m_defaultTextMeshProUITextContainerSize; //Field offset: 0x64
	[SerializeField]
	private bool m_autoSizeTextContainer; //Field offset: 0x6C
	[SerializeField]
	private bool m_IsTextObjectScaleStatic; //Field offset: 0x6D
	[SerializeField]
	private List<TMP_FontAsset> m_fallbackFontAssets; //Field offset: 0x70
	[SerializeField]
	private bool m_matchMaterialPreset; //Field offset: 0x78
	[SerializeField]
	private bool m_HideSubTextObjects; //Field offset: 0x79
	[SerializeField]
	private TMP_SpriteAsset m_defaultSpriteAsset; //Field offset: 0x80
	[SerializeField]
	private string m_defaultSpriteAssetPath; //Field offset: 0x88
	[SerializeField]
	private bool m_enableEmojiSupport; //Field offset: 0x90
	[SerializeField]
	private uint m_MissingCharacterSpriteUnicode; //Field offset: 0x94
	[SerializeField]
	private List<TMP_Asset> m_EmojiFallbackTextAssets; //Field offset: 0x98
	[SerializeField]
	private string m_defaultColorGradientPresetsPath; //Field offset: 0xA0
	[SerializeField]
	private TMP_StyleSheet m_defaultStyleSheet; //Field offset: 0xA8
	[SerializeField]
	private string m_StyleSheetsResourcePath; //Field offset: 0xB0
	[SerializeField]
	private TextAsset m_leadingCharacters; //Field offset: 0xB8
	[SerializeField]
	private TextAsset m_followingCharacters; //Field offset: 0xC0
	[SerializeField]
	private LineBreakingTable m_linebreakingRules; //Field offset: 0xC8
	[SerializeField]
	private bool m_UseModernHangulLineBreakingRules; //Field offset: 0xD0

	public static bool autoSizeTextContainer
	{
		 get { } //Length: 79
	}

	public static bool clearDynamicDataOnBuild
	{
		 get { } //Length: 79
	}

	public static string defaultColorGradientPresetsPath
	{
		 get { } //Length: 82
	}

	public static TMP_FontAsset defaultFontAsset
	{
		 get { } //Length: 79
		 set { } //Length: 96
	}

	public static string defaultFontAssetPath
	{
		 get { } //Length: 79
	}

	public static float defaultFontSize
	{
		 get { } //Length: 80
	}

	public static TMP_SpriteAsset defaultSpriteAsset
	{
		 get { } //Length: 82
		 set { } //Length: 102
	}

	public static string defaultSpriteAssetPath
	{
		 get { } //Length: 82
	}

	public static TMP_StyleSheet defaultStyleSheet
	{
		 get { } //Length: 82
		 set { } //Length: 102
	}

	public static float defaultTextAutoSizingMaxRatio
	{
		 get { } //Length: 80
	}

	public static float defaultTextAutoSizingMinRatio
	{
		 get { } //Length: 80
	}

	public static Vector2 defaultTextMeshProTextContainerSize
	{
		 get { } //Length: 93
	}

	public static Vector2 defaultTextMeshProUITextContainerSize
	{
		 get { } //Length: 93
	}

	public static List<TMP_Asset> emojiFallbackTextAssets
	{
		 get { } //Length: 82
		 set { } //Length: 102
	}

	public static bool enableEmojiSupport
	{
		 get { } //Length: 82
		 set { } //Length: 87
	}

	public static bool enableExtraPadding
	{
		 get { } //Length: 79
	}

	[Obsolete("The \"enableKerning\" property has been deprecated. Use the \"fontFeatures\" property to control what features are enabled by default on newly created text components.")]
	public static bool enableKerning
	{
		 get { } //Length: 187
	}

	public static bool enableParseEscapeCharacters
	{
		 get { } //Length: 79
	}

	public static bool enableRaycastTarget
	{
		 get { } //Length: 79
	}

	public static bool enableTintAllSprites
	{
		 get { } //Length: 79
	}

	public static List<TMP_FontAsset> fallbackFontAssets
	{
		 get { } //Length: 79
		 set { } //Length: 96
	}

	public static TextAsset followingCharacters
	{
		 get { } //Length: 82
	}

	public static List<OTL_FeatureTag> fontFeatures
	{
		 get { } //Length: 79
	}

	public static bool getFontFeaturesAtRuntime
	{
		 get { } //Length: 79
	}

	public static bool hideSubTextObjects
	{
		 get { } //Length: 79
	}

	public static TMP_Settings instance
	{
		 get { } //Length: 714
	}

	public static bool isTextObjectScaleStatic
	{
		 get { } //Length: 79
		 set { } //Length: 84
	}

	internal static bool isTMPSettingsNull
	{
		internal get { } //Length: 126
	}

	public static TextAsset leadingCharacters
	{
		 get { } //Length: 82
	}

	public static LineBreakingTable linebreakingRules
	{
		 get { } //Length: 153
	}

	public static bool matchMaterialPreset
	{
		 get { } //Length: 79
	}

	public static uint missingCharacterSpriteUnicode
	{
		 get { } //Length: 81
		 set { } //Length: 86
	}

	public static int missingGlyphCharacter
	{
		 get { } //Length: 78
		 set { } //Length: 83
	}

	public static string styleSheetsResourcePath
	{
		 get { } //Length: 82
	}

	public static TextWrappingModes textWrappingMode
	{
		 get { } //Length: 78
	}

	public static bool useModernHangulLineBreakingRules
	{
		 get { } //Length: 82
		 set { } //Length: 87
	}

	public static string version
	{
		 get { } //Length: 44
	}

	public static bool warningsDisabled
	{
		 get { } //Length: 79
	}

	private static TMP_Settings() { }

	public TMP_Settings() { }

	public static bool get_autoSizeTextContainer() { }

	public static bool get_clearDynamicDataOnBuild() { }

	public static string get_defaultColorGradientPresetsPath() { }

	public static TMP_FontAsset get_defaultFontAsset() { }

	public static string get_defaultFontAssetPath() { }

	public static float get_defaultFontSize() { }

	public static TMP_SpriteAsset get_defaultSpriteAsset() { }

	public static string get_defaultSpriteAssetPath() { }

	public static TMP_StyleSheet get_defaultStyleSheet() { }

	public static float get_defaultTextAutoSizingMaxRatio() { }

	public static float get_defaultTextAutoSizingMinRatio() { }

	public static Vector2 get_defaultTextMeshProTextContainerSize() { }

	public static Vector2 get_defaultTextMeshProUITextContainerSize() { }

	public static List<TMP_Asset> get_emojiFallbackTextAssets() { }

	public static bool get_enableEmojiSupport() { }

	public static bool get_enableExtraPadding() { }

	public static bool get_enableKerning() { }

	public static bool get_enableParseEscapeCharacters() { }

	public static bool get_enableRaycastTarget() { }

	public static bool get_enableTintAllSprites() { }

	public static List<TMP_FontAsset> get_fallbackFontAssets() { }

	public static TextAsset get_followingCharacters() { }

	public static List<OTL_FeatureTag> get_fontFeatures() { }

	public static bool get_getFontFeaturesAtRuntime() { }

	public static bool get_hideSubTextObjects() { }

	public static TMP_Settings get_instance() { }

	public static bool get_isTextObjectScaleStatic() { }

	internal static bool get_isTMPSettingsNull() { }

	public static TextAsset get_leadingCharacters() { }

	public static LineBreakingTable get_linebreakingRules() { }

	public static bool get_matchMaterialPreset() { }

	public static uint get_missingCharacterSpriteUnicode() { }

	public static int get_missingGlyphCharacter() { }

	public static string get_styleSheetsResourcePath() { }

	public static TextWrappingModes get_textWrappingMode() { }

	public static bool get_useModernHangulLineBreakingRules() { }

	public static string get_version() { }

	public static bool get_warningsDisabled() { }

	private static HashSet<UInt32> GetCharacters(TextAsset file) { }

	public static TMP_FontAsset GetFontAsset() { }

	public static TMP_Settings GetSettings() { }

	public static TMP_SpriteAsset GetSpriteAsset() { }

	public static TMP_StyleSheet GetStyleSheet() { }

	public static TMP_Settings LoadDefaultSettings() { }

	public static void LoadLinebreakingRules() { }

	public static void set_defaultFontAsset(TMP_FontAsset value) { }

	public static void set_defaultSpriteAsset(TMP_SpriteAsset value) { }

	public static void set_defaultStyleSheet(TMP_StyleSheet value) { }

	public static void set_emojiFallbackTextAssets(List<TMP_Asset> value) { }

	public static void set_enableEmojiSupport(bool value) { }

	public static void set_fallbackFontAssets(List<TMP_FontAsset> value) { }

	public static void set_isTextObjectScaleStatic(bool value) { }

	public static void set_missingCharacterSpriteUnicode(uint value) { }

	public static void set_missingGlyphCharacter(int value) { }

	public static void set_useModernHangulLineBreakingRules(bool value) { }

	internal void SetAssetVersion() { }

}

