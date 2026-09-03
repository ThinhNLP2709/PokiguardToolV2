/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[ExcludeFromPreset]
	[HelpURL("https://docs.unity3d.com/2023.3/Documentation/Manual/UIE-sprite.html")]
	public class SpriteAsset : TextAsset // TypeDefIndex: 12663
	{
		// Fields
		internal Dictionary<int, int> m_NameLookup; // 0x40
		internal Dictionary<uint, int> m_GlyphIndexLookup; // 0x48
		[SerializeField]
		internal FaceInfo m_FaceInfo; // 0x50
		[FormerlySerializedAs("spriteSheet")]
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal Texture m_SpriteAtlasTexture; // 0xB0
		[CompilerGenerated]
		private float _width_k__BackingField; // 0xB8
		[CompilerGenerated]
		private float _height_k__BackingField; // 0xBC
		[SerializeField]
		private List<SpriteCharacter> m_SpriteCharacterTable; // 0xC0
		internal Dictionary<uint, SpriteCharacter> m_SpriteCharacterLookup; // 0xC8
		[SerializeField]
		private List<SpriteGlyph> m_SpriteGlyphTable; // 0xD0
		internal Dictionary<uint, SpriteGlyph> m_SpriteGlyphLookup; // 0xD8
		[SerializeField]
		public List<SpriteAsset> fallbackSpriteAssets; // 0xE0
		internal bool m_IsSpriteAssetLookupTablesDirty; // 0xE8
	
		// Properties
		public FaceInfo faceInfo { get; internal set; } // 0x0000000181CC1980-0x0000000181CC19C0 0x0000000182335730-0x0000000182335780
		public Texture spriteSheet { get; internal set; } // 0x00000001806BAE60-0x00000001806BAE70 0x0000000182335790-0x0000000182335820
		internal float width { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000182335720-0x0000000182335730 0x0000000182335820-0x0000000182335830
		internal float height { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E6F280-0x0000000181E6F290 0x0000000182335780-0x0000000182335790
		public List<SpriteCharacter> spriteCharacterTable { get; internal set; } // 0x00000001823356E0-0x0000000182335720 0x00000001806CCDA0-0x00000001806CCDC0
		public Dictionary<uint, SpriteCharacter> spriteCharacterLookupTable { get; internal set; } // 0x00000001823356A0-0x00000001823356E0 0x00000001806CCD60-0x00000001806CCD80
		public List<SpriteGlyph> spriteGlyphTable { get; internal set; } // 0x00000001806CCB60-0x00000001806CCB70 0x00000001806CCD80-0x00000001806CCDA0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12664
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<SpriteGlyph, uint> __9__43_0; // 0x08
			public static Func<SpriteCharacter, uint> __9__44_0; // 0x10
	
			// Constructors
			static __c(); // 0x000000018234B8E0-0x000000018234B950
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortGlyphTable_b__43_0(SpriteGlyph item); // 0x000000018030F200-0x000000018030F220
			internal uint _SortCharacterTable_b__44_0(SpriteCharacter c); // 0x0000000182095970-0x0000000182095990
		}
	
		// Constructors
		public SpriteAsset(); // 0x00000001823355D0-0x00000001823356A0
	
		// Methods
		public void UpdateLookupTables(); // 0x0000000182334FF0-0x00000001823355D0
		public int GetSpriteIndexFromHashcode(int hashCode); // 0x0000000182334050-0x00000001823340E0
		public int GetSpriteIndexFromUnicode(uint unicode); // 0x0000000182334120-0x00000001823341C0
		public int GetSpriteIndexFromName(string name); // 0x00000001823340E0-0x0000000182334120
		public static SpriteAsset SearchForSpriteByUnicode(SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex); // 0x0000000182334940-0x0000000182334AB0
		private static SpriteAsset SearchForSpriteByUnicodeInternal(List<SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex); // 0x0000000182334710-0x00000001823348A0
		private static SpriteAsset SearchForSpriteByUnicodeInternal(SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex); // 0x00000001823348A0-0x0000000182334940
		public static SpriteAsset SearchForSpriteByHashCode(SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex, TextSettings textSettings = null); // 0x00000001823343E0-0x0000000182334710
		private static SpriteAsset SearchForSpriteByHashCodeInternal(List<SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex); // 0x0000000182334260-0x00000001823343E0
		private static SpriteAsset SearchForSpriteByHashCodeInternal(SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex); // 0x00000001823341C0-0x0000000182334260
		public void SortGlyphTable(); // 0x0000000182334E90-0x0000000182334FF0
		internal void SortCharacterTable(); // 0x0000000182334AB0-0x0000000182334C10
		internal void SortGlyphAndCharacterTables(); // 0x0000000182334C10-0x0000000182334E90
	}
}
