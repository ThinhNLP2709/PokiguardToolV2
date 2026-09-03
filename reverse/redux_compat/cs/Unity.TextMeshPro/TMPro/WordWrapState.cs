/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	internal struct WordWrapState // TypeDefIndex: 11937
	{
		// Fields
		public int previous_WordBreak; // 0x00
		public int total_CharacterCount; // 0x04
		public int visible_CharacterCount; // 0x08
		public int visibleSpaceCount; // 0x0C
		public int visible_SpriteCount; // 0x10
		public int visible_LinkCount; // 0x14
		public int firstCharacterIndex; // 0x18
		public int firstVisibleCharacterIndex; // 0x1C
		public int lastCharacterIndex; // 0x20
		public int lastVisibleCharIndex; // 0x24
		public int lineNumber; // 0x28
		public float maxCapHeight; // 0x2C
		public float maxAscender; // 0x30
		public float maxDescender; // 0x34
		public float startOfLineAscender; // 0x38
		public float maxLineAscender; // 0x3C
		public float maxLineDescender; // 0x40
		public float pageAscender; // 0x44
		public HorizontalAlignmentOptions horizontalAlignment; // 0x48
		public float marginLeft; // 0x4C
		public float marginRight; // 0x50
		public float xAdvance; // 0x54
		public float preferredWidth; // 0x58
		public float preferredHeight; // 0x5C
		public float renderedWidth; // 0x60
		public float renderedHeight; // 0x64
		public float previousLineScale; // 0x68
		public int wordCount; // 0x6C
		public FontStyles fontStyle; // 0x70
		public int italicAngle; // 0x74
		public float fontScaleMultiplier; // 0x78
		public float currentFontSize; // 0x7C
		public float baselineOffset; // 0x80
		public float lineOffset; // 0x84
		public bool isDrivenLineSpacing; // 0x88
		public int lastBaseGlyphIndex; // 0x8C
		public float cSpace; // 0x90
		public float mSpace; // 0x94
		public TMP_TextInfo textInfo; // 0x98
		public TMP_LineInfo lineInfo; // 0xA0
		public Color32 vertexColor; // 0x100
		public Color32 underlineColor; // 0x104
		public Color32 strikethroughColor; // 0x108
		public HighlightState highlightState; // 0x10C
		public TMP_FontStyleStack basicStyleStack; // 0x120
		public TMP_TextProcessingStack<int> italicAngleStack; // 0x130
		public TMP_TextProcessingStack<Color32> colorStack; // 0x150
		public TMP_TextProcessingStack<Color32> underlineColorStack; // 0x170
		public TMP_TextProcessingStack<Color32> strikethroughColorStack; // 0x190
		public TMP_TextProcessingStack<Color32> highlightColorStack; // 0x1B0
		public TMP_TextProcessingStack<HighlightState> highlightStateStack; // 0x1D0
		public TMP_TextProcessingStack<TMP_ColorGradient> colorGradientStack; // 0x200
		public TMP_TextProcessingStack<float> sizeStack; // 0x228
		public TMP_TextProcessingStack<float> indentStack; // 0x248
		public TMP_TextProcessingStack<FontWeight> fontWeightStack; // 0x268
		public TMP_TextProcessingStack<int> styleStack; // 0x288
		public TMP_TextProcessingStack<float> baselineStack; // 0x2A8
		public TMP_TextProcessingStack<int> actionStack; // 0x2C8
		public TMP_TextProcessingStack<MaterialReference> materialReferenceStack; // 0x2E8
		public TMP_TextProcessingStack<HorizontalAlignmentOptions> lineJustificationStack; // 0x340
		public int spriteAnimationID; // 0x360
		public TMP_FontAsset currentFontAsset; // 0x368
		public TMP_SpriteAsset currentSpriteAsset; // 0x370
		public Material currentMaterial; // 0x378
		public int currentMaterialIndex; // 0x380
		public Extents meshExtents; // 0x384
		public bool tagNoParsing; // 0x394
		public bool isNonBreakingSpace; // 0x395
		public Quaternion fxRotation; // 0x398
		public Vector3 fxScale; // 0x3A8
	}
}
