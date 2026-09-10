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

public class GuildCreateView : MonoBehaviour // TypeDefIndex: 698
{
	// Fields
	[SerializeField]
	private InputField inputName; // 0x20
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
	private Button btnCreate; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtFee; // 0x58
	[SerializeField]
	private Button btnClose; // 0x60
	private GuildPanelController _owner; // 0x68
	private bool _wired; // 0x70
	private int _logoId; // 0x74
	private int _bgId; // 0x78
	private List<int> _pets; // 0x80
	private int _petIdx; // 0x88

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 699
	{
		// Fields
		public GuildCreateView __4__this; // 0x10
		public Action done; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPets_b__0(List<int> list); // 0x0000000180467F30-0x0000000180468110
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 700
	{
		// Fields
		public GuildCreateView __4__this; // 0x10
		public string name; // 0x18
		public string slogan; // 0x20

		// Constructors
		public __c__DisplayClass28_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickCreate_b__0(); // 0x0000000180468250-0x0000000180468280
	}

	// Constructors
	public GuildCreateView(); // 0x000000018045B410-0x000000018045B430

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180459AA0-0x0000000180459AD0
	private void EnsureWired(); // 0x0000000180459050-0x0000000180459AA0
	private void WireLogoTouch(); // 0x000000018045B230-0x000000018045B3F0
	public void Open(); // 0x000000018045A270-0x000000018045A4B0
	private void LoadPets(Action done = null); // 0x0000000180459AD0-0x0000000180459BD0
	public void Close(); // 0x0000000180458DD0-0x0000000180458E60
	private void OpenPicker(); // 0x000000018045A120-0x000000018045A270
	private void ShowPicker(); // 0x000000018045AA60-0x000000018045AB20
	private void StepBg(int d); // 0x000000018045AB20-0x000000018045AB80
	private static int Wrap(int v, int count); // 0x000000018045B3F0-0x000000018045B410
	private void RefreshFlag(bool animate); // 0x000000018045A670-0x000000018045AA60
	internal static string EmblemLabel(List<int> pets, int idx); // 0x0000000180458E60-0x0000000180459050
	private void PlayFlagFx(); // 0x000000018045A4B0-0x000000018045A670
	private void OnClickCreate(); // 0x0000000180459BD0-0x000000018045A120
	private void Submit(string name, string slogan); // 0x000000018045AB80-0x000000018045AE50
	[CompilerGenerated]
	private void _EnsureWired_b__16_0(); // 0x000000018045AE50-0x000000018045AEB0
	[CompilerGenerated]
	private void _EnsureWired_b__16_1(); // 0x000000018045AEB0-0x000000018045AF10
	[CompilerGenerated]
	private void _ShowPicker_b__22_0(int petId); // 0x000000018045AF10-0x000000018045AFC0
	[CompilerGenerated]
	private void _Submit_b__29_0(GuildActionData d); // 0x000000018045AFC0-0x000000018045B1B0
	[CompilerGenerated]
	private void _Submit_b__29_1(); // 0x000000018045B1B0-0x000000018045B230
}

