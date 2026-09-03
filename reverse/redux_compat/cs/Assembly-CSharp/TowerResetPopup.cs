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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class TowerResetPopup : MonoBehaviour // TypeDefIndex: 802
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

	// Constructors
	public TowerResetPopup(); // 0x0000000180431CB0-0x0000000180431DB0
	static TowerResetPopup(); // 0x0000000180431BB0-0x0000000180431CB0

	// Methods
	private void Awake(); // 0x0000000180430210-0x0000000180430220
	private void EnsureWired(); // 0x0000000180430640-0x0000000180430BC0
	private static void Wire(Button b, UnityAction a); // 0x0000000180431B10-0x0000000180431BB0
	private static void ApplyRubyIcon(Image img); // 0x000000018042FFF0-0x0000000180430210
	public void Show(TowerResetOffer offer, Action<string> onClaim); // 0x0000000180431510-0x00000001804318F0
	private void RenderSlot(int slot, Button btn, GameObject free, GameObject fee, UnityEngine.UI.Text price, Button gift); // 0x0000000180430D50-0x0000000180430F20
	private TowerResetPackage PackageAt(int slot); // 0x0000000180430C80-0x0000000180430D50
	public void ShowTooltip(int slot); // 0x0000000180431360-0x0000000180431510
	public void HideTooltip(); // 0x0000000180430BC0-0x0000000180430C80
	public void ShowClaimedGift(TowerGiftBundle gift, string title); // 0x0000000180430F20-0x0000000180431360
	public void Close(); // 0x0000000180430270-0x0000000180430390
	private void Claim(int slot); // 0x0000000180430220-0x0000000180430270
	public static string ConfirmText(TowerResetPackage p); // 0x0000000180430390-0x0000000180430640
	public static string TypeLabel(string packageType); // 0x00000001804318F0-0x00000001804319F0
	[CompilerGenerated]
	private void _EnsureWired_b__27_0(); // 0x00000001804319F0-0x0000000180431A40
	[CompilerGenerated]
	private void _EnsureWired_b__27_1(); // 0x0000000180431A40-0x0000000180431A90
	[CompilerGenerated]
	private void _EnsureWired_b__27_2(); // 0x0000000180431A90-0x0000000180431AE0
	[CompilerGenerated]
	private void _EnsureWired_b__27_3(); // 0x0000000180431AE0-0x0000000180431AF0
	[CompilerGenerated]
	private void _EnsureWired_b__27_4(); // 0x0000000180431AF0-0x0000000180431B00
	[CompilerGenerated]
	private void _EnsureWired_b__27_5(); // 0x0000000180431B00-0x0000000180431B10
}

