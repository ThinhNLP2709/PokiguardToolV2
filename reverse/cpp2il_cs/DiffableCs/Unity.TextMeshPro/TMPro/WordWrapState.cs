namespace TMPro;

internal struct WordWrapState
{
	public int previous_WordBreak; //Field offset: 0x0
	public int total_CharacterCount; //Field offset: 0x4
	public int visible_CharacterCount; //Field offset: 0x8
	public int visibleSpaceCount; //Field offset: 0xC
	public int visible_SpriteCount; //Field offset: 0x10
	public int visible_LinkCount; //Field offset: 0x14
	public int firstCharacterIndex; //Field offset: 0x18
	public int firstVisibleCharacterIndex; //Field offset: 0x1C
	public int lastCharacterIndex; //Field offset: 0x20
	public int lastVisibleCharIndex; //Field offset: 0x24
	public int lineNumber; //Field offset: 0x28
	public float maxCapHeight; //Field offset: 0x2C
	public float maxAscender; //Field offset: 0x30
	public float maxDescender; //Field offset: 0x34
	public float startOfLineAscender; //Field offset: 0x38
	public float maxLineAscender; //Field offset: 0x3C
	public float maxLineDescender; //Field offset: 0x40
	public float pageAscender; //Field offset: 0x44
	public HorizontalAlignmentOptions horizontalAlignment; //Field offset: 0x48
	public float marginLeft; //Field offset: 0x4C
	public float marginRight; //Field offset: 0x50
	public float xAdvance; //Field offset: 0x54
	public float preferredWidth; //Field offset: 0x58
	public float preferredHeight; //Field offset: 0x5C
	public float renderedWidth; //Field offset: 0x60
	public float renderedHeight; //Field offset: 0x64
	public float previousLineScale; //Field offset: 0x68
	public int wordCount; //Field offset: 0x6C
	public FontStyles fontStyle; //Field offset: 0x70
	public int italicAngle; //Field offset: 0x74
	public float fontScaleMultiplier; //Field offset: 0x78
	public float currentFontSize; //Field offset: 0x7C
	public float baselineOffset; //Field offset: 0x80
	public float lineOffset; //Field offset: 0x84
	public bool isDrivenLineSpacing; //Field offset: 0x88
	public int lastBaseGlyphIndex; //Field offset: 0x8C
	public float cSpace; //Field offset: 0x90
	public float mSpace; //Field offset: 0x94
	public TMP_TextInfo textInfo; //Field offset: 0x98
	public TMP_LineInfo lineInfo; //Field offset: 0xA0
	public Color32 vertexColor; //Field offset: 0x100
	public Color32 underlineColor; //Field offset: 0x104
	public Color32 strikethroughColor; //Field offset: 0x108
	public HighlightState highlightState; //Field offset: 0x10C
	public TMP_FontStyleStack basicStyleStack; //Field offset: 0x120
	public TMP_TextProcessingStack<Int32> italicAngleStack; //Field offset: 0x130
	public TMP_TextProcessingStack<Color32> colorStack; //Field offset: 0x150
	public TMP_TextProcessingStack<Color32> underlineColorStack; //Field offset: 0x170
	public TMP_TextProcessingStack<Color32> strikethroughColorStack; //Field offset: 0x190
	public TMP_TextProcessingStack<Color32> highlightColorStack; //Field offset: 0x1B0
	public TMP_TextProcessingStack<HighlightState> highlightStateStack; //Field offset: 0x1D0
	public TMP_TextProcessingStack<TMP_ColorGradient> colorGradientStack; //Field offset: 0x200
	public TMP_TextProcessingStack<Single> sizeStack; //Field offset: 0x228
	public TMP_TextProcessingStack<Single> indentStack; //Field offset: 0x248
	public TMP_TextProcessingStack<FontWeight> fontWeightStack; //Field offset: 0x268
	public TMP_TextProcessingStack<Int32> styleStack; //Field offset: 0x288
	public TMP_TextProcessingStack<Single> baselineStack; //Field offset: 0x2A8
	public TMP_TextProcessingStack<Int32> actionStack; //Field offset: 0x2C8
	public TMP_TextProcessingStack<MaterialReference> materialReferenceStack; //Field offset: 0x2E8
	public TMP_TextProcessingStack<HorizontalAlignmentOptions> lineJustificationStack; //Field offset: 0x340
	public int spriteAnimationID; //Field offset: 0x360
	public TMP_FontAsset currentFontAsset; //Field offset: 0x368
	public TMP_SpriteAsset currentSpriteAsset; //Field offset: 0x370
	public Material currentMaterial; //Field offset: 0x378
	public int currentMaterialIndex; //Field offset: 0x380
	public Extents meshExtents; //Field offset: 0x384
	public bool tagNoParsing; //Field offset: 0x394
	public bool isNonBreakingSpace; //Field offset: 0x395
	public Quaternion fxRotation; //Field offset: 0x398
	public Vector3 fxScale; //Field offset: 0x3A8

}

