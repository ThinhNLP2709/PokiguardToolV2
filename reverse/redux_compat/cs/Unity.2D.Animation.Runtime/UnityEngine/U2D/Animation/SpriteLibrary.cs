/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.Common;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[AddComponentMenu("2D Animation/Sprite Library")]
	[DisallowMultipleComponent]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@16.0/manual/SL-component.html")]
	[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
	public class SpriteLibrary : MonoBehaviour, IPreviewable // TypeDefIndex: 14378
	{
		// Fields
		[SerializeField]
		private List<SpriteLibCategory> m_Library; // 0x20
		[SerializeField]
		private SpriteLibraryAsset m_SpriteLibraryAsset; // 0x28
		private Dictionary<int, CategoryEntrySprite> m_CategoryEntryHashCache; // 0x30
		private Dictionary<string, HashSet<string>> m_CategoryEntryCache; // 0x38
		private EntityId m_PreviousSpriteLibraryAsset; // 0x40
		private long m_PreviousModificationHash; // 0x48
	
		// Properties
		public SpriteLibraryAsset spriteLibraryAsset { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181C239A0-0x0000000181C23A30
		internal IEnumerable<string> categoryNames { get; } // 0x0000000181C23950-0x0000000181C239A0 
	
		// Nested types
		private struct CategoryEntrySprite // TypeDefIndex: 14379
		{
			// Fields
			public string category; // 0x00
			public string entry; // 0x08
			public Sprite sprite; // 0x10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass18_0 // TypeDefIndex: 14380
		{
			// Fields
			public string category; // 0x10
	
			// Constructors
			public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetEntries_b__0(SpriteLibCategory x); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass19_0 // TypeDefIndex: 14381
		{
			// Fields
			public string entry; // 0x10
	
			// Constructors
			public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetEntry_b__0(SpriteCategoryEntry x); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_0 // TypeDefIndex: 14382
		{
			// Fields
			public int categoryHash; // 0x10
	
			// Constructors
			public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddOverride_b__0(SpriteLibCategory x); // 0x0000000181C2E580-0x0000000181C2E5A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_0 // TypeDefIndex: 14383
		{
			// Fields
			public string category; // 0x10
	
			// Constructors
			public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveOverride_b__0(SpriteLibCategory x); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 14384
		{
			// Fields
			public string label; // 0x10
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveOverride_b__0(SpriteCategoryEntry x); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		// Constructors
		public SpriteLibrary(); // 0x0000000181C238D0-0x0000000181C23950
	
		// Methods
		private void OnEnable(); // 0x0000000181C23540-0x0000000181C23550
		public void OnPreviewUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		public Sprite GetSprite(string category, string label); // 0x0000000181C233A0-0x0000000181C23460
		private Sprite GetSprite(int hash); // 0x0000000181C23460-0x0000000181C23500
		private void UpdateCacheOverridesIfNeeded(); // 0x0000000181C23800-0x0000000181C238D0
		internal bool GetCategoryAndEntryNameFromHash(int hash, out string category, out string entry); // 0x0000000181C22D50-0x0000000181C22E60
		internal static int GetHashForCategoryAndEntry(string category, string entry); // 0x0000000181C23230-0x0000000181C232E0
		internal Sprite GetSpriteFromCategoryAndEntryHash(int hash, out bool validEntry); // 0x0000000181C232E0-0x0000000181C233A0
		private List<SpriteCategoryEntry> GetEntries(string category, bool addIfNotExist); // 0x0000000181C22E60-0x0000000181C23040
		private static SpriteCategoryEntry GetEntry(List<SpriteCategoryEntry> entries, string entry, bool addIfNotExist); // 0x0000000181C230E0-0x0000000181C23230
		public void AddOverride(SpriteLibraryAsset spriteLib, string category, string label); // 0x0000000181C22240-0x0000000181C22480
		public void AddOverride(SpriteLibraryAsset spriteLib, string category); // 0x0000000181C22010-0x0000000181C221C0
		public void AddOverride(Sprite sprite, string category, string label); // 0x0000000181C221C0-0x0000000181C22240
		public void RemoveOverride(string category); // 0x0000000181C235E0-0x0000000181C236F0
		public void RemoveOverride(string category, string label); // 0x0000000181C236F0-0x0000000181C23800
		public bool HasOverride(string category, string label); // 0x0000000181C23500-0x0000000181C23540
		public void RefreshSpriteResolvers(); // 0x0000000181C23550-0x0000000181C235E0
		internal IEnumerable<string> GetEntryNames(string category); // 0x0000000181C23040-0x0000000181C230E0
		internal void CacheOverrides(); // 0x0000000181C22480-0x0000000181C22D50
	}
}
