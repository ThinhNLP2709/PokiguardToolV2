/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipSlotsPresenter : MonoBehaviour // TypeDefIndex: 2781
	{
		// Fields
		public const string ICON_DIR = "Image/EquipUI/Icon/"; // Metadata: 0x005F198B
		public const string LEGACY_WEAPON_DIR = "Image/weapons/"; // Metadata: 0x005F199F
		public const long LEGACY_ICON_BASE = 9901000; // Metadata: 0x005F19AE
		public const long LEGACY_ICON_MAX = 9901099; // Metadata: 0x005F19B6
		private readonly List<EquipSlotView> _views; // 0x20
		private readonly int[] _iconToken; // 0x28
		private bool _collected; // 0x30
		[CompilerGenerated]
		private Action<EquipSlot> SlotClicked; // 0x38
		[CompilerGenerated]
		private Action<EquipSlot> CloseClicked; // 0x40
		[CompilerGenerated]
		private Action<EquipSlot> UpgradeClicked; // 0x48
	
		// Properties
		public int ViewCount { get; } // 0x0000000180CCC9E0-0x0000000180CCCA10 
	
		// Events
		public event Action<EquipSlot> SlotClicked {
			add; // 0x0000000180CCC320-0x0000000180CCC440
			remove; // 0x0000000180CCC440-0x0000000180CCC560
		}
		public event Action<EquipSlot> CloseClicked {
			add; // 0x0000000180CCC560-0x0000000180CCC680
			remove; // 0x0000000180CCC680-0x0000000180CCC7A0
		}
		public event Action<EquipSlot> UpgradeClicked {
			add; // 0x0000000180CCC7A0-0x0000000180CCC8C0
			remove; // 0x0000000180CCC8C0-0x0000000180CCC9E0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass27_0 // TypeDefIndex: 2782
		{
			// Fields
			public EquipSlotsPresenter __4__this; // 0x10
			public EquipSlotView view; // 0x18
			public int slotIndex; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x0000000180CCDF70-0x0000000180CCE140
		}
	
		// Constructors
		public EquipSlotsPresenter(); // 0x0000000180CCDD90-0x0000000180CCDF70
	
		// Methods
		public static bool IsLegacyWeaponIcon(long iconId); // 0x0000000180CCC150-0x0000000180CCC170
		public static string IconPath(long iconId); // 0x0000000180CCC170-0x0000000180CCC320
		private void Awake(); // 0x0000000180CCCA10-0x0000000180CCCA20
		private void OnDestroy(); // 0x0000000180CCCA20-0x0000000180CCCDD0
		private void EnsureCollected(); // 0x0000000180CCCDD0-0x0000000180CCD2C0
		public void ApplySlots(EquipSlotDTO[] slots); // 0x0000000180CCD2C0-0x0000000180CCD4A0
		public RectTransform AnchorOf(EquipSlot slot); // 0x0000000180CCD4A0-0x0000000180CCD5D0
		public EquipSlotView FindView(EquipSlot slot); // 0x0000000180CCD5D0-0x0000000180CCD780
		public void Clear(); // 0x0000000180CCD780-0x0000000180CCD990
		private void LoadIcon(EquipSlotView view, EquipSlotDTO info); // 0x0000000180CCD990-0x0000000180CCDD90
		private void OnSlotClicked(EquipSlot slot); // 0x0000000180423DD0-0x0000000180423DF0
		private void OnCloseClicked(EquipSlot slot); // 0x0000000180423DF0-0x0000000180423E10
		private void OnUpgradeClicked(EquipSlot slot); // 0x0000000180423E10-0x0000000180423E30
	}
}
