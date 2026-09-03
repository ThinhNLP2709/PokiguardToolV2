/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public abstract class TMP_Text : MaskableGraphic // TypeDefIndex: 11898
	{
		// Fields
		[SerializeField]
		[TextArea(5, 10)]
		protected string m_text; // 0xE0
		private bool m_IsTextBackingStringDirty; // 0xE8
		[SerializeField]
		protected ITextPreprocessor m_TextPreprocessor; // 0xF0
		[SerializeField]
		protected bool m_isRightToLeft; // 0xF8
		[SerializeField]
		protected TMP_FontAsset m_fontAsset; // 0x100
		protected TMP_FontAsset m_currentFontAsset; // 0x108
		protected bool m_isSDFShader; // 0x110
		[SerializeField]
		protected Material m_sharedMaterial; // 0x118
		protected Material m_currentMaterial; // 0x120
		protected static MaterialReference[] m_materialReferences; // 0x00
		protected static readonly Dictionary<EntityId, int> m_materialReferenceIndexLookup; // 0x08
		protected static TMP_TextProcessingStack<MaterialReference> m_materialReferenceStack; // 0x10
		protected int m_currentMaterialIndex; // 0x128
		[SerializeField]
		protected Material[] m_fontSharedMaterials; // 0x130
		[SerializeField]
		protected Material m_fontMaterial; // 0x138
		[SerializeField]
		protected Material[] m_fontMaterials; // 0x140
		protected bool m_isMaterialDirty; // 0x148
		[SerializeField]
		protected Color32 m_fontColor32; // 0x14C
		[SerializeField]
		protected Color m_fontColor; // 0x150
		protected static readonly Color32 s_colorWhite; // 0x68
		protected Color32 m_underlineColor; // 0x160
		protected Color32 m_strikethroughColor; // 0x164
		internal HighlightState m_HighlightState; // 0x168
		internal bool m_ConvertToLinearSpace; // 0x17C
		[SerializeField]
		protected bool m_enableVertexGradient; // 0x17D
		[SerializeField]
		protected ColorMode m_colorMode; // 0x180
		[SerializeField]
		protected VertexGradient m_fontColorGradient; // 0x184
		[SerializeField]
		protected TMP_ColorGradient m_fontColorGradientPreset; // 0x1C8
		[SerializeField]
		protected TMP_SpriteAsset m_spriteAsset; // 0x1D0
		[SerializeField]
		protected bool m_tintAllSprites; // 0x1D8
		protected bool m_tintSprite; // 0x1D9
		protected Color32 m_spriteColor; // 0x1DC
		[SerializeField]
		protected TMP_StyleSheet m_StyleSheet; // 0x1E0
		internal TMP_Style m_TextStyle; // 0x1E8
		[SerializeField]
		protected int m_TextStyleHashCode; // 0x1F0
		[SerializeField]
		protected bool m_overrideHtmlColors; // 0x1F4
		[SerializeField]
		protected Color32 m_faceColor; // 0x1F8
		protected Color32 m_outlineColor; // 0x1FC
		protected float m_outlineWidth; // 0x200
		protected Vector3 m_currentEnvMapRotation; // 0x204
		protected bool m_hasEnvMapProperty; // 0x210
		[SerializeField]
		protected float m_fontSize; // 0x214
		protected float m_currentFontSize; // 0x218
		[SerializeField]
		protected float m_fontSizeBase; // 0x21C
		protected TMP_TextProcessingStack<float> m_sizeStack; // 0x220
		[SerializeField]
		protected FontWeight m_fontWeight; // 0x240
		protected FontWeight m_FontWeightInternal; // 0x244
		protected TMP_TextProcessingStack<FontWeight> m_FontWeightStack; // 0x248
		[SerializeField]
		protected bool m_enableAutoSizing; // 0x268
		protected float m_maxFontSize; // 0x26C
		protected float m_minFontSize; // 0x270
		protected int m_AutoSizeIterationCount; // 0x274
		protected int m_AutoSizeMaxIterationCount; // 0x278
		protected bool m_IsAutoSizePointSizeSet; // 0x27C
		[SerializeField]
		protected float m_fontSizeMin; // 0x280
		[SerializeField]
		protected float m_fontSizeMax; // 0x284
		[SerializeField]
		protected FontStyles m_fontStyle; // 0x288
		protected FontStyles m_FontStyleInternal; // 0x28C
		protected TMP_FontStyleStack m_fontStyleStack; // 0x290
		protected bool m_isUsingBold; // 0x29A
		[SerializeField]
		protected HorizontalAlignmentOptions m_HorizontalAlignment; // 0x29C
		[SerializeField]
		protected VerticalAlignmentOptions m_VerticalAlignment; // 0x2A0
		[FormerlySerializedAs("m_lineJustification")]
		[SerializeField]
		protected TextAlignmentOptions m_textAlignment; // 0x2A4
		protected HorizontalAlignmentOptions m_lineJustification; // 0x2A8
		protected TMP_TextProcessingStack<HorizontalAlignmentOptions> m_lineJustificationStack; // 0x2B0
		protected Vector3[] m_textContainerLocalCorners; // 0x2D0
		[SerializeField]
		protected float m_characterSpacing; // 0x2D8
		protected float m_cSpacing; // 0x2DC
		protected float m_monoSpacing; // 0x2E0
		protected bool m_duoSpace; // 0x2E4
		[SerializeField]
		private protected float m_characterHorizontalScale; // 0x2E8
		[SerializeField]
		protected float m_wordSpacing; // 0x2EC
		[SerializeField]
		protected float m_lineSpacing; // 0x2F0
		protected float m_lineSpacingDelta; // 0x2F4
		protected float m_lineHeight; // 0x2F8
		protected bool m_IsDrivenLineSpacing; // 0x2FC
		[SerializeField]
		protected float m_lineSpacingMax; // 0x300
		[SerializeField]
		protected float m_paragraphSpacing; // 0x304
		[SerializeField]
		protected float m_charWidthMaxAdj; // 0x308
		protected float m_charWidthAdjDelta; // 0x30C
		[FormerlySerializedAs("m_enableWordWrapping")]
		[SerializeField]
		protected TextWrappingModes m_TextWrappingMode; // 0x310
		protected bool m_isCharacterWrappingEnabled; // 0x314
		protected bool m_isNonBreakingSpace; // 0x315
		protected bool m_isIgnoringAlignment; // 0x316
		[SerializeField]
		protected float m_wordWrappingRatios; // 0x318
		[SerializeField]
		protected TextOverflowModes m_overflowMode; // 0x31C
		protected int m_firstOverflowCharacterIndex; // 0x320
		[SerializeField]
		protected TMP_Text m_linkedTextComponent; // 0x328
		[SerializeField]
		internal TMP_Text parentLinkedComponent; // 0x330
		protected bool m_isTextTruncated; // 0x338
		[SerializeField]
		protected bool m_enableKerning; // 0x339
		protected int m_LastBaseGlyphIndex; // 0x33C
		[SerializeField]
		protected List<OTL_FeatureTag> m_ActiveFontFeatures; // 0x340
		[SerializeField]
		protected bool m_enableExtraPadding; // 0x348
		[SerializeField]
		protected bool checkPaddingRequired; // 0x349
		[SerializeField]
		protected bool m_isRichText; // 0x34A
		[SerializeField]
		private bool m_EmojiFallbackSupport; // 0x34B
		[SerializeField]
		protected bool m_parseCtrlCharacters; // 0x34C
		protected bool m_isOverlay; // 0x34D
		[SerializeField]
		protected bool m_isOrthographic; // 0x34E
		[SerializeField]
		protected bool m_isCullingEnabled; // 0x34F
		protected bool m_isMaskingEnabled; // 0x350
		protected bool isMaskUpdateRequired; // 0x351
		protected bool m_ignoreCulling; // 0x352
		[SerializeField]
		protected TextureMappingOptions m_horizontalMapping; // 0x354
		[SerializeField]
		protected TextureMappingOptions m_verticalMapping; // 0x358
		[SerializeField]
		protected float m_uvLineOffset; // 0x35C
		protected TextRenderFlags m_renderMode; // 0x360
		[SerializeField]
		protected VertexSortingOrder m_geometrySortingOrder; // 0x364
		[SerializeField]
		protected bool m_IsTextObjectScaleStatic; // 0x368
		[SerializeField]
		protected bool m_VertexBufferAutoSizeReduction; // 0x369
		protected int m_firstVisibleCharacter; // 0x36C
		protected int m_maxVisibleCharacters; // 0x370
		protected int m_maxVisibleWords; // 0x374
		protected int m_maxVisibleLines; // 0x378
		[SerializeField]
		protected bool m_useMaxVisibleDescender; // 0x37C
		[SerializeField]
		protected int m_pageToDisplay; // 0x380
		protected bool m_isNewPage; // 0x384
		[SerializeField]
		protected Vector4 m_margin; // 0x388
		protected float m_marginLeft; // 0x398
		protected float m_marginRight; // 0x39C
		protected float m_marginWidth; // 0x3A0
		protected float m_marginHeight; // 0x3A4
		protected float m_width; // 0x3A8
		protected TMP_TextInfo m_textInfo; // 0x3B0
		protected bool m_havePropertiesChanged; // 0x3B8
		[SerializeField]
		protected bool m_isUsingLegacyAnimationComponent; // 0x3B9
		protected Transform m_transform; // 0x3C0
		protected RectTransform m_rectTransform; // 0x3C8
		protected Vector2 m_PreviousRectTransformSize; // 0x3D0
		protected Vector2 m_PreviousPivotPosition; // 0x3D8
		[CompilerGenerated]
		private bool _autoSizeTextContainer_k__BackingField; // 0x3E0
		protected bool m_autoSizeTextContainer; // 0x3E1
		protected Mesh m_mesh; // 0x3E8
		[SerializeField]
		protected bool m_isVolumetricText; // 0x3F0
		[CompilerGenerated]
		private static Func<uint, TMP_Text, TMP_FontAsset> OnCharacterRequest; // 0x70
		[CompilerGenerated]
		private static Func<int, string, TMP_FontAsset> OnFontAssetRequest; // 0x78
		[CompilerGenerated]
		private static Func<int, string, Material> OnFontMaterialRequest; // 0x80
		[CompilerGenerated]
		private static Func<int, string, TMP_SpriteAsset> OnSpriteAssetRequest; // 0x88
		[CompilerGenerated]
		private static Func<int, string, TMP_ColorGradient> OnColorGradientAssetRequest; // 0x90
		[CompilerGenerated]
		private static MissingCharacterEventCallback OnMissingCharacter; // 0x98
		[CompilerGenerated]
		private Action<TMP_TextInfo> OnPreRenderText; // 0x3F8
		protected TMP_SpriteAnimator m_spriteAnimator; // 0x400
		protected float m_flexibleHeight; // 0x408
		protected float m_flexibleWidth; // 0x40C
		protected float m_minWidth; // 0x410
		protected float m_minHeight; // 0x414
		protected float m_maxWidth; // 0x418
		protected float m_maxHeight; // 0x41C
		protected LayoutElement m_LayoutElement; // 0x420
		protected float m_preferredWidth; // 0x428
		protected float m_RenderedWidth; // 0x42C
		protected bool m_isPreferredWidthDirty; // 0x430
		protected float m_preferredHeight; // 0x434
		protected float m_RenderedHeight; // 0x438
		protected bool m_isPreferredHeightDirty; // 0x43C
		protected bool m_isCalculatingPreferredValues; // 0x43D
		protected int m_layoutPriority; // 0x440
		protected bool m_isLayoutDirty; // 0x444
		protected bool m_isAwake; // 0x445
		internal bool m_isWaitingOnResourceLoad; // 0x446
		internal TextInputSources m_inputSource; // 0x448
		protected float m_fontScaleMultiplier; // 0x44C
		private static readonly char[] m_htmlTag; // 0xA0
		private static readonly RichTextTagAttribute[] m_xmlAttribute; // 0xA8
		private static readonly float[] m_attributeParameterValues; // 0xB0
		protected float tag_LineIndent; // 0x450
		protected float tag_Indent; // 0x454
		protected TMP_TextProcessingStack<float> m_indentStack; // 0x458
		protected bool tag_NoParsing; // 0x478
		protected bool m_isTextLayoutPhase; // 0x479
		protected Quaternion m_FXRotation; // 0x47C
		protected Vector3 m_FXScale; // 0x48C
		internal TextProcessingElement[] m_TextProcessingArray; // 0x498
		internal int m_InternalTextProcessingArraySize; // 0x4A0
		private TMP_CharacterInfo[] m_internalCharacterInfo; // 0x4A8
		protected int m_totalCharacterCount; // 0x4B0
		internal static WordWrapState m_SavedWordWrapState; // 0xB8
		internal static WordWrapState m_SavedLineState; // 0x470
		internal static WordWrapState m_SavedEllipsisState; // 0x828
		internal static WordWrapState m_SavedLastValidState; // 0xBE0
		internal static WordWrapState m_SavedSoftLineBreakState; // 0xF98
		internal static TMP_TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack; // 0x1350
		protected int m_characterCount; // 0x4B4
		protected int m_firstCharacterOfLine; // 0x4B8
		protected int m_firstVisibleCharacterOfLine; // 0x4BC
		protected int m_lastCharacterOfLine; // 0x4C0
		protected int m_lastVisibleCharacterOfLine; // 0x4C4
		protected int m_lineNumber; // 0x4C8
		protected int m_lineVisibleCharacterCount; // 0x4CC
		protected int m_lineVisibleSpaceCount; // 0x4D0
		protected int m_pageNumber; // 0x4D4
		protected float m_PageAscender; // 0x4D8
		protected float m_maxTextAscender; // 0x4DC
		protected float m_maxCapHeight; // 0x4E0
		protected float m_ElementAscender; // 0x4E4
		protected float m_ElementDescender; // 0x4E8
		protected float m_maxLineAscender; // 0x4EC
		protected float m_maxLineDescender; // 0x4F0
		protected float m_startOfLineAscender; // 0x4F4
		protected float m_startOfLineDescender; // 0x4F8
		protected float m_lineOffset; // 0x4FC
		protected Extents m_meshExtents; // 0x500
		protected Color32 m_htmlColor; // 0x510
		protected TMP_TextProcessingStack<Color32> m_colorStack; // 0x518
		protected TMP_TextProcessingStack<Color32> m_underlineColorStack; // 0x538
		protected TMP_TextProcessingStack<Color32> m_strikethroughColorStack; // 0x558
		protected TMP_TextProcessingStack<HighlightState> m_HighlightStateStack; // 0x578
		protected TMP_ColorGradient m_colorGradientPreset; // 0x5A8
		protected TMP_TextProcessingStack<TMP_ColorGradient> m_colorGradientStack; // 0x5B0
		protected bool m_colorGradientPresetIsTinted; // 0x5D8
		protected float m_tabSpacing; // 0x5DC
		protected float m_spacing; // 0x5E0
		protected TMP_TextProcessingStack<int>[] m_TextStyleStacks; // 0x5E8
		protected int m_TextStyleStackDepth; // 0x5F0
		protected TMP_TextProcessingStack<int> m_ItalicAngleStack; // 0x5F8
		protected int m_ItalicAngle; // 0x618
		protected TMP_TextProcessingStack<int> m_actionStack; // 0x620
		protected float m_padding; // 0x640
		protected float m_baselineOffset; // 0x644
		protected TMP_TextProcessingStack<float> m_baselineOffsetStack; // 0x648
		protected float m_xAdvance; // 0x668
		protected TMP_TextElementType m_textElementType; // 0x66C
		protected TMP_TextElement m_cached_TextElement; // 0x670
		protected SpecialCharacter m_Ellipsis; // 0x678
		protected SpecialCharacter m_Underline; // 0x698
		protected TMP_SpriteAsset m_defaultSpriteAsset; // 0x6B8
		protected TMP_SpriteAsset m_currentSpriteAsset; // 0x6C0
		protected int m_spriteCount; // 0x6C8
		protected int m_spriteIndex; // 0x6CC
		protected int m_spriteAnimationID; // 0x6D0
		private static readonly ProfilerMarker k_ParseTextMarker; // 0x1728
		private static readonly ProfilerMarker k_InsertNewLineMarker; // 0x1730
		protected bool m_ignoreActiveState; // 0x6D4
		private TextBackingContainer m_TextBackingArray; // 0x6D8
		private readonly decimal[] k_Power; // 0x6E8
		protected static readonly Vector2 k_LargePositiveVector2; // 0x1738
		protected static readonly Vector2 k_LargeNegativeVector2; // 0x1740
		protected const float k_LargePositiveFloat = 32767f; // Metadata: 0x006A22E4
		protected const float k_LargeNegativeFloat = -32767f; // Metadata: 0x006A22E8
		protected const int k_LargePositiveInt = 2147483647; // Metadata: 0x006A22EC
		protected const int k_LargeNegativeInt = -2147483647; // Metadata: 0x006A22ED
	
		// Properties
		public virtual string text { get; set; } // 0x00000001820AFE10-0x00000001820AFF10 0x00000001820B1D70-0x00000001820B1E20
		public ITextPreprocessor textPreprocessor { get; set; } // 0x0000000180CC3740-0x0000000180CC3750 0x0000000180CC3C60-0x0000000180CC3C80
		public bool isRightToLeftText { get; set; } // 0x00000001820AF5B0-0x00000001820AF5C0 0x00000001820B1410-0x00000001820B1470
		public TMP_FontAsset font { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001820B11D0-0x00000001820B12A0
		public virtual Material fontSharedMaterial { get; set; } // 0x000000018171E0D0-0x000000018171E0E0 0x00000001820B0F20-0x00000001820B0FE0
		public virtual Material[] fontSharedMaterials { get; set; } // 0x00000001820AF4E0-0x00000001820AF500 0x00000001820B0EC0-0x00000001820B0F20
		public Material fontMaterial { get; set; } // 0x00000001820AF4A0-0x00000001820AF4C0 0x00000001820B0DA0-0x00000001820B0EC0
		public virtual Material[] fontMaterials { get; set; } // 0x00000001820AF4C0-0x00000001820AF4E0 0x00000001820B0EC0-0x00000001820B0F20
		public override Color color { get; set; } // 0x00000001820AF290-0x00000001820AF2A0 0x00000001820B08D0-0x00000001820B0960
		public float alpha { get; set; } // 0x00000001820AF140-0x00000001820AF150 0x00000001820B06D0-0x00000001820B0710
		public bool enableVertexGradient { get; set; } // 0x00000001820AF320-0x00000001820AF330 0x00000001820B0BA0-0x00000001820B0BD0
		public VertexGradient colorGradient { get; set; } // 0x00000001820AF260-0x00000001820AF290 0x00000001820B0880-0x00000001820B08D0
		public TMP_ColorGradient colorGradientPreset { get; set; } // 0x0000000181CB2300-0x0000000181CB2310 0x00000001820B0840-0x00000001820B0880
		public TMP_SpriteAsset spriteAsset { get; set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x00000001820B1BE0-0x00000001820B1C40
		public bool tintAllSprites { get; set; } // 0x0000000182019880-0x0000000182019890 0x00000001820B1E20-0x00000001820B1E50
		public TMP_StyleSheet styleSheet { get; set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x00000001820B1C40-0x00000001820B1CA0
		public TMP_Style textStyle { get; set; } // 0x00000001820AFD80-0x00000001820AFE00 0x00000001820B1CA0-0x00000001820B1D10
		public bool overrideColorTags { get; set; } // 0x00000001820AF950-0x00000001820AF960 0x00000001820B1A40-0x00000001820B1A70
		public Color32 faceColor { get; set; } // 0x00000001820AF360-0x00000001820AF450 0x00000001820B0C90-0x00000001820B0D10
		public Color32 outlineColor { get; set; } // 0x00000001820AF780-0x00000001820AF870 0x00000001820B1900-0x00000001820B1970
		public float outlineWidth { get; set; } // 0x00000001820AF870-0x00000001820AF940 0x00000001820B1970-0x00000001820B19E0
		public float fontSize { get; set; } // 0x00000001820AF520-0x00000001820AF530 0x00000001820B10A0-0x00000001820B1110
		public FontWeight fontWeight { get; set; } // 0x0000000180517470-0x0000000180517480 0x00000001820B1170-0x00000001820B11D0
		public float pixelsPerUnit { get; } // 0x00000001820AF990-0x00000001820AFAA0 
		public bool enableAutoSizing { get; set; } // 0x00000001820AF2B0-0x00000001820AF2C0 0x00000001820B09C0-0x00000001820B0A10
		public float fontSizeMin { get; set; } // 0x00000001820AF510-0x00000001820AF520 0x00000001820B1040-0x00000001820B10A0
		public float fontSizeMax { get; set; } // 0x00000001820AF500-0x00000001820AF510 0x00000001820B0FE0-0x00000001820B1040
		public FontStyles fontStyle { get; set; } // 0x00000001820AF530-0x00000001820AF540 0x00000001820B1110-0x00000001820B1170
		public bool isUsingBold { get; } // 0x00000001820AF5D0-0x00000001820AF5E0 
		public HorizontalAlignmentOptions horizontalAlignment { get; set; } // 0x00000001820AF560-0x00000001820AF570 0x00000001820B1300-0x00000001820B1330
		public VerticalAlignmentOptions verticalAlignment { get; set; } // 0x00000001820AFFD0-0x00000001820AFFE0 0x00000001820B1EB0-0x00000001820B1EE0
		public TextAlignmentOptions alignment { get; set; } // 0x00000001820AF130-0x00000001820AF140 0x00000001820B0680-0x00000001820B06D0
		public float characterSpacing { get; set; } // 0x00000001820AF240-0x00000001820AF250 0x00000001820B0780-0x00000001820B07E0
		public float characterHorizontalScale { get; set; } // 0x00000001820AF230-0x00000001820AF240 0x00000001820B0720-0x00000001820B0780
		public float wordSpacing { get; set; } // 0x00000001820AFFF0-0x00000001820B0000 0x00000001820B1F10-0x00000001820B1F70
		public float lineSpacing { get; set; } // 0x00000001820AF6C0-0x00000001820AF6D0 0x00000001820B15F0-0x00000001820B1650
		public float lineSpacingAdjustment { get; set; } // 0x00000001820AF6B0-0x00000001820AF6C0 0x00000001820B1590-0x00000001820B15F0
		public float paragraphSpacing { get; set; } // 0x00000001820AF970-0x00000001820AF980 0x00000001820B1AA0-0x00000001820B1B00
		public float characterWidthAdjustment { get; set; } // 0x00000001820AF250-0x00000001820AF260 0x00000001820B07E0-0x00000001820B0840
		public TextWrappingModes textWrappingMode { get; set; } // 0x00000001820AFE00-0x00000001820AFE10 0x00000001820B1D10-0x00000001820B1D70
		[Obsolete("The enableWordWrapping property is now obsolete. Please use the textWrappingMode property instead.", true)]
		public bool enableWordWrapping { get; set; } // 0x00000001820AF330-0x00000001820AF350 0x00000001820B0BD0-0x00000001820B0C30
		public float wordWrappingRatios { get; set; } // 0x00000001820B0000-0x00000001820B0010 0x00000001820B1F70-0x00000001820B1FD0
		public TextOverflowModes overflowMode { get; set; } // 0x00000001820AF940-0x00000001820AF950 0x00000001820B19E0-0x00000001820B1A40
		public bool isTextOverflowing { get; } // 0x00000001820AF5C0-0x00000001820AF5D0 
		public int firstOverflowCharacterIndex { get; } // 0x00000001820AF450-0x00000001820AF460 
		public TMP_Text linkedTextComponent { get; set; } // 0x00000001820AF6D0-0x00000001820AF6E0 0x00000001820B1650-0x00000001820B1770
		public bool isTextTruncated { get; } // 0x0000000181F17A90-0x0000000181F17AA0 
		[Obsolete("The \"enableKerning\" property has been deprecated. Use the \"fontFeatures\" property to control what features are enabled on the text component.", true)]
		public bool enableKerning { get; set; } // 0x00000001820AF2D0-0x00000001820AF320 0x00000001820B0A50-0x00000001820B0BA0
		public List<OTL_FeatureTag> fontFeatures { get; set; } // 0x00000001820AF490-0x00000001820AF4A0 0x00000001820B0D40-0x00000001820B0DA0
		public bool extraPadding { get; set; } // 0x00000001820AF350-0x00000001820AF360 0x00000001820B0C30-0x00000001820B0C90
		public bool richText { get; set; } // 0x00000001820AFB90-0x00000001820AFBA0 0x00000001820B1B80-0x00000001820B1BE0
		public bool emojiFallbackSupport { get; set; } // 0x00000001820AF2A0-0x00000001820AF2B0 0x00000001820B0960-0x00000001820B09C0
		public bool parseCtrlCharacters { get; set; } // 0x00000001820AF980-0x00000001820AF990 0x00000001820B1B00-0x00000001820B1B60
		public bool isOverlay { get; set; } // 0x00000001820AF5A0-0x00000001820AF5B0 0x00000001820B13B0-0x00000001820B1410
		public bool isOrthographic { get; set; } // 0x00000001820AF590-0x00000001820AF5A0 0x00000001820B1380-0x00000001820B13B0
		public bool enableCulling { get; set; } // 0x00000001820AF2C0-0x00000001820AF2D0 0x00000001820B0A10-0x00000001820B0A50
		public bool ignoreVisibility { get; set; } // 0x00000001820AF580-0x00000001820AF590 0x00000001820B1360-0x00000001820B1380
		public TextureMappingOptions horizontalMapping { get; set; } // 0x00000001820AF570-0x00000001820AF580 0x00000001820B1330-0x00000001820B1360
		public TextureMappingOptions verticalMapping { get; set; } // 0x00000001820AFFE0-0x00000001820AFFF0 0x00000001820B1EE0-0x00000001820B1F10
		public float mappingUvLineOffset { get; set; } // 0x00000001820AF6E0-0x00000001820AF6F0 0x00000001820B1770-0x00000001820B17B0
		public TextRenderFlags renderMode { get; set; } // 0x00000001820AFB80-0x00000001820AFB90 0x00000001820B1B60-0x00000001820B1B80
		public VertexSortingOrder geometrySortingOrder { get; set; } // 0x00000001820AF540-0x00000001820AF550 0x00000001820B12A0-0x00000001820B12D0
		public bool isTextObjectScaleStatic { get; set; } // 0x000000018059B4D0-0x000000018059B4E0 0x00000001820B1470-0x00000001820B1510
		public bool vertexBufferAutoSizeReduction { get; set; } // 0x00000001820AFFC0-0x00000001820AFFD0 0x00000001820B1E80-0x00000001820B1EB0
		public int firstVisibleCharacter { get; set; } // 0x00000001820AF460-0x00000001820AF470 0x00000001820B0D10-0x00000001820B0D40
		public int maxVisibleCharacters { get; set; } // 0x00000001820AF710-0x00000001820AF720 0x00000001820B1870-0x00000001820B18A0
		public int maxVisibleWords { get; set; } // 0x00000001820AF730-0x00000001820AF740 0x00000001820B18D0-0x00000001820B1900
		public int maxVisibleLines { get; set; } // 0x00000001820AF720-0x00000001820AF730 0x00000001820B18A0-0x00000001820B18D0
		public bool useMaxVisibleDescender { get; set; } // 0x00000001820AFFB0-0x00000001820AFFC0 0x00000001820B1E50-0x00000001820B1E80
		public int pageToDisplay { get; set; } // 0x00000001820AF960-0x00000001820AF970 0x00000001820B1A70-0x00000001820B1AA0
		public virtual Vector4 margin { get; set; } // 0x00000001820AF6F0-0x00000001820AF700 0x00000001820B17B0-0x00000001820B1870
		public TMP_TextInfo textInfo { get; } // 0x00000001820AFD00-0x00000001820AFD80 
		public bool havePropertiesChanged { get; set; } // 0x00000001820AF550-0x00000001820AF560 0x00000001820B12D0-0x00000001820B1300
		public bool isUsingLegacyAnimationComponent { get; set; } // 0x00000001820AF5E0-0x00000001820AF5F0 0x00000001820B1510-0x00000001820B1520
		public new Transform transform { get; } // 0x00000001820AFF10-0x00000001820AFFB0 
		public new RectTransform rectTransform { get; } // 0x00000001820AFAE0-0x00000001820AFB80 
		public virtual bool autoSizeTextContainer { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001820AF150-0x00000001820AF160 0x00000001820B0710-0x00000001820B0720
		public virtual Mesh mesh { get; } // 0x00000001820AF750-0x00000001820AF760 
		public bool isVolumetricText { get; set; } // 0x00000001820AF5F0-0x00000001820AF600 0x00000001820B1520-0x00000001820B1590
		public Bounds bounds { get; } // 0x00000001820AF160-0x00000001820AF230 
		public Bounds textBounds { get; } // 0x00000001820AFCA0-0x00000001820AFD00 
		protected TMP_SpriteAnimator spriteAnimator { get; } // 0x00000001820AFBA0-0x00000001820AFCA0 
		public float flexibleHeight { get; } // 0x00000001820AF470-0x00000001820AF480 
		public float flexibleWidth { get; } // 0x00000001820AF480-0x00000001820AF490 
		public float minWidth { get; } // 0x00000001820AF770-0x00000001820AF780 
		public float minHeight { get; } // 0x00000001820AF760-0x00000001820AF770 
		public float maxWidth { get; } // 0x00000001820AF740-0x00000001820AF750 
		public float maxHeight { get; } // 0x00000001820AF700-0x00000001820AF710 
		protected LayoutElement layoutElement { get; } // 0x00000001820AF600-0x00000001820AF6A0 
		public virtual float preferredWidth { get; } // 0x00000001820AFAC0-0x00000001820AFAE0 
		public virtual float preferredHeight { get; } // 0x00000001820AFAA0-0x00000001820AFAC0 
		public virtual float renderedWidth { get; } // 0x000000018209E890-0x000000018209E8C0 
		public virtual float renderedHeight { get; } // 0x000000018209E7B0-0x000000018209E7E0 
		public int layoutPriority { get; } // 0x00000001820AF6A0-0x00000001820AF6B0 
	
		// Events
		public static event Func<uint, TMP_Text, TMP_FontAsset> OnCharacterRequest {
			add; // 0x00000001820AEAC0-0x00000001820AEBB0
			remove; // 0x00000001820B0010-0x00000001820B0100
		}
		public static event Func<int, string, TMP_FontAsset> OnFontAssetRequest {
			add; // 0x00000001820AECB0-0x00000001820AEDA0
			remove; // 0x00000001820B0200-0x00000001820B02F0
		}
		public static event Func<int, string, Material> OnFontMaterialRequest {
			add; // 0x00000001820AEDA0-0x00000001820AEE90
			remove; // 0x00000001820B02F0-0x00000001820B03E0
		}
		public static event Func<int, string, TMP_SpriteAsset> OnSpriteAssetRequest {
			add; // 0x00000001820AF030-0x00000001820AF130
			remove; // 0x00000001820B0580-0x00000001820B0680
		}
		public static event Func<int, string, TMP_ColorGradient> OnColorGradientAssetRequest {
			add; // 0x00000001820AEBB0-0x00000001820AECB0
			remove; // 0x00000001820B0100-0x00000001820B0200
		}
		public static event MissingCharacterEventCallback OnMissingCharacter {
			add; // 0x00000001820AEE90-0x00000001820AEF60
			remove; // 0x00000001820B03E0-0x00000001820B04B0
		}
		public virtual event Action<TMP_TextInfo> OnPreRenderText {
			add; // 0x00000001820AEF60-0x00000001820AF030
			remove; // 0x00000001820B04B0-0x00000001820B0580
		}
	
		// Nested types
		public delegate void MissingCharacterEventCallback(int unicode, int stringIndex, string text, TMP_FontAsset fontAsset, TMP_Text textComponent); // TypeDefIndex: 11899; 0x000000018122C800-0x000000018122C820
	
		protected struct CharacterSubstitution // TypeDefIndex: 11900
		{
			// Fields
			public int index; // 0x00
			public uint unicode; // 0x04
	
			// Constructors
			public CharacterSubstitution(int index, uint unicode); // 0x0000000180C55C70-0x0000000180C55C80
		}
	
		internal enum TextInputSources // TypeDefIndex: 11901
		{
			TextInputBox = 0,
			SetText = 1,
			SetTextArray = 2,
			TextString = 3
		}
	
		[DebuggerDisplay("Unicode ({unicode})  \'{(char)unicode}\'")]
		internal struct TextProcessingElement // TypeDefIndex: 11902
		{
			// Fields
			public TextProcessingElementType elementType; // 0x00
			public uint unicode; // 0x04
			public int stringIndex; // 0x08
			public int length; // 0x0C
		}
	
		protected struct SpecialCharacter // TypeDefIndex: 11903
		{
			// Fields
			public TMP_Character character; // 0x00
			public TMP_FontAsset fontAsset; // 0x08
			public Material material; // 0x10
			public int materialIndex; // 0x18
	
			// Constructors
			public SpecialCharacter(TMP_Character character, int materialIndex); // 0x00000001820C2080-0x00000001820C21E0
		}
	
		private struct TextBackingContainer // TypeDefIndex: 11904
		{
			// Fields
			private uint[] m_Array; // 0x00
			private int m_Index; // 0x08
	
			// Properties
			public int Capacity { get; } // 0x0000000180EEFE00-0x0000000180EEFE20 
			public int Count { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
			public uint this[int index] { get => default; set {} } // 0x00000001820D1010-0x00000001820D1040 0x00000001820D1040-0x00000001820D10A0
	
			// Constructors
			public TextBackingContainer(int size); // 0x00000001820D0F80-0x00000001820D1010
	
			// Methods
			public Span<uint> AsSpan(); // 0x00000001820D0E30-0x00000001820D0E60
			public Span<uint> AsSpan(int start, int length); // 0x00000001820D0E60-0x00000001820D0EF0
			public void EnsureCapacity(int requiredCapacity); // 0x00000001820D0EF0-0x00000001820D0F70
			public void Resize(int size); // 0x00000001820D0F70-0x00000001820D0F80
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11905
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<TMP_TextInfo> __9__666_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001820D2260-0x00000001820D22D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.ctor_b__666_0(TMP_TextInfo _p0_); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		protected TMP_Text(); // 0x00000001820ADD90-0x00000001820AEAC0
		static TMP_Text(); // 0x00000001820AD800-0x00000001820ADD90
	
		// Methods
		protected virtual void LoadFontAsset(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void SetSharedMaterial(Material mat); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual Material GetMaterial(Material mat); // 0x00000001802E7860-0x00000001802E7870
		protected virtual void SetFontBaseMaterial(Material mat); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual Material[] GetSharedMaterials(); // 0x00000001802E7860-0x00000001802E7870
		protected virtual void SetSharedMaterials(Material[] materials); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual Material[] GetMaterials(Material[] mats); // 0x00000001802E7860-0x00000001802E7870
		protected virtual Material CreateMaterialInstance(Material source); // 0x0000000182099B70-0x0000000182099C30
		protected void SetVertexColorGradient(TMP_ColorGradient gradient); // 0x00000001820A77F0-0x00000001820A78A0
		protected void SetTextSortingOrder(VertexSortingOrder order); // 0x00000001802E76C0-0x00000001802E76D0
		protected void SetTextSortingOrder(int[] order); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void SetFaceColor(Color32 color); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void SetOutlineColor(Color32 color); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void SetOutlineThickness(float thickness); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void SetShaderDepth(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void SetCulling(); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void UpdateCulling(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual float GetPaddingForMaterial(); // 0x000000018209DB40-0x000000018209DC70
		protected virtual float GetPaddingForMaterial(Material mat); // 0x000000018209DC70-0x000000018209DD90
		protected virtual Vector3[] GetTextContainerLocalCorners(); // 0x00000001802E7860-0x00000001802E7870
		public virtual void ForceMeshUpdate(bool ignoreActiveState = false /* Metadata: 0x006A22E1 */, bool forceTextReparsing = false /* Metadata: 0x006A22E2 */); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UpdateGeometry(Mesh mesh, int index); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UpdateVertexData(TMP_VertexDataUpdateFlags flags); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UpdateVertexData(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetVertices(Vector3[] vertices); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UpdateMeshPadding(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha); // 0x0000000182099CA0-0x0000000182099D40
		public override void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale); // 0x0000000182099C30-0x0000000182099CA0
		protected virtual void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale); // 0x00000001802E76C0-0x00000001802E76D0
		protected void ParseInputText(); // 0x00000001820A2200-0x00000001820A2380
		private void PopulateTextBackingArray(string sourceText); // 0x00000001820A2720-0x00000001820A27C0
		private void PopulateTextBackingArray(string sourceText, int start, int length); // 0x00000001820A2600-0x00000001820A2690
		private void PopulateTextBackingArray(char[] sourceText, int start, int length); // 0x00000001820A2690-0x00000001820A2720
		private void PopulateTextBackingArray(ReadOnlySpan<char> sourceText, int start, int length); // 0x00000001820A2500-0x00000001820A2600
		private void PopulateTextBackingArray(StringBuilder sourceText, int start, int length); // 0x00000001820A2380-0x00000001820A2500
		private void PopulateTextProcessingArray(); // 0x00000001820A27C0-0x00000001820A3710
		private void SetTextInternal(string sourceText); // 0x00000001820A6E40-0x00000001820A6EE0
		public void SetText(string sourceText); // 0x00000001820A7220-0x00000001820A7300
		[Obsolete("Use the SetText(string) function instead.", true)]
		public void SetText(string sourceText, bool syncTextInputBox = true /* Metadata: 0x006A22E3 */); // 0x00000001820A7220-0x00000001820A7300
		public void SetText(string sourceText, float arg0); // 0x00000001820A7550-0x00000001820A7590
		public void SetText(string sourceText, float arg0, float arg1); // 0x00000001820A6EE0-0x00000001820A6F20
		public void SetText(string sourceText, float arg0, float arg1, float arg2); // 0x00000001820A74B0-0x00000001820A7500
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3); // 0x00000001820A7500-0x00000001820A7550
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4); // 0x00000001820A7450-0x00000001820A74B0
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5); // 0x00000001820A7380-0x00000001820A73E0
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6); // 0x00000001820A73E0-0x00000001820A7450
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6, float arg7); // 0x00000001820A6F70-0x00000001820A7220
		public void SetText(ReadOnlySpan<char> sourceText); // 0x00000001820A7300-0x00000001820A7380
		public void SetText(ReadOnlySpan<char> sourceText, int start, int length); // 0x00000001820A75A0-0x00000001820A7620
		public void SetText(StringBuilder sourceText); // 0x00000001820A6F20-0x00000001820A6F70
		private void SetText(StringBuilder sourceText, int start, int length); // 0x00000001820A7620-0x00000001820A77F0
		public void SetText(char[] sourceText); // 0x00000001820A6B30-0x00000001820A6B60
		public void SetText(char[] sourceText, int start, int length); // 0x00000001820A7590-0x00000001820A75A0
		public void SetCharArray(char[] sourceText); // 0x00000001820A6B30-0x00000001820A6B60
		public void SetCharArray(char[] sourceText, int start, int length); // 0x00000001820A6A50-0x00000001820A6B30
		private TMP_Style GetStyle(int hashCode); // 0x000000018209EAC0-0x000000018209EBA0
		private void InsertOpeningTextStyle(TMP_Style style, ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A14E0-0x00000001820A15B0
		private void InsertClosingTextStyle(TMP_Style style, ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A09A0-0x00000001820A0A70
		private void InsertTextStyleInTextProcessingArray(ref TextProcessingElement[] charBuffer, ref int writeIndex, uint[] styleDefinition); // 0x00000001820A15B0-0x00000001820A1A20
		private bool ReplaceOpeningStyleTag(ref TextBackingContainer sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A3AD0-0x00000001820A3C80
		private bool ReplaceOpeningStyleTag(ref uint[] sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A3910-0x00000001820A3AD0
		private void ReplaceClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A3830-0x00000001820A3910
		private void InsertOpeningStyleTag(TMP_Style style, ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A1420-0x00000001820A14E0
		private void InsertClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex); // 0x00000001820A0910-0x00000001820A09A0
		private int GetMarkupTagHashCode(uint[] sourceText, int readIndex); // 0x000000018209D960-0x000000018209DA60
		private int GetMarkupTagHashCode(TextBackingContainer sourceText, int readIndex); // 0x000000018209DA60-0x000000018209DB40
		private int GetStyleHashCode(ref uint[] text, int index, out int closeIndex); // 0x000000018209E9C0-0x000000018209EAC0
		private int GetStyleHashCode(ref TextBackingContainer text, int index, out int closeIndex); // 0x000000018209E8F0-0x000000018209E9C0
		private void ResizeInternalArray<T>(ref ref T[] array);
		private void ResizeInternalArray<T>(ref ref T[] array, int size);
		private void AddFloatToInternalTextBackingArray(float value, int padding, int precision, ref int writeIndex); // 0x0000000182095C60-0x0000000182096090
		private void AddIntegerToInternalTextBackingArray(double number, int padding, ref int writeIndex); // 0x0000000182096090-0x00000001820961E0
		private string InternalTextBackingArrayToString(); // 0x00000001820A1A20-0x00000001820A1B10
		internal virtual int SetArraySizes(TextProcessingElement[] unicodeChars); // 0x00000001802E7860-0x00000001802E7870
		public Vector2 GetPreferredValues(); // 0x000000018209E450-0x000000018209E4B0
		public Vector2 GetPreferredValues(float width, float height); // 0x000000018209E0F0-0x000000018209E160
		public Vector2 GetPreferredValues(string text); // 0x000000018209E160-0x000000018209E2C0
		public Vector2 GetPreferredValues(string text, float width, float height); // 0x000000018209E2C0-0x000000018209E450
		protected float GetPreferredWidth(); // 0x000000018209E4B0-0x000000018209E650
		private float GetPreferredWidth(Vector2 margin); // 0x000000018209E650-0x000000018209E6F0
		private float GetPreferredWidth(Vector2 margin, TextWrappingModes wrapMode); // 0x000000018209E6F0-0x000000018209E780
		protected float GetPreferredHeight(); // 0x000000018209DF40-0x000000018209E0F0
		private float GetPreferredHeight(Vector2 margin); // 0x000000018209DE80-0x000000018209DF40
		public Vector2 GetRenderedValues(); // 0x000000018209E820-0x000000018209E860
		public Vector2 GetRenderedValues(bool onlyVisibleCharacters); // 0x000000018209E7E0-0x000000018209E820
		private float GetRenderedWidth(); // 0x000000018209E890-0x000000018209E8C0
		protected float GetRenderedWidth(bool onlyVisibleCharacters); // 0x000000018209E860-0x000000018209E890
		private float GetRenderedHeight(); // 0x000000018209E7B0-0x000000018209E7E0
		protected float GetRenderedHeight(bool onlyVisibleCharacters); // 0x000000018209E780-0x000000018209E7B0
		protected virtual Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, TextWrappingModes textWrapMode); // 0x0000000182096630-0x0000000182099990
		protected virtual Bounds GetCompoundBounds(); // 0x0000000180A69590-0x0000000180A695A0
		internal virtual Rect GetCanvasSpaceClippingRect(); // 0x000000018209D620-0x000000018209D6C0
		protected Bounds GetTextBounds(); // 0x000000018209EEE0-0x000000018209F1E0
		protected Bounds GetTextBounds(bool onlyVisibleCharacters); // 0x000000018209EBA0-0x000000018209EEE0
		protected void AdjustLineOffset(int startIndex, int endIndex, float offset); // 0x00000001820961E0-0x0000000182096630
		protected void ResizeLineExtents(int size); // 0x00000001820A3CE0-0x00000001820A3F20
		public virtual TMP_TextInfo GetTextInfo(string text); // 0x00000001802E7860-0x00000001802E7870
		public virtual void ComputeMarginSize(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender); // 0x00000001820A0A70-0x00000001820A1420
		internal void SaveWordWrappingState(ref WordWrapState state, int index, int count); // 0x00000001820A6470-0x00000001820A6A50
		internal int RestoreWordWrappingState(ref WordWrapState state); // 0x00000001820A3F20-0x00000001820A4540
		protected virtual void SaveGlyphVertexInfo(float padding, float style_padding, Color32 vertexColor); // 0x00000001820A4540-0x00000001820A5A50
		protected virtual void SaveSpriteVertexInfo(Color32 vertexColor); // 0x00000001820A5A50-0x00000001820A6470
		protected virtual void FillCharacterVertexBuffers(int i); // 0x000000018209C140-0x000000018209CAA0
		protected virtual void FillCharacterVertexBuffers(int i, bool isVolumetric); // 0x000000018209B330-0x000000018209C140
		protected virtual void FillSpriteVertexBuffers(int i); // 0x000000018209CAA0-0x000000018209D400
		protected virtual void DrawUnderlineMesh(Vector3 start, Vector3 end, ref int index, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor); // 0x000000018209A3F0-0x000000018209B330
		protected virtual void DrawTextHighlight(Vector3 start, Vector3 end, ref int index, Color32 highlightColor); // 0x0000000182099DF0-0x000000018209A3F0
		protected void LoadDefaultSettings(); // 0x00000001820A1DA0-0x00000001820A2180
		protected void GetSpecialCharacters(TMP_FontAsset fontAsset); // 0x000000018209E8C0-0x000000018209E8F0
		protected void GetEllipsisSpecialCharacter(TMP_FontAsset fontAsset); // 0x000000018209D6C0-0x000000018209D8D0
		protected void GetUnderlineSpecialCharacter(TMP_FontAsset fontAsset); // 0x000000018209FE40-0x000000018209FED0
		protected void ReplaceTagWithCharacter(int[] chars, int insertionIndex, int tagLength, char c); // 0x00000001820A3C80-0x00000001820A3CE0
		protected TMP_FontAsset GetFontAssetForWeight(int fontWeight); // 0x000000018209D8D0-0x000000018209D960
		internal TMP_TextElement GetTextElement(uint unicode, TMP_FontAsset fontAsset, FontStyles fontStyle, FontWeight fontWeight, out bool isUsingAlternativeTypeface); // 0x000000018209F1E0-0x000000018209F780
		protected virtual void SetActiveSubMeshes(bool state); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void DestroySubMeshObjects(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void ClearMesh(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void ClearMesh(bool uploadGeometry); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual string GetParsedText(); // 0x000000018209DD90-0x000000018209DE80
		internal bool IsSelfOrLinkedAncestor(TMP_Text targetTextComponent); // 0x00000001820A1B10-0x00000001820A1BE0
		internal void ReleaseLinkedTextComponent(TMP_Text targetTextComponent); // 0x00000001820A3710-0x00000001820A3830
		protected void DoMissingGlyphCallback(int unicode, int stringIndex, TMP_FontAsset fontAsset); // 0x0000000182099D40-0x0000000182099DF0
		protected Vector2 PackUV(float x, float y, float scale); // 0x00000001820A21C0-0x00000001820A2200
		protected float PackUV(float x, float y); // 0x00000001820A2180-0x00000001820A21C0
		internal virtual void InternalUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		protected uint HexToInt(char hex); // 0x00000001820A07F0-0x00000001820A0910
		private bool IsValidUTF16(TextBackingContainer text, int index); // 0x00000001820A1BE0-0x00000001820A1C60
		private bool IsValidUTF16(ReadOnlySpan<uint> text, int index); // 0x00000001820A1C60-0x00000001820A1CC0
		private uint GetUTF16(uint[] text, int i); // 0x000000018209F780-0x000000018209F850
		private uint GetUTF16(TextBackingContainer text, int i); // 0x000000018209F850-0x000000018209F920
		private uint GetUTF16(ReadOnlySpan<uint> text, int i); // 0x000000018209F920-0x000000018209F9F0
		private bool IsValidUTF32(TextBackingContainer text, int index); // 0x00000001820A1CC0-0x00000001820A1D40
		private bool IsValidUTF32(ReadOnlySpan<uint> text, int index); // 0x00000001820A1D40-0x00000001820A1DA0
		private uint GetUTF32(uint[] text, int i); // 0x000000018209FB60-0x000000018209FCE0
		private uint GetUTF32(TextBackingContainer text, int i); // 0x000000018209FCE0-0x000000018209FE40
		private uint GetUTF32(ReadOnlySpan<uint> text, int i); // 0x000000018209F9F0-0x000000018209FB60
		protected Color32 HexCharsToColor(char[] hexChars, int tagCount); // 0x00000001820A0180-0x00000001820A07F0
		protected Color32 HexCharsToColor(char[] hexChars, int startIndex, int length); // 0x000000018209FED0-0x00000001820A0180
		private int GetAttributeParameters(char[] chars, int startIndex, int length, float[] parameters); // 0x000000018209D400-0x000000018209D620
		protected float ConvertToFloat(char[] chars, int startIndex, int length); // 0x0000000182099B40-0x0000000182099B70
		protected float ConvertToFloat(char[] chars, int startIndex, int length, out int lastIndex); // 0x0000000182099990-0x0000000182099B40
		private bool TryLoadAsset<TAsset>(int assetHashCode, string assetName, string defaultResourcePath, Func<int, string, TAsset> assetRequest, out ref TAsset asset)
			where TAsset : UnityEngine.Object;
		private void SetCurrentFontMaterialFromAttributes(RichTextTagAttribute[] attributes); // 0x00000001820A6B60-0x00000001820A6E40
		internal bool ValidateHtmlTag(TextProcessingElement[] chars, int startIndex, out int endIndex); // 0x00000001820A78A0-0x00000001820AD800
	}
}
