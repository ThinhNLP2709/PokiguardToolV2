/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class TowerResetPopup : MonoBehaviour // TypeDefIndex: 997
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

	// Constructors
	public TowerResetPopup(); // 0x00000001804F2C10-0x00000001804F2D10
	static TowerResetPopup(); // 0x00000001804F2B10-0x00000001804F2C10

	// Methods
	private void Awake(); // 0x00000001804F0B10-0x00000001804F0B20
	private void EnsureWired(); // 0x00000001804F13D0-0x00000001804F1950
	private static void Wire(Button b, UnityAction a); // 0x00000001804F2A70-0x00000001804F2B10
	private static void ApplyRubyIcon(Image img); // 0x00000001804F0A10-0x00000001804F0B10
	public void Show(TowerResetOffer offer, Action<string> onClaim); // 0x00000001804F2440-0x00000001804F2820
	private void RenderSlot(int slot, Button btn, GameObject free, GameObject fee, UnityEngine.UI.Text price, Button gift); // 0x00000001804F1C10-0x00000001804F1DE0
	private TowerResetPackage PackageAt(int slot); // 0x00000001804F1A10-0x00000001804F1AE0
	public void ShowTooltip(int slot); // 0x00000001804F2250-0x00000001804F2440
	private void EnsureTooltipScroll(); // 0x00000001804F0FC0-0x00000001804F13D0
	private void RefreshTooltipScroll(); // 0x00000001804F1AE0-0x00000001804F1C10
	public void HideTooltip(); // 0x00000001804F1950-0x00000001804F1A10
	public void ShowClaimedGift(TowerGiftBundle gift, string title); // 0x00000001804F1DE0-0x00000001804F2250
	public void Close(); // 0x00000001804F0B70-0x00000001804F0C90
	private void Claim(int slot); // 0x00000001804F0B20-0x00000001804F0B70
	public static string ConfirmText(TowerResetPackage p); // 0x00000001804F0C90-0x00000001804F0FC0
	public static string TypeLabel(string packageType); // 0x00000001804F2820-0x00000001804F2950
	[CompilerGenerated]
	private void _EnsureWired_b__28_0(); // 0x00000001804F2950-0x00000001804F29A0
	[CompilerGenerated]
	private void _EnsureWired_b__28_1(); // 0x00000001804F29A0-0x00000001804F29F0
	[CompilerGenerated]
	private void _EnsureWired_b__28_2(); // 0x00000001804F29F0-0x00000001804F2A40
	[CompilerGenerated]
	private void _EnsureWired_b__28_3(); // 0x00000001804F2A40-0x00000001804F2A50
	[CompilerGenerated]
	private void _EnsureWired_b__28_4(); // 0x00000001804F2A50-0x00000001804F2A60
	[CompilerGenerated]
	private void _EnsureWired_b__28_5(); // 0x00000001804F2A60-0x00000001804F2A70
}

