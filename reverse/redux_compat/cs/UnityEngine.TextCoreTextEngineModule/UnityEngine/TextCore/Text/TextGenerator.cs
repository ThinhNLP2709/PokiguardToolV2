/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal class TextGenerator // TypeDefIndex: 12681
	{
		// Fields
		private static readonly ProfilerMarker s_GenerateTextMarker; // 0x00
		[CompilerGenerated]
		private static bool _IsExecutingJob_k__BackingField; // 0x08
		private TextBackingContainer m_TextBackingArray; // 0x10
		internal TextProcessingElement[] m_TextProcessingArray; // 0x20
		internal int m_InternalTextProcessingArraySize; // 0x28
		[SerializeField]
		protected bool m_VertexBufferAutoSizeReduction; // 0x2C
		private char[] m_HtmlTag; // 0x30
		internal HighlightState m_HighlightState; // 0x38
		protected bool m_IsIgnoringAlignment; // 0x4C
		protected bool m_IsTextTruncated; // 0x4D
		[CompilerGenerated]
		private static MissingCharacterEventCallback OnMissingCharacter; // 0x10
		private Vector3[] m_RectTransformCorners; // 0x50
		private float m_MarginWidth; // 0x58
		private float m_MarginHeight; // 0x5C
		private float m_PreferredWidth; // 0x60
		private float m_PreferredHeight; // 0x64
		private FontAsset m_CurrentFontAsset; // 0x68
		private Material m_CurrentMaterial; // 0x70
		private int m_CurrentMaterialIndex; // 0x78
		private TextProcessingStack<MaterialReference> m_MaterialReferenceStack; // 0x80
		private float m_Padding; // 0xD8
		private SpriteAsset m_CurrentSpriteAsset; // 0xE0
		private int m_TotalCharacterCount; // 0xE8
		private float m_FontSize; // 0xEC
		private float m_FontScaleMultiplier; // 0xF0
		private bool m_ShouldRenderBitmap; // 0xF4
		private float m_CurrentFontSize; // 0xF8
		private TextProcessingStack<float> m_SizeStack; // 0x100
		protected TextProcessingStack<int>[] m_TextStyleStacks; // 0x120
		protected int m_TextStyleStackDepth; // 0x128
		private FontStyles m_FontStyleInternal; // 0x12C
		private FontStyleStack m_FontStyleStack; // 0x130
		private TextFontWeight m_FontWeightInternal; // 0x13C
		private TextProcessingStack<TextFontWeight> m_FontWeightStack; // 0x140
		private TextAlignment m_LineJustification; // 0x160
		private TextProcessingStack<TextAlignment> m_LineJustificationStack; // 0x168
		private float _m_BaselineOffset; // 0x188
		private TextProcessingStack<float> m_BaselineOffsetStack; // 0x190
		private Color32 m_FontColor32; // 0x1B0
		private Color32 m_HtmlColor; // 0x1B4
		private Color32 m_UnderlineColor; // 0x1B8
		private Color32 m_StrikethroughColor; // 0x1BC
		private TextProcessingStack<Color32> m_ColorStack; // 0x1C0
		private TextProcessingStack<Color32> m_UnderlineColorStack; // 0x1E0
		private TextProcessingStack<Color32> m_StrikethroughColorStack; // 0x200
		private TextProcessingStack<Color32> m_HighlightColorStack; // 0x220
		private TextProcessingStack<HighlightState> m_HighlightStateStack; // 0x240
		private TextProcessingStack<int> m_ItalicAngleStack; // 0x270
		private TextColorGradient m_ColorGradientPreset; // 0x290
		private TextProcessingStack<TextColorGradient> m_ColorGradientStack; // 0x298
		private bool m_ColorGradientPresetIsTinted; // 0x2C0
		private TextProcessingStack<int> m_ActionStack; // 0x2C8
		private float _m_LineOffset; // 0x2E8
		private float _m_LineHeight; // 0x2EC
		private bool m_IsDrivenLineSpacing; // 0x2F0
		private float m_CSpacing; // 0x2F4
		private float m_MonoSpacing; // 0x2F8
		private bool m_DuoSpace; // 0x2FC
		private float _m_XAdvance; // 0x300
		private float m_TagLineIndent; // 0x304
		private float m_TagIndent; // 0x308
		private TextProcessingStack<float> m_IndentStack; // 0x310
		private bool m_TagNoParsing; // 0x330
		private int m_CharacterCount; // 0x334
		private int m_FirstCharacterOfLine; // 0x338
		private int m_LastCharacterOfLine; // 0x33C
		private int m_FirstVisibleCharacterOfLine; // 0x340
		private int m_LastVisibleCharacterOfLine; // 0x344
		private float m_MaxLineAscender; // 0x348
		private float m_MaxLineDescender; // 0x34C
		private int m_LineNumber; // 0x350
		private int m_LineVisibleCharacterCount; // 0x354
		private int m_LineVisibleSpaceCount; // 0x358
		private int m_FirstOverflowCharacterIndex; // 0x35C
		private float m_MarginLeft; // 0x360
		private float m_MarginRight; // 0x364
		private float m_Width; // 0x368
		private Extents m_MeshExtents; // 0x36C
		private float m_MaxCapHeight; // 0x37C
		private float m_MaxAscender; // 0x380
		private float m_MaxDescender; // 0x384
		private bool m_IsNonBreakingSpace; // 0x388
		private WordWrapState m_SavedWordWrapState; // 0x390
		private WordWrapState m_SavedLineState; // 0x728
		private WordWrapState m_SavedEllipsisState; // 0xAC0
		private WordWrapState m_SavedLastValidState; // 0xE58
		private WordWrapState m_SavedSoftLineBreakState; // 0x11F0
		private TextElementType m_TextElementType; // 0x1588
		private bool m_isTextLayoutPhase; // 0x1589
		private int m_SpriteIndex; // 0x158C
		private Color32 m_SpriteColor; // 0x1590
		private TextElement m_CachedTextElement; // 0x1598
		private Color32 m_HighlightColor; // 0x15A0
		private float m_CharWidthAdjDelta; // 0x15A4
		private float m_MaxFontSize; // 0x15A8
		private float m_MinFontSize; // 0x15AC
		private int m_AutoSizeIterationCount; // 0x15B0
		private int m_AutoSizeMaxIterationCount; // 0x15B4
		private float m_StartOfLineAscender; // 0x15B8
		private float m_LineSpacingDelta; // 0x15BC
		internal MaterialReference[] m_MaterialReferences; // 0x15C0
		private int m_SpriteCount; // 0x15C8
		private TextProcessingStack<int> m_StyleStack; // 0x15D0
		private TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack; // 0x15F0
		private int m_SpriteAnimationId; // 0x19A8
		private int m_ItalicAngle; // 0x19AC
		private Vector3 m_FXScale; // 0x19B0
		private Quaternion m_FXRotation; // 0x19BC
		private int m_LastBaseGlyphIndex; // 0x19CC
		private float m_PageAscender; // 0x19D0
		private RichTextTagAttribute[] m_XmlAttribute; // 0x19D8
		private float[] m_AttributeParameterValues; // 0x19E0
		private Dictionary<int, int> m_MaterialReferenceIndexLookup; // 0x19E8
		private bool m_IsCalculatingPreferredValues; // 0x19F0
		private bool m_TintSprite; // 0x19F1
		protected SpecialCharacter m_Ellipsis; // 0x19F8
		protected SpecialCharacter m_Underline; // 0x1A18
		private TextElementInfo[] m_InternalTextElementInfo; // 0x1A38
		internal static readonly bool EnableTextAlignmentAssertions; // 0x18
		internal static readonly bool EnableCheckerboardPattern; // 0x19
		private static readonly ProfilerMarker s_CalculatePreferredValuesMarker; // 0x20
		private static readonly ProfilerMarker s_PrepareMarker; // 0x28
	
		// Properties
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool IsExecutingJob { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182330860-0x00000001823308B0 0x00000001823308D0-0x0000000182330930
		public bool isTextTruncated { get; } // 0x000000018169C650-0x000000018169C660 
		private float m_BaselineOffset { get; set; } // 0x00000001823308C0-0x00000001823308D0 0x0000000182330930-0x0000000182330970
		private float m_LineOffset { get; set; } // 0x00000001820AF230-0x00000001820AF240 0x00000001823309B0-0x00000001823309F0
		private float m_LineHeight { get; set; } // 0x00000001820AFFF0-0x00000001820B0000 0x0000000182330970-0x00000001823309B0
		private float m_XAdvance { get; set; } // 0x00000001820AF6B0-0x00000001820AF6C0 0x00000001823309F0-0x0000000182330B30
		private bool NeedToRound { get; } // 0x00000001823308B0-0x00000001823308C0 
	
		// Nested types
		public delegate void MissingCharacterEventCallback(uint unicode, int stringIndex, TextInfo text, FontAsset fontAsset); // TypeDefIndex: 12682; 0x000000018043A200-0x000000018043A220
	
		protected struct SpecialCharacter // TypeDefIndex: 12683
		{
			// Fields
			public Character character; // 0x00
			public FontAsset fontAsset; // 0x08
			public Material material; // 0x10
			public int materialIndex; // 0x18
	
			// Constructors
			public SpecialCharacter(Character character, int materialIndex); // 0x0000000182333EF0-0x0000000182334050
		}
	
		// Constructors
		public TextGenerator(); // 0x000000018232FEE0-0x0000000182330860
		static TextGenerator(); // 0x000000018232FDE0-0x000000018232FEE0
	
		// Methods
		public void GenerateText(TextGenerationSettings settings, TextInfo textInfo); // 0x0000000182318900-0x0000000182318B50
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void GenerateTextMesh(TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182318210-0x0000000182318900
		private bool ValidateHtmlTag(TextProcessingElement[] chars, int startIndex, out int endIndex, TextGenerationSettings generationSettings, TextInfo textInfo, out bool isThreadSuccess); // 0x000000018232AAC0-0x000000018232FDE0
		internal void CloseLastLinkTag(TextInfo textInfo); // 0x0000000182316BF0-0x0000000182316C80
		internal void CloseAllLinkTags(TextInfo textInfo); // 0x0000000182316B80-0x0000000182316BF0
		private void CloseLinkTag(TextInfo textInfo, int index); // 0x0000000182316C80-0x0000000182316CF0
		private void ClearMarkupTagAttributes(); // 0x0000000182316AF0-0x0000000182316B50
		private void SaveWordWrappingState(ref WordWrapState state, int index, int count, TextInfo textInfo); // 0x0000000182328270-0x0000000182328800
		private int RestoreWordWrappingState(ref WordWrapState state, TextInfo textInfo); // 0x0000000182326960-0x0000000182326F40
		private void SaveGlyphVertexInfo(float padding, float stylePadding, Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182326F60-0x0000000182327BA0
		private void SaveSpriteVertexInfo(Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182327BA0-0x0000000182328270
		private void EnsureMeshInfoCapacityForMaterialReferences(TextInfo textInfo, TextGenerationSettings generationSettings); // 0x0000000182317EE0-0x0000000182318210
		private void DrawUnderlineMesh(Vector3 start, Vector3 end, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182317440-0x0000000182317EE0
		private void DrawTextHighlight(Vector3 start, Vector3 end, Color32 highlightColor, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182316ED0-0x0000000182317440
		private static void ClearMesh(bool updateMesh, TextInfo textInfo); // 0x0000000182316B50-0x0000000182316B80
		public void LayoutPhase(TextInfo textInfo, TextGenerationSettings generationSettings, float maxVisibleDescender); // 0x000000018231AA60-0x000000018231E510
		private float Round(float v); // 0x0000000182326F40-0x0000000182326F60
		public void ParsingPhase(TextInfo textInfo, TextGenerationSettings generationSettings, out uint charCode, out float maxVisibleDescender); // 0x000000018231E510-0x0000000182323F40
		private void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x000000018231A140-0x000000018231AA60
		public Vector2 GetPreferredValues(TextGenerationSettings settings, TextInfo textInfo); // 0x0000000182319020-0x0000000182319250
		private Vector2 GetPreferredValuesInternal(TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182318ED0-0x0000000182319020
		protected virtual Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182313110-0x0000000182316AF0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void Prepare(TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182326590-0x0000000182326960
		internal bool PrepareFontAsset(TextGenerationSettings generationSettings); // 0x00000001823264A0-0x0000000182326590
		private int SetArraySizes(TextProcessingElement[] textProcessingArray, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x0000000182328800-0x000000018232AAC0
		private TextElement GetTextElement(TextGenerationSettings generationSettings, uint unicode, FontAsset fontAsset, FontStyles fontStyle, TextFontWeight fontWeight, out bool isUsingAlternativeTypeface, bool populateLigatures); // 0x00000001823195B0-0x0000000182319BC0
		private void PopulateTextBackingArray([IsReadOnly] in RenderedText sourceText); // 0x0000000182325560-0x0000000182325660
		private void PopulateTextProcessingArray(TextGenerationSettings generationSettings); // 0x0000000182325660-0x00000001823264A0
		private bool PopulateFontAsset(TextGenerationSettings generationSettings, TextProcessingElement[] textProcessingArray); // 0x0000000182323F40-0x0000000182325560
		private void ComputeMarginSize(Rect rect, Vector4 margins); // 0x0000000182316CF0-0x0000000182316E30
		protected bool GetSpecialCharacters(TextGenerationSettings generationSettings); // 0x0000000182319250-0x00000001823192B0
		protected bool GetEllipsisSpecialCharacter(TextGenerationSettings generationSettings); // 0x0000000182318B50-0x0000000182318ED0
		protected bool GetUnderlineSpecialCharacter(TextGenerationSettings generationSettings); // 0x0000000182319BC0-0x000000018231A140
		protected void DoMissingGlyphCallback(uint unicode, int stringIndex, FontAsset fontAsset, TextInfo textInfo); // 0x0000000182316E30-0x0000000182316ED0
		private static SpriteCharacter GetSpriteCharacterFromSpriteAssetThreadSafe(uint unicode, SpriteAsset spriteAsset); // 0x00000001823192B0-0x0000000182319410
		private static SpriteCharacter GetSpriteFromFallbacksThreadSafe(uint unicode, List<SpriteAsset> fallbacks, HashSet<int> searched); // 0x0000000182319410-0x00000001823195B0
	}
}
