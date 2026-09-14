/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarPreviewView // TypeDefIndex: 2770
	{
		// Fields
		private static readonly Color PriceNormal; // 0x00
		private static readonly Color PriceShort; // 0x10
		private static readonly Color PriceOwned; // 0x20
		private static readonly Color CompareUp; // 0x30
		private static readonly Color CompareDown; // 0x40
		private readonly StringBuilder _sb; // 0x10
		private MonoBehaviour _host; // 0x18
		private Transform _root; // 0x20
		public UnityEngine.UI.Text txtName; // 0x28
		public Image imgRarityTag; // 0x30
		public UnityEngine.UI.Text txtRarityTag; // 0x38
		public GameObject secAvatar; // 0x40
		public Image imgComposite; // 0x48
		public Image imgFallbackIcon; // 0x50
		public UnityEngine.UI.Text txtSlot; // 0x58
		public UnityEngine.UI.Text txtStats; // 0x60
		public UnityEngine.UI.Text txtResist; // 0x68
		public UnityEngine.UI.Text txtSet; // 0x70
		public UnityEngine.UI.Text txtCompare; // 0x78
		public GameObject secPrice; // 0x80
		public Image imgCurrency; // 0x88
		public UnityEngine.UI.Text txtPrice; // 0x90
		public UnityEngine.UI.Text txtOldPrice; // 0x98
		public UnityEngine.UI.Text txtLock; // 0xA0
		public Button btnBuy; // 0xA8
		public UnityEngine.UI.Text txtBuyLabel; // 0xB0
		[CompilerGenerated]
		private ShopAvatarItemDTO _Item_k__BackingField; // 0xB8
		[CompilerGenerated]
		private ShopAvatarPortraitDTO _Portrait_k__BackingField; // 0xC0
		[CompilerGenerated]
		private Action BuyClicked; // 0xC8
		private int _token; // 0xD0
	
		// Properties
		public ShopAvatarItemDTO Item { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8FA0-0x00000001802D8FB0 0x00000001802D8FB0-0x00000001802D9010
		public ShopAvatarPortraitDTO Portrait { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D9010-0x00000001802D9020 0x00000001802D9020-0x00000001802D9080
	
		// Events
		public event Action BuyClicked {
			add; // 0x0000000180CBA980-0x0000000180CBAA80
			remove; // 0x0000000180CBAA80-0x0000000180CBAB80
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass68_0 // TypeDefIndex: 2771
		{
			// Fields
			public ShopAvatarPreviewView __4__this; // 0x10
			public int token; // 0x18
			public ShopAvatarItemDTO item; // 0x20
	
			// Constructors
			public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindComposite_b__0(Sprite sp); // 0x0000000180CC14D0-0x0000000180CC1630
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass73_0 // TypeDefIndex: 2772
		{
			// Fields
			public ShopAvatarPreviewView __4__this; // 0x10
			public int token; // 0x18
	
			// Constructors
			public __c__DisplayClass73_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ShowSprite_b__0(Sprite sp); // 0x0000000180CC1630-0x0000000180CC1990
		}
	
		// Constructors
		public ShopAvatarPreviewView(); // 0x0000000180CC1350-0x0000000180CC1420
		static ShopAvatarPreviewView(); // 0x0000000180CC1420-0x0000000180CC14D0
	
		// Methods
		public void AutoWire(Transform panelRoot, MonoBehaviour host, Action<string> reportMissing); // 0x0000000180CBAB80-0x0000000180CBBB80
		private void OnBuyClicked(); // 0x0000000180CBBB80-0x0000000180CBBC00
		public void Clear(); // 0x0000000180CBBC00-0x0000000180CBC4B0
		public void Bind(ShopAvatarItemDTO item, string baseLayers, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CBC4B0-0x0000000180CBCC80
		public void BindPortrait(ShopAvatarPortraitDTO p, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CBCC80-0x0000000180CBD320
		private void BindSet(ShopAvatarItemDTO item); // 0x0000000180CBD320-0x0000000180CBD500
		private void BindCompare(ShopAvatarItemDTO item); // 0x0000000180CBD500-0x0000000180CBD800
		private void BindPrice(ShopAvatarItemDTO item, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CBD800-0x0000000180CBDA30
		private void SetPriceRow(long price, long oldPrice, string currency, bool owned, bool poor, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CBDA30-0x0000000180CBE170
		private void BindButton(ShopAvatarItemDTO item, ShopAvatarWalletDTO wallet); // 0x0000000180CBE170-0x0000000180CBE590
		private void BindComposite(ShopAvatarItemDTO item, string baseLayers); // 0x0000000180CBE590-0x0000000180CBEAD0
		private void BindSetNote(ShopAvatarItemDTO item, string baseLayers); // 0x0000000180CBEAD0-0x0000000180CBED60
		private void ShowComposite(Sprite sp); // 0x0000000180CBED60-0x0000000180CBF150
		private void FitContentInAvatarBox(Image img, Sprite sp, float fill, float offsetY); // 0x0000000180CBF150-0x0000000180CBF8D0
		private void FitInAvatarBox(Image img, float zoom, float offsetY); // 0x0000000180CBF8D0-0x0000000180CBFDF0
		private void ShowSprite(string path); // 0x0000000180CBFDF0-0x0000000180CC05B0
		private string PerkLine(ShopAvatarItemDTO item); // 0x0000000180CC05B0-0x0000000180CC07F0
		private string ResistLine(int[] resist); // 0x0000000180CC07F0-0x0000000180CC09D0
		public static string AvatarPath(long avatarId); // 0x0000000180CC09D0-0x0000000180CC0A80
		private GameObject FindNode(string name, Action<string> missing); // 0x0000000180CC0A80-0x0000000180CC0C70
		private Image FindImage(string name, Action<string> missing); // 0x0000000180CC0C70-0x0000000180CC0DE0
		private UnityEngine.UI.Text FindText(string name, Action<string> missing); // 0x0000000180CC0DE0-0x0000000180CC0F50
		private static void NoRichText(UnityEngine.UI.Text t); // 0x0000000180CC0F50-0x0000000180CC1070
		private static void SetText(UnityEngine.UI.Text t, string value); // 0x0000000180CC1070-0x0000000180CC1180
		private static void Show(UnityEngine.UI.Text t, bool on); // 0x0000000180CC1180-0x0000000180CC1350
	}
}
