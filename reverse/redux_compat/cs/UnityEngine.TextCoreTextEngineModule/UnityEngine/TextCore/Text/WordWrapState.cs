/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	internal struct WordWrapState // TypeDefIndex: 12700
	{
		// Fields
		public int previousWordBreak; // 0x00
		public int totalCharacterCount; // 0x04
		public int visibleCharacterCount; // 0x08
		public int visibleSpaceCount; // 0x0C
		public int visibleSpriteCount; // 0x10
		public int visibleLinkCount; // 0x14
		public int firstCharacterIndex; // 0x18
		public int firstVisibleCharacterIndex; // 0x1C
		public int lastCharacterIndex; // 0x20
		public int lastVisibleCharIndex; // 0x24
		public int lineNumber; // 0x28
		public float maxCapHeight; // 0x2C
		public float maxAscender; // 0x30
		public float maxDescender; // 0x34
		public float maxLineAscender; // 0x38
		public float maxLineDescender; // 0x3C
		public float startOfLineAscender; // 0x40
		public float xAdvance; // 0x44
		public float preferredWidth; // 0x48
		public float preferredHeight; // 0x4C
		public float previousLineScale; // 0x50
		public float pageAscender; // 0x54
		public int wordCount; // 0x58
		public FontStyles fontStyle; // 0x5C
		public float fontScale; // 0x60
		public float fontScaleMultiplier; // 0x64
		public int italicAngle; // 0x68
		public float currentFontSize; // 0x6C
		public float baselineOffset; // 0x70
		public float lineOffset; // 0x74
		public TextInfo textInfo; // 0x78
		public LineInfo lineInfo; // 0x80
		public Color32 vertexColor; // 0xE0
		public Color32 underlineColor; // 0xE4
		public Color32 strikethroughColor; // 0xE8
		public Color32 highlightColor; // 0xEC
		public HighlightState highlightState; // 0xF0
		public FontStyleStack basicStyleStack; // 0x104
		public TextProcessingStack<int> italicAngleStack; // 0x110
		public TextProcessingStack<Color32> colorStack; // 0x130
		public TextProcessingStack<Color32> underlineColorStack; // 0x150
		public TextProcessingStack<Color32> strikethroughColorStack; // 0x170
		public TextProcessingStack<Color32> highlightColorStack; // 0x190
		public TextProcessingStack<HighlightState> highlightStateStack; // 0x1B0
		public TextProcessingStack<TextColorGradient> colorGradientStack; // 0x1E0
		public TextProcessingStack<float> sizeStack; // 0x208
		public TextProcessingStack<float> indentStack; // 0x228
		public TextProcessingStack<TextFontWeight> fontWeightStack; // 0x248
		public TextProcessingStack<int> styleStack; // 0x268
		public TextProcessingStack<float> baselineStack; // 0x288
		public TextProcessingStack<int> actionStack; // 0x2A8
		public TextProcessingStack<MaterialReference> materialReferenceStack; // 0x2C8
		public TextProcessingStack<TextAlignment> lineJustificationStack; // 0x320
		public int lastBaseGlyphIndex; // 0x340
		public int spriteAnimationId; // 0x344
		public FontAsset currentFontAsset; // 0x348
		public SpriteAsset currentSpriteAsset; // 0x350
		public Material currentMaterial; // 0x358
		public int currentMaterialIndex; // 0x360
		public Extents meshExtents; // 0x364
		public bool tagNoParsing; // 0x374
		public bool isNonBreakingSpace; // 0x375
		public bool isDrivenLineSpacing; // 0x376
		public Vector3 fxScale; // 0x378
		public Quaternion fxRotation; // 0x384
	}
}
