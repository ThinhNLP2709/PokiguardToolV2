/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct LineInfo // TypeDefIndex: 12646
	{
		// Fields
		internal int controlCharacterCount; // 0x00
		public int characterCount; // 0x04
		public int visibleCharacterCount; // 0x08
		public int visibleSpaceCount; // 0x0C
		public int spaceCount; // 0x10
		public int wordCount; // 0x14
		public int firstCharacterIndex; // 0x18
		public int firstVisibleCharacterIndex; // 0x1C
		public int lastCharacterIndex; // 0x20
		public int lastVisibleCharacterIndex; // 0x24
		public float length; // 0x28
		public float lineHeight; // 0x2C
		public float ascender; // 0x30
		public float baseline; // 0x34
		public float descender; // 0x38
		public float maxAdvance; // 0x3C
		public float width; // 0x40
		public float marginLeft; // 0x44
		public float marginRight; // 0x48
		public TextAlignment alignment; // 0x4C
		public Extents lineExtents; // 0x50
	}
}
