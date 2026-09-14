/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildCreateView : MonoBehaviour // TypeDefIndex: 773
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
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 774
	{
		// Fields
		public GuildCreateView __4__this; // 0x10
		public Action done; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPets_b__0(List<int> list); // 0x00000001804FB0B0-0x00000001804FB400
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 775
	{
		// Fields
		public GuildCreateView __4__this; // 0x10
		public string name; // 0x18
		public string slogan; // 0x20

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickCreate_b__0(); // 0x00000001804FB400-0x00000001804FB430
	}

	// Constructors
	public GuildCreateView(); // 0x00000001804FAAE0-0x00000001804FAB40

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001804F78B0-0x00000001804F7910
	private void EnsureWired(); // 0x00000001804F7910-0x00000001804F8800
	private void WireLogoTouch(); // 0x00000001804F8800-0x00000001804F89D0
	public void Open(); // 0x00000001804F89D0-0x00000001804F9000
	private void LoadPets(Action done = null); // 0x00000001804F9000-0x00000001804F91A0
	public void Close(); // 0x00000001804F91A0-0x00000001804F92E0
	private void OpenPicker(); // 0x00000001804F92E0-0x00000001804F9450
	private void ShowPicker(); // 0x00000001804F9450-0x00000001804F9530
	private void StepBg(int d); // 0x00000001804F9530-0x00000001804F9590
	private static int Wrap(int v, int count); // 0x00000001804F9590-0x00000001804F95B0
	private void RefreshFlag(bool animate); // 0x00000001804F95B0-0x00000001804F9880
	internal static string EmblemLabel(List<int> pets, int idx); // 0x00000001804F9880-0x00000001804F9AD0
	private void PlayFlagFx(); // 0x00000001804F9AD0-0x00000001804F9DA0
	private void OnClickCreate(); // 0x00000001804F9DA0-0x00000001804FA510
	private void Submit(string name, string slogan); // 0x00000001804FA510-0x00000001804FAAE0
	[CompilerGenerated]
	private void _EnsureWired_b__16_0(); // 0x00000001804FAB40-0x00000001804FABA0
	[CompilerGenerated]
	private void _EnsureWired_b__16_1(); // 0x00000001804FABA0-0x00000001804FAC00
	[CompilerGenerated]
	private void _ShowPicker_b__22_0(int petId); // 0x00000001804FAC00-0x00000001804FAD50
	[CompilerGenerated]
	private void _Submit_b__29_0(GuildActionData d); // 0x00000001804FAD50-0x00000001804FAFB0
	[CompilerGenerated]
	private void _Submit_b__29_1(); // 0x00000001804FAFB0-0x00000001804FB0B0
}

