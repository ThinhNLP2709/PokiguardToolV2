/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class VipConfirmDialog : SettingsDialog // TypeDefIndex: 1471
{
	// Fields
	private const float BOX_W = 900f; // Metadata: 0x005EFBF4
	private const float BOX_H = 420f; // Metadata: 0x005EFBF8
	private const float BTN_W = 250f; // Metadata: 0x005EFBFC
	private const float BTN_H = 68f; // Metadata: 0x005EFC00
	private const float BTN_Y = 300f; // Metadata: 0x005EFC04
	private const long DAY_MS = 86400000; // Metadata: 0x005EFC08
	private UnityEngine.UI.Text _title; // 0x50
	private UnityEngine.UI.Text _body; // 0x58
	private Button _btnYes; // 0x60
	private Button _btnNo; // 0x68
	private UnityEngine.UI.Text _lblYes; // 0x70
	private UnityEngine.UI.Text _lblNo; // 0x78
	private Action _onYes; // 0x80
	private bool _sending; // 0x88

	// Constructors
	public VipConfirmDialog(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Build(); // 0x00000001807FEF50-0x00000001807FF710
	public static void Show(VipPanel host, VipTierData t, Action onYes); // 0x00000001807FF710-0x00000001807FF910
	public void Open(VipTierData t, Action onYes); // 0x00000001807FF910-0x00000001807FFF70
	private static string ExpectedDate(VipTierData t); // 0x00000001807FFF70-0x0000000180800180
	private void OnYesTap(); // 0x0000000180800180-0x00000001808001B0
	public void SetSending(bool on); // 0x00000001808001B0-0x00000001808003C0
	public void HideNow(); // 0x00000001808003C0-0x0000000180800580
	private static VipConfig.StringsCfg SafeStrings(); // 0x0000000180800580-0x00000001808005D0
	private static string Txt(string value, string fallback); // 0x0000000180343570-0x0000000180343590
}

