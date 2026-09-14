/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class LoginForm : MonoBehaviour // TypeDefIndex: 1052
{
	// Fields
	private const float PAD = 40f; // Metadata: 0x005F06C6
	private const float FIELD_W = 680f; // Metadata: 0x005F06CA
	public Action<string, string, bool> OnSubmit; // 0x20
	public Action OnForgot; // 0x28
	private LoginField _user; // 0x30
	private LoginField _pass; // 0x68
	private Image _chkBox; // 0xA0
	private Image _chkTick; // 0xA8
	private UnityEngine.UI.Text _lblRemember; // 0xB0
	private UnityEngine.UI.Text _txtError; // 0xB8
	private UnityEngine.UI.Text _txtHint; // 0xC0
	private UnityEngine.UI.Text _txtTerms; // 0xC8
	private Button _btnLogin; // 0xD0
	private Button _btnForgot; // 0xD8
	private UnityEngine.UI.Text _btnLoginLabel; // 0xE0
	private Image _eyeIcon; // 0xE8
	private UnityEngine.UI.Text _eyeLabel; // 0xF0
	private bool _passVisible; // 0xF8
	private bool _remember; // 0xF9
	private bool _interactable; // 0xFA
	[CompilerGenerated]
	private CanvasGroup _Group_k__BackingField; // 0x100
	[CompilerGenerated]
	private RectTransform _Rect_k__BackingField; // 0x108

	// Properties
	public CanvasGroup Group { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4A40-0x00000001802B4A50 0x00000001802B4AF0-0x00000001802B4B50
	public RectTransform Rect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C79A0-0x00000001803C79B0 0x00000001803C79B0-0x00000001803C7A10
	public RectTransform CardRect { get; } // 0x0000000180650B30-0x0000000180650C70 
	public UnityEngine.UI.Text ErrorText { get; } // 0x00000001802D8FA0-0x00000001802D8FB0 
	public Image RimUser { get; } // 0x00000001802BA640-0x00000001802BA650 
	public Image RimPass { get; } // 0x00000001802A86B0-0x00000001802A86C0 
	public Button LoginButton { get; } // 0x00000001802D90F0-0x00000001802D9100 
	public RectTransform LoginButtonRect { get; } // 0x0000000180650C70-0x0000000180650D90 
	public string UserName { get; } // 0x0000000180650D90-0x0000000180650DC0 
	public bool Remember { get; } // 0x0000000180650DC0-0x0000000180650DD0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1053
	{
		// Fields
		public LoginField captured; // 0x10

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Wire_b__0(); // 0x0000000180654560-0x00000001806545D0
		internal void _Wire_b__1(); // 0x00000001806545D0-0x0000000180654640
	}

	// Constructors
	public LoginForm(); // 0x0000000180654510-0x0000000180654560

	// Methods
	public void Build(Transform parent); // 0x0000000180650DD0-0x0000000180652000
	private void BuildRememberRow(LoginConfig.StringsCfg s); // 0x0000000180652000-0x0000000180652610
	private Button BuildFlatButton(string name, float x, float y, float w, float h, string label, float fontSize, Color color, TextAnchor align, UnityAction onTap); // 0x0000000180652610-0x0000000180652870
	private void Wire(LoginField f); // 0x0000000180652870-0x0000000180652AE0
	private void ToggleEye(); // 0x0000000180652AE0-0x0000000180652B90
	private void ToggleRemember(); // 0x0000000180652B90-0x0000000180652BB0
	private void SetRemember(bool on); // 0x0000000180652BB0-0x0000000180652FE0
	private void OnUserEndEdit(string _); // 0x0000000180652FE0-0x0000000180653100
	private void OnPassEndEdit(string _); // 0x0000000180653100-0x0000000180653220
	private static bool EnterOrTab(); // 0x0000000180653220-0x0000000180653250
	private static bool EnterPressed(); // 0x0000000180653250-0x00000001806532C0
	private static bool TabPressed(); // 0x00000001806532C0-0x0000000180653320
	public void Submit(); // 0x0000000180653320-0x0000000180653760
	public void Focus(); // 0x0000000180653760-0x0000000180653910
	public void Reset(); // 0x0000000180653910-0x0000000180653B60
	public void Prefill(string user, bool remember); // 0x0000000180653B60-0x0000000180653CB0
	public void SetInteractable(bool on); // 0x0000000180653CB0-0x0000000180653F60
	public void SetPrimaryLabel(string label); // 0x0000000180653F60-0x00000001806540A0
	public void SetHint(string hint); // 0x00000001806540A0-0x00000001806541E0
	public void ShowError(string message); // 0x00000001806541E0-0x0000000180654390
	public void ClearError(); // 0x0000000180654390-0x00000001806543E0
	public void SetPasswordForAutoSubmit(string pass); // 0x00000001806543E0-0x0000000180654510
	[CompilerGenerated]
	private void _Build_b__44_0(); // 0x000000018029FCA0-0x000000018029FCC0
}

