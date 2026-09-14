/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ShopAvatarCellView : MonoBehaviour // TypeDefIndex: 2747
	{
		// Fields
		public const string N_FRAME = "img_Frame"; // Metadata: 0x005F2AF7
		public const string N_ICON_BG = "img_IconBg"; // Metadata: 0x005F2B01
		public const string N_ICON = "img_Icon"; // Metadata: 0x005F2B0C
		public const string N_NAME = "txt_Name"; // Metadata: 0x005F2B15
		public const string N_PRICE = "sec_Price"; // Metadata: 0x005F2B1E
		public const string N_PRICE_BG = "img_PriceBg"; // Metadata: 0x005F2B28
		public const string N_CURRENCY = "img_Currency"; // Metadata: 0x005F2B34
		public const string N_PRICE_TEXT = "txt_Price"; // Metadata: 0x005F2B41
		public const string N_OWNED = "img_Owned"; // Metadata: 0x005F2B4B
		public const string N_OWNED_TEXT = "txt_Owned"; // Metadata: 0x005F2B55
		public const string N_LOCK = "img_Lock"; // Metadata: 0x005F2B5F
		public const string N_LEVEL = "txt_Level"; // Metadata: 0x005F2B68
		public const string N_TAG = "img_Tag"; // Metadata: 0x005F2B72
		public const string N_TAG_TEXT = "txt_Tag"; // Metadata: 0x005F2B7A
		public const string N_SELECT = "img_Select"; // Metadata: 0x005F2B82
		public const string N_BUTTON = "btn_Cell"; // Metadata: 0x005F2B8D
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
		public int Index { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CA79B0-0x0000000180CA79C0 0x0000000180CA79C0-0x0000000180CA79D0
		public long ShopId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D90F0-0x00000001802D9100 0x0000000180CA79D0-0x0000000180CA79E0
	
		// Events
		public event Action<int> Clicked {
			add; // 0x0000000180CA79E0-0x0000000180CA7B00
			remove; // 0x0000000180CA7B00-0x0000000180CA7C20
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass59_0 // TypeDefIndex: 2748
		{
			// Fields
			public ShopAvatarCellView __4__this; // 0x10
			public int token; // 0x18
	
			// Constructors
			public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindIcon_b__0(Sprite sp); // 0x0000000180CABCF0-0x0000000180CABF40
		}
	
		// Constructors
		public ShopAvatarCellView(); // 0x0000000180CABBE0-0x0000000180CABC40
		static ShopAvatarCellView(); // 0x0000000180CABC40-0x0000000180CABCF0
	
		// Methods
		private void OnDestroy(); // 0x0000000180CA7C20-0x0000000180CA7C80
		public void AutoWire(); // 0x0000000180CA7C80-0x0000000180CA8A20
		public void SetIndex(int index); // 0x0000000180CA79C0-0x0000000180CA79D0
		private void OnClicked(); // 0x0000000180CA8A20-0x0000000180CA8AB0
		public void Clear(); // 0x0000000180CA8AB0-0x0000000180CA9380
		public void Bind(ShopAvatarItemDTO item, MonoBehaviour host); // 0x0000000180CA9380-0x0000000180CA9CB0
		private void BindIcon(long iconId, MonoBehaviour host); // 0x0000000180CA9CB0-0x0000000180CAA290
		private void ShowIcon(Sprite sp); // 0x0000000180CAA290-0x0000000180CAA360
		private void BindPrice(ShopAvatarItemDTO item); // 0x0000000180CAA360-0x0000000180CAA930
		private void BindTag(string tag, bool owned); // 0x0000000180CAA930-0x0000000180CAAC60
		public void SetSelected(bool on); // 0x0000000180CAAC60-0x0000000180CAADC0
		public void MarkOwned(); // 0x0000000180CAADC0-0x0000000180CAB390
		public Sprite SpriteFor(string currencyType); // 0x0000000180CAB390-0x0000000180CAB4F0
		public void InheritCurrencySprites(Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180CAB4F0-0x0000000180CAB810
		private static GameObject FindNode(Transform scope, string name); // 0x0000000180CAB810-0x0000000180CAB940
		private static Image FindImage(Transform scope, string name); // 0x0000000180CAB940-0x0000000180CABA90
		private static UnityEngine.UI.Text FindText(Transform scope, string name); // 0x0000000180CABA90-0x0000000180CABBE0
	}
}
