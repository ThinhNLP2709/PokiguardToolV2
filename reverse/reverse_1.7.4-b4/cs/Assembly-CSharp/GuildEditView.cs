/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildEditView : MonoBehaviour // TypeDefIndex: 788
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x20
	[SerializeField]
	private InputField inputSlogan; // 0x28
	[SerializeField]
	private GuildLogoView logo; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtLogo; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtPattern; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtBackground; // 0x48
	[SerializeField]
	private Button btnConfirm; // 0x50
	[SerializeField]
	private Button btnClose; // 0x58
	[Header("Popup \u0111\u1ED5i t\u00EAn")]
	[SerializeField]
	private GameObject renamePopup; // 0x60
	[SerializeField]
	private InputField inputRename; // 0x68
	[SerializeField]
	private Button btnRenameConfirm; // 0x70
	[SerializeField]
	private Button btnRenameClose; // 0x78
	[SerializeField]
	private UnityEngine.UI.Text txtRenameFee; // 0x80
	private GuildPanelController _owner; // 0x88
	private bool _wired; // 0x90
	private GuildInfo _guild; // 0x98
	private int _logoId; // 0xA0
	private int _bgId; // 0xA4
	private List<int> _pets; // 0xA8
	private int _petIdx; // 0xB0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 789
	{
		// Fields
		public GuildEditView __4__this; // 0x10
		public Action done; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPets_b__0(List<int> list); // 0x00000001805111D0-0x0000000180511440
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 790
	{
		// Fields
		public GuildEditView __4__this; // 0x10
		public string name; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickRename_b__0(); // 0x0000000180511440-0x0000000180511470
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass35_0 // TypeDefIndex: 791
	{
		// Fields
		public GuildEditView __4__this; // 0x10
		public string name; // 0x18

		// Constructors
		public __c__DisplayClass35_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SubmitRename_b__0(GuildActionData d); // 0x0000000180511470-0x0000000180511710
		internal void _SubmitRename_b__1(); // 0x0000000180511710-0x0000000180511820
	}

	// Constructors
	public GuildEditView(); // 0x0000000180510C80-0x0000000180510CE0

	// Methods
	public void Init(GuildPanelController owner); // 0x000000018050D070-0x000000018050D0D0
	private void EnsureWired(); // 0x000000018050D0D0-0x000000018050E240
	public void Open(GuildInfo g); // 0x000000018050E240-0x000000018050E7C0
	private void LoadPets(Action done = null); // 0x000000018050E7C0-0x000000018050E960
	public void Close(); // 0x000000018050E960-0x000000018050EAA0
	private void WireLogoTouch(Transform editRoot); // 0x000000018050EAA0-0x000000018050EC60
	private void OpenPicker(); // 0x000000018050EC60-0x000000018050EDD0
	private void ShowPicker(); // 0x000000018050EDD0-0x000000018050EEB0
	private void StepBg(int d); // 0x000000018050EEB0-0x000000018050EF20
	private static int Wrap(int v, int count); // 0x00000001804FAD30-0x00000001804FAD50
	private void RefreshFlag(bool animate); // 0x000000018050EF20-0x000000018050F480
	private void OnClickSave(); // 0x000000018050F480-0x000000018050FA30
	private void OpenRename(); // 0x000000018050FA30-0x000000018050FE00
	private void CloseRename(); // 0x000000018050FE00-0x000000018050FFB0
	private void OnClickRename(); // 0x000000018050FFB0-0x0000000180510620
	private void SubmitRename(string name); // 0x0000000180510620-0x0000000180510C80
	[CompilerGenerated]
	private void _EnsureWired_b__21_0(); // 0x0000000180510CE0-0x0000000180510D40
	[CompilerGenerated]
	private void _EnsureWired_b__21_1(); // 0x0000000180510D40-0x0000000180510DA0
	[CompilerGenerated]
	private void _ShowPicker_b__27_0(int petId); // 0x0000000180510DA0-0x0000000180510EF0
	[CompilerGenerated]
	private void _OnClickSave_b__31_0(GuildActionData d); // 0x0000000180510EF0-0x00000001805110D0
	[CompilerGenerated]
	private void _OnClickSave_b__31_1(); // 0x00000001805110D0-0x00000001805111D0
}

