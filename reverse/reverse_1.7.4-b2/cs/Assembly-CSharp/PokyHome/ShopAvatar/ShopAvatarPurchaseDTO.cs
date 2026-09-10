/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	[Serializable]
	public class ShopAvatarPurchaseDTO // TypeDefIndex: 2322
	{
		// Fields
		public bool success; // 0x10
		public int reason; // 0x14
		public string message; // 0x18
		public long shopId; // 0x20
		public long itemId; // 0x28
		public long rowId; // 0x30
		public bool equipped; // 0x38
		public ShopAvatarWalletDTO wallet; // 0x40
		public string avatarLayers; // 0x48
		public EquipBookDTO book; // 0x50
	
		// Properties
		public ShopAvatarReason Reason { get; } // 0x00000001807C4BF0-0x00000001807C4C00 
	
		// Constructors
		public ShopAvatarPurchaseDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}
}
