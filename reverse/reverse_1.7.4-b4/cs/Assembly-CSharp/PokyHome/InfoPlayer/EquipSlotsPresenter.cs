/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipSlotsPresenter : MonoBehaviour // TypeDefIndex: 2788
	{
		// Fields
		public const string ICON_DIR = "Image/EquipUI/Icon/"; // Metadata: 0x005F2DA2
		public const string LEGACY_WEAPON_DIR = "Image/weapons/"; // Metadata: 0x005F2DB6
		public const long LEGACY_ICON_BASE = 9901000; // Metadata: 0x005F2DC5
		public const long LEGACY_ICON_MAX = 9901099; // Metadata: 0x005F2DCD
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
		public int ViewCount { get; } // 0x0000000180CDA220-0x0000000180CDA250 
	
		// Events
		public event Action<EquipSlot> SlotClicked {
			add; // 0x0000000180CD9B60-0x0000000180CD9C80
			remove; // 0x0000000180CD9C80-0x0000000180CD9DA0
		}
		public event Action<EquipSlot> CloseClicked {
			add; // 0x0000000180CD9DA0-0x0000000180CD9EC0
			remove; // 0x0000000180CD9EC0-0x0000000180CD9FE0
		}
		public event Action<EquipSlot> UpgradeClicked {
			add; // 0x0000000180CD9FE0-0x0000000180CDA100
			remove; // 0x0000000180CDA100-0x0000000180CDA220
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass27_0 // TypeDefIndex: 2789
		{
			// Fields
			public EquipSlotsPresenter __4__this; // 0x10
			public EquipSlotView view; // 0x18
			public int slotIndex; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x0000000180CDB7F0-0x0000000180CDB9C0
		}
	
		// Constructors
		public EquipSlotsPresenter(); // 0x0000000180CDB610-0x0000000180CDB7F0
	
		// Methods
		public static bool IsLegacyWeaponIcon(long iconId); // 0x0000000180CD9990-0x0000000180CD99B0
		public static string IconPath(long iconId); // 0x0000000180CD99B0-0x0000000180CD9B60
		private void Awake(); // 0x0000000180CDA250-0x0000000180CDA260
		private void OnDestroy(); // 0x0000000180CDA260-0x0000000180CDA610
		private void EnsureCollected(); // 0x0000000180CDA610-0x0000000180CDAB00
		public void ApplySlots(EquipSlotDTO[] slots); // 0x0000000180CDAB00-0x0000000180CDACE0
		public RectTransform AnchorOf(EquipSlot slot); // 0x0000000180CDACE0-0x0000000180CDAE10
		public EquipSlotView FindView(EquipSlot slot); // 0x0000000180CDAE10-0x0000000180CDAFC0
		public void Clear(); // 0x0000000180CDAFC0-0x0000000180CDB1D0
		private void LoadIcon(EquipSlotView view, EquipSlotDTO info); // 0x0000000180CDB1D0-0x0000000180CDB610
		private void OnSlotClicked(EquipSlot slot); // 0x0000000180424B30-0x0000000180424B50
		private void OnCloseClicked(EquipSlot slot); // 0x0000000180424B50-0x0000000180424B70
		private void OnUpgradeClicked(EquipSlot slot); // 0x0000000180424B70-0x0000000180424B90
	}
}
