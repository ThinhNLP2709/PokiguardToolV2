/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	[DisallowMultipleComponent]
	public class ShopAvatarCellView : MonoBehaviour // TypeDefIndex: 2740
	{
		// Fields
		public const string N_FRAME = "img_Frame"; // Metadata: 0x005F16E0
		public const string N_ICON_BG = "img_IconBg"; // Metadata: 0x005F16EA
		public const string N_ICON = "img_Icon"; // Metadata: 0x005F16F5
		public const string N_NAME = "txt_Name"; // Metadata: 0x005F16FE
		public const string N_PRICE = "sec_Price"; // Metadata: 0x005F1707
		public const string N_PRICE_BG = "img_PriceBg"; // Metadata: 0x005F1711
		public const string N_CURRENCY = "img_Currency"; // Metadata: 0x005F171D
		public const string N_PRICE_TEXT = "txt_Price"; // Metadata: 0x005F172A
		public const string N_OWNED = "img_Owned"; // Metadata: 0x005F1734
		public const string N_OWNED_TEXT = "txt_Owned"; // Metadata: 0x005F173E
		public const string N_LOCK = "img_Lock"; // Metadata: 0x005F1748
		public const string N_LEVEL = "txt_Level"; // Metadata: 0x005F1751
		public const string N_TAG = "img_Tag"; // Metadata: 0x005F175B
		public const string N_TAG_TEXT = "txt_Tag"; // Metadata: 0x005F1763
		public const string N_SELECT = "img_Select"; // Metadata: 0x005F176B
		public const string N_BUTTON = "btn_Cell"; // Metadata: 0x005F1776
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
		public int Index { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C74300-0x0000000180C74310 0x0000000180C74310-0x0000000180C74320
		public long ShopId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D90C0-0x00000001802D90D0 0x0000000180C74320-0x0000000180C74330
	
		// Events
		public event Action<int> Clicked {
			add; // 0x0000000180C74330-0x0000000180C74450
			remove; // 0x0000000180C74450-0x0000000180C74570
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass59_0 // TypeDefIndex: 2741
		{
			// Fields
			public ShopAvatarCellView __4__this; // 0x10
			public int token; // 0x18
	
			// Constructors
			public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindIcon_b__0(Sprite sp); // 0x0000000180C78610-0x0000000180C78860
		}
	
		// Constructors
		public ShopAvatarCellView(); // 0x0000000180C78500-0x0000000180C78560
		static ShopAvatarCellView(); // 0x0000000180C78560-0x0000000180C78610
	
		// Methods
		private void OnDestroy(); // 0x0000000180C74570-0x0000000180C745D0
		public void AutoWire(); // 0x0000000180C745D0-0x0000000180C75370
		public void SetIndex(int index); // 0x0000000180C74310-0x0000000180C74320
		private void OnClicked(); // 0x0000000180C75370-0x0000000180C75400
		public void Clear(); // 0x0000000180C75400-0x0000000180C75CD0
		public void Bind(ShopAvatarItemDTO item, MonoBehaviour host); // 0x0000000180C75CD0-0x0000000180C76600
		private void BindIcon(long iconId, MonoBehaviour host); // 0x0000000180C76600-0x0000000180C76BB0
		private void ShowIcon(Sprite sp); // 0x0000000180C76BB0-0x0000000180C76C80
		private void BindPrice(ShopAvatarItemDTO item); // 0x0000000180C76C80-0x0000000180C77250
		private void BindTag(string tag, bool owned); // 0x0000000180C77250-0x0000000180C77580
		public void SetSelected(bool on); // 0x0000000180C77580-0x0000000180C776E0
		public void MarkOwned(); // 0x0000000180C776E0-0x0000000180C77CB0
		public Sprite SpriteFor(string currencyType); // 0x0000000180C77CB0-0x0000000180C77E10
		public void InheritCurrencySprites(Sprite gold, Sprite ruby, Sprite safia); // 0x0000000180C77E10-0x0000000180C78130
		private static GameObject FindNode(Transform scope, string name); // 0x0000000180C78130-0x0000000180C78260
		private static Image FindImage(Transform scope, string name); // 0x0000000180C78260-0x0000000180C783B0
		private static UnityEngine.UI.Text FindText(Transform scope, string name); // 0x0000000180C783B0-0x0000000180C78500
	}
}
