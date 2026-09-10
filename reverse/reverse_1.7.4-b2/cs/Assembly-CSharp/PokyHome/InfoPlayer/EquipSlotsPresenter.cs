/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipSlotsPresenter : MonoBehaviour // TypeDefIndex: 2345
	{
		// Fields
		public const string ICON_DIR = "Image/EquipUI/Icon/"; // Metadata: 0x0068EB78
		public const string LEGACY_WEAPON_DIR = "Image/weapons/"; // Metadata: 0x0068EB8C
		public const long LEGACY_ICON_BASE = 9901000; // Metadata: 0x0068EB9B
		public const long LEGACY_ICON_MAX = 9901099; // Metadata: 0x0068EBA3
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
		public int ViewCount { get; } // 0x00000001807CEFD0-0x00000001807CF000 
	
		// Events
		public event Action<EquipSlot> SlotClicked {
			add; // 0x00000001807CEE50-0x00000001807CEF10
			remove; // 0x00000001807CF0C0-0x00000001807CF180
		}
		public event Action<EquipSlot> CloseClicked {
			add; // 0x00000001807CED90-0x00000001807CEE50
			remove; // 0x00000001807CF000-0x00000001807CF0C0
		}
		public event Action<EquipSlot> UpgradeClicked {
			add; // 0x00000001807CEF10-0x00000001807CEFD0
			remove; // 0x00000001807CF180-0x00000001807CF240
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass27_0 // TypeDefIndex: 2346
		{
			// Fields
			public EquipSlotsPresenter __4__this; // 0x10
			public EquipSlotView view; // 0x18
			public int slotIndex; // 0x20
			public int token; // 0x24
	
			// Constructors
			public __c__DisplayClass27_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _LoadIcon_b__0(Sprite sp); // 0x00000001807DC540-0x00000001807DC610
		}
	
		// Constructors
		public EquipSlotsPresenter(); // 0x00000001807CECE0-0x00000001807CED90
	
		// Methods
		public static bool IsLegacyWeaponIcon(long iconId); // 0x00000001807CE820-0x00000001807CE840
		public static string IconPath(long iconId); // 0x00000001807CE730-0x00000001807CE820
		private void Awake(); // 0x00000001807CE0F0-0x00000001807CE100
		private void OnDestroy(); // 0x00000001807CEAA0-0x00000001807CECE0
		private void EnsureCollected(); // 0x00000001807CE300-0x00000001807CE610
		public void ApplySlots(EquipSlotDTO[] slots); // 0x00000001807CDF90-0x00000001807CE0F0
		public RectTransform AnchorOf(EquipSlot slot); // 0x00000001807CDDF0-0x00000001807CDF90
		public EquipSlotView FindView(EquipSlot slot); // 0x00000001807CE610-0x00000001807CE730
		public void Clear(); // 0x00000001807CE100-0x00000001807CE300
		private void LoadIcon(EquipSlotView view, EquipSlotDTO info); // 0x00000001807CE840-0x00000001807CEAA0
		private void OnSlotClicked(EquipSlot slot); // 0x00000001803D9460-0x00000001803D9480
		private void OnCloseClicked(EquipSlot slot); // 0x00000001803D9480-0x00000001803D94A0
		private void OnUpgradeClicked(EquipSlot slot); // 0x00000001803D94A0-0x00000001803D94C0
	}
}
