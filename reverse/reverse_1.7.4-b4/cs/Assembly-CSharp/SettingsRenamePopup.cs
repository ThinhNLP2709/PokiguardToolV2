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
public class SettingsRenamePopup : SettingsDialog // TypeDefIndex: 1231
{
	// Fields
	private const float BOX_W = 900f; // Metadata: 0x005F09E6
	private const float BOX_H = 640f; // Metadata: 0x005F09EA
	private const int FALLBACK_COST = 300000; // Metadata: 0x005F09EE
	private const string TUN_COST = "tun.rename.cost"; // Metadata: 0x005F09F2
	private static readonly Color COUNTER_DIM; // 0x00
	private static readonly Color PLACEHOLDER_DIM; // 0x10
	[NonSerialized]
	public Action<string> onRenamed; // 0x50
	private InputField _input; // 0x58
	private RectTransform _inputRect; // 0x60
	private UnityEngine.UI.Text _txtCurrent; // 0x68
	private UnityEngine.UI.Text _txtCounter; // 0x70
	private UnityEngine.UI.Text _txtRules; // 0x78
	private UnityEngine.UI.Text _txtError; // 0x80
	private UnityEngine.UI.Text _txtFee; // 0x88
	private UnityEngine.UI.Text _txtWallet; // 0x90
	private UnityEngine.UI.Text _txtCooldown; // 0x98
	private Button _btnOk; // 0xA0
	private Button _btnCancel; // 0xA8
	private int _userId; // 0xB0
	private string _currentName; // 0xB8
	private int _costGold; // 0xC0
	private int _gold; // 0xC4
	private int _cooldownSec; // 0xC8
	private bool _sending; // 0xCC

	// Constructors
	public SettingsRenamePopup(); // 0x00000001806EDCD0-0x00000001806EDDA0
	static SettingsRenamePopup(); // 0x00000001806EDDA0-0x00000001806EDE00

	// Methods
	public void Build(); // 0x00000001806E9E50-0x00000001806EAB50
	private void BuildInput(RectTransform box, SettingsConfig.StringsCfg s); // 0x00000001806EAB50-0x00000001806EB430
	public void Open(int userId, string currentName, int knownGold); // 0x00000001806EB430-0x00000001806EB9F0
	private static int ReadTunableCost(); // 0x00000001806EB9F0-0x00000001806EBB50
	private void RefreshTexts(); // 0x00000001806EBB50-0x00000001806EC1F0
	private void UpdateCounter(string raw); // 0x00000001806EC1F0-0x00000001806EC500
	private void OnInputChanged(string raw); // 0x00000001806EC500-0x00000001806EC640
	private void RefreshOkState(); // 0x00000001806EC640-0x00000001806ECC00
	private void ShowError(string message); // 0x00000001806ECC00-0x00000001806ECD40
	private void OnConfirm(); // 0x00000001806ECD40-0x00000001806ED540
	private void OnRenameResult(SettingsApi.RenameRes res); // 0x00000001806ED540-0x00000001806ED970
	private void OnRenameError(string err); // 0x00000001806ED970-0x00000001806EDB30
	private void EndSending(); // 0x00000001806EDB30-0x00000001806EDCD0
	[CompilerGenerated]
	private void _Open_b__26_0(SettingsApi.RenameInfoData info); // 0x00000001806EDE00-0x00000001806EDFD0
	[CompilerGenerated]
	private void _Open_b__26_1(string err); // 0x00000001806EDFD0-0x00000001806EE280
}

