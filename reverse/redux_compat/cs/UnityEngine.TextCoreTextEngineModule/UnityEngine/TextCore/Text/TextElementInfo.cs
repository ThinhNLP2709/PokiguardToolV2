/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct TextElementInfo // TypeDefIndex: 12679
	{
		// Fields
		public uint character; // 0x00
		public int index; // 0x04
		public TextElementType elementType; // 0x08
		public int stringLength; // 0x0C
		public TextElement textElement; // 0x10
		public Glyph alternativeGlyph; // 0x18
		public FontAsset fontAsset; // 0x20
		public SpriteAsset spriteAsset; // 0x28
		public Material material; // 0x30
		public int materialReferenceIndex; // 0x38
		public bool isUsingAlternateTypeface; // 0x3C
		public float pointSize; // 0x40
		public int lineNumber; // 0x44
		public int vertexIndex; // 0x48
		public TextVertex vertexTopLeft; // 0x4C
		public TextVertex vertexBottomLeft; // 0x74
		public TextVertex vertexTopRight; // 0x9C
		public TextVertex vertexBottomRight; // 0xC4
		public Vector3 topLeft; // 0xEC
		public Vector3 bottomLeft; // 0xF8
		public Vector3 topRight; // 0x104
		public Vector3 bottomRight; // 0x110
		public float origin; // 0x11C
		public float ascender; // 0x120
		public float baseLine; // 0x124
		public float descender; // 0x128
		internal float adjustedAscender; // 0x12C
		internal float adjustedDescender; // 0x130
		internal float adjustedHorizontalAdvance; // 0x134
		public float xAdvance; // 0x138
		public float aspectRatio; // 0x13C
		public float scale; // 0x140
		public Color32 color; // 0x144
		public Color32 underlineColor; // 0x148
		public int underlineVertexIndex; // 0x14C
		public Color32 strikethroughColor; // 0x150
		public int strikethroughVertexIndex; // 0x154
		public Color32 highlightColor; // 0x158
		public HighlightState highlightState; // 0x15C
		public FontStyles style; // 0x170
		public bool isVisible; // 0x174
	
		// Methods
		public override string ToString(); // 0x0000000182336B80-0x0000000182338C30
	}
}
