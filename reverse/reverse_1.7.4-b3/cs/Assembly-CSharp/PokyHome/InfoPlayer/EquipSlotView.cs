/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipSlotView : MonoBehaviour // TypeDefIndex: 2780
	{
		// Fields
		public const string NODE_BG = "img_bg"; // Metadata: 0x005F194B
		public const string NODE_ITEM = "img_item"; // Metadata: 0x005F1952
		public const string NODE_NEW = "txt_New"; // Metadata: 0x005F195B
		public const string NODE_STARS = "sec_Star"; // Metadata: 0x005F1963
		public const string NODE_STAR_PREFIX = "img_Star"; // Metadata: 0x005F196C
		public const string NODE_CLOSE = "btn_close"; // Metadata: 0x005F1975
		public const string NODE_UPGRADE = "btn_upgrate"; // Metadata: 0x005F197F
		[Header("\u00D4 n\u00E0y l\u00E0 \u00F4 n\u00E0o \u2014 theo V\u1ECA TR\u00CD m\u00E0n h\u00ECnh (1..12), kh\u1EDBp EquipSlot")]
		[Tooltip("1\u20136 c\u1ED9t tr\u00E1i (6 = th\u00FA c\u01B0ng), 7\u201312 c\u1ED9t ph\u1EA3i.")]
		public int slot; // 0x20
		[Header("Th\u00E0nh ph\u1EA7n")]
		[Tooltip("N\u1EC1n \u00F4. \u1EA2nh \u0111\u1ED5i theo \u0111\u1ED9 hi\u1EBFm c\u1EE7a m\u00F3n \u0111ang m\u1EB7c.")]
		public Image background; // 0x28
		[Tooltip("\u1EA2nh m\u00F3n. T\u1EAFt khi \u00F4 tr\u1ED1ng.")]
		public Image itemIcon; // 0x30
		[Tooltip("Huy hi\u1EC7u NEW. T\u1EAFt s\u1EB5n; b\u1EADt khi trong kho c\u00F3 m\u00F3n ch\u01B0a t\u1EEBng m\u1EB7c h\u1EE3p \u00F4 n\u00E0y.")]
		public GameObject newBadge; // 0x38
		[Tooltip("C\u1EE5m n\u0103m ng\u00F4i sao. T\u1EAFt c\u1EA3 c\u1EE5m khi m\u00F3n kh\u00F4ng n\u00E2ng sao \u0111\u01B0\u1EE3c.")]
		public GameObject starGroup; // 0x40
		[Tooltip("\u0110\u00FAng n\u0103m \u1EA3nh sao, th\u1EE9 t\u1EF1 tr\u00E1i sang ph\u1EA3i.")]
		public Image[] stars; // 0x48
		[Header("N\u00FAt")]
		public Button slotButton; // 0x50
		public Button closeButton; // 0x58
		public Button upgradeButton; // 0x60
		[Header("\u1EA2nh n\u1EC1n theo \u0111\u1ED9 hi\u1EBFm")]
		[Tooltip("\u0110\u00FAng b\u1ED1n \u1EA3nh theo th\u1EE9 t\u1EF1 EquipRarity: Th\u01B0\u1EDDng(slot) \u00B7 Hi\u1EBFm(slot2) \u00B7 Huy\u1EC1n tho\u1EA1i(slot4) \u00B7 V\u00F4 c\u1EF1c(slot3). CH\u00DA \u00DD s\u1ED1 t\u1EC7p KH\u00D4NG \u0111i theo b\u1EADc hi\u1EBFm.")]
		public Sprite[] rarityBackgrounds; // 0x68
		[Tooltip("N\u1EC1n c\u1EE7a \u00F4 tr\u1ED1ng. B\u1ECF tr\u1ED1ng \u21D2 d\u00F9ng n\u1EC1n b\u1EADc Th\u01B0\u1EDDng.")]
		public Sprite emptyBackground; // 0x70
		[Header("M\u00E0u sao")]
		[Tooltip("Sao \u0111\u00E3 \u0111\u1EA1t. Kho \u1EA3nh kh\u00F4ng c\u00F3 sprite sao t\u1ED1i n\u00EAn s\u00E1ng/t\u1EAFt l\u00E0m b\u1EB1ng M\u00C0U.")]
		public Color starOnColor; // 0x78
		[Tooltip("Sao ch\u01B0a \u0111\u1EA1t \u2014 x\u00E1m \u0111\u1EADm: v\u1EABn th\u1EA5y h\u00ECnh nh\u01B0ng r\u00F5 r\u00E0ng l\u00E0 ch\u01B0a c\u00F3.")]
		public Color starOffColor; // 0x88
		[CompilerGenerated]
		private Action<EquipSlot> SlotClicked; // 0x98
		[CompilerGenerated]
		private Action<EquipSlot> CloseClicked; // 0xA0
		[CompilerGenerated]
		private Action<EquipSlot> UpgradeClicked; // 0xA8
		[CompilerGenerated]
		private bool _HasItem_k__BackingField; // 0xB0
		private bool _wired; // 0xB1
	
		// Properties
		public bool HasItem { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC9470-0x0000000180CC9480 0x0000000180CC9480-0x0000000180CC9490
		public EquipSlot Slot { get; } // 0x0000000180CC9490-0x0000000180CC94A0 
	
		// Events
		public event Action<EquipSlot> SlotClicked {
			add; // 0x0000000180CC8DB0-0x0000000180CC8ED0
			remove; // 0x0000000180CC8ED0-0x0000000180CC8FF0
		}
		public event Action<EquipSlot> CloseClicked {
			add; // 0x0000000180CC8FF0-0x0000000180CC9110
			remove; // 0x0000000180CC9110-0x0000000180CC9230
		}
		public event Action<EquipSlot> UpgradeClicked {
			add; // 0x0000000180CC9230-0x0000000180CC9350
			remove; // 0x0000000180CC9350-0x0000000180CC9470
		}
	
		// Constructors
		public EquipSlotView(); // 0x0000000180CCBFE0-0x0000000180CCC150
	
		// Methods
		private void Awake(); // 0x0000000180CC94A0-0x0000000180CC97C0
		private void OnDestroy(); // 0x0000000180CC97C0-0x0000000180CC9C90
		public void AutoWire(); // 0x0000000180CC9C90-0x0000000180CCACA0
		private bool NeedStars(); // 0x0000000180CCACA0-0x0000000180CCAE20
		private void OnSlotClicked(); // 0x0000000180CCAE20-0x0000000180CCAE50
		private void OnCloseClicked(); // 0x0000000180CCAE50-0x0000000180CCAE80
		private void OnUpgradeClicked(); // 0x0000000180CCAE80-0x0000000180CCAEB0
		public void Bind(EquipSlotDTO info); // 0x0000000180CCAEB0-0x0000000180CCB520
		public void SetItemSprite(Sprite sprite); // 0x0000000180CCB520-0x0000000180CCB740
		private void BindEmpty(); // 0x0000000180CCB740-0x0000000180CCBCE0
		private void BindStars(EquipItemDTO item); // 0x0000000180CCBCE0-0x0000000180CCBF90
		private Sprite BackgroundFor(int rarity); // 0x0000000180CCBF90-0x0000000180CCBFE0
	}
}
