/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarPreviewView // TypeDefIndex: 2328
	{
		// Fields
		public const string N_ROOT = "sec_Preview"; // Metadata: 0x0068E85F
		public const string N_NAME = "txt_Name"; // Metadata: 0x0068E86B
		public const string N_RARITY_TAG = "img_RarityTag"; // Metadata: 0x0068E874
		public const string N_RARITY_TEXT = "txt_RarityTag"; // Metadata: 0x0068E882
		public const string N_AVATAR = "sec_Avatar"; // Metadata: 0x0068E890
		public const string N_COMPOSITE = "img_Composite"; // Metadata: 0x0068E89B
		public const string N_FALLBACK = "img_FallbackIcon"; // Metadata: 0x0068E8A9
		public const string N_SLOT = "txt_Slot"; // Metadata: 0x0068E8BA
		public const string N_STATS = "txt_Stats"; // Metadata: 0x0068E8C3
		public const string N_RESIST = "txt_Resist"; // Metadata: 0x0068E8CD
		public const string N_SET = "txt_Set"; // Metadata: 0x0068E8D8
		public const string N_COMPARE = "txt_Compare"; // Metadata: 0x0068E8E0
		public const string N_PRICE = "sec_Price"; // Metadata: 0x0068E8EC
		public const string N_CURRENCY = "img_Currency"; // Metadata: 0x0068E8F6
		public const string N_PRICE_TEXT = "txt_Price"; // Metadata: 0x0068E903
		public const string N_OLD_PRICE = "txt_OldPrice"; // Metadata: 0x0068E90D
		public const string N_LOCK = "txt_Lock"; // Metadata: 0x0068E91A
		public const string N_BUY = "btn_Buy"; // Metadata: 0x0068E923
		public const string N_BUY_LABEL = "txt_BuyLabel"; // Metadata: 0x0068E92B
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
		private const string PERK_PREFIX = "Thu\u1ED9c t\u00EDnh: "; // Metadata: 0x0068E938
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
		public ShopAvatarItemDTO Item { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803198F0-0x0000000180319900 0x0000000180319BB0-0x0000000180319BD0
		public ShopAvatarPortraitDTO Portrait { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803198D0-0x00000001803198E0 0x0000000180319B70-0x0000000180319B90
	
		// Events
		public event Action BuyClicked {
			add; // 0x00000001807C4A90-0x00000001807C4B40
			remove; // 0x00000001807C4B40-0x00000001807C4BF0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass68_0 // TypeDefIndex: 2329
		{
			// Fields
			public ShopAvatarPreviewView __4__this; // 0x10
			public int token; // 0x18
			public ShopAvatarItemDTO item; // 0x20
	
			// Constructors
			public __c__DisplayClass68_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _BindComposite_b__0(Sprite sp); // 0x00000001807C7080-0x00000001807C7160
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass73_0 // TypeDefIndex: 2330
		{
			// Fields
			public ShopAvatarPreviewView __4__this; // 0x10
			public int token; // 0x18
	
			// Constructors
			public __c__DisplayClass73_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ShowSprite_b__0(Sprite sp); // 0x00000001807C7190-0x00000001807C7320
		}
	
		// Constructors
		public ShopAvatarPreviewView(); // 0x00000001807C4A40-0x00000001807C4A90
		static ShopAvatarPreviewView(); // 0x00000001807C4990-0x00000001807C4A40
	
		// Methods
		public void AutoWire(Transform panelRoot, MonoBehaviour host, Action<string> reportMissing); // 0x00000001807C03C0-0x00000001807C0E20
		private void OnBuyClicked(); // 0x00000001807C3CC0-0x00000001807C3D40
		public void Clear(); // 0x00000001807C2CC0-0x00000001807C3310
		public void Bind(ShopAvatarItemDTO item, string baseLayers, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x00000001807C24D0-0x00000001807C2CC0
		public void BindPortrait(ShopAvatarPortraitDTO p, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x00000001807C1820-0x00000001807C1F70
		private void BindSet(ShopAvatarItemDTO item); // 0x00000001807C22E0-0x00000001807C24D0
		private void BindCompare(ShopAvatarItemDTO item); // 0x00000001807C1370-0x00000001807C15A0
		private void BindPrice(ShopAvatarItemDTO item, ShopAvatarWalletDTO wallet, Sprite gold, Sprite ruby, Sprite safia); // 0x00000001807C1F70-0x00000001807C20C0
		private void SetPriceRow(long price, long oldPrice, string currency, bool owned, bool poor, Sprite gold, Sprite ruby, Sprite safia); // 0x00000001807C3F20-0x00000001807C4310
		private void BindButton(ShopAvatarItemDTO item, ShopAvatarWalletDTO wallet); // 0x00000001807C0E70-0x00000001807C1370
		private void BindComposite(ShopAvatarItemDTO item, string baseLayers); // 0x00000001807C15A0-0x00000001807C1820
		private void BindSetNote(ShopAvatarItemDTO item, string baseLayers); // 0x00000001807C20C0-0x00000001807C22E0
		private void ShowComposite(Sprite sp); // 0x00000001807C43B0-0x00000001807C4570
		private void FitContentInAvatarBox(Image img, Sprite sp, float fill, float offsetY); // 0x00000001807C35E0-0x00000001807C3980
		private void FitInAvatarBox(Image img, float zoom, float offsetY); // 0x00000001807C3980-0x00000001807C3C50
		private void ShowSprite(string path); // 0x00000001807C4570-0x00000001807C48E0
		private string ResistLine(int[] resist); // 0x00000001807C3D40-0x00000001807C3F20
		public static string AvatarPath(long avatarId); // 0x00000001807C0E20-0x00000001807C0E70
		private GameObject FindNode(string name, Action<string> missing); // 0x00000001807C3400-0x00000001807C34F0
		private Image FindImage(string name, Action<string> missing); // 0x00000001807C3310-0x00000001807C3400
		private UnityEngine.UI.Text FindText(string name, Action<string> missing); // 0x00000001807C34F0-0x00000001807C35E0
		private static void NoRichText(UnityEngine.UI.Text t); // 0x00000001807C3C50-0x00000001807C3CC0
		private static void SetText(UnityEngine.UI.Text t, string value); // 0x00000001807C4310-0x00000001807C43B0
		private static void Show(UnityEngine.UI.Text t, bool on); // 0x00000001807C48E0-0x00000001807C4990
	}
}
