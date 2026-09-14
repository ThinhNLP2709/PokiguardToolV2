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
	public class EquipBagCellView : MonoBehaviour // TypeDefIndex: 2773
	{
		// Fields
		public const string NODE_BG = "img_Bg"; // Metadata: 0x005F18BD
		public const string NODE_ICON = "img_Icon"; // Metadata: 0x005F18C4
		public const string NODE_EQUIPPED = "sec_Equipped"; // Metadata: 0x005F18CD
		public const string NODE_NEW = "txt_New"; // Metadata: 0x005F18DA
		public const string NODE_SELECT = "sec_Select"; // Metadata: 0x005F18E2
		public const string NODE_RARITY = "txt_Rarity"; // Metadata: 0x005F18ED
		[Header("Th\u00E0nh ph\u1EA7n")]
		public Image background; // 0x20
		public Image itemIcon; // 0x28
		[Tooltip("Khung ch\u1ECDn v\u00E0ng. V\u1EBD TR\u00CAN m\u1ECDi th\u1EE9 \u2014 n\u00F3 l\u00E0 vi\u1EC1n n\u00EAn kh\u00F4ng che m\u00F3n.")]
		public GameObject selectedMark; // 0x30
		[Tooltip("Ribbon \'\u0110\u00E3 m\u1EB7c\'. T\u1EAFt s\u1EB5n.")]
		public GameObject equippedMark; // 0x38
		[Tooltip("Ch\u1EEF NEW \u2014 m\u00F3n ch\u01B0a t\u1EEBng m\u1EB7c. T\u1EAFt s\u1EB5n.")]
		public GameObject newBadge; // 0x40
		[Header("N\u00FAt")]
		[Tooltip("B\u1EA5m v\u00E0o \u00F4: ch\u1ECDn \u00F4 v\u00E0 m\u1EDF tooltip. N\u00FAt \'M\u1EB7c\' n\u1EB1m TRONG tooltip, kh\u00F4ng tr\u00EAn \u00F4 \u2014 tr\u00EAn m\u1ED9t \u00F4 105 px, m\u1ED9t c\u00E1i n\u00FAt che m\u1EA5t \u0111\u00FAng th\u1EE9 ng\u01B0\u1EDDi ch\u01A1i \u0111ang nh\u00ECn \u0111\u1EC3 ch\u1ECDn.")]
		public Button cellButton; // 0x48
		[Header("\u1EA2nh n\u1EC1n")]
		[Tooltip("B\u1ED1n \u1EA3nh theo th\u1EE9 t\u1EF1 EquipRarity. L\u01B0\u1EDBi kho hi\u1EC7n ch\u1EC9 d\u00F9ng ph\u1EA7n t\u1EED [0] \u2014 xem BackgroundFor.")]
		public Sprite[] rarityBackgrounds; // 0x50
		[Tooltip("N\u1EC1n \u00F4 TR\u1ED0NG. B\u1ECF tr\u1ED1ng \u21D2 d\u00F9ng ch\u00EDnh \u1EA3nh b\u1EADc Th\u01B0\u1EDDng, l\u00E0m t\u1ED1i b\u1EB1ng emptyTint.")]
		public Sprite emptyBackground; // 0x58
		[Tooltip("M\u00E0u n\u1EC1n c\u1EE7a \u00F4 TR\u1ED0NG \u2014 ph\u1EA3i t\u1ED1i \u0111i \u0111\u1EC3 m\u1ED9t m\u00F3n b\u1EADc Th\u01B0\u1EDDng ch\u01B0a k\u1ECBp t\u1EA3i \u1EA3nh kh\u00F4ng tr\u00F4ng y h\u1EC7t m\u1ED9t \u00F4 kh\u00F4ng c\u00F3 g\u00EC.")]
		public Color emptyTint; // 0x60
		[CompilerGenerated]
		private Action<int> Clicked; // 0x70
		[CompilerGenerated]
		private bool _HasItem_k__BackingField; // 0x78
		[CompilerGenerated]
		private bool _IsEquipped_k__BackingField; // 0x79
		[CompilerGenerated]
		private int _Index_k__BackingField; // 0x7C
		private bool _wired; // 0x80
		private static readonly Color[] RARITY_TINT; // 0x00
		private static readonly string[] RARITY_NAME; // 0x08
		private UnityEngine.UI.Text _rarityRibbon; // 0x88
		private bool _ribbonTried; // 0x90
		private Image _rarityPill; // 0x98
	
		// Properties
		public bool HasItem { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CBE460-0x0000000180CBE470 0x0000000180CBE470-0x0000000180CBE480
		public bool IsEquipped { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CBE480-0x0000000180CBE490 0x0000000180CBE490-0x0000000180CBE4A0
		public int Index { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CBE4A0-0x0000000180CBE4B0 0x0000000180CBE4B0-0x0000000180CBE4C0
	
		// Events
		public event Action<int> Clicked {
			add; // 0x0000000180CBE220-0x0000000180CBE340
			remove; // 0x0000000180CBE340-0x0000000180CBE460
		}
	
		// Constructors
		public EquipBagCellView(); // 0x0000000180CC1AC0-0x0000000180CC1BA0
		static EquipBagCellView(); // 0x0000000180CC1BA0-0x0000000180CC1E20
	
		// Methods
		private void Awake(); // 0x0000000180CBE4C0-0x0000000180CBE630
		private void OnDestroy(); // 0x0000000180CBE630-0x0000000180CBE820
		public void AutoWire(); // 0x0000000180CBE820-0x0000000180CBF300
		public void SetIndex(int index); // 0x0000000180CBE4B0-0x0000000180CBE4C0
		private void OnCellClicked(); // 0x0000000180CBF300-0x0000000180CBF320
		public void Bind(EquipBagItemDTO entry); // 0x0000000180CBF320-0x0000000180CBF330
		public void Bind(EquipBagItemDTO entry, bool artAmbiguous); // 0x0000000180CBF330-0x0000000180CBF7F0
		public void Clear(); // 0x0000000180CBF7F0-0x0000000180CBFD00
		public void SetItemSprite(Sprite sprite); // 0x0000000180CBFD00-0x0000000180CBFF20
		public void SetSelected(bool selected); // 0x0000000180CBFF20-0x0000000180CC0090
		private Sprite BackgroundFor(int rarity, bool artAmbiguous); // 0x0000000180CC0090-0x0000000180CC0210
		private void ApplyRarityRibbon(int rarity, bool artAmbiguous); // 0x0000000180CC0210-0x0000000180CC06A0
		private void SetRibbonVisible(bool on); // 0x0000000180CC06A0-0x0000000180CC0910
		private UnityEngine.UI.Text EnsureRarityRibbon(); // 0x0000000180CC0910-0x0000000180CC1AC0
	}
}
