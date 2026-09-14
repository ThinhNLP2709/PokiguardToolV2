/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.Avatar;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarCatalog // TypeDefIndex: 2739
	{
		// Fields
		public static readonly ShopAvatarTab[] Tabs; // 0x00
	
		// Constructors
		static ShopAvatarCatalog(); // 0x0000000180C736A0-0x0000000180C74300
	
		// Methods
		public static int IndexOfKey(string key); // 0x0000000180C72AD0-0x0000000180C72C90
		public static int IndexOfCategory(int category); // 0x0000000180C72C90-0x0000000180C72D80
		public static int CategoryOfKey(string key); // 0x0000000180C72D80-0x0000000180C72E10
		public static int SafeCategory(int category); // 0x0000000180C72E10-0x0000000180C72E70
		public static bool IsPortrait(int category); // 0x0000000180C72E70-0x0000000180C72E80
		public static string SlotLabel(int slot); // 0x0000000180C72E80-0x0000000180C72F10
		public static bool HasAvatarSet(string layers); // 0x0000000180C72F10-0x0000000180C72F50
		public static string WithSlot(string layers, int slot, long iconId); // 0x0000000180C72F50-0x0000000180C73390
		private static string Build(List<AvatarLayerPair> pairs); // 0x0000000180C73390-0x0000000180C73680
		private static int CompareBySlot(AvatarLayerPair a, AvatarLayerPair b); // 0x0000000180C73680-0x0000000180C736A0
	}
}
