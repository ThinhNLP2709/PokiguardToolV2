/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	[Serializable]
	public class ShopAvatarDataDTO // TypeDefIndex: 2321
	{
		// Fields
		public int category; // 0x10
		public int rarity; // 0x14
		public bool hideOwned; // 0x18
		public string sort; // 0x20
		public int page; // 0x28
		public int totalPages; // 0x2C
		public int matchCount; // 0x30
		public int pageSize; // 0x34
		public int level; // 0x38
		public ShopAvatarWalletDTO wallet; // 0x40
		public string avatarLayers; // 0x48
		public long catalogVersion; // 0x50
		public bool portraitTab; // 0x58
		public long serverTime; // 0x60
		public ShopAvatarItemDTO[] items; // 0x68
	
		// Properties
		public bool IsUsable { get; } // 0x00000001807BE860-0x00000001807BE880 
	
		// Constructors
		public ShopAvatarDataDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}
}
