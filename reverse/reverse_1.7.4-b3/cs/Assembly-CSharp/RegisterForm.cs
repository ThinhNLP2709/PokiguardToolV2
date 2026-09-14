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
public class RegisterForm : MonoBehaviour // TypeDefIndex: 1086
{
	// Fields
	private const float PAD = 40f; // Metadata: 0x005EF3C4
	private const float FIELD_W = 680f; // Metadata: 0x005EF3C8
	private const float FIELD_H = 64f; // Metadata: 0x005EF3CC
	private const float BAR_W = 540f; // Metadata: 0x005EF3D0
	private const int USER_MIN = 3; // Metadata: 0x005EF3D4
	private const int USER_MAX = 20; // Metadata: 0x005EF3D5
	private const int PASS_MIN = 6; // Metadata: 0x005EF3D6
	private const int PASS_MAX = 64; // Metadata: 0x005EF3D7
	private const string ERR_PASSWORD = "M\u1EADt kh\u1EA9u 6\u201364 k\u00FD t\u1EF1, kh\u00F4ng c\u00F3 kho\u1EA3ng tr\u1EAFng."; // Metadata: 0x005EF3D9
	public Action<string, string, string> OnSubmit; // 0x20
	private LoginField _name; // 0x28
	private LoginField _user; // 0x60
	private LoginField _pass; // 0x98
	private LoginField _confirm; // 0xD0
	private UnityEngine.UI.Text _txtNameCount; // 0x108
	private UnityEngine.UI.Text _txtNameRule; // 0x110
	private UnityEngine.UI.Text _txtUserRule; // 0x118
	private UnityEngine.UI.Text _txtStrength; // 0x120
	private UnityEngine.UI.Text _txtError; // 0x128
	private UnityEngine.UI.Text _txtDeviceNote; // 0x130
	private Image _barFill; // 0x138
	private Image _icMatch; // 0x140
	private Button _btnRegister; // 0x148
	private UnityEngine.UI.Text _btnRegisterLabel; // 0x150
	private Image _eyeIcon; // 0x158
	private UnityEngine.UI.Text _eyeLabel; // 0x160
	private bool _passVisible; // 0x168
	private bool _interactable; // 0x169
	private int _lastCount; // 0x16C
	private int _lastStrength; // 0x170
	[CompilerGenerated]
	private CanvasGroup _Group_k__BackingField; // 0x178
	[CompilerGenerated]
	private RectTransform _Rect_k__BackingField; // 0x180

	// Properties
	public CanvasGroup Group { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018066D1C0-0x000000018066D1D0 0x000000018066D1D0-0x000000018066D230
	public RectTransform Rect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018066D230-0x000000018066D240 0x000000018066D240-0x000000018066D2A0
	public UnityEngine.UI.Text ErrorText { get; } // 0x000000018066D2A0-0x000000018066D2B0 
	public RectTransform RegisterButtonRect { get; } // 0x000000018066D2B0-0x000000018066D3D0 
	public RectTransform CardRect { get; } // 0x000000018066D3D0-0x000000018066D510 

	// Constructors
	public RegisterForm(); // 0x0000000180672320-0x0000000180672380

	// Methods
	public void Build(Transform parent); // 0x000000018066D510-0x000000018066EED0
	private void BuildStrengthBar(LoginConfig.StringsCfg s); // 0x000000018066EED0-0x000000018066F4B0
	private void OnNameChanged(string raw); // 0x000000018066F4B0-0x000000018066F720
	private void Revalidate(); // 0x000000018066F720-0x000000018066FAF0
	private static bool ValidName(string raw); // 0x000000018066FAF0-0x000000018066FEC0
	private static bool ValidUser(string raw); // 0x000000018066FEC0-0x000000018066FF30
	private static bool ValidPass(string raw); // 0x000000018066FF30-0x000000018066FF50
	private static void Rim(Image rim, string value, bool ok); // 0x000000018066FF50-0x0000000180670150
	private void RefreshStrength(string pass); // 0x0000000180670150-0x00000001806707E0
	private void ToggleEye(); // 0x00000001806707E0-0x0000000180670890
	private static void NextField(LoginField next); // 0x0000000180670890-0x0000000180670A00
	private void OnConfirmEndEdit(string _); // 0x0000000180670A00-0x0000000180670A90
	public void Submit(); // 0x0000000180670A90-0x00000001806711E0
	private void FocusWithError(LoginField f, string message); // 0x00000001806711E0-0x0000000180671340
	public void Focus(); // 0x0000000180671340-0x0000000180671440
	public void Reset(); // 0x0000000180671440-0x0000000180671760
	public void SetInteractable(bool on); // 0x0000000180671760-0x0000000180671A40
	public void MarkTaken(bool userTaken, bool nameTaken); // 0x0000000180671A40-0x0000000180671DE0
	public void MarkDeviceLimit(); // 0x0000000180671DE0-0x0000000180671F30
	public void ShowError(string message); // 0x0000000180671F30-0x00000001806720E0
	public void ClearError(); // 0x00000001806720E0-0x0000000180672260
	private static string Safe(string format, object arg0); // 0x0000000180672260-0x0000000180672320
	[CompilerGenerated]
	private void _Build_b__44_0(string _); // 0x0000000180672380-0x00000001806723D0
	[CompilerGenerated]
	private void _Build_b__44_1(string _); // 0x00000001806723D0-0x00000001806723E0
	[CompilerGenerated]
	private void _Build_b__44_2(string _); // 0x00000001806723E0-0x0000000180672430
	[CompilerGenerated]
	private void _Build_b__44_3(string _); // 0x00000001806723D0-0x00000001806723E0
	[CompilerGenerated]
	private void _Build_b__44_4(string _); // 0x0000000180672430-0x0000000180672480
	[CompilerGenerated]
	private void _Build_b__44_5(string _); // 0x00000001806723D0-0x00000001806723E0
}

