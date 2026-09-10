/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildEditView : MonoBehaviour // TypeDefIndex: 701
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
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 702
	{
		// Fields
		public GuildEditView __4__this; // 0x10
		public Action done; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPets_b__0(List<int> list); // 0x0000000180468110-0x0000000180468250
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 703
	{
		// Fields
		public GuildEditView __4__this; // 0x10
		public string name; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickRename_b__0(); // 0x0000000180468280-0x00000001804682B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass35_0 // TypeDefIndex: 704
	{
		// Fields
		public GuildEditView __4__this; // 0x10
		public string name; // 0x18

		// Constructors
		public __c__DisplayClass35_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SubmitRename_b__0(GuildActionData d); // 0x00000001804682B0-0x0000000180468480
		internal void _SubmitRename_b__1(); // 0x0000000180468480-0x0000000180468510
	}

	// Constructors
	public GuildEditView(); // 0x000000018045DB20-0x000000018045DB40

	// Methods
	public void Init(GuildPanelController owner); // 0x000000018045C0C0-0x000000018045C0F0
	private void EnsureWired(); // 0x000000018045B560-0x000000018045C0C0
	public void Open(GuildInfo g); // 0x000000018045CC00-0x000000018045CE30
	private void LoadPets(Action done = null); // 0x000000018045C0F0-0x000000018045C1F0
	public void Close(); // 0x000000018045B4C0-0x000000018045B560
	private void WireLogoTouch(Transform editRoot); // 0x000000018045D970-0x000000018045DB20
	private void OpenPicker(); // 0x000000018045C920-0x000000018045CA70
	private void ShowPicker(); // 0x000000018045D1F0-0x000000018045D2B0
	private void StepBg(int d); // 0x000000018045D2B0-0x000000018045D320
	private static int Wrap(int v, int count); // 0x000000018045B3F0-0x000000018045B410
	private void RefreshFlag(bool animate); // 0x000000018045CE30-0x000000018045D1F0
	private void OnClickSave(); // 0x000000018045C6A0-0x000000018045C920
	private void OpenRename(); // 0x000000018045CA70-0x000000018045CC00
	private void CloseRename(); // 0x000000018045B430-0x000000018045B4C0
	private void OnClickRename(); // 0x000000018045C1F0-0x000000018045C6A0
	private void SubmitRename(string name); // 0x000000018045D320-0x000000018045D610
	[CompilerGenerated]
	private void _EnsureWired_b__21_0(); // 0x000000018045D610-0x000000018045D670
	[CompilerGenerated]
	private void _EnsureWired_b__21_1(); // 0x000000018045D670-0x000000018045D6D0
	[CompilerGenerated]
	private void _ShowPicker_b__27_0(int petId); // 0x000000018045D8C0-0x000000018045D970
	[CompilerGenerated]
	private void _OnClickSave_b__31_0(GuildActionData d); // 0x000000018045D6D0-0x000000018045D840
	[CompilerGenerated]
	private void _OnClickSave_b__31_1(); // 0x000000018045D840-0x000000018045D8C0
}

