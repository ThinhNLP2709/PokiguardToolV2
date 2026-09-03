/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	internal class TMP_DynamicFontAssetUtilities // TypeDefIndex: 11811
	{
		// Fields
		private static TMP_DynamicFontAssetUtilities s_Instance; // 0x00
		private Dictionary<ulong, FontReference> s_SystemFontLookup; // 0x10
		private string[] s_SystemFontPaths; // 0x18
		private const uint s_RegularStyleNameHashCode = 1291372090; // Metadata: 0x006A1F40
	
		// Nested types
		public struct FontReference // TypeDefIndex: 11812
		{
			// Fields
			public string familyName; // 0x00
			public string styleName; // 0x08
			public int faceIndex; // 0x10
			public string filePath; // 0x18
			public ulong hashCode; // 0x20
	
			// Constructors
			public FontReference(string fontFilePath, string faceNameAndStyle, int index); // 0x000000018206D160-0x000000018206D480
		}
	
		// Constructors
		public TMP_DynamicFontAssetUtilities(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static TMP_DynamicFontAssetUtilities(); // 0x00000001820768A0-0x0000000182076910
	
		// Methods
		private void InitializeSystemFontReferenceCache(); // 0x0000000182075E00-0x00000001820764C0
		public static bool TryGetSystemFontReference(string familyName, out FontReference fontRef); // 0x0000000182076810-0x00000001820768A0
		public static bool TryGetSystemFontReference(string familyName, string styleName, out FontReference fontRef); // 0x0000000182076780-0x0000000182076810
		private bool TryGetSystemFontReferenceInternal(string familyName, string styleName, out FontReference fontRef); // 0x00000001820764C0-0x0000000182076780
	}
}
