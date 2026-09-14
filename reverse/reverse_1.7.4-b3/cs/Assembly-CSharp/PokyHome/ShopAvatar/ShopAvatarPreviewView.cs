/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarPreviewView // TypeDefIndex: 2763
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
		public ShopAvatarItemDTO Item { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8F70-0x00000001802D8F80 0x00000001802D8F80-0x00000001802D8FE0
		public ShopAvatarPortraitDTO Portrait { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8FE0-0x00000001802D8FF0 0x00000001802D8FF0-0x00000001802D9050
	
		// Events
		public event Action BuyClicked {
			add; // 0x0000000180CAD1B0-0x0000000180CAD2B0
			remove; // 0x0000000180CAD2B0-0x0000000180CAD3B0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass68_0 // TypeDefIndex: 2764
		{
			// Fields
			public ShopAvatarPreviewView __4__this; // 0x10
			public int token; // 0x18
			public ShopAvatarItemDTO item; // 0x20
	
			// Constructors
			public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindComposite_b__0(Sprite sp); // 0x0000000180CB3CD0-0x0000000180CB3E30
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass73_0 // TypeDefIndex: 2765
		{
			// Fields
			public ShopAvatarPreviewView __4__this; // 0x10
			public int token; // 0x18
	
			// Constructors
			public __c__DisplayClass73_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ShowSprite_b__0(Sprite sp); // 0x0000000180CB3E30-0x0000000180CB4190
		}
	
		// Constructors
		public ShopAvatarPreviewView(); // 0x0000000180CB3B50-0x0000000180CB3C20
		static ShopAvatarPreviewView(); // 0x0000000180CB3C20-0x0000000180CB3CD0
	
		// Methods
		public void AutoWire(Transform panelRoot, MonoBehaviour host, Action<string> reportMissing); // 0x0000000180CAD3B0-0x0000000180CAE3B0
		private void OnBuyClicked(); // 0x0000000180CAE3B0-0x0000000180CAE430
		public void Clear(); // 0x0000000180CAE430-0x0000000180CAECE0
		public void Bind(ShopAvatarItemDTO item, string baseLayers, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CAECE0-0x0000000180CAF4B0
		public void BindPortrait(ShopAvatarPortraitDTO p, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CAF4B0-0x0000000180CAFB50
		private void BindSet(ShopAvatarItemDTO item); // 0x0000000180CAFB50-0x0000000180CAFD30
		private void BindCompare(ShopAvatarItemDTO item); // 0x0000000180CAFD30-0x0000000180CB0030
		private void BindPrice(ShopAvatarItemDTO item, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CB0030-0x0000000180CB0260
		private void SetPriceRow(long price, long oldPrice, string currency, bool owned, bool poor, Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CB0260-0x0000000180CB09A0
		private void BindButton(ShopAvatarItemDTO item, ShopAvatarWalletDTO wallet); // 0x0000000180CB09A0-0x0000000180CB0DC0
		private void BindComposite(ShopAvatarItemDTO item, string baseLayers); // 0x0000000180CB0DC0-0x0000000180CB1300
		private void BindSetNote(ShopAvatarItemDTO item, string baseLayers); // 0x0000000180CB1300-0x0000000180CB1590
		private void ShowComposite(Sprite sp); // 0x0000000180CB1590-0x0000000180CB1980
		private void FitContentInAvatarBox(Image img, Sprite sp, float fill, float offsetY); // 0x0000000180CB1980-0x0000000180CB2100
		private void FitInAvatarBox(Image img, float zoom, float offsetY); // 0x0000000180CB2100-0x0000000180CB2620
		private void ShowSprite(string path); // 0x0000000180CB2620-0x0000000180CB2DB0
		private string PerkLine(ShopAvatarItemDTO item); // 0x0000000180CB2DB0-0x0000000180CB2FF0
		private string ResistLine(int[] resist); // 0x0000000180CB2FF0-0x0000000180CB31D0
		public static string AvatarPath(long avatarId); // 0x0000000180CB31D0-0x0000000180CB3280
		private GameObject FindNode(string name, Action<string> missing); // 0x0000000180CB3280-0x0000000180CB3470
		private Image FindImage(string name, Action<string> missing); // 0x0000000180CB3470-0x0000000180CB35E0
		private UnityEngine.UI.Text FindText(string name, Action<string> missing); // 0x0000000180CB35E0-0x0000000180CB3750
		private static void NoRichText(UnityEngine.UI.Text t); // 0x0000000180CB3750-0x0000000180CB3870
		private static void SetText(UnityEngine.UI.Text t, string value); // 0x0000000180CB3870-0x0000000180CB3980
		private static void Show(UnityEngine.UI.Text t, bool on); // 0x0000000180CB3980-0x0000000180CB3B50
	}
}
