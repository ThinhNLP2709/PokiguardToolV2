/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class LoginForm : MonoBehaviour // TypeDefIndex: 1050
{
	// Fields
	private const float PAD = 40f; // Metadata: 0x005EF2F9
	private const float FIELD_W = 680f; // Metadata: 0x005EF2FD
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
	public RectTransform Rect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6CD0-0x00000001803C6CE0 0x00000001803C6CE0-0x00000001803C6D40
	public RectTransform CardRect { get; } // 0x000000018064F140-0x000000018064F280 
	public UnityEngine.UI.Text ErrorText { get; } // 0x00000001802D8F70-0x00000001802D8F80 
	public Image RimUser { get; } // 0x00000001802BA610-0x00000001802BA620 
	public Image RimPass { get; } // 0x00000001802A86B0-0x00000001802A86C0 
	public Button LoginButton { get; } // 0x00000001802D90C0-0x00000001802D90D0 
	public RectTransform LoginButtonRect { get; } // 0x000000018064F280-0x000000018064F3A0 
	public string UserName { get; } // 0x000000018064F3A0-0x000000018064F3D0 
	public bool Remember { get; } // 0x000000018064F3D0-0x000000018064F3E0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1051
	{
		// Fields
		public LoginField captured; // 0x10

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Wire_b__0(); // 0x0000000180652B70-0x0000000180652BE0
		internal void _Wire_b__1(); // 0x0000000180652BE0-0x0000000180652C50
	}

	// Constructors
	public LoginForm(); // 0x0000000180652B20-0x0000000180652B70

	// Methods
	public void Build(Transform parent); // 0x000000018064F3E0-0x0000000180650610
	private void BuildRememberRow(LoginConfig.StringsCfg s); // 0x0000000180650610-0x0000000180650C20
	private Button BuildFlatButton(string name, float x, float y, float w, float h, string label, float fontSize, Color color, TextAnchor align, UnityAction onTap); // 0x0000000180650C20-0x0000000180650E80
	private void Wire(LoginField f); // 0x0000000180650E80-0x00000001806510F0
	private void ToggleEye(); // 0x00000001806510F0-0x00000001806511A0
	private void ToggleRemember(); // 0x00000001806511A0-0x00000001806511C0
	private void SetRemember(bool on); // 0x00000001806511C0-0x00000001806515F0
	private void OnUserEndEdit(string _); // 0x00000001806515F0-0x0000000180651710
	private void OnPassEndEdit(string _); // 0x0000000180651710-0x0000000180651830
	private static bool EnterOrTab(); // 0x0000000180651830-0x0000000180651860
	private static bool EnterPressed(); // 0x0000000180651860-0x00000001806518D0
	private static bool TabPressed(); // 0x00000001806518D0-0x0000000180651930
	public void Submit(); // 0x0000000180651930-0x0000000180651D70
	public void Focus(); // 0x0000000180651D70-0x0000000180651F20
	public void Reset(); // 0x0000000180651F20-0x0000000180652170
	public void Prefill(string user, bool remember); // 0x0000000180652170-0x00000001806522C0
	public void SetInteractable(bool on); // 0x00000001806522C0-0x0000000180652570
	public void SetPrimaryLabel(string label); // 0x0000000180652570-0x00000001806526B0
	public void SetHint(string hint); // 0x00000001806526B0-0x00000001806527F0
	public void ShowError(string message); // 0x00000001806527F0-0x00000001806529A0
	public void ClearError(); // 0x00000001806529A0-0x00000001806529F0
	public void SetPasswordForAutoSubmit(string pass); // 0x00000001806529F0-0x0000000180652B20
	[CompilerGenerated]
	private void _Build_b__44_0(); // 0x000000018029FCA0-0x000000018029FCC0
}

