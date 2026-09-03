/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	internal class TextResourceManager // TypeDefIndex: 12722
	{
		// Fields
		private static readonly Dictionary<EntityId, FontAssetRef> s_FontAssetReferences; // 0x00
		private static readonly Dictionary<int, FontAsset> s_FontAssetNameReferenceLookup; // 0x08
		private static readonly Dictionary<long, FontAsset> s_FontAssetFamilyNameAndStyleReferenceLookup; // 0x10
		private static readonly List<EntityId> s_FontAssetRemovalList; // 0x18
		private static readonly int k_RegularStyleHashCode; // 0x20
	
		// Nested types
		private struct FontAssetRef // TypeDefIndex: 12723
		{
			// Fields
			public int nameHashCode; // 0x00
			public int familyNameHashCode; // 0x04
			public int styleNameHashCode; // 0x08
			public long familyNameAndStyleHashCode; // 0x10
			public readonly FontAsset fontAsset; // 0x18
	
			// Constructors
			public FontAssetRef(int nameHashCode, int familyNameHashCode, int styleNameHashCode, FontAsset fontAsset); // 0x00000001820BEF70-0x00000001820BEFB0
		}
	
		// Constructors
		static TextResourceManager(); // 0x000000018234BF50-0x000000018234C1C0
	
		// Methods
		internal static void AddFontAsset(FontAsset fontAsset); // 0x000000018234BA30-0x000000018234BF50
	}
}
