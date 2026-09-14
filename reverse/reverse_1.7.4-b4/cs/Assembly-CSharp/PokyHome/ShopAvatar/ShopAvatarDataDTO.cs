/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	[Serializable]
	public class ShopAvatarDataDTO // TypeDefIndex: 2763
	{
		// Fields
		public int category; // 0x10
		public int rarity; // 0x14
		public bool hideOwned; // 0x18
		public string sort; // 0x20
		public int page; // 0x28
		public int totalPages; // 0x2C
		public ShopAvatarWalletDTO wallet; // 0x30
		public string avatarLayers; // 0x38
		public long catalogVersion; // 0x40
		public bool portraitTab; // 0x48
		public ShopAvatarItemDTO[] items; // 0x50
	
		// Properties
		public bool IsUsable { get; } // 0x0000000180CB7BE0-0x0000000180CB7C00 
	
		// Constructors
		public ShopAvatarDataDTO(); // 0x000000018028A320-0x000000018028A330
	}
}
