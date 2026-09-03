/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@16.0/manual/AssetUpgrader.html#upgrading-sprite-libraries")]
	[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
	public class SpriteLibraryAsset : ScriptableObject // TypeDefIndex: 14389
	{
		// Fields
		[SerializeField]
		private List<SpriteLibCategory> m_Labels; // 0x18
		[SerializeField]
		private long m_ModificationHash; // 0x20
		[SerializeField]
		private int m_Version; // 0x28
	
		// Properties
		internal List<SpriteLibCategory> categories { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181C219A0-0x0000000181C219D0
		internal long modificationHash { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181727440-0x0000000181727450
		internal int version { set; } // 0x0000000180378100-0x0000000180378110
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14390
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<SpriteLibCategory, string> __9__17_0; // 0x08
			public static Func<SpriteCategoryEntry, string> __9__19_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181C2E9D0-0x0000000181C2EA40
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _GetCategoryNames_b__17_0(SpriteLibCategory x); // 0x000000018052BA80-0x000000018052BAA0
			internal string _GetCategoryLabelNames_b__19_1(SpriteCategoryEntry x); // 0x000000018052BA80-0x000000018052BAA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 14391
		{
			// Fields
			public int categoryHash; // 0x10
			public int labelHash; // 0x14
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetSprite_b__0(SpriteLibCategory x); // 0x0000000181C2E580-0x0000000181C2E5A0
			internal bool _GetSprite_b__1(SpriteCategoryEntry x); // 0x0000000181C2E5A0-0x0000000181C2E5C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass19_0 // TypeDefIndex: 14392
		{
			// Fields
			public string category; // 0x10
	
			// Constructors
			public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetCategoryLabelNames_b__0(SpriteLibCategory x); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass20_0 // TypeDefIndex: 14393
		{
			// Fields
			public int catHash; // 0x10
	
			// Constructors
			public __c__DisplayClass20_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddCategoryLabel_b__0(SpriteLibCategory x); // 0x0000000181C2E580-0x0000000181C2E5A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass20_1 // TypeDefIndex: 14394
		{
			// Fields
			public int labelHash; // 0x10
	
			// Constructors
			public __c__DisplayClass20_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddCategoryLabel_b__1(SpriteCategoryEntry y); // 0x0000000181C2E580-0x0000000181C2E5A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_0 // TypeDefIndex: 14395
		{
			// Fields
			public int catHash; // 0x10
			public SpriteLibCategory libCategory; // 0x18
	
			// Constructors
			public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveCategoryLabel_b__0(SpriteLibCategory x); // 0x0000000181C2E580-0x0000000181C2E5A0
			internal bool _RemoveCategoryLabel_b__2(SpriteLibCategory x); // 0x0000000181C2E650-0x0000000181C2E680
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_1 // TypeDefIndex: 14396
		{
			// Fields
			public int labelHash; // 0x10
	
			// Constructors
			public __c__DisplayClass21_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveCategoryLabel_b__1(SpriteCategoryEntry x); // 0x0000000181C2E580-0x0000000181C2E5A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_0 // TypeDefIndex: 14397
		{
			// Fields
			public bool log; // 0x10
	
			// Constructors
			public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ValidateCategories_b__0(string originalName, string newName); // 0x0000000181C2E680-0x0000000181C2E7E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 14398
		{
			// Fields
			public INameHash category; // 0x10
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RenameDuplicate_b__0(INameHash x); // 0x0000000181C2E7E0-0x0000000181C2E8C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_1 // TypeDefIndex: 14399
		{
			// Fields
			public INameHash categoryClash; // 0x10
	
			// Constructors
			public __c__DisplayClass24_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_2 // TypeDefIndex: 14400
		{
			// Fields
			public int nameHash; // 0x10
			public string name; // 0x18
			public __c__DisplayClass24_1 CS___8__locals1; // 0x20
	
			// Constructors
			public __c__DisplayClass24_2(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RenameDuplicate_b__1(INameHash x); // 0x0000000181C2E8C0-0x0000000181C2E960
		}
	
		// Constructors
		public SpriteLibraryAsset(); // 0x0000000181C21920-0x0000000181C219A0
	
		// Methods
		internal static SpriteLibraryAsset CreateAsset(List<SpriteLibCategory> categories, string assetName, long modificationHash); // 0x0000000181C20810-0x0000000181C208C0
		private void OnEnable(); // 0x0000000181C20FC0-0x0000000181C20FF0
		private void UpdateToVersionOne(); // 0x0000000181C21750-0x0000000181C21770
		internal Sprite GetSprite(int categoryHash, int labelHash); // 0x0000000181C20D70-0x0000000181C20EC0
		internal Sprite GetSprite(int categoryHash, int labelHash, out bool validEntry); // 0x0000000181C20EC0-0x0000000181C20FC0
		public Sprite GetSprite(string category, string label); // 0x0000000181C20B90-0x0000000181C20D70
		public IEnumerable<string> GetCategoryNames(); // 0x0000000181C20A90-0x0000000181C20B90
		[Obsolete("GetCategorylabelNames has been deprecated. Please use GetCategoryLabelNames (UnityUpgradable) -> GetCategoryLabelNames(*)")]
		public IEnumerable<string> GetCategorylabelNames(string category); // 0x0000000181C208C0-0x0000000181C20A90
		public IEnumerable<string> GetCategoryLabelNames(string category); // 0x0000000181C208C0-0x0000000181C20A90
		public void AddCategoryLabel(Sprite sprite, string category, string label); // 0x0000000181C20380-0x0000000181C20810
		public void RemoveCategoryLabel(string category, string label, bool deleteCategory); // 0x0000000181C20FF0-0x0000000181C21280
		internal void UpdateHashes(); // 0x0000000181C21680-0x0000000181C21750
		internal void ValidateCategories(bool log = true /* Metadata: 0x006A96C8 */); // 0x0000000181C21770-0x0000000181C21920
		internal static void RenameDuplicate(IEnumerable<INameHash> nameHashList, Action<string, string> onRename); // 0x0000000181C21280-0x0000000181C21680
	}
}
