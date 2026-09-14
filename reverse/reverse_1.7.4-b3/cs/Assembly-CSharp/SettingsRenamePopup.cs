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
public class SettingsRenamePopup : SettingsDialog // TypeDefIndex: 1229
{
	// Fields
	private const float BOX_W = 900f; // Metadata: 0x005EF619
	private const float BOX_H = 640f; // Metadata: 0x005EF61D
	private const int FALLBACK_COST = 300000; // Metadata: 0x005EF621
	private const string TUN_COST = "tun.rename.cost"; // Metadata: 0x005EF625
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
	public SettingsRenamePopup(); // 0x00000001806EBFF0-0x00000001806EC0C0
	static SettingsRenamePopup(); // 0x00000001806EC0C0-0x00000001806EC120

	// Methods
	public void Build(); // 0x00000001806E81C0-0x00000001806E8EC0
	private void BuildInput(RectTransform box, SettingsConfig.StringsCfg s); // 0x00000001806E8EC0-0x00000001806E97A0
	public void Open(int userId, string currentName, int knownGold); // 0x00000001806E97A0-0x00000001806E9D60
	private static int ReadTunableCost(); // 0x00000001806E9D60-0x00000001806E9EC0
	private void RefreshTexts(); // 0x00000001806E9EC0-0x00000001806EA560
	private void UpdateCounter(string raw); // 0x00000001806EA560-0x00000001806EA870
	private void OnInputChanged(string raw); // 0x00000001806EA870-0x00000001806EA9B0
	private void RefreshOkState(); // 0x00000001806EA9B0-0x00000001806EAF70
	private void ShowError(string message); // 0x00000001806EAF70-0x00000001806EB0B0
	private void OnConfirm(); // 0x00000001806EB0B0-0x00000001806EB8B0
	private void OnRenameResult(SettingsApi.RenameRes res); // 0x00000001806EB8B0-0x00000001806EBCC0
	private void OnRenameError(string err); // 0x00000001806EBCC0-0x00000001806EBE50
	private void EndSending(); // 0x00000001806EBE50-0x00000001806EBFF0
	[CompilerGenerated]
	private void _Open_b__26_0(SettingsApi.RenameInfoData info); // 0x00000001806EC120-0x00000001806EC2D0
	[CompilerGenerated]
	private void _Open_b__26_1(string err); // 0x00000001806EC2D0-0x00000001806EC550
}

