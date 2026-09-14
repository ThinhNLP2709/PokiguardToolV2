/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.Avatar;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarCatalog // TypeDefIndex: 2746
	{
		// Fields
		public static readonly ShopAvatarTab[] Tabs; // 0x00
	
		// Constructors
		static ShopAvatarCatalog(); // 0x0000000180CA6D50-0x0000000180CA79B0
	
		// Methods
		public static int IndexOfKey(string key); // 0x0000000180CA6180-0x0000000180CA6340
		public static int IndexOfCategory(int category); // 0x0000000180CA6340-0x0000000180CA6430
		public static int CategoryOfKey(string key); // 0x0000000180CA6430-0x0000000180CA64C0
		public static int SafeCategory(int category); // 0x0000000180CA64C0-0x0000000180CA6520
		public static bool IsPortrait(int category); // 0x0000000180CA6520-0x0000000180CA6530
		public static string SlotLabel(int slot); // 0x0000000180CA6530-0x0000000180CA65C0
		public static bool HasAvatarSet(string layers); // 0x0000000180CA65C0-0x0000000180CA6600
		public static string WithSlot(string layers, int slot, long iconId); // 0x0000000180CA6600-0x0000000180CA6A40
		private static string Build(List<AvatarLayerPair> pairs); // 0x0000000180CA6A40-0x0000000180CA6D30
		private static int CompareBySlot(AvatarLayerPair a, AvatarLayerPair b); // 0x0000000180CA6D30-0x0000000180CA6D50
	}
}
