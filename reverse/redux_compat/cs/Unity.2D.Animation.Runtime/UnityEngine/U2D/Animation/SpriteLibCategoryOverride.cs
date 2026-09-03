/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[Serializable]
	internal class SpriteLibCategoryOverride : SpriteLibCategory // TypeDefIndex: 14402
	{
		// Fields
		[SerializeField]
		private List<SpriteCategoryEntryOverride> m_OverrideEntries; // 0x28
		[SerializeField]
		private bool m_FromMain; // 0x30
		[SerializeField]
		private int m_EntryOverrideCount; // 0x34
	
		// Properties
		public bool fromMain { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
		public int entryOverrideCount { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public List<SpriteCategoryEntryOverride> overrideEntries { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14403
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string, string> __9__13_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181C2EA40-0x0000000181C2EAB0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RenameDuplicateOverrideEntries_b__13_0(string _, string _); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public SpriteLibCategoryOverride(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void UpdateOverrideCount(); // 0x0000000181C1FF00-0x0000000181C20080
		public void RenameDuplicateOverrideEntries(); // 0x0000000181C1FE00-0x0000000181C1FF00
	}
}
