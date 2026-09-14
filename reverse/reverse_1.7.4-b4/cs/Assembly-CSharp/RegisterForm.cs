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
public class RegisterForm : MonoBehaviour // TypeDefIndex: 1088
{
	// Fields
	private const float PAD = 40f; // Metadata: 0x005F0791
	private const float FIELD_W = 680f; // Metadata: 0x005F0795
	private const float FIELD_H = 64f; // Metadata: 0x005F0799
	private const float BAR_W = 540f; // Metadata: 0x005F079D
	private const int USER_MIN = 3; // Metadata: 0x005F07A1
	private const int USER_MAX = 20; // Metadata: 0x005F07A2
	private const int PASS_MIN = 6; // Metadata: 0x005F07A3
	private const int PASS_MAX = 64; // Metadata: 0x005F07A4
	private const string ERR_PASSWORD = "M\u1EADt kh\u1EA9u 6\u201364 k\u00FD t\u1EF1, kh\u00F4ng c\u00F3 kho\u1EA3ng tr\u1EAFng."; // Metadata: 0x005F07A6
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
	public CanvasGroup Group { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018066EBB0-0x000000018066EBC0 0x000000018066EBC0-0x000000018066EC20
	public RectTransform Rect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018066EC20-0x000000018066EC30 0x000000018066EC30-0x000000018066EC90
	public UnityEngine.UI.Text ErrorText { get; } // 0x000000018066EC90-0x000000018066ECA0 
	public RectTransform RegisterButtonRect { get; } // 0x000000018066ECA0-0x000000018066EDC0 
	public RectTransform CardRect { get; } // 0x000000018066EDC0-0x000000018066EF00 

	// Constructors
	public RegisterForm(); // 0x0000000180673D10-0x0000000180673D70

	// Methods
	public void Build(Transform parent); // 0x000000018066EF00-0x00000001806708C0
	private void BuildStrengthBar(LoginConfig.StringsCfg s); // 0x00000001806708C0-0x0000000180670EA0
	private void OnNameChanged(string raw); // 0x0000000180670EA0-0x0000000180671110
	private void Revalidate(); // 0x0000000180671110-0x00000001806714E0
	private static bool ValidName(string raw); // 0x00000001806714E0-0x00000001806718B0
	private static bool ValidUser(string raw); // 0x00000001806718B0-0x0000000180671920
	private static bool ValidPass(string raw); // 0x0000000180671920-0x0000000180671940
	private static void Rim(Image rim, string value, bool ok); // 0x0000000180671940-0x0000000180671B40
	private void RefreshStrength(string pass); // 0x0000000180671B40-0x00000001806721D0
	private void ToggleEye(); // 0x00000001806721D0-0x0000000180672280
	private static void NextField(LoginField next); // 0x0000000180672280-0x00000001806723F0
	private void OnConfirmEndEdit(string _); // 0x00000001806723F0-0x0000000180672480
	public void Submit(); // 0x0000000180672480-0x0000000180672BD0
	private void FocusWithError(LoginField f, string message); // 0x0000000180672BD0-0x0000000180672D30
	public void Focus(); // 0x0000000180672D30-0x0000000180672E30
	public void Reset(); // 0x0000000180672E30-0x0000000180673150
	public void SetInteractable(bool on); // 0x0000000180673150-0x0000000180673430
	public void MarkTaken(bool userTaken, bool nameTaken); // 0x0000000180673430-0x00000001806737D0
	public void MarkDeviceLimit(); // 0x00000001806737D0-0x0000000180673920
	public void ShowError(string message); // 0x0000000180673920-0x0000000180673AD0
	public void ClearError(); // 0x0000000180673AD0-0x0000000180673C50
	private static string Safe(string format, object arg0); // 0x0000000180673C50-0x0000000180673D10
	[CompilerGenerated]
	private void _Build_b__44_0(string _); // 0x0000000180673D70-0x0000000180673DC0
	[CompilerGenerated]
	private void _Build_b__44_1(string _); // 0x0000000180673DC0-0x0000000180673DD0
	[CompilerGenerated]
	private void _Build_b__44_2(string _); // 0x0000000180673DD0-0x0000000180673E20
	[CompilerGenerated]
	private void _Build_b__44_3(string _); // 0x0000000180673DC0-0x0000000180673DD0
	[CompilerGenerated]
	private void _Build_b__44_4(string _); // 0x0000000180673E20-0x0000000180673E70
	[CompilerGenerated]
	private void _Build_b__44_5(string _); // 0x0000000180673DC0-0x0000000180673DD0
}

