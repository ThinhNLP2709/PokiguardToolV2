/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.Avatar;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarCatalog // TypeDefIndex: 2303
	{
		// Fields
		public static readonly ShopAvatarTab[] Tabs; // 0x00
	
		// Constructors
		static ShopAvatarCatalog(); // 0x00000001807B53F0-0x00000001807B58C0
	
		// Methods
		public static int IndexOfKey(string key); // 0x00000001807B4D80-0x00000001807B4E90
		public static int IndexOfCategory(int category); // 0x00000001807B4C90-0x00000001807B4D80
		public static int CategoryOfKey(string key); // 0x00000001807B4BA0-0x00000001807B4C30
		public static int SafeCategory(int category); // 0x00000001807B4EA0-0x00000001807B4FC0
		public static bool IsPortrait(int category); // 0x00000001807B4E90-0x00000001807B4EA0
		public static string SlotLabel(int slot); // 0x00000001807B4FC0-0x00000001807B5050
		public static bool HasAvatarSet(string layers); // 0x00000001807B4C50-0x00000001807B4C90
		public static string WithSlot(string layers, int slot, long iconId); // 0x00000001807B5050-0x00000001807B53F0
		private static string Build(List<AvatarLayerPair> pairs); // 0x00000001807B4990-0x00000001807B4BA0
		private static int CompareBySlot(AvatarLayerPair a, AvatarLayerPair b); // 0x00000001807B4C30-0x00000001807B4C50
	}
}
