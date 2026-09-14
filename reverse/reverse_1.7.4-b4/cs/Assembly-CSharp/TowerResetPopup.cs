/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class TowerResetPopup : MonoBehaviour // TypeDefIndex: 1368
{
	// Fields
	private static readonly string[] SlotType; // 0x00
	[Header("Ti\u00EAu \u0111\u1EC1")]
	public UnityEngine.UI.Text txtResetFloor; // 0x20
	[Header("N\u00FAt nh\u1EADn (0=Th\u01B0\u1EDDng, 1=VIP, 2=\u0110\u1EB7c bi\u1EC7t)")]
	public Button btnResetNormal; // 0x28
	public Button btnResetVip; // 0x30
	public Button btnResetSpecial; // 0x38
	[Header("Th\u00E2n MI\u1EC4N PH\u00CD")]
	public GameObject freeNormal; // 0x40
	public GameObject freeVip; // 0x48
	public GameObject freeSpecial; // 0x50
	[Header("Th\u00E2n C\u00D3 PH\u00CD")]
	public GameObject feeNormal; // 0x58
	public GameObject feeVip; // 0x60
	public GameObject feeSpecial; // 0x68
	[Header("Gi\u00E1 (Ruby)")]
	public UnityEngine.UI.Text txtPriceNormal; // 0x70
	public UnityEngine.UI.Text txtPriceVip; // 0x78
	public UnityEngine.UI.Text txtPriceSpecial; // 0x80
	[Header("Icon ti\u1EC1n t\u1EC7 (\u0111\u1ED5i Gems c\u1EE7a Poky \u2192 Ruby c\u1EE7a Pokiguard)")]
	public Image iconRubyNormal; // 0x88
	public Image iconRubyVip; // 0x90
	public Image iconRubySpecial; // 0x98
	[Header("V\u00F9ng b\u1EA5m xem qu\u00E0")]
	public Button btnGiftNormal; // 0xA0
	public Button btnGiftVip; // 0xA8
	public Button btnGiftSpecial; // 0xB0
	[Header("Tooltip qu\u00E0")]
	public GameObject resetTooltip; // 0xB8
	public Transform resetTooltipContainer; // 0xC0
	public Button resetTooltipMask; // 0xC8
	private readonly Dictionary<string, TowerResetPackage> _byType; // 0xD0
	private Action<string> _onClaim; // 0xD8
	private bool _wired; // 0xE0
	private ScrollRect _tipScroll; // 0xE8
	private const float AUTO_CLOSE_SEC = 6f; // Metadata: 0x005F0DC6
	private Coroutine _autoCloseCo; // 0xF0
	[CompilerGenerated]
	private bool _ShowingClaimedGift_k__BackingField; // 0xF8

	// Properties
	public bool ShowingClaimedGift { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180737400-0x0000000180737410 0x0000000180777A90-0x0000000180777AA0

	// Nested types
	[CompilerGenerated]
	private sealed class _AutoClose_d__46 : IEnumerator<object> // TypeDefIndex: 1369
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerResetPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoClose_d__46(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018077B4A0-0x000000018077B5F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018077B5F0-0x000000018077B630
	}

	// Constructors
	public TowerResetPopup(); // 0x000000018077B080-0x000000018077B240
	static TowerResetPopup(); // 0x000000018077B240-0x000000018077B380

	// Methods
	private void Awake(); // 0x0000000180777AA0-0x0000000180777AB0
	private void OnDisable(); // 0x0000000180777AB0-0x0000000180777B20
	private void EnsureWired(); // 0x0000000180777B20-0x0000000180777DE0
	private static void Wire(Button b, UnityAction a); // 0x0000000180777DE0-0x0000000180777EF0
	private static void ApplyRubyIcon(Image img); // 0x0000000180777EF0-0x00000001807780F0
	public void Show(TowerResetOffer offer, Action<string> onClaim); // 0x00000001807780F0-0x0000000180778700
	private void RenderSlot(int slot, Button btn, GameObject free, GameObject fee, UnityEngine.UI.Text price, Button gift); // 0x0000000180778700-0x0000000180778BF0
	private TowerResetPackage PackageAt(int slot); // 0x0000000180778BF0-0x0000000180778CD0
	public void ShowTooltip(int slot); // 0x0000000180778CD0-0x0000000180779200
	private void EnsureTooltipScroll(); // 0x0000000180779200-0x0000000180779A60
	private void RefreshTooltipScroll(); // 0x0000000180779A60-0x0000000180779CA0
	public void HideTooltip(); // 0x0000000180779CA0-0x0000000180779F00
	public bool ShowClaimedGift(TowerGiftBundle gift, string title); // 0x0000000180779F00-0x000000018077A8F0
	[IteratorStateMachine(typeof(_AutoClose_d__46))]
	private IEnumerator AutoClose(); // 0x000000018077A8F0-0x000000018077A990
	private void StopAutoClose(); // 0x000000018077A990-0x000000018077AA10
	public void Close(); // 0x000000018077AA10-0x000000018077AC20
	private void Claim(int slot); // 0x000000018077AC20-0x000000018077AC70
	public static string ConfirmText(TowerResetPackage p); // 0x000000018077AC70-0x000000018077AE70
	public static string TypeLabel(string packageType); // 0x000000018077AE70-0x000000018077B080
	[CompilerGenerated]
	private void _EnsureWired_b__35_0(); // 0x000000018077B380-0x000000018077B3D0
	[CompilerGenerated]
	private void _EnsureWired_b__35_1(); // 0x000000018077B3D0-0x000000018077B420
	[CompilerGenerated]
	private void _EnsureWired_b__35_2(); // 0x000000018077B420-0x000000018077B470
	[CompilerGenerated]
	private void _EnsureWired_b__35_3(); // 0x000000018077B470-0x000000018077B480
	[CompilerGenerated]
	private void _EnsureWired_b__35_4(); // 0x000000018077B480-0x000000018077B490
	[CompilerGenerated]
	private void _EnsureWired_b__35_5(); // 0x000000018077B490-0x000000018077B4A0
}

