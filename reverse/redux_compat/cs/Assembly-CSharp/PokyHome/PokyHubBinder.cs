/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHubBinder : MonoBehaviour // TypeDefIndex: 1855
	{
		// Fields
		[Header("Thanh t\u00E0i nguy\u00EAn (InfoUser)")]
		public UnityEngine.UI.Text txtGold; // 0x20
		public UnityEngine.UI.Text txtGem; // 0x28
		public UnityEngine.UI.Text txtPower; // 0x30
		public UnityEngine.UI.Text txtPowerTimer; // 0x38
		public UnityEngine.UI.Text txtArenaCoin; // 0x40
		public UnityEngine.UI.Text txtStoneLight; // 0x48
		public UnityEngine.UI.Text txtStoneWater; // 0x50
		public UnityEngine.UI.Text txtStoneFire; // 0x58
		[Header("Kh\u1ED1i \u0111\u1EA1i di\u1EC7n (LeftUI/UserAvatar)")]
		public Image imgAvatar; // 0x60
		public UnityEngine.UI.Text txtName; // 0x68
		public Image imgLevelFrame; // 0x70
		public UnityEngine.UI.Text txtExp; // 0x78
		public Slider expSlider; // 0x80
		public Image imgMedal; // 0x88
		public WeaponBadgeUI weaponBadge; // 0x90
		[Header("Kh\u00E1c")]
		public Toggle toggleBusy; // 0x98
		public GameObject giftBoxIcon; // 0xA0
		public UnityEngine.UI.Text txtGiftCount; // 0xA8
		public Image flagWheel; // 0xB0
		[CompilerGenerated]
		private int _BoundCount_k__BackingField; // 0xB8
		private ManagerQuangTruong _hub; // 0xC0
		private UnityEngine.UI.Text _oVang; // 0xC8
		private UnityEngine.UI.Text _oSafia; // 0xD0
		private UnityEngine.UI.Text _oNl; // 0xD8
		private UnityEngine.UI.Text _oCountdown; // 0xE0
		private UnityEngine.UI.Text _oCt; // 0xE8
		private UnityEngine.UI.Text _oW; // 0xF0
		private UnityEngine.UI.Text _oB; // 0xF8
		private UnityEngine.UI.Text _oR; // 0x100
		private UnityEngine.UI.Text _oName; // 0x108
		private UnityEngine.UI.Text _oExp; // 0x110
		private UnityEngine.UI.Text _oGiftCount; // 0x118
		private Image _oAvatar; // 0x120
		private Image _oLv; // 0x128
		private Image _oHc; // 0x130
		private Image _oFlagWheel; // 0x138
		private Slider _oExpSlider; // 0x140
		private Toggle _oBusy; // 0x148
		private GameObject _oGiftIcon; // 0x150
		private WeaponBadgeUI _oWeapon; // 0x158
		private bool _applied; // 0x160
	
		// Properties
		public int BoundCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806342B0-0x00000001806342C0 0x00000001806342C0-0x00000001806342D0
	
		// Constructors
		public PokyHubBinder(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public void Apply(ManagerQuangTruong hub); // 0x0000000180633810-0x0000000180633DF0
		public void RefreshNow(); // 0x0000000180633E00-0x0000000180633F00
		public void Restore(); // 0x0000000180633F00-0x00000001806342B0
		private void OnDestroy(); // 0x0000000180633DF0-0x0000000180633E00
		private static bool Set<T>(ref ref T field, T node)
			where T : UnityEngine.Object;
	}
}
