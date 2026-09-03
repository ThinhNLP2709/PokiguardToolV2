/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public struct FontAssetCreationSettings // TypeDefIndex: 11818
	{
		// Fields
		public string sourceFontFileName; // 0x00
		public string sourceFontFileGUID; // 0x08
		public int faceIndex; // 0x10
		public int pointSizeSamplingMode; // 0x14
		public int pointSize; // 0x18
		public int padding; // 0x1C
		public int paddingMode; // 0x20
		public int packingMode; // 0x24
		public int atlasWidth; // 0x28
		public int atlasHeight; // 0x2C
		public int characterSetSelectionMode; // 0x30
		public string characterSequence; // 0x38
		public string referencedFontAssetGUID; // 0x40
		public string referencedTextAssetGUID; // 0x48
		public int fontStyle; // 0x50
		public float fontStyleModifier; // 0x54
		public int renderMode; // 0x58
		public bool includeFontFeatures; // 0x5C
	
		// Constructors
		internal FontAssetCreationSettings(string sourceFontFileGUID, int pointSize, int pointSizeSamplingMode, int padding, int packingMode, int atlasWidth, int atlasHeight, int characterSelectionMode, string characterSet, int renderMode); // 0x00000001820824A0-0x00000001820825A0
	}
}
