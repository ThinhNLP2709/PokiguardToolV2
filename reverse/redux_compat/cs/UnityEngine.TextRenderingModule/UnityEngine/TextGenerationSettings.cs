/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 62: UnityEngine.TextRenderingModule.dll - Assembly: UnityEngine.TextRenderingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15763-15782

namespace UnityEngine
{
	public struct TextGenerationSettings // TypeDefIndex: 15768
	{
		// Fields
		public Font font; // 0x00
		public Color color; // 0x08
		public int fontSize; // 0x18
		public float lineSpacing; // 0x1C
		public bool richText; // 0x20
		public float scaleFactor; // 0x24
		public FontStyle fontStyle; // 0x28
		public TextAnchor textAnchor; // 0x2C
		public bool alignByGeometry; // 0x30
		public bool resizeTextForBestFit; // 0x31
		public int resizeTextMinSize; // 0x34
		public int resizeTextMaxSize; // 0x38
		public bool updateBounds; // 0x3C
		public VerticalWrapMode verticalOverflow; // 0x40
		public HorizontalWrapMode horizontalOverflow; // 0x44
		public Vector2 generationExtents; // 0x48
		public Vector2 pivot; // 0x50
		public bool generateOutOfBounds; // 0x58
	
		// Methods
		private bool CompareColors(Color left, Color right); // 0x000000018234FE50-0x000000018234FF30
		private bool CompareVector2(Vector2 left, Vector2 right); // 0x000000018234FF30-0x000000018234FFD0
		public bool Equals(TextGenerationSettings other); // 0x000000018234FFD0-0x00000001823502E0
	}
}
