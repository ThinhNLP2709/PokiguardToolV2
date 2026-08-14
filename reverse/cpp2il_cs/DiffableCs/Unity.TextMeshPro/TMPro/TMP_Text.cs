namespace TMPro;

public abstract class TMP_Text : MaskableGraphic
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<TMP_TextInfo> <>9__645_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__645_0(TMP_TextInfo <p0>) { }

	}

	internal struct CharacterSubstitution
	{
		public int index; //Field offset: 0x0
		public uint unicode; //Field offset: 0x4

		public CharacterSubstitution(int index, uint unicode) { }

	}

	internal sealed class MissingCharacterEventCallback : MulticastDelegate
	{

		public MissingCharacterEventCallback(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(int unicode, int stringIndex, string text, TMP_FontAsset fontAsset, TMP_Text textComponent, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(int unicode, int stringIndex, string text, TMP_FontAsset fontAsset, TMP_Text textComponent) { }

	}

	internal struct SpecialCharacter
	{
		public TMP_Character character; //Field offset: 0x0
		public TMP_FontAsset fontAsset; //Field offset: 0x8
		public Material material; //Field offset: 0x10
		public int materialIndex; //Field offset: 0x18

		public SpecialCharacter(TMP_Character character, int materialIndex) { }

	}

	[DefaultMember("Item")]
	private struct TextBackingContainer
	{
		private UInt32[] m_Array; //Field offset: 0x0
		private int m_Index; //Field offset: 0x8

		public int Capacity
		{
			 get { } //Length: 25
		}

		public int Count
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public uint Item
		{
			 get { } //Length: 42
			 set { } //Length: 91
		}

		public UInt32[] Text
		{
			 get { } //Length: 4
		}

		public TextBackingContainer(int size) { }

		public int get_Capacity() { }

		public int get_Count() { }

		public uint get_Item(int index) { }

		public UInt32[] get_Text() { }

		public void Resize(int size) { }

		public void set_Count(int value) { }

		public void set_Item(int index, uint value) { }

	}

	public enum TextInputSources
	{
		TextInputBox = 0,
		SetText = 1,
		SetTextArray = 2,
		TextString = 3,
	}

	[DebuggerDisplay("Unicode ({unicode})  '{(char)unicode}'")]
	public struct TextProcessingElement
	{
		public TextProcessingElementType elementType; //Field offset: 0x0
		public uint unicode; //Field offset: 0x4
		public int stringIndex; //Field offset: 0x8
		public int length; //Field offset: 0xC

	}

	protected static MaterialReference[] m_materialReferences; //Field offset: 0x0
	protected static Dictionary<Int32, Int32> m_materialReferenceIndexLookup; //Field offset: 0x8
	protected static TMP_TextProcessingStack<MaterialReference> m_materialReferenceStack; //Field offset: 0x10
	protected static Color32 s_colorWhite; //Field offset: 0x68
	[CompilerGenerated]
	private static Func<Int32, String, TMP_FontAsset> OnFontAssetRequest; //Field offset: 0x70
	[CompilerGenerated]
	private static Func<Int32, String, TMP_SpriteAsset> OnSpriteAssetRequest; //Field offset: 0x78
	[CompilerGenerated]
	private static MissingCharacterEventCallback OnMissingCharacter; //Field offset: 0x80
	private static Char[] m_htmlTag; //Field offset: 0x88
	private static RichTextTagAttribute[] m_xmlAttribute; //Field offset: 0x90
	private static Single[] m_attributeParameterValues; //Field offset: 0x98
	internal static WordWrapState m_SavedWordWrapState; //Field offset: 0xA0
	internal static WordWrapState m_SavedLineState; //Field offset: 0x458
	internal static WordWrapState m_SavedEllipsisState; //Field offset: 0x810
	internal static WordWrapState m_SavedLastValidState; //Field offset: 0xBC8
	internal static WordWrapState m_SavedSoftLineBreakState; //Field offset: 0xF80
	[SerializeField]
	[TextArea(5, 10)]
	protected string m_text; //Field offset: 0xE0
	private bool m_IsTextBackingStringDirty; //Field offset: 0xE8
	[SerializeField]
	protected ITextPreprocessor m_TextPreprocessor; //Field offset: 0xF0
	[SerializeField]
	protected bool m_isRightToLeft; //Field offset: 0xF8
	[SerializeField]
	protected TMP_FontAsset m_fontAsset; //Field offset: 0x100
	protected TMP_FontAsset m_currentFontAsset; //Field offset: 0x108
	protected bool m_isSDFShader; //Field offset: 0x110
	[SerializeField]
	protected Material m_sharedMaterial; //Field offset: 0x118
	protected Material m_currentMaterial; //Field offset: 0x120
	protected int m_currentMaterialIndex; //Field offset: 0x128
	[SerializeField]
	protected Material[] m_fontSharedMaterials; //Field offset: 0x130
	[SerializeField]
	protected Material m_fontMaterial; //Field offset: 0x138
	[SerializeField]
	protected Material[] m_fontMaterials; //Field offset: 0x140
	protected bool m_isMaterialDirty; //Field offset: 0x148
	[SerializeField]
	protected Color32 m_fontColor32; //Field offset: 0x14C
	[SerializeField]
	protected Color m_fontColor; //Field offset: 0x150
	protected Color32 m_underlineColor; //Field offset: 0x160
	protected Color32 m_strikethroughColor; //Field offset: 0x164
	internal HighlightState m_HighlightState; //Field offset: 0x168
	internal bool m_ConvertToLinearSpace; //Field offset: 0x17C
	[SerializeField]
	protected bool m_enableVertexGradient; //Field offset: 0x17D
	[SerializeField]
	protected ColorMode m_colorMode; //Field offset: 0x180
	[SerializeField]
	protected VertexGradient m_fontColorGradient; //Field offset: 0x184
	[SerializeField]
	protected TMP_ColorGradient m_fontColorGradientPreset; //Field offset: 0x1C8
	[SerializeField]
	protected TMP_SpriteAsset m_spriteAsset; //Field offset: 0x1D0
	[SerializeField]
	protected bool m_tintAllSprites; //Field offset: 0x1D8
	protected bool m_tintSprite; //Field offset: 0x1D9
	protected Color32 m_spriteColor; //Field offset: 0x1DC
	[SerializeField]
	protected TMP_StyleSheet m_StyleSheet; //Field offset: 0x1E0
	internal TMP_Style m_TextStyle; //Field offset: 0x1E8
	[SerializeField]
	protected int m_TextStyleHashCode; //Field offset: 0x1F0
	[SerializeField]
	protected bool m_overrideHtmlColors; //Field offset: 0x1F4
	[SerializeField]
	protected Color32 m_faceColor; //Field offset: 0x1F8
	protected Color32 m_outlineColor; //Field offset: 0x1FC
	protected float m_outlineWidth; //Field offset: 0x200
	protected Vector3 m_currentEnvMapRotation; //Field offset: 0x204
	protected bool m_hasEnvMapProperty; //Field offset: 0x210
	[SerializeField]
	protected float m_fontSize; //Field offset: 0x214
	protected float m_currentFontSize; //Field offset: 0x218
	[SerializeField]
	protected float m_fontSizeBase; //Field offset: 0x21C
	protected TMP_TextProcessingStack<Single> m_sizeStack; //Field offset: 0x220
	[SerializeField]
	protected FontWeight m_fontWeight; //Field offset: 0x240
	protected FontWeight m_FontWeightInternal; //Field offset: 0x244
	protected TMP_TextProcessingStack<FontWeight> m_FontWeightStack; //Field offset: 0x248
	[SerializeField]
	protected bool m_enableAutoSizing; //Field offset: 0x268
	protected float m_maxFontSize; //Field offset: 0x26C
	protected float m_minFontSize; //Field offset: 0x270
	protected int m_AutoSizeIterationCount; //Field offset: 0x274
	protected int m_AutoSizeMaxIterationCount; //Field offset: 0x278
	protected bool m_IsAutoSizePointSizeSet; //Field offset: 0x27C
	[SerializeField]
	protected float m_fontSizeMin; //Field offset: 0x280
	[SerializeField]
	protected float m_fontSizeMax; //Field offset: 0x284
	[SerializeField]
	protected FontStyles m_fontStyle; //Field offset: 0x288
	protected FontStyles m_FontStyleInternal; //Field offset: 0x28C
	protected TMP_FontStyleStack m_fontStyleStack; //Field offset: 0x290
	protected bool m_isUsingBold; //Field offset: 0x29A
	[SerializeField]
	protected HorizontalAlignmentOptions m_HorizontalAlignment; //Field offset: 0x29C
	[SerializeField]
	protected VerticalAlignmentOptions m_VerticalAlignment; //Field offset: 0x2A0
	[FormerlySerializedAs("m_lineJustification")]
	[SerializeField]
	protected TextAlignmentOptions m_textAlignment; //Field offset: 0x2A4
	protected HorizontalAlignmentOptions m_lineJustification; //Field offset: 0x2A8
	protected TMP_TextProcessingStack<HorizontalAlignmentOptions> m_lineJustificationStack; //Field offset: 0x2B0
	protected Vector3[] m_textContainerLocalCorners; //Field offset: 0x2D0
	[SerializeField]
	protected float m_characterSpacing; //Field offset: 0x2D8
	protected float m_cSpacing; //Field offset: 0x2DC
	protected float m_monoSpacing; //Field offset: 0x2E0
	protected bool m_duoSpace; //Field offset: 0x2E4
	[SerializeField]
	protected float m_wordSpacing; //Field offset: 0x2E8
	[SerializeField]
	protected float m_lineSpacing; //Field offset: 0x2EC
	protected float m_lineSpacingDelta; //Field offset: 0x2F0
	protected float m_lineHeight; //Field offset: 0x2F4
	protected bool m_IsDrivenLineSpacing; //Field offset: 0x2F8
	[SerializeField]
	protected float m_lineSpacingMax; //Field offset: 0x2FC
	[SerializeField]
	protected float m_paragraphSpacing; //Field offset: 0x300
	[SerializeField]
	protected float m_charWidthMaxAdj; //Field offset: 0x304
	protected float m_charWidthAdjDelta; //Field offset: 0x308
	[FormerlySerializedAs("m_enableWordWrapping")]
	[SerializeField]
	protected TextWrappingModes m_TextWrappingMode; //Field offset: 0x30C
	protected bool m_isCharacterWrappingEnabled; //Field offset: 0x310
	protected bool m_isNonBreakingSpace; //Field offset: 0x311
	protected bool m_isIgnoringAlignment; //Field offset: 0x312
	[SerializeField]
	protected float m_wordWrappingRatios; //Field offset: 0x314
	[SerializeField]
	protected TextOverflowModes m_overflowMode; //Field offset: 0x318
	protected int m_firstOverflowCharacterIndex; //Field offset: 0x31C
	[SerializeField]
	protected TMP_Text m_linkedTextComponent; //Field offset: 0x320
	[SerializeField]
	internal TMP_Text parentLinkedComponent; //Field offset: 0x328
	protected bool m_isTextTruncated; //Field offset: 0x330
	[SerializeField]
	protected bool m_enableKerning; //Field offset: 0x331
	protected int m_LastBaseGlyphIndex; //Field offset: 0x334
	internal static TMP_TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack; //Field offset: 0x1338
	[SerializeField]
	protected List<OTL_FeatureTag> m_ActiveFontFeatures; //Field offset: 0x338
	[SerializeField]
	protected bool m_enableExtraPadding; //Field offset: 0x340
	[SerializeField]
	protected bool checkPaddingRequired; //Field offset: 0x341
	[SerializeField]
	protected bool m_isRichText; //Field offset: 0x342
	[SerializeField]
	private bool m_EmojiFallbackSupport; //Field offset: 0x343
	[SerializeField]
	protected bool m_parseCtrlCharacters; //Field offset: 0x344
	protected bool m_isOverlay; //Field offset: 0x345
	[SerializeField]
	protected bool m_isOrthographic; //Field offset: 0x346
	[SerializeField]
	protected bool m_isCullingEnabled; //Field offset: 0x347
	protected bool m_isMaskingEnabled; //Field offset: 0x348
	protected bool isMaskUpdateRequired; //Field offset: 0x349
	protected bool m_ignoreCulling; //Field offset: 0x34A
	[SerializeField]
	protected TextureMappingOptions m_horizontalMapping; //Field offset: 0x34C
	[SerializeField]
	protected TextureMappingOptions m_verticalMapping; //Field offset: 0x350
	[SerializeField]
	protected float m_uvLineOffset; //Field offset: 0x354
	protected TextRenderFlags m_renderMode; //Field offset: 0x358
	[SerializeField]
	protected VertexSortingOrder m_geometrySortingOrder; //Field offset: 0x35C
	[SerializeField]
	protected bool m_IsTextObjectScaleStatic; //Field offset: 0x360
	[SerializeField]
	protected bool m_VertexBufferAutoSizeReduction; //Field offset: 0x361
	protected int m_firstVisibleCharacter; //Field offset: 0x364
	protected int m_maxVisibleCharacters; //Field offset: 0x368
	protected int m_maxVisibleWords; //Field offset: 0x36C
	protected int m_maxVisibleLines; //Field offset: 0x370
	[SerializeField]
	protected bool m_useMaxVisibleDescender; //Field offset: 0x374
	[SerializeField]
	protected int m_pageToDisplay; //Field offset: 0x378
	protected bool m_isNewPage; //Field offset: 0x37C
	[SerializeField]
	protected Vector4 m_margin; //Field offset: 0x380
	protected float m_marginLeft; //Field offset: 0x390
	protected float m_marginRight; //Field offset: 0x394
	protected float m_marginWidth; //Field offset: 0x398
	protected float m_marginHeight; //Field offset: 0x39C
	protected float m_width; //Field offset: 0x3A0
	protected TMP_TextInfo m_textInfo; //Field offset: 0x3A8
	protected bool m_havePropertiesChanged; //Field offset: 0x3B0
	[SerializeField]
	protected bool m_isUsingLegacyAnimationComponent; //Field offset: 0x3B1
	protected Transform m_transform; //Field offset: 0x3B8
	protected RectTransform m_rectTransform; //Field offset: 0x3C0
	protected Vector2 m_PreviousRectTransformSize; //Field offset: 0x3C8
	protected Vector2 m_PreviousPivotPosition; //Field offset: 0x3D0
	[CompilerGenerated]
	private bool <autoSizeTextContainer>k__BackingField; //Field offset: 0x3D8
	protected bool m_autoSizeTextContainer; //Field offset: 0x3D9
	protected Mesh m_mesh; //Field offset: 0x3E0
	[SerializeField]
	protected bool m_isVolumetricText; //Field offset: 0x3E8
	[CompilerGenerated]
	private Action<TMP_TextInfo> OnPreRenderText; //Field offset: 0x3F0
	protected TMP_SpriteAnimator m_spriteAnimator; //Field offset: 0x3F8
	protected float m_flexibleHeight; //Field offset: 0x400
	protected float m_flexibleWidth; //Field offset: 0x404
	protected float m_minWidth; //Field offset: 0x408
	protected float m_minHeight; //Field offset: 0x40C
	protected float m_maxWidth; //Field offset: 0x410
	protected float m_maxHeight; //Field offset: 0x414
	protected LayoutElement m_LayoutElement; //Field offset: 0x418
	protected float m_preferredWidth; //Field offset: 0x420
	protected float m_RenderedWidth; //Field offset: 0x424
	protected bool m_isPreferredWidthDirty; //Field offset: 0x428
	protected float m_preferredHeight; //Field offset: 0x42C
	protected float m_RenderedHeight; //Field offset: 0x430
	protected bool m_isPreferredHeightDirty; //Field offset: 0x434
	protected bool m_isCalculatingPreferredValues; //Field offset: 0x435
	protected int m_layoutPriority; //Field offset: 0x438
	protected bool m_isLayoutDirty; //Field offset: 0x43C
	protected bool m_isAwake; //Field offset: 0x43D
	internal bool m_isWaitingOnResourceLoad; //Field offset: 0x43E
	internal TextInputSources m_inputSource; //Field offset: 0x440
	protected float m_fontScaleMultiplier; //Field offset: 0x444
	protected float tag_LineIndent; //Field offset: 0x448
	protected float tag_Indent; //Field offset: 0x44C
	protected TMP_TextProcessingStack<Single> m_indentStack; //Field offset: 0x450
	protected bool tag_NoParsing; //Field offset: 0x470
	protected bool m_isTextLayoutPhase; //Field offset: 0x471
	protected Quaternion m_FXRotation; //Field offset: 0x474
	protected Vector3 m_FXScale; //Field offset: 0x484
	internal TextProcessingElement[] m_TextProcessingArray; //Field offset: 0x490
	internal int m_InternalTextProcessingArraySize; //Field offset: 0x498
	private TMP_CharacterInfo[] m_internalCharacterInfo; //Field offset: 0x4A0
	protected int m_totalCharacterCount; //Field offset: 0x4A8
	protected int m_characterCount; //Field offset: 0x4AC
	protected int m_firstCharacterOfLine; //Field offset: 0x4B0
	protected int m_firstVisibleCharacterOfLine; //Field offset: 0x4B4
	protected int m_lastCharacterOfLine; //Field offset: 0x4B8
	protected int m_lastVisibleCharacterOfLine; //Field offset: 0x4BC
	protected int m_lineNumber; //Field offset: 0x4C0
	protected int m_lineVisibleCharacterCount; //Field offset: 0x4C4
	protected int m_lineVisibleSpaceCount; //Field offset: 0x4C8
	protected int m_pageNumber; //Field offset: 0x4CC
	protected float m_PageAscender; //Field offset: 0x4D0
	protected float m_maxTextAscender; //Field offset: 0x4D4
	protected float m_maxCapHeight; //Field offset: 0x4D8
	protected float m_ElementAscender; //Field offset: 0x4DC
	protected float m_ElementDescender; //Field offset: 0x4E0
	protected float m_maxLineAscender; //Field offset: 0x4E4
	protected float m_maxLineDescender; //Field offset: 0x4E8
	protected float m_startOfLineAscender; //Field offset: 0x4EC
	protected float m_startOfLineDescender; //Field offset: 0x4F0
	protected float m_lineOffset; //Field offset: 0x4F4
	protected Extents m_meshExtents; //Field offset: 0x4F8
	protected Color32 m_htmlColor; //Field offset: 0x508
	protected TMP_TextProcessingStack<Color32> m_colorStack; //Field offset: 0x510
	protected TMP_TextProcessingStack<Color32> m_underlineColorStack; //Field offset: 0x530
	protected TMP_TextProcessingStack<Color32> m_strikethroughColorStack; //Field offset: 0x550
	protected TMP_TextProcessingStack<HighlightState> m_HighlightStateStack; //Field offset: 0x570
	protected TMP_ColorGradient m_colorGradientPreset; //Field offset: 0x5A0
	protected TMP_TextProcessingStack<TMP_ColorGradient> m_colorGradientStack; //Field offset: 0x5A8
	protected bool m_colorGradientPresetIsTinted; //Field offset: 0x5D0
	protected float m_tabSpacing; //Field offset: 0x5D4
	protected float m_spacing; //Field offset: 0x5D8
	protected TMP_TextProcessingStack<Int32>[] m_TextStyleStacks; //Field offset: 0x5E0
	protected int m_TextStyleStackDepth; //Field offset: 0x5E8
	protected TMP_TextProcessingStack<Int32> m_ItalicAngleStack; //Field offset: 0x5F0
	protected int m_ItalicAngle; //Field offset: 0x610
	protected TMP_TextProcessingStack<Int32> m_actionStack; //Field offset: 0x618
	protected float m_padding; //Field offset: 0x638
	protected float m_baselineOffset; //Field offset: 0x63C
	protected TMP_TextProcessingStack<Single> m_baselineOffsetStack; //Field offset: 0x640
	protected float m_xAdvance; //Field offset: 0x660
	protected TMP_TextElementType m_textElementType; //Field offset: 0x664
	protected TMP_TextElement m_cached_TextElement; //Field offset: 0x668
	protected SpecialCharacter m_Ellipsis; //Field offset: 0x670
	protected SpecialCharacter m_Underline; //Field offset: 0x690
	protected TMP_SpriteAsset m_defaultSpriteAsset; //Field offset: 0x6B0
	protected TMP_SpriteAsset m_currentSpriteAsset; //Field offset: 0x6B8
	protected int m_spriteCount; //Field offset: 0x6C0
	protected int m_spriteIndex; //Field offset: 0x6C4
	protected int m_spriteAnimationID; //Field offset: 0x6C8
	protected bool m_ignoreActiveState; //Field offset: 0x6CC
	private TextBackingContainer m_TextBackingArray; //Field offset: 0x6D0
	private readonly Decimal[] k_Power; //Field offset: 0x6E0
	private static ProfilerMarker k_ParseTextMarker; //Field offset: 0x1710
	private static ProfilerMarker k_InsertNewLineMarker; //Field offset: 0x1718
	protected static Vector2 k_LargePositiveVector2; //Field offset: 0x1720
	protected static Vector2 k_LargeNegativeVector2; //Field offset: 0x1728
	protected static float k_LargePositiveFloat; //Field offset: 0x1730
	protected static float k_LargeNegativeFloat; //Field offset: 0x1734
	protected static int k_LargePositiveInt; //Field offset: 0x1738
	protected static int k_LargeNegativeInt; //Field offset: 0x173C

	public static event Func<Int32, String, TMP_FontAsset> OnFontAssetRequest
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static event MissingCharacterEventCallback OnMissingCharacter
	{
		[CompilerGenerated]
		 add { } //Length: 242
		[CompilerGenerated]
		 remove { } //Length: 242
	}

	public override event Action<TMP_TextInfo> OnPreRenderText
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public static event Func<Int32, String, TMP_SpriteAsset> OnSpriteAssetRequest
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public TextAlignmentOptions alignment
	{
		 get { } //Length: 13
		 set { } //Length: 65
	}

	public float alpha
	{
		 get { } //Length: 9
		 set { } //Length: 51
	}

	public override bool autoSizeTextContainer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public Bounds bounds
	{
		 get { } //Length: 199
	}

	public float characterSpacing
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	public float characterWidthAdjustment
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	public virtual Color color
	{
		 get { } //Length: 14
		 set { } //Length: 144
	}

	public VertexGradient colorGradient
	{
		 get { } //Length: 47
		 set { } //Length: 70
	}

	public TMP_ColorGradient colorGradientPreset
	{
		 get { } //Length: 8
		 set { } //Length: 63
	}

	public bool emojiFallbackSupport
	{
		 get { } //Length: 8
		 set { } //Length: 83
	}

	public bool enableAutoSizing
	{
		 get { } //Length: 8
		 set { } //Length: 76
	}

	public bool enableCulling
	{
		 get { } //Length: 8
		 set { } //Length: 55
	}

	[Obsolete("The \"enableKerning\" property has been deprecated. Use the \"fontFeatures\" property to control what features are enabled on the text component.")]
	public bool enableKerning
	{
		 get { } //Length: 76
		 set { } //Length: 333
	}

	public bool enableVertexGradient
	{
		 get { } //Length: 8
		 set { } //Length: 42
	}

	[Obsolete("The enabledWordWrapping property is now obsolete. Please use the textWrappingMode property instead.")]
	public bool enableWordWrapping
	{
		 get { } //Length: 23
		 set { } //Length: 86
	}

	public bool extraPadding
	{
		 get { } //Length: 8
		 set { } //Length: 83
	}

	public Color32 faceColor
	{
		 get { } //Length: 227
		 set { } //Length: 125
	}

	public int firstOverflowCharacterIndex
	{
		 get { } //Length: 7
	}

	public int firstVisibleCharacter
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public override float flexibleHeight
	{
		 get { } //Length: 9
	}

	public override float flexibleWidth
	{
		 get { } //Length: 9
	}

	public TMP_FontAsset font
	{
		 get { } //Length: 8
		 set { } //Length: 206
	}

	public List<OTL_FeatureTag> fontFeatures
	{
		 get { } //Length: 8
		 set { } //Length: 89
	}

	public Material fontMaterial
	{
		 get { } //Length: 27
		 set { } //Length: 266
	}

	public override Material[] fontMaterials
	{
		 get { } //Length: 27
		 set { } //Length: 85
	}

	public override Material fontSharedMaterial
	{
		 get { } //Length: 8
		 set { } //Length: 187
	}

	public override Material[] fontSharedMaterials
	{
		 get { } //Length: 20
		 set { } //Length: 85
	}

	public float fontSize
	{
		 get { } //Length: 9
		 set { } //Length: 109
	}

	public float fontSizeMax
	{
		 get { } //Length: 9
		 set { } //Length: 85
	}

	public float fontSizeMin
	{
		 get { } //Length: 9
		 set { } //Length: 85
	}

	public FontStyles fontStyle
	{
		 get { } //Length: 7
		 set { } //Length: 83
	}

	public FontWeight fontWeight
	{
		 get { } //Length: 7
		 set { } //Length: 83
	}

	public VertexSortingOrder geometrySortingOrder
	{
		 get { } //Length: 7
		 set { } //Length: 33
	}

	public bool havePropertiesChanged
	{
		 get { } //Length: 8
		 set { } //Length: 35
	}

	public HorizontalAlignmentOptions horizontalAlignment
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public TextureMappingOptions horizontalMapping
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public bool ignoreVisibility
	{
		 get { } //Length: 8
		 set { } //Length: 22
	}

	public bool isOrthographic
	{
		 get { } //Length: 8
		 set { } //Length: 42
	}

	public bool isOverlay
	{
		 get { } //Length: 8
		 set { } //Length: 83
	}

	public bool isRightToLeftText
	{
		 get { } //Length: 8
		 set { } //Length: 83
	}

	public bool isTextObjectScaleStatic
	{
		 get { } //Length: 8
		 set { } //Length: 131
	}

	public bool isTextOverflowing
	{
		 get { } //Length: 11
	}

	public bool isTextTruncated
	{
		 get { } //Length: 8
	}

	public bool isUsingBold
	{
		 get { } //Length: 8
	}

	public bool isUsingLegacyAnimationComponent
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public bool isVolumetricText
	{
		 get { } //Length: 8
		 set { } //Length: 104
	}

	protected LayoutElement layoutElement
	{
		 get { } //Length: 153
	}

	public override int layoutPriority
	{
		 get { } //Length: 7
	}

	public float lineSpacing
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	public float lineSpacingAdjustment
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	public TMP_Text linkedTextComponent
	{
		 get { } //Length: 8
		 set { } //Length: 276
	}

	public float mappingUvLineOffset
	{
		 get { } //Length: 9
		 set { } //Length: 51
	}

	public override Vector4 margin
	{
		 get { } //Length: 14
		 set { } //Length: 185
	}

	public float maxHeight
	{
		 get { } //Length: 9
	}

	public int maxVisibleCharacters
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public int maxVisibleLines
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public int maxVisibleWords
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public float maxWidth
	{
		 get { } //Length: 9
	}

	public override Mesh mesh
	{
		 get { } //Length: 8
	}

	public override float minHeight
	{
		 get { } //Length: 9
	}

	public override float minWidth
	{
		 get { } //Length: 9
	}

	public Color32 outlineColor
	{
		 get { } //Length: 227
		 set { } //Length: 103
	}

	public float outlineWidth
	{
		 get { } //Length: 205
		 set { } //Length: 99
	}

	public TextOverflowModes overflowMode
	{
		 get { } //Length: 7
		 set { } //Length: 83
	}

	public bool overrideColorTags
	{
		 get { } //Length: 8
		 set { } //Length: 42
	}

	public int pageToDisplay
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public float paragraphSpacing
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	public bool parseCtrlCharacters
	{
		 get { } //Length: 8
		 set { } //Length: 83
	}

	public float pixelsPerUnit
	{
		 get { } //Length: 497
	}

	public override float preferredHeight
	{
		 get { } //Length: 30
	}

	public override float preferredWidth
	{
		 get { } //Length: 30
	}

	public RectTransform rectTransform
	{
		 get { } //Length: 153
	}

	public override float renderedHeight
	{
		 get { } //Length: 34
	}

	public override float renderedWidth
	{
		 get { } //Length: 38
	}

	public TextRenderFlags renderMode
	{
		 get { } //Length: 7
		 set { } //Length: 22
	}

	public bool richText
	{
		 get { } //Length: 8
		 set { } //Length: 83
	}

	protected TMP_SpriteAnimator spriteAnimator
	{
		 get { } //Length: 271
	}

	public TMP_SpriteAsset spriteAsset
	{
		 get { } //Length: 8
		 set { } //Length: 85
	}

	public TMP_StyleSheet styleSheet
	{
		 get { } //Length: 8
		 set { } //Length: 85
	}

	public override string text
	{
		 get { } //Length: 243
		 set { } //Length: 176
	}

	public Bounds textBounds
	{
		 get { } //Length: 90
	}

	public TMP_TextInfo textInfo
	{
		 get { } //Length: 121
	}

	public ITextPreprocessor textPreprocessor
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public TMP_Style textStyle
	{
		 get { } //Length: 123
		 set { } //Length: 111
	}

	public TextWrappingModes textWrappingMode
	{
		 get { } //Length: 7
		 set { } //Length: 83
	}

	public bool tintAllSprites
	{
		 get { } //Length: 8
		 set { } //Length: 42
	}

	public Transform transform
	{
		 get { } //Length: 153
	}

	public bool useMaxVisibleDescender
	{
		 get { } //Length: 8
		 set { } //Length: 42
	}

	public bool vertexBufferAutoSizeReduction
	{
		 get { } //Length: 8
		 set { } //Length: 33
	}

	public VerticalAlignmentOptions verticalAlignment
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public TextureMappingOptions verticalMapping
	{
		 get { } //Length: 7
		 set { } //Length: 42
	}

	public float wordSpacing
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	public float wordWrappingRatios
	{
		 get { } //Length: 9
		 set { } //Length: 92
	}

	private static TMP_Text() { }

	protected TMP_Text() { }

	[CompilerGenerated]
	public static void add_OnFontAssetRequest(Func<Int32, String, TMP_FontAsset> value) { }

	[CompilerGenerated]
	public static void add_OnMissingCharacter(MissingCharacterEventCallback value) { }

	[CompilerGenerated]
	public override void add_OnPreRenderText(Action<TMP_TextInfo> value) { }

	[CompilerGenerated]
	public static void add_OnSpriteAssetRequest(Func<Int32, String, TMP_SpriteAsset> value) { }

	private void AddFloatToInternalTextBackingArray(float value, int padding, int precision, ref int writeIndex) { }

	private void AddIntegerToInternalTextBackingArray(double number, int padding, ref int writeIndex) { }

	protected void AdjustLineOffset(int startIndex, int endIndex, float offset) { }

	protected override Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, TextWrappingModes textWrapMode) { }

	private void ClearMarkupTagAttributes() { }

	public override void ClearMesh(bool uploadGeometry) { }

	public override void ClearMesh() { }

	public override void ComputeMarginSize() { }

	protected float ConvertToFloat(Char[] chars, int startIndex, int length) { }

	protected float ConvertToFloat(Char[] chars, int startIndex, int length, out int lastIndex) { }

	protected override Material CreateMaterialInstance(Material source) { }

	public virtual void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) { }

	public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) { }

	protected override void DestroySubMeshObjects() { }

	protected void DoMissingGlyphCallback(int unicode, int stringIndex, TMP_FontAsset fontAsset) { }

	protected override void DrawTextHighlight(Vector3 start, Vector3 end, ref int index, Color32 highlightColor) { }

	protected override void DrawUnderlineMesh(Vector3 start, Vector3 end, ref int index, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor) { }

	protected override void FillCharacterVertexBuffers(int i, bool isVolumetric) { }

	protected override void FillCharacterVertexBuffers(int i) { }

	protected override void FillSpriteVertexBuffers(int i) { }

	public override void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false) { }

	public TextAlignmentOptions get_alignment() { }

	public float get_alpha() { }

	[CompilerGenerated]
	public override bool get_autoSizeTextContainer() { }

	public Bounds get_bounds() { }

	public float get_characterSpacing() { }

	public float get_characterWidthAdjustment() { }

	public virtual Color get_color() { }

	public VertexGradient get_colorGradient() { }

	public TMP_ColorGradient get_colorGradientPreset() { }

	public bool get_emojiFallbackSupport() { }

	public bool get_enableAutoSizing() { }

	public bool get_enableCulling() { }

	public bool get_enableKerning() { }

	public bool get_enableVertexGradient() { }

	public bool get_enableWordWrapping() { }

	public bool get_extraPadding() { }

	public Color32 get_faceColor() { }

	public int get_firstOverflowCharacterIndex() { }

	public int get_firstVisibleCharacter() { }

	public override float get_flexibleHeight() { }

	public override float get_flexibleWidth() { }

	public TMP_FontAsset get_font() { }

	public List<OTL_FeatureTag> get_fontFeatures() { }

	public Material get_fontMaterial() { }

	public override Material[] get_fontMaterials() { }

	public override Material get_fontSharedMaterial() { }

	public override Material[] get_fontSharedMaterials() { }

	public float get_fontSize() { }

	public float get_fontSizeMax() { }

	public float get_fontSizeMin() { }

	public FontStyles get_fontStyle() { }

	public FontWeight get_fontWeight() { }

	public VertexSortingOrder get_geometrySortingOrder() { }

	public bool get_havePropertiesChanged() { }

	public HorizontalAlignmentOptions get_horizontalAlignment() { }

	public TextureMappingOptions get_horizontalMapping() { }

	public bool get_ignoreVisibility() { }

	public bool get_isOrthographic() { }

	public bool get_isOverlay() { }

	public bool get_isRightToLeftText() { }

	public bool get_isTextObjectScaleStatic() { }

	public bool get_isTextOverflowing() { }

	public bool get_isTextTruncated() { }

	public bool get_isUsingBold() { }

	public bool get_isUsingLegacyAnimationComponent() { }

	public bool get_isVolumetricText() { }

	protected LayoutElement get_layoutElement() { }

	public override int get_layoutPriority() { }

	public float get_lineSpacing() { }

	public float get_lineSpacingAdjustment() { }

	public TMP_Text get_linkedTextComponent() { }

	public float get_mappingUvLineOffset() { }

	public override Vector4 get_margin() { }

	public float get_maxHeight() { }

	public int get_maxVisibleCharacters() { }

	public int get_maxVisibleLines() { }

	public int get_maxVisibleWords() { }

	public float get_maxWidth() { }

	public override Mesh get_mesh() { }

	public override float get_minHeight() { }

	public override float get_minWidth() { }

	public Color32 get_outlineColor() { }

	public float get_outlineWidth() { }

	public TextOverflowModes get_overflowMode() { }

	public bool get_overrideColorTags() { }

	public int get_pageToDisplay() { }

	public float get_paragraphSpacing() { }

	public bool get_parseCtrlCharacters() { }

	public float get_pixelsPerUnit() { }

	public override float get_preferredHeight() { }

	public override float get_preferredWidth() { }

	public RectTransform get_rectTransform() { }

	public override float get_renderedHeight() { }

	public override float get_renderedWidth() { }

	public TextRenderFlags get_renderMode() { }

	public bool get_richText() { }

	protected TMP_SpriteAnimator get_spriteAnimator() { }

	public TMP_SpriteAsset get_spriteAsset() { }

	public TMP_StyleSheet get_styleSheet() { }

	public override string get_text() { }

	public Bounds get_textBounds() { }

	public TMP_TextInfo get_textInfo() { }

	public ITextPreprocessor get_textPreprocessor() { }

	public TMP_Style get_textStyle() { }

	public TextWrappingModes get_textWrappingMode() { }

	public bool get_tintAllSprites() { }

	public Transform get_transform() { }

	public bool get_useMaxVisibleDescender() { }

	public bool get_vertexBufferAutoSizeReduction() { }

	public VerticalAlignmentOptions get_verticalAlignment() { }

	public TextureMappingOptions get_verticalMapping() { }

	public float get_wordSpacing() { }

	public float get_wordWrappingRatios() { }

	private int GetAttributeParameters(Char[] chars, int startIndex, int length, ref Single[] parameters) { }

	internal override Rect GetCanvasSpaceClippingRect() { }

	protected override Bounds GetCompoundBounds() { }

	protected void GetEllipsisSpecialCharacter(TMP_FontAsset fontAsset) { }

	protected TMP_FontAsset GetFontAssetForWeight(int fontWeight) { }

	private int GetMarkupTagHashCode(TextBackingContainer styleDefinition, int readIndex) { }

	private int GetMarkupTagHashCode(UInt32[] styleDefinition, int readIndex) { }

	protected override Material GetMaterial(Material mat) { }

	protected override Material[] GetMaterials(Material[] mats) { }

	protected override float GetPaddingForMaterial(Material mat) { }

	protected override float GetPaddingForMaterial() { }

	public override string GetParsedText() { }

	private float GetPreferredHeight(Vector2 margin) { }

	protected float GetPreferredHeight() { }

	public Vector2 GetPreferredValues() { }

	public Vector2 GetPreferredValues(float width, float height) { }

	public Vector2 GetPreferredValues(string text) { }

	public Vector2 GetPreferredValues(string text, float width, float height) { }

	protected float GetPreferredWidth() { }

	private float GetPreferredWidth(Vector2 margin) { }

	private float GetPreferredWidth(Vector2 margin, TextWrappingModes wrapMode) { }

	protected float GetRenderedHeight(bool onlyVisibleCharacters) { }

	private float GetRenderedHeight() { }

	public Vector2 GetRenderedValues(bool onlyVisibleCharacters) { }

	public Vector2 GetRenderedValues() { }

	protected float GetRenderedWidth(bool onlyVisibleCharacters) { }

	private float GetRenderedWidth() { }

	protected override Material[] GetSharedMaterials() { }

	protected void GetSpecialCharacters(TMP_FontAsset fontAsset) { }

	private TMP_Style GetStyle(int hashCode) { }

	private int GetStyleHashCode(ref UInt32[] text, int index, out int closeIndex) { }

	private int GetStyleHashCode(ref TextBackingContainer text, int index, out int closeIndex) { }

	protected Bounds GetTextBounds(bool onlyVisibleCharacters) { }

	protected Bounds GetTextBounds() { }

	protected override Vector3[] GetTextContainerLocalCorners() { }

	internal TMP_TextElement GetTextElement(uint unicode, TMP_FontAsset fontAsset, FontStyles fontStyle, FontWeight fontWeight, out bool isUsingAlternativeTypeface) { }

	public override TMP_TextInfo GetTextInfo(string text) { }

	protected void GetUnderlineSpecialCharacter(TMP_FontAsset fontAsset) { }

	private uint GetUTF16(TextBackingContainer text, int i) { }

	private uint GetUTF16(UInt32[] text, int i) { }

	private uint GetUTF32(TextBackingContainer text, int i) { }

	private uint GetUTF32(UInt32[] text, int i) { }

	protected Color32 HexCharsToColor(Char[] hexChars, int startIndex, int length) { }

	protected Color32 HexCharsToColor(Char[] hexChars, int tagCount) { }

	protected uint HexToInt(char hex) { }

	private void InsertClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	private void InsertClosingTextStyle(TMP_Style style, ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	internal void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender) { }

	private void InsertOpeningStyleTag(TMP_Style style, ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	private void InsertOpeningTextStyle(TMP_Style style, ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	private void InsertTextStyleInTextProcessingArray(ref TextProcessingElement[] charBuffer, ref int writeIndex, UInt32[] styleDefinition) { }

	protected override void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) { }

	protected override void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) { }

	private string InternalTextBackingArrayToString() { }

	internal override void InternalUpdate() { }

	internal bool IsSelfOrLinkedAncestor(TMP_Text targetTextComponent) { }

	private bool IsValidUTF16(TextBackingContainer text, int index) { }

	private bool IsValidUTF32(TextBackingContainer text, int index) { }

	protected void LoadDefaultSettings() { }

	protected override void LoadFontAsset() { }

	protected Vector2 PackUV(float x, float y, float scale) { }

	protected float PackUV(float x, float y) { }

	protected void ParseInputText() { }

	private void PopulateTextBackingArray(StringBuilder sourceText, int start, int length) { }

	private void PopulateTextBackingArray(string sourceText, int start, int length) { }

	private void PopulateTextBackingArray(Char[] sourceText, int start, int length) { }

	private void PopulateTextBackingArray(string sourceText) { }

	private void PopulateTextProcessingArray() { }

	internal void ReleaseLinkedTextComponent(TMP_Text targetTextComponent) { }

	[CompilerGenerated]
	public static void remove_OnFontAssetRequest(Func<Int32, String, TMP_FontAsset> value) { }

	[CompilerGenerated]
	public static void remove_OnMissingCharacter(MissingCharacterEventCallback value) { }

	[CompilerGenerated]
	public override void remove_OnPreRenderText(Action<TMP_TextInfo> value) { }

	[CompilerGenerated]
	public static void remove_OnSpriteAssetRequest(Func<Int32, String, TMP_SpriteAsset> value) { }

	private void ReplaceClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	private bool ReplaceOpeningStyleTag(ref TextBackingContainer sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	private bool ReplaceOpeningStyleTag(ref UInt32[] sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex) { }

	protected void ReplaceTagWithCharacter(Int32[] chars, int insertionIndex, int tagLength, char c) { }

	private void ResizeInternalArray(ref T[] array) { }

	private void ResizeInternalArray(ref T[] array, int size) { }

	protected void ResizeLineExtents(int size) { }

	internal int RestoreWordWrappingState(ref WordWrapState state) { }

	protected override void SaveGlyphVertexInfo(float padding, float style_padding, Color32 vertexColor) { }

	protected override void SaveSpriteVertexInfo(Color32 vertexColor) { }

	internal void SaveWordWrappingState(ref WordWrapState state, int index, int count) { }

	public void set_alignment(TextAlignmentOptions value) { }

	public void set_alpha(float value) { }

	[CompilerGenerated]
	public override void set_autoSizeTextContainer(bool value) { }

	public void set_characterSpacing(float value) { }

	public void set_characterWidthAdjustment(float value) { }

	public virtual void set_color(Color value) { }

	public void set_colorGradient(VertexGradient value) { }

	public void set_colorGradientPreset(TMP_ColorGradient value) { }

	public void set_emojiFallbackSupport(bool value) { }

	public void set_enableAutoSizing(bool value) { }

	public void set_enableCulling(bool value) { }

	public void set_enableKerning(bool value) { }

	public void set_enableVertexGradient(bool value) { }

	public void set_enableWordWrapping(bool value) { }

	public void set_extraPadding(bool value) { }

	public void set_faceColor(Color32 value) { }

	public void set_firstVisibleCharacter(int value) { }

	public void set_font(TMP_FontAsset value) { }

	public void set_fontFeatures(List<OTL_FeatureTag> value) { }

	public void set_fontMaterial(Material value) { }

	public override void set_fontMaterials(Material[] value) { }

	public override void set_fontSharedMaterial(Material value) { }

	public override void set_fontSharedMaterials(Material[] value) { }

	public void set_fontSize(float value) { }

	public void set_fontSizeMax(float value) { }

	public void set_fontSizeMin(float value) { }

	public void set_fontStyle(FontStyles value) { }

	public void set_fontWeight(FontWeight value) { }

	public void set_geometrySortingOrder(VertexSortingOrder value) { }

	public void set_havePropertiesChanged(bool value) { }

	public void set_horizontalAlignment(HorizontalAlignmentOptions value) { }

	public void set_horizontalMapping(TextureMappingOptions value) { }

	public void set_ignoreVisibility(bool value) { }

	public void set_isOrthographic(bool value) { }

	public void set_isOverlay(bool value) { }

	public void set_isRightToLeftText(bool value) { }

	public void set_isTextObjectScaleStatic(bool value) { }

	public void set_isUsingLegacyAnimationComponent(bool value) { }

	public void set_isVolumetricText(bool value) { }

	public void set_lineSpacing(float value) { }

	public void set_lineSpacingAdjustment(float value) { }

	public void set_linkedTextComponent(TMP_Text value) { }

	public void set_mappingUvLineOffset(float value) { }

	public override void set_margin(Vector4 value) { }

	public void set_maxVisibleCharacters(int value) { }

	public void set_maxVisibleLines(int value) { }

	public void set_maxVisibleWords(int value) { }

	public void set_outlineColor(Color32 value) { }

	public void set_outlineWidth(float value) { }

	public void set_overflowMode(TextOverflowModes value) { }

	public void set_overrideColorTags(bool value) { }

	public void set_pageToDisplay(int value) { }

	public void set_paragraphSpacing(float value) { }

	public void set_parseCtrlCharacters(bool value) { }

	public void set_renderMode(TextRenderFlags value) { }

	public void set_richText(bool value) { }

	public void set_spriteAsset(TMP_SpriteAsset value) { }

	public void set_styleSheet(TMP_StyleSheet value) { }

	public override void set_text(string value) { }

	public void set_textPreprocessor(ITextPreprocessor value) { }

	public void set_textStyle(TMP_Style value) { }

	public void set_textWrappingMode(TextWrappingModes value) { }

	public void set_tintAllSprites(bool value) { }

	public void set_useMaxVisibleDescender(bool value) { }

	public void set_vertexBufferAutoSizeReduction(bool value) { }

	public void set_verticalAlignment(VerticalAlignmentOptions value) { }

	public void set_verticalMapping(TextureMappingOptions value) { }

	public void set_wordSpacing(float value) { }

	public void set_wordWrappingRatios(float value) { }

	protected override void SetActiveSubMeshes(bool state) { }

	internal override int SetArraySizes(TextProcessingElement[] unicodeChars) { }

	public void SetCharArray(Char[] sourceText) { }

	public void SetCharArray(Char[] sourceText, int start, int length) { }

	protected override void SetCulling() { }

	protected override void SetFaceColor(Color32 color) { }

	protected override void SetFontBaseMaterial(Material mat) { }

	protected override void SetOutlineColor(Color32 color) { }

	protected override void SetOutlineThickness(float thickness) { }

	protected override void SetShaderDepth() { }

	protected override void SetSharedMaterial(Material mat) { }

	protected override void SetSharedMaterials(Material[] materials) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6) { }

	public void SetText(string sourceText, float arg0) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6, float arg7) { }

	public void SetText(StringBuilder sourceText) { }

	private void SetText(StringBuilder sourceText, int start, int length) { }

	public void SetText(Char[] sourceText) { }

	public void SetText(Char[] sourceText, int start, int length) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2) { }

	public void SetText(string sourceText, float arg0, float arg1) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5) { }

	[Obsolete("Use the SetText(string) function instead.")]
	public void SetText(string sourceText, bool syncTextInputBox = true) { }

	public void SetText(string sourceText) { }

	private void SetTextInternal(string sourceText) { }

	protected void SetTextSortingOrder(Int32[] order) { }

	protected void SetTextSortingOrder(VertexSortingOrder order) { }

	protected void SetVertexColorGradient(TMP_ColorGradient gradient) { }

	public override void SetVertices(Vector3[] vertices) { }

	internal override void UpdateCulling() { }

	public override void UpdateGeometry(Mesh mesh, int index) { }

	public override void UpdateMeshPadding() { }

	public override void UpdateVertexData() { }

	public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags) { }

	internal bool ValidateHtmlTag(TextProcessingElement[] chars, int startIndex, out int endIndex) { }

}

