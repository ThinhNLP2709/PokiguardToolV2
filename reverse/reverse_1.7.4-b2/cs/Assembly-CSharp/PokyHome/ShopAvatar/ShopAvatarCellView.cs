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
	[DisallowMultipleComponent]
	public class ShopAvatarCellView : MonoBehaviour // TypeDefIndex: 2304
	{
		// Fields
		public const string N_FRAME = "img_Frame"; // Metadata: 0x0068E69A
		public const string N_ICON_BG = "img_IconBg"; // Metadata: 0x0068E6A4
		public const string N_ICON = "img_Icon"; // Metadata: 0x0068E6AF
		public const string N_NAME = "txt_Name"; // Metadata: 0x0068E6B8
		public const string N_PRICE = "sec_Price"; // Metadata: 0x0068E6C1
		public const string N_PRICE_BG = "img_PriceBg"; // Metadata: 0x0068E6CB
		public const string N_CURRENCY = "img_Currency"; // Metadata: 0x0068E6D7
		public const string N_PRICE_TEXT = "txt_Price"; // Metadata: 0x0068E6E4
		public const string N_OWNED = "img_Owned"; // Metadata: 0x0068E6EE
		public const string N_OWNED_TEXT = "txt_Owned"; // Metadata: 0x0068E6F8
		public const string N_LOCK = "img_Lock"; // Metadata: 0x0068E702
		public const string N_LEVEL = "txt_Level"; // Metadata: 0x0068E70B
		public const string N_TAG = "img_Tag"; // Metadata: 0x0068E715
		public const string N_TAG_TEXT = "txt_Tag"; // Metadata: 0x0068E71D
		public const string N_SELECT = "img_Select"; // Metadata: 0x0068E725
		public const string N_BUTTON = "btn_Cell"; // Metadata: 0x0068E730
		[Header("Node (t\u1EF1 d\u00F2 theo t\u00EAn \u2014 b\u1ED9 d\u1EF1ng kh\u00F4ng c\u1EA7n g\u00E1n)")]
		public Image imgFrame; // 0x20
		public Image imgIconBg; // 0x28
		public Image imgIcon; // 0x30
		public UnityEngine.UI.Text txtName; // 0x38
		public GameObject secPrice; // 0x40
		public Image imgPriceBg; // 0x48
		public Image imgCurrency; // 0x50
		public UnityEngine.UI.Text txtPrice; // 0x58
		public GameObject imgOwned; // 0x60
		public UnityEngine.UI.Text txtOwned; // 0x68
		public GameObject imgLock; // 0x70
		public UnityEngine.UI.Text txtLevel; // 0x78
		public GameObject imgTag; // 0x80
		public UnityEngine.UI.Text txtTag; // 0x88
		public GameObject imgSelect; // 0x90
		public Button btnCell; // 0x98
		[Header("Icon ba lo\u1EA1i ti\u1EC1n (b\u1ED9 d\u1EF1ng g\u00E1n t\u1EEB bundle cash_shop)")]
		public Sprite spriteGold; // 0xA0
		public Sprite spriteRuby; // 0xA8
		public Sprite spriteSafia; // 0xB0
		private static readonly Color PriceNormal; // 0x00
		private static readonly Color PriceShort; // 0x10
		private static readonly Color OwnedTint; // 0x20
		private Color _frameTint; // 0xB8
		private bool _tintCaptured; // 0xC8
		private bool _wired; // 0xC9
		[CompilerGenerated]
		private int _Index_k__BackingField; // 0xCC
		[CompilerGenerated]
		private long _ShopId_k__BackingField; // 0xD0
		[CompilerGenerated]
		private Action<int> Clicked; // 0xD8
		private int _iconToken; // 0xE0
		private static readonly Color OwnedBg; // 0x30
		private static readonly Color DisplayOnlyBg; // 0x40
	
		// Properties
		public int Index { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807B7B10-0x00000001807B7B20 0x00000001807B77A0-0x00000001807B77B0
		public long ShopId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803198C0-0x00000001803198D0 0x00000001807B7BF0-0x00000001807B7C00
	
		// Events
		public event Action<int> Clicked {
			add; // 0x00000001807B7A40-0x00000001807B7B10
			remove; // 0x00000001807B7B20-0x00000001807B7BF0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass59_0 // TypeDefIndex: 2305
		{
			// Fields
			public ShopAvatarCellView __4__this; // 0x10
			public int token; // 0x18
	
			// Constructors
			public __c__DisplayClass59_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _BindIcon_b__0(Sprite sp); // 0x00000001807C6FC0-0x00000001807C7080
		}
	
		// Constructors
		public ShopAvatarCellView(); // 0x00000001807B7A20-0x00000001807B7A40
		static ShopAvatarCellView(); // 0x00000001807B7970-0x00000001807B7A20
	
		// Methods
		private void OnDestroy(); // 0x00000001807B7780-0x00000001807B77A0
		public void AutoWire(); // 0x00000001807B58C0-0x00000001807B6060
		public void SetIndex(int index); // 0x00000001807B77A0-0x00000001807B77B0
		private void OnClicked(); // 0x00000001807B76F0-0x00000001807B7780
		public void Clear(); // 0x00000001807B6F60-0x00000001807B71C0
		public void Bind(ShopAvatarItemDTO item, MonoBehaviour host); // 0x00000001807B6750-0x00000001807B6F60
		private void BindIcon(long iconId, MonoBehaviour host); // 0x00000001807B6060-0x00000001807B6330
		private void ShowIcon(Sprite sp); // 0x00000001807B7840-0x00000001807B78C0
		private void BindPrice(ShopAvatarItemDTO item); // 0x00000001807B6330-0x00000001807B6600
		private void BindTag(string tag, bool owned); // 0x00000001807B6600-0x00000001807B6750
		public void SetSelected(bool on); // 0x00000001807B77B0-0x00000001807B7840
		public void MarkOwned(); // 0x00000001807B7510-0x00000001807B76F0
		public Sprite SpriteFor(string currencyType); // 0x00000001807B78C0-0x00000001807B7970
		public void InheritCurrencySprites(Sprite gold, Sprite ruby, Sprite safia); // 0x00000001807B7410-0x00000001807B7510
		private static GameObject FindNode(Transform scope, string name); // 0x00000001807B7290-0x00000001807B7340
		private static Image FindImage(Transform scope, string name); // 0x00000001807B71C0-0x00000001807B7290
		private static UnityEngine.UI.Text FindText(Transform scope, string name); // 0x00000001807B7340-0x00000001807B7410
	}
}
