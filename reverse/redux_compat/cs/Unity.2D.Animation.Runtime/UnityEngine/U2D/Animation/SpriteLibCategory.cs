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
	[Serializable]
	[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
	internal class SpriteLibCategory : INameHash, ISpriteLibraryCategory // TypeDefIndex: 14387
	{
		// Fields
		[SerializeField]
		private string m_Name; // 0x10
		[SerializeField]
		private int m_Hash; // 0x18
		[SerializeField]
		private List<SpriteCategoryEntry> m_CategoryList; // 0x20
	
		// Properties
		public string name { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181C202F0-0x0000000181C20380
		public int hash { get; } // 0x0000000180B23260-0x0000000180B23270 
		public List<SpriteCategoryEntry> categoryList { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public IEnumerable<ISpriteLibraryLabel> labels { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 14388
		{
			// Fields
			public bool log; // 0x10
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ValidateLabels_b__0(string originalName, string newName); // 0x0000000181C2E5C0-0x0000000181C2E650
		}
	
		// Constructors
		public SpriteLibCategory(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void UpdateHash(); // 0x0000000181C20080-0x0000000181C20230
		internal void ValidateLabels(bool log = true /* Metadata: 0x006A96C7 */); // 0x0000000181C20230-0x0000000181C202F0
	}
}
