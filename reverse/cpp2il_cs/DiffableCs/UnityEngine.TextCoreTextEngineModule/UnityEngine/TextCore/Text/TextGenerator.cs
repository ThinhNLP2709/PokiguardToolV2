namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal class TextGenerator
{
	internal sealed class MissingCharacterEventCallback : MulticastDelegate
	{

		public MissingCharacterEventCallback(object object, IntPtr method) { }

		public override void Invoke(uint unicode, int stringIndex, TextInfo text, FontAsset fontAsset) { }

	}

	internal struct SpecialCharacter
	{
		public Character character; //Field offset: 0x0
		public FontAsset fontAsset; //Field offset: 0x8
		public Material material; //Field offset: 0x10
		public int materialIndex; //Field offset: 0x18

		public SpecialCharacter(Character character, int materialIndex) { }

	}

	private const int k_Tab = 9; //Field offset: 0x0
	private const int k_ParagraphSeparator = 8233; //Field offset: 0x0
	private const int k_RightSingleQuote = 8217; //Field offset: 0x0
	private const int k_Square = 9633; //Field offset: 0x0
	private const int k_HangulJamoStart = 4352; //Field offset: 0x0
	private const int k_HangulJamoEnd = 4607; //Field offset: 0x0
	private const int k_CjkStart = 11904; //Field offset: 0x0
	private const int k_CjkEnd = 40959; //Field offset: 0x0
	private const int k_HangulJameExtendedStart = 43360; //Field offset: 0x0
	private const int k_HangulJameExtendedEnd = 43391; //Field offset: 0x0
	private const int k_LineSeparator = 8232; //Field offset: 0x0
	private const int k_HangulSyllablesStart = 44032; //Field offset: 0x0
	private const int k_CjkIdeographsStart = 63744; //Field offset: 0x0
	private const int k_CjkIdeographsEnd = 64255; //Field offset: 0x0
	private const int k_CjkFormsStart = 65072; //Field offset: 0x0
	private const int k_CjkHalfwidthStart = 65280; //Field offset: 0x0
	private const int k_CjkHalfwidthEnd = 65519; //Field offset: 0x0
	private const int k_EndOfText = 3; //Field offset: 0x0
	private const float k_FloatUnset = -32767; //Field offset: 0x0
	private const int k_MaxCharacters = 8; //Field offset: 0x0
	private static TextGenerator s_TextGenerator; //Field offset: 0x0
	private const int k_HangulSyllablesEnd = 55295; //Field offset: 0x0
	private const int k_HorizontalEllipsis = 8230; //Field offset: 0x0
	private const int k_CjkFormsEnd = 65103; //Field offset: 0x0
	private const int k_NarrowNoBreakSpace = 8239; //Field offset: 0x0
	private const int k_LineFeed = 10; //Field offset: 0x0
	private const int k_VerticalTab = 11; //Field offset: 0x0
	private const int k_CarriageReturn = 13; //Field offset: 0x0
	private const int k_Space = 32; //Field offset: 0x0
	private const int k_DoubleQuotes = 34; //Field offset: 0x0
	private const int k_NumberSign = 35; //Field offset: 0x0
	private const int k_PercentSign = 37; //Field offset: 0x0
	private const int k_Plus = 43; //Field offset: 0x0
	private const int k_Period = 46; //Field offset: 0x0
	private const int k_LesserThan = 60; //Field offset: 0x0
	private const int k_SingleQuote = 39; //Field offset: 0x0
	private const int k_GreaterThan = 62; //Field offset: 0x0
	private const int k_ZeroWidthSpace = 8203; //Field offset: 0x0
	private const int k_NonBreakingHyphen = 8209; //Field offset: 0x0
	private const int k_Equal = 61; //Field offset: 0x0
	private const int k_FigureSpace = 8199; //Field offset: 0x0
	private const int k_HyphenMinus = 45; //Field offset: 0x0
	private const int k_Hyphen = 8208; //Field offset: 0x0
	private const int k_NoBreakSpace = 160; //Field offset: 0x0
	private const int k_Underline = 95; //Field offset: 0x0
	private const int k_SoftHyphen = 173; //Field offset: 0x0
	private const int k_WordJoiner = 8288; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static bool <IsExecutingJob>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static MissingCharacterEventCallback OnMissingCharacter; //Field offset: 0x10
	private TextBackingContainer m_TextBackingArray; //Field offset: 0x10
	internal TextProcessingElement[] m_TextProcessingArray; //Field offset: 0x20
	internal int m_InternalTextProcessingArraySize; //Field offset: 0x28
	[SerializeField]
	protected bool m_VertexBufferAutoSizeReduction; //Field offset: 0x2C
	private Char[] m_HtmlTag; //Field offset: 0x30
	internal HighlightState m_HighlightState; //Field offset: 0x38
	protected bool m_IsIgnoringAlignment; //Field offset: 0x4C
	protected bool m_IsTextTruncated; //Field offset: 0x4D
	private Vector3[] m_RectTransformCorners; //Field offset: 0x50
	private float m_MarginWidth; //Field offset: 0x58
	private float m_MarginHeight; //Field offset: 0x5C
	private float m_PreferredWidth; //Field offset: 0x60
	private float m_PreferredHeight; //Field offset: 0x64
	private FontAsset m_CurrentFontAsset; //Field offset: 0x68
	private Material m_CurrentMaterial; //Field offset: 0x70
	private int m_CurrentMaterialIndex; //Field offset: 0x78
	private TextProcessingStack<MaterialReference> m_MaterialReferenceStack; //Field offset: 0x80
	private float m_Padding; //Field offset: 0xD8
	private SpriteAsset m_CurrentSpriteAsset; //Field offset: 0xE0
	private int m_TotalCharacterCount; //Field offset: 0xE8
	private float m_FontSize; //Field offset: 0xEC
	private float m_FontScaleMultiplier; //Field offset: 0xF0
	private float m_CurrentFontSize; //Field offset: 0xF4
	private TextProcessingStack<Single> m_SizeStack; //Field offset: 0xF8
	protected TextProcessingStack<Int32>[] m_TextStyleStacks; //Field offset: 0x118
	protected int m_TextStyleStackDepth; //Field offset: 0x120
	private FontStyles m_FontStyleInternal; //Field offset: 0x124
	private FontStyleStack m_FontStyleStack; //Field offset: 0x128
	private TextFontWeight m_FontWeightInternal; //Field offset: 0x134
	private TextProcessingStack<TextFontWeight> m_FontWeightStack; //Field offset: 0x138
	private TextAlignment m_LineJustification; //Field offset: 0x158
	private TextProcessingStack<TextAlignment> m_LineJustificationStack; //Field offset: 0x160
	private float m_BaselineOffset; //Field offset: 0x180
	private TextProcessingStack<Single> m_BaselineOffsetStack; //Field offset: 0x188
	private Color32 m_FontColor32; //Field offset: 0x1A8
	private Color32 m_HtmlColor; //Field offset: 0x1AC
	private Color32 m_UnderlineColor; //Field offset: 0x1B0
	private Color32 m_StrikethroughColor; //Field offset: 0x1B4
	private TextProcessingStack<Color32> m_ColorStack; //Field offset: 0x1B8
	private TextProcessingStack<Color32> m_UnderlineColorStack; //Field offset: 0x1D8
	private TextProcessingStack<Color32> m_StrikethroughColorStack; //Field offset: 0x1F8
	private TextProcessingStack<Color32> m_HighlightColorStack; //Field offset: 0x218
	private TextProcessingStack<HighlightState> m_HighlightStateStack; //Field offset: 0x238
	private TextProcessingStack<Int32> m_ItalicAngleStack; //Field offset: 0x268
	private TextColorGradient m_ColorGradientPreset; //Field offset: 0x288
	private TextProcessingStack<TextColorGradient> m_ColorGradientStack; //Field offset: 0x290
	private bool m_ColorGradientPresetIsTinted; //Field offset: 0x2B8
	private TextProcessingStack<Int32> m_ActionStack; //Field offset: 0x2C0
	private float m_LineOffset; //Field offset: 0x2E0
	private float m_LineHeight; //Field offset: 0x2E4
	private bool m_IsDrivenLineSpacing; //Field offset: 0x2E8
	private float m_CSpacing; //Field offset: 0x2EC
	private float m_MonoSpacing; //Field offset: 0x2F0
	private bool m_DuoSpace; //Field offset: 0x2F4
	private float m_XAdvance; //Field offset: 0x2F8
	private float m_TagLineIndent; //Field offset: 0x2FC
	private float m_TagIndent; //Field offset: 0x300
	private TextProcessingStack<Single> m_IndentStack; //Field offset: 0x308
	private bool m_TagNoParsing; //Field offset: 0x328
	private int m_CharacterCount; //Field offset: 0x32C
	private int m_FirstCharacterOfLine; //Field offset: 0x330
	private int m_LastCharacterOfLine; //Field offset: 0x334
	private int m_FirstVisibleCharacterOfLine; //Field offset: 0x338
	private int m_LastVisibleCharacterOfLine; //Field offset: 0x33C
	private float m_MaxLineAscender; //Field offset: 0x340
	private float m_MaxLineDescender; //Field offset: 0x344
	private int m_LineNumber; //Field offset: 0x348
	private int m_LineVisibleCharacterCount; //Field offset: 0x34C
	private int m_LineVisibleSpaceCount; //Field offset: 0x350
	private int m_FirstOverflowCharacterIndex; //Field offset: 0x354
	private int m_PageNumber; //Field offset: 0x358
	private float m_MarginLeft; //Field offset: 0x35C
	private float m_MarginRight; //Field offset: 0x360
	private float m_Width; //Field offset: 0x364
	private Extents m_MeshExtents; //Field offset: 0x368
	private float m_MaxCapHeight; //Field offset: 0x378
	private float m_MaxAscender; //Field offset: 0x37C
	private float m_MaxDescender; //Field offset: 0x380
	private bool m_IsNewPage; //Field offset: 0x384
	private bool m_IsNonBreakingSpace; //Field offset: 0x385
	private WordWrapState m_SavedWordWrapState; //Field offset: 0x388
	private WordWrapState m_SavedLineState; //Field offset: 0x720
	private WordWrapState m_SavedEllipsisState; //Field offset: 0xAB8
	private WordWrapState m_SavedLastValidState; //Field offset: 0xE50
	private WordWrapState m_SavedSoftLineBreakState; //Field offset: 0x11E8
	private TextElementType m_TextElementType; //Field offset: 0x1580
	private bool m_isTextLayoutPhase; //Field offset: 0x1581
	private int m_SpriteIndex; //Field offset: 0x1584
	private Color32 m_SpriteColor; //Field offset: 0x1588
	private TextElement m_CachedTextElement; //Field offset: 0x1590
	private Color32 m_HighlightColor; //Field offset: 0x1598
	private float m_CharWidthAdjDelta; //Field offset: 0x159C
	private float m_MaxFontSize; //Field offset: 0x15A0
	private float m_MinFontSize; //Field offset: 0x15A4
	private int m_AutoSizeIterationCount; //Field offset: 0x15A8
	private int m_AutoSizeMaxIterationCount; //Field offset: 0x15AC
	private float m_StartOfLineAscender; //Field offset: 0x15B0
	private float m_LineSpacingDelta; //Field offset: 0x15B4
	internal MaterialReference[] m_MaterialReferences; //Field offset: 0x15B8
	private int m_SpriteCount; //Field offset: 0x15C0
	private TextProcessingStack<Int32> m_StyleStack; //Field offset: 0x15C8
	private TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack; //Field offset: 0x15E8
	private int m_SpriteAnimationId; //Field offset: 0x19A0
	private int m_ItalicAngle; //Field offset: 0x19A4
	private Vector3 m_FXScale; //Field offset: 0x19A8
	private Quaternion m_FXRotation; //Field offset: 0x19B4
	private int m_LastBaseGlyphIndex; //Field offset: 0x19C4
	private float m_PageAscender; //Field offset: 0x19C8
	private RichTextTagAttribute[] m_XmlAttribute; //Field offset: 0x19D0
	private Single[] m_AttributeParameterValues; //Field offset: 0x19D8
	private Dictionary<Int32, Int32> m_MaterialReferenceIndexLookup; //Field offset: 0x19E0
	private bool m_IsCalculatingPreferredValues; //Field offset: 0x19E8
	private bool m_TintSprite; //Field offset: 0x19E9
	protected SpecialCharacter m_Ellipsis; //Field offset: 0x19F0
	protected SpecialCharacter m_Underline; //Field offset: 0x1A10
	private TextElementInfo[] m_InternalTextElementInfo; //Field offset: 0x1A30

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static bool IsExecutingJob
	{
		[CompilerGenerated]
		internal get { } //Length: 55
		[CompilerGenerated]
		internal set { } //Length: 60
	}

	public bool isTextTruncated
	{
		 get { } //Length: 7
	}

	public TextGenerator() { }

	protected override Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	private void ClearMarkupTagAttributes() { }

	private static void ClearMesh(bool updateMesh, TextInfo textInfo) { }

	private void ComputeMarginSize(Rect rect, Vector4 margins) { }

	protected void DoMissingGlyphCallback(uint unicode, int stringIndex, FontAsset fontAsset, TextInfo textInfo) { }

	private void DrawTextHighlight(Vector3 start, Vector3 end, Color32 highlightColor, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	private void DrawUnderlineMesh(Vector3 start, Vector3 end, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	public void GenerateText(TextGenerationSettings settings, TextInfo textInfo) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal void GenerateTextMesh(TextGenerationSettings generationSettings, TextInfo textInfo) { }

	[CompilerGenerated]
	internal static bool get_IsExecutingJob() { }

	public bool get_isTextTruncated() { }

	protected bool GetEllipsisSpecialCharacter(TextGenerationSettings generationSettings) { }

	public Vector2 GetPreferredValues(TextGenerationSettings settings, TextInfo textInfo) { }

	private Vector2 GetPreferredValuesInternal(TextGenerationSettings generationSettings, TextInfo textInfo) { }

	protected bool GetSpecialCharacters(TextGenerationSettings generationSettings) { }

	private TextElement GetTextElement(TextGenerationSettings generationSettings, uint unicode, FontAsset fontAsset, FontStyles fontStyle, TextFontWeight fontWeight, out bool isUsingAlternativeTypeface, bool populateLigatures) { }

	protected bool GetUnderlineSpecialCharacter(TextGenerationSettings generationSettings) { }

	private void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	public void LayoutPhase(TextInfo textInfo, TextGenerationSettings generationSettings, float maxVisibleDescender) { }

	public void ParsingPhase(TextInfo textInfo, TextGenerationSettings generationSettings, out uint charCode, out float maxVisibleDescender) { }

	private bool PopulateFontAsset(TextGenerationSettings generationSettings, TextProcessingElement[] textProcessingArray) { }

	private void PopulateTextBackingArray(in RenderedText sourceText) { }

	private void PopulateTextProcessingArray(TextGenerationSettings generationSettings) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal void Prepare(TextGenerationSettings generationSettings, TextInfo textInfo) { }

	internal bool PrepareFontAsset(TextGenerationSettings generationSettings) { }

	private int RestoreWordWrappingState(ref WordWrapState state, TextInfo textInfo) { }

	private void SaveGlyphVertexInfo(float padding, float stylePadding, Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	private void SaveSpriteVertexInfo(Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	private void SaveWordWrappingState(ref WordWrapState state, int index, int count, TextInfo textInfo) { }

	[CompilerGenerated]
	internal static void set_IsExecutingJob(bool value) { }

	private int SetArraySizes(TextProcessingElement[] textProcessingArray, TextGenerationSettings generationSettings, TextInfo textInfo) { }

	private bool ValidateHtmlTag(TextProcessingElement[] chars, int startIndex, out int endIndex, TextGenerationSettings generationSettings, TextInfo textInfo, out bool isThreadSuccess) { }

}

