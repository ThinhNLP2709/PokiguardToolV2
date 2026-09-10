/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarHubLink // TypeDefIndex: 2326
	{
		// Fields
		public const string PREF_SEEN = "shopavatar.seenCatalog"; // Metadata: 0x0068E828
		public const string PREF_LAST = "shopavatar.lastCatalog"; // Metadata: 0x0068E83F
		public const string N_BADGE = "badgeNew"; // Metadata: 0x0068E856
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2327
		{
			// Fields
			public int category; // 0x10
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Open_b__0(GameObject panel); // 0x00000001807C7320-0x00000001807C7560
		}
	
		// Methods
		public static void NoteCatalogVersion(long version); // 0x00000001807BFED0-0x00000001807BFF80
		public static void MarkSeen(); // 0x00000001807BFE10-0x00000001807BFED0
		public static bool ShouldShowBadge(); // 0x00000001807C0320-0x00000001807C03C0
		public static void RefreshBadge(Button button); // 0x00000001807C0170-0x00000001807C0320
		public static void Open(int category = 0 /* Metadata: 0x0068E827 */); // 0x00000001807BFF80-0x00000001807C0170
	}
}
