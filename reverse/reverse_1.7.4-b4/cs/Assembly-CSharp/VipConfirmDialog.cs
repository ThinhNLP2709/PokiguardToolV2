/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class VipConfirmDialog : SettingsDialog // TypeDefIndex: 1473
{
	// Fields
	private const float BOX_W = 900f; // Metadata: 0x005F0FC1
	private const float BOX_H = 420f; // Metadata: 0x005F0FC5
	private const float BTN_W = 250f; // Metadata: 0x005F0FC9
	private const float BTN_H = 68f; // Metadata: 0x005F0FCD
	private const float BTN_Y = 300f; // Metadata: 0x005F0FD1
	private const long DAY_MS = 86400000; // Metadata: 0x005F0FD5
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
	public void Build(); // 0x0000000180801040-0x0000000180801800
	public static void Show(VipPanel host, VipTierData t, Action onYes); // 0x0000000180801800-0x0000000180801A00
	public void Open(VipTierData t, Action onYes); // 0x0000000180801A00-0x0000000180802060
	private static string ExpectedDate(VipTierData t); // 0x0000000180802060-0x0000000180802270
	private void OnYesTap(); // 0x0000000180802270-0x00000001808022A0
	public void SetSending(bool on); // 0x00000001808022A0-0x00000001808024B0
	public void HideNow(); // 0x00000001808024B0-0x0000000180802670
	private static VipConfig.StringsCfg SafeStrings(); // 0x0000000180802670-0x00000001808026C0
	private static string Txt(string value, string fallback); // 0x0000000180343690-0x00000001803436B0
}

