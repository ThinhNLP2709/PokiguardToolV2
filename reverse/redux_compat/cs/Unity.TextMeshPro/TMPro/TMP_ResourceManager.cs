/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMP_ResourceManager // TypeDefIndex: 11863
	{
		// Fields
		private static TMP_Settings s_TextSettings; // 0x00
		private static readonly Dictionary<EntityId, FontAssetRef> s_FontAssetReferences; // 0x08
		private static readonly Dictionary<int, TMP_FontAsset> s_FontAssetNameReferenceLookup; // 0x10
		private static readonly Dictionary<long, TMP_FontAsset> s_FontAssetFamilyNameAndStyleReferenceLookup; // 0x18
		private static readonly List<EntityId> s_FontAssetRemovalList; // 0x20
		private static readonly int k_RegularStyleHashCode; // 0x28
	
		// Nested types
		private struct FontAssetRef // TypeDefIndex: 11864
		{
			// Fields
			public int nameHashCode; // 0x00
			public int familyNameHashCode; // 0x04
			public int styleNameHashCode; // 0x08
			public long familyNameAndStyleHashCode; // 0x10
			public readonly TMP_FontAsset fontAsset; // 0x18
	
			// Constructors
			public FontAssetRef(int nameHashCode, int familyNameHashCode, int styleNameHashCode, TMP_FontAsset fontAsset); // 0x00000001820BEF70-0x00000001820BEFB0
		}
	
		// Constructors
		static TMP_ResourceManager(); // 0x00000001820C8A80-0x00000001820C8C90
	
		// Methods
		internal static TMP_Settings GetTextSettings(); // 0x00000001820C82E0-0x00000001820C83D0
		public static void AddFontAsset(TMP_FontAsset fontAsset); // 0x00000001820C7D80-0x00000001820C82A0
		public static void RemoveFontAsset(TMP_FontAsset fontAsset); // 0x00000001820C87B0-0x00000001820C8900
		internal static bool TryGetFontAssetByName(int nameHashcode, out TMP_FontAsset fontAsset); // 0x00000001820C89E0-0x00000001820C8A80
		internal static bool TryGetFontAssetByFamilyName(int familyNameHashCode, int styleNameHashCode, out TMP_FontAsset fontAsset); // 0x00000001820C8900-0x00000001820C89E0
		public static void ClearFontAssetGlyphCache(); // 0x00000001820C82A0-0x00000001820C82E0
		internal static void RebuildFontAssetCache(); // 0x00000001820C83D0-0x00000001820C87B0
	}
}
