/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[ExcludeFromPreset]
	[TMPHelpURL("Sprites")]
	public class TMP_SpriteAsset : TMP_Asset // TypeDefIndex: 11877
	{
		// Fields
		internal Dictionary<int, int> m_NameLookup; // 0xA0
		internal Dictionary<uint, int> m_GlyphIndexLookup; // 0xA8
		public Texture spriteSheet; // 0xB0
		[SerializeField]
		private List<TMP_SpriteCharacter> m_SpriteCharacterTable; // 0xB8
		internal Dictionary<uint, TMP_SpriteCharacter> m_SpriteCharacterLookup; // 0xC0
		[FormerlySerializedAs("m_SpriteGlyphTable")]
		[SerializeField]
		private List<TMP_SpriteGlyph> m_GlyphTable; // 0xC8
		internal Dictionary<uint, TMP_SpriteGlyph> m_SpriteGlyphLookup; // 0xD0
		public List<TMP_Sprite> spriteInfoList; // 0xD8
		[SerializeField]
		public List<TMP_SpriteAsset> fallbackSpriteAssets; // 0xE0
		internal bool m_IsSpriteAssetLookupTablesDirty; // 0xE8
		private static HashSet<EntityId> k_searchedSpriteAssets; // 0x00
	
		// Properties
		public List<TMP_SpriteCharacter> spriteCharacterTable { get; internal set; } // 0x00000001820CC120-0x00000001820CC160 0x00000001806CCDE0-0x00000001806CCE00
		public Dictionary<uint, TMP_SpriteCharacter> spriteCharacterLookupTable { get; internal set; } // 0x00000001820CC0E0-0x00000001820CC120 0x00000001806CCDA0-0x00000001806CCDC0
		public List<TMP_SpriteGlyph> spriteGlyphTable { get; internal set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001806CCD60-0x00000001806CCD80
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11878
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<TMP_SpriteGlyph, uint> __9__32_0; // 0x08
			public static Func<TMP_SpriteCharacter, uint> __9__33_0; // 0x10
	
			// Constructors
			static __c(); // 0x00000001820D22D0-0x00000001820D2340
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortGlyphTable_b__32_0(TMP_SpriteGlyph item); // 0x000000018030F200-0x000000018030F220
			internal uint _SortCharacterTable_b__33_0(TMP_SpriteCharacter c); // 0x0000000182095970-0x0000000182095990
		}
	
		// Constructors
		public TMP_SpriteAsset(); // 0x00000001820CC010-0x00000001820CC0E0
	
		// Methods
		private void Awake(); // 0x00000001820CA3A0-0x00000001820CA420
		private Material GetDefaultSpriteMaterial(); // 0x00000001820CA420-0x00000001820CA4F0
		public void UpdateLookupTables(); // 0x00000001820CB650-0x00000001820CBBB0
		public int GetSpriteIndexFromHashcode(int hashCode); // 0x00000001820CA4F0-0x00000001820CA580
		public int GetSpriteIndexFromUnicode(uint unicode); // 0x00000001820CA600-0x00000001820CA6A0
		public int GetSpriteIndexFromName(string name); // 0x00000001820CA580-0x00000001820CA600
		public static TMP_SpriteAsset SearchForSpriteByUnicode(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex); // 0x00000001820CAEB0-0x00000001820CB110
		private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(List<TMP_SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, out int spriteIndex); // 0x00000001820CAC90-0x00000001820CAE10
		private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex); // 0x00000001820CAE10-0x00000001820CAEB0
		public static TMP_SpriteAsset SearchForSpriteByHashCode(TMP_SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex); // 0x00000001820CA8C0-0x00000001820CAC90
		private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(List<TMP_SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, out int spriteIndex); // 0x00000001820CA740-0x00000001820CA8C0
		private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(TMP_SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, out int spriteIndex); // 0x00000001820CA6A0-0x00000001820CA740
		public void SortGlyphTable(); // 0x00000001820CB4F0-0x00000001820CB650
		internal void SortCharacterTable(); // 0x00000001820CB110-0x00000001820CB270
		internal void SortGlyphAndCharacterTables(); // 0x00000001820CB270-0x00000001820CB4F0
		private void UpgradeSpriteAsset(); // 0x00000001820CBBB0-0x00000001820CC010
	}
}
