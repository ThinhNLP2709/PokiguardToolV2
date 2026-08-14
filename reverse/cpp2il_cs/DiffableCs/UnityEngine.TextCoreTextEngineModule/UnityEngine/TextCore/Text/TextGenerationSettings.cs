namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule"})]
internal class TextGenerationSettings : IEquatable<TextGenerationSettings>
{
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule"})]
	internal static Func<Boolean> IsEditorTextRenderingModeBitmap; //Field offset: 0x0
	private RenderedText m_RenderedText; //Field offset: 0x10
	private string m_CachedRenderedText; //Field offset: 0x30
	public Rect screenRect; //Field offset: 0x38
	public Vector4 margins; //Field offset: 0x48
	public float pixelsPerPoint; //Field offset: 0x58
	public bool isEditorRenderingModeBitmap; //Field offset: 0x5C
	public FontAsset fontAsset; //Field offset: 0x60
	public Material material; //Field offset: 0x68
	public SpriteAsset spriteAsset; //Field offset: 0x70
	public TextStyleSheet styleSheet; //Field offset: 0x78
	public FontStyles fontStyle; //Field offset: 0x80
	public TextSettings textSettings; //Field offset: 0x88
	public TextAlignment textAlignment; //Field offset: 0x90
	public TextOverflowMode overflowMode; //Field offset: 0x94
	public float wordWrappingRatio; //Field offset: 0x98
	public Color color; //Field offset: 0x9C
	public TextColorGradient fontColorGradient; //Field offset: 0xB0
	public TextColorGradient fontColorGradientPreset; //Field offset: 0xB8
	public bool tintSprites; //Field offset: 0xC0
	public bool overrideRichTextColors; //Field offset: 0xC1
	public bool shouldConvertToLinearSpace; //Field offset: 0xC2
	public float fontSize; //Field offset: 0xC4
	public bool autoSize; //Field offset: 0xC8
	public float fontSizeMin; //Field offset: 0xCC
	public float fontSizeMax; //Field offset: 0xD0
	public List<OTL_FeatureTag> fontFeatures; //Field offset: 0xD8
	public bool emojiFallbackSupport; //Field offset: 0xE0
	public bool richText; //Field offset: 0xE1
	public bool isRightToLeft; //Field offset: 0xE2
	public float extraPadding; //Field offset: 0xE4
	public bool parseControlCharacters; //Field offset: 0xE8
	public bool isOrthographic; //Field offset: 0xE9
	public bool isPlaceholder; //Field offset: 0xEA
	public bool tagNoParsing; //Field offset: 0xEB
	public float characterSpacing; //Field offset: 0xEC
	public float wordSpacing; //Field offset: 0xF0
	public float lineSpacing; //Field offset: 0xF4
	public float paragraphSpacing; //Field offset: 0xF8
	public float lineSpacingMax; //Field offset: 0xFC
	public TextWrappingMode textWrappingMode; //Field offset: 0x100
	public int maxVisibleCharacters; //Field offset: 0x104
	public int maxVisibleWords; //Field offset: 0x108
	public int maxVisibleLines; //Field offset: 0x10C
	public int firstVisibleCharacter; //Field offset: 0x110
	public bool useMaxVisibleDescender; //Field offset: 0x114
	public TextFontWeight fontWeight; //Field offset: 0x118
	public int pageToDisplay; //Field offset: 0x11C
	public TextureMapping horizontalMapping; //Field offset: 0x120
	public TextureMapping verticalMapping; //Field offset: 0x124
	public float uvLineOffset; //Field offset: 0x128
	public VertexSortingOrder geometrySortingOrder; //Field offset: 0x12C
	public bool inverseYAxis; //Field offset: 0x130
	public bool isIMGUI; //Field offset: 0x131
	public float charWidthMaxAdj; //Field offset: 0x134
	internal TextInputSource inputSource; //Field offset: 0x138

	public RenderedText renderedText
	{
		 get { } //Length: 19
		 set { } //Length: 59
	}

	public string text
	{
		 get { } //Length: 86
		 set { } //Length: 262
	}

	public TextGenerationSettings() { }

	public override bool Equals(TextGenerationSettings other) { }

	public virtual bool Equals(object obj) { }

	public RenderedText get_renderedText() { }

	public string get_text() { }

	public virtual int GetHashCode() { }

	public static bool op_Inequality(TextGenerationSettings left, TextGenerationSettings right) { }

	public void set_renderedText(RenderedText value) { }

	public void set_text(string value) { }

	public virtual string ToString() { }

}

